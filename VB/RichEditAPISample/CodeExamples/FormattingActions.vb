Imports Microsoft.VisualBasic
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Drawing

Namespace RichEditAPISample.CodeExamples
	Public NotInheritable Class FormattingActions
		Private Sub New()
		End Sub
		Private Shared Sub FormatText(ByVal document As Document)
'			#Region "#FormatText"
			document.BeginUpdate()
			document.AppendText("Normal" & Constants.vbLf & "Formatted" & Constants.vbLf & "Normal")
			document.EndUpdate()
			Dim range As DocumentRange = document.Paragraphs(1).Range
			Dim cp As CharacterProperties = document.BeginUpdateCharacters(range)
			cp.FontName = "Comic Sans MS"
			cp.FontSize = 18
			cp.ForeColor = Color.Blue
			cp.BackColor = Color.Snow
			cp.Underline = UnderlineType.DoubleWave
			cp.UnderlineColor = Color.Red
			document.EndUpdateCharacters(cp)
'			#End Region ' #FormatText
		End Sub

		Private Shared Sub ResetCharacterFormatting(ByVal document As Document)
'			#Region "#ResetCharacterFormatting"
			document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			' Set font size and font name of the characters in the first paragraph to default. 
			' Other character properties remain intact.
			Dim range As DocumentRange = document.Paragraphs(0).Range
			Dim cp As CharacterProperties = document.BeginUpdateCharacters(range)
			cp.Reset(CharacterPropertiesMask.FontSize Or CharacterPropertiesMask.FontName)
			document.EndUpdateCharacters(cp)
'			#End Region ' #ResetCharacterFormatting
		End Sub

		Private Shared Sub FormatParagraph(ByVal document As Document)
'			#Region "#FormatParagraph"
			document.BeginUpdate()
			document.AppendText("Modified Paragraph" & Constants.vbLf & "Normal" & Constants.vbLf & "Normal")
			document.EndUpdate()
			Dim pos As DocumentPosition = document.Range.Start
			Dim range As DocumentRange = document.CreateRange(pos, 0)
			Dim pp As ParagraphProperties = document.BeginUpdateParagraphs(range)
			' Center paragraph
			pp.Alignment = ParagraphAlignment.Center
			' Set triple spacing
			pp.LineSpacingType = ParagraphLineSpacing.Multiple
			pp.LineSpacingMultiplier = 3
			' Set left indent at 0.5".
			' Default unit is 1/300 of an inch (a document unit).
			pp.LeftIndent = DevExpress.Office.Utils.Units.InchesToDocumentsF(0.5f)
			' Set tab stop at 1.5"
			Dim tbiColl As TabInfoCollection = pp.BeginUpdateTabs(True)
			Dim tbi As New DevExpress.XtraRichEdit.API.Native.TabInfo()
			tbi.Alignment = TabAlignmentType.Center
			tbi.Position = DevExpress.Office.Utils.Units.InchesToDocumentsF(1.5f)
			tbiColl.Add(tbi)
			pp.EndUpdateTabs(tbiColl)
			document.EndUpdateParagraphs(pp)
'			#End Region ' #FormatParagraph
		End Sub

		Private Shared Sub ResetParagraphFormatting(ByVal document As Document)
'			#Region "#ResetParagraphFormatting"
			document.LoadDocument("Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			' Set alignment and indentation of the first line in the first paragraph to default. 
			' Other paragraph properties remain intact.
			Dim range As DocumentRange = document.Paragraphs(0).Range
			Dim cp As ParagraphProperties = document.BeginUpdateParagraphs(range)
			cp.Reset(ParagraphPropertiesMask.Alignment Or ParagraphPropertiesMask.FirstLineIndent)
			document.EndUpdateParagraphs(cp)
'			#End Region ' #ResetParagraphFormatting
		End Sub
	End Class
End Namespace
