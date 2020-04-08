Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
	Friend Class FieldActions
		Private Shared Sub InsertField(ByVal document As Document)
'			#Region "#InsertField"
			Dim caretPosition As DocumentPosition = document.CaretPosition

			'Start updating the document
			caretPosition.BeginUpdateDocument()

			'Create a DATE field at the caret position
			document.Fields.Create(caretPosition, "DATE")
			document.Fields.Update()

			'Finalize the modification
			document.EndUpdate()
'			#End Region ' #InsertField
		End Sub

		Private Shared Sub ModifyFieldCode(ByVal document As Document)
'			#Region "#ModifyFieldCode"
			Dim caretPosition As DocumentPosition = document.CaretPosition
			Dim currentDocument As SubDocument = caretPosition.BeginUpdateDocument()

			'Create a DATE field at the caret position
			currentDocument.Fields.Create(caretPosition, "DATE")
			currentDocument.EndUpdate()

			For i As Integer = 0 To currentDocument.Fields.Count - 1
				Dim fieldCode As String = document.GetText(currentDocument.Fields(i).CodeRange)
				If fieldCode = "DATE" Then
					'Retrieve the range obtained by the field code
					Dim position As DocumentPosition = currentDocument.Fields(i).CodeRange.End

					'Insert the format switch to the end of the field code range
					currentDocument.InsertText(position, "\@ ""M/d/yyyy h:mm am/pm""")
				End If
			Next i

			'Update all document fields
			currentDocument.Fields.Update()
'			#End Region ' #ModifyFieldCode
		End Sub

		Private Shared Sub CreateFieldFromRange(ByVal document As Document)
'			#Region "#CreateFieldFromRange"
			document.BeginUpdate()
			'Insert the text to the document end
			document.AppendText("SYMBOL 0x54 \f Wingdings \s 24")
			document.EndUpdate()

			'Convert the inserted text to the field 
			document.Fields.Create(document.Paragraphs(0).Range)
			document.Fields.Update()
'			#End Region ' #CreateFieldFromRange
		End Sub

		Private Shared Sub ShowFieldCodes(ByVal document As Document)
'			#Region "#ShowFieldCodes"
			document.LoadDocument("Documents//MailMergeSimple.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			For i As Integer = 0 To document.Fields.Count - 1
				document.Fields(i).ShowCodes = True
			Next i
'			#End Region ' #ShowFieldCodes
		End Sub

	End Class
End Namespace
