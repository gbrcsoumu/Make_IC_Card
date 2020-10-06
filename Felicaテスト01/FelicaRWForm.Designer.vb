<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FelicaRWForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCardID = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.BlockWriteButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DumpWithMacButton = New System.Windows.Forms.Button()
        Me.CkWriteBtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label_Center = New System.Windows.Forms.Label()
        Me.Label_Department = New System.Windows.Forms.Label()
        Me.Label_Section = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCardID
        '
        Me.btnCardID.Location = New System.Drawing.Point(43, 20)
        Me.btnCardID.Name = "btnCardID"
        Me.btnCardID.Size = New System.Drawing.Size(196, 84)
        Me.btnCardID.TabIndex = 0
        Me.btnCardID.Text = "カードデータダンプ"
        Me.btnCardID.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(39, 146)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(1364, 183)
        Me.txtMessage.TabIndex = 1
        '
        'BlocWriteButton
        '
        Me.BlockWriteButton.Location = New System.Drawing.Point(705, 23)
        Me.BlockWriteButton.Name = "BlocWriteButton"
        Me.BlockWriteButton.Size = New System.Drawing.Size(210, 81)
        Me.BlockWriteButton.TabIndex = 2
        Me.BlockWriteButton.Text = "ブロック書込"
        Me.BlockWriteButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1069, 73)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(282, 31)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "1234"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(1067, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(283, 32)
        Me.ComboBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(921, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Block Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(957, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Value"
        '
        'DumpWithMacButton
        '
        Me.DumpWithMacButton.Location = New System.Drawing.Point(245, 20)
        Me.DumpWithMacButton.Name = "DumpWithMacButton"
        Me.DumpWithMacButton.Size = New System.Drawing.Size(176, 84)
        Me.DumpWithMacButton.TabIndex = 7
        Me.DumpWithMacButton.Text = "Mac付きダンプ"
        Me.DumpWithMacButton.UseVisualStyleBackColor = True
        '
        'CkWriteBtn
        '
        Me.CkWriteBtn.Location = New System.Drawing.Point(439, 20)
        Me.CkWriteBtn.Name = "CkWriteBtn"
        Me.CkWriteBtn.Size = New System.Drawing.Size(206, 84)
        Me.CkWriteBtn.TabIndex = 8
        Me.CkWriteBtn.Text = "個別可カード鍵　書込"
        Me.CkWriteBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(43, 454)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.Size = New System.Drawing.Size(1359, 752)
        Me.DataGridView1.TabIndex = 9
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(43, 388)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(446, 45)
        Me.ComboBox2.TabIndex = 10
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(565, 388)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(372, 45)
        Me.ComboBox3.TabIndex = 11
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(1018, 388)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(384, 45)
        Me.ComboBox4.TabIndex = 12
        '
        'Label_Center
        '
        Me.Label_Center.AutoSize = True
        Me.Label_Center.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Center.Location = New System.Drawing.Point(53, 346)
        Me.Label_Center.Name = "Label_Center"
        Me.Label_Center.Size = New System.Drawing.Size(177, 33)
        Me.Label_Center.TabIndex = 13
        Me.Label_Center.Text = "所属センター"
        '
        'Label_Department
        '
        Me.Label_Department.AutoSize = True
        Me.Label_Department.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Department.Location = New System.Drawing.Point(571, 346)
        Me.Label_Department.Name = "Label_Department"
        Me.Label_Department.Size = New System.Drawing.Size(111, 33)
        Me.Label_Department.TabIndex = 13
        Me.Label_Department.Text = "所属部"
        '
        'Label_Section
        '
        Me.Label_Section.AutoSize = True
        Me.Label_Section.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Section.Location = New System.Drawing.Point(1012, 346)
        Me.Label_Section.Name = "Label_Section"
        Me.Label_Section.Size = New System.Drawing.Size(159, 33)
        Me.Label_Section.TabIndex = 13
        Me.Label_Section.Text = "所属室・課"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.Location = New System.Drawing.Point(1525, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(292, 154)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "閉じる"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'NameTextBox
        '
        Me.NameTextBox.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NameTextBox.Location = New System.Drawing.Point(1465, 388)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(352, 45)
        Me.NameTextBox.TabIndex = 16
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("MS UI Gothic", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button4.Location = New System.Drawing.Point(1465, 306)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(276, 72)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "名前検索"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FelicaRWForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1954, 1255)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label_Section)
        Me.Controls.Add(Me.Label_Department)
        Me.Controls.Add(Me.Label_Center)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CkWriteBtn)
        Me.Controls.Add(Me.DumpWithMacButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BlockWriteButton)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.btnCardID)
        Me.Name = "FelicaRWForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "職員カード発行システム v1.0"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCardID As System.Windows.Forms.Button
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents BlockWriteButton As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DumpWithMacButton As System.Windows.Forms.Button
    Friend WithEvents CkWriteBtn As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Center As System.Windows.Forms.Label
    Friend WithEvents Label_Department As System.Windows.Forms.Label
    Friend WithEvents Label_Section As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
