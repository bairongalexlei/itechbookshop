using BookShop.EFData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.Forms
{
    public partial class frmReceiptSummary : Form
    {
        //private Common.SummarySearchParams searchParms;

        public frmReceiptSummary()
        {
            InitializeComponent();
        }

        public frmReceiptSummary(Common.SummarySearchParams summarySearchParms)
        {
            InitializeComponent();

            try
            {
                using (var dbContext = new BookShopEntities())
                {

                }
            }
            catch
            {

            }
        }

        private void fromReceiptSummary_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
