using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class FieldActions
    {
        static void InsertField(Document document)
        {
            #region #InsertField
            document.BeginUpdate();
            document.Fields.Create(document.CaretPosition, "DATE");
            document.Fields.Update();
            document.EndUpdate();
            #endregion #InsertField
        }

        static void ModifyFieldCode(Document document)
        {
            #region #ModifyFieldCode
            document.BeginUpdate();
            document.Fields.Create(document.CaretPosition, "DATE");
            document.EndUpdate();
            for (int i = 0; i < document.Fields.Count; i++)
            {
                string fieldCode = document.GetText(document.Fields[i].CodeRange);
                if (fieldCode == "DATE")
                {
                    DocumentPosition position = document.Fields[i].CodeRange.End;
                    document.InsertText(position, @"\@ ""M/d/yyyy h:mm am/pm""");
                }
            }
            document.Fields.Update();
            #endregion #ModifyFieldCode
        }

        static void CreateFieldFromRange(Document document)
        {
            #region #CreateFieldFromRange
            document.BeginUpdate();
            document.AppendText("SYMBOL 0x54 \\f Wingdings \\s 24");
            document.EndUpdate();
            document.Fields.Create(document.Paragraphs[0].Range);
            document.Fields.Update();
            #endregion #CreateFieldFromRange
        }

        static void ShowFieldCodes(Document document)
        {
            #region #ShowFieldCodes
            document.LoadDocument("MailMergeSimple.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            for (int i = 0; i < document.Fields.Count; i++)
            {
                document.Fields[i].ShowCodes = true;
            }
            #endregion #ShowFieldCodes
        }


    }
}
