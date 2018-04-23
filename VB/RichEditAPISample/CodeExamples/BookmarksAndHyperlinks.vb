Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit

Namespace RichEditAPISample.CodeExamples
    Friend Class BookmarksAndHyperlinksActions
        Private Shared Sub InsertBookmark(ByVal document As Document)
'            #Region "#InsertBookmark"
            document.LoadDocument("Grimm.docx",DocumentFormat.OpenXml)
            document.BeginUpdate()
            Dim pos As DocumentPosition = document.Range.Start
            document.Bookmarks.Create(document.CreateRange(pos, 0), "Top")
           'Insert the hyperlink anchored to the created bookmark:
            Dim pos1 As DocumentPosition = document.CreatePosition((document.Range.End).ToInt()+25)
            document.Hyperlinks.Create(document.InsertText(pos1, "get to the top"))
            document.Hyperlinks(0).Anchor = "Top"
            document.EndUpdate()
'            #End Region ' #InsertBookmark
        End Sub
        Private Shared Sub InsertHYperlink(ByVal document As Document)
'            #Region "#InsertHyperlink"
            Dim hPos As DocumentPosition = document.Range.Start
            document.Hyperlinks.Create(document.InsertText(hPos, "Follow me!"))
            document.Hyperlinks(0).NavigateUri = "https://www.devexpress.com/Products/NET/Controls/WinForms/Rich_Editor/"
            document.Hyperlinks(0).ToolTip = "WinForms Rich Text Editor"
'            #End Region ' #InsertHyperlink
        End Sub

    End Class
End Namespace
