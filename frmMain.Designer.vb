<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.BtnSendCommand = New System.Windows.Forms.Button()
        Me.TxtIP = New System.Windows.Forms.TextBox()
        Me.TxtPort = New System.Windows.Forms.TextBox()
        Me.TxtPasswd = New System.Windows.Forms.TextBox()
        Me.TextBoxCommand = New System.Windows.Forms.TextBox()
        Me.BtnDisconnect = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(341, 6)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(95, 33)
        Me.BtnConnect.TabIndex = 0
        Me.BtnConnect.Text = "连接(&C)"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'BtnSendCommand
        '
        Me.BtnSendCommand.Location = New System.Drawing.Point(341, 45)
        Me.BtnSendCommand.Name = "BtnSendCommand"
        Me.BtnSendCommand.Size = New System.Drawing.Size(95, 33)
        Me.BtnSendCommand.TabIndex = 1
        Me.BtnSendCommand.Text = "发送(&S)>>"
        Me.BtnSendCommand.UseVisualStyleBackColor = True
        '
        'TxtIP
        '
        Me.TxtIP.AccessibleDescription = ""
        Me.TxtIP.AccessibleName = ""
        Me.TxtIP.Location = New System.Drawing.Point(12, 12)
        Me.TxtIP.Name = "TxtIP"
        Me.TxtIP.Size = New System.Drawing.Size(128, 25)
        Me.TxtIP.TabIndex = 3
        Me.TxtIP.Text = "127.0.0.1"
        '
        'TxtPort
        '
        Me.TxtPort.Location = New System.Drawing.Point(146, 12)
        Me.TxtPort.MaxLength = 5
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(62, 25)
        Me.TxtPort.TabIndex = 4
        '
        'TxtPasswd
        '
        Me.TxtPasswd.Location = New System.Drawing.Point(214, 12)
        Me.TxtPasswd.Name = "TxtPasswd"
        Me.TxtPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.TxtPasswd.Size = New System.Drawing.Size(121, 25)
        Me.TxtPasswd.TabIndex = 5
        '
        'TextBoxCommand
        '
        Me.TextBoxCommand.Location = New System.Drawing.Point(12, 51)
        Me.TextBoxCommand.Name = "TextBoxCommand"
        Me.TextBoxCommand.Size = New System.Drawing.Size(323, 25)
        Me.TextBoxCommand.TabIndex = 6
        '
        'BtnDisconnect
        '
        Me.BtnDisconnect.Location = New System.Drawing.Point(442, 6)
        Me.BtnDisconnect.Name = "BtnDisconnect"
        Me.BtnDisconnect.Size = New System.Drawing.Size(95, 33)
        Me.BtnDisconnect.TabIndex = 7
        Me.BtnDisconnect.Text = "断开(&D)"
        Me.BtnDisconnect.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(442, 45)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(95, 33)
        Me.BtnClear.TabIndex = 8
        Me.BtnClear.Text = "清空日志"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AcceptButton = Me.BtnSendCommand
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 91)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnDisconnect)
        Me.Controls.Add(Me.TextBoxCommand)
        Me.Controls.Add(Me.TxtPasswd)
        Me.Controls.Add(Me.TxtPort)
        Me.Controls.Add(Me.TxtIP)
        Me.Controls.Add(Me.BtnSendCommand)
        Me.Controls.Add(Me.BtnConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Minecraft RCON 客户端"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConnect As Button
    Friend WithEvents BtnSendCommand As Button
    Friend WithEvents TxtIP As TextBox
    Friend WithEvents TxtPort As TextBox
    Friend WithEvents TxtPasswd As TextBox
    Friend WithEvents TextBoxCommand As TextBox
    Friend WithEvents BtnDisconnect As Button
    Friend WithEvents BtnClear As Button
End Class
