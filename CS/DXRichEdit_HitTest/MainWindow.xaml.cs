using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#region usings
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Office.Utils;
#endregion #usings

namespace DXRichEdit_HitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            richEditControl1.Loaded += new RoutedEventHandler(richEditControl1_Loaded);
        }

        void richEditControl1_Loaded(object sender, RoutedEventArgs e)
        {
            richEditControl1.LoadDocument("sample.docx", DocumentFormat.OpenXml);
            biHitTest.CheckedChanged += new DevExpress.Xpf.Bars.ItemClickEventHandler(biHitTest_CheckedChanged);
            richEditControl1.Options.Bookmarks.Visibility = RichEditBookmarkVisibility.Visible;
            richEditControl1.Options.Bookmarks.Color = System.Drawing.Color.Red;
        }

        void biHitTest_CheckedChanged(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (this.biHitTest.IsChecked == true)
            {
                richEditControl1.MouseMove += new MouseEventHandler(richEditControl1_MouseMove);
            }
            else {
                richEditControl1.MouseMove -= new MouseEventHandler(richEditControl1_MouseMove);
            }
        }

        #region #hittest
        void richEditControl1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition((UIElement)richEditControl1);
            System.Drawing.PointF pt = new System.Drawing.PointF(Units.PixelsToDocumentsF((float)point.X,richEditControl1.DpiX),
                Units.PixelsToDocumentsF((float)point.Y, richEditControl1.DpiY));
            DocumentPosition pos = richEditControl1.GetPositionFromPoint(pt);

            BookmarkCollection bmCollection = richEditControl1.Document.Bookmarks;
            textBlock1.Text = String.Empty; //Clear a text block displaying bookmark info
            
            if (pos != null)
            {
                foreach (Bookmark bm in bmCollection)
                {
                    if (bm.Range.Contains(pos))
                    {
                        Bookmark bmHovered = bm;
                        richEditControl1.Document.Bookmarks.Select(bmHovered);
                        ShowBookmarkInTextBlock(bmHovered);
                        break;
                    }
                }
            }           
        }
        #endregion #hittest

        private void ShowBookmarkInTextBlock(Bookmark bm)
        {
            string textFragment = richEditControl1.Document.GetText(bm.Range);
            textBlock1.Text = String.Format("You are over a bookmark '{0}' containing text: '{1}'", bm.Name, textFragment);
        }




    }
}
