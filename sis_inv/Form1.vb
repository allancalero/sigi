Imports System.Runtime.InteropServices
Public Class Form1
    Private Const  As String = " "
    Public Property Txpass As Object
#Region "Close and Minimize Form - Cerrar y Minimizar Formulario"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region
#Region "Drag Form - Arrastrar/ mover Formulario"

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub titleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles titlebar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

#End Region

    Private Sub CustomizeComponents()
        'txtuser
        Txtuser.AutoSize = False
        Txtuser.Size = New Size(350, 25)
        'txtpass
        Txtpass.AutoSize = False
        Txtpass.Size = New Size(350, 25)
        Txtpass.UseSystemPasswordChar = True
    End Sub


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CustomizeComponents()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion()
    End Sub

    Private Sub Btningresar_Click(sender As Object, e As EventArgs) Handles Btningresar.Click
        If Txtuser.Text = "" Or Txtpass.Text = "" Then
            MsgBox("Los datos no estan completos..!!")
        Else
            consultas("SELECT * FROM usuarios where nick_usuario='" + Trim(Txtuser.Text) + "' and clave_usuario='" + Trim(Eramake.eCryptography.Encrypt(Txtpass.Text)) + "'", "usuarios")
            da.Fill(ds, "usuarios")
            Dim fila1 As Integer
            fila1 = ds.Tables("usuarios").Rows.Count
            If fila1 = 0 Then
                MsgBox("Credenciales incorrectas!!")
                Txtuser.Text = ""
                Txpass.Text = ""
                Txtuser.Focus()
            Else
                'INGRESAR AL MENU PRINCIPAL
                Me.Hide()
                F_MENUP.Show()
            End If



        End If


    End Sub
End Class
