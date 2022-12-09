Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditAPISample.CodeExamples

    Friend Class FormFieldsActions

        Private Shared Sub InsertChechBox(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#InsertCheckBox"
            Dim currentPosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CaretPosition
            Dim currentDocument As DevExpress.XtraRichEdit.API.Native.SubDocument = currentPosition.BeginUpdateDocument()
            Dim checkBox As DevExpress.XtraRichEdit.API.Native.CheckBox = document.FormFields.InsertCheckBox(currentPosition)
            checkBox.Name = "check1"
            checkBox.State = DevExpress.XtraRichEdit.API.Native.CheckBoxState.Checked
            checkBox.SizeMode = DevExpress.XtraRichEdit.API.Native.CheckBoxSizeMode.Auto
            checkBox.HelpTextType = DevExpress.XtraRichEdit.API.Native.FormFieldTextType.Custom
            checkBox.HelpText = "help text"
            currentPosition.EndUpdateDocument(currentDocument)
#End Region  ' #InsertCheckBox
        End Sub
    End Class
End Namespace
