
namespace RentalSystemDB
{
    partial class FormInitPay
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
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_receiptNo = new System.Windows.Forms.Label();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.dtp_initPayment = new System.Windows.Forms.DateTimePicker();
            this.txt_receiptNo = new System.Windows.Forms.TextBox();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.rtx_comment = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(12, 9);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(31, 13);
            this.lbl_type.TabIndex = 0;
            this.lbl_type.Text = "Type";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(12, 66);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(30, 13);
            this.lbl_date.TabIndex = 1;
            this.lbl_date.Text = "Date";
            // 
            // lbl_receiptNo
            // 
            this.lbl_receiptNo.AutoSize = true;
            this.lbl_receiptNo.Location = new System.Drawing.Point(12, 122);
            this.lbl_receiptNo.Name = "lbl_receiptNo";
            this.lbl_receiptNo.Size = new System.Drawing.Size(84, 13);
            this.lbl_receiptNo.TabIndex = 2;
            this.lbl_receiptNo.Text = "Receipt Number";
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Location = new System.Drawing.Point(180, 9);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(43, 13);
            this.lbl_amount.TabIndex = 3;
            this.lbl_amount.Text = "Amount";
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(180, 66);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(51, 13);
            this.lbl_comment.TabIndex = 4;
            this.lbl_comment.Text = "Comment";
            // 
            // txt_type
            // 
            this.txt_type.Location = new System.Drawing.Point(15, 25);
            this.txt_type.Name = "txt_type";
            this.txt_type.ReadOnly = true;
            this.txt_type.Size = new System.Drawing.Size(122, 20);
            this.txt_type.TabIndex = 5;
            this.txt_type.Text = "Initial Payment";
            // 
            // dtp_initPayment
            // 
            this.dtp_initPayment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_initPayment.Location = new System.Drawing.Point(15, 82);
            this.dtp_initPayment.Name = "dtp_initPayment";
            this.dtp_initPayment.Size = new System.Drawing.Size(122, 20);
            this.dtp_initPayment.TabIndex = 6;
            // 
            // txt_receiptNo
            // 
            this.txt_receiptNo.Location = new System.Drawing.Point(15, 138);
            this.txt_receiptNo.Name = "txt_receiptNo";
            this.txt_receiptNo.Size = new System.Drawing.Size(122, 20);
            this.txt_receiptNo.TabIndex = 7;
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(183, 25);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(126, 20);
            this.txt_amount.TabIndex = 8;
            // 
            // rtx_comment
            // 
            this.rtx_comment.Location = new System.Drawing.Point(183, 85);
            this.rtx_comment.Name = "rtx_comment";
            this.rtx_comment.Size = new System.Drawing.Size(126, 73);
            this.rtx_comment.TabIndex = 9;
            this.rtx_comment.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Location = new System.Drawing.Point(127, 197);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormInitPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 232);
            this.ControlBox = false;
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.rtx_comment);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.txt_receiptNo);
            this.Controls.Add(this.dtp_initPayment);
            this.Controls.Add(this.txt_type);
            this.Controls.Add(this.lbl_comment);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_receiptNo);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.lbl_type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormInitPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initial Payment";
            this.Shown += new System.EventHandler(this.FormInitPay_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_receiptNo;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.DateTimePicker dtp_initPayment;
        private System.Windows.Forms.TextBox txt_receiptNo;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.RichTextBox rtx_comment;
        private System.Windows.Forms.Button btn_save;
    }
}