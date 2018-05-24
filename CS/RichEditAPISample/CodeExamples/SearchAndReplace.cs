using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Linq;

namespace RichEditAPISample.CodeExamples
{
    class SearchAndReplaceActions
    {
        static void FindSixLetterWords(Document document)
        {
            #region #FindSixLetterWords
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            document.InsertSection(document.Range.Start);
            // Specify a regular expression that will find all six letter words.
            System.Text.RegularExpressions.Regex expr =
                new System.Text.RegularExpressions.Regex("\\b\\w{6}\\b");
            System.Collections.Specialized.StringCollection sixLetterWords =
                new System.Collections.Specialized.StringCollection();
            // Perform the search.
            DocumentRange[] found = document.FindAll(expr);
            foreach (DocumentRange r in found)
            {
                sixLetterWords.Add(document.GetText(r));
            }
            document.BeginUpdate();
            // Insert an ordered list of non-repetitive words in the beginning of the document.
            var distinctWords = sixLetterWords.Cast<string>().Distinct().OrderByDescending(s => s);
            foreach (var s in distinctWords)
            {
                document.InsertText(document.Range.Start, s.ToString() + Environment.NewLine);
            }
            document.EndUpdate();
            #endregion #FindSixLetterWords
        }

        static void FindDatesInSpecificFormat(Document document)
        {
            #region #FindDatesInSpecificFormat
            document.AppendText("12\\14\\2014" + Environment.NewLine);
            IRegexSearchResult result;
            string pattern = @"(?<mm>\d{2}).(?<dd>\d{2}).(?<yyyy>\d{4})";
            System.Text.RegularExpressions.Regex myRegEx = 
                new System.Text.RegularExpressions.Regex(pattern);

            result = document.StartSearch(myRegEx);
            if (result.FindNext())
            {
                string dayFound = result.Match.Groups[2].Value;
                string monthFound = result.Match.Groups[1].Value;
                string yearFound = result.Match.Groups[3].Value;
                document.AppendText(String.Format("Found a date that is the {0} day of the {1} month of the {2} year.",
                    dayFound, monthFound, yearFound));
            }
            #endregion #FindDatesInSpecificFormat
        }

        static void RemoveBlankLines(Document document)
        {
            #region #RemoveBlankLines
            document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            string pattern = @"((?<=^)|(?<=\n))\n";
            string replacementString = string.Empty;
            System.Text.RegularExpressions.Regex myRegEx = 
                new System.Text.RegularExpressions.Regex(pattern);
            int count = document.ReplaceAll(myRegEx, replacementString);
            System.Windows.Forms.MessageBox.Show(String.Format("{0} blank lines have been removed",count));
            #endregion #RemoveBlankLines
        }

        static void ChangeDateFormat(Document document)
        {
            #region #ChangeDateFormat
            document.AppendText("12\\14\\2014" + Environment.NewLine);
            string pattern = @"(?<mm>\d{2}).(?<dd>\d{2}).(?<yyyy>\d{4})";
            string replacementString = @"${yyyy}-${mm}-${dd} or ${dd}.${mm}.${yyyy}";
            System.Text.RegularExpressions.Regex myRegEx =
                new System.Text.RegularExpressions.Regex(pattern);
            int count = document.ReplaceAll(myRegEx, replacementString);
            System.Windows.Forms.MessageBox.Show(String.Format("We've done {0} replacement(s).", count));
            #endregion #ChangeDateFormat
        }
    }
}
