namespace BookShop.Forms
{
    partial class frmPaymentSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptPaymentSummaryViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptPaymentSummaryViewer
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OfferingBindingSource;
            this.rptPaymentSummaryViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rptPaymentSummaryViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptPaymentMethodSummary.rdlc";
            this.rptPaymentSummaryViewer.Location = new System.Drawing.Point(12, 9);
            this.rptPaymentSummaryViewer.Name = "rptPaymentSummaryViewer";
            this.rptPaymentSummaryViewer.Size = new System.Drawing.Size(756, 474);
            this.rptPaymentSummaryViewer.TabIndex = 0;
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // frmPaymentSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.rptPaymentSummaryViewer);
            this.Name = "frmPaymentSummary";
            this.Text = "Payment Summary";
            this.Load += new System.EventHandler(this.frmPaymentSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptPaymentSummaryViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;

    }
}