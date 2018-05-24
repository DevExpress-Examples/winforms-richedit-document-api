using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit.API.Native;

namespace RichEditAPISample.CodeExamples
{
    class FormFieldsActions
   
    {
        static void InsertChechBox(Document document)
        {
            #region #InsertCheckBox
            DocumentPosition currentPosition = document.CaretPosition;
            DevExpress.XtraRichEdit.API.Native.CheckBox checkBox = document.FormFields.InsertCheckBox(currentPosition);
            checkBox.Name = "check1";
            checkBox.State = CheckBoxState.Checked;
            checkBox.SizeMode = CheckBoxSizeMode.Auto;
            checkBox.HelpTextType = FormFieldTextType.Custom;
            checkBox.HelpText = "help text";
            #endregion #InsertCheckBox
        }
    }
}
