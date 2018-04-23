using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class CommentsActions    {

        static void CreateComment(Document document)
        {
            #region #CreateComment
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            DocumentRange docRange = document.Paragraphs[1].Range;
            string commentAuthor = "Maryland B. Clopton";
            string commentName = String.Empty;
            foreach (char c in commentAuthor)
            {
                if (char.IsLetter(c) && char.IsUpper(c)) commentName += c;
            }
            document.Comments.Create(docRange, commentName, commentAuthor);
            #endregion #CreateComment
        }

        static void DeleteComment(Document document)
        {
            #region #DeleteComment
            CommentHelper.CreateComment(document);
            int commentCount = document.Comments.Count;
            if (document.Comments.Count > 0)
            {
                // Uncomment the line below to delete a comment.
                //document.Comments.Remove(document.Comments[0]);
            }
            #endregion #DeleteComment
        }

        #region #@DeleteComment
        class CommentHelper
        {
            public static void CreateComment(Document document)
            {
                document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
                DocumentRange docRange = document.Paragraphs[1].Range;
                string commentAuthor = "Maryland B. Clopton";
                string commentName = String.Empty;
                foreach (char c in commentAuthor)
                {
                    if (char.IsLetter(c) && char.IsUpper(c)) commentName += c;
                }
                document.Comments.Create(docRange, commentName, commentAuthor);
            }
        }
        #endregion #@DeleteComment

        static void EditCommentProperties(Document document)
        {
            #region #EditCommentProperties
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            int commentCount = document.Comments.Count;
            if (commentCount > 0)
            {
                document.BeginUpdate();
                DevExpress.XtraRichEdit.API.Native.Comment comment = document.Comments[document.Comments.Count - 1];
                comment.Name = "New Name";
                comment.Date = DateTime.Now;
                comment.Author = "New Author";
                document.EndUpdate();
            }
            #endregion #EditCommentProperties
        }

        static void EditCommentContent(Document document)
        {
            #region #EditCommentContent
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            int commentCount = document.Comments.Count;
            if (commentCount > 0)
            {
                DevExpress.XtraRichEdit.API.Native.Comment comment = document.Comments[document.Comments.Count - 1];
                if (comment != null)
                {
                    SubDocument commentDocument = comment.BeginUpdate();
                    commentDocument.InsertText(commentDocument.CreatePosition(0), "comment text");
                    commentDocument.Tables.Create(commentDocument.CreatePosition(12), 5, 4);
                    comment.EndUpdate(commentDocument);
                }
            }
            #endregion #EditCommentContent
        }
    }
}
