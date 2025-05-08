Imports System.Net.Sockets
Imports System.Text
Public Class RconClient
    Private RconClient As TcpClient
    Private RconStream As NetworkStream
    Private RconPassword As String
    Private RconHost As String
    Private RconPort As Integer
    Public Sub New(host As String, port As Integer, password As String) '初始化RCON实例
        RconHost = host '主机
        RconPort = port '端口
        RconPassword = password '密码
    End Sub
    Public ReadOnly Property IsConnected As Boolean '获得RCON连接状态
        Get
            Return RconClient IsNot Nothing AndAlso RconClient.Connected
        End Get
    End Property
    Public Function Connect() As Boolean '连接到RCON
        LogInfo("§e-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=")
        LogInfo("[RCON] 正在尝试连接到:" & RconHost & ":" & RconPort & "...")
        Try
            RconClient = New TcpClient()
            RconClient.ConnectAsync(RconHost, RconPort).Wait(5000) '设置连接超时（5秒）
            If Not RconClient.Connected Then
                Throw New Exception("连接超时,请检查你的网络连接!")
            End If
            RconStream = RconClient.GetStream()
            If Authenticate() = False Then Return False '验证失败时返回False
            LogInfo("[RCON] §a连接成功!")
            Return True
        Catch ex As Exception
            LogError("[RCON] " & ex.Message)
            If IsConnected = True Then Disconnect() '断开连接
            Return False
        End Try
    End Function
    Private Function Authenticate() As Boolean '认证RCON
        LogInfo("[RCON] 鉴权中...")
        Try
            Dim packet As New RconPacket(0, 3, RconPassword)
            SendPacket(packet)
            Dim response = ReceivePacket()
            If response.RequestId = -1 Then
                Throw New Exception("认证失败:密码错误或协议不兼容!")
            End If
            Return True
        Catch ex As Exception
            LogError("[RCON] " & ex.Message)
            If IsConnected = True Then Disconnect() '断开连接
            Return False
        End Try
    End Function
    Public Function SendCommand(command As String) As String '发送RCON命令
        Try
            LogInfo("[RCON] 输入命令:" & command) '显示发送的命令
            Dim packet As New RconPacket(1, 2, command)
            SendPacket(packet)
            Dim response = ReceivePacket().Payload
            LogInfo("[Server] " & response)
            Return response
        Catch ex As Exception
            LogError("[RCON] " & ex.Message)
            Return vbNullString
        End Try
    End Function
    Private Sub SendPacket(packet As RconPacket) '发送RCON数据包
        Dim data = packet.ToBytes()
        RconStream.Write(data, 0, data.Length)
    End Sub
    Private Function ReceivePacket() As RconPacket
        Dim sizeBytes(3) As Byte '读取4字节的长度字段
        Dim read = RconStream.Read(sizeBytes, 0, 4)
        If read < 4 Then Throw New Exception("数据包长度不完整")
        Dim size = BitConverter.ToInt32(sizeBytes, 0)
        Dim data(size - 1) As Byte
        Dim totalRead = 0
        While totalRead < size '循环读取剩余数据
            read = RconStream.Read(data, totalRead, size - totalRead)
            If read = 0 Then Throw New Exception("数据包未完整接收")
            totalRead += read
        End While
        Dim requestId = BitConverter.ToInt32(data, 0)
        Dim type = BitConverter.ToInt32(data, 4)
        Dim payload = Encoding.UTF8.GetString(data, 8, size - 10) '解析数据包
        Return New RconPacket(requestId, type, payload)
    End Function
    Public Sub Disconnect() '断开连接
        If RconStream IsNot Nothing Then RconStream.Close()
        If RconClient IsNot Nothing Then RconClient.Close()
        Console.Title = "RCON Client"
        LogInfo("[RCON] §c已断开连接!")
        LogInfo("§e-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=")
    End Sub
End Class

