namespace BookShop.Forms
{
    partial class frmReceiptSummary
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
            this.rptReceiptSummaryViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptReceiptSummaryViewer
            // 
            this.rptReceiptSummaryViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptReceiptSummary.rdlc";
            this.rptReceiptSummaryViewer.Location = new System.Drawing.Point(12, 12);
            this.rptReceiptSummaryViewer.Name = "rptReceiptSummaryViewer";
            this.rptReceiptSummaryViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rptReceiptSummaryViewer.Size = new System.Drawing.Size(756, 474);
            this.rptReceiptSummaryViewer.TabIndex = 0;
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // frmReceiptSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.rptReceiptSummaryViewer);
            this.Name = "frmReceiptSummary";
            this.Text = "Receipt Summary";
            this.Load += new System.EventHandler(this.fromReceiptSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptReceiptSummaryViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}