using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichEditAPISample.CodeExamples {
    class DocumentPropertiesActions {
        static void StandardDocumentProperties(Document document) {
            #region #StandardDocumentProperties
            document.BeginUpdate();

            document.DocumentProperties.Creator = "John Doe";
            document.DocumentProperties.Title = "Inserting Custom Properties";
            document.DocumentProperties.Category = "TestDoc";
            document.DocumentProperties.Description = "This code demonstrates API to modify and display standard document properties.";

            document.Fields.Create(document.AppendText("\nAUTHOR: ").End, "AUTHOR");
            document.Fields.Create(document.AppendText("\nTITLE: ").End, "TITLE");
            document.Fields.Create(document.AppendText("\nCOMMENTS: ").End, "COMMENTS");
            document.Fields.Create(document.AppendText("\nCREATEDATE: ").End, "CREATEDATE");
            document.Fields.Create(document.AppendText("\nCategory: ").End, "DOCPROPERTY Category");
            document.Fields.Update();
            document.EndUpdate();
            #endregion #StandardDocumentProperties
        }


        static void CustomDocumentProperties(Document document) {
            #region #CustomDocumentProperties
            document.BeginUpdate();
            document.AppendText("A new value of MyBookmarkProperty is obtained from here: NEWVALUE!\n");
            document.Bookmarks.Create(document.FindAll("NEWVALUE!", SearchOptions.CaseSensitive)[0], "bmOne");
            document.AppendText("\nMyNumericProperty: ");
            document.Fields.Create(document.Range.End, @"DOCPROPERTY ""MyNumericProperty""");
            document.AppendText("\nMyStringProperty: ");
            document.Fields.Create(document.Range.End, @"DOCPROPERTY ""MyStringProperty""");
            document.AppendText("\nMyBooleanProperty: ");
            document.Fields.Create(document.Range.End, @"DOCPROPERTY ""MyBooleanProperty""");
            document.AppendText("\nMyBookmarkProperty: ");
            document.Fields.Create(document.Range.End, @"DOCPROPERTY ""MyBookmarkProperty""");
            document.EndUpdate();

            document.CustomProperties["MyNumericProperty"]= 123.45;
            document.CustomProperties["MyStringProperty"]="The Final Answer";
            document.CustomProperties["MyBookmarkProperty"] = document.Bookmarks[0];
            document.CustomProperties["MyBooleanProperty"]=true;

            document.Fields.Update();
            #endregion #CustomDocumentProperties
        }
    }
}