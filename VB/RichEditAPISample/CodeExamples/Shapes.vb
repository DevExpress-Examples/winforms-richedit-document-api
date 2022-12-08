Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class ShapesActions

        Private Shared Sub AddFloatingPicture(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#AddFloatingPicture"
            document.AppendText("Line One" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Two" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Three")
            Dim myPicture As DevExpress.XtraRichEdit.API.Native.Shape = document.Shapes.InsertPicture(document.CreatePosition(15), System.Drawing.Image.FromFile("beverages.png"))
            myPicture.HorizontalAlignment = DevExpress.XtraRichEdit.API.Native.ShapeHorizontalAlignment.Center
'#End Region  ' #AddFloatingPicture
        End Sub

        Private Shared Sub FloatingPictureOffset(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#FloatingPictureOffset"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            document.Unit = DevExpress.Office.DocumentUnit.Centimeter
            Dim myPicture As DevExpress.XtraRichEdit.API.Native.Shape = document.Shapes(1)
            ' Clear the qualitative positioning to allow positioning by specifying the numerical offset.
            myPicture.HorizontalAlignment = DevExpress.XtraRichEdit.API.Native.ShapeHorizontalAlignment.None
            myPicture.VerticalAlignment = DevExpress.XtraRichEdit.API.Native.ShapeVerticalAlignment.None
            ' Specify the reference item for positioning.
            myPicture.RelativeHorizontalPosition = DevExpress.XtraRichEdit.API.Native.ShapeRelativeHorizontalPosition.LeftMargin
            myPicture.RelativeVerticalPosition = DevExpress.XtraRichEdit.API.Native.ShapeRelativeVerticalPosition.TopMargin
            ' Specify the offset value.
            myPicture.Offset = New System.Drawing.PointF(4.5F, 2.0F)
'#End Region  ' #FloatingPictureOffset
        End Sub

        Private Shared Sub ChangeZorderAndWrapping(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ChangeZorderAndWrapping"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim myPicture As DevExpress.XtraRichEdit.API.Native.Shape = document.Shapes(1)
            myPicture.VerticalAlignment = DevExpress.XtraRichEdit.API.Native.ShapeVerticalAlignment.Top
            myPicture.ZOrder = document.Shapes(CInt((0))).ZOrder - 1
            myPicture.TextWrapping = DevExpress.XtraRichEdit.API.Native.TextWrappingType.BehindText
'#End Region  ' #ChangeZorderAndWrapping
        End Sub

        Private Shared Sub AddTextBox(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#AddTextBox"
            document.AppendText("Line One" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Two" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Three")
            Dim myTextBox As DevExpress.XtraRichEdit.API.Native.Shape = document.Shapes.InsertTextBox(document.CreatePosition(15))
            myTextBox.HorizontalAlignment = DevExpress.XtraRichEdit.API.Native.ShapeHorizontalAlignment.Center
            ' Specify the text box background color.
            myTextBox.Fill.Color = System.Drawing.Color.WhiteSmoke
            ' Draw a border around the text box.
            myTextBox.Line.Color = System.Drawing.Color.Black
            myTextBox.Line.Thickness = 1
            ' Modify text box content.
            Dim textBoxDocument As DevExpress.XtraRichEdit.API.Native.SubDocument = myTextBox.TextBox.Document
            textBoxDocument.AppendText("TextBox Text")
            Dim cp As DevExpress.XtraRichEdit.API.Native.CharacterProperties = textBoxDocument.BeginUpdateCharacters(textBoxDocument.Range.Start, 7)
            cp.ForeColor = System.Drawing.Color.Orange
            cp.FontSize = 24
            textBoxDocument.EndUpdateCharacters(cp)
'#End Region  ' #AddTextBox
        End Sub

        Private Shared Sub InsertRichTextInTextBox(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#InsertRichTextInTextBox"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim myTextBox As DevExpress.XtraRichEdit.API.Native.Shape = document.Shapes(0)
            ' Allow text box resize to fit contents.
            myTextBox.TextBox.HeightRule = DevExpress.XtraRichEdit.API.Native.TextBoxSizeRule.Auto
            Dim boxedDocument As DevExpress.XtraRichEdit.API.Native.SubDocument = myTextBox.TextBox.Document
            Dim appendPosition As Integer = myTextBox.TextBox.Document.Range.[End].ToInt()
            ' Append the second paragraph of the main document to the boxed text.
            Dim newRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = boxedDocument.AppendDocumentContent(document.Paragraphs(CInt((1))).Range)
            boxedDocument.Paragraphs.Insert(newRange.Start)
            ' Insert an image form the main document into the text box.
            boxedDocument.Images.Insert(boxedDocument.CreatePosition(appendPosition), document.Images(CInt((0))).Image.NativeImage)
            ' Resize the image so that its size equals the image in the main document.
            boxedDocument.Images(CInt((0))).Size = document.Images(CInt((0))).Size
'#End Region  ' #InsertRichTextInTextBox
        End Sub

        Private Shared Sub RotateAndResize(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#RotateAndResize"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            For Each s As DevExpress.XtraRichEdit.API.Native.Shape In document.Shapes
                ' Rotate a text box and resize a floating picture.
                If s.TextBox Is Nothing Then
                    s.ScaleX = 0.1F
                    s.ScaleY = 0.1F
                Else
                    s.RotationAngle = 45
                End If
            Next
'#End Region  ' #RotateAndResize
        End Sub

        Private Shared Sub SelectShape(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#SelectShape"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            document.Selection = document.Shapes(CInt((0))).Range
'#End Region  ' #SelectShape
        End Sub
    End Class
End Namespace
