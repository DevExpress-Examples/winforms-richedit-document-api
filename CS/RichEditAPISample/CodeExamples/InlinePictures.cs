using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class InlinePicturesActions
    {
        static void ImageFromFile(Document document)
        {
            #region #ImageFromFile
            DocumentPosition pos = document.Range.Start;
            document.Images.Insert(pos, DocumentImageSource.FromFile("beverages.png"));
            #endregion #ImageFromFile
        }
       
        static void ImageCollection(Document document)
        {
            #region #ImageCollection
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            ReadOnlyDocumentImageCollection images = document.Images;
            // If the width of an image exceeds 50 millimeters, 
            // the image is scaled proportionally to half its size.
            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].Size.Width > DevExpress.Office.Utils.Units.MillimetersToDocumentsF(50))
                {
                    images[i].ScaleX /= 2;
                    images[i].ScaleY /= 2;
                }
            }
            #endregion #ImageCollection
        }

        static void SaveImageToFile(Document document)
        {
            #region #SaveImageToFile
            document.LoadDocument("Documents//MovieRentals.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            DocumentRange myRange = document.CreateRange(0,100);
            ReadOnlyDocumentImageCollection images = document.Images.Get(myRange);
            if (images.Count > 0)
            {
                DevExpress.Office.Utils.OfficeImage myImage = images[0].Image;
                System.Drawing.Image image = myImage.NativeImage;
                string imageName = String.Format("Image_at_pos_{0}.png", images[0].Range.Start.ToInt());
                image.Save(imageName);
                System.Diagnostics.Process.Start("explorer.exe", "/select," + imageName);
            }
            #endregion #SaveImageToFile
        }
    }
}
