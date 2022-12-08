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
Imports System.Drawing
Imports DevExpress.Office.Utils

Namespace RichEditAPISample

    Public Partial Class Form1
        Inherits Form

        Private horizontalSplitContainerControl1 As SplitContainerControl

        Private verticalSplitContainerControl1 As SplitContainerControl

#Region "Controls"
        Private treeList1 As TreeList

        Private xtraTabControl1 As XtraTabControl

        Private xtraTabPage1 As XtraTabPage

        Private richEditControlCS As RichEditControl

        Private xtraTabPage2 As XtraTabPage

        Public displayResultControl1 As DisplayResultControl

        Private richEditControlVB As RichEditControl

#End Region
#Region "InitializeComponent"
        Private Sub InitializeComponent()
            horizontalSplitContainerControl1 = New SplitContainerControl()
            checkEdit1 = New CheckEdit()
            xtraTabControl1 = New XtraTabControl()
            xtraTabPage1 = New XtraTabPage()
            richEditControlCS = New RichEditControl()
            xtraTabPage2 = New XtraTabPage()
            richEditControlVB = New RichEditControl()
            xtraTabPage3 = New XtraTabPage()
            richEditControlCSClass = New RichEditControl()
            xtraTabPage4 = New XtraTabPage()
            richEditControlVBClass = New RichEditControl()
            codeExampleNameLbl = New LabelControl()
            displayResultControl1 = New DisplayResultControl()
            verticalSplitContainerControl1 = New SplitContainerControl()
            treeList1 = New TreeList()
            CType(horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            horizontalSplitContainerControl1.SuspendLayout()
            CType(checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            xtraTabControl1.SuspendLayout()
            xtraTabPage1.SuspendLayout()
            xtraTabPage2.SuspendLayout()
            xtraTabPage3.SuspendLayout()
            xtraTabPage4.SuspendLayout()
            CType(verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            verticalSplitContainerControl1.SuspendLayout()
            CType(treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' horizontalSplitContainerControl1
            ' 
            horizontalSplitContainerControl1.Dock = DockStyle.Fill
            horizontalSplitContainerControl1.FixedPanel = SplitFixedPanel.Panel2
            horizontalSplitContainerControl1.Horizontal = False
            horizontalSplitContainerControl1.Location = New System.Drawing.Point(0, 0)
            horizontalSplitContainerControl1.Name = "horizontalSplitContainerControl1"
            horizontalSplitContainerControl1.Panel1.Controls.Add(checkEdit1)
            horizontalSplitContainerControl1.Panel1.Controls.Add(xtraTabControl1)
            horizontalSplitContainerControl1.Panel1.Controls.Add(codeExampleNameLbl)
            horizontalSplitContainerControl1.Panel1.Text = "Panel1"
            horizontalSplitContainerControl1.Panel2.Controls.Add(displayResultControl1)
            horizontalSplitContainerControl1.Panel2.Text = "Panel2"
            horizontalSplitContainerControl1.Size = New System.Drawing.Size(982, 655)
            horizontalSplitContainerControl1.SplitterPosition = 340
            horizontalSplitContainerControl1.TabIndex = 2
            horizontalSplitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' checkEdit1
            ' 
            checkEdit1.Location = New System.Drawing.Point(714, 12)
            checkEdit1.Name = "checkEdit1"
            checkEdit1.Properties.Caption = "Indicate cursor position at window caption"
            checkEdit1.Size = New System.Drawing.Size(237, 19)
            checkEdit1.TabIndex = 12
            AddHandler checkEdit1.CheckedChanged, New EventHandler(AddressOf checkEdit1_CheckedChanged)
            ' 
            ' xtraTabControl1
            ' 
            xtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.Transparent
            xtraTabControl1.AppearancePage.PageClient.BackColor2 = System.Drawing.Color.Transparent
            xtraTabControl1.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Transparent
            xtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = True
            xtraTabControl1.AppearancePage.PageClient.Options.UseBorderColor = True
            xtraTabControl1.Dock = DockStyle.Fill
            xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True
            xtraTabControl1.Location = New System.Drawing.Point(0, 44)
            xtraTabControl1.Name = "xtraTabControl1"
            xtraTabControl1.SelectedTabPage = xtraTabPage1
            xtraTabControl1.Size = New System.Drawing.Size(982, 259)
            xtraTabControl1.TabIndex = 11
            xtraTabControl1.TabPages.AddRange(New XtraTabPage() {xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4})
            ' 
            ' xtraTabPage1
            ' 
            xtraTabPage1.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            xtraTabPage1.Appearance.HeaderActive.Options.UseFont = True
            xtraTabPage1.Controls.Add(richEditControlCS)
            xtraTabPage1.Name = "xtraTabPage1"
            xtraTabPage1.Size = New System.Drawing.Size(980, 234)
            xtraTabPage1.Tag = "CS"
            xtraTabPage1.Text = "CS"
            ' 
            ' richEditControlCS
            ' 
            richEditControlCS.ActiveViewType = RichEditViewType.Draft
            richEditControlCS.Dock = DockStyle.Fill
            richEditControlCS.Location = New System.Drawing.Point(0, 0)
            richEditControlCS.Name = "richEditControlCS"
            richEditControlCS.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden
            richEditControlCS.Size = New System.Drawing.Size(980, 234)
            richEditControlCS.TabIndex = 14
            ' 
            ' xtraTabPage2
            ' 
            xtraTabPage2.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            xtraTabPage2.Appearance.HeaderActive.Options.UseFont = True
            xtraTabPage2.Controls.Add(richEditControlVB)
            xtraTabPage2.Name = "xtraTabPage2"
            xtraTabPage2.Size = New System.Drawing.Size(980, 234)
            xtraTabPage2.Tag = "VB"
            xtraTabPage2.Text = "VB"
            ' 
            ' richEditControlVB
            ' 
            richEditControlVB.ActiveViewType = RichEditViewType.Draft
            richEditControlVB.Dock = DockStyle.Fill
            richEditControlVB.Location = New System.Drawing.Point(0, 0)
            richEditControlVB.Name = "richEditControlVB"
            richEditControlVB.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden
            richEditControlVB.Size = New System.Drawing.Size(980, 234)
            richEditControlVB.TabIndex = 15
            ' 
            ' xtraTabPage3
            ' 
            xtraTabPage3.Controls.Add(richEditControlCSClass)
            xtraTabPage3.Name = "xtraTabPage3"
            xtraTabPage3.Size = New System.Drawing.Size(980, 234)
            xtraTabPage3.Tag = "CS"
            xtraTabPage3.Text = "СS Helper"
            ' 
            ' richEditControlCSClass
            ' 
            richEditControlCSClass.ActiveViewType = RichEditViewType.Draft
            richEditControlCSClass.Dock = DockStyle.Fill
            richEditControlCSClass.Location = New System.Drawing.Point(0, 0)
            richEditControlCSClass.Name = "richEditControlCSClass"
            richEditControlCSClass.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden
            richEditControlCSClass.Size = New System.Drawing.Size(980, 234)
            richEditControlCSClass.TabIndex = 0
            ' 
            ' xtraTabPage4
            ' 
            xtraTabPage4.Controls.Add(richEditControlVBClass)
            xtraTabPage4.Name = "xtraTabPage4"
            xtraTabPage4.Size = New System.Drawing.Size(980, 234)
            xtraTabPage4.Tag = "VB"
            xtraTabPage4.Text = "VB Helper"
            ' 
            ' richEditControlVBClass
            ' 
            richEditControlVBClass.ActiveViewType = RichEditViewType.Draft
            richEditControlVBClass.Dock = DockStyle.Fill
            richEditControlVBClass.Location = New System.Drawing.Point(0, 0)
            richEditControlVBClass.Name = "richEditControlVBClass"
            richEditControlVBClass.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden
            richEditControlVBClass.Size = New System.Drawing.Size(980, 234)
            richEditControlVBClass.TabIndex = 1
            ' 
            ' codeExampleNameLbl
            ' 
            codeExampleNameLbl.Appearance.Font = New System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
            codeExampleNameLbl.Dock = DockStyle.Top
            codeExampleNameLbl.Location = New System.Drawing.Point(0, 0)
            codeExampleNameLbl.Margin = New Padding(3, 5, 3, 5)
            codeExampleNameLbl.Name = "codeExampleNameLbl"
            codeExampleNameLbl.Padding = New Padding(0, 0, 0, 12)
            codeExampleNameLbl.Size = New System.Drawing.Size(72, 44)
            codeExampleNameLbl.TabIndex = 10
            codeExampleNameLbl.Text = "label1"
            ' 
            ' displayResultControl1
            ' 
            displayResultControl1.Dock = DockStyle.Fill
            displayResultControl1.Location = New System.Drawing.Point(0, 0)
            displayResultControl1.Name = "displayResultControl1"
            displayResultControl1.ReviewingPaneFormVisible = True
            displayResultControl1.Size = New System.Drawing.Size(982, 340)
            displayResultControl1.TabIndex = 0
            ' 
            ' verticalSplitContainerControl1
            ' 
            verticalSplitContainerControl1.Dock = DockStyle.Fill
            verticalSplitContainerControl1.FixedPanel = SplitFixedPanel.Panel2
            verticalSplitContainerControl1.Location = New System.Drawing.Point(0, 0)
            verticalSplitContainerControl1.Name = "verticalSplitContainerControl1"
            verticalSplitContainerControl1.Panel1.Controls.Add(horizontalSplitContainerControl1)
            verticalSplitContainerControl1.Panel1.Text = "Panel1"
            verticalSplitContainerControl1.Panel2.Controls.Add(treeList1)
            verticalSplitContainerControl1.Panel2.Text = "Panel2"
            verticalSplitContainerControl1.Size = New System.Drawing.Size(1212, 655)
            verticalSplitContainerControl1.SplitterPosition = 218
            verticalSplitContainerControl1.TabIndex = 0
            verticalSplitContainerControl1.Text = "verticalSplitContainerControl1"
            ' 
            ' treeList1
            ' 
            treeList1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline)
            treeList1.Appearance.FocusedCell.Options.UseFont = True
            treeList1.Dock = DockStyle.Fill
            treeList1.Location = New System.Drawing.Point(0, 0)
            treeList1.Name = "treeList1"
            treeList1.Size = New System.Drawing.Size(218, 655)
            treeList1.TabIndex = 11
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(1212, 655)
            Me.Controls.Add(verticalSplitContainerControl1)
            Name = "Form1"
            CType(horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            horizontalSplitContainerControl1.ResumeLayout(False)
            CType(checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
            xtraTabControl1.ResumeLayout(False)
            xtraTabPage1.ResumeLayout(False)
            xtraTabPage2.ResumeLayout(False)
            xtraTabPage3.ResumeLayout(False)
            xtraTabPage4.ResumeLayout(False)
            CType(verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            verticalSplitContainerControl1.ResumeLayout(False)
            CType(treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private codeExampleNameLbl As LabelControl

        Private codeEditor As ExampleCodeEditor

        Private evaluator As ExampleEvaluatorByTimer

        Private examples As List(Of CodeExampleGroup)

        Private checkEdit1 As CheckEdit

        Private xtraTabPage3 As XtraTabPage

        Private richEditControlCSClass As RichEditControl

        Private xtraTabPage4 As XtraTabPage

        Private richEditControlVBClass As RichEditControl

        Private treeListRootNodeLoading As Boolean = True

        Private richEditControl As RichEditControl

        Public Sub New()
            InitializeComponent()
            InitializeRichEditControl()
            Dim examplePath As String = GetExamplePath("CodeExamples")
            Dim examplesCS As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp)
            Dim examplesVB As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.VB)
            DisableTabs(examplesCS.Count, examplesVB.Count)
            examples = FindExamples(examplePath, examplesCS, examplesVB)
            ShowExamplesInTreeList(treeList1, examples)
            codeEditor = New ExampleCodeEditor(richEditControlCS, richEditControlVB, richEditControlCSClass, richEditControlVBClass)
            CurrentExampleLanguage = DetectExampleLanguage("RichEditAPISample")
            evaluator = New RichEditExampleEvaluatorByTimer()
            AddHandler evaluator.QueryEvaluate, AddressOf OnExampleEvaluatorQueryEvaluate
            AddHandler evaluator.OnBeforeCompile, AddressOf evaluator_OnBeforeCompile
            AddHandler evaluator.OnAfterCompile, AddressOf evaluator_OnAfterCompile
            AddHandler xtraTabControl1.SelectedPageChanged, AddressOf xtraTabControl1_SelectedPageChanged
            ShowFirstExample("Range")
            treeList1.CollapseAll()
        End Sub

        Private Sub InitializeRichEditControl()
            richEditControl = displayResultControl1.RichEdit
        End Sub

        Public Property CurrentExampleLanguage As ExampleLanguage
            Get
                If Equals(xtraTabControl1.SelectedTabPage.Tag.ToString(), "CS") Then
                    Return ExampleLanguage.Csharp
                Else
                    Return ExampleLanguage.VB
                End If
            End Get

            Set(ByVal value As ExampleLanguage)
                codeEditor.CurrentExampleLanguage = value
            'xtraTabControl1.SelectedTabPageIndex = (value == ExampleLanguage.Csharp) ? 0 : 1;
            End Set
        End Property

        Private Sub ShowExamplesInTreeList(ByVal treeList As TreeList, ByVal examples As List(Of CodeExampleGroup))
#Region "InitializeTreeList"
            treeList.OptionsPrint.UsePrintStyles = True
            AddHandler treeList.FocusedNodeChanged, New FocusedNodeChangedEventHandler(AddressOf OnNewExampleSelected)
            treeList.OptionsView.ShowColumns = False
            treeList.OptionsView.ShowIndicator = False
            AddHandler treeList.VirtualTreeGetChildNodes, AddressOf treeList_VirtualTreeGetChildNodes
            AddHandler treeList.VirtualTreeGetCellValue, AddressOf treeList_VirtualTreeGetCellValue
#End Region
            Dim col1 As TreeListColumn = New TreeListColumn()
            col1.VisibleIndex = 0
            col1.OptionsColumn.AllowEdit = False
            col1.OptionsColumn.AllowMove = False
            col1.OptionsColumn.ReadOnly = True
            treeList.Columns.AddRange(New TreeListColumn() {col1})
            treeList.DataSource = New [Object]()
            treeList.ExpandAll()
        End Sub

        Private Sub treeList_VirtualTreeGetCellValue(ByVal sender As Object, ByVal args As VirtualTreeGetCellValueInfo)
            Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
            If group IsNot Nothing Then args.CellData = group.Name
            Dim example As CodeExample = TryCast(args.Node, CodeExample)
            If example IsNot Nothing Then args.CellData = example.RegionName
        End Sub

        Private Sub treeList_VirtualTreeGetChildNodes(ByVal sender As Object, ByVal args As VirtualTreeGetChildNodesInfo)
            If treeListRootNodeLoading Then
                args.Children = examples
                treeListRootNodeLoading = False
            Else
                If args.Node Is Nothing Then Return
                Dim group As CodeExampleGroup = TryCast(args.Node, CodeExampleGroup)
                If group IsNot Nothing Then args.Children = group.Examples
            End If
        End Sub

        Private Sub ShowFirstExample(ByVal firstGroupName As String)
            treeList1.ExpandAll()
            If treeList1.Nodes.Count > 0 Then treeList1.FocusedNode = treeList1.FindNodeByFieldValue("", firstGroupName).NextVisibleNode
        End Sub

        Private Sub evaluator_OnAfterCompile(ByVal sender As Object, ByVal args As OnAfterCompileEventArgs)
            codeEditor.AfterCompile(args.Result)
        End Sub

        Private Sub evaluator_OnBeforeCompile(ByVal sender As Object, ByVal e As EventArgs)
            Dim document As Document = richEditControl.Document
            document.BeginUpdate()
            codeEditor.BeforeCompile()
            richEditControl.CreateNewDocument()
            document.Unit = DevExpress.Office.DocumentUnit.Document
            document.EndUpdate()
        End Sub

        Private Sub OnNewExampleSelected(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
            Dim newExample As CodeExample = TryCast(TryCast(sender, TreeList).GetDataRecordByNode(e.Node), CodeExample)
            Dim oldExample As CodeExample = TryCast(TryCast(sender, TreeList).GetDataRecordByNode(e.OldNode), CodeExample)
            If newExample Is Nothing Then Return
            Dim exampleCode As String = codeEditor.ShowExample(oldExample, newExample)
            codeExampleNameLbl.Text = ConvertStringToMoreHumanReadableForm(newExample.RegionName) & " example"
            Dim args As CodeEvaluationEventArgs = New CodeEvaluationEventArgs()
            InitializeCodeEvaluationEventArgs(args)
            evaluator.ForceCompile(args)
            If Equals(newExample.HumanReadableGroupName, "Comments") Then
                richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Visible
                displayResultControl1.DockPanel.Show()
            Else
                richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Hidden
                displayResultControl1.DockPanel.Hide()
            End If
        End Sub

        Private Sub InitializeCodeEvaluationEventArgs(ByVal e As CodeEvaluationEventArgs)
            e.Result = True
            e.Code = codeEditor.CurrentCodeEditor.Text
            e.CodeClasses = codeEditor.CurrentCodeClassEditor.Text
            e.Language = CurrentExampleLanguage
            e.EvaluationParameter = richEditControl.Document
        End Sub

        Private Sub OnExampleEvaluatorQueryEvaluate(ByVal sender As Object, ByVal e As CodeEvaluationEventArgs)
            e.Result = False
            If codeEditor.RichEditTextChanged Then ' && compileComplete) {
                Dim span As TimeSpan = Date.Now - codeEditor.LastExampleCodeModifiedTime
                If span < TimeSpan.FromMilliseconds(1000) Then 'CompileTimeIntervalInMilliseconds  1900
                    codeEditor.ResetLastExampleModifiedTime()
                    Return
                End If

                'e.Result = true;
                InitializeCodeEvaluationEventArgs(e)
            End If
        End Sub

        Private Sub DisableTabs(ByVal examplesCSCount As Integer, ByVal examplesVBCount As Integer)
            If examplesCSCount = 0 Then
                For Each t As XtraTabPage In xtraTabControl1.TabPages
                    If Equals(t.Tag.ToString(), "CS") Then t.PageEnabled = False
                Next
            End If

            If examplesVBCount = 0 Then
                For Each t As XtraTabPage In xtraTabControl1.TabPages
                    If Equals(t.Tag.ToString(), "VB") Then t.PageEnabled = False
                Next
            End If
        End Sub

        Private Sub checkEdit1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If checkEdit1.Checked Then
                AddHandler richEditControl.MouseMove, AddressOf richEditControl_MouseMove
            Else
                RemoveHandler richEditControl.MouseMove, AddressOf richEditControl_MouseMove
            End If
        End Sub

        Private Sub xtraTabControl1_SelectedPageChanged(ByVal sender As Object, ByVal e As TabPageChangedEventArgs)
            CurrentExampleLanguage = If((Equals(e.Page.Tag.ToString(), "CS")), ExampleLanguage.Csharp, ExampleLanguage.VB)
        End Sub

#Region "#getpositionfrrompoint"
        Private Sub richEditControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim docPoint As Point = Units.PixelsToDocuments(e.Location, richEditControl.DpiX, richEditControl.DpiY)
            Dim pos As DocumentPosition = richEditControl.GetPositionFromPoint(docPoint)
            If pos IsNot Nothing Then
                Text = String.Format("Mouse is over position {0}", pos)
            Else
                Text = ""
            End If
        End Sub
#End Region  ' #getpositionfrrompoint
    End Class
End Namespace
