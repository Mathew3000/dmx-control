Imports System.IO
Imports System.IO.Ports
Imports System.Threading

Public Class Form1
    Dim port As String = "COM1"
    Dim baudrate As Integer = 115200
    Dim ch(10) As Integer
    Dim chv(10) As Integer
    Dim set1(10) As Integer
    Dim set2(10) As Integer
    Dim set3(10) As Integer
    Dim setv1(10) As Integer
    Dim setv2(10) As Integer
    Dim setv3(10) As Integer
    Dim activeset As Integer = 1
    Dim setting As Integer
    Dim runner(9) As Integer

    'Declaration of Scene Type
    Private Structure scene
        Public chan() As Integer
        Public val() As Integer
        Public empty As Boolean
    End Structure
    'Declaration of Scenes
    Dim sce(18) As scene

    'Declaration of Program Type
    Private Structure program
        Public actions() As scene
        Public speed As Integer
        Public count As Integer
        Public empty As Boolean
    End Structure
    'Declaration of Programs
    Dim pro(9) As program

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HelpButton = True
        For index As Integer = 1 To 10
            set1(index) = index
        Next
        For index As Integer = 1 To 10
            set2(index) = index + 10
        Next
        For index As Integer = 1 To 10
            set3(index) = index + 20
        Next
        For index As Integer = 1 To 9
            runner(index) = 1
        Next
        For index As Integer = 1 To 18
            ReDim Preserve sce(index).chan(10)
            ReDim Preserve sce(index).val(10)
            sce(index).empty = True
        Next
            ch = set1
        For index As Integer = 1 To 9
            ReDim pro(index).actions(256)
            For run As Integer = 1 To 256
                ReDim Preserve pro(index).actions(run).chan(10)
                ReDim Preserve pro(index).actions(run).val(10)
            Next
            pro(index).speed = 1000
            pro(index).count = 0
            pro(index).empty = True
        Next

    End Sub

    Sub setval()
        TrackBar1.Value = chv(1)
        TrackBar2.Value = chv(2)
        TrackBar3.Value = chv(3)
        TrackBar4.Value = chv(4)
        TrackBar5.Value = chv(5)
        TrackBar6.Value = chv(6)
        TrackBar7.Value = chv(7)
        TrackBar8.Value = chv(8)
        TrackBar9.Value = chv(9)
        TrackBar10.Value = chv(10)

    End Sub

    Sub setch()
        TextBox1.Text = ch(1)
        TextBox2.Text = ch(2)
        TextBox3.Text = ch(3)
        TextBox4.Text = ch(4)
        TextBox5.Text = ch(5)
        TextBox6.Text = ch(6)
        TextBox7.Text = ch(7)
        TextBox8.Text = ch(8)
        TextBox9.Text = ch(9)
        TextBox10.Text = ch(10)
    End Sub

    Sub change()
        If chset1.Checked = True Then
            If activeset = 2 Then
                set2 = ch
                setv2 = chv
                ch = set1
                chv = setv1
                setch()
                setval()
                activeset = 1
            End If
            If activeset = 3 Then
                set3 = ch
                setv3 = chv
                ch = set1
                chv = setv1
                setch()
                setval()
                activeset = 1
            End If
        End If
        If chset2.Checked = True Then
            If activeset = 1 Then
                set1 = ch
                setv1 = chv
                ch = set2
                chv = setv2
                setch()
                setval()
                activeset = 2
            End If
            If activeset = 3 Then
                set3 = ch
                setv3 = chv
                ch = set2
                chv = setv2
                setch()
                setval()
                activeset = 2
            End If
        End If
        If chset3.Checked = True Then
            If activeset = 1 Then
                set1 = ch
                setv1 = chv
                ch = set3
                chv = setv3
                setch()
                setval()
                activeset = 3
            End If
            If activeset = 2 Then
                set2 = ch
                setv2 = chv
                ch = set3
                chv = setv3
                setch()
                setval()
                activeset = 3
            End If
        End If
    End Sub

    Sub SSD(ByVal data As String)
        If SerialPort1.IsOpen Then
            Try
                SerialPort1.Write(data)
            Finally

            End Try
        End If

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        SerialPort1.PortName = ComboBox1.Text
        port = ComboBox1.Text
    End Sub

    Private Sub Blackout_CheckedChanged(sender As Object, e As EventArgs) Handles Blackout.CheckedChanged
        If (Blackout.Checked = True) Then
            SSD("r")
        End If
        If (Blackout.Checked = False) Then
            For index As Integer = 1 To 10
                SSD(ch(index) & "c")
                SSD(chv(index) & "v")
            Next
        End If

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ch(1) = TextBox1.Text
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        chv(1) = TrackBar1.Value
        SSD(ch(1) & "c")
        SSD(chv(1) & "v")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ch(2) = TextBox2.Text
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        chv(2) = TrackBar2.Value
        SSD(ch(2) & "c")
        SSD(chv(2) & "v")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ch(3) = TextBox3.Text
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        chv(3) = TrackBar3.Value
        SSD(ch(3) & "c")
        SSD(chv(3) & "v")
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        ch(4) = TextBox4.Text
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        chv(4) = TrackBar4.Value
        SSD(ch(4) & "c")
        SSD(chv(4) & "v")
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ch(5) = TextBox5.Text
    End Sub

    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles TrackBar5.Scroll
        chv(5) = TrackBar5.Value
        SSD(ch(5) & "c")
        SSD(chv(5) & "v")
    End Sub



    Private Sub TrackBar6_Scroll(sender As Object, e As EventArgs) Handles TrackBar6.Scroll
        chv(6) = TrackBar6.Value
        SSD(ch(6) & "c")
        SSD(chv(6) & "v")
    End Sub

    Private Sub TrackBar7_Scroll(sender As Object, e As EventArgs) Handles TrackBar7.Scroll
        chv(7) = TrackBar7.Value
        SSD(ch(7) & "c")
        SSD(chv(7) & "v")
    End Sub

    Private Sub TrackBar8_Scroll(sender As Object, e As EventArgs) Handles TrackBar8.Scroll
        chv(8) = TrackBar8.Value
        SSD(ch(8) & "c")
        SSD(chv(8) & "v")
    End Sub

    Private Sub TrackBar9_Scroll(sender As Object, e As EventArgs) Handles TrackBar9.Scroll
        chv(9) = TrackBar9.Value
        SSD(ch(9) & "c")
        SSD(chv(9) & "v")
    End Sub

    Private Sub TrackBar10_Scroll(sender As Object, e As EventArgs) Handles TrackBar10.Scroll
        chv(10) = TrackBar10.Value
        SSD(ch(10) & "c")
        SSD(chv(10) & "v")
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        ch(6) = TextBox6.Text
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        ch(7) = TextBox7.Text
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        ch(8) = TextBox8.Text
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        ch(9) = TextBox9.Text
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        ch(10) = TextBox10.Text
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "b" OrElse e.KeyChar = "B" Then
            If Blackout.Checked = False Then
                Blackout.Checked = True
            End If
            If Blackout.Checked = True Then
                Blackout.Checked = False
            End If
        End If
    End Sub

    Private Sub chset1_CheckedChanged(sender As Object, e As EventArgs) Handles chset1.CheckedChanged
        If chset1.Checked = True Then
            change()
        End If
    End Sub

    Private Sub chset2_CheckedChanged(sender As Object, e As EventArgs) Handles chset2.CheckedChanged
        If chset2.Checked = True Then
            change()
        End If
    End Sub

    Private Sub chset3_CheckedChanged(sender As Object, e As EventArgs) Handles chset3.CheckedChanged
        If chset3.Checked = True Then
            change()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles offline.CheckedChanged
        If offline.Checked = False Then
            Try
                SerialPort1.Open()
            Catch ex As System.IO.IOException
                MessageBox.Show("Could not connect to Arduino on Port " & port & "!",
                            "No Arduino found!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                offline.Checked = True
                Exit Try
            Finally

            End Try
        End If
        If offline.Checked = True Then
            Try
                SerialPort1.Close()
            Finally
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For index As Integer = 1 To 10
            setv1(index) = 0
        Next
        For index As Integer = 1 To 10
            setv2(index) = 0
        Next
        For index As Integer = 1 To 10
            setv3(index) = 0
        Next
        For index As Integer = 1 To 10
            chv(index) = 0
        Next
        setval()
        SSD("r")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            SerialPort1.Close()
        Finally
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles record.CheckedChanged
        If record.Checked = True Then
            setpos.Enabled = True
        End If
        If record.Checked = False Then
            setpos.Enabled = False
        End If
    End Sub

    Private Sub prog1_CheckedChanged(sender As Object, e As EventArgs) Handles prog1.CheckedChanged
        If record.Checked = True Then
            setting = 1
            pro(setting).count = 0
            prog1.Checked = False
        End If
        If record.Checked = False Then
            If pro(1).empty Then
                If prog1.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog1.Checked = False
            End If
            Timer1.Enabled = prog1.Checked
        End If
    End Sub

    Private Sub prog2_CheckedChanged(sender As Object, e As EventArgs) Handles prog2.CheckedChanged
        If record.Checked = True Then
            setting = 2
            pro(setting).count = 0
            prog2.Checked = False
        End If
        If record.Checked = False Then
            If pro(2).empty Then
                If prog2.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog2.Checked = False
            Else
                Timer2.Enabled = prog2.Checked
            End If
        End If
    End Sub

    Private Sub prog3_CheckedChanged(sender As Object, e As EventArgs) Handles prog3.CheckedChanged
        If record.Checked = True Then
            setting = 3
            pro(setting).count = 0
            prog3.Checked = False
        End If
        If record.Checked = False Then
            If pro(3).empty Then
                If prog3.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog3.Checked = False
            Else
                Timer3.Enabled = prog3.Checked
            End If
        End If
    End Sub

    Private Sub prog4_CheckedChanged(sender As Object, e As EventArgs) Handles prog4.CheckedChanged
        If record.Checked = True Then
            setting = 4
            pro(setting).count = 0
            prog4.Checked = False
        End If
        If record.Checked = False Then
            If pro(4).empty Then
                If prog4.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog4.Checked = False
            Else
                Timer4.Enabled = prog4.Checked
            End If
        End If
    End Sub

    Private Sub prog5_CheckedChanged(sender As Object, e As EventArgs) Handles prog5.CheckedChanged
        If record.Checked = True Then
            setting = 5
            pro(setting).count = 0
            prog5.Checked = False
        End If
        If record.Checked = False Then
            If pro(5).empty Then
                If prog5.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog5.Checked = False
            Else
                Timer5.Enabled = prog5.Checked
            End If
        End If
    End Sub

    Private Sub prog6_CheckedChanged(sender As Object, e As EventArgs) Handles prog6.CheckedChanged
        If record.Checked = True Then
            setting = 6
            pro(setting).count = 0
            prog6.Checked = False
        End If
        If record.Checked = False Then
            If pro(6).empty Then
                If prog6.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog6.Checked = False
            Else
                Timer6.Enabled = prog6.Checked
            End If
        End If
    End Sub

    Private Sub prog7_CheckedChanged(sender As Object, e As EventArgs) Handles prog7.CheckedChanged
        If record.Checked = True Then
            setting = 7
            pro(setting).count = 0
            prog7.Checked = False
        End If
        If record.Checked = False Then
            If pro(7).empty Then
                If prog7.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog7.Checked = False
            Else
                Timer7.Enabled = prog7.Checked
            End If
        End If
    End Sub

    Private Sub prog8_CheckedChanged(sender As Object, e As EventArgs) Handles prog8.CheckedChanged
        If record.Checked = True Then
            setting = 8
            pro(setting).count = 0
            prog8.Checked = False
        End If
        If record.Checked = False Then
            If pro(8).empty Then
                If prog8.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog8.Checked = False
            Else
                Timer8.Enabled = prog8.Checked
            End If
        End If
    End Sub

    Private Sub prog9_CheckedChanged(sender As Object, e As EventArgs) Handles prog9.CheckedChanged
        If record.Checked = True Then
            setting = 9
            pro(setting).count = 0
            prog9.Checked = False
        End If
        If record.Checked = False Then
            If pro(9).empty Then
                If prog9.Checked = True Then
                    MessageBox.Show("This Program is empty fill it first with 'Record'!",
                            "Empty!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
                End If
                prog9.Checked = False
            Else
                Timer9.Enabled = prog9.Checked
            End If
        End If
    End Sub

    Private Sub setpos_Click(sender As Object, e As EventArgs) Handles setpos.Click
        pro(setting).empty = False
        pro(setting).count = pro(setting).count + 1
        For index As Integer = 1 To 10
            pro(setting).actions(pro(setting).count).chan(index) = ch(index)
        Next
        For index As Integer = 1 To 10
            pro(setting).actions(pro(setting).count).val(index) = chv(index)
        Next

        '        MessageBox.Show(setting.ToString & "- prog: -" &
        '                        "1:" & pro(setting).actions(pro(setting).count).val(1).ToString & "-" &
        '                        "2:" & pro(setting).actions(pro(setting).count).val(2).ToString & "-" &
        '                        "3:" & pro(setting).actions(pro(setting).count).val(3).ToString & "-" &
        '                        "4:" & pro(setting).actions(pro(setting).count).val(4).ToString & "-" &
        '                        "5:" & pro(setting).actions(pro(setting).count).val(5).ToString & "- slider: -" &
        '                        "1:" & chv(1) & "-" &
        '                        "2:" & chv(2) & "-" &
        '                        "3:" & chv(3) & "-" &
        '                        "4:" & chv(4) & "-" &
        '                        "5:" & chv(5) & "-",
        '                            "Ping!",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Information,
        '                       MessageBoxDefaultButton.Button1)

        Select Case setting
            Case 1
                prog1.ForeColor = Color.Red
            Case 2
                prog2.ForeColor = Color.Red
            Case 3
                prog3.ForeColor = Color.Red
            Case 4
                prog4.ForeColor = Color.Red
            Case 5
                prog5.ForeColor = Color.Red
            Case 6
                prog6.ForeColor = Color.Red
            Case 7
                prog7.ForeColor = Color.Red
            Case 8
                prog8.ForeColor = Color.Red
            Case 9
                prog9.ForeColor = Color.Red
        End Select



    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles spe1.TextChanged
        pro(1).speed = spe1.Text
        Timer1.Interval = spe1.Text
    End Sub

    Private Sub spe2_TextChanged(sender As Object, e As EventArgs) Handles spe2.TextChanged
        pro(2).speed = spe2.Text
        Timer2.Interval = spe2.Text
    End Sub

    Private Sub spe3_TextChanged(sender As Object, e As EventArgs) Handles spe3.TextChanged
        pro(3).speed = spe3.Text
        Timer3.Interval = spe3.Text
    End Sub

    Private Sub spe4_TextChanged(sender As Object, e As EventArgs) Handles spe4.TextChanged
        pro(4).speed = spe4.Text
        Timer4.Interval = spe4.Text
    End Sub

    Private Sub spe5_TextChanged(sender As Object, e As EventArgs) Handles spe5.TextChanged
        pro(5).speed = spe5.Text
        Timer5.Interval = spe5.Text
    End Sub

    Private Sub spe6_TextChanged(sender As Object, e As EventArgs) Handles spe6.TextChanged
        pro(6).speed = spe6.Text
        Timer6.Interval = spe6.Text
    End Sub

    Private Sub spe7_TextChanged(sender As Object, e As EventArgs) Handles spe7.TextChanged
        pro(7).speed = spe7.Text
        Timer7.Interval = spe7.Text
    End Sub

    Private Sub spe8_TextChanged(sender As Object, e As EventArgs) Handles spe8.TextChanged
        pro(8).speed = spe8.Text
        Timer8.Interval = spe8.Text
    End Sub

    Private Sub spe9_TextChanged(sender As Object, e As EventArgs) Handles spe9.TextChanged
        pro(9).speed = spe9.Text
        Timer9.Interval = spe9.Text
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim num As Integer = 1
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim num As Integer = 2
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim num As Integer = 3
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim num As Integer = 4
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Dim num As Integer = 5
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Dim num As Integer = 6
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        Dim num As Integer = 7
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        Dim num As Integer = 8
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        Dim num As Integer = 9
        For run As Integer = 1 To 10
            SSD(pro(num).actions(runner(num)).chan(run) & "c")
            SSD(pro(num).actions(runner(num)).val(run) & "v")
        Next
        runner(num) = runner(num) + 1
        If runner(num) > pro(num).count Then
            runner(num) = 1
        End If
    End Sub

    Private Sub sce1_Click(sender As Object, e As EventArgs) Handles sce1.Click, sce2.Click, sce3.Click, sce4.Click, sce5.Click, sce6.Click, sce7.Click, sce8.Click, sce9.Click, sce10.Click, sce11.Click, sce12.Click, sce13.Click, sce14.Click, sce15.Click, sce16.Click, sce17.Click, sce18.Click
        'get id
        Dim temp As String = sender.text
        Dim id As Integer = Val(temp)

        If record.Checked = True Then
            For run As Integer = 1 To 10
                sce(id).chan(run) = ch(run)
                sce(id).val(run) = chv(run)
            Next
            sce(id).empty = False
            Select Case id
                Case 1
                    sce1.ForeColor = Color.Red
                Case 2
                    sce2.ForeColor = Color.Red
                Case 3
                    sce3.ForeColor = Color.Red
                Case 4
                    sce4.ForeColor = Color.Red
                Case 5
                    sce5.ForeColor = Color.Red
                Case 6
                    sce6.ForeColor = Color.Red
                Case 7
                    sce7.ForeColor = Color.Red
                Case 8
                    sce8.ForeColor = Color.Red
                Case 9
                    sce9.ForeColor = Color.Red
                Case 10
                    sce10.ForeColor = Color.Red
                Case 11
                    sce11.ForeColor = Color.Red
                Case 12
                    sce12.ForeColor = Color.Red
                Case 13
                    sce13.ForeColor = Color.Red
                Case 14
                    sce14.ForeColor = Color.Red
                Case 15
                    sce15.ForeColor = Color.Red
                Case 16
                    sce16.ForeColor = Color.Red
                Case 17
                    sce17.ForeColor = Color.Red
                Case 18
                    sce18.ForeColor = Color.Red
            End Select
            record.Checked = False
        Else
            If sce(id).empty Then
                MessageBox.Show("This scene is empty fill it first with 'Record'!",
                        "Empty!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)
            Else
                For run As Integer = 1 To 10
                    SSD(sce(id).chan(run) & "c")
                    SSD(sce(id).val(run) & "v")
                Next
            End If
        End If
    End Sub

    Private Sub save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
        ' Create a string array with the lines of text
        Dim lines() As String = {"DMX-Control save file. Edit what you want but don't blame me!", "Scenes:"}

        Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        ' Write the string array to a new file named "WriteLines.txt".
        Using outputFile As New StreamWriter(mydocpath & Convert.ToString("\DMX-Control.txt"))
            File.Delete(mydocpath & "\DMX-Control")
            For Each line As String In lines
                outputFile.WriteLine(line)
            Next
            For index As Integer = 1 To 18
                outputFile.WriteLine("Scene " & index & ":")
                outputFile.WriteLine(sce(index).empty)
                For run As Integer = 1 To 10
                    outputFile.WriteLine(sce(index).chan(run))
                    outputFile.WriteLine(sce(index).val(run))
                Next
            Next
            outputFile.WriteLine("Programs:")
            For index As Integer = 1 To 9
                outputFile.WriteLine("Program" & index & ":")
                outputFile.WriteLine(pro(index).empty)
                For wata As Integer = 1 To 255
                    For run As Integer = 1 To 10
                        outputFile.WriteLine(pro(index).actions(wata).chan(run))
                        outputFile.WriteLine(pro(index).actions(wata).val(run))
                    Next
                Next
            Next
        End Using
        MessageBox.Show("Saved your settings to 'MyDocuments\DMX-Control.txt'!",
                "Saved!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub load_btn_Click(sender As Object, e As EventArgs) Handles load_btn.Click
        Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        If File.Exists(mydocpath & "\DMX-Control.txt") Then
            Dim fileReader As System.IO.StreamReader
            fileReader =
            My.Computer.FileSystem.OpenTextFileReader(mydocpath & Convert.ToString("\DMX-Control.txt"))
            Dim stringReader(46318) As String
            For index As Integer = 1 To 46318
                stringReader(index) = fileReader.ReadLine()
            Next
            fileReader.Close()
            fileReader.Dispose()
            fileReader = Nothing
            MessageBox.Show("Loaded your settings from 'MyDocuments\DMX-Control.txt'!",
                            "Loaded!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)

            For index As Integer = 1 To 18                            'load Scenes
                If stringReader(4 + (22 * (index - 1))) = "False" Then
                    For run As Integer = 1 To 10
                        sce(index).chan(run) = stringReader(5 + (2 * (run - 1)) + (22 * (index - 1)))
                        sce(index).val(run) = stringReader(6 + (2 * (run - 1)) + (22 * (index - 1)))
                    Next
                    sce(index).empty = False
                    Select Case index
                        Case 1
                            sce1.ForeColor = Color.Red
                        Case 2
                            sce2.ForeColor = Color.Red
                        Case 3
                            sce3.ForeColor = Color.Red
                        Case 4
                            sce4.ForeColor = Color.Red
                        Case 5
                            sce5.ForeColor = Color.Red
                        Case 6
                            sce6.ForeColor = Color.Red
                        Case 7
                            sce7.ForeColor = Color.Red
                        Case 8
                            sce8.ForeColor = Color.Red
                        Case 9
                            sce9.ForeColor = Color.Red
                        Case 10
                            sce10.ForeColor = Color.Red
                        Case 11
                            sce11.ForeColor = Color.Red
                        Case 12
                            sce12.ForeColor = Color.Red
                        Case 13
                            sce13.ForeColor = Color.Red
                        Case 14
                            sce14.ForeColor = Color.Red
                        Case 15
                            sce15.ForeColor = Color.Red
                        Case 16
                            sce16.ForeColor = Color.Red
                        Case 17
                            sce17.ForeColor = Color.Red
                        Case 18
                            sce18.ForeColor = Color.Red
                    End Select
                End If

            Next

            For index As Integer = 1 To 9                             'load Programs
                If stringReader(401 + (257 * 10 * 2 * (index - 1)) - (38 * (index - 1))) = "False" Then
                    For wata As Integer = 1 To 255
                        For run As Integer = 1 To 10
                            pro(index).actions(wata).chan(run) = stringReader((401 + (257 * 10 * 2 * (index - 1)) - (38 * (index - 1))) + (2 * wata * run) - 1)
                            pro(index).actions(wata).val(run) = stringReader((401 + (257 * 10 * 2 * (index - 1)) - (38 * (index - 1))) + (2 * wata * run))
                        Next
                    Next
                    pro(index).empty = False
                    Select Case index
                        Case 1
                            prog1.ForeColor = Color.Red
                        Case 2
                            prog2.ForeColor = Color.Red
                        Case 3
                            prog3.ForeColor = Color.Red
                        Case 4
                            prog4.ForeColor = Color.Red
                        Case 5
                            prog5.ForeColor = Color.Red
                        Case 6
                            prog6.ForeColor = Color.Red
                        Case 7
                            prog7.ForeColor = Color.Red
                        Case 8
                            prog8.ForeColor = Color.Red
                        Case 9
                            prog9.ForeColor = Color.Red
                    End Select
                End If

            Next
        Else
            MessageBox.Show("Could not load your settings from 'MyDocuments\DMX-Control.txt'!",
                            "File not found!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)

        End If
    End Sub
End Class

