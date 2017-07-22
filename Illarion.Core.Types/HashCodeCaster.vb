Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Explicit)>
Friend Structure HashCodeCaster
  <FieldOffset(0)>
  Public LongValue As Long
  <FieldOffset(0)>
  Public IntValue As Integer

  Public Overrides Function GetHashCode() As Integer
    Return IntValue
  End Function
End Structure
