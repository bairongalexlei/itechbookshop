using BookShop.EFData;
using Microsoft.Reporting.WinForms;
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
        private DateTime dateGreaterThan;
        private DateTime dateLessThan;

        public frmByOrganization()
        {
            InitializeComponent();
        }

        public frmByOrganization(string strDateGreaterThan, string strDateLessThan)
        {
            if (!string.IsNullOrEmpty(strDateGreaterThan))
            {
                DateTime.TryParse(strDateGreaterThan, out dateGreaterThan);
            }

            if (!string.IsNullOrEmpty(strDateLessThan))
            {
                DateTime.TryParse(strDateLessThan, out dateLessThan);
            }

            InitializeComponent();
        }

        private void frmByOrganization_Load(object sender, EventArgs e)
        {

            try
            {
                rptByOrganizationViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptByOrganizationViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptByOrganizationReport.rdlc";

                //Get data source here
                using (var dbContext = new BookShopEntities())
                {
                    string fromDateParameter = string.Empty;
                    string toDateParameter = string.Empty;

                    var query = dbContext.Offerings.Where(offr =>
                        offr.StatusId == (int)Common.CommonEnum.Status.Active);

                    if (dateGreaterThan != null && dateGreaterThan > DateTime.MinValue)
                    {
                        query = query.Where(offr => offr.CreatedDate >= dateGreaterThan);
                        fromDateParameter = dateGreaterThan.ToShortDateString();
                    }

                    if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                    {
                        query = query.Where(offr => offr.CreatedDate <= dateLessThan);
                        toDateParameter = dateLessThan.ToShortDateString();
                    }

                    //test here
                    //        [DisplayValue("Church")]
                    //Church = 1,
                    //[DisplayValue("Individual")]
                    //Individual = 2,
                    //[DisplayValue("Organization")]
                    //Organization = 3,
                    //[DisplayValue("Y-Church")]
                    //YChurch = 4,
                    //[DisplayValue("Y-Individual")]
                    //YIndividual = 5,
                    //[DisplayValue("Y-Organization")]
                    //YOrganization = 6
                    int[] organizationTypeIds = { 1, 3, 4, 6 };
                    query = query.Where(offr => organizationTypeIds.Contains(offr.Account.AccountTypeId));

                    var offerings = query.Select(offr => new
                    {
                        OfferingId = offr.OfferingId,
                        AccountId = offr.AccountId,
                        AccountType = ((Common.CommonEnum.AccountType)offr.Account.AccountTypeId).ToString(),
                        FirstName = offr.Account.FirstName,
                        LastName = offr.Account.LastName,
                        Telephone = offr.Account.Phone,
                        Organization = offr.Account.OrganizationName,

                        UnitNum = (offr.Account.Address != null &&
                            (offr.Account.Address.UnitSuiteNumber ?? 0) > 0) ?
                            (offr.Account.Address.UnitSuiteNumber ?? 0).ToString() : "",
                        StreetName = (offr.Account.Address != null &&
                            (offr.Account.Address.StreetName != null) &&
                            offr.Account.Address.StreetName != "") ?
                            offr.Account.Address.StreetName : "",
                        City = (offr.Account.Address != null &&
                            (offr.Account.Address.City != null) &&
                            offr.Account.Address.City != "") ?
                            offr.Account.Address.City : "",
                        Province = (offr.Account.Address != null &&
                            (offr.Account.Address.Province != null) &&
                            offr.Account.Address.Province != "") ?
                            offr.Account.Address.Province : "",
                        Country = (offr.Account.Address != null &&
                            (offr.Account.Address.Country != null) &&
                            offr.Account.Address.Country != "") ?
                            offr.Account.Address.Country : "",
                        PostalCode = (offr.Account.Address != null &&
                        (offr.Account.Address.PostalCode != null) &&
                        offr.Account.Address.PostalCode != "") ?
                        offr.Account.Address.PostalCode : "",

                        Email = offr.Account.Email,
                        Spouse = offr.Account.SpouseFirstName,

                        ReceivedDate = offr.CreatedDate,
                        ReceiptId = (offr.ReceiptId ?? 0),
                        ReceivedYear = offr.CreatedDate.Year,
                        Amount = offr.Amount ?? 0
                    }).ToList();

                    var offeringBEs = offerings.Select(offr => new
                    {
                        OfferingId = offr.OfferingId,
                        AccountId = offr.AccountId,
                        AccountType = offr.AccountType,
                        FirstName = offr.FirstName,
                        LastName = offr.LastName,
                        Telephone = offr.Telephone,
                        Organization = !string.IsNullOrEmpty(offr.Organization) ? 
                            offr.Organization : "No Organization",

                        FullAddress = Common.Helper.GetFormattedAddressLine(
                            offr.UnitNum,
                            offr.StreetName,
                            offr.City,
                            offr.Province,
                            offr.Country,
                            offr.PostalCode),

                        Email = offr.Email,
                        Spouse = offr.Spouse,

                        ReceivedDate = offr.ReceivedDate.ToShortDateString(),
                        ReceiptNumber = offr.ReceiptId > 0 ?
                            string.Format("{0}-{1}", offr.ReceivedYear.ToString(),
                            offr.ReceiptId.ToString().PadLeft(6, '0')) : "",
                        //ReceiptId = (offr.ReceiptId ?? 0),
                        //ReceivedYear = offr.CreatedDate.Year,
                        Amount = offr.Amount
                    }).ToList();

                    var dsByIndividual = new ReportDataSource();
                    dsByIndividual.Name = "ByOrganizationDataSet";
                    dsByIndividual.Value = offeringBEs;

                    localReport.DataSources.Add(dsByIndividual);

                    ReportParameter[] rptPerameters = new ReportParameter[2];
                    rptPerameters[0] = new ReportParameter("FromDate", fromDateParameter);
                    rptPerameters[1] = new ReportParameter("ToDate", toDateParameter);
                    localReport.SetParameters(rptPerameters);
                }

                this.rptByOrganizationViewer.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error on generating by organization report. Please contact iTech support for assistance.");
            }

            //this.rptByOrganizationViewer.RefreshReport();
        }
    }
}
