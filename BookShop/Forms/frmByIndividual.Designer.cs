namespace BookShop.Forms
{
    partial class frmByIndividual
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
            this.rptByIndividualViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OfferingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptByIndividualViewer
            // 
            this.rptByIndividualViewer.LocalReport.ReportEmbeddedResource = "BookShop.Forms.rptByIndividualReport.rdlc";
            this.rptByIndividualViewer.Location = new System.Drawing.Point(12, 12);
            this.rptByIndividualViewer.Name = "rptByIndividualViewer";
            this.rptByIndividualViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rptByIndividualViewer.Size = new System.Drawing.Size(831, 685);
            this.rptByIndividualViewer.TabIndex = 0;
            // 
            // OfferingBindingSource
            // 
            this.OfferingBindingSource.DataSource = typeof(BookShop.EFData.Offering);
            // 
            // frmByIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 709);
            this.Controls.Add(this.rptByIndividualViewer);
            this.MaximizeBox = false;
            this.Name = "frmByIndividual";
            this.Text = "By Individual";
            this.Load += new System.EventHandler(this.frmByIndividual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OfferingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptByIndividualViewer;
        private System.Windows.Forms.BindingSource OfferingBindingSource;
    }
}