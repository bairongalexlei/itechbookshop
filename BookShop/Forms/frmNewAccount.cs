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
    public partial class frmNewAccount : Form
    {
        public frmNewAccount()
        {
            InitializeComponent();
            BindAccountId();
            txtCountry.Text = "Canada";
            txtProvince.Text = "Ontario";
        }

        private void BindAccountId()
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var lastAccount = dbContext.Accounts.OrderByDescending(ac => ac.AccountId).FirstOrDefault();
                    if (lastAccount == null)
                    {
                        txtAccountId.Text = "1";
                    }
                    else
                    {
                        int lastAccountId = lastAccount.AccountId;
                        txtAccountId.Text = (++lastAccountId).ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error occurs when getting new account id. Please contact iTech support for assistance.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int newAddressId = 0;
            bool isMissingCritalFelds = IsMissingCritalFelds();

            if (isMissingCritalFelds)
            {
                //MessageBox.Show("First name, last name and account type can not be empty");
                MessageBox.Show("Missing fields.");
                return;
            }

            if (!IsEmailValid(txtEmail.Text))
            {
                MessageBox.Show("Invalid email address");
                return;
            }

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    bool isAddressFieldsEmpty = IsAddressFielsEmpty();
                    if (!isAddressFieldsEmpty)
                    {
                        var newAddress = new Address
                        {
                            StreetName = Common.Helper.TrimString(txtStreet.Text),
                            City = Common.Helper.TrimString(txtCity.Text),
                            Province = Common.Helper.TrimString(txtProvince.Text),
                            Country = Common.Helper.TrimString(txtCountry.Text),
                            PostalCode = Common.Helper.TrimString(txtPostalCode.Text),
                        };

                        int unitNumber = 0;
                        int.TryParse(Common.Helper.TrimString(txtUnit.Text), out unitNumber);
                        if (unitNumber > 0) newAddress.UnitSuiteNumber = unitNumber;

                        dbContext.Addresses.Add(newAddress);
                        dbContext.SaveChanges();
                        newAddressId = newAddress.AddressId;
                    }

                    var newAccount = new Account
                    {
                        FirstName = Common.Helper.TrimString(txtFirstName.Text),
                        LastName = Common.Helper.TrimString(txtLastName.Text),
                        StatusId = (int)Common.CommonEnum.Status.Active,
                        OrganizationName = Common.Helper.TrimString(txtOrganization.Text),
                        Title = Common.Helper.TrimString(txtTitle.Text),
                        ChineseName = Common.Helper.TrimString(txtChineseName.Text),
                        SpouseFirstName = Common.Helper.TrimString(txtSpouse.Text),
                        Phone = Common.Helper.TrimString(maskedTxtPhone.Text),
                        Fax = Common.Helper.TrimString(maskedTxtFax.Text),
                        Email = Common.Helper.TrimString(txtEmail.Text),
                    };

                    try
                    {
                        int languageId = (int)cmbLanguage.SelectedIndex;
                        if (languageId >= 0) newAccount.LanguageId = (languageId + 1);
                    }
                    catch { }

                    try
                    {
                        int accountTypeId = (int)cmbAccountType.SelectedIndex;
                        if (accountTypeId >= 0) newAccount.AccountTypeId = (accountTypeId + 1);
                    }
                    catch { }

                    if (newAddressId > 0) newAccount.AddressId = newAddressId;

                    dbContext.Accounts.Add(newAccount);
                    dbContext.SaveChanges();
                }

                MessageBox.Show("Successfully saved new account");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error occurs when saving new account. Please contact iTech support for assistance.");
            }
        }

        private bool IsMissingCritalFelds()
        {
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            int accountTypeId = 0;

            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName.Trim();
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName.Trim();
            }

            try
            {
                accountTypeId = (int)cmbAccountType.SelectedIndex + 1;
            }
            catch { }

            //bool isMissingCritalFields = (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || accountTypeId <= 0);
            bool isMissingCritalFields = false;

            if (accountTypeId > 0)
            {
                if (accountTypeId == 2 || accountTypeId == 5)
                {
                    isMissingCritalFields = (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
                }
                else
                {
                    isMissingCritalFields = string.IsNullOrEmpty(txtOrganization.Text);
                } 
            }
            else
            {
                isMissingCritalFields = true;
            }

            return isMissingCritalFields;
        }

        private bool IsAddressFielsEmpty()
        {
            bool isUnitEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtUnit.Text));
            bool isStreetEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtStreet.Text));
            bool isCityEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtCity.Text));
            bool isProvinceEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtProvince.Text));
            bool isCountryEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtCountry.Text));
            bool isPostalCodeEmpty = string.IsNullOrEmpty(Common.Helper.TrimString(txtPostalCode.Text));

            return (isUnitEmpty && isStreetEmpty && isCityEmpty && isProvinceEmpty && isCountryEmpty && isPostalCodeEmpty);
        }

        private bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            try
            {
                var mail = new System.Net.Mail.MailAddress(email.Trim());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountType.SelectedIndex == 1 || cmbAccountType.SelectedIndex == 4)
            {
                txtOrganization.Enabled = false;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
            }
            else
            {
                txtOrganization.Enabled = true;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
            }
        }
    }
}
