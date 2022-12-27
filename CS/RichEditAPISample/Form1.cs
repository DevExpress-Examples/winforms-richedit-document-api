using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.API.Native;
using System.Drawing;
using DevExpress.Office.Utils;

namespace RichEditAPISample
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        #region Controls
        private TreeList treeList1;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private RichEditControl richEditControlCS;
        private XtraTabPage xtraTabPage2;
        public DisplayResultControl displayResultControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleLabelItem codeExampleNameLbl;
        private RichEditControl richEditControlVB;
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.displayResultControl1 = new RichEditAPISample.DisplayResultControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.richEditControlCS = new DevExpress.XtraRichEdit.RichEditControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.richEditControlVB = new DevExpress.XtraRichEdit.RichEditControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.richEditControlCSClass = new DevExpress.XtraRichEdit.RichEditControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.richEditControlVBClass = new DevExpress.XtraRichEdit.RichEditControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.codeExampleNameLbl = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeExampleNameLbl)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.AutoSizeInLayoutControl = true;
            this.checkEdit1.Location = new System.Drawing.Point(596, 18);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Indicate cursor position at window caption";
            this.checkEdit1.Size = new System.Drawing.Size(225, 20);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 12;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Controls.Add(this.displayResultControl1);
            this.layoutControl1.Controls.Add(this.xtraTabControl1);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(742, 351, 650, 403);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1248, 668);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Location = new System.Drawing.Point(835, 12);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(401, 644);
            this.treeList1.TabIndex = 11;
            // 
            // displayResultControl1
            // 
            this.displayResultControl1.Location = new System.Drawing.Point(12, 317);
            this.displayResultControl1.Name = "displayResultControl1";
            this.displayResultControl1.ReviewingPaneFormVisible = false;
            this.displayResultControl1.Size = new System.Drawing.Size(809, 339);
            this.displayResultControl1.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.PageClient.BackColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.AppearancePage.PageClient.BackColor2 = System.Drawing.Color.Transparent;
            this.xtraTabControl1.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseBackColor = true;
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 48);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(809, 255);
            this.xtraTabControl1.TabIndex = 11;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage1.Appearance.HeaderActive.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.richEditControlCS);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(807, 230);
            this.xtraTabPage1.Tag = "CS";
            this.xtraTabPage1.Text = "CS";
            // 
            // richEditControlCS
            // 
            this.richEditControlCS.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditControlCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControlCS.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControlCS.Location = new System.Drawing.Point(0, 0);
            this.richEditControlCS.Name = "richEditControlCS";
            this.richEditControlCS.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlCS.Size = new System.Drawing.Size(807, 230);
            this.richEditControlCS.TabIndex = 14;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseFont = true;
            this.xtraTabPage2.Controls.Add(this.richEditControlVB);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(778, 181);
            this.xtraTabPage2.Tag = "VB";
            this.xtraTabPage2.Text = "VB";
            // 
            // richEditControlVB
            // 
            this.richEditControlVB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditControlVB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControlVB.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControlVB.Location = new System.Drawing.Point(0, 0);
            this.richEditControlVB.Name = "richEditControlVB";
            this.richEditControlVB.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlVB.Size = new System.Drawing.Size(778, 181);
            this.richEditControlVB.TabIndex = 15;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.richEditControlCSClass);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(778, 181);
            this.xtraTabPage3.Tag = "CS";
            this.xtraTabPage3.Text = "СS Helper";
            // 
            // richEditControlCSClass
            // 
            this.richEditControlCSClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditControlCSClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControlCSClass.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControlCSClass.Location = new System.Drawing.Point(0, 0);
            this.richEditControlCSClass.Name = "richEditControlCSClass";
            this.richEditControlCSClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlCSClass.Size = new System.Drawing.Size(778, 181);
            this.richEditControlCSClass.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.richEditControlVBClass);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(778, 181);
            this.xtraTabPage4.Tag = "VB";
            this.xtraTabPage4.Text = "VB Helper";
            // 
            // richEditControlVBClass
            // 
            this.richEditControlVBClass.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditControlVBClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControlVBClass.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControlVBClass.Location = new System.Drawing.Point(0, 0);
            this.richEditControlVBClass.Name = "richEditControlVBClass";
            this.richEditControlVBClass.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControlVBClass.Size = new System.Drawing.Size(778, 181);
            this.richEditControlVBClass.TabIndex = 1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.splitterItem1,
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1248, 668);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.treeList1;
            this.layoutControlItem5.Location = new System.Drawing.Point(823, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(405, 648);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(813, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(10, 648);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.splitterItem2,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.codeExampleNameLbl});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(813, 648);
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(0, 295);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(813, 10);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.displayResultControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 305);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(813, 343);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem2.Control = this.checkEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(584, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(229, 36);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.xtraTabControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(813, 259);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // codeExampleNameLbl
            // 
            this.codeExampleNameLbl.AllowHotTrack = false;
            this.codeExampleNameLbl.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 20.25F);
            this.codeExampleNameLbl.AppearanceItemCaption.Options.UseFont = true;
            this.codeExampleNameLbl.Location = new System.Drawing.Point(0, 0);
            this.codeExampleNameLbl.MinSize = new System.Drawing.Size(100, 36);
            this.codeExampleNameLbl.Name = "codeExampleNameLbl";
            this.codeExampleNameLbl.Size = new System.Drawing.Size(584, 36);
            this.codeExampleNameLbl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.codeExampleNameLbl.TextSize = new System.Drawing.Size(335, 32);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 668);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeExampleNameLbl)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        ExampleCodeEditor codeEditor;
        ExampleEvaluatorByTimer evaluator;
        List<CodeExampleGroup> examples;
        private CheckEdit checkEdit1;
        private XtraTabPage xtraTabPage3;
        private RichEditControl richEditControlCSClass;
        private XtraTabPage xtraTabPage4;
        private RichEditControl richEditControlVBClass;
        bool treeListRootNodeLoading = true;
        private RichEditControl richEditControl;

        public Form1()
        {
            InitializeComponent();
            InitializeRichEditControl();

            string examplePath = CodeExampleDemoUtils.GetExamplePath("CodeExamples");

            Dictionary<string, FileInfo> examplesCS = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp);
            Dictionary<string, FileInfo> examplesVB = CodeExampleDemoUtils.GatherExamplesFromProject(examplePath, ExampleLanguage.VB);
            DisableTabs(examplesCS.Count, examplesVB.Count);
            this.examples = CodeExampleDemoUtils.FindExamples(examplePath, examplesCS, examplesVB);
            ShowExamplesInTreeList(treeList1, examples);

            this.codeEditor = new ExampleCodeEditor(richEditControlCS, richEditControlVB, richEditControlCSClass, richEditControlVBClass);
            CurrentExampleLanguage = CodeExampleDemoUtils.DetectExampleLanguage("RichEditAPISample");
            this.evaluator = new RichEditExampleEvaluatorByTimer();

            this.evaluator.QueryEvaluate += OnExampleEvaluatorQueryEvaluate;
            this.evaluator.OnBeforeCompile += evaluator_OnBeforeCompile;
            this.evaluator.OnAfterCompile += evaluator_OnAfterCompile;
            this.xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;

            ShowFirstExample("Range");
            treeList1.CollapseAll();
        }

        private void InitializeRichEditControl()
        {
            this.richEditControl = this.displayResultControl1.RichEdit;
        }

        public ExampleLanguage CurrentExampleLanguage
        {
            get
            {
                if (xtraTabControl1.SelectedTabPage.Tag.ToString() == "CS") return ExampleLanguage.Csharp;
                else return ExampleLanguage.VB;
            }
            set
            {
                this.codeEditor.CurrentExampleLanguage = value;
                //xtraTabControl1.SelectedTabPageIndex = (value == ExampleLanguage.Csharp) ? 0 : 1;
            }
        }

        void ShowExamplesInTreeList(TreeList treeList, List<CodeExampleGroup> examples)
        {
            #region InitializeTreeList
            treeList.OptionsPrint.UsePrintStyles = true;
            treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.OnNewExampleSelected);
            treeList.OptionsView.ShowColumns = false;
            treeList.OptionsView.ShowIndicator = false;
            treeList.VirtualTreeGetChildNodes += treeList_VirtualTreeGetChildNodes;
            treeList.VirtualTreeGetCellValue += treeList_VirtualTreeGetCellValue;
            #endregion
            TreeListColumn col1 = new TreeListColumn();
            col1.VisibleIndex = 0;
            col1.OptionsColumn.AllowEdit = false;
            col1.OptionsColumn.AllowMove = false;
            col1.OptionsColumn.ReadOnly = true;
            treeList.Columns.AddRange(new TreeListColumn[] { col1 });

            treeList.DataSource = new Object();
            treeList.ExpandAll();
        }

        void treeList_VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo args)
        {
            CodeExampleGroup group = args.Node as CodeExampleGroup;
            if (group != null)
                args.CellData = group.Name;

            CodeExample example = args.Node as CodeExample;
            if (example != null)
                args.CellData = example.RegionName;
        }

        void treeList_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo args)
        {
            if (treeListRootNodeLoading)
            {
                args.Children = examples;
                treeListRootNodeLoading = false;
            }
            else
            {
                if (args.Node == null)
                    return;
                CodeExampleGroup group = args.Node as CodeExampleGroup;
                if (group != null)
                    args.Children = group.Examples;
            }
        }

        void ShowFirstExample(string firstGroupName)
        {
            treeList1.ExpandAll();
            if (treeList1.Nodes.Count > 0)
                treeList1.FocusedNode = treeList1.FindNodeByFieldValue("", firstGroupName).NextVisibleNode;
        }

        void evaluator_OnAfterCompile(object sender, OnAfterCompileEventArgs args)
        {
            codeEditor.AfterCompile(args.Result);
        }

        void evaluator_OnBeforeCompile(object sender, EventArgs e)
        {
            Document document = richEditControl.Document;
            document.BeginUpdate();
            codeEditor.BeforeCompile();
            richEditControl.CreateNewDocument();
            document.Unit = DevExpress.Office.DocumentUnit.Document;
            document.EndUpdate();
        }

        void OnNewExampleSelected(object sender, FocusedNodeChangedEventArgs e)
        {
            CodeExample newExample = (sender as TreeList).GetDataRecordByNode(e.Node) as CodeExample;
            CodeExample oldExample = (sender as TreeList).GetDataRecordByNode(e.OldNode) as CodeExample;

            if (newExample == null)
                return;
            
            string exampleCode = codeEditor.ShowExample(oldExample, newExample);
            codeExampleNameLbl.Text = CodeExampleDemoUtils.ConvertStringToMoreHumanReadableForm(newExample.RegionName) + " example";
            CodeEvaluationEventArgs args = new CodeEvaluationEventArgs();
            InitializeCodeEvaluationEventArgs(args);
            evaluator.ForceCompile(args);

            if (newExample.HumanReadableGroupName == "Comments")
            {
                this.richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Visible;
                this.displayResultControl1.DockPanel.Show();
            }
            else
            {
                this.richEditControl.Options.Comments.Visibility = RichEditCommentVisibility.Hidden;
                this.displayResultControl1.DockPanel.Hide();
            }

        }

        void InitializeCodeEvaluationEventArgs(CodeEvaluationEventArgs e)
        {
            e.Result = true;
            e.Code = codeEditor.CurrentCodeEditor.Text;
            e.CodeClasses = codeEditor.CurrentCodeClassEditor.Text;
            e.Language = CurrentExampleLanguage;
            e.EvaluationParameter = richEditControl.Document;
        }

        void OnExampleEvaluatorQueryEvaluate(object sender, CodeEvaluationEventArgs e)
        {
            e.Result = false;
            if (codeEditor.RichEditTextChanged)
            {// && compileComplete) {
                TimeSpan span = DateTime.Now - codeEditor.LastExampleCodeModifiedTime;

                if (span < TimeSpan.FromMilliseconds(1000))
                {//CompileTimeIntervalInMilliseconds  1900
                    codeEditor.ResetLastExampleModifiedTime();
                    return;
                }
                //e.Result = true;
                InitializeCodeEvaluationEventArgs(e);
            }
        }

        void DisableTabs(int examplesCSCount, int examplesVBCount)
        {
            if (examplesCSCount == 0)
                foreach (XtraTabPage t in xtraTabControl1.TabPages) if (t.Tag.ToString() == "CS") t.PageEnabled = false;
            if (examplesVBCount == 0)
                foreach (XtraTabPage t in xtraTabControl1.TabPages) if (t.Tag.ToString() == "VB") t.PageEnabled = false;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                richEditControl.MouseMove += richEditControl_MouseMove;
            }
            else
            {
                richEditControl.MouseMove -= richEditControl_MouseMove;
            }
        }

        void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            CurrentExampleLanguage = (e.Page.Tag.ToString() == "CS") ? ExampleLanguage.Csharp : ExampleLanguage.VB;

        }

        #region #getpositionfrrompoint
        void richEditControl_MouseMove(object sender, MouseEventArgs e)
        {
            Point docPoint = Units.PixelsToDocuments(e.Location, richEditControl.DpiX, richEditControl.DpiY);
            DocumentPosition pos = richEditControl.GetPositionFromPoint(docPoint);
            if (pos != null)
                this.Text = System.String.Format("Mouse is over position {0}", pos);
            else this.Text = "";
        }
        #endregion #getpositionfrrompoint

    }
}
