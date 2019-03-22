# WinForms RichEdit Document API

*Files to look at*:

* [CodeExamples](./CS/RichEditAPISample/CodeExamples) (VB: [CodeExamples](./VB/RichEditAPISample/CodeExamples))

<p>This example demonstrates how to use RichEdit Document API to manage rich text documents in code.<br />The application includes several RichEditControls at the top used to display and edit the code and another RichEditControl (at the bottom) which shows the result of code execution. There are two groups of tabs displaying code - one for C# and another for VB languages. Each group is composed of the main tab displaying the main executable code and the tab which displays the code of the helper class used in the main code snippet. Generally the helper class is not required and the corresponding tab is empty.<br />You can modify the code and watch the result. The code is executed two seconds after it is modified. If an error occurs during compilation or execution, the code window background color turns to pink.<br /><br />The <a href="https://www.devexpress.com/Support/Center/p/T213968">WPF RichEdit Document API</a> example is also available.</p>

<br/>