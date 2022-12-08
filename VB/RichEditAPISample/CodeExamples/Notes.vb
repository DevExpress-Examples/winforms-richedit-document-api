Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace RichEditAPISample.CodeExamples

    Friend Class NotesActions

        Private Shared Sub InsertFootnotes(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#InsertFootnotes"
            document.LoadDocument("Documents//Grimm.docx")
            'Insert a footnote at the end of the 6th paragraph:
            Dim footnotePosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(document.Paragraphs(CInt((5))).Range.[End].ToInt() - 1)
            document.Footnotes.Insert(footnotePosition)
            'Insert a footnote at the end of the 8th paragraph with a custom mark:
            Dim footnoteWithCustomMarkPosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(document.Paragraphs(CInt((7))).Range.[End].ToInt() - 1)
            document.Footnotes.Insert(footnoteWithCustomMarkPosition, "º")
#End Region  ' #InsertFootnotes 
        End Sub

        Private Shared Sub InsertEndnotes(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#InsertEndnotes"
            document.LoadDocument("Documents//Grimm.docx")
            'Insert an endnote at the end of the second last paragraph paragraph:
            Dim endnotePosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(document.Paragraphs(CInt((document.Paragraphs.Count - 2))).Range.[End].ToInt() - 1)
            document.Endnotes.Insert(endnotePosition)
            'Insert an endnote with a custom mark:
            Dim endnoteWithCustomMarkPosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CreatePosition(document.Paragraphs(CInt((document.Paragraphs.Count - 3))).Range.[End].ToInt() - 1)
            document.Endnotes.Insert(endnoteWithCustomMarkPosition, "º")
#End Region  ' #InsertEndnotes
        End Sub

        Private Shared Sub EditFootnote(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#EditFootnote"
            document.LoadDocument("Documents//Grimm.docx")
            'Access the first fottnote's content:
            Dim footnote As DevExpress.XtraRichEdit.API.Native.SubDocument = document.Footnotes(CInt((0))).BeginUpdate()
            'Exclude the reference mark and the space after it from the range to be edited:
            Dim noteTextRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = footnote.CreateRange(footnote.Range.Start.ToInt() + 2, footnote.Range.Length - 2)
            'Clear the range:
            footnote.Delete(noteTextRange)
            'Append a new text:
            footnote.AppendText("the text is removed")
            'Finalize the update:
            document.Footnotes(CInt((0))).EndUpdate(footnote)
#End Region  ' #EditFootnote
        End Sub

        Private Shared Sub EditEndnote(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#EditEndnote"
            document.LoadDocument("Documents//Grimm.docx")
            'Access the first endnote's content:
            Dim endnote As DevExpress.XtraRichEdit.API.Native.SubDocument = document.Endnotes(CInt((0))).BeginUpdate()
            'Exclude the reference mark and the space after it from the range to be edited:
            Dim noteTextRange As DevExpress.XtraRichEdit.API.Native.DocumentRange = endnote.CreateRange(endnote.Range.Start.ToInt() + 2, endnote.Range.Length - 2)
            'Access the range's character properties:
            Dim characterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = endnote.BeginUpdateCharacters(noteTextRange)
            characterProperties.ForeColor = System.Drawing.Color.Red
            characterProperties.Italic = True
            'Finalize the character options update:
            endnote.EndUpdateCharacters(characterProperties)
            'Finalize the endnote update:
            document.Endnotes(CInt((0))).EndUpdate(endnote)
#End Region  ' #EditEndnote
        End Sub

        Private Shared Sub EditSeparator(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#EditSeparator"
            document.LoadDocument("Documents//Grimm.docx")
            'Check whether the footnotes already have a separator:
            If document.Footnotes.HasSeparator(DevExpress.XtraRichEdit.API.Native.NoteSeparatorType.Separator) Then
                'Initiate the update session:
                Dim noteSeparator As DevExpress.XtraRichEdit.API.Native.SubDocument = document.Footnotes.BeginUpdateSeparator(DevExpress.XtraRichEdit.API.Native.NoteSeparatorType.Separator)
                'Clear the separator range:
                noteSeparator.Delete(noteSeparator.Range)
                'Append a new text:
                noteSeparator.AppendText("***")
                Dim characterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = noteSeparator.BeginUpdateCharacters(noteSeparator.Range)
                characterProperties.ForeColor = System.Drawing.Color.Blue
                noteSeparator.EndUpdateCharacters(characterProperties)
                'Finalize the update:
                document.Footnotes.EndUpdateSeparator(noteSeparator)
            End If
#End Region  ' #EditSeparator
        End Sub

        Private Shared Sub RemoveNotes(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#RemoveNotes"
            document.LoadDocument("Documents//Grimm.docx")
            'Remove first footnote:
            document.Footnotes.RemoveAt(0)
            'Remove all custom endnotes:
            For i As Integer = document.Endnotes.Count - 1 To 0 Step -1
                If document.Endnotes(CInt((i))).IsCustom Then document.Endnotes.Remove(document.Endnotes(i))
            Next
#End Region  ' #RemoveNotes
        End Sub
    End Class
End Namespace
