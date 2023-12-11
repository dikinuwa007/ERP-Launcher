Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Net
Imports MySql.Data.MySqlClient
'Dim Conn As MySqlConnection = New MySqlConnection("server=localhost;user id=root;database=db_adm_delivery;password=''")
Module Module1
    Public Sub savetexttofile()
        Dim fs As System.IO.StreamWriter
        fs = My.Computer.FileSystem.OpenTextFileWriter("c:\test.txt", True)
        fs.Close()
    End Sub

    Public Function CheckForDatabase() As Boolean
        Try
            'Dim MyDB = "Driver={MySQL ODBC 3.51 Driver};server=localhost;database=db_aplikasi;user=root;Password="
            'Dim MyDB = "Driver={MySQL ODBC 3.51 Driver};server=localhost;database=erp;user=root;Password=''"
            Dim Conn As MySqlConnection = New MySqlConnection("server=localhost;user id=root;database=db_adm_delivery;password=''")
            'Dim Conn = New OdbcConnection(MyDB)

            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
                Conn.Close()
                Return True
            Else
                Conn.Open()
                Conn.Close()
                Return True
            End If
        Catch
            Return False
        End Try
    End Function
    Public Function CheckForInternetConnection() As Boolean
        'function untuk test internet access
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("https://mersi-uat.sandbox.operations.dynamics.com/")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Sub tutup()
        'Close()
        Application.Exit()
        End
    End Sub

    ' Sub CloseApp()
    Function GetMyMACAddress() As String
        'Declaring the necessary variables.
        Dim strComputer As String
        Dim objWMIService As Object
        Dim colItems As Object
        Dim objItem As Object
        Dim myMACAddress As String
        Dim myIPAddress As String
        'Set the computer.
        strComputer = "."

        'The root\cimv2 namespace is used to access the Win32_NetworkAdapterConfiguration class.
        objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")

        'A select query is used to get a collection of network adapters that have the property IPEnabled equal to true.
        colItems = objWMIService.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True")
        'myMACAddress = ""
        'Loop through all the collection of adapters and return the MAC address of the first adapter that has a non-empty IP.
        For Each objItem In colItems
            If Not IsNothing(objItem.IPAddress) Then
                myMACAddress = objItem.MACAddress
                myIPAddress = Trim(objItem.IPAddress(0))
            End If

            Exit For
        Next

        'Return the IP string.
        'GetMyLocalIP = myIPAddress,"'",
        GetMyMACAddress = myMACAddress & "|" & myIPAddress

    End Function
    Public Sub CheckIfRunning()
        Dim p() As Process
        p = Process.GetProcessesByName("ERP")
        If p.Count > 1 Then
            ' Process is running
            tutup()
            MessageBox.Show("ERP sudah dibuka", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            ' Process is not running
        End If
    End Sub
End Module
