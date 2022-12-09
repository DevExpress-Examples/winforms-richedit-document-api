Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit

Namespace RichEditAPISample.CodeExamples

    Friend Class ExportActions

        Private Shared Sub SaveImageFromRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SaveImageFromRange"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim docRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((2))).Range
            Dim docImageColl As DevExpress.XtraRichEdit.API.Native.ReadOnlyDocumentImageCollection = document.Images.[Get](docRange)
            If docImageColl.Count > 0 Then
                Dim myImage As DevExpress.Office.Utils.OfficeImage = docImageColl(CInt((0))).Image
                Dim image As System.Drawing.Image = myImage.NativeImage
                Dim imageName As String = System.[String].Format("Image_at_pos_{0}.png", docRange.Start.ToInt())
                image.Save(imageName)
                System.Diagnostics.Process.Start("explorer.exe", "/select," & imageName)
            End If
#End Region  ' #SaveImageFromRange
        End Sub

        Private Shared Sub ExportRangeToHtml(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ExportRangeToHtml"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            ' Get the range for three paragraphs.
            Dim r As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(document.Paragraphs(CInt((0))).Range.Start, document.Paragraphs(CInt((0))).Range.Length + document.Paragraphs(CInt((1))).Range.Length + document.Paragraphs(CInt((2))).Range.Length)
            ' Export to HTML.
            Dim htmlText As String = document.GetHtmlText(r, Nothing)
            Call System.IO.File.WriteAllText("test.html", htmlText)
            ' Show the result in a browser window.
            System.Diagnostics.Process.Start("test.html")
#End Region  ' #ExportRangeToHtml
        End Sub

        Private Shared Sub ExportRangeToPlainText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ExportRangeToPlainText"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim plainText As String = document.GetText(document.Paragraphs(CInt((2))).Range)
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = True
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
#End Region  ' #ExportRangeToPlainText
        End Sub

        Private Shared Sub ExportSelectionToPlainText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ExportSelectionToPlainText"
            document.LoadDocument("Documents//FloatingObjects.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            ' Select footer.
            Dim footerDocument As DevExpress.XtraRichEdit.API.Native.SubDocument = document.Sections(CInt((0))).BeginUpdateFooter()
            document.ChangeActiveDocument(footerDocument)
            document.Selection = footerDocument.Paragraphs(CInt((0))).Range
            document.Sections(CInt((0))).EndUpdateFooter(footerDocument)
            ' Get selection as plain text.
            Dim docRange As DevExpress.XtraRichEdit.API.Native.SubDocument = document.Selection.BeginUpdateDocument()
            Dim plainText As String = docRange.GetText(docRange.Range)
            document.Selection.EndUpdateDocument(docRange)
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = True
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
#End Region  ' #ExportSelectionToPlainText
        End Sub

        Private Shared Sub ExportFieldWithCodesToPlainText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ExportFieldWithCodesToPlainText"
            document.LoadDocument("Documents//SampleTOC.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim plainText As String = System.[String].Empty
            For Each item As DevExpress.XtraRichEdit.API.Native.Field In document.Fields
                Dim fieldCode As String = document.GetText(item.CodeRange)
                Dim fieldParts As String() = fieldCode.Split(" "c)
                If Equals(fieldParts(CInt((0))).Trim(), "TOC") AndAlso Equals(fieldParts(CInt((1))).Trim(), "\h") Then
                    Dim exportOptions As DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions = New DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions()
                    exportOptions.ExportHiddenText = True
                    exportOptions.FieldCodeStartMarker = "[<"
                    exportOptions.FieldCodeEndMarker = ">"
                    exportOptions.FieldResultEndMarker = "]"
                    plainText = document.GetText(item.Range, exportOptions)
                End If
            Next

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = False
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
#End Region  ' #ExportFieldWithCodesToPlainText
        End Sub

        Private Shared Sub ExportToPlainTextWithTextFragmentOptions(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ExportToPlainTextWithTextFragmentOptions"
            document.LoadDocument("Documents//SampleTOC.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim plainText As String = System.[String].Empty
            For Each item As DevExpress.XtraRichEdit.API.Native.Field In document.Fields
                Dim fieldCode As String = document.GetText(item.CodeRange)
                Dim fieldParts As String() = fieldCode.Split(" "c)
                If Equals(fieldParts(CInt((0))).Trim(), "TOC") AndAlso Equals(fieldParts(CInt((1))).Trim(), "\h") Then
                    Dim options As DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions = New DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions()
                    options.AllowExtendingDocumentRange = False
                    For Each par As DevExpress.XtraRichEdit.API.Native.Paragraph In document.Paragraphs.[Get](item.ResultRange)
                        plainText += document.GetText(par.Range, options)
                        plainText += System.Environment.NewLine
                    Next
                End If
            Next

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = False
            DevExpress.XtraEditors.XtraMessageBox.Show(plainText)
#End Region  ' #ExportToPlainTextWithTextFragmentOptions
        End Sub
    End Class
End Namespace
