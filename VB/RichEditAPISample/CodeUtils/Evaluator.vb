Namespace RichEditAPISample

'#Region "RichEditExampleEvaluatorByTimer"
    Public Class RichEditExampleEvaluatorByTimer
        Inherits ExampleEvaluatorByTimer

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Function GetExampleCodeEvaluator(ByVal language As ExampleLanguage) As ExampleCodeEvaluator
            If language = ExampleLanguage.VB Then Return New RichEditVbExampleCodeEvaluator()
            Return New RichEditCSExampleCodeEvaluator()
        End Function
    End Class
'#End Region
End Namespace
