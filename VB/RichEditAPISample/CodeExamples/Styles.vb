Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class StylesActions

        Private Shared Sub CreateNewCharacterStyle(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateNewCharacterStyle"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim cstyle As DevExpress.XtraRichEdit.API.Native.CharacterStyle = document.CharacterStyles("MyCStyle")
            If cstyle Is Nothing Then
                cstyle = document.CharacterStyles.CreateNew()
                cstyle.Name = "MyCStyle"
                cstyle.Parent = document.CharacterStyles("Default Paragraph Font")
                cstyle.ForeColor = System.Drawing.Color.DarkOrange
                cstyle.Strikeout = DevExpress.XtraRichEdit.API.Native.StrikeoutType.[Double]
                cstyle.FontName = "Verdana"
                document.CharacterStyles.Add(cstyle)
            End If

            Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((0))).Range
            Dim charProps As DevExpress.XtraRichEdit.API.Native.CharacterProperties = document.BeginUpdateCharacters(myRange)
            charProps.Style = cstyle
            document.EndUpdateCharacters(charProps)
#End Region  ' #CreateNewCharacterStyle
        End Sub

        Private Shared Sub CreateNewParagraphStyle(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateNewParagraphStyle"
            document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Dim pstyle As DevExpress.XtraRichEdit.API.Native.ParagraphStyle = document.ParagraphStyles("MyPStyle")
            If pstyle Is Nothing Then
                pstyle = document.ParagraphStyles.CreateNew()
                pstyle.Name = "MyPStyle"
                pstyle.LineSpacingType = DevExpress.XtraRichEdit.API.Native.ParagraphLineSpacing.[Double]
                pstyle.Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Center
                document.ParagraphStyles.Add(pstyle)
            End If

            document.Paragraphs(CInt((2))).Style = pstyle
#End Region  ' #CreateNewParagraphStyle
        End Sub

        Private Shared Sub CreateNewLinkedStyle(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateNewLinkedStyle"
            document.BeginUpdate()
            document.AppendText("Line One" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Two" & Global.Microsoft.VisualBasic.Constants.vbLf & "Line Three")
            document.EndUpdate()
            'Create new paragraph style
            Dim lstyle As DevExpress.XtraRichEdit.API.Native.ParagraphStyle = document.ParagraphStyles("MyLinkedStyle")
            If lstyle Is Nothing Then
                document.BeginUpdate()
                lstyle = document.ParagraphStyles.CreateNew()
                lstyle.Name = "MyLinkedStyle"
                lstyle.LineSpacingType = DevExpress.XtraRichEdit.API.Native.ParagraphLineSpacing.[Double]
                lstyle.Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Center
                document.ParagraphStyles.Add(lstyle)
                Dim lcstyle As DevExpress.XtraRichEdit.API.Native.CharacterStyle = document.CharacterStyles.CreateNew()
                lcstyle.Name = "MyLinkedCStyle"
                document.CharacterStyles.Add(lcstyle)
                lcstyle.LinkedStyle = lstyle
                lcstyle.ForeColor = System.Drawing.Color.DarkGreen
                lcstyle.Strikeout = DevExpress.XtraRichEdit.API.Native.StrikeoutType.[Single]
                lcstyle.FontSize = 24
                document.EndUpdate()
                'Apply created styles 
                'to the text range and to the entire paragraph
                document.Paragraphs(CInt((1))).Style = lstyle
                Dim myRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = document.Paragraphs(CInt((0))).Range
                Dim charProps As DevExpress.XtraRichEdit.API.Native.CharacterProperties = document.BeginUpdateCharacters(myRange)
                charProps.Style = lcstyle
                document.EndUpdateCharacters(charProps)
            End If
#End Region  ' #CreateNewLinkedStyle
        End Sub
    End Class
End Namespace
