using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShop.EFData;
using BookShop.Forms;

namespace BookShop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            BindAccounts();
        }

        private void BindAccounts()
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var accounts = dbContext.Accounts.Where(acct => acct.StatusId == 1)
                            .Select(ac =>
                                new
                                {
                                    AccountId = ac.AccountId,
                                    FirstName = ac.FirstName,
                                    LastName = ac.LastName,
                                    ChineseName = ac.ChineseName,
                                    Title = ac.Title,
                                    SpouseFirstName = ac.SpouseFirstName,
                                    PostalCode = (ac.Address != null ? ac.Address.PostalCode : ""),
                                    OrganizationName = ac.OrganizationName,
                                    Phone = ac.Phone,
                                    Fax = ac.Fax,
                                    Email = ac.Email,
                                    AddressId = ac.AddressId,
                                    //StatusId = ac.StatusId,
                                    //LanguageId = ac.LanguageId,
                                }).ToList();

                    dataGridViewAccounts.Columns[0].DataPropertyName = "AccountId";
                    dataGridViewAccounts.Columns[1].DataPropertyName = "FirstName";
                    dataGridViewAccounts.Columns[2].DataPropertyName = "LastName";
                    dataGridViewAccounts.Columns[3].DataPropertyName = "ChineseName";
                    dataGridViewAccounts.Columns[4].DataPropertyName = "Title";
                    dataGridViewAccounts.Columns[5].DataPropertyName = "SpouseFirstName";
                    dataGridViewAccounts.Columns[6].DataPropertyName = "PostalCode";
                    dataGridViewAccounts.Columns[7].DataPropertyName = "OrganizationName";
                    dataGridViewAccounts.Columns[8].DataPropertyName = "Phone";
                    dataGridViewAccounts.Columns[9].DataPropertyName = "Fax";
                    dataGridViewAccounts.Columns[10].DataPropertyName = "Email";
                    dataGridViewAccounts.Columns[11].DataPropertyName = "AddressId";

                    //dataGridViewAccounts.DataSource = accounts;

                    //var accountIds = accounts.Select(ac => ac.AccountId.ToString()).ToArray();
                    var accountIds = accounts.Select(ac => ac.AccountId.ToString()).ToList();
                    accountIds.Insert(0, "");
                    cmbAccountId.DataSource = accountIds;

                    dataGridViewAccounts.DataSource = null;
                    dataGridViewAccounts.Rows.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs when binding accounts. Please contact iTech support for assistance.");
            }
        }

        //private void dataGridViewAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0 && e.ColumnIndex == 12)
        //    {
        //        //TODO - Button Clicked - Execute Code Here
        //        //MessageBox.Show("hello");
        //        var cellButton = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        //var addressIdCell = senderGrid.Rows[e.RowIndex].Cells[22];
        //    }
        //}

        private void dataGridViewAccounts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                var accountIdCell = senderGrid.Rows[e.RowIndex].Cells[0];
                int accountId = accountIdCell.Value != null ? (int)accountIdCell.Value : 0;

                var addressIdCell = senderGrid.Rows[e.RowIndex].Cells[11];
                int addressId = addressIdCell.Value != null ? (int)addressIdCell.Value : 0;

                var addressForm = new frmAddress(addressId);
                addressForm.StartPosition = FormStartPosition.CenterParent;
                addressForm.ShowDialog();

                if (addressForm.Addressid > 0)
                {
                    try
                    {
                        using (var dbContext = new BookShopEntities())
                        {
                            var currentEditAccount =
                                dbContext.Accounts.FirstOrDefault(ac => ac.AccountId == accountId);

                            if (currentEditAccount != null && currentEditAccount.AddressId <= 0)
                            {
                                currentEditAccount.AddressId = addressForm.Addressid;
                                dbContext.SaveChanges();
                                MessageBox.Show("Address was added to account successfully");
                            }
                        }
                    }
                    catch { } 
                }
            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            var accountForm = new frmNewAccount();
            accountForm.StartPosition = FormStartPosition.CenterParent;
            accountForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSearchParamsEmpty = IsSearchParamsEmpty();
                if (isSearchParamsEmpty)
                {
                    MessageBox.Show("Empty search parameters!");
                    return;
                }

                using (var dbContext = new BookShopEntities())
                {
                    var accounts = dbContext.Accounts.Where(ac => 
                        ac.StatusId == (int)Common.CommonEnum.Status.Active);

                    int selectedAccountId = cmbAccountId.SelectedIndex;
                    if (selectedAccountId >= 0)
                    {
                        int searchAccountId = 0;
                        string strSearchAccountId = Common.Helper.TrimString(cmbAccountId.Text);
                        int.TryParse(strSearchAccountId, out searchAccountId);

                        if (searchAccountId > 0) 
                        { 
                            accounts = accounts.Where(ac => ac.AccountId == searchAccountId);
                        }
                    }

                    int selectedAccountTypeId = cmbAccountType.SelectedIndex;
                    if (selectedAccountTypeId >= 0)
                    {
                        int accountTypeId = 0;
                        string strAccountTypeId = Common.Helper.TrimString(cmbAccountType.Text);
                        int.TryParse(strAccountTypeId, out accountTypeId);

                        if (accountTypeId > 0)
                        {
                            accounts = accounts.Where(ac => ac.AccountTypeId == accountTypeId);
                        }
                    }

                    string organization = Common.Helper.TrimString(txtOrganization.Text);
                    if (!string.IsNullOrEmpty(organization))
                    {
                        accounts = accounts.Where(ac => ac.OrganizationName.ToLower().Contains(organization.ToLower()));
                    }

                    string selectedLastName = Common.Helper.TrimString(txtLastName.Text);
                    if (!string.IsNullOrEmpty(selectedLastName))
                    {
                        accounts = accounts.Where(ac => ac.LastName.ToLower().Contains(selectedLastName.ToLower()));
                    }

                    string selectedFirstName = Common.Helper.TrimString(txtFirstName.Text);
                    if (!string.IsNullOrEmpty(selectedFirstName))
                    {
                        accounts = accounts.Where(ac => ac.FirstName.ToLower().Contains(selectedFirstName.ToLower()));
                    }

                    int selectedLanguage = cmbLanguage.SelectedIndex;
                    if (selectedLanguage >= 0)
                    {
                        int selectedLanguageId = selectedLanguage + 1;
                        accounts = accounts.Where(ac => ac.LanguageId == selectedLanguageId);
                    }

                    int unitNumber = 0;
                    string strUnitNumber = txtUnit.Text;
                    int.TryParse(Common.Helper.TrimString(strUnitNumber), out unitNumber);
                    if (unitNumber > 0)
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.UnitSuiteNumber == unitNumber);
                    }

                    string street = Common.Helper.TrimString(txtStreet.Text);
                    if (!string.IsNullOrEmpty(street))
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.StreetName.ToLower().Contains(street.ToLower()));
                    }

                    string city = Common.Helper.TrimString(txtCity.Text);
                    if (!string.IsNullOrEmpty(city))
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.City.ToLower().Contains(city.ToLower()));
                    }

                    string province = Common.Helper.TrimString(txtProvince.Text);
                    if (!string.IsNullOrEmpty(province))
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.Province.ToLower().Contains(province.ToLower()));
                    }

                    string country = Common.Helper.TrimString(txtCountry.Text);
                    if (!string.IsNullOrEmpty(country))
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.Country.ToLower().Contains(country.ToLower()));
                    }

                    string postalCode = Common.Helper.TrimString(txtPostalCode.Text);
                    if (!string.IsNullOrEmpty(postalCode))
                    {
                        accounts = accounts.Where(ac => ac.Address != null &&
                                                        ac.Address.PostalCode.ToLower().Contains(postalCode.ToLower()));
                    }

                    var accountBEs = accounts.Select(ac =>
                                new
                                {
                                    AccountId = ac.AccountId,
                                    FirstName = ac.FirstName,
                                    LastName = ac.LastName,
                                    ChineseName = ac.ChineseName,
                                    Title = ac.Title,
                                    SpouseFirstName = ac.SpouseFirstName,
                                    PostalCode = (ac.Address != null ? ac.Address.PostalCode : ""),
                                    OrganizationName = ac.OrganizationName,
                                    Phone = ac.Phone,
                                    Fax = ac.Fax,
                                    Email = ac.Email,
                                    AddressId = ac.AddressId,
                                    //StatusId = ac.StatusId,
                                    //LanguageId = ac.LanguageId,
                                }).ToList();

                    if (dataGridViewAccounts.DataSource != null)
                    {
                        dataGridViewAccounts.Columns[0].DataPropertyName = "AccountId";
                        dataGridViewAccounts.Columns[1].DataPropertyName = "FirstName";
                        dataGridViewAccounts.Columns[2].DataPropertyName = "LastName";
                        dataGridViewAccounts.Columns[3].DataPropertyName = "ChineseName";
                        dataGridViewAccounts.Columns[4].DataPropertyName = "Title";
                        dataGridViewAccounts.Columns[5].DataPropertyName = "SpouseFirstName";
                        dataGridViewAccounts.Columns[6].DataPropertyName = "PostalCode";
                        dataGridViewAccounts.Columns[7].DataPropertyName = "OrganizationName";
                        dataGridViewAccounts.Columns[8].DataPropertyName = "Phone";
                        dataGridViewAccounts.Columns[9].DataPropertyName = "Fax";
                        dataGridViewAccounts.Columns[10].DataPropertyName = "Email";
                        dataGridViewAccounts.Columns[11].DataPropertyName = "AddressId"; 
                    }

                    dataGridViewAccounts.DataSource = accountBEs;
                }
            }
            catch {
                MessageBox.Show("Error on searching account. Please contact iTech support for assistance.");
            }
        }

        private bool IsSearchParamsEmpty()
        {
            int selectedAccountId = cmbAccountId.SelectedIndex;
            int selectedAccountTypeId = cmbAccountType.SelectedIndex;
            string organization = Common.Helper.TrimString(txtOrganization.Text);
            string selectedLastName = Common.Helper.TrimString(txtLastName.Text);
            string selectedFirstName = Common.Helper.TrimString(txtFirstName.Text);
            int selectedLanguage = cmbLanguage.SelectedIndex;
            int unitNumber = 0;
            string strUnitNumber = txtUnit.Text;
            int.TryParse(Common.Helper.TrimString(strUnitNumber), out unitNumber);
            string street = Common.Helper.TrimString(txtStreet.Text);
            string city = Common.Helper.TrimString(txtCity.Text);
            string province = Common.Helper.TrimString(txtProvince.Text);
            string country = Common.Helper.TrimString(txtCountry.Text);
            string postalCode = Common.Helper.TrimString(txtPostalCode.Text);

            bool isParamsEmpty = (selectedAccountId <= 0 &&
                                    selectedAccountTypeId < 0 &&
                                    string.IsNullOrEmpty(organization) &&
                                    string.IsNullOrEmpty(selectedLastName) &&
                                    string.IsNullOrEmpty(selectedFirstName) &&
                                    selectedLanguage < 0 &&
                                    unitNumber <= 0 &&
                                    string.IsNullOrEmpty(street) &&
                                    string.IsNullOrEmpty(city) &&
                                    string.IsNullOrEmpty(province) &&
                                    string.IsNullOrEmpty(country) &&
                                    string.IsNullOrEmpty(postalCode));

            return isParamsEmpty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbAccountId.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtOrganization.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            cmbLanguage.SelectedIndex = -1;
            txtUnit.Clear();
            txtStreet.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            txtCountry.Clear();
            txtPostalCode.Clear();

            dataGridViewAccounts.DataSource = null;
            dataGridViewAccounts.Rows.Clear();
        }
    }
}
