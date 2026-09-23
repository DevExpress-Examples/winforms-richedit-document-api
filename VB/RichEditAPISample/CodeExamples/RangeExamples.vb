Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Public Module RangeActions

        Private Sub InsertTextInRange(ByVal doc As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#InsertTextInRange"
            doc.AppendText("ABCDEFGH")
            Dim r1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = doc.CreateRange(1, 3)
            Dim pos1 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = doc.CreatePosition(2)
            Dim r2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = doc.InsertText(pos1, "NewText")
            Dim s1 As String = System.[String].Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            Dim s2 As String = System.[String].Format("Range r2 starts at {0}, ends at {1}", r2.Start, r2.[End])
            doc.AppendParagraph()
            doc.AppendText(s1)
            doc.AppendParagraph()
            doc.AppendText(s2)
'#End Region  ' #InsertTextInRange
        End Sub

        Private Sub AppendTextToRange(ByVal doc As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#AppendTextToRange"
            doc.AppendText("ABCDEFGH")
            Dim r1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = doc.AppendText("X")
            Dim s1 As String = System.[String].Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            doc.AppendText("Y")
            doc.AppendText("Z")
            Dim s2 As String = System.[String].Format("Currently range r1 starts at {0}, ends at {1}", r1.Start, r1.[End])
            doc.AppendParagraph()
            doc.AppendText(s1)
            doc.AppendParagraph()
            doc.AppendText(s2)
'#End Region  ' #AppendTextToRange
        End Sub
    End Module
End Namespace
