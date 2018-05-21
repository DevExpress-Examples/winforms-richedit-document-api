using DevExpress.XtraRichEdit.API.Native;
using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace RichEditAPISample.CodeExamples
{
    class ExportActions
    {

        static void SaveImageFromRange(Document document)
        {
            #region #SaveImageFromRange
            document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml);
            DocumentRange docRange = document.Paragraphs[2].Range;
            ReadOnlyDocumentImageCollection docImageColl = document.Images.Get(docRange);
            if (docImageColl.Count > 0)
            {
                DevExpress.Office.Utils.OfficeImage myImage = docImageColl[0].Image;
                System.Drawing.Image image = myImage.NativeImage;
                string imageName = String.Format("Image_at_pos_{0}.png", docRange.Start.ToInt());
                image.Save(imageName);
                System.Diagnostics.Process.Start("explorer.exe", "/select," + imageName);
            }
            #endregion #SaveImageFromRange
        }

        static void ExportRangeToHtml(Document document)
        {
            #region #ExportRangeToHtml
            document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml);
            // Get the range for three paragraphs.
            DocumentRange r = document.CreateRange(document.Paragraphs[0].Range.Start, document.Paragraphs[0].Range.Length + document.Paragraphs[1].Range.Length + document.Paragraphs[2].Range.Length);
            // Export to HTML.
            string htmlText = document.GetHtmlText(r, null);
            File.WriteAllText("test.html", htmlText);
            // Show the result in a browser window.
            System.Diagnostics.Process.Start("test.html");
            #endregion #ExportRangeToHtml
        }

        static void ExportRangeToPlainText(Document document)
        {
            #region #ExportRangeToPlainText
            document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml);
            string plainText = document.GetText(document.Paragraphs[2].Range);

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText);
            #endregion #ExportRangeToPlainText
        }

        static void ExportSelectionToPlainText(Document document) {
            #region #ExportSelectionToPlainText
            document.LoadDocument("FloatingObjects.docx", DocumentFormat.OpenXml);

            // Select footer.
            SubDocument footerDocument = document.Sections[0].BeginUpdateFooter();
            document.ChangeActiveDocument(footerDocument);
            document.Selection = footerDocument.Paragraphs[0].Range;
            document.Sections[0].EndUpdateFooter(footerDocument);
            // Get selection as plain text.
            SubDocument docRange = document.Selection.BeginUpdateDocument();
            string plainText = docRange.GetText(docRange.Range);
            document.Selection.EndUpdateDocument(docRange);

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText);
            #endregion #ExportSelectionToPlainText
        }

        static void ExportFieldWithCodesToPlainText(Document document) {
            #region #ExportFieldWithCodesToPlainText
            document.LoadDocument("SampleTOC.docx", DocumentFormat.OpenXml);
            string plainText = String.Empty;

            foreach (Field item in document.Fields) {
                string fieldCode = document.GetText(item.CodeRange);
                string[] fieldParts = fieldCode.Split(' ');
                if (fieldParts[0].Trim() == "TOC" && fieldParts[1].Trim() == "\\h") {
                    DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions exportOptions = 
                        new DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions();
                    exportOptions.ExportHiddenText = true;
                    exportOptions.FieldCodeStartMarker = "[<";
                    exportOptions.FieldCodeEndMarker = ">";
                    exportOptions.FieldResultEndMarker = "]";
                    plainText = document.GetText(item.Range, exportOptions);
                }
            }

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = false;
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText);
            #endregion #ExportFieldWithCodesToPlainText
        }

        static void ExportToPlainTextWithTextFragmentOptions(Document document) {
            #region #ExportToPlainTextWithTextFragmentOptions
            document.LoadDocument("SampleTOC.docx", DocumentFormat.OpenXml);
            string plainText = String.Empty;

            foreach (Field item in document.Fields) {
                string fieldCode = document.GetText(item.CodeRange);
                string[] fieldParts = fieldCode.Split(' ');
                if (fieldParts[0].Trim() == "TOC" && fieldParts[1].Trim() == "\\h") {
                    DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions options = 
                        new DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions();
                    options.AllowExtendingDocumentRange = false;
                    foreach (Paragraph par in document.Paragraphs.Get(item.ResultRange)) {
                        plainText += document.GetText(par.Range, options);
                        plainText += Environment.NewLine;
                    }
                }
            }

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = false;
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText);
            #endregion #ExportToPlainTextWithTextFragmentOptions
        }
    }
}
