using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;

namespace RichEditAPISample.CodeExamples
{
    class BookmarksAndHyperlinksActions
    {
        static void InsertBookmark(Document document)
        {
            #region #InsertBookmark
            document.LoadDocument("Grimm.docx",DocumentFormat.OpenXml);  
            document.BeginUpdate();           
            DocumentPosition pos = document.Range.Start;
            document.Bookmarks.Create(document.CreateRange(pos, 0), "Top");
           //Insert the hyperlink anchored to the created bookmark:
            DocumentPosition pos1 = document.CreatePosition((document.Range.End).ToInt()+25);
            document.Hyperlinks.Create(document.InsertText(pos1, "get to the top"));
            document.Hyperlinks[0].Anchor = "Top";            
            document.EndUpdate();          
            #endregion #InsertBookmark
        }
        static void InsertHYperlink(Document document)
        {
            #region #InsertHyperlink
            DocumentPosition hPos = document.Range.Start;
            document.Hyperlinks.Create(document.InsertText(hPos, "Follow me!"));
            document.Hyperlinks[0].NavigateUri = "https://www.devexpress.com/Products/NET/Controls/WinForms/Rich_Editor/";
            document.Hyperlinks[0].ToolTip = "WinForms Rich Text Editor";
            #endregion #InsertHyperlink
        }

    }
}
