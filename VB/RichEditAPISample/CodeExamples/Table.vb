Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RichEditAPISample.CodeExamples

    Friend Class TableActions

        Private Shared Sub CreateTable(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateTable"
            ' Insert new table.
            Dim tbl As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 1, 3, DevExpress.XtraRichEdit.API.Native.AutoFitBehaviorType.AutoFitToWindow)
            ' Create a table header.
            document.InsertText(tbl(CInt((0)), CInt((0))).Range.Start, "Name")
            document.InsertText(tbl(CInt((0)), CInt((1))).Range.Start, "Size")
            document.InsertText(tbl(CInt((0)), CInt((2))).Range.Start, "DateTime")
            ' Insert table data.
            Dim dirinfo As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("C:\")
            Try
                tbl.BeginUpdate()
                For Each fi As System.IO.FileInfo In dirinfo.GetFiles()
                    Dim row As DevExpress.XtraRichEdit.API.Native.TableRow = tbl.Rows.Append()
                    Dim cell As DevExpress.XtraRichEdit.API.Native.TableCell = row.FirstCell
                    Dim fileName As String = fi.Name
                    Dim fileLength As String = System.[String].Format("{0:N0}", fi.Length)
                    Dim fileLastTime As String = System.[String].Format("{0:g}", fi.LastWriteTime)
                    document.InsertSingleLineText(cell.Range.Start, fileName)
                    document.InsertSingleLineText(cell.[Next].Range.Start, fileLength)
                    document.InsertSingleLineText(cell.[Next].[Next].Range.Start, fileLastTime)
                Next

                ' Center the table header.
                For Each p As DevExpress.XtraRichEdit.API.Native.Paragraph In document.Paragraphs.[Get](tbl.FirstRow.Range)
                    p.Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Center
                Next
            Finally
                tbl.EndUpdate()
            End Try
'#End Region  ' #CreateTable
        End Sub

        Private Shared Sub CreateFixedTable(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateFixedTable"
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 3, 3)
            table.TableAlignment = DevExpress.XtraRichEdit.API.Native.TableRowAlignment.Center
            table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Fixed
            table.PreferredWidthType = DevExpress.XtraRichEdit.API.Native.WidthType.Fixed
            table.PreferredWidth = DevExpress.Office.Utils.Units.InchesToDocumentsF(4F)
            table.Rows(CInt((1))).HeightType = DevExpress.XtraRichEdit.API.Native.HeightType.Exact
            table.Rows(CInt((1))).Height = DevExpress.Office.Utils.Units.InchesToDocumentsF(0.8F)
            table(CInt((1)), CInt((1))).PreferredWidthType = DevExpress.XtraRichEdit.API.Native.WidthType.Fixed
            table(CInt((1)), CInt((1))).PreferredWidth = DevExpress.Office.Utils.Units.InchesToDocumentsF(1.5F)
'#End Region  ' #CreateFixedTable
        End Sub

        Private Shared Sub ChangeTableColor(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ChangeTableColor"
            ' Create a table.
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 3, 5, DevExpress.XtraRichEdit.API.Native.AutoFitBehaviorType.AutoFitToWindow)
            table.BeginUpdate()
            ' Provide the space between table cells.
            ' The distance between cells will be 4 mm.
            document.Unit = DevExpress.Office.DocumentUnit.Millimeter
            table.TableCellSpacing = 2
            ' Change the color of empty space between cells.
            table.TableBackgroundColor = System.Drawing.Color.Violet
            'Change cell background color.
            table.ForEachCell(New DevExpress.XtraRichEdit.API.Native.TableCellProcessorDelegate(AddressOf RichEditAPISample.CodeExamples.TableActions.TableHelper.ChangeCellColor))
            table.EndUpdate()
'#End Region  ' #ChangeTableColor
        End Sub

'#Region "#@ChangeTableColor"
        Private Class TableHelper

            Public Shared Sub ChangeCellColor(ByVal cell As DevExpress.XtraRichEdit.API.Native.TableCell, ByVal i As Integer, ByVal j As Integer)
                cell.BackgroundColor = System.Drawing.Color.Yellow
            End Sub
        End Class

'#End Region  ' #@ChangeTableColor
        Private Shared Sub CreateAndApplyTableStyle(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#CreateAndApplyTableStyle"
            document.BeginUpdate()
            ' Create a new table style.
            Dim tStyleMain As DevExpress.XtraRichEdit.API.Native.TableStyle = document.TableStyles.CreateNew()
            ' Specify style characteristics.
            tStyleMain.AllCaps = True
            tStyleMain.FontName = "Segoe Condensed"
            tStyleMain.FontSize = 14
            tStyleMain.Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Center
            tStyleMain.TableBorders.InsideHorizontalBorder.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.Dotted
            tStyleMain.TableBorders.InsideVerticalBorder.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.Dotted
            tStyleMain.TableBorders.Top.LineThickness = 1.5F
            tStyleMain.TableBorders.Top.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.[Double]
            tStyleMain.TableBorders.Left.LineThickness = 1.5F
            tStyleMain.TableBorders.Left.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.[Double]
            tStyleMain.TableBorders.Bottom.LineThickness = 1.5F
            tStyleMain.TableBorders.Bottom.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.[Double]
            tStyleMain.TableBorders.Right.LineThickness = 1.5F
            tStyleMain.TableBorders.Right.LineStyle = DevExpress.XtraRichEdit.API.Native.TableBorderLineStyle.[Double]
            tStyleMain.CellBackgroundColor = System.Drawing.Color.LightBlue
            tStyleMain.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Fixed
            tStyleMain.Name = "MyTableStyle"
            'Add the style to the document.
            document.TableStyles.Add(tStyleMain)
            document.EndUpdate()
            document.BeginUpdate()
            ' Create a table.
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 3, 3)
            table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Fixed
            table.PreferredWidthType = DevExpress.XtraRichEdit.API.Native.WidthType.Fixed
            table.PreferredWidth = DevExpress.Office.Utils.Units.InchesToDocumentsF(4.5F)
            table(CInt((1)), CInt((1))).PreferredWidthType = DevExpress.XtraRichEdit.API.Native.WidthType.Fixed
            table(CInt((1)), CInt((1))).PreferredWidth = DevExpress.Office.Utils.Units.InchesToDocumentsF(1.5F)
            ' Apply a previously defined style.
            table.Style = tStyleMain
            document.EndUpdate()
            document.InsertText(table(CInt((1)), CInt((1))).Range.Start, "STYLED")
'#End Region  ' #CreateAndApplyTableStyle
        End Sub

        Private Shared Sub UseConditionalStyle(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#UseConditionalStyle"
            document.LoadDocument("TableStyles.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            document.BeginUpdate()
            ' Create a new style that is based on the 'Grid Table 5 Dark Accent 1' style defined in the loaded document.
            Dim myNewStyle As DevExpress.XtraRichEdit.API.Native.TableStyle = document.TableStyles.CreateNew()
            myNewStyle.Parent = document.TableStyles("Grid Table 5 Dark Accent 1")
            ' Create conditional styles (styles for table elements)
            Dim myNewStyleForFirstRow As DevExpress.XtraRichEdit.API.Native.TableConditionalStyle = myNewStyle.ConditionalStyleProperties.CreateConditionalStyle(DevExpress.XtraRichEdit.API.Native.ConditionalTableStyleFormattingTypes.FirstRow)
            myNewStyleForFirstRow.CellBackgroundColor = System.Drawing.Color.PaleVioletRed
            Dim myNewStyleForFirstColumn As DevExpress.XtraRichEdit.API.Native.TableConditionalStyle = myNewStyle.ConditionalStyleProperties.CreateConditionalStyle(DevExpress.XtraRichEdit.API.Native.ConditionalTableStyleFormattingTypes.FirstColumn)
            myNewStyleForFirstColumn.CellBackgroundColor = System.Drawing.Color.PaleVioletRed
            Dim myNewStyleForOddColumns As DevExpress.XtraRichEdit.API.Native.TableConditionalStyle = myNewStyle.ConditionalStyleProperties.CreateConditionalStyle(DevExpress.XtraRichEdit.API.Native.ConditionalTableStyleFormattingTypes.OddColumnBanding)
            myNewStyleForOddColumns.CellBackgroundColor = System.Windows.Forms.ControlPaint.Light(System.Drawing.Color.PaleVioletRed)
            Dim myNewStyleForEvenColumns As DevExpress.XtraRichEdit.API.Native.TableConditionalStyle = myNewStyle.ConditionalStyleProperties.CreateConditionalStyle(DevExpress.XtraRichEdit.API.Native.ConditionalTableStyleFormattingTypes.EvenColumnBanding)
            myNewStyleForEvenColumns.CellBackgroundColor = System.Windows.Forms.ControlPaint.LightLight(System.Drawing.Color.PaleVioletRed)
            document.TableStyles.Add(myNewStyle)
            ' Create a new table and apply a new style.
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.[End], 4, 4, DevExpress.XtraRichEdit.API.Native.AutoFitBehaviorType.AutoFitToWindow)
            table.Style = myNewStyle
            ' Specify which conditonal styles are in effect.
            table.TableLook = DevExpress.XtraRichEdit.API.Native.TableLookTypes.ApplyFirstRow Or DevExpress.XtraRichEdit.API.Native.TableLookTypes.ApplyFirstColumn
            document.EndUpdate()
'#End Region  ' #UseConditionalStyle
        End Sub

        Private Shared Sub ChangeColumnAppearance(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ChangeColumnAppearance"
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 3, 10)
            table.BeginUpdate()
            'Change cell background color and vertical alignment in the third column.
            table.ForEachRow(New DevExpress.XtraRichEdit.API.Native.TableRowProcessorDelegate(AddressOf RichEditAPISample.CodeExamples.TableActions.ChangeColumnAppearanceHelper.ChangeColumnColor))
            table.EndUpdate()
'#End Region  ' #ChangeColumnAppearance
        End Sub

'#Region "#@ChangeColumnAppearance"
        Private Class ChangeColumnAppearanceHelper

            Public Shared Sub ChangeColumnColor(ByVal row As DevExpress.XtraRichEdit.API.Native.TableRow, ByVal rowIndex As Integer)
                row(CInt((2))).BackgroundColor = System.Drawing.Color.LightCyan
                row(CInt((2))).VerticalAlignment = DevExpress.XtraRichEdit.API.Native.TableCellVerticalAlignment.Center
            End Sub
        End Class

'#End Region  ' #@ChangeColumnAppearance
        Private Shared Sub UseTableCellProcessor(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#UseTableCellProcessor"
            Dim table As DevExpress.XtraRichEdit.API.Native.Table = document.Tables.Create(document.Range.Start, 8, 8)
            table.BeginUpdate()
            table.ForEachCell(New DevExpress.XtraRichEdit.API.Native.TableCellProcessorDelegate(AddressOf RichEditAPISample.CodeExamples.TableActions.UseTableCellProcessorHelper.MakeMultiplicationCell))
            table.EndUpdate()
'#End Region  ' #UseTableCellProcessor
        End Sub

'#Region "#@UseTableCellProcessor"
        Private Class UseTableCellProcessorHelper

            Public Shared Sub MakeMultiplicationCell(ByVal cell As DevExpress.XtraRichEdit.API.Native.TableCell, ByVal i As Integer, ByVal j As Integer)
                Dim doc As DevExpress.XtraRichEdit.API.Native.SubDocument = cell.Range.BeginUpdateDocument()
                doc.InsertText(cell.Range.Start, System.[String].Format("{0}*{1} = {2}", i + 2, j + 2, (i + 2) * (j + 2)))
                cell.Range.EndUpdateDocument(doc)
            End Sub
        End Class
'#End Region  ' #@UseTableCellProcessor
    End Class
End Namespace
