Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Explicit)>
Friend Structure Caster
  <FieldOffset(0)>
  Public IntegerValue As Integer
  <FieldOffset(0)>
  Public UIntegerValue As UInteger
  <FieldOffset(0)>
  Public ShortValue1 As Short
  <FieldOffset(2)>
  Public ShortValue2 As Short
  <FieldOffset(0)>
  Public UShortValue1 As UShort
  <FieldOffset(2)>
  Public UShortValue2 As UShort
  <FieldOffset(0)>
  Public ByteValue1 As Byte
  <FieldOffset(1)>
  Public ByteValue2 As Byte
  <FieldOffset(2)>
  Public ByteValue3 As Byte
  <FieldOffset(3)>
  Public ByteValue4 As Byte
End Structure