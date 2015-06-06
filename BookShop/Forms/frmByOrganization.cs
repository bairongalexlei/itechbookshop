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
    public partial class frmByOrganization : Form
    {
        public frmByOrganization()
        {
            InitializeComponent();
        }

        private void frmByOrganization_Load(object sender, EventArgs e)
        {

            this.rptByOrganizationViewer.RefreshReport();
        }
    }
}
