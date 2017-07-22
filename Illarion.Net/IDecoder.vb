Imports System.IO
Imports Illarion.Core.Types

Public Interface IDecoder
  Sub Shutdown()
  Function ReadString(stream As Stream) As String
  Function ReadByte(stream As Stream) As Byte
  Function ReadShort(stream As Stream) As Short
  Function ReadCharacterId(stream As Stream) As CharacterId
  Function ReadLocation(stream As Stream) As Location
End Interface
