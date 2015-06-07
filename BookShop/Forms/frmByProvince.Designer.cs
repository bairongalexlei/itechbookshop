namespace BookShop.Forms
{
    partial class frmByProvince
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
            this.rptByProvinceViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // rptByProvinceViewer
            // 
            this.rptByProvinceViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptByProvinceReport.rdlc";
            this.rptByProvinceViewer.Location = new System.Drawing.Point(12, 12);
            this.rptByProvinceViewer.Name = "rptByProvinceViewer";
            this.rptByProvinceViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rptByProvinceViewer.Size = new System.Drawing.Size(831, 685);
            this.rptByProvinceViewer.TabIndex = 0;
            // 
            // frmByProvince
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 709);
            this.Controls.Add(this.rptByProvinceViewer);
            this.MaximizeBox = false;
            this.Name = "frmByProvince";
            this.Text = "By Province";
            this.Load += new System.EventHandler(this.frmByProvince_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptByProvinceViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}