Imports Microsoft.VisualBasic
Imports DevExpress.XtraTab
Imports DevExpress.XtraEditors
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditAPISample
	Partial Public Class Form1
		Inherits Form
		'PrintableComponentLinkBase link;
		Private horizontalSplitContainerControl1 As SplitContainerControl
		Private verticalSplitContainerControl1 As SplitContainerControl
		'IContainer components = null;

		#Region "Controls"
		Private treeList1 As TreeList
		Private xtraTabControl1 As XtraTabControl
		Private xtraTabPage1 As XtraTabPage
		Private richeditcontrol As RichEditControl
		Private richEditControlCS As RichEditControl
		Private xtraTabPage2 As XtraTabPage
		Private richEditControlVB As RichEditControl
		#End Region

		Private codeExampleNameLbl As LabelControl
		Private codeEditor As ExampleCodeEditor
		Private evaluator As ExampleEvaluatorByTimer
		Private examples As List(Of CodeExampleGroup)
		Private treeListRootNodeLoading As Boolean = True

			Public Sub New()
			InitializeComponent()
			Dim examplePath As String = CodeExampleDemoUtils.GetExamplePath("CodeExamples")

			Dim examplesCS As Dictionary(Of String, FileInfo) = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp)
			Dim examplesVB As Dictionary(Of String, FileInfo) = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.VB)
			DisableTabs(examplesCS.Count, examplesVB.Count)
			Me.examples = CodeExampleDemoUtils.FindExamples(examplePath, examplesCS, examplesVB)
			RearrangeExamples()
			ShowExamplesInTreeList(treeList1, examples)

			Me.codeEditor = New ExampleCodeEditor(richEditControlCS, richEditControlVB)
			CurrentExampleLanguage = CodeExampleDemoUtils.DetectExampleLanguage("RichEditAPISample")
			Me.evaluator = New RichEditExampleEvaluatorByTimer() 'this.components

			AddHandler Me.evaluator.QueryEvaluate, AddressOf OnExampleEvaluatorQueryEvaluate
			AddHandler Me.evaluator.OnBeforeCompile, AddressOf evaluator_OnBeforeCompile
			AddHandler Me.evaluator.OnAfterCompile, AddressOf evaluator_OnAfterCompile

			ShowFirstExample()
			AddHandler xtraTabControl1.SelectedPageChanged, AddressOf xtraTabControl1_SelectedPageChanged
			End Sub

		Private Sub RearrangeExamples()
			Dim i As Integer = 0
			Do While i < examples.Count
				Dim group As CodeExampleGroup = examples(i)
				If group.Name = "Charts" Then
					examples.RemoveAt(i)
					examples.Insert(0, group)
					Exit Do
				End If
				i += 1
			Loop
			i = 0
			Do While i < examples.Count
				Dim group As CodeExampleGroup = examples(i)
				If group.Name.StartsWith("Creation") Then
					examples.RemoveAt(i)
					examples.Insert(1, group)
					Exit Do
				End If
				i += 1
			Loop
		End Sub

		Private Sub evaluator_OnAfterCompile(ByVal sender As Object, ByVal args As OnAfterCompileEventArgs)
			codeEditor.AfterCompile(args.Result)
		End Sub

		Private Sub evaluator_OnBeforeCompile(ByVal sender As Object, ByVal e As EventArgs)
			Dim doc As Document = richeditcontrol.Document
			doc.BeginUpdate()
			codeEditor.BeforeCompile()

			doc.LoadDocument("Document.docx",DocumentFormat.OpenXml)
			doc.EndUpdate()
		End Sub
		Private Property CurrentExampleLanguage() As ExampleLanguage
			Get
				Return CType(xtraTabControl1.SelectedTabPageIndex, ExampleLanguage)
			End Get
			Set(ByVal value As ExampleLanguage)
				Me.codeEditor.CurrentExampleLanguage = value
				xtraTabControl1.SelectedTabPageIndex = If((value = ExampleLanguage.Csharp), 0, 1)
			End Set
		End Property
		Private Sub ShowExamplesInTreeList(ByVal treeList As TreeList, ByVal examples As List(Of CodeExampleGroup))
'			#Region "InitializeTreeList"
			treeList.OptionsPrint.UsePrintStyles = True
			AddHandler treeList.FocusedNodeChanged, AddressOf OnNewExampleSelected
			treeList.OptionsView.ShowColumns = False
			treeList.OptionsView.ShowIndicator = False


			AddHandler treeList.VirtualTreeGetChildNodes, AddressOf treeList_VirtualTreeGetChildNodes
			AddHandler treeList.VirtualTreeGetCellValue, AddressOf treeList_VirtualTreeGetCellValue
'			#End Region
			Dim col1 As New TreeListColumn()
			col1.VisibleIndex = 0
			col1.OptionsColumn.AllowEdit = False
			col1.OptionsColumn.AllowMove = False
			col1.OptionsColumn.ReadOnly = True
			treeList.Columns.AddRange(New TreeListColumn() { col1 })

			treeList.DataSource = New Object()
			treeList.ExpandAll()
		End Sub

		Private Sub treeList_VirtualTreeGetCellValue(ByVal sender As Object, ByVal args As VirtualTreeGetCellValueInfo)
			Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
			If group IsNot Nothing Then
				args.CellData = group.Name
			End If

			Dim example As CodeExample = TryCast(args.Node, CodeExample)
			If example IsNot Nothing Then
				args.CellData = example.RegionName
			End If
		End Sub

		Private Sub treeList_VirtualTreeGetChildNodes(ByVal sender As Object, ByVal args As VirtualTreeGetChildNodesInfo)
			If treeListRootNodeLoading Then
				args.Children = examples
				treeListRootNodeLoading = False
			Else
				If args.Node Is Nothing Then
					Return
				End If
				Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
				If group IsNot Nothing Then
					args.Children = group.Examples
				End If
			End If
		End Sub
		Private Sub ShowFirstExample()
			treeList1.ExpandAll()
			If treeList1.Nodes.Count > 0 Then
				treeList1.FocusedNode = treeList1.MoveFirst().FirstNode
			End If
		End Sub
		Private Sub OnNewExampleSelected(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
			Dim newExample As CodeExample = TryCast((TryCast(sender, TreeList)).GetDataRecordByNode(e.Node), CodeExample)
			Dim oldExample As CodeExample = TryCast((TryCast(sender, TreeList)).GetDataRecordByNode(e.OldNode), CodeExample)

			If newExample Is Nothing Then
				Return
			End If

			Dim exampleCode As String = codeEditor.ShowExample(oldExample, newExample)
			codeExampleNameLbl.Text = CodeExampleDemoUtils.ConvertStringToMoreHumanReadableForm(newExample.RegionName) & " example"
			Dim args As New CodeEvaluationEventArgs()
			InitializeCodeEvaluationEventArgs(args)
			evaluator.ForceCompile(args)
		End Sub
		Private Sub InitializeCodeEvaluationEventArgs(ByVal e As CodeEvaluationEventArgs)
			e.Result = True
			e.Code = codeEditor.CurrentCodeEditor.Text
			e.Language = CurrentExampleLanguage
			e.EvaluationParameter = richeditcontrol.Document
		End Sub
		Private Sub OnExampleEvaluatorQueryEvaluate(ByVal sender As Object, ByVal e As CodeEvaluationEventArgs)
			e.Result = False
			If codeEditor.RichEditTextChanged Then ' && compileComplete) {
				Dim span As TimeSpan = DateTime.Now - codeEditor.LastExampleCodeModifiedTime

				If span < TimeSpan.FromMilliseconds(1000) Then 'CompileTimeIntervalInMilliseconds 1900
					codeEditor.ResetLastExampleModifiedTime()
					Return
				End If
				'e.Result = true;
				InitializeCodeEvaluationEventArgs(e)
			End If
		End Sub
		#Region "InitializeComponent"
		Private Sub InitializeComponent()
			Me.horizontalSplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
			Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
			Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
			Me.richeditcontrol = New DevExpress.XtraRichEdit.RichEditControl()
			Me.richEditControlCS = New DevExpress.XtraRichEdit.RichEditControl()
			Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
			Me.richEditControlVB = New DevExpress.XtraRichEdit.RichEditControl()
			Me.codeExampleNameLbl = New DevExpress.XtraEditors.LabelControl()
			Me.verticalSplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			CType(Me.horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.horizontalSplitContainerControl1.SuspendLayout()
			CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.xtraTabControl1.SuspendLayout()
			Me.xtraTabPage1.SuspendLayout()
			Me.xtraTabPage2.SuspendLayout()
			CType(Me.verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.verticalSplitContainerControl1.SuspendLayout()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' horizontalSplitContainerControl1
			' 
			Me.horizontalSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.horizontalSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
			Me.horizontalSplitContainerControl1.Horizontal = False
			Me.horizontalSplitContainerControl1.Location = New System.Drawing.Point(0, 0)
			Me.horizontalSplitContainerControl1.Name = "horizontalSplitContainerControl1"
			Me.horizontalSplitContainerControl1.Panel1.Controls.Add(Me.xtraTabControl1)
			Me.horizontalSplitContainerControl1.Panel1.Controls.Add(Me.codeExampleNameLbl)
			Me.horizontalSplitContainerControl1.Panel1.Text = "Panel1"
			Me.horizontalSplitContainerControl1.Panel2.Controls.Add(Me.richeditcontrol)
			Me.horizontalSplitContainerControl1.Panel2.Text = "Panel2"
			Me.horizontalSplitContainerControl1.Size = New System.Drawing.Size(1005, 694)
			Me.horizontalSplitContainerControl1.SplitterPosition = 340
			Me.horizontalSplitContainerControl1.TabIndex = 2
			Me.horizontalSplitContainerControl1.Text = "splitContainerControl1"
			' 
			' xtraTabControl1
			' 
			Me.xtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.Transparent
			Me.xtraTabControl1.AppearancePage.PageClient.BackColor2 = System.Drawing.Color.Transparent
			Me.xtraTabControl1.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Transparent
			Me.xtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = True
			Me.xtraTabControl1.AppearancePage.PageClient.Options.UseBorderColor = True
			Me.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True
			Me.xtraTabControl1.Location = New System.Drawing.Point(0, 44)
			Me.xtraTabControl1.Name = "xtraTabControl1"
			Me.xtraTabControl1.SelectedTabPage = Me.xtraTabPage1
			Me.xtraTabControl1.Size = New System.Drawing.Size(1005, 305)
			Me.xtraTabControl1.TabIndex = 11
			Me.xtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() { Me.xtraTabPage1, Me.xtraTabPage2})
			' 
			' xtraTabPage1
			' 
			Me.xtraTabPage1.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
			Me.xtraTabPage1.Appearance.HeaderActive.Options.UseFont = True
			Me.xtraTabPage1.Controls.Add(Me.richEditControlCS)
			Me.xtraTabPage1.Name = "xtraTabPage1"
			Me.xtraTabPage1.Size = New System.Drawing.Size(999, 277)
			Me.xtraTabPage1.Text = "C#"
			' 
			' richEditControlCS
			' 
			Me.richEditControlCS.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
			Me.richEditControlCS.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richEditControlCS.Location = New System.Drawing.Point(0, 0)
			Me.richEditControlCS.Name = "richEditControlCS"
			Me.richEditControlCS.Options.Fields.UseCurrentCultureDateTimeFormat = False
			Me.richEditControlCS.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
			Me.richEditControlCS.Options.MailMerge.KeepLastParagraph = False
			Me.richEditControlCS.Size = New System.Drawing.Size(999, 277)
			Me.richEditControlCS.TabIndex = 14
			' 
			' xtraTabPage2
			' 
			Me.xtraTabPage2.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
			Me.xtraTabPage2.Appearance.HeaderActive.Options.UseFont = True
			Me.xtraTabPage2.Controls.Add(Me.richEditControlVB)
			Me.xtraTabPage2.Name = "xtraTabPage2"
			Me.xtraTabPage2.Size = New System.Drawing.Size(999, 277)
			Me.xtraTabPage2.Text = "VB"
			' 
			' richEditControlVB
			' 
			Me.richEditControlVB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
			Me.richEditControlVB.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richEditControlVB.Location = New System.Drawing.Point(0, 0)
			Me.richEditControlVB.Name = "richEditControlVB"
			Me.richEditControlVB.Options.Fields.UseCurrentCultureDateTimeFormat = False
			Me.richEditControlVB.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
			Me.richEditControlVB.Options.MailMerge.KeepLastParagraph = False
			Me.richEditControlVB.Size = New System.Drawing.Size(999, 277)
			Me.richEditControlVB.TabIndex = 15
			' 
			' codeExampleNameLbl
			' 
			Me.codeExampleNameLbl.Appearance.Font = New System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.codeExampleNameLbl.Dock = System.Windows.Forms.DockStyle.Top
			Me.codeExampleNameLbl.Location = New System.Drawing.Point(0, 0)
			Me.codeExampleNameLbl.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
			Me.codeExampleNameLbl.Name = "codeExampleNameLbl"
			Me.codeExampleNameLbl.Padding = New System.Windows.Forms.Padding(0, 0, 0, 12)
			Me.codeExampleNameLbl.Size = New System.Drawing.Size(72, 44)
			Me.codeExampleNameLbl.TabIndex = 10
			Me.codeExampleNameLbl.Text = "label1"
			' 
			' richeditcontrol
			' 
			Me.richeditcontrol.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richeditcontrol.Location = New System.Drawing.Point(0, 0)
			Me.richeditcontrol.Name = "richeditcontrol"
			Me.richeditcontrol.Size = New System.Drawing.Size(1005, 340)
			' 
			' verticalSplitContainerControl1
			' 
			Me.verticalSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.verticalSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
			Me.verticalSplitContainerControl1.Location = New System.Drawing.Point(0, 0)
			Me.verticalSplitContainerControl1.Name = "verticalSplitContainerControl1"
			Me.verticalSplitContainerControl1.Panel1.Controls.Add(Me.horizontalSplitContainerControl1)
			Me.verticalSplitContainerControl1.Panel1.Text = "Panel1"
			Me.verticalSplitContainerControl1.Panel2.Controls.Add(Me.treeList1)
			Me.verticalSplitContainerControl1.Panel2.Text = "Panel2"
			Me.verticalSplitContainerControl1.Size = New System.Drawing.Size(1228, 694)
			Me.verticalSplitContainerControl1.SplitterPosition = 218
			Me.verticalSplitContainerControl1.TabIndex = 0
			Me.verticalSplitContainerControl1.Text = "verticalSplitContainerControl1"
			' 
			' treeList1
			' 
			Me.treeList1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline)
			Me.treeList1.Appearance.FocusedCell.Options.UseFont = True
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(218, 694)
			Me.treeList1.TabIndex = 11
			' 
			' RichEditAPIModule
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.verticalSplitContainerControl1)
			Me.Name = "RichEditAPIModule"
			Me.Size = New System.Drawing.Size(1228, 694)
			CType(Me.horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.horizontalSplitContainerControl1.ResumeLayout(False)
			CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.xtraTabControl1.ResumeLayout(False)
			Me.xtraTabPage1.ResumeLayout(False)
			Me.xtraTabPage2.ResumeLayout(False)
			CType(Me.verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.verticalSplitContainerControl1.ResumeLayout(False)
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub xtraTabControl1_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs)
			Dim value As ExampleLanguage = CType(xtraTabControl1.SelectedTabPageIndex, ExampleLanguage)
			If codeEditor IsNot Nothing Then
				Me.codeEditor.CurrentExampleLanguage = value
			End If
		End Sub
		Private Sub ChartAPIModule_Disposed(ByVal sender As Object, ByVal e As EventArgs)
			evaluator.Dispose()
		End Sub
		Private Sub DisableTabs(ByVal examplesCSCount As Integer, ByVal examplesVBCount As Integer)
			If examplesCSCount = 0 Then
				xtraTabControl1.TabPages(CInt(Fix(ExampleLanguage.Csharp))).PageEnabled = False
			End If
			If examplesVBCount = 0 Then
				xtraTabControl1.TabPages(CInt(Fix(ExampleLanguage.VB))).PageEnabled = False
			End If
		End Sub
	End Class
End Namespace
