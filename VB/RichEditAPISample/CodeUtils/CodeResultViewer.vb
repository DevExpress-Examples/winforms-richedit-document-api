Imports System
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.CSharp
Imports System.Globalization
Imports DevExpress.Spreadsheet

Namespace RichEditAPISample
    Public MustInherit Class RichEditExampleCodeEvaluator
        Inherits ExampleCodeEvaluator


        Protected Overrides Function GetModuleAssembly() As String
            Return AssemblyInfo.SRAssemblyRichEditCore
        End Function
        Protected Overrides Function GetExampleClassName() As String
            Return "RichEditCodeResultViewer.ExampleItem"
        End Function
    End Class
    #Region "RichEditCSExampleCodeEvaluator"
    Public Class RichEditCSExampleCodeEvaluator
        Inherits RichEditExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New CSharpCodeProvider()
        End Function

        Private Const codeStart_Renamed As String = "using System;" & ControlChars.CrLf & "using DevExpress.XtraRichEdit;" & ControlChars.CrLf & "using DevExpress.XtraRichEdit.API.Native;" & ControlChars.CrLf & "using System.Drawing;" & ControlChars.CrLf & "using System.Windows.Forms;" & ControlChars.CrLf & "using DevExpress.Utils;" & ControlChars.CrLf & "using System.IO;" & ControlChars.CrLf & "using System.Diagnostics;" & ControlChars.CrLf & "using System.Xml;" & ControlChars.CrLf & "using System.Data;" & ControlChars.CrLf & "using System.Collections.Generic;" & ControlChars.CrLf & "using System.Globalization;" & ControlChars.CrLf & "namespace RichEditCodeResultViewer { " & ControlChars.CrLf & "public class ExampleItem { " & ControlChars.CrLf & "        public static void Process(Document doc) { " & ControlChars.CrLf & ControlChars.CrLf


        Private Const codeEnd_Renamed As String = "       " & ControlChars.CrLf & " }" & ControlChars.CrLf & "    }" & ControlChars.CrLf & "}" & ControlChars.CrLf
        Protected Overrides ReadOnly Property CodeStart() As String
            Get
                Return codeStart_Renamed
            End Get
        End Property
        Protected Overrides ReadOnly Property CodeEnd() As String
            Get
                Return codeEnd_Renamed
            End Get
        End Property
    End Class
    #End Region
    #Region "RichEditVbExampleCodeEvaluator"
    Public Class RichEditVbExampleCodeEvaluator
        Inherits RichEditExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New Microsoft.VisualBasic.VBCodeProvider()
        End Function

        Private Const codeStart_Renamed As String = "Imports Microsoft.VisualBasic" & ControlChars.CrLf & "Imports System" & ControlChars.CrLf & "using DevExpress.XtraRichEdit;" & ControlChars.CrLf & "using DevExpress.XtraRichEdit.API.Native;" & ControlChars.CrLf & "Imports System.Drawing" & ControlChars.CrLf & "Imports System.Windows.Forms" & ControlChars.CrLf & "Imports DevExpress.Utils" & ControlChars.CrLf & "Imports System.IO" & ControlChars.CrLf & "Imports System.Diagnostics" & ControlChars.CrLf & "Imports System.Xml" & ControlChars.CrLf & "Imports System.Data" & ControlChars.CrLf & "Imports System.Collections.Generic" & ControlChars.CrLf & "Imports System.Globalization" & ControlChars.CrLf & "Namespace RichEditCodeResultViewer" & ControlChars.CrLf & "	Public Class ExampleItem" & ControlChars.CrLf & "		Public Shared Sub Process(ByVal doc As Document)" & ControlChars.CrLf & ControlChars.CrLf


        Private Const codeEnd_Renamed As String = ControlChars.CrLf & "		End Sub" & ControlChars.CrLf & "	End Class" & ControlChars.CrLf & "End Namespace" & ControlChars.CrLf

        Protected Overrides ReadOnly Property CodeStart() As String
            Get
                Return codeStart_Renamed
            End Get
        End Property
        Protected Overrides ReadOnly Property CodeEnd() As String
            Get
                Return codeEnd_Renamed
            End Get
        End Property
    End Class
    #End Region
End Namespace
