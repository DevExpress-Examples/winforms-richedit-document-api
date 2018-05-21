using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples
{
    class ListActions
    {
        static void CreateBulletedList(Document document)
        {
            #region #CreateBulletedList
            document.BeginUpdate();
            // Define an abstract list that is the pattern for lists used in the document.
            AbstractNumberingList list = document.AbstractNumberingLists.Add();
            list.NumberingType = NumberingType.Bullet;
            // Specify parameters for each list level.
            ListLevel level = list.Levels[0];
            CreateBulletedListHelper.AdjustLevelProperties(level, 100, 75, NumberingFormat.Decimal, new string('\u00B7', 1));
            level = list.Levels[1];
            CreateBulletedListHelper.AdjustLevelProperties(level, 300, 150, NumberingFormat.DecimalEnclosedParenthses, new string('\u006F', 1));
            level = list.Levels[2];
            CreateBulletedListHelper.AdjustLevelProperties(level, 450, 220, NumberingFormat.UpperRoman, new string('\u00B7', 1));
            // Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0);
            document.EndUpdate();

            document.AppendText("Line 1\nLine 2\nLine 3");
            // Convert paragraphs to list items.
            document.BeginUpdate();
            ParagraphCollection paragraphs = document.Paragraphs;
            foreach (Paragraph pgf in paragraphs) {
                pgf.ListIndex = 0;
                pgf.ListLevel = 0;
            }
            paragraphs[1].ListLevel = 1;
            paragraphs[2].ListLevel = 2;
            document.EndUpdate();
            #endregion #CreateBulletedList
        }
        #region #@CreateBulletedList
        class CreateBulletedListHelper {
            public static void AdjustLevelProperties(ListLevel level, int leftIndent, int firstLineIndent, NumberingFormat format, string displayFormat) {
                level.CharacterProperties.FontName = "Symbol";
                level.ParagraphProperties.LeftIndent = leftIndent;
                level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
                level.ParagraphProperties.FirstLineIndent = firstLineIndent;
                level.Start = 1;
                level.NumberingFormat = format;
                level.DisplayFormatString = displayFormat;
            }
        }
        #endregion #@CreateBulletedList

        static void CreateNumberedList(Document document)
        {
            #region #CreateNumberedList
            document.BeginUpdate();
            // Define an abstract list that is the pattern for lists used in the document.
            AbstractNumberingList list = document.AbstractNumberingLists.Add();
            list.NumberingType = NumberingType.MultiLevel;
            // Specify parameters for each list level.
            ListLevel level = list.Levels[0];
            CreateNumberedListHelper.AdjustLevelProperties(level, 150, 75, NumberingFormat.Decimal, "{0}");
            level = list.Levels[1];
            CreateNumberedListHelper.AdjustLevelProperties(level, 300, 150, NumberingFormat.DecimalEnclosedParenthses, "{0}→{1}");
            level = list.Levels[2];
            CreateNumberedListHelper.AdjustLevelProperties(level, 450, 220, NumberingFormat.UpperRoman, "{0}→{1}→{2}");
            // Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0);
            document.EndUpdate();

            document.AppendText("Line one\nLine two\nLine three\nLine four");
            // Convert all paragraphs to list items of level 0.
            document.BeginUpdate();
            ParagraphCollection paragraphs = document.Paragraphs;
            foreach (Paragraph pgf in paragraphs)
            {
                pgf.ListIndex = 0;
                pgf.ListLevel = 0;
            }
            // Specify a different level for a certain paragraph.
            paragraphs[1].ListLevel = 1;
            document.EndUpdate();
            #endregion #CreateNumberedList
        }
        #region #@CreateNumberedList
        class CreateNumberedListHelper {
            public static void AdjustLevelProperties(ListLevel level, int leftIndent, int firstLineIndent, NumberingFormat format, string displayFormat) {
                  level.ParagraphProperties.LeftIndent = leftIndent;
                level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging;
                level.ParagraphProperties.FirstLineIndent = firstLineIndent;
                level.Start = 1;
                level.NumberingFormat = format;
                level.DisplayFormatString = displayFormat;
            }
        }
        #endregion #@CreateNumberedList


    }
}
