Imports System.Security.Cryptography

Friend Module ToolsV1
  Private ReadOnly IllaBase64 As String = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"

  Friend Function CalculateCrc(payload() As Byte, offset As Integer, length As Integer) As Short
    Dim caster As New Caster() With {.IntegerValue = 0}
    For i = offset To offset + length - 1
      caster.IntegerValue = CInt(caster.ShortValue1) + payload(i)
    Next
    Return caster.ShortValue1
  End Function

  Friend Function EncryptPassword(password As String, salt As String, magic As String) As String
    If password Is Nothing Then Throw New ArgumentNullException(NameOf(password))
    If salt Is Nothing Then Throw New ArgumentNullException(NameOf(salt))
    If magic Is Nothing Then Throw New ArgumentNullException(NameOf(magic))

    Dim cleanSalt = GetCleanedSalt(salt, magic)

    Dim encoding = Text.Encoding.GetEncoding("ISO-8859-1")
    Dim passwordBytes = encoding.GetBytes(password)
    Dim saltBytes = encoding.GetBytes(cleanSalt)
    Dim magicBytes = encoding.GetBytes(magic)

    Dim encPasswordBytes = EncryptPassword(passwordBytes, saltBytes, magicBytes)

    Return magic & salt & "$"c & ToBase64String(encPasswordBytes)
  End Function

  Private Function ToBase64String(bytes() As Byte) As String
    Dim base64 As New Text.StringBuilder()
    For i = 0 To 3
      AppendTo64(base64, (CInt(bytes(i)) << 16) Or (CInt(bytes(i + 6)) << 8) Or bytes(i + 12), 4)
    Next
    AppendTo64(base64, (CInt(bytes(4)) << 16) Or (CInt(bytes(10)) << 8) Or bytes(5), 4)
    AppendTo64(base64, bytes(11), 2)
    Return base64.ToString
  End Function

  Private Sub AppendTo64(builder As Text.StringBuilder, value As Integer, size As Integer)
    Dim currentValue = value
    For i = 0 To size - 1
      builder.Append(IllaBase64(currentValue And &H3F))
      currentValue >>= 6
    Next
  End Sub

  Private Function EncryptPassword(password() As Byte, salt() As Byte, magic() As Byte) As Byte()
    If password Is Nothing Then Throw New ArgumentNullException(NameOf(password))
    If salt Is Nothing Then Throw New ArgumentNullException(NameOf(salt))
    If magic Is Nothing Then Throw New ArgumentNullException(NameOf(magic))

    Dim hashProvider = IncrementalHash.CreateHash(HashAlgorithmName.MD5)
    hashProvider.AppendData(password)
    hashProvider.AppendData(salt)
    hashProvider.AppendData(password)
    Dim currentHash = hashProvider.GetHashAndReset()

    hashProvider.AppendData(password)
    hashProvider.AppendData(magic)
    hashProvider.AppendData(salt)

    For length = password.Length To 1 Step -16
      hashProvider.AppendData(currentHash, 0, Math.Min(length, 16))
    Next

    Array.Clear(currentHash, 0, currentHash.Length)

    Dim i = password.Length()
    While i <> 0
      If (i And 1) = 0 Then
        hashProvider.AppendData(password, 0, 1)
      Else
        hashProvider.AppendData(currentHash, 0, 1)
      End If
      i >>= 1
    End While

    Dim currentEncPassword = hashProvider.GetHashAndReset()

    For i = 0 To 999
      If (i And 1) = 0 Then
        hashProvider.AppendData(currentEncPassword, 0, 16)
      Else
        hashProvider.AppendData(password)
      End If

      If (i Mod 3) <> 0 Then
        hashProvider.AppendData(salt)
      End If

      If (i Mod 7) <> 0 Then
        hashProvider.AppendData(password)
      End If

      If (i And 1) = 0 Then
        hashProvider.AppendData(password)
      Else
        hashProvider.AppendData(currentEncPassword, 0, 16)
      End If

      currentEncPassword = hashProvider.GetHashAndReset()
    Next

    Return currentEncPassword
  End Function

  Private Function GetCleanedSalt(salt As String, magic As String) As String
    If salt Is Nothing Then Throw New ArgumentNullException(NameOf(salt))
    If magic Is Nothing Then Throw New ArgumentNullException(NameOf(magic))

    Dim cleanedSalt = If(salt.StartsWith(magic), salt.Substring(magic.Length), salt)

    Dim saltTerminatorIndex = cleanedSalt.IndexOf("$"c)
    If saltTerminatorIndex <> -1 Then
      cleanedSalt = cleanedSalt.Substring(0, saltTerminatorIndex)
    End If
    If cleanedSalt.Length > 8 Then
      cleanedSalt = cleanedSalt.Substring(0, 8)
    End If
    Return cleanedSalt
  End Function
End Module
