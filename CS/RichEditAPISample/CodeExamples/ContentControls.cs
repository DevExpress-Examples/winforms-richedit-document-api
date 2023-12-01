using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit.API.Native;

namespace RichEditAPISample.CodeExamples
{
    class ContentControls
    {
        static void CreateContentControls(Document document)
        {
            #region #CreateContentControls
            document.LoadDocument("Documents\\Simple Form.docx");
            var contentControls = document.ContentControls;

            // Insert a form to enter a name:
            var namePosition = document.CreatePosition(document.Paragraphs[0].Range.End.ToInt() - 1);
            var nameControl = contentControls.InsertPlainTextControl(namePosition);

            // Insert text in a content control:
            var nameTextPosition = document.CreatePosition(nameControl.Range.Start.ToInt() + 1);
            document.InsertText(nameTextPosition, "Click to enter a name");

            // Insert a drop-down list to select the appointment type:
            var listPosition = document.CreatePosition(document.Paragraphs[1].Range.End.ToInt() - 1);
            var listControl = contentControls.InsertDropDownListControl(listPosition);

            // Add items to the drop-down list:
            listControl.AddItem("First Appointment", "First Appointment");
            listControl.AddItem("Follow-Up Appointment", "Follow-Up Appointment");
            listControl.AddItem("Laboratory Results Check", "Laboratory Results Check");

            listControl.SelectedItemIndex = 1;

            // Insert a date picker to select the appointment date:
            var datePosition = document.CreatePosition(document.Paragraphs[2].Range.End.ToInt() - 1);
            var datePicker = contentControls.InsertDatePickerControl(datePosition);
            datePicker.DateFormat = "dddd, MMMM dd, yyyy";

            // Insert a checkbox:
            var checkboxControl = contentControls.InsertCheckboxControl(document.Paragraphs[3].Range.Start);
            checkboxControl.Checked = false;
            #endregion #CreateContentControls
        }

        private static void ChangeContentControls(Document document)
        {
            #region #ChangeContentControlParameters
            document.LoadDocument("Documents\\Simple Form Filled.docx");
            var contentControls = document.ContentControls;
            foreach (var contentControl in contentControls)
            {
                contentControl.Color = Color.Red;
                switch (contentControl.ControlType)
                {
                    case ContentControlType.RichText:
                    case ContentControlType.PlainText:

                        contentControl.IsTemporary = true;
                        break;
                    case ContentControlType.Checkbox:
                        ContentControlCheckbox checkbox = contentControl as ContentControlCheckbox;
                        checkbox.CheckedSymbolStyle.Character = '*';
                        break;
                }
            }
            #endregion #ChangeContentControlParameters        
        }

        private static void RemoveContentControls(Document document)
        {
            #region #RemoveContentControls
            document.LoadDocument("Documents\\Simple Form Filled.docx");
            var contentControls = document.ContentControls;
            for (var i = 0; i < contentControls.Count; i++)
            {
                if (contentControls[i].ControlType == ContentControlType.Date)
                {
                    contentControls.Remove(contentControls[i], true);
                }
            }
            #endregion #RemoveContentControls
        }

    }
}
