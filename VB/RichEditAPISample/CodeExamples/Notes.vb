Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditAPISample.CodeExamples
	 Friend Class NotesActions

		Private Shared Sub InsertFootnotes(ByVal document As Document)
'			#Region "#InsertFootnotes"
			document.LoadDocument("Documents//Grimm.docx")

			'Insert a footnote at the end of the 6th paragraph:
			Dim footnotePosition As DocumentPosition = document.CreatePosition(document.Paragraphs(5).Range.End.ToInt() - 1)
			document.Footnotes.Insert(footnotePosition)

			'Insert a footnote at the end of the 8th paragraph with a custom mark:
			Dim footnoteWithCustomMarkPosition As DocumentPosition = document.CreatePosition(document.Paragraphs(7).Range.End.ToInt() - 1)
			document.Footnotes.Insert(footnoteWithCustomMarkPosition, ChrW(&H00BA).ToString())
'			#End Region ' #InsertFootnotes 
		End Sub


		Private Shared Sub InsertEndnotes(ByVal document As Document)
'			#Region "#InsertEndnotes"
			document.LoadDocument("Documents//Grimm.docx")

			'Insert an endnote at the end of the second last paragraph paragraph:
			Dim endnotePosition As DocumentPosition = document.CreatePosition(document.Paragraphs(document.Paragraphs.Count - 2).Range.End.ToInt() - 1)
			document.Endnotes.Insert(endnotePosition)

			'Insert an endnote with a custom mark:
			Dim endnoteWithCustomMarkPosition As DocumentPosition = document.CreatePosition(document.Paragraphs(document.Paragraphs.Count - 3).Range.End.ToInt() - 1)
			document.Endnotes.Insert(endnoteWithCustomMarkPosition, ChrW(&H00BA).ToString())
'			#End Region ' #InsertEndnotes
		End Sub

		Private Shared Sub EditFootnote(ByVal document As Document)
'			#Region "#EditFootnote"
			document.LoadDocument("Documents//Grimm.docx")

			'Access the first fottnote's content:
			Dim footnote As SubDocument = document.Footnotes(0).BeginUpdate()

			'Exclude the reference mark and the space after it from the range to be edited:
			Dim noteTextRange As DocumentRange = footnote.CreateRange(footnote.Range.Start.ToInt() + 2, footnote.Range.Length - 2)

			'Clear the range:
			footnote.Delete(noteTextRange)

			'Append a new text:
			footnote.AppendText("the text is removed")

			'Finalize the update:
			document.Footnotes(0).EndUpdate(footnote)
'			#End Region ' #EditFootnote
		End Sub

		Private Shared Sub EditEndnote(ByVal document As Document)
'			#Region "#EditEndnote"
			document.LoadDocument("Documents//Grimm.docx")

			'Access the first endnote's content:
			Dim endnote As SubDocument = document.Endnotes(0).BeginUpdate()

			'Exclude the reference mark and the space after it from the range to be edited:
			Dim noteTextRange As DocumentRange = endnote.CreateRange(endnote.Range.Start.ToInt() + 2, endnote.Range.Length - 2)

			'Access the range's character properties:
			Dim characterProperties As CharacterProperties = endnote.BeginUpdateCharacters(noteTextRange)

			characterProperties.ForeColor = System.Drawing.Color.Red
			characterProperties.Italic = True

			'Finalize the character options update:
			endnote.EndUpdateCharacters(characterProperties)

			'Finalize the endnote update:
			document.Endnotes(0).EndUpdate(endnote)
'			#End Region ' #EditEndnote
		End Sub

		Private Shared Sub EditSeparator(ByVal document As Document)
'			#Region "#EditSeparator"
			document.LoadDocument("Documents//Grimm.docx")

			'Check whether the footnotes already have a separator:
			If document.Footnotes.HasSeparator(NoteSeparatorType.Separator) Then
				'Initiate the update session:
				Dim noteSeparator As SubDocument = document.Footnotes.BeginUpdateSeparator(NoteSeparatorType.Separator)

				'Clear the separator range:
				noteSeparator.Delete(noteSeparator.Range)

				'Append a new text:
				noteSeparator.AppendText("***")

				Dim characterProperties As CharacterProperties = noteSeparator.BeginUpdateCharacters(noteSeparator.Range)
				characterProperties.ForeColor = System.Drawing.Color.Blue
				noteSeparator.EndUpdateCharacters(characterProperties)

				'Finalize the update:
				document.Footnotes.EndUpdateSeparator(noteSeparator)
			End If
'			#End Region ' #EditSeparator
		End Sub
		Private Shared Sub RemoveNotes(ByVal document As Document)
'			#Region "#RemoveNotes"
			document.LoadDocument("Documents//Grimm.docx")

			'Remove first footnote:
			document.Footnotes.RemoveAt(0)


			'Remove all custom endnotes:
			For i As Integer = document.Endnotes.Count - 1 To 0 Step -1
				If document.Endnotes(i).IsCustom Then
					document.Endnotes.Remove(document.Endnotes(i))
				End If
			Next i

'			#End Region ' #RemoveNotes
		End Sub
	 End Class
End Namespace
