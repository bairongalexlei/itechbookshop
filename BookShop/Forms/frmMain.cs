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
                    //var accounts = dbContext.Accounts.Where(acct => acct.StatusId == 1)
                    //        .Select(ac =>
                    //            new {
                    //                AccountId = ac.AccountId,
                    //                FirstName = ac.FirstName,
                    //                LastName = ac.LastName,
                    //                ChineseName = ac.ChineseName,
                    //                Title = ac.Title,
                    //                SpouseFirstName = ac.SpouseFirstName,
                    //                OrganizationName = ac.OrganizationName,
                    //                AddressId = ac.AddressId,
                    //                Phone = ac.Phone,
                    //                Fax = ac.Fax,
                    //                Email = ac.Email,
                    //                //StatusId = ac.StatusId,
                    //                //LanguageId = ac.LanguageId,
                    //            }).ToList();

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

                    dataGridViewAccounts.DataSource = accounts;
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridViewAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 12)
            {
                //TODO - Button Clicked - Execute Code Here
                //MessageBox.Show("hello");
                var cellButton = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //var addressIdCell = senderGrid.Rows[e.RowIndex].Cells[22];
            }
        }

        private void dataGridViewAccounts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                var addressIdCell = senderGrid.Rows[e.RowIndex].Cells[11];
                int addressId = addressIdCell.Value != null ? (int)addressIdCell.Value : 0;

                if (addressId <= 0)
                {
                    MessageBox.Show("This account has no address.");
                    return;
                }


            }
        }
    }
}
