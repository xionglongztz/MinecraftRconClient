Imports System.Text

Module logger
    Public Enum LogLevel
        Trace
        Info
        Warn
        [Error]
        Fatal
    End Enum
    Public Sub Log(message As String, Optional level As LogLevel = LogLevel.Info)
        Dim timestamp As String = DateTime.Now.ToString("HH:mm:ss.fff") '获取当前时间戳 yyyy-MM-dd HH:mm:ss.fff
        Select Case level'设置控制台颜色
            Case LogLevel.Trace
                Console.ForegroundColor = ConsoleColor.DarkGray
            Case LogLevel.Info
                Console.ForegroundColor = ConsoleColor.White
            Case LogLevel.Warn
                Console.ForegroundColor = ConsoleColor.Yellow
            Case LogLevel.Error
                Console.ForegroundColor = ConsoleColor.Red
            Case LogLevel.Fatal
                Console.ForegroundColor = ConsoleColor.Magenta
        End Select
        'Console.WriteLine($"[{timestamp}] [{level.ToString().ToUpper()}]: {message}") '输出带时间戳和级别的日志消息
        WriteColorText($"[{timestamp}] [{level.ToString().ToUpper()}]: {message}") '发送带颜色格式的信息
        Console.ResetColor() '恢复默认颜色
    End Sub
    Public Sub LogTrace(message As String)
        Log(message, LogLevel.Trace)
    End Sub
    Public Sub LogInfo(message As String)
        Log(message, LogLevel.Info)
    End Sub
    Public Sub LogWarn(message As String)
        Log(message, LogLevel.Warn)
    End Sub
    Public Sub LogError(message As String)
        Log(message, LogLevel.Error)
    End Sub
    Public Sub LogFatal(message As String)
        Log(message, LogLevel.Fatal)
    End Sub
    Private ReadOnly colorCodes As New Dictionary(Of Char, ConsoleColor) From {
        {"0", ConsoleColor.Black},
        {"1", ConsoleColor.DarkBlue},
        {"2", ConsoleColor.DarkGreen},
        {"3", ConsoleColor.DarkCyan},
        {"4", ConsoleColor.DarkRed},
        {"5", ConsoleColor.DarkMagenta},
        {"6", ConsoleColor.DarkYellow},
        {"7", ConsoleColor.Gray},
        {"8", ConsoleColor.DarkGray},
        {"9", ConsoleColor.Blue},
        {"a", ConsoleColor.Green},
        {"b", ConsoleColor.Cyan},
        {"c", ConsoleColor.Red},
        {"d", ConsoleColor.Magenta},
        {"e", ConsoleColor.Yellow},
        {"f", ConsoleColor.White},
        {"r", ConsoleColor.White} '重置颜色
    } '对颜色进行格式化处理
    Public Sub WriteColorText(text As String)
        Dim buffer As New StringBuilder()
        Dim currentColor As ConsoleColor = Console.ForegroundColor
        For i As Integer = 0 To text.Length - 1
            If text(i) = "§"c AndAlso i + 1 < text.Length Then
                '输出缓冲内容（应用当前颜色）
                If buffer.Length > 0 Then
                    Console.Write(buffer.ToString())
                    buffer.Clear()
                End If
                '处理颜色代码
                Dim code As Char = text(i + 1)
                If colorCodes.ContainsKey(code) Then
                    Console.ForegroundColor = colorCodes(code)
                End If
                i += 1 '跳过颜色代码
            Else
                buffer.Append(text(i))
            End If
        Next
        '输出剩余内容
        If buffer.Length > 0 Then
            Console.Write(buffer.ToString())
        End If
        '重置颜色
        Console.ForegroundColor = currentColor
        Console.WriteLine()
    End Sub
End Module
