
namespace RentalSystemDB
{
    partial class FormPayment
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
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_receiptNo = new System.Windows.Forms.Label();
            this.txt_receiptNo = new System.Windows.Forms.TextBox();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.rbtn_paid = new System.Windows.Forms.RadioButton();
            this.rbtn_unpaid = new System.Windows.Forms.RadioButton();
            this.gb_status = new System.Windows.Forms.GroupBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.rtxt_comment = new System.Windows.Forms.RichTextBox();
            this.dtp_Payment = new System.Windows.Forms.DateTimePicker();
            this.gb_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(12, 18);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(31, 13);
            this.lbl_type.TabIndex = 4;
            this.lbl_type.Text = "Type";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(15, 34);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(137, 21);
            this.cb_type.TabIndex = 5;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(13, 76);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(30, 13);
            this.lbl_date.TabIndex = 8;
            this.lbl_date.Text = "Date";
            // 
            // lbl_receiptNo
            // 
            this.lbl_receiptNo.AutoSize = true;
            this.lbl_receiptNo.Location = new System.Drawing.Point(13, 138);
            this.lbl_receiptNo.Name = "lbl_receiptNo";
            this.lbl_receiptNo.Size = new System.Drawing.Size(84, 13);
            this.lbl_receiptNo.TabIndex = 10;
            this.lbl_receiptNo.Text = "Receipt Number";
            // 
            // txt_receiptNo
            // 
            this.txt_receiptNo.Location = new System.Drawing.Point(16, 154);
            this.txt_receiptNo.Name = "txt_receiptNo";
            this.txt_receiptNo.Size = new System.Drawing.Size(136, 20);
            this.txt_receiptNo.TabIndex = 11;
            this.txt_receiptNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_receiptNo_KeyDown);
            this.txt_receiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_receiptNo_KeyPress);
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Location = new System.Drawing.Point(207, 138);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(43, 13);
            this.lbl_amount.TabIndex = 12;
            this.lbl_amount.Text = "Amount";
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(210, 154);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(100, 20);
            this.txt_amount.TabIndex = 13;
            this.txt_amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_amount_KeyDown);
            this.txt_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_amount_KeyPress);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(238, 274);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // rbtn_paid
            // 
            this.rbtn_paid.AutoSize = true;
            this.rbtn_paid.Location = new System.Drawing.Point(7, 20);
            this.rbtn_paid.Name = "rbtn_paid";
            this.rbtn_paid.Size = new System.Drawing.Size(46, 17);
            this.rbtn_paid.TabIndex = 0;
            this.rbtn_paid.TabStop = true;
            this.rbtn_paid.Text = "Paid";
            this.rbtn_paid.UseVisualStyleBackColor = true;
            // 
            // rbtn_unpaid
            // 
            this.rbtn_unpaid.AutoSize = true;
            this.rbtn_unpaid.Location = new System.Drawing.Point(7, 44);
            this.rbtn_unpaid.Name = "rbtn_unpaid";
            this.rbtn_unpaid.Size = new System.Drawing.Size(59, 17);
            this.rbtn_unpaid.TabIndex = 1;
            this.rbtn_unpaid.TabStop = true;
            this.rbtn_unpaid.Text = "Unpaid";
            this.rbtn_unpaid.UseVisualStyleBackColor = true;
            // 
            // gb_status
            // 
            this.gb_status.Controls.Add(this.rbtn_unpaid);
            this.gb_status.Controls.Add(this.rbtn_paid);
            this.gb_status.Location = new System.Drawing.Point(214, 18);
            this.gb_status.Name = "gb_status";
            this.gb_status.Size = new System.Drawing.Size(99, 71);
            this.gb_status.TabIndex = 3;
            this.gb_status.TabStop = false;
            this.gb_status.Text = "Status";
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(15, 190);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(51, 13);
            this.lbl_comment.TabIndex = 16;
            this.lbl_comment.Text = "Comment";
            // 
            // rtxt_comment
            // 
            this.rtxt_comment.Location = new System.Drawing.Point(15, 207);
            this.rtxt_comment.Name = "rtxt_comment";
            this.rtxt_comment.Size = new System.Drawing.Size(138, 90);
            this.rtxt_comment.TabIndex = 17;
            this.rtxt_comment.Text = "";
            // 
            // dtp_Payment
            // 
            this.dtp_Payment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Payment.Location = new System.Drawing.Point(16, 93);
            this.dtp_Payment.Name = "dtp_Payment";
            this.dtp_Payment.Size = new System.Drawing.Size(136, 20);
            this.dtp_Payment.TabIndex = 18;
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 316);
            this.Controls.Add(this.dtp_Payment);
            this.Controls.Add(this.rtxt_comment);
            this.Controls.Add(this.lbl_comment);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.txt_receiptNo);
            this.Controls.Add(this.lbl_receiptNo);
            this.Controls.Add(this.lbl_date);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.lbl_type);
            this.Controls.Add(this.gb_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FormPayment_Shown);
            this.gb_status.ResumeLayout(false);
            this.gb_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_receiptNo;
        private System.Windows.Forms.TextBox txt_receiptNo;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.RadioButton rbtn_paid;
        private System.Windows.Forms.RadioButton rbtn_unpaid;
        private System.Windows.Forms.GroupBox gb_status;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.RichTextBox rtxt_comment;
        private System.Windows.Forms.DateTimePicker dtp_Payment;
    }
}