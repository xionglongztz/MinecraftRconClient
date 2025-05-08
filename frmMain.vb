Imports System.Net.NetworkInformation

Public Class frmMain
    Private Rcon As RconClient
    Dim originConsoleTitle As String
    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click '连接RCON
        Try
            Rcon = New RconClient(TxtIP.Text, Val(TxtPort.Text), TxtPasswd.Text)
            If Rcon.Connect() Then
                BtnConnect.Enabled = False
                BtnDisconnect.Enabled = True
                TxtIP.Enabled = False
                TxtPasswd.Enabled = False
                TxtPort.Enabled = False
                Console.Title = "RCON Client Connected - " & TxtIP.Text & ":" & TxtPort.Text
            Else
                Throw New Exception("连接失败!")
            End If
        Catch ex As Exception
            LogError("[RCON] " & ex.Message)
            If Rcon.IsConnected = True Then Rcon.Disconnect() '断开连接
        End Try
    End Sub
    Private Sub BtnSendCommand_Click(sender As Object, e As EventArgs) Handles BtnSendCommand.Click '发送RCON命令
        If Rcon Is Nothing Then '未初始化
            LogWarn("[RCON] 当前未初始化")
            Return
        End If
        If Not Rcon.IsConnected Then '断开连接
            LogWarn("[RCON] 当前已断开连接")
            Return
        End If
        Dim command = TextBoxCommand.Text.Trim()
        If String.IsNullOrEmpty(command) Then Return '当命令为空时不执行
        If Not IsNetworkAvailable() Then
            Throw New Exception("当前网络不可用!")
            Return
        End If
        Try
            Rcon.SendCommand(command)
            TextBoxCommand.Text = "" '清空
        Catch ex As Exception
            LogError("[RCON] " & ex.Message)
        End Try
    End Sub
    '关闭时断开RCON
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Rcon IsNot Nothing Then Rcon.Disconnect() '断开连接
        LogInfo("[RCON] §c程序已退出")
        Console.Title = originConsoleTitle '改回标题
        Console.CursorVisible = True
        FreeConsole() '释放控制台
    End Sub
    Private Sub BtnDisconnect_Click(sender As Object, e As EventArgs) Handles BtnDisconnect.Click
        If Rcon IsNot Nothing Then
            BtnConnect.Enabled = True
            BtnDisconnect.Enabled = False
            TxtIP.Enabled = True
            TxtPasswd.Enabled = True
            TxtPort.Enabled = True
            Rcon.Disconnect() '断开连接
        End If
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AttachConsole(-1) Then '请求附加到控制台
            AllocConsole() '如果附加失败,新建控制台
            LogInfo("[RCON] 未检测到控制台,已开启新的控制台!")
        Else
            Console.WriteLine()
            LogInfo("[RCON] 检测到已有的控制台!")
        End If
        originConsoleTitle = Console.Title
        LogInfo("[RCON] §e程序已启动§6(PID:" & Process.GetCurrentProcess.Id & ")")
        BtnDisconnect.Enabled = False
        Console.Title = "RCON Client"
        Console.CursorVisible = False
        Dim consoleHandle As IntPtr = GetConsoleHandle()
        If consoleHandle <> IntPtr.Zero Then LogInfo($"[RCON] §b控制台句柄:0x{consoleHandle.ToInt64():X8}")
        LogInfo($"[RCON] §b主窗口句柄:0x{Handle.ToInt64():X8}")
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        Console.Clear()
    End Sub
    Public Function IsNetworkAvailable() As Boolean
        Return NetworkInterface.GetIsNetworkAvailable()
    End Function
End Class
