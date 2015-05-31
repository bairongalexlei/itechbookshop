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
    public partial class frmDepartmentProjectSummary : Form
    {
        private Common.SummarySearchParams searchParms;

        public frmDepartmentProjectSummary()
        {
            InitializeComponent();
        }

        public frmDepartmentProjectSummary(Common.SummarySearchParams summarySearchParms)
        {
            InitializeComponent();
            searchParms = summarySearchParms;
        }

        private void frmDepartmentProjectSummary_Load(object sender, EventArgs e)
        {
            try
            {
                rptDepartmentProjectSummaryViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptDepartmentProjectSummaryViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptDepartmentProjectSummary.rdlc";

                using (var dbContext = new BookShopEntities())
                {
                    var fromDate = searchParms.FromDate;
                    var toDate = searchParms.ToDate;
                    string fromDateParameter = string.Empty;
                    string toDateParameter = string.Empty;

                    //var offerings = dbContext.Offerings.Where(oneOffering =>
                    //    oneOffering.StatusId == (int)Common.CommonEnum.Status.Active &&
                    //    oneOffering.OfferingLines != null &&
                    //    oneOffering.OfferingLines.Count > 0);

                    var offeringLines = dbContext.OfferingLines.Where(oneOfferingLine =>
                        oneOfferingLine.StatusId == (int)Common.CommonEnum.Status.Active &&
                        oneOfferingLine.Offering != null &&
                        oneOfferingLine.Offering.StatusId == (int)Common.CommonEnum.Status.Active &&
                        oneOfferingLine.ProjectId > 0);

                    if (fromDate != null && fromDate > DateTime.MinValue)
                    {
                        //offerings = offerings.Where(oneOffering => oneOffering.CreatedDate >= fromDate);
                        offeringLines = offeringLines.Where(oneOfferinLine => oneOfferinLine.CreatedDate >= fromDate);
                        fromDateParameter = fromDate.ToShortDateString();
                    }

                    if (toDate != null && toDate > DateTime.MinValue)
                    {
                        //offerings = offerings.Where(oneOffering => oneOffering.CreatedDate <= toDate);
                        offeringLines = offeringLines.Where(oneOfferinLine => oneOfferinLine.CreatedDate <= toDate);
                        toDateParameter = toDate.ToShortDateString();
                    }

                    var departmentProjectGroups = offeringLines.GroupBy(ofl =>
                            new
                            {
                                ofl.Project.Department.DepartmentName,
                                ofl.Project.Description
                            })
                            .Select(dpg => new
                            {
                                Department = dpg.Key.DepartmentName,
                                Project = dpg.Key.Description,
                                Amount = dpg.Sum(g => g.Amount),
                                OfferingsCount = dpg.Count()
                            }).ToList();

                    var dsDepartmentProject = new ReportDataSource();
                    dsDepartmentProject.Name = "DepartmentProjectSummaryDataSet";
                    dsDepartmentProject.Value = departmentProjectGroups;

                    localReport.DataSources.Add(dsDepartmentProject);

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

            this.rptDepartmentProjectSummaryViewer.RefreshReport();
        }
    }
}
