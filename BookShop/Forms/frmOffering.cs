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
    public partial class frmOffering : Form
    {
        private int accountId;
        private int offeringId;
        //private List<Tuple<int, decimal>> offerLineItems;

        public frmOffering()
        {
            InitializeComponent();

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    int currentMaxOfferingId = 0;
                    var lastOffering = dbContext.Offerings.OrderByDescending(offr => offr.OfferingId).FirstOrDefault();
                    if (lastOffering != null)
                    {
                        currentMaxOfferingId = lastOffering.OfferingId;
                    }
                    txtOfferingId.Text = (++currentMaxOfferingId).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error on getting new offering id. Please contact iTech support for assistance.");
                return;
            }

            //dataGridViewOfferLines.Columns[0].DataPropertyName = "Item1";
            //dataGridViewOfferLines.Columns[1].DataPropertyName = "Item2";
            //offerLineItems = new List<Tuple<int, decimal>>();
            //dataGridViewOfferLines.DataSource = offerLineItems;

            //dataGridViewOfferLines.Columns[0].DataGridView.DataSource = GetDepartmentProjectNames();
            DataGridViewComboBoxColumn a = (DataGridViewComboBoxColumn)dataGridViewOfferLines.Columns[0];
            a.DataSource = GetDepartmentProjectNames();
        }

        public frmOffering(int AccountId, int OfferingId)
        {
            InitializeComponent();
            
            if (AccountId > 0)
            {
                accountId = AccountId;
                cmbAccountId.Text = accountId.ToString();
                cmbAccountId.Enabled = false; 
            }

            if (OfferingId > 0)
            {
                offeringId = OfferingId;
                try
                {
                    using (var dbContext = new BookShopEntities())
                    {
                        var oneOffering = dbContext.Offerings.FirstOrDefault(ofr => 
                            ofr.OfferingId == offeringId &&
                            ofr.StatusId == (int)Common.CommonEnum.Status.Active);

                        if (oneOffering != null)
                        {
                            txtOfferingId.Text = offeringId.ToString();
                            txtReceivedDate.Text = oneOffering.CreatedDate.ToShortDateString();
                            txtOfferYear.Text = oneOffering.CreatedDate.Year.ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error on populating offering information. Please contact iTech support for assistance.");
                    return;
                }
            }

            //dataGridViewOfferLines.Columns[0].DataPropertyName = "Item1";
            //dataGridViewOfferLines.Columns[1].DataPropertyName = "Item2";
            //offerLineItems = new List<Tuple<int, decimal>>();
            //dataGridViewOfferLines.DataSource = offerLineItems;
        }

        private void frmOffering_Load(object sender, EventArgs e)
        {
            cmbAccountId.DropDown +=
                new System.EventHandler(cmbAccountId_DropDown);
        }

        private void cmbAccountId_DropDown(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var accountIds = dbContext.Accounts.Where(acct => acct.StatusId == 1)
                            .Select(ac => ac.AccountId.ToString()).ToList();

                    accountIds.Insert(0, "");
                    cmbAccountId.DataSource = accountIds;
                }
            }
            catch
            {
                MessageBox.Show("Error on getting account id list. Please contact iTech support for assistance.");
            }
        }

        private void cmbAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountId.SelectedIndex == -1 || string.IsNullOrEmpty(cmbAccountId.Text))
                return;

            //clear account fields
            txtAccountType.Clear();
            txtOrganization.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtUnit.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            txtCountry.Clear();
            txtPostalCode.Clear();
            txtTitle.Clear();

            string strAccountId = cmbAccountId.Text;
            int.TryParse(strAccountId, out accountId);
            cmbAccountId.Text = accountId.ToString();

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var account = dbContext.Accounts.FirstOrDefault(ac =>
                        ac.AccountId == accountId &&
                        ac.StatusId == (int)Common.CommonEnum.Status.Active);

                    if (account == null)
                    {
                        MessageBox.Show("The account does not exist any more.");
                        return;
                    }

                    txtAccountType.Text = ((Common.CommonEnum.AccountType)account.AccountTypeId).ToString();
                    txtOrganization.Text = account.OrganizationName;
                    txtLastName.Text = account.LastName;
                    txtFirstName.Text = account.FirstName;
                    txtTitle.Text = account.Title;

                    var accountAddress = account.Address;
                    if (accountAddress != null)
                    {
                        txtUnit.Text = accountAddress.UnitSuiteNumber.ToString();
                        txtStreet.Text = accountAddress.StreetName;
                        txtCity.Text = accountAddress.City;
                        txtProvince.Text = accountAddress.Province;
                        txtCountry.Text = accountAddress.Country;
                        txtPostalCode.Text = accountAddress.PostalCode;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error on populating account information. Please contact iTech support for assistance.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dataGridViewOfferLines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //if (dataGridViewOfferLines.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
        //    //{
        //    //    ComboBox comboBox = e.Control as ComboBox;
        //    //    //comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;

        //    //}

        //    if (e.Control is ComboBox)
        //    {
        //        ComboBox comboBox = e.Control as ComboBox;
        //        //comboBox.DataSource = GetDepartmentProjectNames();
        //        //comboBox.DropDown += PopulateDepartments;
        //    }
        //}

        //private void PopulateDepartments(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //var sendingCB = sender as DataGridViewComboBoxEditingControl;
        //        var sendingCB = sender as ComboBox;

        //        var namesSource = GetDepartmentProjectNames();

        //        sendingCB.DataSource = namesSource;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error on getting departments. Please contact iTech support for assistance.");
        //    }
        //}

        private List<string> GetDepartmentProjectNames()
        {
            List<string> resultNames = null;

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var projects = dbContext.Projects.Where(proj =>
                                    proj.StatusId == (int)Common.CommonEnum.Status.Active);

                    var projectDepartmentNames =
                        projects.Select(proj =>
                                        new
                                        {
                                            ProjctName = proj.Description,
                                            DepartmentName = proj.Department != null ? proj.Department.DepartmentName : ""
                                        }).ToList();

                    var namesSource = projectDepartmentNames.Select(pdPair =>
                    {
                        string result;
                        if (!string.IsNullOrEmpty(pdPair.DepartmentName))
                        {
                            result = string.Format("{0} - {1}", pdPair.ProjctName, pdPair.DepartmentName);
                        }
                        else
                        {
                            result = pdPair.ProjctName;
                        }
                        return result;
                    }).ToList();

                    resultNames = namesSource;
                }
            }
            catch
            {
                MessageBox.Show("Error on getting departments. Please contact iTech support for assistance.");
            }

            return resultNames;
        }
    }
}
