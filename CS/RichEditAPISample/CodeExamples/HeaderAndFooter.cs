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
            // Check whether the document already has a header (the same header for all pages).
            if (!firstSection.HasHeader(HeaderFooterType.Primary))
            {
                SubDocument headerDocument = firstSection.BeginUpdateHeader();
                document.ChangeActiveDocument(headerDocument);
                headerDocument.AppendText("Header");
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

        static void CreateFooter(Document document)
        {
            #region #CreateFooter
            Section firstSection = document.Sections[0];
            // Create an empty footer.
            SubDocument newFooter = firstSection.BeginUpdateFooter();
            firstSection.EndUpdateFooter(newFooter);
            // Check whether the document already has a footer (the same footer for all pages).
            if (firstSection.HasFooter(HeaderFooterType.Primary)) {
                SubDocument footerDocument = firstSection.BeginUpdateFooter();
                document.ChangeActiveDocument(footerDocument);
                document.CaretPosition = footerDocument.CreatePosition(0);
                firstSection.EndUpdateFooter(footerDocument);
            }
            #endregion #CreateFooter
        }


        static void ModifyFooter(Document document)
        {
            #region #ModifyFooter
            document.AppendSection();
            Section firstSection = document.Sections[0];
            // Modify the footer of the HeaderFooterType.First type.
            SubDocument myFooter = firstSection.BeginUpdateFooter(HeaderFooterType.First);
            DocumentRange range = myFooter.InsertText(myFooter.CreatePosition(0), " PAGE NUMBER ");
            Field fld = myFooter.Fields.Create(range.End, "PAGE \\* ARABICDASH");
            myFooter.Fields.Update();
            firstSection.EndUpdateHeader(myFooter);
            // Display the footer of the HeaderFooterType.First type on the first page.
            firstSection.DifferentFirstPage = true;
            #endregion #ModifyFooter
        }
    }
}
