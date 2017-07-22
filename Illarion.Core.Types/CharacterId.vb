<DebuggerDisplay("{toString()}", Name:="Character ID")>
Public Structure CharacterId
  Implements IComparable, IComparable(Of CharacterId)
  Implements IEquatable(Of CharacterId)
  Implements IFormattable

  Private ReadOnly _id As UInteger

  Public Sub New(id As UInteger)
    _id = id
  End Sub

#Region "IComparable/IComparable(of )"
  Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
    If TypeOf obj Is CharacterId Then
      Return CompareTo(DirectCast(obj, CharacterId))
    End If
    Return 1
  End Function

  Public Function CompareTo(other As CharacterId) As Integer Implements IComparable(Of CharacterId).CompareTo
    Return _id.CompareTo(other._id)
  End Function
#End Region

#Region "IFormattable"
  Public Overloads Function ToString(format As String, formatProvider As IFormatProvider) As String Implements IFormattable.ToString
    Return _id.ToString(format, formatProvider)
  End Function
#End Region

#Region "IEquatable(Of )"
  Public Overloads Function Equals(other As CharacterId) As Boolean Implements IEquatable(Of CharacterId).Equals
    Return _id.Equals(other._id)
  End Function
#End Region

#Region "Object"
  Public Overrides Function Equals(obj As Object) As Boolean
    Return TypeOf obj Is CharacterId AndAlso Equals(DirectCast(obj, CharacterId))
  End Function

  Public Overrides Function GetHashCode() As Integer
    Return _id.GetHashCode()
  End Function

  Public Overrides Function ToString() As String
    Return _id.ToString
  End Function
#End Region

#Region "Operators"
  Public Shared Widening Operator CType(id As CharacterId) As UInteger
    Return id._id
  End Operator
  Public Shared Widening Operator CType(id As UInteger) As CharacterId
    Return New CharacterId(id)
  End Operator
  Public Shared Operator =(first As CharacterId, second As CharacterId) As Boolean
    Return first._id = second._id
  End Operator
  Public Shared Operator <>(first As CharacterId, second As CharacterId) As Boolean
    Return first._id <> second._id
  End Operator
  Public Shared Operator <(first As CharacterId, second As CharacterId) As Boolean
    Return first._id < second._id
  End Operator
  Public Shared Operator >(first As CharacterId, second As CharacterId) As Boolean
    Return first._id > second._id
  End Operator
  Public Shared Operator <=(first As CharacterId, second As CharacterId) As Boolean
    Return first._id <= second._id
  End Operator
  Public Shared Operator >=(first As CharacterId, second As CharacterId) As Boolean
    Return first._id >= second._id
  End Operator
#End Region
End Structure
