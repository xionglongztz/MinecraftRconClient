Imports System.Runtime.InteropServices

Module winAPI
    <DllImport("kernel32.dll", SetLastError:=True)>'分配一个控制台实例
    Public Function AllocConsole() As Boolean
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>'释放控制台占用的资源
    Public Function FreeConsole() As Boolean
    End Function
    <DllImport("kernel32.dll")>
    Public Function AttachConsole(dwProcessId As Integer) As Boolean
    End Function
    <DllImport("kernel32.dll")>
    Private Function GetConsoleWindow() As IntPtr
    End Function
    Public Function GetConsoleHandle() As IntPtr
        Return GetConsoleWindow()
    End Function
End Module
