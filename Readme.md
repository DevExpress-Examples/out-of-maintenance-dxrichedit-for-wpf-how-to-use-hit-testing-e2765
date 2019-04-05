<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXRichEdit_HitTest/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXRichEdit_HitTest/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXRichEdit_HitTest/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXRichEdit_HitTest/MainWindow.xaml.vb))
<!-- default file list end -->
# DXRichEdit for WPF: How to use hit testing


<p>This example illustrates handling the <strong>MouseMove </strong>event of the RichEditControl and using the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfRichEditRichEditControl_GetPositionFromPointtopic"><u>GetPositionFromPoint</u></a> method to obtain the corresponding position in the document. <br />
If the position under the mouse cursor belongs to a <a href="http://documentation.devexpress.com/#WPF/CustomDocument9103"><u>bookmark</u></a>, this bookmark is selected using the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSubDocument_SelectBookmarktopic"><u>SelectBookmark</u></a> method and the bookmark's name and a text fragment are displayed in the text box below.</p>

<br/>


