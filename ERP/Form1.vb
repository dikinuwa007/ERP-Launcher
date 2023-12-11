Imports System.Data.Odbc
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports Microsoft.Web.WebView2.Core

Public Class Form1
    Dim Conn As OdbcConnection
    Dim Da As OdbcDataAdapter
    Dim Ds As DataSet
    Dim dt As DataTable = New DataTable()
    Dim cmd As Odbc.OdbcCommand
    Public internet, db As Boolean
    Public login As Boolean = False  ' untuk mencegah bypass user
    'Dim MyDB, uri As String
    Dim MyDB = "Driver={MySQL ODBC 3.51 Driver};server=localhost;database=erp;user=root;Password="
    Private countdownTimer As Integer = 30
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'Try
        If txtUser.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("User atau Password Kosong", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Conn = New OdbcConnection(MyDB)
            Conn.Open()
            Da = New OdbcDataAdapter("select * from tbl_anggota where BINARY username='" + txtUser.Text + "' and is_online='NO' and password like binary '" + txtPassword.Text + "'", Conn)

            Da.Fill(dt)
            If (dt.Rows.Count > 0) Then
                Dim strHostName As String
                Dim strIPAddress6, strIPAddress4 As String
                Dim strMACAddress As String
                Dim MACIp As String = GetMyMACAddress()
                Dim MACIpArr() As String = Split(MACIp, "|")
                strHostName = System.Net.Dns.GetHostName()
                strIPAddress6 = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()
                strMACAddress = MACIpArr(0)
                strIPAddress4 = MACIpArr(1)
                Dim id As String() = Split(txtUser.Text, "@")
                Dim Sid As String = id(0)
                cmd = New OdbcCommand("insert into tbl_log(email,pcname,ipaddress4,ipaddress6,macaddress,activity,username) values('" + txtUser.Text + "','" + strHostName.ToString + "','" + strIPAddress4.ToString + "','" + strIPAddress6.ToString + "','" + strMACAddress.ToString + "','LOGIN','" + Sid + "')", Conn)
                cmd.ExecuteNonQuery()
                cmd = New OdbcCommand("update tbl_anggota set is_online='YES' where username='" + txtUser.Text + "' and password ='" + txtPassword.Text + "'", Conn)
                cmd.ExecuteNonQuery()
                Conn.Close() 'update kill connection
                MessageBox.Show("Login Success", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'WebView2.EnsureCoreWebView2Async()
                'WebView2.CoreWebView2.Navigate("https://mersi-uat.sandbox.operations.dynamics.com")
                'WebView2.CoreWebView2.CookieManager.DeleteAllCookies()
                ' WebView2.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.setCacheDisabled","{\"cacheDisabled\":true}")


                login = True
                txtPassword.Enabled = False
                txtUser.Enabled = False
                btn_cp_user.Visible = True
                btn_cp_password.Visible = True
                'If WebView2.CoreWebView2.IsSuspended Then
                'WebView2.Hide()
                'Else
                MsgBox(WV2.CoreWebView2.CookieManager.ToString)
                WV2.CoreWebView2.ExecuteScriptAsync("javascript:localStorage.clear()")
                WV2.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCache", "{}") 'clear cache
                WV2.Show()
                'tesst method cache
                'var webView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);
                'await kioskBrowser.EnsureCoreWebView2Async(webView2Environment);
                'kioskBrowser.Source = New Uri(url);

                'WebView2.EnsureCoreWebView2Async.
                'WebView2.CoreWebView2.CookieManager.DeleteAllCookies()
                'End If
                btnLogin.Visible = False
                Label4.Text = 30
                Label4.Show()
                Label3.Show()
                PictureBox1.Hide()
                ProgressBar1.Maximum = countdownTimer
                ProgressBar1.Value = countdownTimer
                Timer1.Enabled = True
                ProgressBar1.Show()
                Button1.Hide()
            Else
                MessageBox.Show("id atau password salah atau anda sudah login di komputer lain", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Else
            '   MessageBox.Show("Koneksi Internet Terputus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        End If
        'Catch
        'MessageBox.Show("Upss... Silahkan Hubungi Staff IT!!!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub
    '    Public Async Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
    '        Dim webViewEnvironment = Await CoreWebView2Environment.CreateAsync(Nothing, "c://temp")
    '        Await WebView21.EnsureCoreWebView2Async(webViewEnvironment)
    '    End Sub
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call CheckIfRunning()
        MDIParent1.Hide()

        'cek
        'Dim webViewEnvironment = Await CoreWebView2Environment.CreateAsync(Nothing, "c://temp")
        'Dim w = Await CoreWebView2Environment.CreateAsync(Nothing, "C:\Users\Administrator\source\ERP\ERP\ERP\obj\Debug")

        'Await WV2.EnsureCoreWebView2Async(webViewEnvironment)
        'Await CoreWebView2Environment.CreateAsync(Nothing, "C:\Users\Administrator\source\ERP\ERP\ERP\obj\Debug")
        Await CoreWebView2Environment.CreateAsync(Nothing, "C:\Users\Administrator\source\ERP\ERP\ERP\bin\Debug\WebView2.exe.WebView2")

        'Await WV2.EnsureCoreWebView2Async(Await CoreWebView2Environment.CreateAsync(Nothing, "C:\Users\Administrator\source\ERP\ERP\ERP\obj\Debug"))
        'cek
        btn_cp_user.Visible = False
        btn_cp_password.Visible = False
        'WV2.CoreWebView2.CookieManager.DeleteAllCookies()
        WV2.Hide()
        Label3.Hide()
        Label4.Hide()
        ProgressBar1.Hide()
        internet = CheckForInternetConnection()
        db = CheckForDatabase()
        If internet = False Or db = False Then
            If internet = False Then
                MessageBox.Show("Koneksi Internet Terputus", "Internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf db = False Then
                MessageBox.Show("Koneksi Database Terputus", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            WV2.Enabled = False
            btnLogin.Enabled = False
            Close()
            'atau bisa juga pake end aja
            Call tutup()
        End If
        'load txt file jika ada trouble di db
        If My.Computer.FileSystem.FileExists("c:\test.txt") = True Then
            Dim fr As String
            fr = My.Computer.FileSystem.ReadAllText("c:\test.txt")
            If Not fr = vbNullString Then
                Dim testArray() As String = Split(fr, ";")
                Conn = New OdbcConnection(MyDB)
                Conn.Open()
                cmd = New OdbcCommand(testArray(0), Conn)
                cmd.ExecuteNonQuery()
                cmd = New OdbcCommand(testArray(1), Conn)
                cmd.ExecuteNonQuery()
                'Conn.Close() 'update kill connection
                My.Computer.FileSystem.DeleteFile("c:\test.txt")
            End If
        End If
        'Conn.Close() 'update kill
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_cp_password.Click
        Clipboard.Clear()
        Clipboard.SetText(txtPassword.Text)
    End Sub
    Private Sub WebView2_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles WV2.SourceChanged
        Dim a = WV2.Source.ToString
        Dim b As String = Mid(a, 1, 33)
        Dim c As String = "@"
        'If (txtUser.TextLength = 0 Or Not txtUser.Text.Contains(c)) And login = False Then
        '   MessageBox.Show("Anda harus melakukan otentikasi/restart", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '    tutup()
        'Else
        If Not b.Equals("https://login.microsoftonline.com") Then
            'If b.Equals("https://mersi-uat.sandbox.operations.dynamics.com") Then
            WV2.CoreWebView2.Navigate("https://mersi-uat.sandbox.operations.dynamics.com")
            Timer1.Stop()
            MDIParent1.Show()

            Me.Hide()
        End If

        'End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = countdownTimer.ToString
        If countdownTimer = 1 Then
            Timer1.Stop()
            Conn.Open()
            cmd = New OdbcCommand("update tbl_anggota set is_online='NO' where username='" + txtUser.Text + "'", Conn)
            cmd.ExecuteNonQuery()
            Conn.Close()
            WV2.Hide()
            ProgressBar1.Hide()
            Label3.Hide()
            Label4.Hide()
            btn_cp_password.Hide()
            btn_cp_user.Hide()
            btnLogin.Show()
            txtPassword.Clear()
            txtUser.Clear()
            txtPassword.Enabled = True
            txtUser.Enabled = True
            PictureBox1.Show()
            Button1.Show()
            MessageBox.Show("Anda harus melakukan otentikasi lagi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            countdownTimer = 30
        Else
            ProgressBar1.Value = countdownTimer
            countdownTimer -= 1
        End If
    End Sub

    Private Sub btn_cp_user_Click(sender As Object, e As EventArgs) Handles btn_cp_user.Click
        Clipboard.Clear()
        Clipboard.SetText(txtUser.Text)
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If login = True Then
            Conn.Open()
            cmd = New OdbcCommand("update tbl_anggota set is_online='NO' where username='" + txtUser.Text + "'", Conn)
            cmd.ExecuteNonQuery()
            Conn.Close() 'update kill connection
        End If
        'Call tutup()
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        txtPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        txtPassword.UseSystemPasswordChar = True

    End Sub
End Class