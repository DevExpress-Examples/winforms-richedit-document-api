Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class ListActions

        Private Shared Sub CreateBulletedList(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateBulletedList"
            document.BeginUpdate()
            ' Define an abstract list that is the pattern for lists used in the document.
            Dim list As DevExpress.XtraRichEdit.API.Native.AbstractNumberingList = document.AbstractNumberingLists.Add()
            list.NumberingType = DevExpress.XtraRichEdit.API.Native.NumberingType.Bullet
            ' Specify parameters for each list level.
            Dim level As DevExpress.XtraRichEdit.API.Native.ListLevel = list.Levels(0)
            level.ParagraphProperties.LeftIndent = 100
            level.CharacterProperties.FontName = "Symbol"
            level.DisplayFormatString = New String("·"c, 1)
            level = list.Levels(1)
            level.ParagraphProperties.LeftIndent = 250
            level.CharacterProperties.FontName = "Symbol"
            level.DisplayFormatString = New String("o"c, 1)
            level = list.Levels(2)
            level.ParagraphProperties.LeftIndent = 450
            level.CharacterProperties.FontName = "Symbol"
            level.DisplayFormatString = New String("·"c, 1)
            ' Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0)
            document.EndUpdate()
            document.AppendText("Line 1" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line 2" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line 3")
            ' Convert all paragraphs to list items.
            document.BeginUpdate()
            Dim paragraphs As DevExpress.XtraRichEdit.API.Native.ParagraphCollection = document.Paragraphs
            For Each pgf As DevExpress.XtraRichEdit.API.Native.Paragraph In paragraphs
                pgf.ListIndex = 0
                pgf.ListLevel = 1
            Next

            document.EndUpdate()
'#End Region  ' #CreateBulletedList
        End Sub

        Private Shared Sub CreateNumberedList(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateNumberedList"
            document.BeginUpdate()
            ' Define an abstract list that is the pattern for lists used in the document.
            Dim list As DevExpress.XtraRichEdit.API.Native.AbstractNumberingList = document.AbstractNumberingLists.Add()
            list.NumberingType = DevExpress.XtraRichEdit.API.Native.NumberingType.MultiLevel
            ' Specify parameters for each list level.
            Dim level As DevExpress.XtraRichEdit.API.Native.ListLevel = list.Levels(0)
            level.ParagraphProperties.LeftIndent = 150
            level.ParagraphProperties.FirstLineIndentType = DevExpress.XtraRichEdit.API.Native.ParagraphFirstLineIndent.Hanging
            level.ParagraphProperties.FirstLineIndent = 75
            level.Start = 1
            level.NumberingFormat = DevExpress.XtraRichEdit.API.Native.NumberingFormat.[Decimal]
            level.DisplayFormatString = "{0}"
            level = list.Levels(1)
            level.ParagraphProperties.LeftIndent = 300
            level.ParagraphProperties.FirstLineIndentType = DevExpress.XtraRichEdit.API.Native.ParagraphFirstLineIndent.Hanging
            level.ParagraphProperties.FirstLineIndent = 150
            level.Start = 1
            level.NumberingFormat = DevExpress.XtraRichEdit.API.Native.NumberingFormat.DecimalEnclosedParenthses
            level.DisplayFormatString = "{0}→{1}"
            level = list.Levels(2)
            level.ParagraphProperties.LeftIndent = 450
            level.ParagraphProperties.FirstLineIndentType = DevExpress.XtraRichEdit.API.Native.ParagraphFirstLineIndent.Hanging
            level.ParagraphProperties.FirstLineIndent = 220
            level.Start = 1
            level.NumberingFormat = DevExpress.XtraRichEdit.API.Native.NumberingFormat.LowerRoman
            level.DisplayFormatString = "{0}→{1}→{2}"
            ' Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0)
            document.EndUpdate()
            document.AppendText("Line one" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line two" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line three" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line four")
            ' Convert all paragraphs to list items of level 0.
            document.BeginUpdate()
            Dim paragraphs As DevExpress.XtraRichEdit.API.Native.ParagraphCollection = document.Paragraphs
            For Each pgf As DevExpress.XtraRichEdit.API.Native.Paragraph In paragraphs
                pgf.ListIndex = 0
                pgf.ListLevel = 0
            Next

            ' Specify a different level for a certain paragraph.
            document.Paragraphs(CInt((1))).ListLevel = 1
            document.EndUpdate()
'#End Region  ' #CreateNumberedList
        End Sub
    End Class
End Namespace
