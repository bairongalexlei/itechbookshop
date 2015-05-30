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
    public partial class frmEditAccount : Form
    {
        private int accountId;
        private int addressId;

        public frmEditAccount()
        {
            InitializeComponent();
        }
        
        public frmEditAccount(int AccountId)
        {
            InitializeComponent();
            accountId = AccountId;
        }

        private void frmEditAccount_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var account = dbContext.Accounts.FirstOrDefault(ac => ac.AccountId == accountId);
                    if (account == null)
                    {
                        MessageBox.Show("Account does not exists.");
                        return;
                    }

                    txtAccountId.Text = accountId.ToString();
                    cmbAccountType.SelectedIndex = account.AccountTypeId - 1;
                    txtOrganization.Text = account.OrganizationName;
                    txtLastName.Text = account.LastName;
                    txtFirstName.Text = account.FirstName;
                    if ((account.LanguageId ?? 0) > 0)
                    {
                        cmbLanguage.SelectedIndex = account.LanguageId.Value - 1; 
                    }

                    txtTitle.Text = account.Title;
                    txtChineseName.Text = account.ChineseName;
                    txtSpouse.Text = account.SpouseFirstName;
                    maskedTxtPhone.Text = account.Phone;
                    maskedTxtFax.Text = account.Fax;
                    txtEmail.Text = account.Email;

                    addressId = account.AddressId;
                    var accountAddress = account.Address;
                    if (accountAddress != null)
                    {
                        txtUnit.Text = (accountAddress.UnitSuiteNumber ?? 0) > 0 ? 
                            accountAddress.UnitSuiteNumber.ToString() : "";

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
                MessageBox.Show("Error occurs when getting account info. Please contact iTech support for assistance.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var account = dbContext.Accounts.FirstOrDefault(ac => ac.AccountId == accountId);
                    if (account == null)
                    {
                        MessageBox.Show("Account does not exists.");
                        return;
                    }

                    if (cmbAccountType.SelectedIndex >= 0)
                    {
                        account.AccountTypeId = cmbAccountType.SelectedIndex + 1; 
                    }
                    account.OrganizationName = txtOrganization.Text;
                    account.LastName = txtLastName.Text;
                    account.FirstName = txtFirstName.Text;
                    account.Email = txtEmail.Text;
                    
                    if (cmbLanguage.SelectedIndex >= 0)
                    {
                        account.LanguageId = cmbLanguage.SelectedIndex + 1;
                    }

                    account.Title = txtTitle.Text;
                    account.ChineseName = txtChineseName.Text;
                    account.SpouseFirstName = txtSpouse.Text;
                    if (maskedTxtPhone.MaskCompleted)
                    {
                        account.Phone = maskedTxtPhone.Text;
                    }

                    if (maskedTxtFax.MaskCompleted)
                    {
                        account.Fax = maskedTxtFax.Text;
                    }
                    txtEmail.Text = account.Email;

                    addressId = account.AddressId;
                    var accountAddress = account.Address;
                    if (accountAddress != null)
                    {
                        string strUnitNumber = txtUnit.Text;
                        int unitNumber = 0;
                        int.TryParse(strUnitNumber, out unitNumber);
                        if (unitNumber > 0)
                        {
                            accountAddress.UnitSuiteNumber = unitNumber;
                        }

                        accountAddress.StreetName = txtStreet.Text;
                        accountAddress.City = txtCity.Text;
                        accountAddress.Province = txtProvince.Text;
                        accountAddress.Country = txtCountry.Text;
                        accountAddress.PostalCode = txtPostalCode.Text;
                    }

                    dbContext.SaveChanges();
                }

                MessageBox.Show("Saved account successfully.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error occurs when saving account info. Please contact iTech support for assistance.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
