
namespace RentalSystemDB
{
    partial class FormContractView
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
            this.gb_editOtherTables = new System.Windows.Forms.GroupBox();
            this.btn_paymentGrid = new System.Windows.Forms.Button();
            this.btn_editTenant = new System.Windows.Forms.Button();
            this.btn_saveClose = new System.Windows.Forms.Button();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Unit = new System.Windows.Forms.Label();
            this.lbl_contractStart = new System.Windows.Forms.Label();
            this.lbl_contractEnd = new System.Windows.Forms.Label();
            this.rtx_comment = new System.Windows.Forms.RichTextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.cb_unit = new System.Windows.Forms.ComboBox();
            this.dtp_contractStart = new System.Windows.Forms.DateTimePicker();
            this.dtp_contractEnd = new System.Windows.Forms.DateTimePicker();
            this.chk_contractDone = new System.Windows.Forms.CheckBox();
            this.gb_editOtherTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_editOtherTables
            // 
            this.gb_editOtherTables.Controls.Add(this.btn_paymentGrid);
            this.gb_editOtherTables.Controls.Add(this.btn_editTenant);
            this.gb_editOtherTables.Location = new System.Drawing.Point(15, 261);
            this.gb_editOtherTables.Name = "gb_editOtherTables";
            this.gb_editOtherTables.Size = new System.Drawing.Size(192, 52);
            this.gb_editOtherTables.TabIndex = 0;
            this.gb_editOtherTables.TabStop = false;
            this.gb_editOtherTables.Text = "Other Tables";
            // 
            // btn_paymentGrid
            // 
            this.btn_paymentGrid.Location = new System.Drawing.Point(91, 23);
            this.btn_paymentGrid.Name = "btn_paymentGrid";
            this.btn_paymentGrid.Size = new System.Drawing.Size(95, 23);
            this.btn_paymentGrid.TabIndex = 3;
            this.btn_paymentGrid.Text = "Veiw Payments";
            this.btn_paymentGrid.UseVisualStyleBackColor = true;
            this.btn_paymentGrid.Click += new System.EventHandler(this.btn_paymentGrid_Click);
            // 
            // btn_editTenant
            // 
            this.btn_editTenant.Location = new System.Drawing.Point(6, 23);
            this.btn_editTenant.Name = "btn_editTenant";
            this.btn_editTenant.Size = new System.Drawing.Size(79, 23);
            this.btn_editTenant.TabIndex = 1;
            this.btn_editTenant.Text = "Edit Tenant";
            this.btn_editTenant.UseVisualStyleBackColor = true;
            this.btn_editTenant.Click += new System.EventHandler(this.btn_editTenant_Click);
            // 
            // btn_saveClose
            // 
            this.btn_saveClose.Location = new System.Drawing.Point(433, 284);
            this.btn_saveClose.Name = "btn_saveClose";
            this.btn_saveClose.Size = new System.Drawing.Size(75, 23);
            this.btn_saveClose.TabIndex = 1;
            this.btn_saveClose.Text = "Save";
            this.btn_saveClose.UseVisualStyleBackColor = true;
            this.btn_saveClose.Click += new System.EventHandler(this.btn_saveClose_Click);
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(12, 9);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "Name";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(15, 25);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(226, 20);
            this.txt_Name.TabIndex = 3;
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.AutoSize = true;
            this.lbl_Unit.Location = new System.Drawing.Point(12, 67);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(26, 13);
            this.lbl_Unit.TabIndex = 4;
            this.lbl_Unit.Text = "Unit";
            // 
            // lbl_contractStart
            // 
            this.lbl_contractStart.AutoSize = true;
            this.lbl_contractStart.Location = new System.Drawing.Point(15, 131);
            this.lbl_contractStart.Name = "lbl_contractStart";
            this.lbl_contractStart.Size = new System.Drawing.Size(72, 13);
            this.lbl_contractStart.TabIndex = 6;
            this.lbl_contractStart.Text = "Contract Start";
            // 
            // lbl_contractEnd
            // 
            this.lbl_contractEnd.AutoSize = true;
            this.lbl_contractEnd.Location = new System.Drawing.Point(12, 194);
            this.lbl_contractEnd.Name = "lbl_contractEnd";
            this.lbl_contractEnd.Size = new System.Drawing.Size(69, 13);
            this.lbl_contractEnd.TabIndex = 8;
            this.lbl_contractEnd.Text = "Contract End";
            // 
            // rtx_comment
            // 
            this.rtx_comment.Location = new System.Drawing.Point(244, 84);
            this.rtx_comment.Name = "rtx_comment";
            this.rtx_comment.Size = new System.Drawing.Size(264, 146);
            this.rtx_comment.TabIndex = 10;
            this.rtx_comment.Text = "";
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(241, 67);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(51, 13);
            this.lbl_comment.TabIndex = 11;
            this.lbl_comment.Text = "Comment";
            // 
            // cb_unit
            // 
            this.cb_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_unit.FormattingEnabled = true;
            this.cb_unit.Location = new System.Drawing.Point(15, 84);
            this.cb_unit.Name = "cb_unit";
            this.cb_unit.Size = new System.Drawing.Size(157, 21);
            this.cb_unit.TabIndex = 12;
            // 
            // dtp_contractStart
            // 
            this.dtp_contractStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_contractStart.Location = new System.Drawing.Point(15, 147);
            this.dtp_contractStart.Name = "dtp_contractStart";
            this.dtp_contractStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp_contractStart.Size = new System.Drawing.Size(157, 20);
            this.dtp_contractStart.TabIndex = 14;
            // 
            // dtp_contractEnd
            // 
            this.dtp_contractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_contractEnd.Location = new System.Drawing.Point(15, 210);
            this.dtp_contractEnd.Name = "dtp_contractEnd";
            this.dtp_contractEnd.Size = new System.Drawing.Size(157, 20);
            this.dtp_contractEnd.TabIndex = 15;
            // 
            // chk_contractDone
            // 
            this.chk_contractDone.AutoSize = true;
            this.chk_contractDone.Location = new System.Drawing.Point(338, 27);
            this.chk_contractDone.Name = "chk_contractDone";
            this.chk_contractDone.Size = new System.Drawing.Size(95, 17);
            this.chk_contractDone.TabIndex = 16;
            this.chk_contractDone.Text = "Contract Done";
            this.chk_contractDone.UseVisualStyleBackColor = true;
            this.chk_contractDone.Click += new System.EventHandler(this.chk_contractDone_Click);
            // 
            // FormContractView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 323);
            this.Controls.Add(this.chk_contractDone);
            this.Controls.Add(this.dtp_contractEnd);
            this.Controls.Add(this.dtp_contractStart);
            this.Controls.Add(this.cb_unit);
            this.Controls.Add(this.lbl_comment);
            this.Controls.Add(this.rtx_comment);
            this.Controls.Add(this.lbl_contractEnd);
            this.Controls.Add(this.lbl_contractStart);
            this.Controls.Add(this.lbl_Unit);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.btn_saveClose);
            this.Controls.Add(this.gb_editOtherTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormContractView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Contract";
            this.Shown += new System.EventHandler(this.FormContractView_Shown);
            this.gb_editOtherTables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_editOtherTables;
        private System.Windows.Forms.Button btn_paymentGrid;
        private System.Windows.Forms.Button btn_editTenant;
        private System.Windows.Forms.Button btn_saveClose;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Unit;
        private System.Windows.Forms.Label lbl_contractStart;
        private System.Windows.Forms.Label lbl_contractEnd;
        private System.Windows.Forms.RichTextBox rtx_comment;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.ComboBox cb_unit;
        private System.Windows.Forms.DateTimePicker dtp_contractStart;
        private System.Windows.Forms.DateTimePicker dtp_contractEnd;
        private System.Windows.Forms.CheckBox chk_contractDone;
    }
}