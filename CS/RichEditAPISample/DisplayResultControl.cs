using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars.Docking;

namespace RichEditAPISample
{
    public partial class DisplayResultControl : UserControl
    {
        public DisplayResultControl()
        {
            InitializeComponent();
            richEditControl1.Options.Comments.Visibility = DevExpress.XtraRichEdit.RichEditCommentVisibility.Hidden;
            richEditControl1.Options.Comments.ShowAllAuthors = true;
        }

        public RichEditControl RichEdit { get { return richEditControl1; } }
        public Boolean ReviewingPaneFormVisible 
        {
            get { return (dockPanel1.Visibility != DockVisibility.Visible) ? true : false;}
            set { dockPanel1.Visibility = (value) ? DockVisibility.Visible : DockVisibility.Hidden; }
        }

        public DockPanel DockPanel
        {
            get {
                dockManager1.ForceInitialize();
                return dockPanel1; }
        }
}
    }
