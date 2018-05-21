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
            //Start updating the document
            document.BeginUpdate();
            
            //Create a DATE field at the caret position
            document.Fields.Create(document.CaretPosition, "DATE");
            document.Fields.Update();

            //Finalize the modification
            document.EndUpdate();
            #endregion #InsertField
        }

        static void ModifyFieldCode(Document document)
        {
            #region #ModifyFieldCode
            document.BeginUpdate();

            //Create a DATE field at the caret position
            document.Fields.Create(document.CaretPosition, "DATE");
            document.EndUpdate();
            for (int i = 0; i < document.Fields.Count; i++)
            {
                string fieldCode = document.GetText(document.Fields[i].CodeRange);
                if (fieldCode == "DATE")
                {
                    //Retrieve the range obtained by the field code
                    DocumentPosition position = document.Fields[i].CodeRange.End;

                    //Insert the format switch to the end of the field code range
                    document.InsertText(position, @"\@ ""M/d/yyyy h:mm am/pm""");
                }
            }

            //Update all document fields
            document.Fields.Update();
            #endregion #ModifyFieldCode
        }

        static void CreateFieldFromRange(Document document)
        {
            #region #CreateFieldFromRange
            document.BeginUpdate();
            //Insert the text to the document end
            document.AppendText("SYMBOL 0x54 \\f Wingdings \\s 24");
            document.EndUpdate();

            //Convert the inserted text to the field 
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
