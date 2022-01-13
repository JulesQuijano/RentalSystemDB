
namespace RentalSystemDB
{
    partial class FormContractNew
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
            this.lbl_unit = new System.Windows.Forms.Label();
            this.cb_unit = new System.Windows.Forms.ComboBox();
            this.lbl_tenant = new System.Windows.Forms.Label();
            this.cb_tenant = new System.Windows.Forms.ComboBox();
            this.lbl_contractStart = new System.Windows.Forms.Label();
            this.btn_newTenant = new System.Windows.Forms.Button();
            this.btn_newUnit = new System.Windows.Forms.Button();
            this.lbl_contractEnd = new System.Windows.Forms.Label();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.rtx_comment = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.dtp_contractStart = new System.Windows.Forms.DateTimePicker();
            this.dtp_contractEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbl_unit
            // 
            this.lbl_unit.AutoSize = true;
            this.lbl_unit.Location = new System.Drawing.Point(322, 9);
            this.lbl_unit.Name = "lbl_unit";
            this.lbl_unit.Size = new System.Drawing.Size(26, 13);
            this.lbl_unit.TabIndex = 0;
            this.lbl_unit.Text = "Unit";
            // 
            // cb_unit
            // 
            this.cb_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_unit.FormattingEnabled = true;
            this.cb_unit.Location = new System.Drawing.Point(325, 25);
            this.cb_unit.Name = "cb_unit";
            this.cb_unit.Size = new System.Drawing.Size(234, 21);
            this.cb_unit.TabIndex = 1;
            // 
            // lbl_tenant
            // 
            this.lbl_tenant.AutoSize = true;
            this.lbl_tenant.Location = new System.Drawing.Point(12, 9);
            this.lbl_tenant.Name = "lbl_tenant";
            this.lbl_tenant.Size = new System.Drawing.Size(41, 13);
            this.lbl_tenant.TabIndex = 2;
            this.lbl_tenant.Text = "Tenant";
            // 
            // cb_tenant
            // 
            this.cb_tenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tenant.FormattingEnabled = true;
            this.cb_tenant.Location = new System.Drawing.Point(15, 26);
            this.cb_tenant.Name = "cb_tenant";
            this.cb_tenant.Size = new System.Drawing.Size(234, 21);
            this.cb_tenant.TabIndex = 3;
            // 
            // lbl_contractStart
            // 
            this.lbl_contractStart.AutoSize = true;
            this.lbl_contractStart.Location = new System.Drawing.Point(12, 105);
            this.lbl_contractStart.Name = "lbl_contractStart";
            this.lbl_contractStart.Size = new System.Drawing.Size(72, 13);
            this.lbl_contractStart.TabIndex = 4;
            this.lbl_contractStart.Text = "Contract Start";
            // 
            // btn_newTenant
            // 
            this.btn_newTenant.Location = new System.Drawing.Point(15, 53);
            this.btn_newTenant.Name = "btn_newTenant";
            this.btn_newTenant.Size = new System.Drawing.Size(75, 23);
            this.btn_newTenant.TabIndex = 6;
            this.btn_newTenant.Text = "New Tenant";
            this.btn_newTenant.UseVisualStyleBackColor = true;
            this.btn_newTenant.Click += new System.EventHandler(this.btn_newTenant_Click);
            // 
            // btn_newUnit
            // 
            this.btn_newUnit.Location = new System.Drawing.Point(325, 53);
            this.btn_newUnit.Name = "btn_newUnit";
            this.btn_newUnit.Size = new System.Drawing.Size(75, 23);
            this.btn_newUnit.TabIndex = 7;
            this.btn_newUnit.Text = "New Unit";
            this.btn_newUnit.UseVisualStyleBackColor = true;
            this.btn_newUnit.Click += new System.EventHandler(this.btn_newUnit_Click);
            // 
            // lbl_contractEnd
            // 
            this.lbl_contractEnd.AutoSize = true;
            this.lbl_contractEnd.Location = new System.Drawing.Point(12, 155);
            this.lbl_contractEnd.Name = "lbl_contractEnd";
            this.lbl_contractEnd.Size = new System.Drawing.Size(69, 13);
            this.lbl_contractEnd.TabIndex = 8;
            this.lbl_contractEnd.Text = "Contract End";
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(322, 105);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(51, 13);
            this.lbl_comment.TabIndex = 10;
            this.lbl_comment.Text = "Comment";
            // 
            // rtx_comment
            // 
            this.rtx_comment.Location = new System.Drawing.Point(325, 121);
            this.rtx_comment.Name = "rtx_comment";
            this.rtx_comment.Size = new System.Drawing.Size(234, 70);
            this.rtx_comment.TabIndex = 11;
            this.rtx_comment.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(245, 236);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dtp_contractStart
            // 
            this.dtp_contractStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_contractStart.Location = new System.Drawing.Point(15, 121);
            this.dtp_contractStart.Name = "dtp_contractStart";
            this.dtp_contractStart.Size = new System.Drawing.Size(102, 20);
            this.dtp_contractStart.TabIndex = 13;
            // 
            // dtp_contractEnd
            // 
            this.dtp_contractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_contractEnd.Location = new System.Drawing.Point(15, 170);
            this.dtp_contractEnd.Name = "dtp_contractEnd";
            this.dtp_contractEnd.Size = new System.Drawing.Size(102, 20);
            this.dtp_contractEnd.TabIndex = 14;
            // 
            // FormContractNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(568, 270);
            this.Controls.Add(this.dtp_contractEnd);
            this.Controls.Add(this.dtp_contractStart);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.rtx_comment);
            this.Controls.Add(this.lbl_comment);
            this.Controls.Add(this.lbl_contractEnd);
            this.Controls.Add(this.btn_newUnit);
            this.Controls.Add(this.btn_newTenant);
            this.Controls.Add(this.lbl_contractStart);
            this.Controls.Add(this.cb_tenant);
            this.Controls.Add(this.lbl_tenant);
            this.Controls.Add(this.cb_unit);
            this.Controls.Add(this.lbl_unit);
            this.MaximizeBox = false;
            this.Name = "FormContractNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Contract";
            this.Load += new System.EventHandler(this.FormNewContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_unit;
        private System.Windows.Forms.ComboBox cb_unit;
        private System.Windows.Forms.Label lbl_tenant;
        private System.Windows.Forms.Label lbl_contractStart;
        private System.Windows.Forms.Button btn_newTenant;
        private System.Windows.Forms.Button btn_newUnit;
        private System.Windows.Forms.Label lbl_contractEnd;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.RichTextBox rtx_comment;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cb_tenant;
        private System.Windows.Forms.DateTimePicker dtp_contractStart;
        private System.Windows.Forms.DateTimePicker dtp_contractEnd;
    }
}