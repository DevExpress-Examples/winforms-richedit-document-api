Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic

Namespace RichEditAPISample.CodeExamples

    Public Module SelectionCollectionActions

        Private Sub SelectSingleRange(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectSingleRange"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim startPos As Integer = 80
            Dim endPos As Integer = document.Tables(CInt((0))).Rows(CInt((1))).LastCell.ContentRange.Start.ToInt()
            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(myRange)
#End Region  ' #SelectSingleRange
        End Sub

        Private Sub UnselectRangeExample1(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#UnselectRangeExample1"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim startPos As Integer = 80
            Dim endPos As Integer = document.Tables(CInt((0))).Rows(CInt((1))).LastCell.ContentRange.Start.ToInt()
            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(myRange)
            Dim unselectRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(140, 200)
            document.Selections.Unselect(unselectRange)
#End Region  ' #UnselectRangeExample1
        End Sub

        Private Sub SelectMultipleRanges(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectMultipleRanges"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(CInt((0))).Rows(CInt((0))).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2, range3, range4})
#End Region  ' #SelectMultipleRanges
        End Sub

        Private Sub RemoveAtRangeIndex(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#RemoveAtRangeIndex"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(CInt((0))).Rows(CInt((0))).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2, range3, range4})
            document.Selections.RemoveAt(0)
#End Region  ' #RemoveAtRangeIndex
        End Sub

        Private Sub UnselectRangeExample2(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#UnselectRangeExample2"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(300, 100)
            Dim startPos2 As Integer = document.Tables(CInt((0))).Rows(CInt((0))).LastCell.ContentRange.Start.ToInt()
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos2, 100)
            Dim range3 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2, range3})
            Dim unselectRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(350, 400)
            document.Selections.Unselect(unselectRange)
#End Region  ' #UnselectRangeExample2
        End Sub

        Private Sub ClearSelections(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ClearSelections"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(80, 100)
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(300, 100)
            Dim startPos3 As Integer = document.Tables(CInt((0))).Rows(CInt((0))).LastCell.ContentRange.Start.ToInt()
            Dim range3 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos3, 100)
            Dim range4 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(720, 100)
            document.Selections.Add(New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2, range3, range4})
            document.Selections.Clear()
#End Region  ' #ClearSelections
        End Sub

        Private Sub SelectTable(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectTable"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim startPos As Integer = document.Tables(CInt((0))).FirstRow.FirstCell.ContentRange.Start.ToInt()
            Dim endPos As Integer = document.Tables(CInt((0))).LastRow.LastCell.ContentRange.[End].ToInt() + 1
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(startPos, endPos - startPos)
            document.Selections.Add(range1)
#End Region  ' #SelectTable
        End Sub

        Private Sub SelectCellsAndMerge(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectCellsAndMerge"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim rootTable As DevExpress.XtraRichEdit.API.Native.Table = document.Tables(0)
            Dim position10 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = rootTable.Rows(CInt((1))).Cells(CInt((0))).Range.Start
            Dim position11 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = rootTable.Rows(CInt((1))).Cells(CInt((1))).Range.Start
            Dim position20 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = rootTable.Rows(CInt((2))).Cells(CInt((0))).Range.Start
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(position10, position11.ToInt() - position10.ToInt())
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(position11, position20.ToInt() - position11.ToInt())
            Dim ranges As System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange) = New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2}
            document.Selections.Add(ranges)
            Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As DevExpress.XtraRichEdit.API.Native.SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(System.[String].Format(Global.Microsoft.VisualBasic.Constants.vbCrLf & "SelectionCollection " & Global.Microsoft.VisualBasic.Constants.vbCrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
#End Region  ' #SelectCellsAndMerge
        End Sub

        Private Sub SelectAndMerge(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectAndMerge"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(document.Range.Start, 12)
            Dim range2 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(document.Range.Start.ToInt() + 12, 9)
            Dim range3 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(document.Range.Start.ToInt() + 21, 3)
            Dim ranges As System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange) = New System.Collections.Generic.List(Of DevExpress.XtraRichEdit.API.Native.DocumentRange)() From {range1, range2}
            document.Selections.Add(ranges)
            Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As DevExpress.XtraRichEdit.API.Native.SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(System.[String].Format(Global.Microsoft.VisualBasic.Constants.vbCrLf & "SelectionCollection " & Global.Microsoft.VisualBasic.Constants.vbCrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
#End Region  ' #SelectAndMerge
        End Sub

        Private Sub SelectCellsAndSplit(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#SelectCellsAndSplit"
            document.LoadDocument("Documents//SelectionCollection.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim rootTable As DevExpress.XtraRichEdit.API.Native.Table = document.Tables(0)
            Dim position10 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = rootTable.Rows(CInt((0))).Cells(CInt((1))).Range.Start
            Dim position11 As DevExpress.XtraRichEdit.API.Native.DocumentPosition = rootTable.Rows(CInt((3))).LastCell.Range.[End]
            Dim range1 As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.CreateRange(position10, position11.ToInt() - position10.ToInt())
            document.Selections.Add(range1)
            Dim comment As DevExpress.XtraRichEdit.API.Native.Comment = document.Comments.Create(document.Selection, "")
            Dim commentDoc As DevExpress.XtraRichEdit.API.Native.SubDocument = comment.BeginUpdate()
            commentDoc.AppendText(System.[String].Format(Global.Microsoft.VisualBasic.Constants.vbCrLf & "SelectionCollection " & Global.Microsoft.VisualBasic.Constants.vbCrLf & "contains {0} item(s).", document.Selections.Count))
            comment.EndUpdate(commentDoc)
#End Region  ' #SelectCellsAndSplit
        End Sub
    End Module
End Namespace
