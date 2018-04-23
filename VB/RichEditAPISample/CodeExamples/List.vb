Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
    Friend Class ListActions
        Private Shared Sub CreateBulletedList(ByVal document As Document)
'            #Region "#CreateBulletedList"
            document.BeginUpdate()
            ' Define an abstract list that is the pattern for lists used in the document.
            Dim list As AbstractNumberingList = document.AbstractNumberingLists.Add()
            list.NumberingType = NumberingType.Bullet
            ' Specify parameters for each list level.
            Dim level As ListLevel = list.Levels(0)
            CreateBulletedListHelper.AdjustLevelProperties(level, 100, 75, NumberingFormat.Decimal, New String(ChrW(&H00B7), 1))
            level = list.Levels(1)
            CreateBulletedListHelper.AdjustLevelProperties(level, 300, 150, NumberingFormat.DecimalEnclosedParenthses, New String(ChrW(&H006F), 1))
            level = list.Levels(2)
            CreateBulletedListHelper.AdjustLevelProperties(level, 450, 220, NumberingFormat.UpperRoman, New String(ChrW(&H00B7), 1))
            ' Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0)
            document.EndUpdate()

            document.AppendText("Line 1" & ControlChars.Lf & "Line 2" & ControlChars.Lf & "Line 3")
            ' Convert paragraphs to list items.
            document.BeginUpdate()
            Dim paragraphs As ParagraphCollection = document.Paragraphs
            For Each pgf As Paragraph In paragraphs
                pgf.ListIndex = 0
                pgf.ListLevel = 0
            Next pgf
            paragraphs(1).ListLevel = 1
            paragraphs(2).ListLevel = 2
            document.EndUpdate()
'            #End Region ' #CreateBulletedList
        End Sub
        #Region "#@CreateBulletedList"
        Private Class CreateBulletedListHelper
            Public Shared Sub AdjustLevelProperties(ByVal level As ListLevel, ByVal leftIndent As Integer, ByVal firstLineIndent As Integer, ByVal format As NumberingFormat, ByVal displayFormat As String)
                level.CharacterProperties.FontName = "Symbol"
                level.ParagraphProperties.LeftIndent = leftIndent
                level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
                level.ParagraphProperties.FirstLineIndent = firstLineIndent
                level.Start = 1
                level.NumberingFormat = format
                level.DisplayFormatString = displayFormat
            End Sub
        End Class
        #End Region ' #@CreateBulletedList

        Private Shared Sub CreateNumberedList(ByVal document As Document)
'            #Region "#CreateNumberedList"
            document.BeginUpdate()
            ' Define an abstract list that is the pattern for lists used in the document.
            Dim list As AbstractNumberingList = document.AbstractNumberingLists.Add()
            list.NumberingType = NumberingType.MultiLevel
            ' Specify parameters for each list level.
            Dim level As ListLevel = list.Levels(0)
            CreateNumberedListHelper.AdjustLevelProperties(level, 150, 75, NumberingFormat.Decimal, "{0}")
            level = list.Levels(1)
            CreateNumberedListHelper.AdjustLevelProperties(level, 300, 150, NumberingFormat.DecimalEnclosedParenthses, "{0}→{1}")
            level = list.Levels(2)
            CreateNumberedListHelper.AdjustLevelProperties(level, 450, 220, NumberingFormat.UpperRoman, "{0}→{1}→{2}")
            ' Create a list for use in the document. It is based on a previously defined abstract list with ID = 0.
            document.NumberingLists.Add(0)
            document.EndUpdate()

            document.AppendText("Line one" & ControlChars.Lf & "Line two" & ControlChars.Lf & "Line three" & ControlChars.Lf & "Line four")
            ' Convert all paragraphs to list items of level 0.
            document.BeginUpdate()
            Dim paragraphs As ParagraphCollection = document.Paragraphs
            For Each pgf As Paragraph In paragraphs
                pgf.ListIndex = 0
                pgf.ListLevel = 0
            Next pgf
            ' Specify a different level for a certain paragraph.
            paragraphs(1).ListLevel = 1
            document.EndUpdate()
'            #End Region ' #CreateNumberedList
        End Sub
        #Region "#@CreateNumberedList"
        Private Class CreateNumberedListHelper
            Public Shared Sub AdjustLevelProperties(ByVal level As ListLevel, ByVal leftIndent As Integer, ByVal firstLineIndent As Integer, ByVal format As NumberingFormat, ByVal displayFormat As String)
                  level.ParagraphProperties.LeftIndent = leftIndent
                level.ParagraphProperties.FirstLineIndentType = ParagraphFirstLineIndent.Hanging
                level.ParagraphProperties.FirstLineIndent = firstLineIndent
                level.Start = 1
                level.NumberingFormat = format
                level.DisplayFormatString = displayFormat
            End Sub
        End Class
        #End Region ' #@CreateNumberedList


    End Class
End Namespace
