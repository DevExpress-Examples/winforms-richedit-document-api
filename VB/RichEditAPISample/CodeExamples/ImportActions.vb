Imports Microsoft.VisualBasic
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples
	Friend Class ImportActions
		Private Shared Sub ImportRtfText(ByVal document As Document)
'			#Region "#ImportRtfText"
			Dim rtfString As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1049" & ControlChars.CrLf & "{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}" & ControlChars.CrLf & "{\f1\fswiss\fcharset0 Arial;}}" & ControlChars.CrLf & "{\colortbl ;\red0\green0\blue255;}" & ControlChars.CrLf & "\viewkind4\uc1\pard\cf1\lang1033\b\f0\fs32 Test.\cf0\b0\f1\fs20\par}"
			document.RtfText = rtfString
'			#End Region ' #ImportRtfText
		End Sub
	End Class
End Namespace
