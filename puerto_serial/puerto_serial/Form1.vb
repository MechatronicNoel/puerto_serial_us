Imports System.Speech.Recognition
Public Class Form1
   
    Public mensajesalida As String, mensajeentrada As String, x As Integer

 

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False

      
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'limpia los datos del combo
        ComboBox1.Items.Clear()
        'ínicio un ciclo para cargar los puertos
        For Each puerto_disponible In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(puerto_disponible)
        Next
        If (ComboBox1.Items.Count > 0) Then
            ComboBox1.Text = ComboBox1.Items(0)
            Button2.Enabled = True
        Else
            MsgBox("no existe puertos disponibles")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Button2.Text = "Conectar") Then
            Button2.Text = "Desconectar"
            SerialPort1.PortName = ComboBox1.Text
            SerialPort1.Open()

            Timer1.Enabled = True
        ElseIf (Button2.Text = "Desconectar") Then
            Button2.Text = "Conectar"
            SerialPort1.Close()

            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        mensajeentrada = SerialPort1.ReadLine
        TextBox3.Text = mensajeentrada

        Dim y1 As Integer, y2 As Integer
        Dim a() As String, s As String

        s = mensajeentrada
        a = Split(s, ";")
        TextBox4.Text = a(0) 'Temp
        TextBox5.Text = a(1) 'pwm


        y1 = Val(a(0))
        y2 = Val(a(1))

        '' Graficar
        Me.Chart1.Series(0).Points.AddXY(0, 36)
        Me.Chart1.Series(1).Points.AddXY(0, y1)
        Me.Chart2.Series(0).Points.AddXY(0, y2)
        TextBox10.Text = "36"

    End Sub

End Class
