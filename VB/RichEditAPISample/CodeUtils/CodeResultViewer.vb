Imports Microsoft.VisualBasic
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
		Private Const codeStart_Renamed As String = "using System;" & Constants.vbCrLf & "using DevExpress.XtraRichEdit;" & Constants.vbCrLf & "using DevExpress.XtraRichEdit.API.Native;" & Constants.vbCrLf & "using System.Drawing;" & Constants.vbCrLf & "using System.Windows.Forms;" & Constants.vbCrLf & "using DevExpress.Utils;" & Constants.vbCrLf & "using System.IO;" & Constants.vbCrLf & "using System.Diagnostics;" & Constants.vbCrLf & "using System.Xml;" & Constants.vbCrLf & "using System.Data;" & Constants.vbCrLf & "using System.Collections.Generic;" & Constants.vbCrLf & "using System.Globalization;" & Constants.vbCrLf & "namespace RichEditCodeResultViewer { " & Constants.vbCrLf & "public class ExampleItem { " & Constants.vbCrLf & "        public static void Process(Document doc) { " & Constants.vbCrLf & Constants.vbCrLf

		Private Const codeEnd_Renamed As String = "       " & Constants.vbCrLf & " }" & Constants.vbCrLf & "    }" & Constants.vbCrLf & "}" & Constants.vbCrLf
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
		Private Const codeStart_Renamed As String = "Imports Microsoft.VisualBasic" & Constants.vbCrLf & "Imports System" & Constants.vbCrLf & "using DevExpress.XtraRichEdit;" & Constants.vbCrLf & "using DevExpress.XtraRichEdit.API.Native;" & Constants.vbCrLf & "Imports System.Drawing" & Constants.vbCrLf & "Imports System.Windows.Forms" & Constants.vbCrLf & "Imports DevExpress.Utils" & Constants.vbCrLf & "Imports System.IO" & Constants.vbCrLf & "Imports System.Diagnostics" & Constants.vbCrLf & "Imports System.Xml" & Constants.vbCrLf & "Imports System.Data" & Constants.vbCrLf & "Imports System.Collections.Generic" & Constants.vbCrLf & "Imports System.Globalization" & Constants.vbCrLf & "Namespace RichEditCodeResultViewer" & Constants.vbCrLf & "	Public Class ExampleItem" & Constants.vbCrLf & "		Public Shared Sub Process(ByVal doc As Document)" & Constants.vbCrLf & Constants.vbCrLf

		Private Const codeEnd_Renamed As String = Constants.vbCrLf & "		End Sub" & Constants.vbCrLf & "	End Class" & Constants.vbCrLf & "End Namespace" & Constants.vbCrLf

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
