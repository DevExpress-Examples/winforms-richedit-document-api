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

    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

#Region "Controls"
        Private treeList1 As TreeList

        Private xtraTabControl1 As XtraTabControl

        Private xtraTabPage1 As XtraTabPage

        Private richEditControlCS As RichEditControl

        Private xtraTabPage2 As XtraTabPage

        Public displayResultControl1 As DisplayResultControl
        Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
        Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents codeExampleNameLbl As DevExpress.XtraLayout.SimpleLabelItem
        Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
        Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
        Private richEditControlVB As RichEditControl

#End Region
#Region "InitializeComponent"
        Private Sub InitializeComponent()
            Me.checkEdit1 = New DevExpress.XtraEditors.CheckEdit()
            Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
            Me.displayResultControl1 = New RichEditAPISample.DisplayResultControl()
            Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
            Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlCS = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlVB = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlCSClass = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlVBClass = New DevExpress.XtraRichEdit.RichEditControl()
            Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.codeExampleNameLbl = New DevExpress.XtraLayout.SimpleLabelItem()
            Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
            Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
            CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.LayoutControl1.SuspendLayout()
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.xtraTabControl1.SuspendLayout()
            Me.xtraTabPage1.SuspendLayout()
            Me.xtraTabPage2.SuspendLayout()
            Me.xtraTabPage3.SuspendLayout()
            Me.xtraTabPage4.SuspendLayout()
            CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.codeExampleNameLbl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'checkEdit1
            '
            Me.checkEdit1.AutoSizeInLayoutControl = True
            Me.checkEdit1.Location = New System.Drawing.Point(636, 18)
            Me.checkEdit1.Name = "checkEdit1"
            Me.checkEdit1.Properties.Caption = "Indicate cursor position at window caption"
            Me.checkEdit1.Size = New System.Drawing.Size(225, 20)
            Me.checkEdit1.StyleController = Me.LayoutControl1
            Me.checkEdit1.TabIndex = 12
            '
            'LayoutControl1
            '
            Me.LayoutControl1.Controls.Add(Me.treeList1)
            Me.LayoutControl1.Controls.Add(Me.displayResultControl1)
            Me.LayoutControl1.Controls.Add(Me.xtraTabControl1)
            Me.LayoutControl1.Controls.Add(Me.checkEdit1)
            Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControl1.Name = "LayoutControl1"
            Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(729, 364, 650, 400)
            Me.LayoutControl1.Root = Me.Root
            Me.LayoutControl1.Size = New System.Drawing.Size(1212, 655)
            Me.LayoutControl1.TabIndex = 1
            Me.LayoutControl1.Text = "LayoutControl1"
            '
            'treeList1
            '
            Me.treeList1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
            Me.treeList1.Appearance.FocusedCell.Options.UseFont = True
            Me.treeList1.Location = New System.Drawing.Point(875, 12)
            Me.treeList1.Name = "treeList1"
            Me.treeList1.Size = New System.Drawing.Size(325, 631)
            Me.treeList1.TabIndex = 11
            '
            'displayResultControl1
            '
            Me.displayResultControl1.Location = New System.Drawing.Point(12, 299)
            Me.displayResultControl1.Name = "displayResultControl1"
            Me.displayResultControl1.ReviewingPaneFormVisible = False
            Me.displayResultControl1.Size = New System.Drawing.Size(849, 344)
            Me.displayResultControl1.TabIndex = 0
            '
            'xtraTabControl1
            '
            Me.xtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.Transparent
            Me.xtraTabControl1.AppearancePage.PageClient.BackColor2 = System.Drawing.Color.Transparent
            Me.xtraTabControl1.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Transparent
            Me.xtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = True
            Me.xtraTabControl1.AppearancePage.PageClient.Options.UseBorderColor = True
            Me.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
            Me.xtraTabControl1.Location = New System.Drawing.Point(12, 48)
            Me.xtraTabControl1.Name = "xtraTabControl1"
            Me.xtraTabControl1.SelectedTabPage = Me.xtraTabPage1
            Me.xtraTabControl1.Size = New System.Drawing.Size(849, 237)
            Me.xtraTabControl1.TabIndex = 11
            Me.xtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtraTabPage1, Me.xtraTabPage2, Me.xtraTabPage3, Me.xtraTabPage4})
            '
            'xtraTabPage1
            '
            Me.xtraTabPage1.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.xtraTabPage1.Appearance.HeaderActive.Options.UseFont = True
            Me.xtraTabPage1.Controls.Add(Me.richEditControlCS)
            Me.xtraTabPage1.Name = "xtraTabPage1"
            Me.xtraTabPage1.Size = New System.Drawing.Size(847, 212)
            Me.xtraTabPage1.Tag = "CS"
            Me.xtraTabPage1.Text = "CS"
            '
            'richEditControlCS
            '
            Me.richEditControlCS.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlCS.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlCS.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
            Me.richEditControlCS.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlCS.Name = "richEditControlCS"
            Me.richEditControlCS.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlCS.Size = New System.Drawing.Size(847, 212)
            Me.richEditControlCS.TabIndex = 14
            '
            'xtraTabPage2
            '
            Me.xtraTabPage2.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.xtraTabPage2.Appearance.HeaderActive.Options.UseFont = True
            Me.xtraTabPage2.Controls.Add(Me.richEditControlVB)
            Me.xtraTabPage2.Name = "xtraTabPage2"
            Me.xtraTabPage2.Size = New System.Drawing.Size(847, 212)
            Me.xtraTabPage2.Tag = "VB"
            Me.xtraTabPage2.Text = "VB"
            '
            'richEditControlVB
            '
            Me.richEditControlVB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlVB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlVB.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
            Me.richEditControlVB.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlVB.Name = "richEditControlVB"
            Me.richEditControlVB.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlVB.Size = New System.Drawing.Size(847, 212)
            Me.richEditControlVB.TabIndex = 15
            '
            'xtraTabPage3
            '
            Me.xtraTabPage3.Controls.Add(Me.richEditControlCSClass)
            Me.xtraTabPage3.Name = "xtraTabPage3"
            Me.xtraTabPage3.Size = New System.Drawing.Size(847, 212)
            Me.xtraTabPage3.Tag = "CS"
            Me.xtraTabPage3.Text = "СS Helper"
            '
            'richEditControlCSClass
            '
            Me.richEditControlCSClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlCSClass.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlCSClass.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
            Me.richEditControlCSClass.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlCSClass.Name = "richEditControlCSClass"
            Me.richEditControlCSClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlCSClass.Size = New System.Drawing.Size(847, 212)
            Me.richEditControlCSClass.TabIndex = 0
            '
            'xtraTabPage4
            '
            Me.xtraTabPage4.Controls.Add(Me.richEditControlVBClass)
            Me.xtraTabPage4.Name = "xtraTabPage4"
            Me.xtraTabPage4.Size = New System.Drawing.Size(847, 212)
            Me.xtraTabPage4.Tag = "VB"
            Me.xtraTabPage4.Text = "VB Helper"
            '
            'richEditControlVBClass
            '
            Me.richEditControlVBClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlVBClass.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlVBClass.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel
            Me.richEditControlVBClass.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlVBClass.Name = "richEditControlVBClass"
            Me.richEditControlVBClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlVBClass.Size = New System.Drawing.Size(847, 212)
            Me.richEditControlVBClass.TabIndex = 1
            '
            'Root
            '
            Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.Root.GroupBordersVisible = False
            Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlGroup1, Me.SplitterItem1})
            Me.Root.Name = "Root"
            Me.Root.Size = New System.Drawing.Size(1212, 655)
            Me.Root.TextVisible = False
            '
            'LayoutControlItem5
            '
            Me.LayoutControlItem5.Control = Me.treeList1
            Me.LayoutControlItem5.Location = New System.Drawing.Point(863, 0)
            Me.LayoutControlItem5.Name = "LayoutControlItem5"
            Me.LayoutControlItem5.Size = New System.Drawing.Size(329, 635)
            Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem5.TextVisible = False
            '
            'LayoutControlGroup1
            '
            Me.LayoutControlGroup1.GroupBordersVisible = False
            Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.codeExampleNameLbl, Me.SplitterItem2})
            Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
            Me.LayoutControlGroup1.Size = New System.Drawing.Size(853, 635)
            '
            'LayoutControlItem2
            '
            Me.LayoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center
            Me.LayoutControlItem2.Control = Me.checkEdit1
            Me.LayoutControlItem2.Location = New System.Drawing.Point(624, 0)
            Me.LayoutControlItem2.Name = "LayoutControlItem2"
            Me.LayoutControlItem2.Size = New System.Drawing.Size(229, 36)
            Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem2.TextVisible = False
            '
            'LayoutControlItem3
            '
            Me.LayoutControlItem3.Control = Me.xtraTabControl1
            Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 36)
            Me.LayoutControlItem3.Name = "LayoutControlItem3"
            Me.LayoutControlItem3.Size = New System.Drawing.Size(853, 241)
            Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem3.TextVisible = False
            '
            'LayoutControlItem4
            '
            Me.LayoutControlItem4.Control = Me.displayResultControl1
            Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 287)
            Me.LayoutControlItem4.Name = "LayoutControlItem4"
            Me.LayoutControlItem4.Size = New System.Drawing.Size(853, 348)
            Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
            Me.LayoutControlItem4.TextVisible = False
            '
            'codeExampleNameLbl
            '
            Me.codeExampleNameLbl.AllowHotTrack = False
            Me.codeExampleNameLbl.AppearanceItemCaption.Font = New System.Drawing.Font("Arial", 20.25!)
            Me.codeExampleNameLbl.AppearanceItemCaption.Options.UseFont = True
            Me.codeExampleNameLbl.Location = New System.Drawing.Point(0, 0)
            Me.codeExampleNameLbl.MinSize = New System.Drawing.Size(100, 36)
            Me.codeExampleNameLbl.Name = "codeExampleNameLbl"
            Me.codeExampleNameLbl.Size = New System.Drawing.Size(624, 36)
            Me.codeExampleNameLbl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            Me.codeExampleNameLbl.TextSize = New System.Drawing.Size(335, 32)
            '
            'SplitterItem2
            '
            Me.SplitterItem2.AllowHotTrack = True
            Me.SplitterItem2.Location = New System.Drawing.Point(0, 277)
            Me.SplitterItem2.Name = "SplitterItem2"
            Me.SplitterItem2.Size = New System.Drawing.Size(853, 10)
            '
            'SplitterItem1
            '
            Me.SplitterItem1.AllowHotTrack = True
            Me.SplitterItem1.Location = New System.Drawing.Point(853, 0)
            Me.SplitterItem1.Name = "SplitterItem1"
            Me.SplitterItem1.Size = New System.Drawing.Size(10, 635)
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1212, 655)
            Me.Controls.Add(Me.LayoutControl1)
            Me.Name = "Form1"
            CType(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.LayoutControl1.ResumeLayout(False)
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.xtraTabControl1.ResumeLayout(False)
            Me.xtraTabPage1.ResumeLayout(False)
            Me.xtraTabPage2.ResumeLayout(False)
            Me.xtraTabPage3.ResumeLayout(False)
            Me.xtraTabPage4.ResumeLayout(False)
            CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.codeExampleNameLbl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private codeEditor As ExampleCodeEditor

        Private evaluator As ExampleEvaluatorByTimer

        Private examples As List(Of CodeExampleGroup)

        Private WithEvents checkEdit1 As CheckEdit

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

        Private Sub checkEdit1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkEdit1.CheckedChanged
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
