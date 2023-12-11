Imports System.Windows.Forms
Imports System.Data.Odbc
Imports System.Threading
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.WinForms 'untuk control
Imports Syncfusion.Windows.Forms.Tools 'untuk tabcontrol
Imports System.Net
Imports System.Text.RegularExpressions

Public Class MDIParent1
    Dim Conn As OdbcConnection
    Dim Da As OdbcDataAdapter
    Dim Ds As DataSet
    Dim cmd As Odbc.OdbcCommand
    'Dim MyDB = "Driver={MySQL ODBC 3.51 Driver};server=localhost;database=db_aplikasi;user=root;Password="
    Dim MyDB = "Driver={MySQL ODBC 3.51 Driver};server=192.168.2.40;database=logger;user=user;Password=rahasia"
    Dim strHostName As String
    Dim strIPAddress6, strIPAddress4 As String
    Dim strMACAddress As String
    Dim uri As String


    'Public Sub New()

    ' This call is required by the designer.
    ' InitializeComponent()
    '  Application.AddMessageFilter(Me)
    '   Timer1.Enabled = True
    ' Add any initialization after the InitializeComponent() call.

    'End Sub
    'Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
    '' Retrigger timer on keyboard and mouse messages
    'If (m.Msg >= &H100 And m.Msg <= &H109) Or (m.Msg >= &H200 And m.Msg <= &H20E) Then
    '       Timer1.Stop()
    '      Timer1.Start()
    'End If
    'End Function
    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '   Timer1.Stop()
    '  MessageBox.Show("Time is up!")
    'End Sub

    'Sub Koneksi()
    ' MyDB = "Driver={MySQL ODBC 3.51 Driver};Server=192.168.2.40;Database=logger;User=user;Password=rahasia"
    '  Conn = New OdbcConnection(MyDB)
    '   If Conn.State = ConnectionState.Closed Then Conn.Open()
    'untuk koneksi sudah fix
    'End Sub
    'Public Sub savetexttofile()
    'My.Computer.FileSystem.CreateDirectory()
    'My.Computer.FileSystem.DeleteFile()
    'Dim path As String = "d:\test.txt"
    ' Dim filepath As String = "D:\tmp.txt"
    '   System.IO.File.Create(filepath).Dispose()
    ' Dim fs As System.IO.StreamWriter
    ''   fs = My.Computer.FileSystem.OpenTextFileWriter("D:\tmp.txt", True)
    '    fs.WriteLine("test")
    '     fs.Close()
    '  End Sub
    Sub closeApp()
        MessageBox.Show("Anda Keluar dari ERP", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim MACIp As String = GetMyMACAddress()
        Dim MACIpArr() As String = Split(MACIp, "|")
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress6 = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()
        strMACAddress = MACIpArr(0)
        strIPAddress4 = MACIpArr(1)
        Dim cekdb = CheckForDatabase()
        Dim id As String() = Split(TextBox1.Text, "@")
        Dim Sid As String = id(0)
        If cekdb = False Then
            Dim filepath As String = "c:\test.txt"
            System.IO.File.Create(filepath).Dispose()
            Dim fs As System.IO.StreamWriter
            fs = My.Computer.FileSystem.OpenTextFileWriter("c:\test.txt", True)
            fs.WriteLine("update tbl_anggota set is_online='NO' where username='" + TextBox1.Text + "';insert into tbl_log(username,pcname,ipaddress4,ipaddress6,macaddress,activity,id) values('" + TextBox1.Text + "','" + strHostName.ToString + "','" + strIPAddress4.ToString + "','" + strIPAddress6.ToString + "','" + strMACAddress.ToString + "','LOGOUT','" + Sid + "');")
            fs.Close()
            WebView21.CoreWebView2.CookieManager.DeleteAllCookies() 'HAPUS COOKIES
            tutup()
        Else
            'metode lama
            Conn = New OdbcConnection(MyDB)
            Conn.Open()
            cmd = New OdbcCommand("update tbl_anggota set is_online='NO' where username='" + TextBox1.Text + "'", Conn)
            cmd.ExecuteNonQuery()
            cmd = New OdbcCommand("insert into tbl_log(email,pcname,ipaddress4,ipaddress6,macaddress,activity,username) values('" + TextBox1.Text + "','" + strHostName.ToString + "','" + strIPAddress4.ToString + "','" + strIPAddress6.ToString + "','" + strMACAddress.ToString + "','LOGOUT','" + Sid + "')", Conn)
            cmd.ExecuteNonQuery()
            WebView21.CoreWebView2.CookieManager.DeleteAllCookies() 'HAPUS COOKIES
            tutup()
        End If


        Conn.Close()
    End Sub
    Sub clearcookies()
        WebView21.CoreWebView2.CookieManager.DeleteAllCookies()

    End Sub

    Private Sub MDIParent1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        closeApp()
        'untuk mengclose aplikasi jika tidak digunakan
        'Dim forceExitTimer = New Threading.Timer(Sub() End, Nothing, 3, Timeout.Infinite)

    End Sub
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim v = WebView21.EnsureCoreWebView2Async.IsCompleted
        'If v = True Then
        'WebView21.Show()
        'Else
        'WebView21.Hide()
        'End If
        WebView21.CoreWebView2.Navigate("https://mersi-uat.sandbox.operations.dynamics.com")
        TextBox1.Text = (Form1.txtUser).Text
        'Dim c = "@"
        'If Not TextBox1.TextLength > 0 Or Form1.login = True Or TextBox1.Text.Contains(c) Then
        'MessageBox.Show("Anda harus melakukan otentikasi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'If Not WebView2.CoreWebView2.Source.Contains("login") Then
        'tutup()
        'End If
    End Sub

    Private Sub WebView21_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles WebView21.SourceChanged
        If WebView21.CoreWebView2.Source.Contains("logout") Then
            closeApp()
            'ElseIf WebView21.CoreWebView2.Source.Contains("logout") Then
            'window.open("http://bankingmadeasy.com/Financial_G_K.aspx", "QuestionsAskedInBanks", "resizable=yes, status=no, toolbar=no, scrollbars= yes, location=no, menubar=no,width=1500, height=1000")
            'testwindow = window.open("http://bankingmadeasy.com/Financial_G_K.aspx", "QuestionsAskedInBanks", "resizable=yes, status=no, toolbar=no, scrollbars=yes, location=no, menubar=no,addressbar=no, width=1500, height=1000");
            'Windows.Forms.PopupEventArgs
            'WebView21.CoreWebView2.
        End If
        'uri = WebView21.CoreWebView2.Source.ToString
    End Sub

    'popup blocker
    Private Sub WebView21_CoreWebView2InitializationCompleted_1(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        'If WebView21.CoreWebView2.Source.Contains("ReportDesigner") Then
        'https://mersi-uat.sandbox.operations.dynamics.com/FinancialReporting/ClickOnceService/ClickOnceClient/ReportDesigner.application?HostServicePath=%2f&ServiceEndPoint=https%3a%2f%2fmersi-uat.sandbox.operations.dynamics.com%2fFinancialReporting%2fApplicationService%2fsoap&NonSoapServiceEndPoint=https%3a%2f%2fmersi-uat.sandbox.operations.dynamics.com%2fFinancialReporting%2fApplicationService%2fsoap&Company=mes&Culture=en-us&caid=673a58c3-b1cb-470b-92d0-8a4a6dd8969e&platform=Cloud&AuthenticationAuthority=https%3a%2f%2flogin.windows.net%2fmetindo.onmicrosoft.com&ShowNewReport=true
        'Else
        'MsgBox("popup")
        AddHandler WebView21.CoreWebView2.NewWindowRequested, AddressOf CoreWebView2_NewWindowRequested
        'AddHandler WebView21.CoreWebView2.NewWindowRequested, AddressOf CoreWebView2_newinaja
        'End If
        'popout
    End Sub
    Private Sub CoreWebView2_NewWindowRequested(ByVal sender As Object, ByVal e As Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs)
        'If WebView21.CoreWebView2.Source.Contains("ReportDesigner") Then
        'Dim wv As New Microsoft.Web.WebView2.WinForms.WebView2()
        'wv.Handled = True
        MsgBox("popup")
        e.NewWindow = sender 'tampilkan popup di tab yang sama
        'e.Handled = True(penyebab blocker)
        'e.NewWindow = CoreWebView2 *instance
        'Else
        'AddHandler WebView21.CoreWebVieermissionRequested, AddressOf CoreWebView2_newinaja
        'End If
        'WebView21.Reload()

    End Sub

    Private Sub TabControl1_MouseClick(ByVal sender As Object,
                                   ByVal e As MouseEventArgs) Handles TabControl1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'newtab()
            Me.ContextMenuStrip1.Show(Me.TabControl1, e.Location)
        End If
    End Sub
    'Function CheckSetupOk() As Boolean
    ''It takes 10 seconds to check whether the edge runtime component is installed successfully. Is there a faster method?
    'Dim WV As cWebView2
    'Set WV = New_c.WebView2
    'CheckSetupOk = WV.BindTo(Me.hWnd) <> 0
    'Set WV = Nothing
    'End Function

    'Function DonwSetupTool() As Boolean
    'Dim URL As String
    'URL = "https://go.microsoft.com/fwlink/p/?LinkId=2124703"
    'xmlhttp download***
    'save as :Edge_Webview2RunTime.exe

    ' Dim Size1 As Long
    '  Size1 = FileLen(App.Path & "\Edge_Webview2RunTime.exe")
    '   DonwSetupTool = Size1 > 1024 ^ 2

    'End Function
    Sub newtab()
        Dim dynamicTab As New TabPage()
        Dim wb As New WebBrowser()
        Dim wv As New Microsoft.Web.WebView2.WinForms.WebView2()
        dynamicTab.Name = "dynamicTab"

        ' Create Button
        Dim btn As New Button()
        btn.Name = "btnButton"
        btn.Text = "Dynamic Button"
        AddHandler btn.Click, AddressOf TabControl1_MouseClick
        'dynamicTab.Controls.Add(btn)
        'Me.TabControl1.TabPages.Add(dynamicTab)
        'wv.Size = New System.Drawing.Size(892, 319)
        'wv.Size = WebView21.Size()
        wv.Anchor = WebView21.Anchor
        'Dim uri As String = WebView21.CoreWebView2.Source.ToString
        wv.Source = WebView21.Source()
        'wv.Source = WebView21.EnsureCoreWebView2Async.
        'WebView21.Source()

        'Dim x As New WebClient()
        'Dim source As String = x.DownloadString(wv.Source)
        'Dim title As String = Regex.Match(source, "\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups("Title").Value
        dynamicTab.Text = TabControl1.SelectedIndex
        MsgBox(TabControl1.SelectedTab.Controls.ToString)
        'If Not wv.CoreWebView2.n Then
        'dynamicTab.Text = wv.CoreWebView2.DocumentTitle.ToString
        'End If
        'CoreWebView2NavigationCompletedEventArgs = ""

        '        dynamicTab.Text = html

        'btn.Text = "Null"
        dynamicTab.Controls.Add(wv)
        Me.TabControl1.TabPages.Add(dynamicTab)
        'MsgBox(dynamicTab)
    End Sub
    'Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
    '   e.Graphics.DrawString("X", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4)
    '  e.Graphics.DrawString(TabControl1.TabPages(e.Index).Text, e.Font, Brushes.Red, e.Bounds.Left + 12, e.Bounds.Top + 4)
    ' e.DrawFocusRectangle()
    'End Sub

    'Private Sub TabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseDown
    'For i As Integer = 0 To TabControl1.TabPages.Count - 1
    'Dim r As Rectangle = TabControl1.GetTabRect(i)
    'Dim closeButton As Rectangle = New Rectangle(r.Right - 15, r.Top + 4, 9, 7)
    'If closeButton.Contains(e.Location) Then
    'If MessageBox.Show("Close form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '               TabControl1.TabPages.RemoveAt(i)
    'Exit Sub
    'End If
    'End If
    'Next
    'End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        If MessageBox.Show("Close form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
            Exit Sub
        End If
    End Sub
    Private Sub DuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateToolStripMenuItem.Click
        newtab()
    End Sub
    'Sub newtab()
    'Dim dynamicTab As New TabPage()
    'Dim wb As New WebBrowser()
    'Dim wv As New WebView2()


    '      dynamicTab.Name = "dynamicTsab"
    '     dynamicTab.Text = "Dynamic Tab"
    '    dynamicTab.BackColor = Color.SkyBlue
    '' Create Button
    'MyWebViewElement.CoreWebView2.ExecuteScriptAsync("javascript:localStorage.clear()")

    '   Dim btn As New Button()
    '      btn.Name = "btnButton"
    '     btn.Text = "Dynamic Button"
    '     btn.BackColor = Color.SeaGreen
    'AddHandler() btn.Click, AddressOf TabControl1_Click
    'dynamicTab.Controls.Add(btn)
    'Me.TabControl1.TabPages.Add(dynamicTab)
    '   wb.Size = New System.Drawing.Size(892, 319)
    'Me.TabPage2.Size = New System.Drawing.Size(892, 319)
    '  wb.Navigate(uri)
    ' dynamicTab.Controls.Add(wv)
    'Me.TabControl1.TabPages.Add(dynamicTab)
    'Dim page As New TabPage

    'page.Text = "Page 1"
    'Me.TabControl1.TabPages.Add(page)
    'Me.TabPage


    'Dim lstView As New Button
    'lstView.Items.Add(WebBrowser)
    'Me.TabControl1.TabPages(0).Controls.Add(lstView)

    'Dim tp As TabPage
    'TabControl1.TabPages.Add(1)
    'Dim wb As WebBrowser
    'tp.Controls.Add(wb)

    '        Me.TabPage2.Controls.Add(Me.WebView22)
    '       Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(254, Byte))
    '      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    ''     Me.TabPage2.Name = "TabPage2"
    '   Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    '  Me.TabPage2.Size = New System.Drawing.Size(892, 319)
    ' Me.TabPage2.TabIndex = 1
    'Me.TabPage2.Text = "ERP 2"
    'Me.TabPage2.UseVisualStyleBackColor = True

    '        Me.WebView22.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
    '           Or System.Windows.Forms.AnchorStyles.Left) _
    ''          Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    ''    Me.WebView22.CreationProperties = Nothing
    ' Me.WebView22.DefaultBackgroundColor = System.Drawing.Color.White
    '  Me.WebView22.Location = New System.Drawing.Point(0, 0)
    ' Me.WebView22.Name = "WebView22"
    '        Me.WebView22.Size = New System.Drawing.Size(892, 323)
    '       Me.WebView22.Source = New System.Uri("https://mersi-uat.sandbox.operations.dynamics.com", System.UriKind.Absolute)
    '      Me.WebView22.TabIndex = 0
    '     Me.sWebView22.ZoomFactor = 1.0R
    'End Sub


End Class
