Imports System.IO

Public Interface IMessageSink
  Sub ProcessMessage(decoder As IDecoder, id As Byte, payload As Stream)
End Interface
