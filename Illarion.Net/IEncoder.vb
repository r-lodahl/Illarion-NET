Imports System.IO
Imports Illarion.Core.Types

Public Interface IEncoder
  Sub Encode(value As String, stream As Stream)
  Sub Encode(value As Byte, stream As Stream)
  Sub Encode(value As UShort, stream As Stream)
  Sub Encode(value As Short, stream As Stream)
  Sub Encode(value As UInteger, stream As Stream)
  Sub Encode(value As Integer, stream As Stream)
  Sub Encode(value As CharacterId, stream As Stream)
  Sub Encode(value As Location, stream As Stream)
  Sub EncodePassword(value As String, stream As Stream)
  Function SendCommandAsync(commandId As Byte) As Task
  Function SendCommandAsync(commandId As Byte, payload As MemoryStream) As Task
  Function SendCommandAsync(commandId As Byte, payload() As Byte, offset As Integer, length As Integer) As Task
End Interface
