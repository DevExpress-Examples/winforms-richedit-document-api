Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditAPISample.CodeExamples
    Friend Class FormFieldsActions

        Private Shared Sub InsertChechBox(ByVal document As Document)
'            #Region "#InsertCheckBox"
            Dim currentPosition As DocumentPosition = document.CaretPosition
            Dim checkBox As DevExpress.XtraRichEdit.API.Native.CheckBox = document.FormFields.InsertCheckBox(currentPosition)
            checkBox.Name = "check1"
            checkBox.State = CheckBoxState.Checked
            checkBox.SizeMode = CheckBoxSizeMode.Auto
            checkBox.HelpTextType = FormFieldTextType.Custom
            checkBox.HelpText = "help text"
'            #End Region ' #InsertCheckBox
        End Sub
    End Class
End Namespace
