<DebuggerDisplay("{toString()}", Name:="Location")>
Public Structure Location
  Implements IEquatable(Of Location)

  Public Property X As Integer
  Public Property Y As Integer
  Public Property Z As Integer

  Public Sub New(x As Integer, y As Integer, z As Integer)
    Me.X = x
    Me.Y = y
    Me.Z = z
  End Sub

  Public Overrides Function Equals(obj As Object) As Boolean
    Return TypeOf obj Is Location AndAlso Equals(DirectCast(obj, Location))
  End Function

  Public Overloads Function Equals(other As Location) As Boolean Implements IEquatable(Of Location).Equals
    Return X = other.X AndAlso Y = other.Y AndAlso Z = other.Z
  End Function

  Public Overrides Function GetHashCode() As Integer
    Dim caster As New HashCodeCaster() With {.LongValue = 31L}
    caster.LongValue = caster.IntValue * 23L + X.GetHashCode()
    caster.LongValue = caster.IntValue * 23L + Y.GetHashCode()
    caster.LongValue = caster.IntValue * 23L + Z.GetHashCode()
    Return caster.GetHashCode()
  End Function

  Public Overrides Function ToString() As String
    Return $"{X}, {Y}, {Z}"
  End Function
End Structure
