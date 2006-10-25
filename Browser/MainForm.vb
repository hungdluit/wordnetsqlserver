Imports System.IO
'
' Created by SharpDevelop.
' User: simpsont
' Date: 25/10/2006
' Time: 9:47 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Partial Class MainForm
	Public quot As String = Chr(34)
	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
        Dim appPath As String = Path.GetDirectoryName(Application.ExecutablePath)
        Dim provider As ICSharpCode.TextEditor.Document.FileSyntaxModeProvider = New ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath)
        ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider)
        sqlEditor.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter("SQL")

		Me.SqlConnection1.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & quot & _
				Data_Path() & _
				quot & ";Integrated Security=True;User Instance=False;Timeout=60"
	End Sub

	Public Readonly Property Data_Path() As String
		Get
			'MessageBox.Show(Application.StartupPath & "..\..\..\Database\wordnet.mdf")
			Return "D:\TroyDevel\Proj\WordNetSQLServer\Database\wordnet.mdf"
'			Return Application.StartupPath & "\..\..\..\Database\wordnet.mdf"
		End Get
	End Property
	
	
	Sub BtnExecuteClick(sender As Object, e As System.EventArgs)
		Dim sc As New System.Data.SqlClient.SqlCommand(sqlEditor.Text, sqlconnection1)
		
		dataset1.Tables.Clear()
		sqlDataAdapter1.SelectCommand = sc
		sqlDataAdapter1.Fill(dataset1)
		datagridview1.DataSource = dataset1.Tables(0)
		
'		MessageBox.Show(dataset1.Tables(0).Rows(0)(1))
'		datagridview1.DataMember = dataset1.Tables(0).TableName
		datagridview1.Refresh
	End Sub
End Class