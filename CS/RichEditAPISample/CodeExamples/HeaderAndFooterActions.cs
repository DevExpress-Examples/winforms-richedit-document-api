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
