﻿Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
	Friend Class ShapesActions
		Private Shared Sub AddFloatingPicture(ByVal document As Document)
'			#Region "#AddFloatingPicture"
			document.AppendText("Line One" & vbLf & "Line Two" & vbLf & "Line Three")
			Dim myPicture As Shape = document.Shapes.InsertPicture(document.CreatePosition(15), System.Drawing.Image.FromFile("beverages.png"))
			myPicture.HorizontalAlignment = ShapeHorizontalAlignment.Center
'			#End Region ' #AddFloatingPicture
		End Sub

		Private Shared Sub FloatingPictureOffset(ByVal document As Document)
'			#Region "#FloatingPictureOffset"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			document.Unit = DevExpress.Office.DocumentUnit.Centimeter
			Dim myPicture As Shape = document.Shapes(1)
			' Clear the qualitative positioning to allow positioning by specifying the numerical offset.
			myPicture.HorizontalAlignment = ShapeHorizontalAlignment.None
			myPicture.VerticalAlignment = ShapeVerticalAlignment.None
			' Specify the reference item for positioning.
			myPicture.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.LeftMargin
			myPicture.RelativeVerticalPosition = ShapeRelativeVerticalPosition.TopMargin
			' Specify the offset value.
			myPicture.Offset = New System.Drawing.PointF(4.5F, 2.0F)
'			#End Region ' #FloatingPictureOffset
		End Sub

		Private Shared Sub ChangeZorderAndWrapping(ByVal document As Document)
'			#Region "#ChangeZorderAndWrapping"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			Dim myPicture As Shape = document.Shapes(1)
			myPicture.VerticalAlignment = ShapeVerticalAlignment.Top
			myPicture.ZOrder = document.Shapes(0).ZOrder - 1
			myPicture.TextWrapping = TextWrappingType.BehindText
'			#End Region ' #ChangeZorderAndWrapping
		End Sub

		Private Shared Sub AddTextBox(ByVal document As Document)
'			#Region "#AddTextBox"
			document.AppendText("Line One" & vbLf & "Line Two" & vbLf & "Line Three")
			Dim myTextBox As Shape = document.Shapes.InsertTextBox(document.CreatePosition(15))
			myTextBox.HorizontalAlignment = ShapeHorizontalAlignment.Center
			' Specify the text box background color.
			myTextBox.Fill.Color = System.Drawing.Color.WhiteSmoke
			' Draw a border around the text box.
			myTextBox.Line.Color = System.Drawing.Color.Black
			myTextBox.Line.Thickness = 1
			' Modify text box content.
			Dim textBoxDocument As SubDocument = myTextBox.ShapeFormat.TextBox.Document
			textBoxDocument.AppendText("TextBox Text")
			Dim cp As CharacterProperties = textBoxDocument.BeginUpdateCharacters(textBoxDocument.Range.Start, 7)
			cp.ForeColor = System.Drawing.Color.Orange
			cp.FontSize = 24
			textBoxDocument.EndUpdateCharacters(cp)
'			#End Region ' #AddTextBox
		End Sub

		Private Shared Sub InsertRichTextInTextBox(ByVal document As Document)
'			#Region "#InsertRichTextInTextBox"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			Dim myTextBox As Shape = document.Shapes(0)
			' Allow text box resize to fit contents.
			myTextBox.ShapeFormat.TextBox.HeightRule = TextBoxSizeRule.Auto
			Dim boxedDocument As SubDocument = myTextBox.ShapeFormat.TextBox.Document
			Dim appendPosition As Integer = myTextBox.ShapeFormat.TextBox.Document.Range.End.ToInt()
			' Append the second paragraph of the main document to the boxed text.
			Dim newRange As DocumentRange = boxedDocument.AppendDocumentContent(document.Paragraphs(1).Range)
			boxedDocument.Paragraphs.Insert(newRange.Start)
			' Insert an image form the main document into the text box.
			boxedDocument.Images.Insert(boxedDocument.CreatePosition(appendPosition), document.Images(0).Image.NativeImage)
			' Resize the image so that its size equals the image in the main document.
			boxedDocument.Images(0).Size = document.Images(0).Size
'			#End Region ' #InsertRichTextInTextBox
		End Sub

		Private Shared Sub RotateAndResize(ByVal document As Document)
'			#Region "#RotateAndResize"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			For Each s As Shape In document.Shapes
			 ' Rotate a text box and resize a floating picture.
				If s.Type = ShapeType.Picture Then
					s.RotationAngle = 45
				Else
					s.ScaleX = 0.1F
					s.ScaleY = 0.1F
				End If
			Next s
'			#End Region ' #RotateAndResize
		End Sub

		Private Shared Sub SelectShape(ByVal document As Document)
'			#Region "#SelectShape"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			document.Selection = document.Shapes(0).Range
'			#End Region ' #SelectShape
		End Sub
	End Class
End Namespace
