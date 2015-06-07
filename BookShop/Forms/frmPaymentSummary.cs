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
    public partial class frmPaymentSummary : Form
    {
        private Common.SummarySearchParams searchParms;

        public frmPaymentSummary()
        {
            InitializeComponent();
        }

        public frmPaymentSummary(Common.SummarySearchParams summarySearchParms)
        {
            InitializeComponent();
            searchParms = summarySearchParms;
        }

        private void frmPaymentSummary_Load(object sender, EventArgs e)
        {

            try
            {
                rptPaymentSummaryViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptPaymentSummaryViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptPaymentMethodSummary.rdlc";

                using (var dbContext = new BookShopEntities())
                {
                    var fromDate = searchParms.FromDate;
                    var toDate = searchParms.ToDate;
                    string fromDateParameter = string.Empty;
                    string toDateParameter = string.Empty;

                    var offerings = dbContext.Offerings.Where(oneOffering =>
                        oneOffering.StatusId == (int)Common.CommonEnum.Status.Active);

                    if (fromDate != null && fromDate > DateTime.MinValue)
                    {
                        offerings = offerings.Where(oneOffering => oneOffering.CreatedDate >= fromDate);
                        fromDateParameter = fromDate.ToShortDateString();
                    }

                    if (toDate != null && toDate > DateTime.MinValue)
                    {
                        offerings = offerings.Where(oneOffering => oneOffering.CreatedDate <= toDate);
                        toDateParameter = toDate.ToShortDateString();
                    }

                    var offeringPaymentSummaries = offerings.GroupBy(oneOffering => (oneOffering.MethodId ?? 0))
                                                .Select(g => new
                                                {
                                                    PaymentMethodId = g.Key,
                                                    PaymentMethodName = ((Common.CommonEnum.PaymentMethod)g.Key).ToString(),
                                                    Amount = g.Sum(oneOffering => oneOffering.Amount),
                                                }).ToList();

                    var dsOfferingPaymentMethod = new ReportDataSource();
                    dsOfferingPaymentMethod.Name = "PaymentSummaryDataSet";
                    dsOfferingPaymentMethod.Value = offeringPaymentSummaries;

                    localReport.DataSources.Add(dsOfferingPaymentMethod);

                    ReportParameter[] rptPerameters = new ReportParameter[2];
                    rptPerameters[0] = new ReportParameter("FromDate", fromDateParameter);
                    rptPerameters[1] = new ReportParameter("ToDate", toDateParameter);
                    localReport.SetParameters(rptPerameters);
                }
            }
            catch
            {
                MessageBox.Show("Error on getting payment method accumulation. Please contact iTech support for assistance.");
            }

            this.rptPaymentSummaryViewer.RefreshReport();
        }
    }
}
