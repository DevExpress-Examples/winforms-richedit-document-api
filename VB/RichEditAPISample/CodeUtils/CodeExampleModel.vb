Imports Microsoft.VisualBasic
Imports System.CodeDom.Compiler
Imports DevExpress.Internal
Imports System.Reflection
Imports System.IO
Imports System.Text.RegularExpressions
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace RichEditAPISample
	 Public Class CodeExampleGroup
		Public Sub New()
		End Sub
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateExamples As List(Of CodeExample)
		Public Property Examples() As List(Of CodeExample)
			Get
				Return privateExamples
			End Get
			Set(ByVal value As List(Of CodeExample))
				privateExamples = value
			End Set
		End Property
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
	 End Class

	Public Class CodeExample
		Private privateCodeCS As String
		Public Property CodeCS() As String
			Get
				Return privateCodeCS
			End Get
			Set(ByVal value As String)
				privateCodeCS = value
			End Set
		End Property
		Private privateCodeCsHelper As String
		Public Property CodeCsHelper() As String
			Get
				Return privateCodeCsHelper
			End Get
			Set(ByVal value As String)
				privateCodeCsHelper = value
			End Set
		End Property
		Private privateCodeVB As String
		Public Property CodeVB() As String
			Get
				Return privateCodeVB
			End Get
			Set(ByVal value As String)
				privateCodeVB = value
			End Set
		End Property
		Private privateCodeVbHelper As String
		Public Property CodeVbHelper() As String
			Get
				Return privateCodeVbHelper
			End Get
			Set(ByVal value As String)
				privateCodeVbHelper = value
			End Set
		End Property
		Private privateRegionName As String
		Public Property RegionName() As String
			Get
				Return privateRegionName
			End Get
			Set(ByVal value As String)
				privateRegionName = value
			End Set
		End Property
		Private privateHumanReadableGroupName As String
		Public Property HumanReadableGroupName() As String
			Get
				Return privateHumanReadableGroupName
			End Get
			Set(ByVal value As String)
				privateHumanReadableGroupName = value
			End Set
		End Property
		Private privateExampleGroup As String
		Public Property ExampleGroup() As String
			Get
				Return privateExampleGroup
			End Get
			Set(ByVal value As String)
				privateExampleGroup = value
			End Set
		End Property
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
	End Class

	Public Class CodeExampleCollection
		Inherits List(Of CodeExample)
		Public Sub Merge(ByVal example As CodeExample)
			Dim item As CodeExample = Me.Find(Function(x) x.HumanReadableGroupName.Equals(example.HumanReadableGroupName) AndAlso x.RegionName.Equals(example.RegionName))
			If item Is Nothing Then
				item = New CodeExample()
				item.HumanReadableGroupName = example.HumanReadableGroupName
				item.RegionName = example.RegionName
				Me.Add(item)
			End If
			item.CodeCS += example.CodeCS
			item.CodeCsHelper += example.CodeCsHelper
			item.CodeVB += example.CodeVB
			item.CodeVbHelper += example.CodeVbHelper
		End Sub

		Public Sub Merge(ByVal exampleList As List(Of CodeExample))
			For Each item As CodeExample In exampleList
				Me.Merge(item)
			Next item
		End Sub
	End Class


	Public Enum ExampleLanguage
		Csharp = 0
		VB = 1
	End Enum
End Namespace
