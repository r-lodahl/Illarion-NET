Public Class ToolsV1Test
  <Theory>
  <InlineData("abcABC123456789", "illarion", "$1$", "$1$illarion$k2vCqcaMJJfPhtJiyn41D0")>
  Public Sub EncryptPasswordTest(password As String, salt As String, magic As String, encodedPassword As String)
    Assert.Equal(encodedPassword, EncryptPassword(password, salt, magic))
  End Sub
End Class