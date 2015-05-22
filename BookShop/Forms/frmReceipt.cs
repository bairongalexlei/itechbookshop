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
    public partial class frmReceipt : Form
    {
        public frmReceipt()
        {
            InitializeComponent();
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = reportViewer1.LocalReport;

                localReport.ReportPath = "Forms\\rptOfferingReceipt.rdlc";

                //Get data source here
                using (var dbContext = new BookShopEntities())
                {
                    var offeringReceipts = dbContext.Offerings.Where(offering => offering.AccountId == 3)
                            .Select(offr => new {
                                Amount = offr.Amount ?? 0,
                                OfferingYear = offr.OfferingYear ?? 0,
                                ReceiptDate = offr.ReceiptDate ?? DateTime.MinValue,
                                ReceiptId = offr.ReceiptId ?? 0,
                                ReceiptIssuedDate = offr.ReceiptIssuedDate ?? DateTime.MinValue,
                                ReceiptTypeId = offr.ReceiptTypeId ?? 0,
                                ReceivedDate = offr.ReceivedDate ?? DateTime.MinValue,
                                SignatureUserId = offr.SignatureUserId,
                            }).ToList();

                    var dsOfferingReceipt = new ReportDataSource();
                    dsOfferingReceipt.Name = "ReceiptOfferingDataSet";
                    dsOfferingReceipt.Value = offeringReceipts;//null;

                    localReport.DataSources.Add(dsOfferingReceipt);
                }

                //var dsOfferingReceipt = new ReportDataSource();
                //dsOfferingReceipt.Name = "ReceiptOfferingDataSet";
                //dsOfferingReceipt.Value = null;

                //localReport.DataSources.Add(dsOfferingReceipt);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
