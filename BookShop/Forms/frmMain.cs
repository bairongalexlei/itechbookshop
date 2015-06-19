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
using BookShop.Common;

namespace BookShop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            BindAccounts();
            BindOfferings();
            BindSignature();
            BindYearEndCombo();
            cmbDepartments.DropDown += new System.EventHandler(cmbDepartments_DropDown);
        }

        private void BindYearEndCombo()
        {
            int currentYear = DateTime.Now.Year;
            List<int> dsYears = new List<int>();

            for (int year = 1998; year <= currentYear; year++)
            {
                dsYears.Add(year);
            }

            cmbYEndOfferingYear.DataSource = dsYears; 
            cmbYEndOfferingYear.SelectedIndex = dsYears.Count - 1;
        }

        private void BindSignature()
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var adminUser = dbContext.Users.FirstOrDefault(user =>
                        user.StatusId == (int)Common.CommonEnum.Status.Active &&
                        user.UserTypeId == (int)Common.CommonEnum.UserType.CFO);

                    if (adminUser != null)
                    {
                        txtSignatureFirstName.Text = adminUser.FirstName;
                        txtSignatureLastName.Text = adminUser.LastName;
                        
                        if (adminUser.SignatureImageBytes != null &&
                            adminUser.SignatureImageBytes.Count() > 0 &&
                            !string.IsNullOrEmpty(adminUser.SignatureImageExtension))
                        {
                            var imageFile = Common.Helper.ByteArrayToImage(adminUser.SignatureImageBytes);
                            imgPictureBox.Image = imageFile;
                        }
                    }
                }
            }
            catch {
                MessageBox.Show("Error on getting signature. Please contact iTech for assistance.");
            }
        }

        private void cmbDepartments_DropDown(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    cmbDepartments.Items.Clear();
                    cmbDepartments.DataSource = null;

                    var departments = dbContext.Departments.Where(d => d.StatusId == (int)Common.CommonEnum.Status.Active);

                    var departmentComboItems = departments.Select(department =>
                        new ComboboxItem { 
                            Text = department.DepartmentName,
                            Value = department.DepartmentId
                        }).ToArray();

                    cmbDepartments.Items.AddRange(departmentComboItems);
                }
            }
            catch
            {
                MessageBox.Show("Error on getting departments. Please contact iTech for assistance.");
            }
        }

        private void BindOfferings()
        {
            dataGridViewOfferings.Columns[0].DataPropertyName = "OfferingId";
            dataGridViewOfferings.Columns[1].DataPropertyName = "LastName";
            dataGridViewOfferings.Columns[2].DataPropertyName = "FirstName";
            dataGridViewOfferings.Columns[3].DataPropertyName = "Phone";
            dataGridViewOfferings.Columns[4].DataPropertyName = "Organization";
            dataGridViewOfferings.Columns[5].DataPropertyName = "Email";
            dataGridViewOfferings.Columns[6].DataPropertyName = "PaymentMethod";
            dataGridViewOfferings.Columns[7].DataPropertyName = "ReceiptType";
            dataGridViewOfferings.Columns[8].DataPropertyName = "AccountId";
            dataGridViewOfferings.Columns[9].DataPropertyName = "AccountType";

            dataGridViewOfferings.DataSource = null;
            dataGridViewOfferings.Rows.Clear();
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
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    var accountIdCell = senderGrid.Rows[e.RowIndex].Cells[0];
                    int accountId = accountIdCell.Value != null ? (int)accountIdCell.Value : 0;

                    var editAccountForm = new frmEditAccount(accountId);
                    editAccountForm.StartPosition = FormStartPosition.CenterParent;
                    editAccountForm.ShowDialog();
                }
                else if (e.ColumnIndex == 6)
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
                        //int accountTypeId = 0;
                        //string strAccountTypeId = Common.Helper.TrimString(cmbAccountType.Text);
                        //int.TryParse(strAccountTypeId, out accountTypeId);

                        //if (accountTypeId > 0)
                        //{
                        //    accounts = accounts.Where(ac => ac.AccountTypeId == accountTypeId);
                        //}

                        int accountTypeId = selectedAccountTypeId + 1;
                        accounts = accounts.Where(ac => ac.AccountTypeId == accountTypeId);
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
                        accounts = accounts.Where(ac => (ac.LanguageId ?? 0) == selectedLanguageId);
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

            //dataGridViewAccounts.DataSource = null;
            //dataGridViewAccounts.Rows.Clear();

            using (var dbContext = new BookShopEntities())
            {
                var accounts = dbContext.Accounts.Where(ac =>
                    ac.StatusId != (int)Common.CommonEnum.Status.Active);

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
                                }).ToList();

                dataGridViewAccounts.DataSource = accountBEs;
            }
        }

        private void SetupOfferingGridViewColumns()
        {
            dataGridViewOfferings.Columns[0].DataPropertyName = "AccountId";
            dataGridViewOfferings.Columns[1].DataPropertyName = "FirstName";
            dataGridViewOfferings.Columns[2].DataPropertyName = "LastName";
            dataGridViewOfferings.Columns[3].DataPropertyName = "ChineseName";
            dataGridViewOfferings.Columns[4].DataPropertyName = "Title";
            dataGridViewOfferings.Columns[5].DataPropertyName = "SpouseFirstName";
            dataGridViewOfferings.Columns[6].DataPropertyName = "PostalCode";
            dataGridViewOfferings.Columns[7].DataPropertyName = "OrganizationName";
            dataGridViewOfferings.Columns[8].DataPropertyName = "Phone";
            dataGridViewOfferings.Columns[9].DataPropertyName = "Fax";
            dataGridViewOfferings.Columns[10].DataPropertyName = "Email";
            dataGridViewOfferings.Columns[11].DataPropertyName = "AddressId";
        }

        private void btnOfferingSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSearchParamsEmpty = IsOfferingSearchParamsEmpty();
                if (isSearchParamsEmpty)
                {
                    MessageBox.Show("Empty search parameters!");
                    return;
                }

                using (var dbContext = new BookShopEntities())
                {
                    var offerings = dbContext.Offerings.Where(offr =>
                        offr.StatusId == (int)Common.CommonEnum.Status.Active);

                    string searchedLastName = Common.Helper.TrimString(txtLastName.Text);
                    if (!string.IsNullOrEmpty(searchedLastName))
                        offerings = offerings.Where(offr => offr.Account.LastName.Contains(searchedLastName));

                    string searchedFirstName = Common.Helper.TrimString(txtFirstName.Text);
                    if (!string.IsNullOrEmpty(searchedFirstName))
                        offerings = offerings.Where(offr => offr.Account.FirstName.Contains(searchedFirstName));

                    string searchedOrganization = Common.Helper.TrimString(txtOrganization.Text);
                    if (!string.IsNullOrEmpty(searchedOrganization))
                        offerings = offerings.Where(offr => offr.Account.OrganizationName.Contains(searchedOrganization));

                    if (maskedTxtOfferingPhone.MaskCompleted) {
                        string searchedPhone = maskedTxtOfferingPhone.Text;
                        offerings = offerings.Where(offr => offr.Account.Phone == searchedPhone);
                    }

                    string searchedEmail = Common.Helper.TrimString(txtOfferingEmail.Text);
                    if (!string.IsNullOrEmpty(searchedEmail))
                        offerings = offerings.Where(offr => offr.Account.Email == searchedEmail);

                    int unitNumber = 0;
                    int.TryParse(Common.Helper.TrimString(txtUnit.Text), out unitNumber);
                    if (unitNumber > 0)
                        offerings = offerings.Where(offr => offr.Account.Address != null &&
                                                            offr.Account.Address.UnitSuiteNumber == unitNumber);

                    string searchedStreet = Common.Helper.TrimString(txtStreet.Text);
                    if (!string.IsNullOrEmpty(searchedStreet))
                        offerings = offerings.Where(offr => offr.Account.Address != null &&
                                                            offr.Account.Address.StreetName == searchedStreet);

                    string searchedCity = Common.Helper.TrimString(txtCity.Text);
                    if (!string.IsNullOrEmpty(searchedCity))
                        offerings = offerings.Where(offr => offr.Account.Address != null &&
                                                            offr.Account.Address.City == searchedCity);

                    string searchedProvince = Common.Helper.TrimString(txtProvince.Text);
                    if (!string.IsNullOrEmpty(searchedProvince))
                        offerings = offerings.Where(offr => offr.Account.Address != null &&
                                                            offr.Account.Address.Province == searchedProvince);

                    string searchedPostalCode = Common.Helper.TrimString(txtPostalCode.Text);
                    if (!string.IsNullOrEmpty(searchedPostalCode))
                        offerings = offerings.Where(offr => offr.Account.Address != null &&
                                                            offr.Account.Address.PostalCode == searchedPostalCode);

                    int selectedMethod = cmbOfferingMethod.SelectedIndex;
                    if (selectedMethod > -1)
                        offerings = offerings.Where(offr => offr.MethodId == (selectedMethod + 1));

                    int selectedReceiptType = cmbOfferingReceiptType.SelectedIndex;
                    if (selectedReceiptType > -1)
                        offerings = offerings.Where(offr => offr.ReceiptTypeId == (selectedReceiptType + 1));

                    if (maskedTxtOfferingDateReceiptIssued.MaskCompleted)
                    {
                        try
                        {
                            var strSearchedDate = maskedTxtOfferingDateReceiptIssued.Text;
                            DateTime searchedDate;
                            DateTime.TryParse(strSearchedDate, out searchedDate);

                            if (searchedDate != null && searchedDate > DateTime.MinValue)
                                offerings = offerings.Where(offr =>
                                    offr.ReceiptIssuedDate <= searchedDate);
                        }
                        catch { } 
                    }

                    string searchedAccountId = Common.Helper.TrimString(txtOfferingAccountId.Text);
                    if (!string.IsNullOrEmpty(searchedAccountId))
                    {
                        int accountId = 0;
                        int.TryParse(searchedAccountId, out accountId);

                        if (accountId > 0)
                            offerings = offerings.Where(offr => offr.AccountId == accountId);

                    }

                    int selectedAccountType = cmbAccountType.SelectedIndex;
                    if (selectedAccountType > -1)
                        offerings = offerings.Where(offr => offr.Account.AccountTypeId == (selectedAccountType + 1));

                    var offeringBEs = offerings.Select(offr =>
                                new
                                {
                                    OfferingId = offr.OfferingId,
                                    LastName = offr.Account.LastName,
                                    FirstName = offr.Account.FirstName,
                                    Phone = offr.Account.Phone,
                                    Organization = offr.Account.OrganizationName,
                                    Email = offr.Account.Email,
                                    PaymentMethod = ((Common.CommonEnum.PaymentMethod)offr.MethodId).ToString(),
                                    ReceiptType = ((Common.CommonEnum.ReceiptType)offr.ReceiptTypeId).ToString(),
                                    AccountId = offr.AccountId,
                                    AccountType = ((Common.CommonEnum.AccountType)offr.Account.AccountTypeId).ToString(),
                                }).ToList();

                    if (dataGridViewOfferings.DataSource != null)
                    {
                        dataGridViewOfferings.Columns[0].DataPropertyName = "OfferingId";
                        dataGridViewOfferings.Columns[1].DataPropertyName = "LastName";
                        dataGridViewOfferings.Columns[2].DataPropertyName = "FirstName";
                        dataGridViewOfferings.Columns[3].DataPropertyName = "Phone";
                        dataGridViewOfferings.Columns[4].DataPropertyName = "Organization";
                        dataGridViewOfferings.Columns[5].DataPropertyName = "Email";
                        dataGridViewOfferings.Columns[6].DataPropertyName = "PaymentMethod";
                        dataGridViewOfferings.Columns[7].DataPropertyName = "ReceiptType";
                        dataGridViewOfferings.Columns[8].DataPropertyName = "AccountId";
                        dataGridViewOfferings.Columns[9].DataPropertyName = "AccountType";
                    }

                    dataGridViewOfferings.DataSource = offeringBEs;
                }
            }
            catch
            {
                MessageBox.Show("Errors on quering offerings. Please contact iTech support for assistance.");
            }
        }

        private bool IsOfferingSearchParamsEmpty()
        {
            string searchedLastName = Common.Helper.TrimString(txtOfferingLastName.Text);
            string searchedFirstName = Common.Helper.TrimString(txtOfferingFirstName.Text);
            string searchedOrganization = Common.Helper.TrimString(txtOfferingOrganization.Text);
            bool isSearchedPhoneCompleted = maskedTxtOfferingPhone.MaskCompleted;
            string searchedEmail = Common.Helper.TrimString(txtOfferingEmail.Text);

            int unitNumber = 0;
            string strUnitNumber = Common.Helper.TrimString(txtOfferingUnit.Text);
            int.TryParse(Common.Helper.TrimString(strUnitNumber), out unitNumber);

            string searchedStreet = Common.Helper.TrimString(txtOfferingStreet.Text);
            string searchedCity = Common.Helper.TrimString(txtOfferingCity.Text);
            string searchedProvince = Common.Helper.TrimString(txtOfferingProvince.Text);
            string searchedCountry = Common.Helper.TrimString(txtOfferingCountry.Text);
            string searchedPostalCode = Common.Helper.TrimString(txtOfferingPostalCode.Text);

            int searchedMethodId = cmbOfferingMethod.SelectedIndex;
            int searchedReceiptType = cmbOfferingReceiptType.SelectedIndex;

            bool isSearchedReceiptIssuedDateCompleted = maskedTxtOfferingDateReceiptIssued.MaskCompleted;

            int accountId = 0;
            string strAccountId = Common.Helper.TrimString(txtOfferingAccountId.Text);
            int.TryParse(Common.Helper.TrimString(strAccountId), out accountId);

            int searchedAccountTypeId = cmbOfferingAccountType.SelectedIndex;

            bool isSearchParamsEmpty = (string.IsNullOrEmpty(searchedLastName) &&
                                        string.IsNullOrEmpty(searchedFirstName) &&
                                        string.IsNullOrEmpty(searchedOrganization) &&
                                        !isSearchedPhoneCompleted &&
                                        string.IsNullOrEmpty(searchedEmail) &&
                                        unitNumber <= 0 &&
                                        string.IsNullOrEmpty(searchedStreet) &&
                                        string.IsNullOrEmpty(searchedCity) &&
                                        string.IsNullOrEmpty(searchedProvince) &&
                                        string.IsNullOrEmpty(searchedCountry) &&
                                        string.IsNullOrEmpty(searchedPostalCode) &&
                                        searchedMethodId < 0 &&
                                        searchedReceiptType < 0 &&
                                        !isSearchedReceiptIssuedDateCompleted &&
                                        accountId <= 0 &&
                                        searchedAccountTypeId < 0);

            return isSearchParamsEmpty;
        }

        private void btnOfferingClear_Click(object sender, EventArgs e)
        {
            txtOfferingLastName.Clear();
            txtOfferingFirstName.Clear();
            txtOfferingOrganization.Clear();
            maskedTxtOfferingPhone.Clear();
            txtOfferingEmail.Clear();

            txtOfferingUnit.Clear();

            txtOfferingStreet.Clear();
            txtOfferingCity.Clear();
            txtOfferingProvince.Clear();
            txtOfferingCountry.Clear();
            txtOfferingPostalCode.Clear();

            cmbOfferingMethod.SelectedIndex = -1;
            cmbOfferingReceiptType.SelectedIndex = -1;

            maskedTxtOfferingDateReceiptIssued.Clear();

            txtOfferingAccountId.Clear();

            cmbOfferingAccountType.SelectedIndex = -1;
        }

        private void btnNewOffering_Click(object sender, EventArgs e)
        {
            var offeringForm = new frmOffering();
            offeringForm.StartPosition = FormStartPosition.CenterParent;
            offeringForm.ShowDialog();
        }

        private void dataGridViewOfferings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var offeringIdCell = senderGrid.Rows[e.RowIndex].Cells[0];
                int offeringId = offeringIdCell.Value != null ? (int)offeringIdCell.Value : 0;

                var accountIdCell = senderGrid.Rows[e.RowIndex].Cells[8];
                int accountId = accountIdCell.Value != null ? (int)accountIdCell.Value : 0;

                if (offeringId > 0 && accountId > 0)
                {
                    var offeringForm = new frmOffering(accountId, offeringId);
                    offeringForm.StartPosition = FormStartPosition.CenterParent;
                    offeringForm.ShowDialog();


                }
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentToAdd = Common.Helper.TrimString(txtDepartmentName.Text);
                if (string.IsNullOrEmpty(departmentToAdd))
                {
                    MessageBox.Show("Invalid department name!");
                    return;
                }

                using (var dbContext = new BookShopEntities())
                {
                    var foundDepartment = dbContext.Departments.FirstOrDefault(d =>
                        d.DepartmentName.ToLower() == departmentToAdd.ToLower());

                    if (foundDepartment != null)
                    {
                        MessageBox.Show("Department already exists!");
                        return;
                    }

                    var newDepartment = new Department();
                    newDepartment.DepartmentName = departmentToAdd;
                    newDepartment.StatusId = (int)Common.CommonEnum.Status.Active;
                    
                    dbContext.Departments.Add(newDepartment);
                    dbContext.SaveChanges();
                }

                MessageBox.Show("Department was added successfully");
            }
            catch
            {
                MessageBox.Show("Please contact iTech support for assitance");
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                string projectToAdd = Common.Helper.TrimString(txtProjectName.Text);
                if (string.IsNullOrEmpty(projectToAdd))
                {
                    MessageBox.Show("Invalid project name!");
                    return;
                }

                int selectedDepartment = cmbDepartments.SelectedIndex;
                if (selectedDepartment < 0)
                {
                    MessageBox.Show("Department should not be empty!");
                    return;
                }

                using (var dbContext = new BookShopEntities())
                {
                    var foundProject = dbContext.Projects.FirstOrDefault(proj =>
                        proj.Description.ToLower() == projectToAdd.ToLower());

                    if (foundProject != null)
                    {
                        MessageBox.Show("Project already exists!");
                        return;
                    }

                    var newProject = new Project();
                    newProject.Description = projectToAdd;
                    newProject.StatusId = (int)Common.CommonEnum.Status.Active;
                    newProject.DepartmentId = ((ComboboxItem)cmbDepartments.SelectedItem).Value;

                    dbContext.Projects.Add(newProject);
                    dbContext.SaveChanges();
                }

                MessageBox.Show("Project was added successfully");
            }
            catch
            {
                MessageBox.Show("Please contact iTech support for assitance");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFd = new OpenFileDialog();
            OpenFd.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";

            DialogResult dr = OpenFd.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                imgPictureBox.Image = Image.FromFile(OpenFd.FileName);
                txtImagePath.Text = OpenFd.FileName;
            }
        }

        private void btnUploadSignature_Click(object sender, EventArgs e)
        {
            string signatureFirstName = Common.Helper.TrimString(txtSignatureFirstName.Text);
            string signatureLastName = Common.Helper.TrimString(txtSignatureLastName.Text);
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrEmpty(signatureFirstName) ||
                string.IsNullOrEmpty(signatureLastName) ||
                string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("First name, last name and image path can not be empty.");
                return;
            }

            try
            {
                string signatureImageName;
                string signatureImageExtension;

                var imagePathParts = imagePath.Split('\\');
                var imageNameWithExtension = imagePathParts.LastOrDefault();
                signatureImageName = imageNameWithExtension.Split('.')[0];
                signatureImageExtension = imageNameWithExtension.Split('.')[1];

                var imageFile = Image.FromFile(imagePath);
                var imageFileBytes = Common.Helper.ImageToByteArray(imageFile, signatureImageExtension);

                using (var dbContext = new BookShopEntities())
                {
                    var adminUser = dbContext.Users
                                    .OrderBy(u => u.UserId)
                                    .FirstOrDefault(user => 
                                        user.StatusId == (int)Common.CommonEnum.Status.Active &&
                                        user.UserTypeId == (int)Common.CommonEnum.UserType.CFO);

                    if (adminUser == null) { 
                        adminUser = new User();
                        adminUser.UserTypeId = (int)Common.CommonEnum.UserType.CFO;
                        adminUser.StatusId = (int)Common.CommonEnum.Status.Active;
                        adminUser.FirstName = signatureFirstName;
                        adminUser.LastName = signatureLastName;
                        adminUser.TakenOnDateTime = DateTime.Now;
                        adminUser.SignatureImageName = signatureImageName;
                        adminUser.SignatureImageExtension = signatureImageExtension;
                        adminUser.SignatureImageBytes = imageFileBytes;
                        
                        dbContext.Users.Add(adminUser);
                    }
                    else {
                        adminUser.FirstName = signatureFirstName;
                        adminUser.LastName = signatureLastName;
                        adminUser.TakenOnDateTime = DateTime.Now;
                        adminUser.SignatureImageName = signatureImageName;
                        adminUser.SignatureImageExtension = signatureImageExtension;
                        adminUser.SignatureImageBytes = imageFileBytes;
                    }

                    dbContext.SaveChanges();
                }

                MessageBox.Show("Uploaded image successfully");
            }
            catch
            {
                MessageBox.Show("Uploaded image unsuccessfully. Please contact iTech support for assistance.");
            }
        }

        private void btnBundleReceipt_Click(object sender, EventArgs e)
        {
            if (!maskedTxtReceivedDateGreaterThan.MaskCompleted &&
                !maskedTxtReceivedDateLessThan.MaskCompleted)
            {
                MessageBox.Show("Date is not input yet!");
                return;
            }

            if (cmbReceiptType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select receipt type first!");
                return;
            }

            string strDateLessThan = string.Empty;
            string strDateGreaterThan = string.Empty;

            if (maskedTxtReceivedDateGreaterThan.MaskCompleted)
                strDateGreaterThan = maskedTxtReceivedDateGreaterThan.Text;

            if (maskedTxtReceivedDateLessThan.MaskCompleted)
                strDateLessThan = maskedTxtReceivedDateLessThan.Text;

            //var receiptForm = new frmReceipt(strDateGreaterThan, strDateLessThan);
            //receiptForm.StartPosition = FormStartPosition.CenterParent;
            //receiptForm.ShowDialog();

            if (cmbReceiptType.SelectedIndex == 0)
            {
                var receiptForm = new frmReceipt(strDateGreaterThan, strDateLessThan);
                //var receiptForm = new frmReceipt(strDateGreaterThan, strDateLessThan, false);
                receiptForm.StartPosition = FormStartPosition.CenterParent;
                receiptForm.ShowDialog(); 
            }
            else
            {
                var receiptForm = new frmNontaxableReceipt(strDateGreaterThan, strDateLessThan);
                receiptForm.StartPosition = FormStartPosition.CenterParent;
                receiptForm.ShowDialog(); 
            }
        }

        private void btnBundleSummary_Click(object sender, EventArgs e)
        {
            if (!maskedTxtReceivedDateGreaterThan.MaskCompleted &&
                !maskedTxtReceivedDateLessThan.MaskCompleted)
            {
                MessageBox.Show("Date is not input yet!");
                return;
            }

            if (cmbSummaryType.SelectedIndex < 0)
            {
                MessageBox.Show("Summary type is not selected yet.");
                return;
            }

            string strDateGreaterThan = maskedTxtReceivedDateGreaterThan.Text;
            string strDateLessThan = maskedTxtReceivedDateLessThan.Text;
            DateTime dateGreaterThan;
            DateTime dateLessThan;
            var summarySearchParms = new SummarySearchParams();

            if (!string.IsNullOrEmpty(strDateGreaterThan))
            {
                DateTime.TryParse(strDateGreaterThan, out dateGreaterThan);
                if (dateGreaterThan != null && dateGreaterThan > DateTime.MinValue)
                    summarySearchParms.FromDate = dateGreaterThan;
            }

            if (!string.IsNullOrEmpty(strDateLessThan))
            {
                DateTime.TryParse(strDateLessThan, out dateLessThan);
                if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                    summarySearchParms.ToDate = dateLessThan;
            }

            if (cmbSummaryType.SelectedIndex == 0)
            {
                var receiptForm = new frmReceiptSummary(summarySearchParms);
                receiptForm.StartPosition = FormStartPosition.CenterParent;
                receiptForm.ShowDialog();
            }
            else if (cmbSummaryType.SelectedIndex == 1)
            {
                var paymentForm = new frmPaymentSummary(summarySearchParms);
                paymentForm.StartPosition = FormStartPosition.CenterParent;
                paymentForm.ShowDialog();
            }
            else if (cmbSummaryType.SelectedIndex == 2)
            {
                var departmentForm = new frmDepartmentProjectSummary(summarySearchParms);
                departmentForm.StartPosition = FormStartPosition.CenterParent;
                departmentForm.ShowDialog();
            }
        }

        private void btnByReport_Click(object sender, EventArgs e)
        {
            if (!maskedTxtReceivedDateGreaterThan.MaskCompleted &&
                !maskedTxtReceivedDateLessThan.MaskCompleted)
            {
                MessageBox.Show("Date is not input yet!");
                return;
            }

            string strDateLessThan = string.Empty;
            string strDateGreaterThan = string.Empty;

            if (maskedTxtReceivedDateGreaterThan.MaskCompleted)
                strDateGreaterThan = maskedTxtReceivedDateGreaterThan.Text;

            if (maskedTxtReceivedDateLessThan.MaskCompleted)
                strDateLessThan = maskedTxtReceivedDateLessThan.Text;

            int selectedByType = cmbByCategory.SelectedIndex;
            if (selectedByType < 0)
            {
                MessageBox.Show("Please select a by type first!");
                return;
            }

            if (cmbByCategory.SelectedIndex == 0)
            {
                var byProvinceForm = new frmByProvince(strDateGreaterThan, strDateLessThan);
                byProvinceForm.StartPosition = FormStartPosition.CenterParent;
                byProvinceForm.ShowDialog();
            }
            else if (cmbByCategory.SelectedIndex == 1)
            {
                var byIndividualForm = new frmByIndividual(strDateGreaterThan, strDateLessThan);
                byIndividualForm.StartPosition = FormStartPosition.CenterParent;
                byIndividualForm.ShowDialog();
            }
            else if (cmbByCategory.SelectedIndex == 2)
            {
                var byIndividualForm = new frmByOrganization(strDateGreaterThan, strDateLessThan);
                byIndividualForm.StartPosition = FormStartPosition.CenterParent;
                byIndividualForm.ShowDialog();
            }
        }

        private void btnYearEndReceipt_Click(object sender, EventArgs e)
        {
            string strYearEndAccountId = txtYEndAccountId.Text;
            int yearEndAccountId = 0;

            int.TryParse(strYearEndAccountId, out yearEndAccountId);
            //if (yearEndAccountId <= 0)
            //{
            //    MessageBox.Show("Invalid input for account id. Please input a proper account id.");
            //    return;
            //}

            int selectedReceiptType = cmbYEndReceiptType.SelectedIndex;
            if (selectedReceiptType <= -1)
            {
                MessageBox.Show("Please select a receipt type first.");
                return;
            }

            int selectedYear = cmbYEndOfferingYear.SelectedIndex;
            if (selectedYear <= -1)
            {
                MessageBox.Show("Please select a year first.");
                return;
            }

            int year = 0;
            int.TryParse(cmbYEndOfferingYear.Text, out year);

            if (selectedReceiptType == 0)
            {
                var taxableReceiptForm = new frmReceipt(yearEndAccountId, year);
                taxableReceiptForm.StartPosition = FormStartPosition.CenterParent;
                taxableReceiptForm.ShowDialog();
            }
            else
            {
                var nonTaxableReceiptForm = new frmNontaxableReceipt(yearEndAccountId, year);
                nonTaxableReceiptForm.StartPosition = FormStartPosition.CenterParent;
                nonTaxableReceiptForm.ShowDialog();
            }
        }
    }
}
