using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class ExportActions
    {

        static void SaveImageFromRange(Document document)
        {
            #region #SaveImageFromRange
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
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
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            // Get the range for three paragraphs.
            DocumentRange r = document.CreateRange(document.Paragraphs[0].Range.Start, document.Paragraphs[0].Range.Length + document.Paragraphs[1].Range.Length + document.Paragraphs[2].Range.Length);
            // Export to HTML.
            string htmlText = document.GetHtmlText(r, null);
            System.IO.File.WriteAllText("test.html", htmlText);
            // Show the result in a browser window.
            System.Diagnostics.Process.Start("test.html");
            #endregion #ExportRangeToHtml
        }

        static void ExportRangeToPlainText(Document document)
        {
            #region #ExportRangeToPlainText
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            string plainText = document.GetText(document.Paragraphs[2].Range);
            System.Windows.Forms.MessageBox.Show(plainText);
            #endregion #ExportRangeToPlainText
        }
    }
}
