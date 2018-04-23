using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class PageLayoutActions
    {
        static void LineNumbering(Document document)
        {
            #region #LineNumbering
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            document.Unit = DevExpress.Office.DocumentUnit.Inch;
            Section sec = document.Sections[0];
            sec.LineNumbering.CountBy = 2;
            sec.LineNumbering.Start = 1;
            sec.LineNumbering.Distance = 0.25f;
            sec.LineNumbering.RestartType = LineNumberingRestart.NewSection;
            #endregion #LineNumbering
        }

        static void CreateColumns(Document document)
        {
            #region #CreateColumns
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            document.Unit = DevExpress.Office.DocumentUnit.Inch;
            // Get the first section in a document
            Section firstSection = document.Sections[0];
            // Create columns and apply them to the document
            SectionColumnCollection sectionColumnsLayout =
                firstSection.Columns.CreateUniformColumns(firstSection.Page, 0.2f, 3);
            firstSection.Columns.SetColumns(sectionColumnsLayout);
            #endregion #CreateColumns
        }
        
        static void PrintLayout(Document document)
        {
            #region #PrintLayout
            document.Unit = DevExpress.Office.DocumentUnit.Inch;
            document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A6;
            document.Sections[0].Page.Landscape = true;
            document.Sections[0].Margins.Left = 2.0f;
            #endregion #PrintLayout
        }

        static void TabStops(Document document)
        {
            #region #TabStops
            document.Unit = DevExpress.Office.DocumentUnit.Inch;
            TabInfoCollection tabs = document.Paragraphs[0].BeginUpdateTabs(true);
            DevExpress.XtraRichEdit.API.Native.TabInfo tab1 = new DevExpress.XtraRichEdit.API.Native.TabInfo();
            // Sets tab stop at 2.5 inch
            tab1.Position = 2.5f;
            tab1.Alignment = TabAlignmentType.Left;
            tab1.Leader = TabLeaderType.MiddleDots;
            tabs.Add(tab1);
            DevExpress.XtraRichEdit.API.Native.TabInfo tab2 = new DevExpress.XtraRichEdit.API.Native.TabInfo();
            tab2.Position = 5.5f;
            tab2.Alignment = TabAlignmentType.Decimal;
            tab2.Leader = TabLeaderType.EqualSign;
            tabs.Add(tab2);
            document.Paragraphs[0].EndUpdateTabs(tabs);
            #endregion #TabStops
        }
    }
}
