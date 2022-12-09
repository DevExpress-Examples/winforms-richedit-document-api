Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Linq

Namespace RichEditAPISample.CodeExamples

    Friend Class SearchAndReplaceActions

        Private Shared Sub FindSixLetterWords(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#FindSixLetterWords"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            document.InsertSection(document.Range.Start)
            ' Specify a regular expression that will find all six letter words.
            Dim expr As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\b\w{6}\b")
            Dim sixLetterWords As System.Collections.Specialized.StringCollection = New System.Collections.Specialized.StringCollection()
            ' Perform the search.
            Dim found As DevExpress.XtraRichEdit.API.Native.DocumentRange() = document.FindAll(expr)
            For Each r As DevExpress.XtraRichEdit.API.Native.DocumentRange In found
                sixLetterWords.Add(document.GetText(r))
            Next

            document.BeginUpdate()
            ' Insert an ordered list of non-repetitive words in the beginning of the document.
            Dim distinctWords = sixLetterWords.Cast(Of String)().Distinct().OrderByDescending(Function(s) s)
            For Each s In distinctWords
                document.InsertText(document.Range.Start, s.ToString() & System.Environment.NewLine)
            Next

            document.EndUpdate()
#End Region  ' #FindSixLetterWords
        End Sub

        Private Shared Sub FindDatesInSpecificFormat(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#FindDatesInSpecificFormat"
            document.AppendText("12\14\2014" & System.Environment.NewLine)
            Dim result As DevExpress.XtraRichEdit.API.Native.IRegexSearchResult
            Dim pattern As String = "(?<mm>\d{2}).(?<dd>\d{2}).(?<yyyy>\d{4})"
            Dim myRegEx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(pattern)
            result = document.StartSearch(myRegEx)
            If result.FindNext() Then
                Dim dayFound As String = result.Match.Groups(CInt((2))).Value
                Dim monthFound As String = result.Match.Groups(CInt((1))).Value
                Dim yearFound As String = result.Match.Groups(CInt((3))).Value
                document.AppendText(System.[String].Format("Found a date that is the {0} day of the {1} month of the {2} year.", dayFound, monthFound, yearFound))
            End If
#End Region  ' #FindDatesInSpecificFormat
        End Sub

        Private Shared Sub RemoveBlankLines(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#RemoveBlankLines"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim pattern As String = "((?<=^)|(?<=\n))\n"
            Dim replacementString As String = String.Empty
            Dim myRegEx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(pattern)
            Dim count As Integer = document.ReplaceAll(myRegEx, replacementString)
            System.Windows.Forms.MessageBox.Show(System.[String].Format("{0} blank lines have been removed", count))
#End Region  ' #RemoveBlankLines
        End Sub

        Private Shared Sub ChangeDateFormat(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ChangeDateFormat"
            document.AppendText("12\14\2014" & System.Environment.NewLine)
            Dim pattern As String = "(?<mm>\d{2}).(?<dd>\d{2}).(?<yyyy>\d{4})"
            Dim replacementString As String = "${yyyy}-${mm}-${dd} or ${dd}.${mm}.${yyyy}"
            Dim myRegEx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(pattern)
            Dim count As Integer = document.ReplaceAll(myRegEx, replacementString)
            System.Windows.Forms.MessageBox.Show(System.[String].Format("We've done {0} replacement(s).", count))
#End Region  ' #ChangeDateFormat
        End Sub
    End Class
End Namespace
