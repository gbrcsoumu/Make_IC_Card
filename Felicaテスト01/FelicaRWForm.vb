'===================================================================================================
'
'   Felica カードへの書込フォーム
'
'   2019/12 CODED By kanyama
'
'===================================================================================================

Imports System.Threading

Public Class FelicaRWForm

    'Private CardMasterKeyString As String
    Private kind1() As String, kind2() As String, kind3() As String
    Private No() As String, Name1() As String, Affiliation1() As String, Affiliation2() As String, Affiliation3() As String, Post() As String, IDm() As String

    '====================================
    ' Invokeメソッドで使用するデリゲート
    '====================================
    Delegate Sub txtMessage_Text_Delegate(ByVal value As String)
    Delegate Sub txtMessage_Scroll_Delegate()
    Delegate Sub btnCardID_Enable_Delegate(ByVal value As Boolean)

    Private dic As Dictionary(Of String, Int16)
    '===============================
    ' txtMessage にメッセージを追加
    '===============================
    Private Sub txtMessage_Text(ByVal value As String)
        txtMessage.Text += value
    End Sub

    '=====================================
    ' txtMessage の表示位置を最終行に移動
    '=====================================
    Private Sub txtMessage_Scroll()
        txtMessage.SelectionStart = txtMessage.Text.Length
        txtMessage.Focus()
        txtMessage.ScrollToCaret()
    End Sub

    '====================================
    ' btnCardID ボタンの有効・無効を設定
    '====================================
    Private Sub btnCardID_Enable(ByVal value As Boolean)
        btnCardID.Enabled = value
    End Sub

    '====================================
    ' DumpWithMacButton ボタンの有効・無効を設定
    '====================================
    Private Sub DumpWithMacButton_Enable(ByVal value As Boolean)
        DumpWithMacButton.Enabled = value
    End Sub

    '====================================
    ' CkWriteBtn ボタンの有効・無効を設定
    '====================================
    Private Sub CkWriteBtn_Enable(ByVal value As Boolean)
        CkWriteBtn.Enabled = value
    End Sub

    '=============================
    ' 別スレッドでPC/SC通信を実行
    '=============================
    ' clsWinSCardクラスに関して
    ' (1) Timeout_MilliSecond にタイムアウトする時間(ミリ秒)を設定する
    '     設定しなければ、Pasoriにカードがセットされるまで無限に待機する
    ' (2) getCardID() を実行することで、下記のプロパティを読み取れるようになります
    '     CardType … カードの種類
    '     IsFelica … Felicaの場合、True
    '     IDm      … FelicaのIDm
    '     PMm      … FelicaのPMm
    '     IsMifare … Mifareの場合、True
    '     UID      … MifareのUID
    Private Sub Thread_PCSC()
        '----------
        ' 変数定義
        '----------
        Dim pcsc As New clsWinSCard(CardMasterKeyString)
        Dim msg As String = ""

        '----------------
        ' Delegateの作成
        '----------------
        Dim msg_txt As New txtMessage_Text_Delegate(AddressOf txtMessage_Text)
        Dim msg_scroll As New txtMessage_Scroll_Delegate(AddressOf txtMessage_Scroll)
        Dim btn_enable As New btnCardID_Enable_Delegate(AddressOf btnCardID_Enable)

        '----------------
        ' ボタンを無効化
        '----------------
        Me.Invoke(btn_enable, New Object() {False})

        '------------------------------
        ' タイムアウトする時間(ミリ秒)
        '------------------------------
        'pcsc.Timeout_MilliSecond = 3000

        '------------------------------------
        ' FelicaのIDm,PMM、MifareのUIDを取得
        '------------------------------------
        If pcsc.getCardID() Then
            If pcsc.IsFelica Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[IDm] " + pcsc.IDm + vbNewLine + _
                      "[PMm] " + pcsc.PMm + vbNewLine
                msg += pcsc.S_PAD0
            ElseIf pcsc.IsMifare Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[UID] " + pcsc.UID
            End If
            Me.Invoke(msg_txt, New Object() {msg + vbNewLine})

        Else
            'エラーメッセージを画面に表示
            Me.Invoke(msg_txt, New Object() {pcsc.ErrorMsg + vbNewLine})
        End If

        '--------------------------
        ' メッセージの最終行に移動
        '--------------------------
        Me.Invoke(msg_scroll)

        '----------------
        ' ボタンを有効化
        '----------------
        Me.Invoke(btn_enable, New Object() {True})
    End Sub

    '======================
    ' ボタン・クリック処理
    '======================
    ' 実行中、画面が固まってしまうので実際の処理は別スレッドで実行します
    Private Sub btnCardID_Click(sender As System.Object, e As System.EventArgs) Handles btnCardID.Click
        Me.txtMessage.Text = ""
        'PC/SC通信を別スレッドで実行
        Dim th As New Thread(New ThreadStart(AddressOf Thread_PCSC))
        'バックグランドで実行
        th.IsBackground = True
        'スレッド開始
        th.Start()
    End Sub

    '=============================
    ' 別スレッドでPC/SC通信を実行
    '=============================
    ' clsWinSCardクラスに関して
    ' (1) Timeout_MilliSecond にタイムアウトする時間(ミリ秒)を設定する
    '     設定しなければ、Pasoriにカードがセットされるまで無限に待機する
    ' (2) getDataWithMac_A() を実行することで、下記のプロパティを読み取れるようになります
    '     CardType … カードの種類
    '     IsFelica … Felicaの場合、True
    '     IDm      … FelicaのIDm
    '     PMm      … FelicaのPMm
    '     IsMifare … Mifareの場合、True
    '     UID      … MifareのUID

    Private Sub Thread_felica()
        '----------
        ' 変数定義
        '----------
        Dim pcsc As New clsWinSCard(CardMasterKeyString)
        Dim msg As String = ""

        '----------------
        ' Delegateの作成
        '----------------
        Dim msg_txt As New txtMessage_Text_Delegate(AddressOf txtMessage_Text)
        Dim msg_scroll As New txtMessage_Scroll_Delegate(AddressOf txtMessage_Scroll)
        Dim btn2_enable As New btnCardID_Enable_Delegate(AddressOf DumpWithMacButton_Enable)

        '----------------
        ' ボタンを無効化
        '----------------
        Me.Invoke(btn2_enable, New Object() {False})

        '------------------------------
        ' タイムアウトする時間(ミリ秒)
        '------------------------------
        'pcsc.Timeout_MilliSecond = 3000

        '------------------------------------
        ' FelicaのIDm,PMM、MifareのUIDを取得
        '------------------------------------
        If pcsc.getDataWithMac_A() Then
            If pcsc.IsFelica Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[IDm] " + pcsc.IDm + vbNewLine + _
                      "[PMm] " + pcsc.PMm + vbNewLine
                msg += pcsc.S_PAD0
            ElseIf pcsc.IsMifare Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[UID] " + pcsc.UID
            End If
            Me.Invoke(msg_txt, New Object() {msg + vbNewLine})

        Else
            'エラーメッセージを画面に表示
            Me.Invoke(msg_txt, New Object() {pcsc.ErrorMsg + vbNewLine})
        End If

        '--------------------------
        ' メッセージの最終行に移動
        '--------------------------
        Me.Invoke(msg_scroll)

        '----------------
        ' ボタンを有効化
        '----------------
        Me.Invoke(btn2_enable, New Object() {True})
    End Sub

    '======================
    ' ボタン・クリック処理
    '======================
    ' 実行中、画面が固まってしまうので実際の処理は別スレッドで実行します
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles DumpWithMacButton.Click
        Me.txtMessage.Text = ""
        'PC/SC通信を別スレッドで実行
        Dim th As New Thread(New ThreadStart(AddressOf Thread_felica))
        'バックグランドで実行
        th.IsBackground = True
        'スレッド開始
        th.Start()
    End Sub


    '======================
    ' 任意のブロックにデータを書き込む（スレッドは使用しない）
    '======================
    ' 
    Private Sub BlockWriteButton_Click(sender As Object, e As EventArgs) Handles BlockWriteButton.Click

        Me.txtMessage.Text = ""
        '----------
        ' 変数定義
        '----------
        Dim pcsc As New clsWinSCard(CardMasterKeyString)
        Dim msg As String = ""

        '----------------
        ' ボタンを無効化
        '----------------
        Me.BlockWriteButton.Enabled = False

        '------------------------------
        ' タイムアウトする時間(ミリ秒)
        '------------------------------
        'pcsc.Timeout_MilliSecond = 3000

        '------------------------------------
        ' Felicaにデータの書き込み
        '------------------------------------
        Dim adr As Int16, chrlen As Integer
        Dim chr As Byte() = {0, 0}
        adr = dic(Me.ComboBox1.Text)
        If Me.TextBox1.Text <> "" Then
            chrlen = Len(Me.TextBox1.Text)
            chr = System.Text.Encoding.UTF8.GetBytes(Me.TextBox1.Text)
        Else
            chrlen = 0
        End If
        If pcsc.setFelicaCard(adr, chr, chrlen) Then
            If pcsc.IsFelica Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[IDm] " + pcsc.IDm + vbNewLine + _
                      "[PMm] " + pcsc.PMm + vbNewLine
                msg += "[" + Me.ComboBox1.Text + "] " + Me.TextBox1.Text
                msg += " 書込成功" + vbNewLine
            End If

            'メッセージを画面に表示
            Me.txtMessage_Text(msg + vbNewLine)
            'Me.Invoke(msg_txt, New Object() {msg + vbNewLine})
        Else
            'エラーメッセージを画面に表示
            Me.txtMessage_Text(pcsc.ErrorMsg + vbNewLine)
        End If

        '--------------------------
        ' メッセージの最終行に移動
        '--------------------------
        Me.txtMessage_Scroll()

        '----------------
        ' ボタンを有効化
        '----------------
        Me.BlockWriteButton.Enabled = True

    End Sub

    '======================
    ' フォームロード時の初期設定
    '======================
    ' 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As New OdbcDbIf
        Dim tb As DataTable
        Dim Sql_Command As String
        Dim i As Integer
        Dim Path1 As String
        Path1 = Application.StartupPath

        Dim n As Integer



        ' ログインダイアログの表示

        Dim res As DialogResult

        Do
            LoginID = ""
            LoginPassWord = ""
            Dim f1 As New LoginForm1
            res = f1.ShowDialog()
            f1.Dispose()
            If res = System.Windows.Forms.DialogResult.Cancel Then
                ' CANCELされた場合は終了する。
                Me.Close()
                Exit Sub
            End If

            Try
                db.Connect(DataBaseName, LoginID, LoginPassWord, -1)
                Exit Do

            Catch ex As Exception
                MsgBox("ID又はパスワードが違います。")
                'Me.Close()
                db.Disconnect()
                'Exit Sub
            End Try
        Loop

        Me.Width = 1000     ' フォームんの幅を設定
        Me.Height = 600     ' フォームんの高さを設定

        Sql_Command = "SELECT ""所属センター"" FROM """ + MemberNameTable2 + """ ORDER BY ""所属センター"""
        tb = db.ExecuteSql(Sql_Command)
        n = tb.Rows.Count
        If n > 0 Then
            ReDim Me.Affiliation1(n - 1)
            For i = 0 To n - 1
                Me.Affiliation1(i) = tb.Rows(i).Item("所属センター").ToString()
            Next

        End If
        Me.kind1 = Nkind(Me.Affiliation1)
        Me.Label_Center.Text = "所属センター(" + Me.kind1.Length.ToString("0") + ")"
        For Each s In Me.kind1
            Me.ComboBox2.Items.Add(s)
        Next

        db.Disconnect()
        tb.Dispose()


        dic = New Dictionary(Of String, Int16)
        For a As Int16 = 0 To 13
            'Me.ComboBox1.Items.Add("S_PAD" + a.ToString("D2"))
            dic.Add("S_PAD" + a.ToString("D2"), a)
        Next
        For Each s In dic
            Me.ComboBox1.Items.Add(s.Key)
        Next
        Me.ComboBox1.Text = ComboBox1.GetItemText(ComboBox1.Items(0))

        Const C_width As Integer = 100
        With Me.DataGridView1
            .Width = 100 + C_width * 7.5 + 60
            .Height = 300
            .ColumnCount = 7
            .ColumnHeadersVisible = True
            .ColumnHeadersHeight = 14
            .ScrollBars = ScrollBars.Both

            Dim columnHeaderStyle As New DataGridViewCellStyle()
            columnHeaderStyle.BackColor = Color.White
            columnHeaderStyle.Font = New Font("MSゴシック", 10, FontStyle.Bold)
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = columnHeaderStyle
            .Columns(0).Name = "職員番号"
            .Columns(1).Name = "氏名"
            .Columns(2).Name = "センター"
            .Columns(3).Name = "所属部"
            .Columns(4).Name = "所属室"
            .Columns(5).Name = "役職"
            .Columns(6).Name = "IDm"
            '                  .Columns(5).Name = "On/Off"
            .RowHeadersVisible = True
            .Columns(0).Width = 80
            .Columns(1).Width = C_width
            .Columns(2).Width = C_width
            .Columns(3).Width = C_width
            .Columns(4).Width = C_width
            .Columns(5).Width = C_width
            .Columns(6).Width = C_width * 1.5

            'DataGridViewButtonColumnの作成
            Dim column As New DataGridViewButtonColumn()
            '列の名前を設定
            column.Name = "カード"
            '全てのボタンに"詳細閲覧"と表示する
            column.UseColumnTextForButtonValue = True
            column.Text = "作成"
            'DataGridViewに追加する
            .Columns.Add(column)
        End With

        Me.CenterToScreen()
    End Sub


    Private Sub CkWriteBtn_Click(sender As Object, e As EventArgs) Handles CkWriteBtn.Click
        Me.txtMessage.Text = ""
        'PC/SC通信を別スレッドで実行
        Dim th As New Thread(New ThreadStart(AddressOf Thread_CkWrite))
        'バックグランドで実行
        th.IsBackground = True
        'スレッド開始
        th.Start()
    End Sub


    Private Sub Thread_CkWrite()
        '----------
        ' 変数定義
        '----------
        Dim pcsc As New clsWinSCard(CardMasterKeyString)
        Dim msg As String = ""

        '----------------
        ' Delegateの作成
        '----------------
        Dim msg_txt As New txtMessage_Text_Delegate(AddressOf txtMessage_Text)
        Dim msg_scroll As New txtMessage_Scroll_Delegate(AddressOf txtMessage_Scroll)
        Dim CkWriteBtn_enable1 As New btnCardID_Enable_Delegate(AddressOf CkWriteBtn_Enable)

        '----------------
        ' ボタンを無効化
        '----------------
        Me.Invoke(CkWriteBtn_enable1, New Object() {False})

        '------------------------------
        ' タイムアウトする時間(ミリ秒)
        '------------------------------
        'pcsc.Timeout_MilliSecond = 3000

        '------------------------------------
        ' FelicaのIDm,PMM、MifareのUIDを取得
        '------------------------------------
        If pcsc.makeCardKey() Then
            If pcsc.IsFelica Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[IDm] " + pcsc.IDm + vbNewLine + _
                      "[PMm] " + pcsc.PMm + vbNewLine
                msg += pcsc.S_PAD0
            ElseIf pcsc.IsMifare Then
                msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                      "[UID] " + pcsc.UID
            End If
            Me.Invoke(msg_txt, New Object() {msg + vbNewLine})

            'メッセージを画面に表示
            'Dim delimiter As Char = vbNewLine
            ''Sprit受け取り配列
            'Dim array() As String
            'array = pcsc.S_PAD0.Split(delimiter)
            'For Each bufstr In array
            '    Me.Invoke(msg_txt, New Object() {bufstr + vbNewLine})
            'Next

            'Me.Invoke(msg_txt, New Object() {msg + vbNewLine})
            'Me.Invoke(msg_txt, New Object() {pcsc.S_PAD0 + vbNewLine})
        Else
            'エラーメッセージを画面に表示
            Me.Invoke(msg_txt, New Object() {pcsc.ErrorMsg + vbNewLine})
        End If

        '--------------------------
        ' メッセージの最終行に移動
        '--------------------------
        Me.Invoke(msg_scroll)

        '----------------
        ' ボタンを有効化
        '----------------
        Me.Invoke(CkWriteBtn_enable1, New Object() {True})
    End Sub



    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'Me.CardMasterKeyString = "GBRC 2020"

    End Sub

    Private Function Nkind(ByRef x() As String) As String()
        Dim xn As Integer, yn() As String
        Dim i As Integer, kn As Integer
        xn = x.Length
        If xn > 0 Then
            ReDim yn(xn - 1)
            kn = 1
            yn(kn - 1) = x(0)
            For i = 1 To xn - 1
                If x(i) <> yn(kn - 1) Then
                    kn += 1
                    yn(kn - 1) = x(i)
                End If
            Next
            ReDim Preserve yn(kn - 1)

        Else
            ReDim yn(0)
            yn(0) = "NO DATA"

        End If

        Return yn
    End Function


    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim db As New OdbcDbIf
        Dim tb As DataTable
        Dim Sql_Command As String
        Dim i As Integer
        Dim n As Integer
        Dim A As String

        A = ComboBox2.Text
        If A <> "" Then
            db.Connect()

            Sql_Command = "SELECT ""所属部"" FROM """ + MemberNameTable2 + """ WHERE ""所属センター"" = '" & A & "' ORDER BY ""所属部"""
            tb = db.ExecuteSql(Sql_Command)
            n = tb.Rows.Count
            If n > 0 Then
                ReDim Me.Affiliation2(n - 1)
                For i = 0 To n - 1
                    Me.Affiliation2(i) = tb.Rows(i).Item("所属部").ToString()
                Next

            End If
            Me.kind2 = Nkind(Me.Affiliation2)
            Me.ComboBox3.Items.Clear()
            For Each s In Me.kind2
                Me.ComboBox3.Items.Add(s)
            Next
            If Me.kind2.Length = 1 Then
                Me.ComboBox3.Text = Me.kind2(0)
            Else
                Me.ComboBox3.Text = ""
            End If
            Me.Label_Department.Text = "所属部(" + Me.kind2.Length.ToString("0") + ")"

            db.Disconnect()
            tb.Dispose()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim db As New OdbcDbIf
        Dim tb As DataTable
        Dim Sql_Command As String
        Dim i As Integer
        Dim n As Integer
        Dim A As String, B As String

        A = ComboBox2.Text
        B = ComboBox3.Text

        If A <> "" And B <> "" Then
            db.Connect()

            Sql_Command = "SELECT ""所属室"" FROM """ + MemberNameTable2 + """ WHERE ""所属センター"" = '" + A + "' AND ""所属部"" = '" + B + "' ORDER BY ""所属室"""
            tb = db.ExecuteSql(Sql_Command)
            n = tb.Rows.Count
            If n > 0 Then
                ReDim Me.Affiliation3(n - 1)
                For i = 0 To n - 1
                    Me.Affiliation3(i) = tb.Rows(i).Item("所属室").ToString()
                Next

            End If
            Me.kind3 = Nkind(Me.Affiliation3)

            Me.ComboBox4.Items.Clear()
            For Each s In Me.kind3
                Me.ComboBox4.Items.Add(s)
            Next
            If Me.kind3.Length = 1 Then
                Me.ComboBox4.Text = Me.kind3(0)
            Else
                Me.ComboBox4.Text = ""
            End If
            Me.Label_Section.Text = "所属室(" + Me.kind3.Length.ToString("0") + ")"

            db.Disconnect()
            tb.Dispose()
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim db As New OdbcDbIf
        Dim tb As DataTable, tb2 As DataTable
        Dim Sql_Command As String, Sql_Command2 As String, Idm2 As String = ""
        Dim i As Integer
        'Dim n As Integer
        Dim A As String, B As String, C As String
        Dim Row() As String

        A = ComboBox2.Text
        B = ComboBox3.Text
        C = ComboBox4.Text

        If A <> "" And B <> "" And C <> "" Then
            db.Connect()


            Dim period As String = " ""異動日前日"" >= CURDATE AND ""異動日"" <= CURDATE "

            Sql_Command = "SELECT ""職員番号"",""氏名"",""所属センター"",""所属部"",""所属室"",""役職"" FROM "
            Sql_Command += """" + MemberNameTable2 + """ WHERE " + period + " AND ""所属センター"" = '" + A + "' AND ""所属部"" = '" + B + "' AND ""所属室"" = '" + C + "'" + " ORDER BY ""職員番号"""

            tb = db.ExecuteSql(Sql_Command)
            Dim n As Integer = tb.Rows.Count
            If n > 0 Then
                ReDim No(n - 1), Name1(n - 1), Affiliation1(n - 1), Affiliation2(n - 1), Affiliation3(n - 1), Post(n - 1), IDm(n - 1)
                'Me.ComboBox1.Items.Clear()
                For i = 0 To n - 1
                    No(i) = tb.Rows(i).Item("職員番号").ToString()
                    Sql_Command2 = "SELECT IDm FROM """ + MemberNameTable + """ WHERE ""職員番号"" = '" + No(i) + "'"
                    tb2 = db.ExecuteSql(Sql_Command2)
                    Dim n2 As Integer = tb2.Rows.Count
                    If n2 > 0 Then
                        Idm2 = tb2.Rows(0).Item("IDm").ToString()
                    End If
                    Name1(i) = tb.Rows(i).Item("氏名").ToString()
                    Affiliation1(i) = tb.Rows(i).Item("所属センター").ToString()
                    Affiliation2(i) = tb.Rows(i).Item("所属部").ToString()
                    Affiliation3(i) = tb.Rows(i).Item("所属室").ToString()
                    Post(i) = tb.Rows(i).Item("役職").ToString()
                    IDm(i) = Idm2
                Next
            End If

            With Me.DataGridView1
                .Rows.Clear()
                For i = 0 To n - 1
                    Row = {No(i), Name1(i), Affiliation1(i), Affiliation2(i), Affiliation3(i), Post(i), IDm(i)}
                    .Rows.Add(Row)
                Next
            End With

            db.Disconnect()
            tb.Dispose()
        End If

    End Sub

    'CellContentClickイベントハンドラ
    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, _
            ByVal e As DataGridViewCellEventArgs) _
            Handles DataGridView1.CellContentClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        '"Button"列ならば、ボタンがクリックされた
        If dgv.Columns(e.ColumnIndex).Name = "カード" Then
            'MessageBox.Show((e.RowIndex.ToString() + _
            '    "行のボタンがクリックされました。"))


            Dim pcsc As New clsWinSCard(CardMasterKeyString)
            Dim msg As String = ""
            Dim adr As Int16, chrlen As Integer, data_n As Integer
            Dim chr As Byte()
            adr = 0
            data_n = e.RowIndex
            chr = System.Text.Encoding.UTF8.GetBytes(Me.No(data_n))
            chrlen = Len(Me.No(data_n))

            If pcsc.setFelicaCard(adr, chr, chrlen) And pcsc.makeCardKey() Then
                If pcsc.IsFelica Then
                    msg = "[カードの種類] " + pcsc.CardType + vbNewLine + _
                          "[IDm] " + pcsc.IDm + vbNewLine + _
                          "[PMm] " + pcsc.PMm + vbNewLine
                    msg += "[" + Me.ComboBox1.Text + "] " + Me.TextBox1.Text
                    msg += " 書込成功" + vbNewLine
                    Me.IDm(data_n) = pcsc.IDm

                    Dim db As New OdbcDbIf
                    Dim tb As DataTable
                    Dim Sql_Command As String
                    'Dim i As Integer
                    'Dim n As Integer
                    Dim A As String, B As String, C As String
                    'Dim Row() As String

                    db.Connect()

                    'Sql_Command = "SELECT * FROM ""職員一覧"" WHERE ""所属センター"" = '" + A + "' AND ""所属部"" = '" + B + "' AND ""所属室"" = '" + C + "' ORDER BY ""職員番号"""

                    Sql_Command = "UPDATE """ + MemberNameTable + """ SET IDm = '" + Me.IDm(data_n) + "' WHERE ""職員番号"" = '" + Me.No(data_n) + "'"

                    tb = db.ExecuteSql(Sql_Command)

                    'Sql_Command = "UPDATE """ + MemberNameTable2 + """ SET IDm = '" + Me.IDm(data_n) + "' WHERE ""職員番号"" = '" + Me.No(data_n) + "'"

                    'tb = db.ExecuteSql(Sql_Command)

                    'UPDATE " 従業員名簿 " SET " 給与 " =32000, " 控除 " =1 WHERE " 従業員番号 " = 'E10001'

                    A = ComboBox2.Text
                    B = ComboBox3.Text
                    C = ComboBox4.Text
                    'db.Connect()

                    Sql_Command = "SELECT Idm FROM """ + MemberNameTable + """ WHERE ""職員番号"" = '" + Me.No(data_n) + "'"
                    tb = db.ExecuteSql(Sql_Command)
                    Dim n As Integer = tb.Rows.Count
                    If n > 0 Then
                        Me.IDm(data_n) = tb.Rows(0).Item("IDm").ToString()
                        Me.DataGridView1.CurrentCell = DataGridView1(6, data_n)
                        Me.DataGridView1.CurrentCell.Value = Me.IDm(data_n)
                    End If

                    db.Disconnect()
                    tb.Dispose()
                End If

                'メッセージを画面に表示
                Me.txtMessage_Text(msg + vbNewLine)
                'Me.Invoke(msg_txt, New Object() {msg + vbNewLine})
            Else
                'エラーメッセージを画面に表示
                Me.txtMessage_Text(pcsc.ErrorMsg + vbNewLine)
            End If

            MsgBox("カードに職員番号(" + Me.No(data_n) + ")が書き込まれました。")
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim CartInput1 As New CardInputForm
        'CartInput1.Show()
        'Me.DialogResult = DialogResult.OK
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Name_Find()
    End Sub


    Private Sub TexBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NameTextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー

            'Dim a As String
            'a = Me.NameTextBox.Text
            'コード()
            Me.Name_Find()
            'e.KeyChar(13) = "" 'キーをクリアする(必要であれば)
        End If
    End Sub

    Private Sub Name_Find()
        If Me.NameTextBox.Text <> "" Then
            Dim db As New OdbcDbIf
            Dim tb As DataTable
            Dim Sql_Command As String
            Dim i As Integer
            'Dim n As Integer
            Dim A As String
            Dim Row() As String

            A = Me.NameTextBox.Text

            db.Connect()


            Dim Year1 As String = Date.Now.Year.ToString
            Dim Month1 As String = Date.Now.Month.ToString
            Dim M2 As Integer = Integer.Parse(Month1) + 1
            If M2 > 12 Then M2 = 1
            Dim Month2 As String = M2.ToString
            Month1 = ("0" + Month1).Substring(Month1.Length - 1, 2)
            Month2 = ("0" + Month2).Substring(Month2.Length - 1, 2)

            Dim Day1 As String = "{" + Month1 + "/01/" + Year1 + "}"
            Dim period As String = " (""異動日前日"" > " + Day1 + "AND ""異動日"" <= " + Day1 + ")"

            'Sql_Command = "SELECT * FROM """ + MemberNameTable2 + """ WHERE " + period + " AND ""所属センター"" = '" + A + "' AND ""所属部"" = '" + B + "' AND ""所属室"" = '" + C + "'" + " ORDER BY ""職員番号"""

            Sql_Command = "SELECT * FROM """ + MemberNameTable2 + """ WHERE " + period + " AND ""氏名"" LIKE '%" + A + "%' ORDER BY ""氏名"""




            'Sql_Command = "SELECT * FROM """ + MemberNameTable2 + """ WHERE ""氏名"" LIKE '%" + A + "%' ORDER BY ""氏名"""
            tb = db.ExecuteSql(Sql_Command)
            Dim n As Integer = tb.Rows.Count
            If n > 0 Then
                ReDim No(n - 1), Name1(n - 1), Affiliation1(n - 1), Affiliation2(n - 1), Affiliation3(n - 1), Post(n - 1), IDm(n - 1)
                'Me.ComboBox1.Items.Clear()
                For i = 0 To n - 1
                    No(i) = tb.Rows(i).Item("職員番号").ToString()
                    Name1(i) = tb.Rows(i).Item("氏名").ToString()
                    Affiliation1(i) = tb.Rows(i).Item("所属センター").ToString()
                    Affiliation2(i) = tb.Rows(i).Item("所属部").ToString()
                    Affiliation3(i) = tb.Rows(i).Item("所属室").ToString()
                    Post(i) = tb.Rows(i).Item("役職").ToString()
                    IDm(i) = tb.Rows(i).Item("IDm").ToString()
                Next
            Else
                MsgBox("そのような名前は存在しません！")
                tb.Dispose()
                db.Disconnect()
                Exit Sub
            End If

            With Me.DataGridView1
                .Rows.Clear()
                For i = 0 To n - 1
                    Row = {No(i), Name1(i), Affiliation1(i), Affiliation2(i), Affiliation3(i), Post(i), IDm(i)}
                    .Rows.Add(Row)
                Next
            End With
            db.Disconnect()
            tb.Dispose()
        End If
    End Sub

End Class
