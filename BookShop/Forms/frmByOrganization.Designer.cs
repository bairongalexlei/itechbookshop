namespace BookShop.Forms
{
    partial class frmByOrganization
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
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptByOrganizationViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // rptByOrganizationViewer
            // 
            this.rptByOrganizationViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptByOrganizationReport.rdlc";
            this.rptByOrganizationViewer.Location = new System.Drawing.Point(12, 12);
            this.rptByOrganizationViewer.Name = "rptByOrganizationViewer";
            this.rptByOrganizationViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rptByOrganizationViewer.ShowExportButton = false;
            this.rptByOrganizationViewer.Size = new System.Drawing.Size(831, 685);
            this.rptByOrganizationViewer.TabIndex = 0;
            // 
            // frmByOrganization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 709);
            this.Controls.Add(this.rptByOrganizationViewer);
            this.MaximizeBox = false;
            this.Name = "frmByOrganization";
            this.Text = "By Organization";
            this.Load += new System.EventHandler(this.frmByOrganization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptByOrganizationViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}