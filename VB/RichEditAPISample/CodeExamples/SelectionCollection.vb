Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic

Namespace RichEditAPISample.CodeExamples
    Public NotInheritable Class SelectionCollectionActions

        Private Sub New()
        End Sub

        Private Shared Sub SelectSingleRange(ByVal document As Document)
'            #Region "#SelectSingleRange"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim startPos As Integer = 80
            Dim endPos As Integer = document.Tables(0).Rows(1).LastCell.ContentRange.Start.ToInt()
            Dim myRange As DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(myRange)
'            #End Region ' #SelectSingleRange
        End Sub

        Private Shared Sub UnselectRangeExample1(ByVal document As Document)
'            #Region "#UnselectRangeExample1"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim startPos As Integer = 80
            Dim endPos As Integer = document.Tables(0).Rows(1).LastCell.ContentRange.Start.ToInt()
            Dim myRange As DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(myRange)
            Dim unselectRange As DocumentRange = document.CreateRange(140, 200)
            document.Selections.Unselect(unselectRange)
'            #End Region ' #UnselectRangeExample1
        End Sub

        Private Shared Sub SelectMultipleRanges(ByVal document As Document)
'            #Region "#SelectMultipleRanges"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim range1 As DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(0).Rows(0).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New List(Of DocumentRange)() From {range1, range2, range3, range4})
'            #End Region ' #SelectMultipleRanges
        End Sub

        Private Shared Sub RemoveAtRangeIndex(ByVal document As Document)
'            #Region "#RemoveAtRangeIndex"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim range1 As DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(0).Rows(0).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New List(Of DocumentRange)() From {range1, range2, range3, range4})
            document.Selections.RemoveAt(0)
'            #End Region ' #RemoveAtRangeIndex
        End Sub

        Private Shared Sub UnselectRangeExample2(ByVal document As Document)
'            #Region "#UnselectRangeExample2"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim range1 As DocumentRange = document.CreateRange(300, 100)
            Dim startPos2 As Integer = document.Tables(0).Rows(0).LastCell.ContentRange.Start.ToInt()
            Dim range2 As DocumentRange = document.CreateRange(startPos2, 100)
            Dim range3 As DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New List(Of DocumentRange)() From {range1, range2, range3})
            Dim unselectRange As DocumentRange = document.CreateRange(350, 400)
            document.Selections.Unselect(unselectRange)
'            #End Region ' #UnselectRangeExample2
        End Sub

        Private Shared Sub ClearSelections(ByVal document As Document)
'            #Region "#ClearSelections"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim range1 As DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(0).Rows(0).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New List(Of DocumentRange)() From {range1, range2, range3, range4})
            document.Selections.Clear()
'            #End Region ' #ClearSelections
        End Sub

        Private Shared Sub SelectTable(ByVal document As Document)
'            #Region "#SelectTable"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim startPos As Integer = document.Tables(0).FirstRow.FirstCell.ContentRange.Start.ToInt()
            Dim endPos As Integer = document.Tables(0).LastRow.LastCell.ContentRange.End.ToInt() + 1
            Dim range1 As DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(range1)
'            #End Region ' #SelectTable
        End Sub

        Private Shared Sub SelectCellsAndMerge(ByVal document As Document)
'            #Region "#SelectCellsAndMerge"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim rootTable As Table = document.Tables(0)
            Dim position10 As DocumentPosition = rootTable.Rows(1).Cells(0).Range.Start
            Dim position11 As DocumentPosition = rootTable.Rows(1).Cells(1).Range.Start
            Dim position20 As DocumentPosition = rootTable.Rows(2).Cells(0).Range.Start
            Dim range1 As DocumentRange = document.CreateRange(position10, position11.ToInt() - position10.ToInt())
            Dim range2 As DocumentRange = document.CreateRange(position11, position20.ToInt() - position11.ToInt())

            Dim ranges As New List(Of DocumentRange)() From {range1, range2}
            document.Selections.Add(ranges)

            Dim comment As Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(String.Format(ControlChars.CrLf & "SelectionCollection " & ControlChars.CrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
'            #End Region ' #SelectCellsAndMerge
        End Sub

        Private Shared Sub SelectAndMerge(ByVal document As Document)
'            #Region "#SelectAndMerge"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim range1 As DocumentRange = document.CreateRange(document.Range.Start, 12)
            Dim range2 As DocumentRange = document.CreateRange(document.Range.Start.ToInt() + 12, 9)
            Dim range3 As DocumentRange = document.CreateRange(document.Range.Start.ToInt() + 21, 3)

            Dim ranges As New List(Of DocumentRange)() From {range1, range2}
            document.Selections.Add(ranges)

            Dim comment As Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(String.Format(ControlChars.CrLf & "SelectionCollection " & ControlChars.CrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
'            #End Region ' #SelectAndMerge
        End Sub

        Private Shared Sub SelectCellsAndSplit(ByVal document As Document)
'            #Region "#SelectCellsAndSplit"
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml)
            Dim rootTable As Table = document.Tables(0)
            Dim position10 As DocumentPosition = rootTable.Rows(0).Cells(1).Range.Start
            Dim position11 As DocumentPosition = rootTable.Rows(3).LastCell.Range.End

            Dim range1 As DocumentRange = document.CreateRange(position10, position11.ToInt() - position10.ToInt())
            document.Selections.Add(range1)

            Dim comment As Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(String.Format(ControlChars.CrLf & "SelectionCollection " & ControlChars.CrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
'            #End Region ' #SelectCellsAndSplit
        End Sub

    End Class
End Namespace
