﻿namespace BookShop
{
    partial class frmMain
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
            this.tabBookShop = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbAccountId = new System.Windows.Forms.ComboBox();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cmbOrganization = new System.Windows.Forms.ComboBox();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbFirstName = new System.Windows.Forms.ComboBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.cmbLastName = new System.Windows.Forms.ComboBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.tabBookShop.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBookShop
            // 
            this.tabBookShop.Controls.Add(this.tabPage1);
            this.tabBookShop.Controls.Add(this.tabPage2);
            this.tabBookShop.Controls.Add(this.tabPage3);
            this.tabBookShop.Controls.Add(this.tabPage4);
            this.tabBookShop.Location = new System.Drawing.Point(12, 32);
            this.tabBookShop.Name = "tabBookShop";
            this.tabBookShop.SelectedIndex = 0;
            this.tabBookShop.Size = new System.Drawing.Size(824, 291);
            this.tabBookShop.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPostalCode);
            this.tabPage1.Controls.Add(this.lblPostalCode);
            this.tabPage1.Controls.Add(this.cmbCountry);
            this.tabPage1.Controls.Add(this.lblCountry);
            this.tabPage1.Controls.Add(this.cmbProvince);
            this.tabPage1.Controls.Add(this.lblProvince);
            this.tabPage1.Controls.Add(this.txtCity);
            this.tabPage1.Controls.Add(this.lblCity);
            this.tabPage1.Controls.Add(this.txtStreet);
            this.tabPage1.Controls.Add(this.lblStreet);
            this.tabPage1.Controls.Add(this.txtUnit);
            this.tabPage1.Controls.Add(this.lblUnit);
            this.tabPage1.Controls.Add(this.cmbLanguage);
            this.tabPage1.Controls.Add(this.lblLanguage);
            this.tabPage1.Controls.Add(this.cmbFirstName);
            this.tabPage1.Controls.Add(this.lblFirstName);
            this.tabPage1.Controls.Add(this.cmbLastName);
            this.tabPage1.Controls.Add(this.lblLastName);
            this.tabPage1.Controls.Add(this.cmbOrganization);
            this.tabPage1.Controls.Add(this.lblOrganization);
            this.tabPage1.Controls.Add(this.cmbAccountType);
            this.tabPage1.Controls.Add(this.lblAccountType);
            this.tabPage1.Controls.Add(this.cmbAccountId);
            this.tabPage1.Controls.Add(this.lblAccountId);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabAccounts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbAccountId
            // 
            this.cmbAccountId.FormattingEnabled = true;
            this.cmbAccountId.Location = new System.Drawing.Point(105, 21);
            this.cmbAccountId.Name = "cmbAccountId";
            this.cmbAccountId.Size = new System.Drawing.Size(121, 21);
            this.cmbAccountId.TabIndex = 1;
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Location = new System.Drawing.Point(38, 24);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(62, 13);
            this.lblAccountId.TabIndex = 0;
            this.lblAccountId.Text = "Account Id:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabOfferings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(816, 265);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabUser";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(816, 265);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabSummary";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(361, 21);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(121, 21);
            this.cmbAccountType.TabIndex = 3;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(279, 24);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(77, 13);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "Account Type:";
            // 
            // cmbOrganization
            // 
            this.cmbOrganization.FormattingEnabled = true;
            this.cmbOrganization.Location = new System.Drawing.Point(646, 21);
            this.cmbOrganization.Name = "cmbOrganization";
            this.cmbOrganization.Size = new System.Drawing.Size(121, 21);
            this.cmbOrganization.TabIndex = 5;
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(564, 24);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(69, 13);
            this.lblOrganization.TabIndex = 4;
            this.lblOrganization.Text = "Organization:";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(647, 51);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 11;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(575, 54);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 10;
            this.lblLanguage.Text = "Language:";
            // 
            // cmbFirstName
            // 
            this.cmbFirstName.FormattingEnabled = true;
            this.cmbFirstName.Location = new System.Drawing.Point(362, 51);
            this.cmbFirstName.Name = "cmbFirstName";
            this.cmbFirstName.Size = new System.Drawing.Size(121, 21);
            this.cmbFirstName.TabIndex = 9;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(296, 54);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
            // 
            // cmbLastName
            // 
            this.cmbLastName.FormattingEnabled = true;
            this.cmbLastName.Location = new System.Drawing.Point(106, 51);
            this.cmbLastName.Name = "cmbLastName";
            this.cmbLastName.Size = new System.Drawing.Size(121, 21);
            this.cmbLastName.TabIndex = 7;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(39, 54);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(21, 84);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(79, 13);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "Apt/Unit/Suite:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(106, 81);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(120, 20);
            this.txtUnit.TabIndex = 13;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(363, 81);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(120, 20);
            this.txtStreet.TabIndex = 15;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(318, 84);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 14;
            this.lblStreet.Text = "Street:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(648, 81);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(120, 20);
            this.txtCity.TabIndex = 17;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(606, 84);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 16;
            this.lblCity.Text = "City:";
            // 
            // cmbProvince
            // 
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Location = new System.Drawing.Point(106, 109);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(121, 21);
            this.cmbProvince.TabIndex = 19;
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(48, 112);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(52, 13);
            this.lblProvince.TabIndex = 18;
            this.lblProvince.Text = "Province:";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(363, 109);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(121, 21);
            this.cmbCountry.TabIndex = 21;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(305, 112);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 20;
            this.lblCountry.Text = "Country:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(648, 110);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(120, 20);
            this.txtPostalCode.TabIndex = 23;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(566, 112);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(67, 13);
            this.lblPostalCode.TabIndex = 22;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 334);
            this.Controls.Add(this.tabBookShop);
            this.Name = "frmMain";
            this.Text = "Bookshop Manager";
            this.tabBookShop.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBookShop;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.ComboBox cmbAccountId;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.ComboBox cmbOrganization;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.ComboBox cmbLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
    }
}

