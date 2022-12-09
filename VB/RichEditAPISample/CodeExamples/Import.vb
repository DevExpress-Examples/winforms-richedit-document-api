Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class Import

        Private Shared Sub ImportRtfText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#ImportRtfText"
            Dim rtfString As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1049
{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}
{\f1\fswiss\fcharset0 Arial;}}
{\colortbl ;\red0\green0\blue255;}
\viewkind4\uc1\pard\cf1\lang1033\b\f0\fs32 Test.\cf0\b0\f1\fs20\par}"
            document.RtfText = rtfString
#End Region  ' #ImportRtfText
        End Sub
    End Class
End Namespace
