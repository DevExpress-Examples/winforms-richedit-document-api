using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class HeaderAndFooterActions
    {
        static void CreateHeader(Document document)
        {
            #region #CreateHeader
            Section firstSection = document.Sections[0];
            // Create an empty header.
            SubDocument newHeader = firstSection.BeginUpdateHeader();
            firstSection.EndUpdateHeader(newHeader);
            // Check whether the document already has a header (the same header for all pages).
            if (firstSection.HasHeader(HeaderFooterType.Primary))
            {
                SubDocument headerDocument = firstSection.BeginUpdateHeader();
                document.ChangeActiveDocument(headerDocument);
                document.CaretPosition = headerDocument.CreatePosition(0);
                firstSection.EndUpdateHeader(headerDocument);
            }
            #endregion #CreateHeader
        }
        
        
        static void ModifyHeader(Document document)
        {
            #region #ModifyHeader
            document.AppendSection();
            Section firstSection = document.Sections[0];
            // Modify the header of the HeaderFooterType.First type.
            SubDocument myHeader = firstSection.BeginUpdateHeader(HeaderFooterType.First);
            DocumentRange range = myHeader.InsertText(myHeader.CreatePosition(0), " PAGE NUMBER ");
            Field fld = myHeader.Fields.Create(range.End, "PAGE \\* ARABICDASH");
            myHeader.Fields.Update();
            firstSection.EndUpdateHeader(myHeader);
            // Display the header of the HeaderFooterType.First type on the first page.
            firstSection.DifferentFirstPage = true;
            #endregion #ModifyHeader
        }
    }
}
