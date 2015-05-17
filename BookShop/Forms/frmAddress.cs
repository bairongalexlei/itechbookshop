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
    public partial class frmAddress : Form
    {
        public int Addressid { get; set; }

        public frmAddress()
        {
            InitializeComponent();
            BindAddress();
        }

        public frmAddress(int addressId)
        {
            InitializeComponent();
            //SetAddressId(addressId);
            Addressid = addressId;
            BindAddress();
        }

        private void BindAddress()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //if (Addressid <= 0)
            //{
            //    return;
            //}

            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var address = dbContext.Addresses.FirstOrDefault(addr => addr.AddressId == Addressid);

                    if (address != null)
                    {
                        txtUnit.Text = (address.UnitSuiteNumber ?? 0) > 0 ? address.UnitSuiteNumber.Value.ToString() : null;
                        txtStreet.Text = address.StreetName;
                        txtCity.Text = address.City;
                        txtProvince.Text = address.Province;
                        txtCountry.Text = address.Country;
                        txtPostalCode.Text = address.PostalCode;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error occurs when binding address. Please contact iTech support for assistance.");
            }
        }

        //public void SetAddressId(int addressId)
        //{
        //    Addressid = addressId;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new BookShopEntities())
                {
                    var address = dbContext.Addresses.FirstOrDefault(addr => addr.AddressId == Addressid);

                    if (address != null)
                    {
                        if (!string.IsNullOrEmpty(txtUnit.Text))
                        {
                            int unitNumber = 0;
                            string strUnit = txtUnit.Text.Trim();
                            int.TryParse(strUnit, out unitNumber);
                            if (unitNumber > 0) 
                                address.UnitSuiteNumber = unitNumber;
                        }
                        else
                        {
                            address.UnitSuiteNumber = null;
                        }

                        address.StreetName = !string.IsNullOrEmpty(txtStreet.Text) ? txtStreet.Text.Trim() : null;
                        address.City = !string.IsNullOrEmpty(txtCity.Text) ? txtCity.Text.Trim() : null;
                        address.Province = !string.IsNullOrEmpty(txtProvince.Text) ? txtProvince.Text.Trim() : null;
                        address.Country = !string.IsNullOrEmpty(txtCountry.Text) ? txtCountry.Text.Trim() : null;
                        address.PostalCode = !string.IsNullOrEmpty(txtPostalCode.Text) ? txtPostalCode.Text.Trim() : null;

                        dbContext.SaveChanges();
                    }
                    else
                    {
                        address = new Address();
                        if (!string.IsNullOrEmpty(txtUnit.Text))
                        {
                            int unitNumber = 0;
                            string strUnit = txtUnit.Text.Trim();
                            int.TryParse(strUnit, out unitNumber);
                            if (unitNumber > 0)
                                address.UnitSuiteNumber = unitNumber;
                        }
                        else
                        {
                            address.UnitSuiteNumber = null;
                        }

                        address.StreetName = !string.IsNullOrEmpty(txtStreet.Text) ? txtStreet.Text.Trim() : null;
                        address.City = !string.IsNullOrEmpty(txtCity.Text) ? txtCity.Text.Trim() : null;
                        address.Province = !string.IsNullOrEmpty(txtProvince.Text) ? txtProvince.Text.Trim() : null;
                        address.Country = !string.IsNullOrEmpty(txtCountry.Text) ? txtCountry.Text.Trim() : null;
                        address.PostalCode = !string.IsNullOrEmpty(txtPostalCode.Text) ? txtPostalCode.Text.Trim() : null;

                        dbContext.Addresses.Add(address);
                        dbContext.SaveChanges();
                        Addressid = address.AddressId;
                    }
                }

                MessageBox.Show("Address was updated successfully");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error occurs when saving address. Please contact iTech support for assistance.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
