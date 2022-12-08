Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class FieldActions

        Private Shared Sub InsertField(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#InsertField"
            document.BeginUpdate()
            document.Fields.Create(document.CaretPosition, "DATE")
            document.Fields.Update()
            document.EndUpdate()
'#End Region  ' #InsertField
        End Sub

        Private Shared Sub ModifyFieldCode(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ModifyFieldCode"
            document.BeginUpdate()
            document.Fields.Create(document.CaretPosition, "DATE")
            document.EndUpdate()
            For i As Integer = 0 To document.Fields.Count - 1
                Dim fieldCode As String = document.GetText(document.Fields(CInt((i))).CodeRange)
                If Equals(fieldCode, "DATE") Then
                    Dim position As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.Fields(CInt((i))).CodeRange.[End]
                    document.InsertText(position, "\@ ""M/d/yyyy h:mm am/pm""")
                End If
            Next

            document.Fields.Update()
'#End Region  ' #ModifyFieldCode
        End Sub

        Private Shared Sub CreateFieldFromRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateFieldFromRange"
            document.BeginUpdate()
            document.AppendText("SYMBOL 0x54 \f Wingdings \s 24")
            document.EndUpdate()
            document.Fields.Create(document.Paragraphs(CInt((0))).Range)
            document.Fields.Update()
'#End Region  ' #CreateFieldFromRange
        End Sub

        Private Shared Sub ShowFieldCodes(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ShowFieldCodes"
            document.LoadDocument("MailMergeSimple.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            For i As Integer = 0 To document.Fields.Count - 1
                document.Fields(CInt((i))).ShowCodes = True
            Next
'#End Region  ' #ShowFieldCodes
        End Sub
    End Class
End Namespace
