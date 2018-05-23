Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
    Public NotInheritable Class RangeActions

        Private Sub New()
        End Sub

        Private Shared Sub InsertTextInRange(ByVal doc As Document)
'            #Region "#InsertTextInRange"
            doc.AppendText("ABCDEFGH")
            Dim r1 As DocumentRange = doc.CreateRange(1, 3)
            Dim pos1 As DocumentPosition = doc.CreatePosition(2)
            Dim r2 As DocumentRange = doc.InsertText(pos1, "NewText")
            Dim s1 As String = String.Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.End)
            Dim s2 As String = String.Format("Range r2 starts at {0}, ends at {1}", r2.Start, r2.End)
            doc.AppendParagraph()
            doc.AppendText(s1)
            doc.AppendParagraph()
            doc.AppendText(s2)
'            #End Region ' #InsertTextInRange
        End Sub

        Private Shared Sub AppendTextToRange(ByVal doc As Document)
'            #Region "#AppendTextToRange"
            doc.AppendText("ABCDEFGH")
            Dim r1 As DocumentRange = doc.AppendText("X")
            Dim s1 As String = String.Format("Range r1 starts at {0}, ends at {1}", r1.Start, r1.End)
            doc.AppendText("Y")
            doc.AppendText("Z")
            Dim s2 As String = String.Format("Currently range r1 starts at {0}, ends at {1}", r1.Start, r1.End)
            doc.AppendParagraph()
            doc.AppendText(s1)
            doc.AppendParagraph()
            doc.AppendText(s2)
'            #End Region ' #AppendTextToRange
        End Sub


    End Class
End Namespace
