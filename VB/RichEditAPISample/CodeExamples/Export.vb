Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class ExportActions

        Private Shared Sub SaveImageFromRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#SaveImageFromRange"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim docRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((2))).Range
            Dim docImageColl As DevExpress.XtraRichEdit.API.Native.ReadOnlyDocumentImageCollection = document.Images.[Get](docRange)
            If docImageColl.Count > 0 Then
                Dim myImage As DevExpress.Office.Utils.OfficeImage = docImageColl(CInt((0))).Image
                Dim image As System.Drawing.Image = myImage.NativeImage
                Dim imageName As String = System.[String].Format("Image_at_pos_{0}.png", docRange.Start.ToInt())
                image.Save(imageName)
                System.Diagnostics.Process.Start("explorer.exe", "/select," & imageName)
            End If
'#End Region  ' #SaveImageFromRange
        End Sub

        Private Shared Sub ExportRangeToHtml(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ExportRangeToHtml"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            ' Get the range for three paragraphs.
            Dim r As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(document.Paragraphs(CInt((0))).Range.Start, document.Paragraphs(CInt((0))).Range.Length + document.Paragraphs(CInt((1))).Range.Length + document.Paragraphs(CInt((2))).Range.Length)
            ' Export to HTML.
            Dim htmlText As String = document.GetHtmlText(r, Nothing)
            System.IO.File.WriteAllText("test.html", htmlText)
            ' Show the result in a browser window.
            System.Diagnostics.Process.Start("test.html")
'#End Region  ' #ExportRangeToHtml
        End Sub

        Private Shared Sub ExportRangeToPlainText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ExportRangeToPlainText"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim plainText As String = document.GetText(document.Paragraphs(CInt((2))).Range)
            System.Windows.Forms.MessageBox.Show(plainText)
'#End Region  ' #ExportRangeToPlainText
        End Sub
    End Class
End Namespace
