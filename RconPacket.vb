Imports System.Text
Public Class RconPacket 'RCON数据包结构
    Public Property RequestId As Integer
    Public Property Type As Integer
    Public Property Payload As String
    Public Sub New(requestId As Integer, type As Integer, payload As String)
        Me.RequestId = requestId
        Me.Type = type
        Me.Payload = payload
    End Sub
    Public Function ToBytes() As Byte()
        Dim bodyBytes As Byte() = Encoding.UTF8.GetBytes(Payload)
        ' 数据负载的长度：RequestId (4) + Type (4) + Body + 两个 Null 字节 (1 + 1)
        Dim payloadLength As Integer = 4 + 4 + bodyBytes.Length + 2
        ' 整个数据包的长度：4 字节的长度字段 + 数据负载的长度
        Dim packetLength As Integer = 4 + payloadLength
        Dim packet As Byte() = New Byte(packetLength - 1) {}
        ' 包长度 (不包括长度字段本身)
        Buffer.BlockCopy(BitConverter.GetBytes(payloadLength), 0, packet, 0, 4)
        ' 请求 ID
        Buffer.BlockCopy(BitConverter.GetBytes(RequestId), 0, packet, 4, 4)
        ' 包类型
        Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, packet, 8, 4)
        ' 包体
        Buffer.BlockCopy(bodyBytes, 0, packet, 12, bodyBytes.Length)
        ' 写入两个 Null 终止符
        If packet.Length > 12 + bodyBytes.Length Then
            packet(12 + bodyBytes.Length) = 0 ' Body 后的 Null 终止符
        End If
        If packet.Length > 13 + bodyBytes.Length Then
            packet(13 + bodyBytes.Length) = 0 ' Body 后的空字符串的 Null 终止符
        End If
        Return packet
    End Function
End Class