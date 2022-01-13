
namespace RentalSystemDB
{
    partial class FormPaymentGrid
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
            this.btn_newPayment = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_editPayment = new System.Windows.Forms.Button();
            this.btn_deletePayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_newPayment
            // 
            this.btn_newPayment.Location = new System.Drawing.Point(12, 12);
            this.btn_newPayment.Name = "btn_newPayment";
            this.btn_newPayment.Size = new System.Drawing.Size(83, 23);
            this.btn_newPayment.TabIndex = 0;
            this.btn_newPayment.Text = "New Payment";
            this.btn_newPayment.UseVisualStyleBackColor = true;
            this.btn_newPayment.Click += new System.EventHandler(this.btn_newPayment_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(12, 43);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(83, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(101, 45);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(216, 20);
            this.txt_search.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(552, 228);
            this.dataGridView1.TabIndex = 3;
            // 
            // btn_editPayment
            // 
            this.btn_editPayment.Location = new System.Drawing.Point(101, 12);
            this.btn_editPayment.Name = "btn_editPayment";
            this.btn_editPayment.Size = new System.Drawing.Size(83, 23);
            this.btn_editPayment.TabIndex = 4;
            this.btn_editPayment.Text = "Edit Payment";
            this.btn_editPayment.UseVisualStyleBackColor = true;
            this.btn_editPayment.Click += new System.EventHandler(this.btn_editPayment_Click);
            // 
            // btn_deletePayment
            // 
            this.btn_deletePayment.Location = new System.Drawing.Point(190, 12);
            this.btn_deletePayment.Name = "btn_deletePayment";
            this.btn_deletePayment.Size = new System.Drawing.Size(93, 23);
            this.btn_deletePayment.TabIndex = 5;
            this.btn_deletePayment.Text = "Delete Payment";
            this.btn_deletePayment.UseVisualStyleBackColor = true;
            this.btn_deletePayment.Click += new System.EventHandler(this.btn_deletePayment_Click);
            // 
            // FormPaymentGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 324);
            this.Controls.Add(this.btn_deletePayment);
            this.Controls.Add(this.btn_editPayment);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_newPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPaymentGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPaymentGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_newPayment;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_editPayment;
        private System.Windows.Forms.Button btn_deletePayment;
    }
}