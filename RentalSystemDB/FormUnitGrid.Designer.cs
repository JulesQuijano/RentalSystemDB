
namespace RentalSystemDB
{
    partial class FormUnitGrid
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
            this.btn_newUnit = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_editUnit = new System.Windows.Forms.Button();
            this.btn_expireUnit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_newUnit
            // 
            this.btn_newUnit.Location = new System.Drawing.Point(40, 12);
            this.btn_newUnit.Name = "btn_newUnit";
            this.btn_newUnit.Size = new System.Drawing.Size(75, 23);
            this.btn_newUnit.TabIndex = 0;
            this.btn_newUnit.Text = "New Unit";
            this.btn_newUnit.UseVisualStyleBackColor = true;
            this.btn_newUnit.Click += new System.EventHandler(this.btn_newUnit_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(40, 48);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(121, 50);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(262, 20);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(553, 228);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btn_editUnit
            // 
            this.btn_editUnit.Location = new System.Drawing.Point(121, 12);
            this.btn_editUnit.Name = "btn_editUnit";
            this.btn_editUnit.Size = new System.Drawing.Size(75, 23);
            this.btn_editUnit.TabIndex = 4;
            this.btn_editUnit.Text = "Edit Unit";
            this.btn_editUnit.UseVisualStyleBackColor = true;
            this.btn_editUnit.Click += new System.EventHandler(this.btn_editUnit_Click);
            // 
            // btn_expireUnit
            // 
            this.btn_expireUnit.Location = new System.Drawing.Point(202, 12);
            this.btn_expireUnit.Name = "btn_expireUnit";
            this.btn_expireUnit.Size = new System.Drawing.Size(75, 23);
            this.btn_expireUnit.TabIndex = 5;
            this.btn_expireUnit.Text = "Expire Unit";
            this.btn_expireUnit.UseVisualStyleBackColor = true;
            this.btn_expireUnit.Click += new System.EventHandler(this.btn_expireUnit_Click);
            // 
            // FormUnitGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 340);
            this.Controls.Add(this.btn_expireUnit);
            this.Controls.Add(this.btn_editUnit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_newUnit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormUnitGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Units";
            this.Load += new System.EventHandler(this.FormUnitGrid_Load);
            this.Shown += new System.EventHandler(this.FormUnitGrid_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_newUnit;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_editUnit;
        private System.Windows.Forms.Button btn_expireUnit;
    }
}