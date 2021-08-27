<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128607248/20.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2765)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXRichEdit_HitTest/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXRichEdit_HitTest/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXRichEdit_HitTest/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXRichEdit_HitTest/MainWindow.xaml.vb))
<!-- default file list end -->
# DXRichEdit for WPF: How to use hit testing


<p>This example illustrates handling the <strong>MouseMove </strong>event of the RichEditControl and using the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfRichEditRichEditControl_GetPositionFromPointtopic"><u>GetPositionFromPoint</u></a> method to obtain the corresponding position in the document. <br />
If the position under the mouse cursor belongs to a <a href="http://documentation.devexpress.com/#WPF/CustomDocument9103"><u>bookmark</u></a>, this bookmark is selected using the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSubDocument_SelectBookmarktopic"><u>SelectBookmark</u></a> method and the bookmark's name and a text fragment are displayed in the text box below.</p>

<br/>


