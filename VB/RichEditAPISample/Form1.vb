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
        Inherits Form

        Private horizontalSplitContainerControl1 As SplitContainerControl
        Private verticalSplitContainerControl1 As SplitContainerControl

        #Region "Controls"
        Private treeList1 As TreeList
        Private xtraTabControl1 As XtraTabControl
        Private xtraTabPage1 As XtraTabPage
        Private richEditControlCS As RichEditControl
        Private xtraTabPage2 As XtraTabPage
        Private displayResultControl1 As DisplayResultControl
        Private richEditControlVB As RichEditControl
        #End Region

        #Region "InitializeComponent"
        Private Sub InitializeComponent()
            Me.horizontalSplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.checkEdit1 = New DevExpress.XtraEditors.CheckEdit()
            Me.xtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
            Me.xtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlCS = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlVB = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlCSClass = New DevExpress.XtraRichEdit.RichEditControl()
            Me.xtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
            Me.richEditControlVBClass = New DevExpress.XtraRichEdit.RichEditControl()
            Me.codeExampleNameLbl = New DevExpress.XtraEditors.LabelControl()
            Me.displayResultControl1 = New RichEditAPISample.DisplayResultControl()
            Me.verticalSplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
            DirectCast(Me.horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.horizontalSplitContainerControl1.SuspendLayout()
            DirectCast(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.xtraTabControl1.SuspendLayout()
            Me.xtraTabPage1.SuspendLayout()
            Me.xtraTabPage2.SuspendLayout()
            Me.xtraTabPage3.SuspendLayout()
            Me.xtraTabPage4.SuspendLayout()
            DirectCast(Me.verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.verticalSplitContainerControl1.SuspendLayout()
            DirectCast(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' horizontalSplitContainerControl1
            ' 
            Me.horizontalSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.horizontalSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
            Me.horizontalSplitContainerControl1.Horizontal = False
            Me.horizontalSplitContainerControl1.Location = New System.Drawing.Point(0, 0)
            Me.horizontalSplitContainerControl1.Name = "horizontalSplitContainerControl1"
            Me.horizontalSplitContainerControl1.Panel1.Controls.Add(Me.checkEdit1)
            Me.horizontalSplitContainerControl1.Panel1.Controls.Add(Me.xtraTabControl1)
            Me.horizontalSplitContainerControl1.Panel1.Controls.Add(Me.codeExampleNameLbl)
            Me.horizontalSplitContainerControl1.Panel1.Text = "Panel1"
            Me.horizontalSplitContainerControl1.Panel2.Controls.Add(Me.displayResultControl1)
            Me.horizontalSplitContainerControl1.Panel2.Text = "Panel2"
            Me.horizontalSplitContainerControl1.Size = New System.Drawing.Size(989, 655)
            Me.horizontalSplitContainerControl1.SplitterPosition = 340
            Me.horizontalSplitContainerControl1.TabIndex = 2
            Me.horizontalSplitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' checkEdit1
            ' 
            Me.checkEdit1.Location = New System.Drawing.Point(714, 12)
            Me.checkEdit1.Name = "checkEdit1"
            Me.checkEdit1.Properties.Caption = "Indicate cursor position at window caption"
            Me.checkEdit1.Size = New System.Drawing.Size(237, 19)
            Me.checkEdit1.TabIndex = 12
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
            Me.xtraTabControl1.Size = New System.Drawing.Size(989, 266)
            Me.xtraTabControl1.TabIndex = 11
            Me.xtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() { Me.xtraTabPage1, Me.xtraTabPage2, Me.xtraTabPage3, Me.xtraTabPage4})
            ' 
            ' xtraTabPage1
            ' 
            Me.xtraTabPage1.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            Me.xtraTabPage1.Appearance.HeaderActive.Options.UseFont = True
            Me.xtraTabPage1.Controls.Add(Me.richEditControlCS)
            Me.xtraTabPage1.Name = "xtraTabPage1"
            Me.xtraTabPage1.Size = New System.Drawing.Size(983, 238)
            Me.xtraTabPage1.Tag = "CS"
            Me.xtraTabPage1.Text = "CS"
            ' 
            ' richEditControlCS
            ' 
            Me.richEditControlCS.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlCS.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlCS.EnableToolTips = True
            Me.richEditControlCS.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlCS.Name = "richEditControlCS"
            Me.richEditControlCS.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never
            Me.richEditControlCS.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlCS.Size = New System.Drawing.Size(983, 238)
            Me.richEditControlCS.TabIndex = 14
            ' 
            ' xtraTabPage2
            ' 
            Me.xtraTabPage2.Appearance.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold)
            Me.xtraTabPage2.Appearance.HeaderActive.Options.UseFont = True
            Me.xtraTabPage2.Controls.Add(Me.richEditControlVB)
            Me.xtraTabPage2.Name = "xtraTabPage2"
            Me.xtraTabPage2.Size = New System.Drawing.Size(983, 238)
            Me.xtraTabPage2.Tag = "VB"
            Me.xtraTabPage2.Text = "VB"
            ' 
            ' richEditControlVB
            ' 
            Me.richEditControlVB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlVB.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlVB.EnableToolTips = True
            Me.richEditControlVB.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlVB.Name = "richEditControlVB"
            Me.richEditControlVB.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never
            Me.richEditControlVB.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlVB.Size = New System.Drawing.Size(983, 238)
            Me.richEditControlVB.TabIndex = 15
            ' 
            ' xtraTabPage3
            ' 
            Me.xtraTabPage3.Controls.Add(Me.richEditControlCSClass)
            Me.xtraTabPage3.Name = "xtraTabPage3"
            Me.xtraTabPage3.Size = New System.Drawing.Size(983, 238)
            Me.xtraTabPage3.Tag = "CS"
            Me.xtraTabPage3.Text = "СS Helper"
            ' 
            ' richEditControlCSClass
            ' 
            Me.richEditControlCSClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlCSClass.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlCSClass.EnableToolTips = True
            Me.richEditControlCSClass.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlCSClass.Name = "richEditControlCSClass"
            Me.richEditControlCSClass.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never
            Me.richEditControlCSClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlCSClass.Size = New System.Drawing.Size(983, 238)
            Me.richEditControlCSClass.TabIndex = 0
            ' 
            ' xtraTabPage4
            ' 
            Me.xtraTabPage4.Controls.Add(Me.richEditControlVBClass)
            Me.xtraTabPage4.Name = "xtraTabPage4"
            Me.xtraTabPage4.Size = New System.Drawing.Size(983, 238)
            Me.xtraTabPage4.Tag = "VB"
            Me.xtraTabPage4.Text = "VB Helper"
            ' 
            ' richEditControlVBClass
            ' 
            Me.richEditControlVBClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
            Me.richEditControlVBClass.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControlVBClass.EnableToolTips = True
            Me.richEditControlVBClass.Location = New System.Drawing.Point(0, 0)
            Me.richEditControlVBClass.Name = "richEditControlVBClass"
            Me.richEditControlVBClass.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never
            Me.richEditControlVBClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
            Me.richEditControlVBClass.Size = New System.Drawing.Size(983, 238)
            Me.richEditControlVBClass.TabIndex = 1
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
            ' displayResultControl1
            ' 
            Me.displayResultControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.displayResultControl1.Location = New System.Drawing.Point(0, 0)
            Me.displayResultControl1.Name = "displayResultControl1"
            Me.displayResultControl1.ReviewingPaneFormVisible = False
            Me.displayResultControl1.Size = New System.Drawing.Size(989, 340)
            Me.displayResultControl1.TabIndex = 0
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
            Me.verticalSplitContainerControl1.Size = New System.Drawing.Size(1212, 655)
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
            Me.treeList1.Size = New System.Drawing.Size(218, 655)
            Me.treeList1.TabIndex = 11
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1212, 655)
            Me.Controls.Add(Me.verticalSplitContainerControl1)
            Me.Name = "Form1"
            DirectCast(Me.horizontalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.horizontalSplitContainerControl1.ResumeLayout(False)
            DirectCast(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.xtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.xtraTabControl1.ResumeLayout(False)
            Me.xtraTabPage1.ResumeLayout(False)
            Me.xtraTabPage2.ResumeLayout(False)
            Me.xtraTabPage3.ResumeLayout(False)
            Me.xtraTabPage4.ResumeLayout(False)
            DirectCast(Me.verticalSplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.verticalSplitContainerControl1.ResumeLayout(False)
            DirectCast(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        #End Region

        Private codeExampleNameLbl As LabelControl
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

            Dim examplePath As String = CodeExampleDemoUtils.GetExamplePath("CodeExamples")

            Dim examplesCS As Dictionary(Of String, FileInfo) = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp)
            Dim examplesVB As Dictionary(Of String, FileInfo) = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.VB)
            DisableTabs(examplesCS.Count, examplesVB.Count)
            Me.examples = CodeExampleDemoUtils.FindExamples(examplePath, examplesCS, examplesVB)
            ShowExamplesInTreeList(treeList1, examples)

            Me.codeEditor = New ExampleCodeEditor(richEditControlCS, richEditControlVB, richEditControlCSClass, richEditControlVBClass)
            CurrentExampleLanguage = CodeExampleDemoUtils.DetectExampleLanguage("RichEditAPISample")
            Me.evaluator = New RichEditExampleEvaluatorByTimer()

            AddHandler Me.evaluator.QueryEvaluate, AddressOf OnExampleEvaluatorQueryEvaluate
            AddHandler Me.evaluator.OnBeforeCompile, AddressOf evaluator_OnBeforeCompile
            AddHandler Me.evaluator.OnAfterCompile, AddressOf evaluator_OnAfterCompile
            AddHandler Me.xtraTabControl1.SelectedPageChanged, AddressOf xtraTabControl1_SelectedPageChanged

            ShowFirstExample("Range")
            treeList1.CollapseAll()
        End Sub

        Private Sub InitializeRichEditControl()
            Me.richEditControl = Me.displayResultControl1.RichEdit
        End Sub

        Public Property CurrentExampleLanguage() As ExampleLanguage
            Get
                If xtraTabControl1.SelectedTabPage.Tag.ToString() = "CS" Then
                    Return ExampleLanguage.Csharp
                Else
                    Return ExampleLanguage.VB
                End If
            End Get
            Set(ByVal value As ExampleLanguage)
                Me.codeEditor.CurrentExampleLanguage = value
                'xtraTabControl1.SelectedTabPageIndex = (value == ExampleLanguage.Csharp) ? 0 : 1;
            End Set
        End Property

        Private Sub ShowExamplesInTreeList(ByVal treeList As TreeList, ByVal examples As List(Of CodeExampleGroup))
'            #Region "InitializeTreeList"
            treeList.OptionsPrint.UsePrintStyles = True
            AddHandler treeList.FocusedNodeChanged, AddressOf OnNewExampleSelected
            treeList.OptionsView.ShowColumns = False
            treeList.OptionsView.ShowIndicator = False
            AddHandler treeList.VirtualTreeGetChildNodes, AddressOf treeList_VirtualTreeGetChildNodes
            AddHandler treeList.VirtualTreeGetCellValue, AddressOf treeList_VirtualTreeGetCellValue
'            #End Region
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

        Private Sub ShowFirstExample(ByVal firstGroupName As String)
            treeList1.ExpandAll()
            If treeList1.Nodes.Count > 0 Then
                treeList1.FocusedNode = treeList1.FindNodeByFieldValue("", firstGroupName).NextVisibleNode
            End If
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

            If newExample.HumanReadableGroupName = "Comments" Then
                Me.richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Visible
                Me.displayResultControl1.DockPanel.Show()
            Else
                Me.richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Hidden
                Me.displayResultControl1.DockPanel.Hide()
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
            If codeEditor.RichEditTextChanged Then
                Dim span As TimeSpan = Date.Now.Subtract(codeEditor.LastExampleCodeModifiedTime)

                If span < TimeSpan.FromMilliseconds(1000) Then
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
                    If t.Tag.ToString() = "CS" Then
                        t.PageEnabled = False
                    End If
                Next t
            End If
            If examplesVBCount = 0 Then
                For Each t As XtraTabPage In xtraTabControl1.TabPages
                    If t.Tag.ToString() = "VB" Then
                        t.PageEnabled = False
                    End If
                Next t
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
            CurrentExampleLanguage = If(e.Page.Tag.ToString() = "CS", ExampleLanguage.Csharp, ExampleLanguage.VB)

        End Sub

        #Region "#getpositionfrrompoint"
        Private Sub richEditControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim docPoint As Point = Units.PixelsToDocuments(e.Location, richEditControl.DpiX, richEditControl.DpiY)
            Dim pos As DocumentPosition = richEditControl.GetPositionFromPoint(docPoint)
            If pos IsNot Nothing Then
                Me.Text = System.String.Format("Mouse is over position {0}", pos)
            Else
                Me.Text = ""
            End If
        End Sub
        #End Region ' #getpositionfrrompoint

    End Class
End Namespace
