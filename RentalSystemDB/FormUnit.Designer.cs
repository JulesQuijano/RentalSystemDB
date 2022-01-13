
namespace RentalSystemDB
{
    partial class FormUnit
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
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_area = new System.Windows.Forms.Label();
            this.lbl_rentalFee = new System.Windows.Forms.Label();
            this.lbl_tenantLimit = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.txt_area = new System.Windows.Forms.TextBox();
            this.txt_rentalFee = new System.Windows.Forms.TextBox();
            this.txt_tenantLimit = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_unitStatus = new System.Windows.Forms.Label();
            this.txt_unitStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(24, 9);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(31, 13);
            this.lbl_type.TabIndex = 0;
            this.lbl_type.Text = "Type";
            // 
            // lbl_area
            // 
            this.lbl_area.AutoSize = true;
            this.lbl_area.Location = new System.Drawing.Point(24, 60);
            this.lbl_area.Name = "lbl_area";
            this.lbl_area.Size = new System.Drawing.Size(64, 13);
            this.lbl_area.TabIndex = 1;
            this.lbl_area.Text = "Area (Sq/m)";
            // 
            // lbl_rentalFee
            // 
            this.lbl_rentalFee.AutoSize = true;
            this.lbl_rentalFee.Location = new System.Drawing.Point(24, 109);
            this.lbl_rentalFee.Name = "lbl_rentalFee";
            this.lbl_rentalFee.Size = new System.Drawing.Size(59, 13);
            this.lbl_rentalFee.TabIndex = 2;
            this.lbl_rentalFee.Text = "Rental Fee";
            // 
            // lbl_tenantLimit
            // 
            this.lbl_tenantLimit.AutoSize = true;
            this.lbl_tenantLimit.Location = new System.Drawing.Point(24, 158);
            this.lbl_tenantLimit.Name = "lbl_tenantLimit";
            this.lbl_tenantLimit.Size = new System.Drawing.Size(65, 13);
            this.lbl_tenantLimit.TabIndex = 3;
            this.lbl_tenantLimit.Text = "Tenant Limit";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "Bungalow",
            "Condo",
            "Duplex",
            "Single Detached",
            "Town House"});
            this.cb_type.Location = new System.Drawing.Point(27, 25);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(152, 21);
            this.cb_type.TabIndex = 5;
            // 
            // txt_area
            // 
            this.txt_area.Location = new System.Drawing.Point(27, 76);
            this.txt_area.Name = "txt_area";
            this.txt_area.Size = new System.Drawing.Size(152, 20);
            this.txt_area.TabIndex = 6;
            this.txt_area.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_area_KeyDown);
            this.txt_area.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_area_KeyPress);
            // 
            // txt_rentalFee
            // 
            this.txt_rentalFee.Location = new System.Drawing.Point(27, 126);
            this.txt_rentalFee.Name = "txt_rentalFee";
            this.txt_rentalFee.Size = new System.Drawing.Size(152, 20);
            this.txt_rentalFee.TabIndex = 7;
            this.txt_rentalFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_rentalFee_KeyDown);
            this.txt_rentalFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rentalFee_KeyPress);
            // 
            // txt_tenantLimit
            // 
            this.txt_tenantLimit.Location = new System.Drawing.Point(27, 174);
            this.txt_tenantLimit.Name = "txt_tenantLimit";
            this.txt_tenantLimit.Size = new System.Drawing.Size(152, 20);
            this.txt_tenantLimit.TabIndex = 8;
            this.txt_tenantLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_tenantLimit_KeyDown);
            this.txt_tenantLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_tenantLimit_KeyPress);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(68, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_unitStatus
            // 
            this.lbl_unitStatus.AutoSize = true;
            this.lbl_unitStatus.Location = new System.Drawing.Point(24, 206);
            this.lbl_unitStatus.Name = "lbl_unitStatus";
            this.lbl_unitStatus.Size = new System.Drawing.Size(59, 13);
            this.lbl_unitStatus.TabIndex = 4;
            this.lbl_unitStatus.Text = "Unit Status";
            // 
            // txt_unitStatus
            // 
            this.txt_unitStatus.Location = new System.Drawing.Point(27, 222);
            this.txt_unitStatus.Name = "txt_unitStatus";
            this.txt_unitStatus.ReadOnly = true;
            this.txt_unitStatus.Size = new System.Drawing.Size(152, 20);
            this.txt_unitStatus.TabIndex = 12;
            // 
            // FormUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 298);
            this.Controls.Add(this.txt_unitStatus);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_tenantLimit);
            this.Controls.Add(this.txt_rentalFee);
            this.Controls.Add(this.txt_area);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lbl_unitStatus);
            this.Controls.Add(this.lbl_tenantLimit);
            this.Controls.Add(this.lbl_rentalFee);
            this.Controls.Add(this.lbl_area);
            this.Controls.Add(this.lbl_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FormUnit_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_area;
        private System.Windows.Forms.Label lbl_rentalFee;
        private System.Windows.Forms.Label lbl_tenantLimit;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.TextBox txt_area;
        private System.Windows.Forms.TextBox txt_rentalFee;
        private System.Windows.Forms.TextBox txt_tenantLimit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_unitStatus;
        private System.Windows.Forms.TextBox txt_unitStatus;
    }
}