using BookShop.EFData;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.Forms
{
    public partial class frmByProvince : Form
    {
        private DateTime dateGreaterThan;
        private DateTime dateLessThan;

        public frmByProvince()
        {
            InitializeComponent();
        }

        public frmByProvince(string strDateGreaterThan, string strDateLessThan)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-CA");
            var parseDateFormat = "dd/MM/yyyy";

            if (!string.IsNullOrEmpty(strDateGreaterThan))
            {
                //DateTime.TryParse(strDateGreaterThan, out dateGreaterThan);
                DateTime.TryParseExact(strDateGreaterThan, parseDateFormat, culture, DateTimeStyles.None, out dateGreaterThan);
            }

            if (!string.IsNullOrEmpty(strDateLessThan))
            {
                //DateTime.TryParse(strDateLessThan, out dateLessThan);
                DateTime.TryParseExact(strDateLessThan, parseDateFormat, culture, DateTimeStyles.None, out dateLessThan);
                if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                {
                    dateLessThan = dateLessThan.AddDays(1);
                }
            }

            InitializeComponent();
        }

        private void frmByProvince_Load(object sender, EventArgs e)
        {
            try
            {
                rptByProvinceViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptByProvinceViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptByProvinceReport.rdlc";

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
                        //fromDateParameter = dateGreaterThan.ToShortDateString();
                        fromDateParameter = dateGreaterThan.ToString("dd/MM/yyyy");
                    }

                    if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                    {
                        query = query.Where(offr => offr.CreatedDate <= dateLessThan);
                        //toDateParameter = dateLessThan.ToShortDateString();
                        toDateParameter = dateLessThan.ToString("dd/MM/yyyy");
                    }


                    var offerings = query.Select(offr => new
                    {
                        Amount = offr.Amount ?? 0,
                        AccountId = offr.Account.AccountId,
                        AccountType = ((Common.CommonEnum.AccountType)offr.Account.AccountTypeId).ToString(),

                        OfferingId = offr.OfferingId,
                        FirstName = offr.Account.FirstName,
                        LastName = offr.Account.LastName,
                        Province = (offr.Account.Address != null &&
                            offr.Account.Address.Province != null &&
                            offr.Account.Address.Province != "") ?
                            offr.Account.Address.Province : "No Province Name",
                    });

                    var accountOfferingGroups = offerings.GroupBy(offering => offering.AccountId)
                                            .Select(aog => new
                                                {
                                                    AccountId = aog.Key,
                                                    AccountType = aog.FirstOrDefault().AccountType,
                                                    ProvinceName = aog.FirstOrDefault().Province,
                                                    Amount = aog.Sum(g => g.Amount),
                                                    FirstName = aog.FirstOrDefault().FirstName,
                                                    LastName = aog.FirstOrDefault().LastName
                                                }).ToList();

                    var dsByProvince = new ReportDataSource();
                    dsByProvince.Name = "ByProvinceDataSet";
                    dsByProvince.Value = accountOfferingGroups;

                    localReport.DataSources.Add(dsByProvince);

                    ReportParameter[] rptPerameters = new ReportParameter[2];
                    rptPerameters[0] = new ReportParameter("FromDate", fromDateParameter);
                    rptPerameters[1] = new ReportParameter("ToDate", toDateParameter);
                    localReport.SetParameters(rptPerameters);
                }

                this.rptByProvinceViewer.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error on generating by province report. Please contact iTech support for assistance.");
            }
        }
    }
}
