Imports System.CodeDom.Compiler
Imports Microsoft.CSharp

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

'#Region "RichEditCSExampleCodeEvaluator"
    Public Class RichEditCSExampleCodeEvaluator
        Inherits RichEditExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New CSharpCodeProvider()
        End Function

        Const codeStartField As String = "using System;" & Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit;" & Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit.API.Native;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Drawing;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Windows.Forms;" & Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.Utils;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.IO;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Diagnostics;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Xml;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Data;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Collections.Generic;" & Microsoft.VisualBasic.Constants.vbCrLf & "using System.Globalization;" & Microsoft.VisualBasic.Constants.vbCrLf & "namespace RichEditCodeResultViewer { " & Microsoft.VisualBasic.Constants.vbCrLf & "public class ExampleItem { " & Microsoft.VisualBasic.Constants.vbCrLf & "        public static void Process(Document doc) { " & Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbCrLf

        Const codeEndField As String = "       " & Microsoft.VisualBasic.Constants.vbCrLf & " }" & Microsoft.VisualBasic.Constants.vbCrLf & "    }" & Microsoft.VisualBasic.Constants.vbCrLf & "}" & Microsoft.VisualBasic.Constants.vbCrLf

        Protected Overrides ReadOnly Property CodeStart As String
            Get
                Return codeStartField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeEnd As String
            Get
                Return codeEndField
            End Get
        End Property
    End Class

'#End Region
'#Region "RichEditVbExampleCodeEvaluator"
    Public Class RichEditVbExampleCodeEvaluator
        Inherits RichEditExampleCodeEvaluator

        Protected Overrides Function GetCodeDomProvider() As CodeDomProvider
            Return New Microsoft.VisualBasic.VBCodeProvider()
        End Function

        Const codeStartField As String = "Imports Microsoft.VisualBasic" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System" & Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit;" & Microsoft.VisualBasic.Constants.vbCrLf & "using DevExpress.XtraRichEdit.API.Native;" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Drawing" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Windows.Forms" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports DevExpress.Utils" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.IO" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Diagnostics" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Xml" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Data" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Collections.Generic" & Microsoft.VisualBasic.Constants.vbCrLf & "Imports System.Globalization" & Microsoft.VisualBasic.Constants.vbCrLf & "Namespace RichEditCodeResultViewer" & Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbTab & "Public Class ExampleItem" & Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbTab & Microsoft.VisualBasic.Constants.vbTab & "Public Shared Sub Process(ByVal doc As Document)" & Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbCrLf

        Const codeEndField As String = Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbTab & Microsoft.VisualBasic.Constants.vbTab & "End Sub" & Microsoft.VisualBasic.Constants.vbCrLf & Microsoft.VisualBasic.Constants.vbTab & "End Class" & Microsoft.VisualBasic.Constants.vbCrLf & "End Namespace" & Microsoft.VisualBasic.Constants.vbCrLf

        Protected Overrides ReadOnly Property CodeStart As String
            Get
                Return codeStartField
            End Get
        End Property

        Protected Overrides ReadOnly Property CodeEnd As String
            Get
                Return codeEndField
            End Get
        End Property
    End Class
'#End Region
End Namespace
