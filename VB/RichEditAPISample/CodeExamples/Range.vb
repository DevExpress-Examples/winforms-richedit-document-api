Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System

Namespace RichEditAPISample.CodeExamples

    Public Module RangeActions

        Private Sub SelectTextInRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectTextInRange"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim myStart As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(69)
            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(myStart, 216)
            document.Selection = myRange
#End Region  ' #SelectTextInRange
        End Sub

        Private Sub InsertTextAtCaretPosition(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#InsertTextAtCaretPosition"
            Dim pos As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CaretPosition
            Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = pos.BeginUpdateDocument()
            doc.InsertText(pos, " INSERTED TEXT ")
            pos.EndUpdateDocument(doc)
#End Region  ' #InsertTextAtCaretPosition
        End Sub

        Private Sub InsertTextInRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#InsertTextInRange"
            document.AppendText("ABCDEFGH")
            Dim r1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(1, 3)
            Dim pos1 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(2)
            Dim r2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.InsertText(pos1, ">>NewText<<")
            Dim s1 As String = System.[String].Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            Dim s2 As String = System.[String].Format("Range r2 starts at {0}, ends at {1}", r2.Start, r2.[End])
            document.Paragraphs.Append()
            document.AppendText(s1)
            document.Paragraphs.Append()
            document.AppendText(s2)
#End Region  ' #InsertTextInRange
        End Sub

        Private Sub AppendTextToRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#AppendTextToRange"
            document.AppendText("abcdefgh")
            Dim r1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.AppendText("X")
            Dim s1 As String = System.[String].Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            document.AppendText("Y")
            document.AppendText("Z")
            Dim s2 As String = System.[String].Format("Currently range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            document.Paragraphs.Append()
            document.AppendText(s1)
            document.Paragraphs.Append()
            document.AppendText(s2)
#End Region  ' #AppendTextToRange
        End Sub

        Private Sub CopyAndPasteRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CopyAndPasteRange"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((0))).Range
            document.Copy(myRange)
            document.Paste(DevExpress.XtraRichEdit.DocumentFormat.PlainText)
#End Region  ' #CopyAndPasteRange
        End Sub

        Private Sub AppendToParagraph(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#AppendToParagraph"
            document.BeginUpdate()
            document.AppendText("First Paragraph" & Global.Microsoft.VisualBasic.Constants.vbLf & "Second Paragraph" & Global.Microsoft.VisualBasic.Constants.vbLf & "Third Paragraph")
            document.EndUpdate()
            Dim pos As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CaretPosition
            Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = pos.BeginUpdateDocument()
            Dim par As DevExpress.XtraRichEdit.API.Native.Paragraph = doc.Paragraphs.[Get](pos)
            Dim newPos As DevExpress.XtraRichEdit.API.Native.DocumentPosition = doc.CreatePosition(par.Range.[End].ToInt() - 1)
            doc.InsertText(newPos, "<<Appended to Paragraph End>>")
            pos.EndUpdateDocument(doc)
#End Region  ' #AppendToParagraph
        End Sub
    End Module
End Namespace
