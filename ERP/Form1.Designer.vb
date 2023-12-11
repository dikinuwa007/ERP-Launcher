<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.WV2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.btn_cp_user = New System.Windows.Forms.Button()
        Me.btn_cp_password = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.WV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        Me.txtUser.Location = New System.Drawing.Point(157, 337)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(342, 27)
        Me.txtUser.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(157, 369)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(342, 27)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnLogin
        '
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(157, 399)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(342, 29)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "LOGIN"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'WV2
        '
        Me.WV2.CreationProperties = Nothing
        Me.WV2.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WV2.Location = New System.Drawing.Point(13, 12)
        Me.WV2.Name = "WV2"
        Me.WV2.Size = New System.Drawing.Size(707, 272)
        Me.WV2.Source = New System.Uri("https://login.microsoftonline.com", System.UriKind.Absolute)
        Me.WV2.TabIndex = 9
        Me.WV2.ZoomFactor = 1.0R
        '
        'btn_cp_user
        '
        Me.btn_cp_user.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cp_user.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cp_user.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.btn_cp_user.Location = New System.Drawing.Point(505, 337)
        Me.btn_cp_user.Name = "btn_cp_user"
        Me.btn_cp_user.Size = New System.Drawing.Size(189, 25)
        Me.btn_cp_user.TabIndex = 10
        Me.btn_cp_user.Text = "COPY USERNAME"
        Me.btn_cp_user.UseVisualStyleBackColor = True
        '
        'btn_cp_password
        '
        Me.btn_cp_password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cp_password.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cp_password.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
        Me.btn_cp_password.Location = New System.Drawing.Point(505, 369)
        Me.btn_cp_password.Name = "btn_cp_password"
        Me.btn_cp_password.Size = New System.Drawing.Size(189, 27)
        Me.btn_cp_password.TabIndex = 11
        Me.btn_cp_password.Text = "COPY PASSWORD"
        Me.btn_cp_password.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(228, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Waktu Login"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(413, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Label4"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(232, 317)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(220, 14)
        Me.ProgressBar1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(-4, 442)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.WebView2.My.Resources.Resources.Logo_Metindo
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(706, 187)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.WebView2.My.Resources.Resources.mata
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Help
        Me.Button1.Image = Global.WebView2.My.Resources.Resources.mata
        Me.Button1.Location = New System.Drawing.Point(470, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 30)
        Me.Button1.TabIndex = 16
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(732, 435)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_cp_password)
        Me.Controls.Add(Me.btn_cp_user)
        Me.Controls.Add(Me.WV2)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login ERP"
        CType(Me.WV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btn_cp_user As Button
    Friend WithEvents btn_cp_password As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Protected WithEvents WV2 As Microsoft.Web.WebView2.WinForms.WebView2
End Class
