Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
    Friend Class StylesActions
        Private Shared Sub CreateNewCharacterStyle(ByVal document As Document)
            '            #Region "#CreateNewCharacterStyle"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim cstyle As CharacterStyle = document.CharacterStyles("MyCStyle")
            If cstyle Is Nothing Then
                cstyle = document.CharacterStyles.CreateNew()
                cstyle.Name = "MyCStyle"
                cstyle.Parent = document.CharacterStyles("Default Paragraph Font")
                cstyle.ForeColor = System.Drawing.Color.DarkOrange
                cstyle.Strikeout = StrikeoutType.Double
                cstyle.FontName = "Verdana"
                document.CharacterStyles.Add(cstyle)
            End If
            Dim myRange As DocumentRange = document.Paragraphs(0).Range
            Dim charProps As CharacterProperties = document.BeginUpdateCharacters(myRange)
            charProps.Style = cstyle
            document.EndUpdateCharacters(charProps)
'            #End Region ' #CreateNewCharacterStyle
        End Sub

        Private Shared Sub CreateNewParagraphStyle(ByVal document As Document)
            '            #Region "#CreateNewParagraphStyle"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim pstyle As ParagraphStyle = document.ParagraphStyles("MyPStyle")
            If pstyle Is Nothing Then
                pstyle = document.ParagraphStyles.CreateNew()
                pstyle.Name = "MyPStyle"
                pstyle.LineSpacingType = ParagraphLineSpacing.Double
                pstyle.Alignment = ParagraphAlignment.Center
                document.ParagraphStyles.Add(pstyle)
            End If
            document.Paragraphs(2).Style = pstyle
'            #End Region ' #CreateNewParagraphStyle
        End Sub

        Private Shared Sub CreateNewLinkedStyle(ByVal document As Document)
'            #Region "#CreateNewLinkedStyle"
            document.BeginUpdate()
            document.AppendText("Line One" & vbLf & "Line Two" & vbLf & "Line Three")
            document.EndUpdate()

            'Create new paragraph style
            Dim lstyle As ParagraphStyle = document.ParagraphStyles("MyLinkedStyle")
            If lstyle Is Nothing Then
                document.BeginUpdate()
                lstyle = document.ParagraphStyles.CreateNew()
                lstyle.Name = "MyLinkedStyle"
                lstyle.LineSpacingType = ParagraphLineSpacing.Double
                lstyle.Alignment = ParagraphAlignment.Center
                document.ParagraphStyles.Add(lstyle)

                Dim lcstyle As CharacterStyle = document.CharacterStyles.CreateNew()
                lcstyle.Name = "MyLinkedCStyle"
                document.CharacterStyles.Add(lcstyle)
                lcstyle.LinkedStyle = lstyle

                lcstyle.ForeColor = System.Drawing.Color.DarkGreen
                lcstyle.Strikeout = StrikeoutType.Single
                lcstyle.FontSize = 24
                document.EndUpdate()

                'Apply created styles 
                'to the text range and to the entire paragraph
                document.Paragraphs(1).Style = lstyle

                Dim myRange As DocumentRange = document.Paragraphs(0).Range
                Dim charProps As CharacterProperties = document.BeginUpdateCharacters(myRange)
                charProps.Style = lcstyle
                document.EndUpdateCharacters(charProps)
            End If
'            #End Region ' #CreateNewLinkedStyle
        End Sub
    End Class
End Namespace
