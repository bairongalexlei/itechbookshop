namespace BookShop.Forms
{
    partial class frmOffering
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
            this.lblOffering = new System.Windows.Forms.Label();
            this.txtOfferingId = new System.Windows.Forms.TextBox();
            this.lblDateReceiptIssued = new System.Windows.Forms.Label();
            this.txtReceiptNumber = new System.Windows.Forms.TextBox();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtOfferYear = new System.Windows.Forms.TextBox();
            this.lblOfferYear = new System.Windows.Forms.Label();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtOrganization = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbOfferingMethod = new System.Windows.Forms.ComboBox();
            this.lblOfferingMethod = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbOfferingReceiptType = new System.Windows.Forms.ComboBox();
            this.lblOfferingReceiptType = new System.Windows.Forms.Label();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.lblOthers = new System.Windows.Forms.Label();
            this.dataGridViewOfferLines = new System.Windows.Forms.DataGridView();
            this.ProjectDepartment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OfferSubAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfferingLineItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.maskedTxtReceivedDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTxtDateReceiptIssued = new System.Windows.Forms.MaskedTextBox();
            this.lblReceivedDateLessThan = new System.Windows.Forms.Label();
            this.txtBoxAccountId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOfferLines)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOffering
            // 
            this.lblOffering.AutoSize = true;
            this.lblOffering.Location = new System.Drawing.Point(53, 18);
            this.lblOffering.Name = "lblOffering";
            this.lblOffering.Size = new System.Drawing.Size(61, 13);
            this.lblOffering.TabIndex = 0;
            this.lblOffering.Text = "Offering ID:";
            // 
            // txtOfferingId
            // 
            this.txtOfferingId.Enabled = false;
            this.txtOfferingId.Location = new System.Drawing.Point(120, 15);
            this.txtOfferingId.Name = "txtOfferingId";
            this.txtOfferingId.Size = new System.Drawing.Size(100, 20);
            this.txtOfferingId.TabIndex = 1;
            // 
            // lblDateReceiptIssued
            // 
            this.lblDateReceiptIssued.AutoSize = true;
            this.lblDateReceiptIssued.Location = new System.Drawing.Point(304, 18);
            this.lblDateReceiptIssued.Name = "lblDateReceiptIssued";
            this.lblDateReceiptIssued.Size = new System.Drawing.Size(107, 13);
            this.lblDateReceiptIssued.TabIndex = 2;
            this.lblDateReceiptIssued.Text = "Date Receipt Issued:";
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Enabled = false;
            this.txtReceiptNumber.Location = new System.Drawing.Point(639, 15);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Size = new System.Drawing.Size(100, 20);
            this.txtReceiptNumber.TabIndex = 5;
            // 
            // lblReceiptNumber
            // 
            this.lblReceiptNumber.AutoSize = true;
            this.lblReceiptNumber.Location = new System.Drawing.Point(576, 18);
            this.lblReceiptNumber.Name = "lblReceiptNumber";
            this.lblReceiptNumber.Size = new System.Drawing.Size(57, 13);
            this.lblReceiptNumber.TabIndex = 4;
            this.lblReceiptNumber.Text = "Receipt #:";
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Location = new System.Drawing.Point(50, 44);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(64, 13);
            this.lblAccountId.TabIndex = 10;
            this.lblAccountId.Text = "Account ID:";
            // 
            // txtOfferYear
            // 
            this.txtOfferYear.Enabled = false;
            this.txtOfferYear.Location = new System.Drawing.Point(639, 41);
            this.txtOfferYear.Name = "txtOfferYear";
            this.txtOfferYear.Size = new System.Drawing.Size(100, 20);
            this.txtOfferYear.TabIndex = 15;
            // 
            // lblOfferYear
            // 
            this.lblOfferYear.AutoSize = true;
            this.lblOfferYear.Location = new System.Drawing.Point(575, 44);
            this.lblOfferYear.Name = "lblOfferYear";
            this.lblOfferYear.Size = new System.Drawing.Size(58, 13);
            this.lblOfferYear.TabIndex = 14;
            this.lblOfferYear.Text = "Offer Year:";
            // 
            // lblReceivedDate
            // 
            this.lblReceivedDate.AutoSize = true;
            this.lblReceivedDate.Location = new System.Drawing.Point(329, 44);
            this.lblReceivedDate.Name = "lblReceivedDate";
            this.lblReceivedDate.Size = new System.Drawing.Size(82, 13);
            this.lblReceivedDate.TabIndex = 12;
            this.lblReceivedDate.Text = "Received Date:";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(37, 70);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(77, 13);
            this.lblAccountType.TabIndex = 56;
            this.lblAccountType.Text = "Account Type:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Location = new System.Drawing.Point(226, 93);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 80;
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Location = new System.Drawing.Point(120, 93);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 79;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(53, 96);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 78;
            this.lblFullName.Text = "Full Name:";
            // 
            // txtOrganization
            // 
            this.txtOrganization.Enabled = false;
            this.txtOrganization.Location = new System.Drawing.Point(120, 147);
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Size = new System.Drawing.Size(206, 20);
            this.txtOrganization.TabIndex = 84;
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(120, 119);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 83;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(84, 122);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 82;
            this.lblTitle.Text = "Title:";
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(45, 150);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(69, 13);
            this.lblOrganization.TabIndex = 81;
            this.lblOrganization.Text = "Organization:";
            // 
            // txtCountry
            // 
            this.txtCountry.Enabled = false;
            this.txtCountry.Location = new System.Drawing.Point(417, 144);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 20);
            this.txtCountry.TabIndex = 96;
            // 
            // txtProvince
            // 
            this.txtProvince.Enabled = false;
            this.txtProvince.Location = new System.Drawing.Point(639, 116);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(99, 20);
            this.txtProvince.TabIndex = 95;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Enabled = false;
            this.txtPostalCode.Location = new System.Drawing.Point(639, 144);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(99, 20);
            this.txtPostalCode.TabIndex = 94;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(566, 147);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(67, 13);
            this.lblPostalCode.TabIndex = 93;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(365, 147);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 92;
            this.lblCountry.Text = "Country:";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(581, 119);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(52, 13);
            this.lblProvince.TabIndex = 91;
            this.lblProvince.Text = "Province:";
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(417, 116);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 90;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(384, 119);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 89;
            this.lblCity.Text = "City:";
            // 
            // txtStreet
            // 
            this.txtStreet.Enabled = false;
            this.txtStreet.Location = new System.Drawing.Point(640, 90);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(99, 20);
            this.txtStreet.TabIndex = 88;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(595, 93);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 87;
            this.lblStreet.Text = "Street:";
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(417, 90);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 86;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(332, 93);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(79, 13);
            this.lblUnit.TabIndex = 85;
            this.lblUnit.Text = "Apt/Unit/Suite:";
            // 
            // cmbOfferingMethod
            // 
            this.cmbOfferingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfferingMethod.FormattingEnabled = true;
            this.cmbOfferingMethod.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Others",
            "Master Card",
            "Visa"});
            this.cmbOfferingMethod.Location = new System.Drawing.Point(119, 174);
            this.cmbOfferingMethod.Name = "cmbOfferingMethod";
            this.cmbOfferingMethod.Size = new System.Drawing.Size(101, 21);
            this.cmbOfferingMethod.TabIndex = 101;
            // 
            // lblOfferingMethod
            // 
            this.lblOfferingMethod.AutoSize = true;
            this.lblOfferingMethod.Location = new System.Drawing.Point(68, 177);
            this.lblOfferingMethod.Name = "lblOfferingMethod";
            this.lblOfferingMethod.Size = new System.Drawing.Size(46, 13);
            this.lblOfferingMethod.TabIndex = 100;
            this.lblOfferingMethod.Text = "Method:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(365, 177);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 102;
            this.lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(417, 174);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 103;
            // 
            // cmbOfferingReceiptType
            // 
            this.cmbOfferingReceiptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfferingReceiptType.FormattingEnabled = true;
            this.cmbOfferingReceiptType.Items.AddRange(new object[] {
            "Personal",
            "Organization",
            "Other"});
            this.cmbOfferingReceiptType.Location = new System.Drawing.Point(640, 174);
            this.cmbOfferingReceiptType.Name = "cmbOfferingReceiptType";
            this.cmbOfferingReceiptType.Size = new System.Drawing.Size(99, 21);
            this.cmbOfferingReceiptType.TabIndex = 105;
            // 
            // lblOfferingReceiptType
            // 
            this.lblOfferingReceiptType.AutoSize = true;
            this.lblOfferingReceiptType.Location = new System.Drawing.Point(559, 177);
            this.lblOfferingReceiptType.Name = "lblOfferingReceiptType";
            this.lblOfferingReceiptType.Size = new System.Drawing.Size(74, 13);
            this.lblOfferingReceiptType.TabIndex = 104;
            this.lblOfferingReceiptType.Text = "Receipt Type:";
            // 
            // txtOthers
            // 
            this.txtOthers.Location = new System.Drawing.Point(120, 201);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(618, 20);
            this.txtOthers.TabIndex = 107;
            // 
            // lblOthers
            // 
            this.lblOthers.AutoSize = true;
            this.lblOthers.Location = new System.Drawing.Point(73, 204);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(41, 13);
            this.lblOthers.TabIndex = 106;
            this.lblOthers.Text = "Others:";
            // 
            // dataGridViewOfferLines
            // 
            this.dataGridViewOfferLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOfferLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectDepartment,
            this.OfferSubAmount,
            this.OfferingLineItemId});
            this.dataGridViewOfferLines.Location = new System.Drawing.Point(40, 231);
            this.dataGridViewOfferLines.Name = "dataGridViewOfferLines";
            this.dataGridViewOfferLines.Size = new System.Drawing.Size(698, 176);
            this.dataGridViewOfferLines.TabIndex = 108;
            this.dataGridViewOfferLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOfferLines_CellContentClick);
            this.dataGridViewOfferLines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewOfferLines_EditingControlShowing);
            // 
            // ProjectDepartment
            // 
            this.ProjectDepartment.HeaderText = "Project/Department";
            this.ProjectDepartment.Name = "ProjectDepartment";
            this.ProjectDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectDepartment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProjectDepartment.Width = 550;
            // 
            // OfferSubAmount
            // 
            this.OfferSubAmount.HeaderText = "Amount";
            this.OfferSubAmount.Name = "OfferSubAmount";
            // 
            // OfferingLineItemId
            // 
            this.OfferingLineItemId.HeaderText = "Offering Line Item Id";
            this.OfferingLineItemId.Name = "OfferingLineItemId";
            this.OfferingLineItemId.ReadOnly = true;
            this.OfferingLineItemId.Visible = false;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Location = new System.Drawing.Point(639, 413);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotal.TabIndex = 110;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(584, 416);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 109;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(666, 464);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 112;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(579, 464);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 111;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.Location = new System.Drawing.Point(39, 464);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(99, 29);
            this.btnPrintReceipt.TabIndex = 113;
            this.btnPrintReceipt.Text = "Generate Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = true;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // txtAccountType
            // 
            this.txtAccountType.Enabled = false;
            this.txtAccountType.Location = new System.Drawing.Point(120, 67);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(100, 20);
            this.txtAccountType.TabIndex = 115;
            // 
            // maskedTxtReceivedDate
            // 
            this.maskedTxtReceivedDate.Location = new System.Drawing.Point(417, 41);
            this.maskedTxtReceivedDate.Mask = "00/00/0000";
            this.maskedTxtReceivedDate.Name = "maskedTxtReceivedDate";
            this.maskedTxtReceivedDate.Size = new System.Drawing.Size(100, 20);
            this.maskedTxtReceivedDate.TabIndex = 116;
            // 
            // maskedTxtDateReceiptIssued
            // 
            this.maskedTxtDateReceiptIssued.Enabled = false;
            this.maskedTxtDateReceiptIssued.Location = new System.Drawing.Point(417, 15);
            this.maskedTxtDateReceiptIssued.Mask = "00/00/0000";
            this.maskedTxtDateReceiptIssued.Name = "maskedTxtDateReceiptIssued";
            this.maskedTxtDateReceiptIssued.Size = new System.Drawing.Size(100, 20);
            this.maskedTxtDateReceiptIssued.TabIndex = 117;
            // 
            // lblReceivedDateLessThan
            // 
            this.lblReceivedDateLessThan.AutoSize = true;
            this.lblReceivedDateLessThan.Location = new System.Drawing.Point(414, 64);
            this.lblReceivedDateLessThan.Name = "lblReceivedDateLessThan";
            this.lblReceivedDateLessThan.Size = new System.Drawing.Size(85, 13);
            this.lblReceivedDateLessThan.TabIndex = 118;
            this.lblReceivedDateLessThan.Text = "(DD/MM/YYYY)";
            // 
            // txtBoxAccountId
            // 
            this.txtBoxAccountId.Location = new System.Drawing.Point(120, 41);
            this.txtBoxAccountId.Name = "txtBoxAccountId";
            this.txtBoxAccountId.Size = new System.Drawing.Size(100, 20);
            this.txtBoxAccountId.TabIndex = 119;
            // 
            // frmOffering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 498);
            this.Controls.Add(this.txtBoxAccountId);
            this.Controls.Add(this.lblReceivedDateLessThan);
            this.Controls.Add(this.maskedTxtDateReceiptIssued);
            this.Controls.Add(this.maskedTxtReceivedDate);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.dataGridViewOfferLines);
            this.Controls.Add(this.txtOthers);
            this.Controls.Add(this.lblOthers);
            this.Controls.Add(this.cmbOfferingReceiptType);
            this.Controls.Add(this.lblOfferingReceiptType);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmbOfferingMethod);
            this.Controls.Add(this.lblOfferingMethod);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtProvince);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.lblPostalCode);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.txtOrganization);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOrganization);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.txtOfferYear);
            this.Controls.Add(this.lblOfferYear);
            this.Controls.Add(this.lblReceivedDate);
            this.Controls.Add(this.lblAccountId);
            this.Controls.Add(this.txtReceiptNumber);
            this.Controls.Add(this.lblReceiptNumber);
            this.Controls.Add(this.lblDateReceiptIssued);
            this.Controls.Add(this.txtOfferingId);
            this.Controls.Add(this.lblOffering);
            this.MaximizeBox = false;
            this.Name = "frmOffering";
            this.Text = "Offering";
            this.Load += new System.EventHandler(this.frmOffering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOfferLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridViewOfferLines_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label lblOffering;
        private System.Windows.Forms.TextBox txtOfferingId;
        private System.Windows.Forms.Label lblDateReceiptIssued;
        private System.Windows.Forms.TextBox txtReceiptNumber;
        private System.Windows.Forms.Label lblReceiptNumber;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtOfferYear;
        private System.Windows.Forms.Label lblOfferYear;
        private System.Windows.Forms.Label lblReceivedDate;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtOrganization;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbOfferingMethod;
        private System.Windows.Forms.Label lblOfferingMethod;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbOfferingReceiptType;
        private System.Windows.Forms.Label lblOfferingReceiptType;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.DataGridView dataGridViewOfferLines;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProjectDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferSubAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferingLineItemId;
        private System.Windows.Forms.MaskedTextBox maskedTxtReceivedDate;
        private System.Windows.Forms.MaskedTextBox maskedTxtDateReceiptIssued;
        private System.Windows.Forms.Label lblReceivedDateLessThan;
        private System.Windows.Forms.TextBox txtBoxAccountId;
    }
}