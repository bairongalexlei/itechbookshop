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
    public partial class frmReceiptSummary : Form
    {
        private Common.SummarySearchParams searchParms;

        public frmReceiptSummary()
        {
            InitializeComponent();
        }

        public frmReceiptSummary(Common.SummarySearchParams summarySearchParms)
        {
            InitializeComponent();
            searchParms = summarySearchParms;
        }

        private void fromReceiptSummary_Load(object sender, EventArgs e)
        {
            try
            {
                rptReceiptSummaryViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptReceiptSummaryViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptReceiptSummary.rdlc";

                using (var dbContext = new BookShopEntities())
                {
                    var fromDate = searchParms.FromDate;
                    var toDate = searchParms.ToDate;

                    var offerings = dbContext.Offerings.Where(oneOffering =>
                        oneOffering.StatusId == (int)Common.CommonEnum.Status.Active);

                    if (fromDate != null && fromDate > DateTime.MinValue)
                    {
                        offerings = offerings.Where(oneOffering => oneOffering.CreatedDate >= fromDate);
                    }

                    if (toDate != null && toDate > DateTime.MinValue)
                    {
                        offerings = offerings.Where(oneOffering => oneOffering.CreatedDate <= toDate);
                    }

                    var offeringReceiptSummaries = offerings.GroupBy(oneOffering => (oneOffering.ReceiptTypeId ?? 0))
                                                .Select(g => new 
                                                {
                                                    ReceiptTypeId = g.Key,
                                                    ReceiptTypeName = ((Common.CommonEnum.ReceiptType)g.Key).ToString(),
                                                    CountOfOfferings = g.Count(),
                                                    Amount = g.Sum(oneOffering => oneOffering.Amount),
                                                }).ToList();

                    var dsOfferingReceipt = new ReportDataSource();
                    dsOfferingReceipt.Name = "ReceiptSummaryDataSet";
                    dsOfferingReceipt.Value = offeringReceiptSummaries;

                    localReport.DataSources.Add(dsOfferingReceipt);
                }
            }
            catch
            {
                MessageBox.Show("Error on getting offering accumulation. Please contact iTech support for assistance.");
            }

            this.rptReceiptSummaryViewer.RefreshReport();
        }
    }
}
