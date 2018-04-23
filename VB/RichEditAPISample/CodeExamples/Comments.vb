Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
    Friend Class CommentsActions

        Private Shared Sub CreateComment(ByVal document As Document)
'            #Region "#CreateComment"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim docRange As DocumentRange = document.Paragraphs(1).Range
            Dim commentAuthor As String = "Maryland B. Clopton"
            Dim commentName As String = String.Empty
            For Each c As Char In commentAuthor
                If Char.IsLetter(c) AndAlso Char.IsUpper(c) Then
                    commentName &= c
                End If
            Next c
            document.Comments.Create(docRange, commentName, commentAuthor)
'            #End Region ' #CreateComment
        End Sub

        Private Shared Sub DeleteComment(ByVal document As Document)
'            #Region "#DeleteComment"
            CommentHelper.CreateComment(document)
            Dim commentCount As Integer = document.Comments.Count
            If document.Comments.Count > 0 Then
                ' Uncomment the line below to delete a comment.
                'document.Comments.Remove(document.Comments[0]);
            End If
'            #End Region ' #DeleteComment
        End Sub

        #Region "#@DeleteComment"
        Private Class CommentHelper
            Public Shared Sub CreateComment(ByVal document As Document)
                document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                Dim docRange As DocumentRange = document.Paragraphs(1).Range
                Dim commentAuthor As String = "Maryland B. Clopton"
                Dim commentName As String = String.Empty
                For Each c As Char In commentAuthor
                    If Char.IsLetter(c) AndAlso Char.IsUpper(c) Then
                        commentName &= c
                    End If
                Next c
                document.Comments.Create(docRange, commentName, commentAuthor)
            End Sub
        End Class
        #End Region ' #@DeleteComment

        Private Shared Sub EditCommentProperties(ByVal document As Document)
'            #Region "#EditCommentProperties"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim commentCount As Integer = document.Comments.Count
            If commentCount > 0 Then
                document.BeginUpdate()
                Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
                comment.Name = "New Name"
                comment.Date = Date.Now
                comment.Author = "New Author"
                document.EndUpdate()
            End If
'            #End Region ' #EditCommentProperties
        End Sub

        Private Shared Sub EditCommentContent(ByVal document As Document)
'            #Region "#EditCommentContent"
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim commentCount As Integer = document.Comments.Count
            If commentCount > 0 Then
                Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
                If comment IsNot Nothing Then
                    Dim commentDocument As SubDocument = comment.BeginUpdate()
                    commentDocument.InsertText(commentDocument.CreatePosition(0), "comment text")
                    commentDocument.Tables.Create(commentDocument.CreatePosition(12), 5, 4)
                    comment.EndUpdate(commentDocument)
                End If
            End If
'            #End Region ' #EditCommentContent
        End Sub
    End Class
End Namespace
