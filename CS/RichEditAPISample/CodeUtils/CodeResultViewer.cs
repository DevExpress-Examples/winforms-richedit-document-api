using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.Globalization;
using DevExpress.Spreadsheet;

namespace RichEditAPISample
{
    public abstract class RichEditExampleCodeEvaluator : ExampleCodeEvaluator
    {


        protected override string GetModuleAssembly()
        {
            return AssemblyInfo.SRAssemblyRichEditCore;
        }
        protected override string GetExampleClassName()
        {
            return "RichEditCodeResultViewer.ExampleItem";
        }
    }
    #region RichEditCSExampleCodeEvaluator
    public class RichEditCSExampleCodeEvaluator : RichEditExampleCodeEvaluator
    {

        protected override CodeDomProvider GetCodeDomProvider()
        {
            return new CSharpCodeProvider();
        }
        const string codeStart =
      "using System;\r\n" +
      "using DevExpress.XtraRichEdit;\r\n" +
      "using DevExpress.XtraRichEdit.API.Native;\r\n" +
      "using System.Drawing;\r\n" +
      "using System.Windows.Forms;\r\n" +
      "using DevExpress.Utils;\r\n" +
      "using System.IO;\r\n" +
      "using System.Diagnostics;\r\n" +
      "using System.Xml;\r\n" +
      "using System.Data;\r\n" +
      "using System.Collections.Generic;\r\n" +
      "using System.Linq;\r\n" +
      "using System.Globalization;\r\n" +
      "namespace RichEditCodeResultViewer { \r\n" +
      "public class ExampleItem { \r\n" +
      "        public static void Process(Document document) { \r\n" +
      "\r\n";

        const string codeEnd =
        "       \r\n }\r\n" +
        "    }\r\n" +
        "}\r\n";
        protected override string CodeStart { get { return codeStart; } }
        protected override string CodeEnd { get { return codeEnd; } }
    }
    #endregion
    #region RichEditVbExampleCodeEvaluator
    public class RichEditVbExampleCodeEvaluator : RichEditExampleCodeEvaluator
    {

        protected override CodeDomProvider GetCodeDomProvider()
        {
            return new Microsoft.VisualBasic.VBCodeProvider();
        }
        const string codeStart =
      "Imports Microsoft.VisualBasic\r\n" +
      "Imports System\r\n" +
      "Imports DevExpress.XtraRichEdit\r\n" +
      "Imports DevExpress.XtraRichEdit.API.Native\r\n" +
      "Imports System.Drawing\r\n" +
      "Imports System.Windows.Forms\r\n" +
      "Imports DevExpress.Utils\r\n" +
      "Imports System.IO\r\n" +
      "Imports System.Diagnostics\r\n" +
      "Imports System.Xml\r\n" +
      "Imports System.Data\r\n" +
      "Imports System.Core\r\n" +
      "Imports System.Collections.Generic\r\n" +
      "Imports System.Globalization\r\n" +
      "Namespace RichEditCodeResultViewer\r\n" +
      "	Public Class ExampleItem\r\n" +
      "		Public Shared Sub Process(ByVal document As Document)\r\n" +
      "\r\n";

        const string codeEnd =
        "\r\n		End Sub\r\n" +
        "	End Class\r\n" +
        "End Namespace\r\n";

        protected override string CodeStart { get { return codeStart; } }
        protected override string CodeEnd { get { return codeEnd; } }
    }
    #endregion
}
