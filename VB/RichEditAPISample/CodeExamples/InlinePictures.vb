Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class InlinePicturesActions

        Private Shared Sub ImageFromFile(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ImageFromFile"
            Dim pos As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.Range.Start
            document.Images.Insert(pos, DevExpress.XtraRichEdit.API.Native.DocumentImageSource.FromFile("beverages.png"))
#End Region  ' #ImageFromFile
        End Sub

        Private Shared Sub ImageCollection(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ImageCollection"
            document.LoadDocument("Documents//Grimm.docx")
            Dim images As DevExpress.XtraRichEdit.API.Native.ReadOnlyDocumentImageCollection = document.Images
            ' If the width of an image exceeds 50 millimeters, 
            ' the image is scaled proportionally to half its size.
            For i As Integer = 0 To images.Count - 1
                If images(CInt((i))).Size.Width > DevExpress.Office.Utils.Units.MillimetersToDocumentsF(50) Then
                    images(CInt((i))).ScaleX /= 2
                    images(CInt((i))).ScaleY /= 2
                End If
            Next
#End Region  ' #ImageCollection
        End Sub

        Private Shared Sub SaveImageToFile(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SaveImageToFile"
            document.LoadDocument("Documents//MovieRentals.docx")
            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(0, 100)
            Dim images As DevExpress.XtraRichEdit.API.Native.ReadOnlyDocumentImageCollection = document.Images.[Get](myRange)
            If images.Count > 0 Then
                Dim myImage As DevExpress.Office.Utils.OfficeImage = images(CInt((0))).Image
                Dim image As System.Drawing.Image = myImage.NativeImage
                Dim imageName As String = System.[String].Format("Image_at_pos_{0}.png", images(CInt((0))).Range.Start.ToInt())
                image.Save(imageName)
                System.Diagnostics.Process.Start("explorer.exe", "/select," & imageName)
            End If
#End Region  ' #SaveImageToFile
        End Sub
    End Class
End Namespace
