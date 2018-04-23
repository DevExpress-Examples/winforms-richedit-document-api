using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;

namespace RichEditAPISample.CodeExamples
{
    public static class SelectionCollectionActions
    {
        static void SelectSingleRange(Document document)
        {
            #region #SelectSingleRange
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            int startPos = 80;
            int endPos = document.Tables[0].Rows[1].LastCell.ContentRange.Start.ToInt();
            DocumentRange myRange = document.CreateRange(startPos, endPos - startPos);
            document.Selections.Add(myRange);
            #endregion #SelectSingleRange
        }

        static void UnselectRangeExample1(Document document)
        {
            #region #UnselectRangeExample1
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            int startPos = 80;
            int endPos = document.Tables[0].Rows[1].LastCell.ContentRange.Start.ToInt();
            DocumentRange myRange = document.CreateRange(startPos, endPos - startPos);
            document.Selections.Add(myRange);
            DocumentRange unselectRange = document.CreateRange(140, 200);
            document.Selections.Unselect(unselectRange);
            #endregion #UnselectRangeExample1
        }

        static void SelectMultipleRanges(Document document)
        {
            #region #SelectMultipleRanges
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            DocumentRange range1 = document.CreateRange(80, 100);
            DocumentRange range2 = document.CreateRange(300, 100);
            int startPos3 = document.Tables[0].Rows[0].LastCell.ContentRange.Start.ToInt();
            DocumentRange range3 = document.CreateRange(startPos3, 100);
            DocumentRange range4 = document.CreateRange(720, 100);
            document.Selections.Add(new List<DocumentRange>() { range1, range2, range3, range4 });
            #endregion #SelectMultipleRanges
        }

        static void RemoveAtRangeIndex(Document document)
        {
            #region #RemoveAtRangeIndex
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            DocumentRange range1 = document.CreateRange(80, 100);
            DocumentRange range2 = document.CreateRange(300, 100);
            int startPos3 = document.Tables[0].Rows[0].LastCell.ContentRange.Start.ToInt();
            DocumentRange range3 = document.CreateRange(startPos3, 100);
            DocumentRange range4 = document.CreateRange(720, 100);
            document.Selections.Add(new List<DocumentRange>() { range1, range2, range3, range4 });
            document.Selections.RemoveAt(0);
            #endregion #RemoveAtRangeIndex
        }

        static void UnselectRangeExample2(Document document)
        {
            #region #UnselectRangeExample2
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            DocumentRange range1 = document.CreateRange(300, 100);
            int startPos2 = document.Tables[0].Rows[0].LastCell.ContentRange.Start.ToInt();
            DocumentRange range2 = document.CreateRange(startPos2, 100);
            DocumentRange range3 = document.CreateRange(720, 100);
            document.Selections.Add(new List<DocumentRange>() { range1, range2, range3 });
            DocumentRange unselectRange = document.CreateRange(350, 400);
            document.Selections.Unselect(unselectRange);
            #endregion #UnselectRangeExample2
        }

        static void ClearSelections(Document document)
        {
            #region #ClearSelections
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            DocumentRange range1 = document.CreateRange(80, 100);
            DocumentRange range2 = document.CreateRange(300, 100);
            int startPos3 = document.Tables[0].Rows[0].LastCell.ContentRange.Start.ToInt();
            DocumentRange range3 = document.CreateRange(startPos3, 100);
            DocumentRange range4 = document.CreateRange(720, 100);
            document.Selections.Add(new List<DocumentRange>() { range1, range2, range3, range4 });
            document.Selections.Clear();
            #endregion #ClearSelections
        }

        static void SelectTable(Document document)
        {
            #region #SelectTable
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            int startPos = document.Tables[0].FirstRow.FirstCell.ContentRange.Start.ToInt();
            int endPos = document.Tables[0].LastRow.LastCell.ContentRange.End.ToInt() + 1;
            DocumentRange range1 = document.CreateRange(startPos, endPos - startPos);
            document.Selections.Add(range1);
            #endregion #SelectTable
        }

        static void SelectCellsAndMerge(Document document)
        {
            #region #SelectCellsAndMerge
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            Table rootTable = document.Tables[0];
            DocumentPosition position10 = rootTable.Rows[1].Cells[0].Range.Start;
            DocumentPosition position11 = rootTable.Rows[1].Cells[1].Range.Start;
            DocumentPosition position20 = rootTable.Rows[2].Cells[0].Range.Start;
            DocumentRange range1 = document.CreateRange(position10, position11.ToInt() - position10.ToInt());
            DocumentRange range2 = document.CreateRange(position11, position20.ToInt() - position11.ToInt());

            List<DocumentRange> ranges = new List<DocumentRange>() { range1, range2 };
            document.Selections.Add(ranges);

            Comment comment = document.Comments.Create(document.Selection, "");
            SubDocument commentDoc = comment.BeginUpdate();
            commentDoc.AppendText(String.Format("\r\nSelectionCollection \r\ncontains {0} item(s).", document.Selections.Count));
            comment.EndUpdate(commentDoc);
            #endregion #SelectCellsAndMerge
        }

        static void SelectAndMerge(Document document)
        {
            #region #SelectAndMerge
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            DocumentRange range1 = document.CreateRange(document.Range.Start, 12);
            DocumentRange range2 = document.CreateRange(document.Range.Start.ToInt() + 12, 9);
            DocumentRange range3 = document.CreateRange(document.Range.Start.ToInt() + 21, 3);

            List<DocumentRange> ranges = new List<DocumentRange>() { range1, range2 };
            document.Selections.Add(ranges);

            Comment comment = document.Comments.Create(document.Selection, "");
            SubDocument commentDoc = comment.BeginUpdate();
            commentDoc.AppendText(String.Format("\r\nSelectionCollection \r\ncontains {0} item(s).", document.Selections.Count));
            comment.EndUpdate(commentDoc);
            #endregion #SelectAndMerge
        }

        static void SelectCellsAndSplit(Document document)
        {
            #region #SelectCellsAndSplit
            document.LoadDocument("SelectionCollection.docx", DocumentFormat.OpenXml);
            Table rootTable = document.Tables[0];
            DocumentPosition position10 = rootTable.Rows[0].Cells[1].Range.Start;
            DocumentPosition position11 = rootTable.Rows[3].LastCell.Range.End;

            DocumentRange range1 = document.CreateRange(position10, position11.ToInt() - position10.ToInt());
            document.Selections.Add(range1);

            Comment comment = document.Comments.Create(document.Selection, "");
            SubDocument commentDoc = comment.BeginUpdate();
            commentDoc.AppendText(String.Format("\r\nSelectionCollection \r\ncontains {0} item(s).", document.Selections.Count));
            comment.EndUpdate(commentDoc);
            #endregion #SelectCellsAndSplit
        }
        
    }
}
