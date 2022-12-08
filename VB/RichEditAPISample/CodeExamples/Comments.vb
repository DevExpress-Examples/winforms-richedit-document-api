Imports DevExpress.XtraRichEdit.API.Native
Imports System

Namespace RichEditAPISample.CodeExamples

    Friend Class CommentsActions

        Private Shared Sub CreateComment(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateComment"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim docRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((2))).Range
            Dim commentAuthor As String = "Johnson Alphonso D"
            document.Comments.Create(docRange, commentAuthor, System.DateTime.Now)
#End Region  ' #CreateComment
        End Sub

        Private Shared Sub CreateNestedComment(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateNestedComment"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            If document.Comments.Count > 0 Then
                Dim resRanges As DevExpress.XtraRichEdit.API.Native.DocumentRange() = document.FindAll("trump", DevExpress.XtraRichEdit.API.Native.SearchOptions.None, document.Comments(CInt((1))).Range)
                If resRanges.Length > 0 Then
                    Dim newComment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments.Create("Vicars Anny", document.Comments(1))
                    newComment.[Date] = System.DateTime.Now
                End If
            End If
#End Region  ' #CreateNestedComment
        End Sub

        Private Shared Sub DeleteComment(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#DeleteComment"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            If document.Comments.Count > 0 Then
                document.Comments.Remove(document.Comments(0))
            End If
#End Region  ' #DeleteComment
        End Sub

        Private Shared Sub EditCommentProperties(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#EditCommentProperties"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim commentCount As Integer = document.Comments.Count
            If commentCount > 0 Then
                document.BeginUpdate()
                Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
                comment.Name = "New Name"
                comment.[Date] = System.DateTime.Now
                comment.Author = "New Author"
                document.EndUpdate()
            End If
#End Region  ' #EditCommentProperties
        End Sub

        Private Shared Sub EditCommentContent(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#EditCommentContent"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim commentCount As Integer = document.Comments.Count
            If commentCount > 0 Then
                Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments(document.Comments.Count - 1)
                If comment IsNot Nothing Then
                    Dim commentDocument As DevExpress.XtraRichEdit.API.Native.SubDocument = comment.BeginUpdate()
                    commentDocument.InsertText(commentDocument.CreatePosition(0), "some text")
                    commentDocument.Tables.Create(commentDocument.CreatePosition(9), 5, 4)
                    comment.EndUpdate(commentDocument)
                End If
            End If
#End Region  ' #EditCommentContent
        End Sub
    End Class
End Namespace
