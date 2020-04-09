Imports DevExpress.XtraRichEdit.API.Native
Imports System

Namespace RichEditAPISample.CodeExamples
	Friend Class CommentsActions

		Private Shared Sub CreateComment(ByVal document As Document)
'			#Region "#CreateComment"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			Dim docRange As DocumentRange = document.Paragraphs(2).Range
			Dim commentAuthor As String = "Johnson Alphonso D"
			document.Comments.Create(docRange, commentAuthor, DateTime.Now)
'			#End Region ' #CreateComment
		End Sub

		Private Shared Sub CreateNestedComment(ByVal document As Document)
'			#Region "#CreateNestedComment"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			If document.Comments.Count > 0 Then
				Dim resRanges() As DocumentRange = document.FindAll("trump", SearchOptions.None, document.Comments(1).Range)
				If resRanges.Length > 0 Then
					Dim newComment As Comment = document.Comments.Create("Vicars Anny", document.Comments(1))
					newComment.Date = DateTime.Now
				End If
			End If
'			#End Region ' #CreateNestedComment
		End Sub

		Private Shared Sub DeleteComment(ByVal document As Document)
'			#Region "#DeleteComment"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			If document.Comments.Count > 0 Then
				document.Comments.Remove(document.Comments(0))
			End If
'			#End Region ' #DeleteComment
		End Sub

		Private Shared Sub EditCommentProperties(ByVal document As Document)
'			#Region "#EditCommentProperties"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			Dim commentCount As Integer = document.Comments.Count
			If commentCount > 0 Then
				document.BeginUpdate()
				Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
				comment.Name = "New Name"
				comment.Date = DateTime.Now
				comment.Author = "New Author"
				document.EndUpdate()
			End If
'			#End Region ' #EditCommentProperties
		End Sub

		Private Shared Sub EditCommentContent(ByVal document As Document)
'			#Region "#EditCommentContent"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			Dim commentCount As Integer = document.Comments.Count
			If commentCount > 0 Then
				Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
				If comment IsNot Nothing Then
					Dim commentDocument As SubDocument = comment.BeginUpdate()
					commentDocument.InsertText(commentDocument.CreatePosition(0), "some text")
					commentDocument.Tables.Create(commentDocument.CreatePosition(9), 5, 4)
					comment.EndUpdate(commentDocument)
				End If
			End If
'			#End Region ' #EditCommentContent
		End Sub
	End Class
End Namespace
