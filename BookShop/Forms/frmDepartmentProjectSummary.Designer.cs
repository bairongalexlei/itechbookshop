namespace BookShop.Forms
{
    partial class frmDepartmentProjectSummary
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
            this.rptDepartmentProjectSummaryViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptDepartmentProjectSummaryViewer
            // 
            this.rptDepartmentProjectSummaryViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptDepartmentProjectSummary.rdlc";
            this.rptDepartmentProjectSummaryViewer.Location = new System.Drawing.Point(12, 12);
            this.rptDepartmentProjectSummaryViewer.Name = "rptDepartmentProjectSummaryViewer";
            this.rptDepartmentProjectSummaryViewer.ShowExportButton = false;
            this.rptDepartmentProjectSummaryViewer.Size = new System.Drawing.Size(756, 474);
            this.rptDepartmentProjectSummaryViewer.TabIndex = 0;
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // frmDepartmentProjectSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.rptDepartmentProjectSummaryViewer);
            this.Name = "frmDepartmentProjectSummary";
            this.Text = "Department Project Summary";
            this.Load += new System.EventHandler(this.frmDepartmentProjectSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptDepartmentProjectSummaryViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}