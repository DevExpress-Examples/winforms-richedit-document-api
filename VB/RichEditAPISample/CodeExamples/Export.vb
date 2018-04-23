Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit

Namespace RichEditAPISample.CodeExamples
    Friend Class ExportActions

        Private Shared Sub SaveImageFromRange(ByVal document As Document)
'            #Region "#SaveImageFromRange"
            document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml)
            Dim docRange As DocumentRange = document.Paragraphs(2).Range
            Dim docImageColl As ReadOnlyDocumentImageCollection = document.Images.Get(docRange)
            If docImageColl.Count > 0 Then
                Dim myImage As DevExpress.Office.Utils.OfficeImage = docImageColl(0).Image
                Dim image As System.Drawing.Image = myImage.NativeImage
                Dim imageName As String = String.Format("Image_at_pos_{0}.png", docRange.Start.ToInt())
                image.Save(imageName)
                System.Diagnostics.Process.Start("explorer.exe", "/select," & imageName)
            End If
'            #End Region ' #SaveImageFromRange
        End Sub

        Private Shared Sub ExportRangeToHtml(ByVal document As Document)
'            #Region "#ExportRangeToHtml"
            document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml)
            ' Get the range for three paragraphs.
            Dim r As DocumentRange = document.CreateRange(document.Paragraphs(0).Range.Start, document.Paragraphs(0).Range.Length + document.Paragraphs(1).Range.Length + document.Paragraphs(2).Range.Length)
            ' Export to HTML.
            Dim htmlText As String = document.GetHtmlText(r, Nothing)
            File.WriteAllText("test.html", htmlText)
            ' Show the result in a browser window.
            System.Diagnostics.Process.Start("test.html")
'            #End Region ' #ExportRangeToHtml
        End Sub

		Shared Sub ExportRangeToPlainText(ByVal document As Document)
'			#Region "#ExportRangeToPlainText"
			document.LoadDocument("Grimm.docx", DocumentFormat.OpenXml)
			Dim plainText As String = document.GetText(document.Paragraphs(2).Range)

			DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = True
			DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
'			#End Region ' #ExportRangeToPlainText
		End Sub

		Shared Sub ExportSelectionToPlainText(ByVal document As Document)
'			#Region "#ExportSelectionToPlainText"
			document.LoadDocument("FloatingObjects.docx", DocumentFormat.OpenXml)

			' Select footer.
			Dim footerDocument As SubDocument = document.Sections(0).BeginUpdateFooter()
			document.ChangeActiveDocument(footerDocument)
			document.Selection = footerDocument.Paragraphs(0).Range
			document.Sections(0).EndUpdateFooter(footerDocument)
			' Get selection as plain text.
			Dim docRange As SubDocument = document.Selection.BeginUpdateDocument()
			Dim plainText As String = docRange.GetText(docRange.Range)
			document.Selection.EndUpdateDocument(docRange)

			DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = True
			DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
'			#End Region ' #ExportSelectionToPlainText
		End Sub

		Shared Sub ExportFieldWithCodesToPlainText(ByVal document As Document)
'			#Region "#ExportFieldWithCodesToPlainText"
			document.LoadDocument("SampleTOC.docx", DocumentFormat.OpenXml)
			Dim plainText As String = String.Empty

			For Each item As Field In document.Fields
				Dim fieldCode As String = document.GetText(item.CodeRange)
				Dim fieldParts() As String = fieldCode.Split(" "c)
				If fieldParts(0).Trim() = "TOC" AndAlso fieldParts(1).Trim() = "\h" Then
					Dim exportOptions As New DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions()
					exportOptions.ExportHiddenText = True
					exportOptions.FieldCodeStartMarker = "[<"
					exportOptions.FieldCodeEndMarker = ">"
					exportOptions.FieldResultEndMarker = "]"
					plainText = document.GetText(item.Range, exportOptions)
				End If
			Next item

			DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = False
			DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
'			#End Region ' #ExportFieldWithCodesToPlainText
		End Sub

		Shared Sub ExportToPlainTextWithTextFragmentOptions(ByVal document As Document)
'			#Region "#ExportToPlainTextWithTextFragmentOptions"
			document.LoadDocument("SampleTOC.docx", DocumentFormat.OpenXml)
			Dim plainText As String = String.Empty

			For Each item As Field In document.Fields
				Dim fieldCode As String = document.GetText(item.CodeRange)
				Dim fieldParts() As String = fieldCode.Split(" "c)
				If fieldParts(0).Trim() = "TOC" AndAlso fieldParts(1).Trim() = "\h" Then
					Dim options As New DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions()
					options.AllowExtendingDocumentRange = False
					For Each par As Paragraph In document.Paragraphs.Get(item.ResultRange)
						plainText &= document.GetText(par.Range, options)
						plainText &= Environment.NewLine
					Next par
				End If
			Next item

			DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = False
			DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
'			#End Region ' #ExportToPlainTextWithTextFragmentOptions
		End Sub


    End Class
End Namespace
