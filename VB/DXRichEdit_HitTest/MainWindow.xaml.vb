Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
#Region "usings"
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Utils
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.Office.Utils
#End Region ' #usings

Namespace DXRichEdit_HitTest
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			AddHandler richEditControl1.Loaded, AddressOf richEditControl1_Loaded
		End Sub

		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			richEditControl1.LoadDocument("sample.docx", DocumentFormat.OpenXml)
			AddHandler biHitTest.CheckedChanged, AddressOf biHitTest_CheckedChanged
			richEditControl1.Options.Bookmarks.Visibility = RichEditBookmarkVisibility.Visible
			richEditControl1.Options.Bookmarks.Color = System.Drawing.Color.Red
		End Sub

		Private Sub biHitTest_CheckedChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			If Me.biHitTest.IsChecked = True Then
				AddHandler richEditControl1.MouseMove, AddressOf richEditControl1_MouseMove
			Else
				RemoveHandler richEditControl1.MouseMove, AddressOf richEditControl1_MouseMove
			End If
		End Sub

		#Region "#hittest"
		Private Sub richEditControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim point As Point = e.GetPosition(CType(richEditControl1, UIElement))
			Dim pt As New System.Drawing.PointF(Units.PixelsToDocumentsF(CSng(point.X),richEditControl1.DpiX), Units.PixelsToDocumentsF(CSng(point.Y), richEditControl1.DpiY))
			Dim pos As DocumentPosition = richEditControl1.GetPositionFromPoint(pt)

			Dim bmCollection As BookmarkCollection = richEditControl1.Document.Bookmarks
			textBlock1.Text = String.Empty 'Clear a text block displaying bookmark info

			If pos IsNot Nothing Then
				For Each bm As Bookmark In bmCollection
					If bm.Range.Contains(pos) Then
						Dim bmHovered As Bookmark = bm
						richEditControl1.Document.SelectBookmark(bmHovered)
						ShowBookmarkInTextBlock(bmHovered)
						Exit For
					End If
				Next bm
			End If
		End Sub
		#End Region ' #hittest

		Private Sub ShowBookmarkInTextBlock(ByVal bm As Bookmark)
			Dim textFragment As String = richEditControl1.Document.GetText(bm.Range)
			textBlock1.Text = String.Format("You are over a bookmark '{0}' containing text: '{1}'", bm.Name, textFragment)
		End Sub




	End Class
End Namespace
