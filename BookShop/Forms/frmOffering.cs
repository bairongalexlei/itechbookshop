﻿using BookShop.Common;
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

            DataGridViewComboBoxColumn departmentColumn = (DataGridViewComboBoxColumn)dataGridViewOfferLines.Columns[0];
            departmentColumn.DataSource = GetDepartmentProjectNames();
            departmentColumn.ValueMember = "Value";
            departmentColumn.DisplayMember = "Text";

        }

        public frmOffering(int AccountId, int OfferingId)
        {
            InitializeComponent();
            
            if (AccountId > 0)
            {
                accountId = AccountId;
                cmbAccountId.Text = accountId.ToString();
                cmbAccountId.Enabled = false;
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

            DataGridViewComboBoxColumn departmentColumn = (DataGridViewComboBoxColumn)dataGridViewOfferLines.Columns[0];
            departmentColumn.DataSource = GetDepartmentProjectNames();
            departmentColumn.ValueMember = "Value";
            departmentColumn.DisplayMember = "Text";

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

                            BindOfferingLineItems(dbContext);

                            //bind amount, payment method and receipt type
                            decimal amount = oneOffering.Amount ?? 0;
                            txtAmount.Text = amount.ToString();
                            txtSubtotal.Text = amount.ToString();

                            int paymentMethodId = oneOffering.MethodId ?? 0;
                            if (paymentMethodId > 0)
                                cmbOfferingMethod.SelectedIndex = paymentMethodId - 1;

                            int receiptTypeId = oneOffering.ReceiptTypeId ?? 0;
                            if (receiptTypeId > 0)
                                cmbOfferingReceiptType.SelectedIndex = receiptTypeId - 1;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error on populating offering information. Please contact iTech support for assistance.");
                    return;
                }
            }
        }

        private void BindOfferingLineItems(BookShopEntities dbContext)
        {
            if (offeringId <= 0)
                return;

            var offeringLineItems = dbContext.OfferingLines.Where(ofl => ofl.OfferingId == offeringId).ToList();
            var offeringLineItemBEs = offeringLineItems.Select(offr =>
                {
                    //int? projectId = offr.ProjectId;
                    //string projectName = string.Empty;
                    //string departmentName = string.Empty;

                    //if (projectId.HasValue && projectId.Value > 0)
                    //{
                    //    var project = dbContext.Projects.FirstOrDefault(proj =>
                    //        proj.ProjectId == projectId.Value);

                    //    if (project != null)
                    //    {
                    //        projectName = project.Description;
                    //        departmentName = project.Department.DepartmentName;
                    //    }
                    //}

                    //return new
                    //{
                    //    Amount = offr.Amount,
                    //    ProjectDepartment =
                    //        string.IsNullOrEmpty(departmentName) ?
                    //        projectName : string.Format("{0} - {1}", projectName, departmentName)
                    //};

                    return new
                    {
                        Amount = offr.Amount,
                        ProjectId = offr.ProjectId ?? 0
                    };
                }).ToList();

            foreach (var oneOfferingLineItemBE in offeringLineItemBEs)
            {
                dataGridViewOfferLines.Rows.Add(oneOfferingLineItemBE.ProjectId, oneOfferingLineItemBE.Amount);
            }
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

        private List<ComboboxItem> GetDepartmentProjectNames()
        {
            List<ComboboxItem> resultNames = null;

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
                                            DepartmentName = proj.Department != null ? proj.Department.DepartmentName : "",
                                            ProjectId = proj.ProjectId
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

                        ComboboxItem oneComboboxItem = new ComboboxItem
                        {
                            Text = result,
                            Value = pdPair.ProjectId
                        };

                        return oneComboboxItem;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var fieldsValidErrorMessages = GetFieldsValidErrorMessage();
            if (fieldsValidErrorMessages != null && fieldsValidErrorMessages.Count > 0)
            {
                MessageBox.Show(string.Join("\n", fieldsValidErrorMessages));
                return;
            }

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    bool addNewOffering = false;
                    var offering = dbContext.Offerings.FirstOrDefault(ofr => ofr.OfferingId == offeringId);
                    if (offering == null)
                    {
                        offering = new Offering();
                        offering.CreatedDate = DateTime.Now;
                        addNewOffering = true;
                    }

                    offering.AccountId = accountId;
                    offering.MethodId = (int)cmbOfferingMethod.SelectedIndex + 1;
                    offering.ReceiptTypeId = (int)cmbOfferingReceiptType.SelectedIndex + 1;

                    string strTotalAmount = txtAmount.Text;
                    decimal totalAmount = 0;
                    decimal.TryParse(strTotalAmount, out totalAmount);
                    offering.Amount = totalAmount;
                    offering.LastUpdatedDate = DateTime.Now;
                    offering.SignatureUserId = 1;

                    if (addNewOffering) {
                        offering.StatusId = (int)CommonEnum.Status.Active;
                        dbContext.Offerings.Add(offering);

                        foreach (DataGridViewRow oneRow in dataGridViewOfferLines.Rows)
                        {
                            int? oneRowProjectId = (int?)oneRow.Cells[0].Value;

                            decimal oneOfferItemAmount = 0;
                            var txtOneRowAmount = oneRow.Cells[1];
                            decimal.TryParse((string)txtOneRowAmount.Value, out oneOfferItemAmount);

                            if (!oneRowProjectId.HasValue || oneOfferItemAmount <= 0)
                                break;

                            var oneOfferLineItem = new OfferingLine();
                            oneOfferLineItem.Amount = oneOfferItemAmount;
                            oneOfferLineItem.CreatedDate = DateTime.Now;
                            oneOfferLineItem.LastUpdatedDate = DateTime.Now;
                            oneOfferLineItem.OfferingId = offering.OfferingId;
                            oneOfferLineItem.ProjectId = oneRowProjectId.Value;
                            oneOfferLineItem.StatusId = (int)CommonEnum.Status.Active;
                            oneOfferLineItem.Percent = oneOfferItemAmount / totalAmount;

                            dbContext.OfferingLines.Add(oneOfferLineItem);
                        }
                    }
                    else
                    {
                        //need test
                        var offeringItemsToRemove = dbContext.OfferingLines.Where(offl => 
                            offl.OfferingId == offering.OfferingId);

                        if (offeringItemsToRemove != null && offeringItemsToRemove.Count() > 0)
                            dbContext.OfferingLines.RemoveRange(offeringItemsToRemove);

                        foreach (DataGridViewRow oneRow in dataGridViewOfferLines.Rows)
                        {
                            int? oneRowProjectId = (int?)oneRow.Cells[0].Value;

                            decimal oneOfferItemAmount = 0;
                            var txtOneRowAmount = oneRow.Cells[1];
                            decimal.TryParse((string)txtOneRowAmount.Value, out oneOfferItemAmount);

                            if (!oneRowProjectId.HasValue || oneOfferItemAmount <= 0)
                                break;

                            var oneOfferLineItem = new OfferingLine();
                            oneOfferLineItem.Amount = oneOfferItemAmount;
                            oneOfferLineItem.CreatedDate = DateTime.Now;
                            oneOfferLineItem.LastUpdatedDate = DateTime.Now;
                            oneOfferLineItem.OfferingId = offering.OfferingId;
                            oneOfferLineItem.ProjectId = oneRowProjectId.Value;
                            oneOfferLineItem.StatusId = (int)CommonEnum.Status.Active;
                            oneOfferLineItem.Percent = oneOfferItemAmount / totalAmount;

                            dbContext.OfferingLines.Add(oneOfferLineItem);
                        }
                    }

                    dbContext.SaveChanges();
                }

                MessageBox.Show("Offering was saved successfully");
                Close();
            }
            catch
            {
                MessageBox.Show("Error on saving offering. Please contact iTech support for assistance.");
                return;
            }
        }

        private List<string> GetFieldsValidErrorMessage()
        {
            List<string> errorMessages = new List<string>();

            if (accountId <= 0)
                errorMessages.Add("Account is not selected.");

            if (cmbOfferingMethod.SelectedIndex < 0)
                errorMessages.Add("Payment method is not selected.");

            float amount = 0;
            float.TryParse(txtAmount.Text, out amount);
            if (amount <= 0)
                errorMessages.Add("Amount is not valid.");

            if (cmbOfferingReceiptType.SelectedIndex < 0)
                errorMessages.Add("Receipt type is not selected.");

            float rowsSubtotal = 0;
            foreach(DataGridViewRow oneRow in dataGridViewOfferLines.Rows)
            {
                int? oneRowProjectId = (int?)oneRow.Cells[0].Value;

                float oneOfferItemAmount = 0;
                var txtOneRowAmount = oneRow.Cells[1];
                float.TryParse((string)txtOneRowAmount.Value, out oneOfferItemAmount);

                if (!oneRowProjectId.HasValue && oneOfferItemAmount <= 0)
                    break;

                if (oneOfferItemAmount <= 0)
                {
                    errorMessages.Add("Offering line item value is not valid or can not be empty.");
                    break;
                }

                if (!oneRowProjectId.HasValue)
                {
                    errorMessages.Add("Offering line item's project/department is not set.");
                    break;
                }

                rowsSubtotal = rowsSubtotal + oneOfferItemAmount;
            }

            if (rowsSubtotal != amount)
                errorMessages.Add("Offering line item's subtotal is not equal to user amount.");

            //var oneRow = dataGridViewOfferLines.Rows[0];

            //var oneColumn = oneRow.Cells[0];

            //var value = oneColumn.Value;

            return errorMessages;
        }

        public void dataGridViewOfferLines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                var txtBox = e.Control as TextBox;
                txtBox.TextChanged -= new EventHandler(offeringLineItemAmount_TextChanged);
                txtBox.TextChanged += new EventHandler(offeringLineItemAmount_TextChanged);
            }
        }

        private void offeringLineItemAmount_TextChanged(object sender, EventArgs e)
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow oneRow in dataGridViewOfferLines.Rows)
            {
                decimal oneOfferItemAmount = 0;
                var txtOneRowAmount = oneRow.Cells[1];
                decimal.TryParse((string)txtOneRowAmount.EditedFormattedValue, out oneOfferItemAmount);

                subTotal = subTotal + oneOfferItemAmount;
            }

            txtSubtotal.Text = subTotal.ToString();
        }
    }
}