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
    public partial class frmNontaxableReceipt : Form
    {
        private DateTime dateGreaterThan;
        private DateTime dateLessThan;
        private int OfferingId;
        private string ReceiptNumber;
        private bool isBundlePrint;
        private int yearEndAccountId;
        private int yearEndReceiptYear;

        public frmNontaxableReceipt()
        {
            InitializeComponent();
        }

        public frmNontaxableReceipt(int offeringId, string receiptNumber)
        {
            InitializeComponent();
            OfferingId = offeringId;
            ReceiptNumber = receiptNumber;
            isBundlePrint = false;
        }

        public frmNontaxableReceipt(string strDateGreaterThan, string strDateLessThan)
        {
            InitializeComponent();

            var culture = CultureInfo.CreateSpecificCulture("en-CA");
            var parseShortDateFormat = "dd/MM/yyyy";

            if (!string.IsNullOrEmpty(strDateGreaterThan))
            {
                //DateTime.TryParse(strDateGreaterThan, out dateGreaterThan);
                DateTime.TryParseExact(strDateGreaterThan, parseShortDateFormat, culture, DateTimeStyles.None, out dateGreaterThan);
            }

            if (!string.IsNullOrEmpty(strDateLessThan))
            {
                //DateTime.TryParse(strDateLessThan, out dateLessThan);
                DateTime.TryParseExact(strDateLessThan, parseShortDateFormat, culture, DateTimeStyles.None, out dateLessThan);
                if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                {
                    dateLessThan = dateLessThan.AddDays(1);
                }
            }

            isBundlePrint = true;
        }

        public frmNontaxableReceipt(int yearEndAccountId, int year)
        {
            InitializeComponent();

            this.yearEndAccountId = yearEndAccountId;
            yearEndReceiptYear = year;
            isBundlePrint = true;
        }

        private void frmNontaxableReceipt_Load(object sender, EventArgs e)
        {
            //if (isBundlePrint)
            //{
            //    GenerateBundleReceipt();
            //    return;
            //}

            if (isBundlePrint)
            {
                if (yearEndReceiptYear <= 0)
                {
                    GenerateNonYearEndBundleReceipt();
                }
                else
                {
                    GenerateYearEndBundleReceipt();
                }

                return;
            }

            if (OfferingId <= 0)
            {
                MessageBox.Show("Offering Id is not assinged yet.");
                return;
            }

            if (string.IsNullOrEmpty(ReceiptNumber))
            {
                MessageBox.Show("Receipt number is empty.");
                return;
            }

            try
            {
                rptNontaxableReceiptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptNontaxableReceiptViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptNontaxableReceipt.rdlc";

                //Get data source here
                using (var dbContext = new BookShopEntities())
                {
                    //var offeringReceipts = dbContext.Offerings.Where(offering => offering.AccountId == 3)
                    var offeringReceipts = dbContext.Offerings.Where(offering => offering.OfferingId == OfferingId)
                            .Select(offr => new
                            {
                                Amount = offr.Amount ?? 0,
                                OfferingYear = offr.OfferingYear ?? 0,
                                ReceiptDate = offr.ReceiptDate ?? DateTime.MinValue,
                                ReceiptId = offr.ReceiptId ?? 0,
                                ReceiptIssuedDate = offr.ReceiptIssuedDate.HasValue ?
                                    offr.ReceiptIssuedDate.Value : DateTime.MinValue,
                                ReceiptTypeId = offr.ReceiptTypeId ?? 0,
                                //ReceivedDate = offr.ReceivedDate ?? DateTime.MinValue,
                                ReceivedDate = offr.CreatedDate,
                                SignatureUserId = offr.SignatureUserId,

                                OfferingId = offr.OfferingId,
                                FirstName = offr.Account.FirstName,
                                LastName = offr.Account.LastName,
                                UnitNumber = (offr.Account.Address != null ?
                                    (offr.Account.Address.UnitSuiteNumber ?? 0) : 0),
                                StreetName = offr.Account.Address != null ?
                                    offr.Account.Address.StreetName : "",
                                City = offr.Account.Address != null ?
                                    offr.Account.Address.City : "",
                                Province = offr.Account.Address != null ?
                                    offr.Account.Address.Province : "",
                                Country = offr.Account.Address != null ?
                                    offr.Account.Address.Country : "",
                                PostalCode = offr.Account.Address != null ?
                                    offr.Account.Address.PostalCode : "",
                                SingatureImage = offr.User.SignatureImageBytes,
                                ReceiptNumber = ReceiptNumber,
                                Organization = offr.Account.OrganizationName,
                                //FormattedAddress = ""
                            }).ToList();

                    var dsOfferingReceipt = new ReportDataSource();
                    dsOfferingReceipt.Name = "ReceiptOfferingDataSet";
                    dsOfferingReceipt.Value = offeringReceipts;

                    localReport.DataSources.Add(dsOfferingReceipt);
                }

                rptNontaxableReceiptViewer.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error on generating receipt. Please contact iTech support for assistance.");
            }
        }

        private void GenerateYearEndBundleReceipt()
        {
            try
            {
                rptNontaxableReceiptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptNontaxableReceiptViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptNontaxableReceipt.rdlc";

                int[] yearEndReceiptTypes = { 
                                                (int)Common.CommonEnum.AccountType.YChurch,
                                                (int)Common.CommonEnum.AccountType.YIndividual,
                                                (int)Common.CommonEnum.AccountType.YOrganization,
                                            };

                //Get data source here
                using (var dbContext = new BookShopEntities())
                {
                    //var query = dbContext.Offerings.Where(offr => offr.StatusId == (int)Common.CommonEnum.Status.Active);
                    var query = dbContext.Offerings.Where(offr =>
                        offr.StatusId == (int)Common.CommonEnum.Status.Active &&
                        offr.ReceiptTypeId != (int)Common.CommonEnum.ReceiptType.Individual);

                    if (dateGreaterThan != null && dateGreaterThan > DateTime.MinValue)
                        query = query.Where(offr => offr.CreatedDate >= dateGreaterThan);

                    if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                        query = query.Where(offr => offr.CreatedDate <= dateLessThan);


                    query = query.Where(offr => yearEndReceiptTypes.Contains(offr.Account.AccountTypeId));

                    if (yearEndAccountId > 0)
                    {
                        query = query.Where(offr => offr.AccountId == yearEndAccountId);
                    }

                    if (yearEndReceiptYear > 0)
                    {
                        query = query.Where(offr => offr.CreatedDate.Year == yearEndReceiptYear);
                    }

                    //test begins here to autogenerate receipt id for no receipt id offerings
                    var offerings = query.ToList();
                    var nonReceiptIdOfferings = offerings.Where(offr => !offr.ReceiptId.HasValue).ToList();
                    if (nonReceiptIdOfferings != null && nonReceiptIdOfferings.Count > 0)
                    {
                        int currentReceiptCount = 0;
                        int offeringYear = DateTime.Now.Year;
                        var currentYearReceiptCounter = dbContext.ReceiptCounters.FirstOrDefault(c =>
                            c.ReceiptYear == offeringYear);

                        if (currentYearReceiptCounter == null)
                        {
                            currentYearReceiptCounter = new ReceiptCounter
                            {
                                ReceiptYear = offeringYear,
                                ReceiptCount = currentReceiptCount
                            };

                            dbContext.ReceiptCounters.Add(currentYearReceiptCounter);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            currentReceiptCount = currentYearReceiptCounter.ReceiptCount;
                        }

                        foreach (var offering in nonReceiptIdOfferings)
                        {
                            currentReceiptCount++;
                            offering.ReceiptId = currentReceiptCount;
                        }

                        currentYearReceiptCounter.ReceiptCount = currentReceiptCount;
                        dbContext.SaveChanges();
                    }
                    //test ends here

                    //var offeringReceipts = query.Select(offr => new
                    var offeringReceipts = offerings.Select(offr => new
                    {
                        Amount = offr.Amount ?? 0,
                        OfferingYear = offr.OfferingYear ?? 0,
                        ReceiptDate = offr.ReceiptDate ?? DateTime.MinValue,
                        ReceiptId = offr.ReceiptId ?? 0,
                        ReceiptIssuedDate = offr.ReceiptIssuedDate.HasValue ?
                            offr.ReceiptIssuedDate.Value : DateTime.MinValue,
                        ReceiptTypeId = offr.ReceiptTypeId ?? 0,
                        //ReceivedDate = offr.ReceivedDate ?? DateTime.MinValue,
                        ReceivedDate = offr.CreatedDate,
                        SignatureUserId = offr.SignatureUserId,
                        CreatedDate = offr.CreatedDate,

                        OfferingId = offr.OfferingId,
                        FirstName = offr.Account.FirstName,
                        LastName = offr.Account.LastName,
                        UnitNumber = (offr.Account.Address != null ?
                            (offr.Account.Address.UnitSuiteNumber ?? 0) : 0),
                        StreetName = offr.Account.Address != null ?
                            offr.Account.Address.StreetName : "",
                        City = offr.Account.Address != null ?
                            offr.Account.Address.City : "",
                        Province = offr.Account.Address != null ?
                            offr.Account.Address.Province : "",
                        Country = offr.Account.Address != null ?
                            offr.Account.Address.Country : "",
                        PostalCode = offr.Account.Address != null ?
                            offr.Account.Address.PostalCode : "",
                        SingatureImage = offr.User.SignatureImageBytes,
                        //ReceiptNumber = ReceiptNumber,
                        ReceiptYear = offr.CreatedDate.Year.ToString(),
                        Organization = offr.Account.OrganizationName,
                    }).ToList();

                    var offeringReceiptBEs = offeringReceipts.Select(offr => new
                    {
                        Amount = offr.Amount,
                        OfferingYear = offr.OfferingYear,
                        ReceiptDate = offr.ReceiptDate,
                        ReceiptId = offr.ReceiptId,
                        ReceiptIssuedDate = offr.ReceiptIssuedDate,
                        ReceiptTypeId = offr.ReceiptTypeId,
                        ReceivedDate = offr.ReceivedDate,
                        SignatureUserId = offr.SignatureUserId,

                        OfferingId = offr.OfferingId,
                        FirstName = offr.FirstName,
                        LastName = offr.LastName,
                        UnitNumber = offr.UnitNumber,
                        StreetName = offr.StreetName,
                        City = offr.City,
                        Province = offr.Province,
                        Country = offr.Country,
                        PostalCode = offr.PostalCode,
                        SingatureImage = offr.SingatureImage,
                        //ReceiptNumber = ReceiptNumber,
                        ReceiptNumber = offr.ReceiptId > 0 ?
                            string.Format("{0}-{1}", offr.CreatedDate.Year.ToString(), offr.ReceiptId.ToString().PadLeft(6, '0'))
                            : "",
                        Organization = offr.Organization,
                    }).ToList();

                    var dsOfferingReceipt = new ReportDataSource();
                    dsOfferingReceipt.Name = "ReceiptOfferingDataSet";
                    //dsOfferingReceipt.Value = offeringReceipts;
                    dsOfferingReceipt.Value = offeringReceiptBEs;

                    localReport.DataSources.Add(dsOfferingReceipt);
                }

                rptNontaxableReceiptViewer.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error on generating year end bundle receipt. Please contact iTech support for assistance.");
            }
        }

        //private void GenerateBundleReceipt()
        private void GenerateNonYearEndBundleReceipt()
        {
            try
            {
                rptNontaxableReceiptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                var localReport = rptNontaxableReceiptViewer.LocalReport;

                localReport.ReportPath = "Forms\\rptNontaxableReceipt.rdlc";

                int[] yearEndReceiptTypes = { 
                                                (int)Common.CommonEnum.AccountType.YChurch,
                                                (int)Common.CommonEnum.AccountType.YIndividual,
                                                (int)Common.CommonEnum.AccountType.YOrganization,
                                            };

                //Get data source here
                using (var dbContext = new BookShopEntities())
                {
                    //var query = dbContext.Offerings.Where(offr => offr.StatusId == (int)Common.CommonEnum.Status.Active);
                    var query = dbContext.Offerings.Where(offr => 
                        offr.StatusId == (int)Common.CommonEnum.Status.Active &&
                        offr.ReceiptTypeId != (int)Common.CommonEnum.ReceiptType.Individual);
                    
                    if (dateGreaterThan != null && dateGreaterThan > DateTime.MinValue)
                        query = query.Where(offr => offr.CreatedDate >= dateGreaterThan);

                    if (dateLessThan != null && dateLessThan > DateTime.MinValue)
                        query = query.Where(offr => offr.CreatedDate <= dateLessThan);


                    query = query.Where(offr => !yearEndReceiptTypes.Contains(offr.Account.AccountTypeId));

                    //bug fix
                    var firstTimePrintOfferings = query.Where(offr => !offr.ReceiptIssuedDate.HasValue).ToList();
                    if (firstTimePrintOfferings != null && firstTimePrintOfferings.Count > 0)
                    {
                        SetReceiptIssuedDate(dbContext, firstTimePrintOfferings);
                    }

                    var offeringReceipts = query.Select(offr => new
                    {
                        Amount = offr.Amount ?? 0,
                        OfferingYear = offr.OfferingYear ?? 0,
                        ReceiptDate = offr.ReceiptDate ?? DateTime.MinValue,
                        ReceiptId = offr.ReceiptId ?? 0,
                        ReceiptIssuedDate = offr.ReceiptIssuedDate.HasValue ?
                            offr.ReceiptIssuedDate.Value : DateTime.MinValue,
                        ReceiptTypeId = offr.ReceiptTypeId ?? 0,
                        ReceivedDate = offr.ReceivedDate ?? DateTime.MinValue,
                        SignatureUserId = offr.SignatureUserId,
                        CreatedDate = offr.CreatedDate,

                        OfferingId = offr.OfferingId,
                        Organization = offr.Account.OrganizationName,
                        FirstName = offr.Account.FirstName,
                        LastName = offr.Account.LastName,
                        UnitNumber = (offr.Account.Address != null ?
                            (offr.Account.Address.UnitSuiteNumber ?? 0) : 0),
                        StreetName = offr.Account.Address != null ?
                            offr.Account.Address.StreetName : "",
                        City = offr.Account.Address != null ?
                            offr.Account.Address.City : "",
                        Province = offr.Account.Address != null ?
                            offr.Account.Address.Province : "",
                        Country = offr.Account.Address != null ?
                            offr.Account.Address.Country : "",
                        PostalCode = offr.Account.Address != null ?
                            offr.Account.Address.PostalCode : "",
                        SingatureImage = offr.User.SignatureImageBytes,
                        //ReceiptNumber = ReceiptNumber,
                        ReceiptYear = offr.CreatedDate.Year.ToString(),
                    }).ToList();

                    var offeringReceiptBEs = offeringReceipts.Select(offr => new
                    {
                        Amount = offr.Amount,
                        OfferingYear = offr.OfferingYear,
                        ReceiptDate = offr.ReceiptDate,
                        ReceiptId = offr.ReceiptId,
                        ReceiptIssuedDate = offr.ReceiptIssuedDate,
                        ReceiptTypeId = offr.ReceiptTypeId,
                        //ReceivedDate = offr.ReceivedDate,
                        ReceivedDate = offr.CreatedDate,
                        SignatureUserId = offr.SignatureUserId,

                        OfferingId = offr.OfferingId,
                        Organization = offr.Organization,
                        FirstName = offr.FirstName,
                        LastName = offr.LastName,
                        UnitNumber = offr.UnitNumber,
                        StreetName = offr.StreetName,
                        City = offr.City,
                        Province = offr.Province,
                        Country = offr.Country,
                        PostalCode = offr.PostalCode,
                        SingatureImage = offr.SingatureImage,
                        //ReceiptNumber = ReceiptNumber,
                        ReceiptNumber = offr.ReceiptId > 0 ?
                            string.Format("{0}-{1}", offr.CreatedDate.Year.ToString(), offr.ReceiptId.ToString().PadLeft(6, '0'))
                            : "",
                    }).ToList();

                    var dsOfferingReceipt = new ReportDataSource();
                    dsOfferingReceipt.Name = "ReceiptOfferingDataSet";
                    //dsOfferingReceipt.Value = offeringReceipts;
                    dsOfferingReceipt.Value = offeringReceiptBEs;

                    localReport.DataSources.Add(dsOfferingReceipt);
                }

                rptNontaxableReceiptViewer.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error on generating non-year end bundle receipt. Please contact iTech support for assistance.");
            }
        }

        private void SetReceiptIssuedDate(BookShopEntities dbContext, List<Offering> firstTimePrintOfferings)
        {
            int currentReceiptCount = 1;
            int offeringYear = DateTime.Now.Year;
            var currentYearReceiptCounter = dbContext.ReceiptCounters.FirstOrDefault(c =>
                c.ReceiptYear == offeringYear);

            if (currentYearReceiptCounter == null)
            {
                currentYearReceiptCounter = new ReceiptCounter
                {
                    ReceiptYear = offeringYear,
                    ReceiptCount = currentReceiptCount
                };

                dbContext.ReceiptCounters.Add(currentYearReceiptCounter);
            }
            else
            {
                currentReceiptCount = currentReceiptCount + currentYearReceiptCounter.ReceiptCount;
                currentYearReceiptCounter.ReceiptCount = currentReceiptCount;
            }

            foreach (var offering in firstTimePrintOfferings)
            {
                var dateTimeNow = DateTime.Now;
                offering.ReceiptDate = dateTimeNow;
                offering.ReceiptId = currentReceiptCount;
                string receiptNumber = string.Format("{0}-{1}", offeringYear.ToString(),
                        currentReceiptCount.ToString().PadLeft(6, '0'));

                offering.ReceiptIssuedDate = dateTimeNow;
                currentYearReceiptCounter.ReceiptCount = currentReceiptCount;
                currentReceiptCount++;
            }

            dbContext.SaveChanges();
        }
    }
}
