using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    public static class RangeActions
    {
        static void InsertTextInRange(Document doc)
        {
            #region #InsertTextInRange
            doc.AppendText("ABCDEFGH");
            DocumentRange r1 = doc.CreateRange(1, 3);
            DocumentPosition pos1 = doc.CreatePosition(2);
            DocumentRange r2 = doc.InsertText(pos1, "NewText");
            string s1 = String.Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.End);
            string s2 = String.Format("Range r2 starts at {0}, ends at {1}", r2.Start, r2.End);
            doc.AppendParagraph();
            doc.AppendText(s1);
            doc.AppendParagraph();
            doc.AppendText(s2);
            #endregion #InsertTextInRange
        }

        static void AppendTextToRange(Document doc)
        {
            #region #AppendTextToRange
            doc.AppendText("ABCDEFGH");
            DocumentRange r1 = doc.AppendText("X");
            string s1 = String.Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.End);
            doc.AppendText("Y");
            doc.AppendText("Z");
            string s2 = String.Format("Currently range r1 starts at {0}, ends at {1}", r1.Start, r1.End);
            doc.AppendParagraph();
            doc.AppendText(s1);
            doc.AppendParagraph();
            doc.AppendText(s2);
            #endregion #AppendTextToRange
        }


    }
}
