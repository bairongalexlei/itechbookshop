namespace BookShop.Forms
{
    partial class frmNontaxableReceipt
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
            this.rptNontaxableReceiptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptNontaxableReceiptViewer
            // 
            this.rptNontaxableReceiptViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptNontaxableReceipt.rdlc";
            this.rptNontaxableReceiptViewer.Location = new System.Drawing.Point(13, 12);
            this.rptNontaxableReceiptViewer.Name = "rptNontaxableReceiptViewer";
            this.rptNontaxableReceiptViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rptNontaxableReceiptViewer.ShowExportButton = false;
            this.rptNontaxableReceiptViewer.Size = new System.Drawing.Size(756, 474);
            this.rptNontaxableReceiptViewer.TabIndex = 0;
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // frmNontaxableReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.rptNontaxableReceiptViewer);
            this.MaximizeBox = false;
            this.Name = "frmNontaxableReceipt";
            this.Text = "Non-taxable Receipt";
            this.Load += new System.EventHandler(this.frmNontaxableReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptNontaxableReceiptViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}