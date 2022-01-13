
namespace RentalSystemDB
{
    partial class FormContractGrid
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btn_viewTenants = new System.Windows.Forms.Button();
            this.btn_viewUnits = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.btn_newContract = new System.Windows.Forms.Button();
            this.btn_editContract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(650, 230);
            this.dataGridView1.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(377, 33);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(285, 20);
            this.searchBox.TabIndex = 1;
            // 
            // btn_viewTenants
            // 
            this.btn_viewTenants.Location = new System.Drawing.Point(6, 19);
            this.btn_viewTenants.Name = "btn_viewTenants";
            this.btn_viewTenants.Size = new System.Drawing.Size(98, 23);
            this.btn_viewTenants.TabIndex = 2;
            this.btn_viewTenants.Text = "Tenant Data Grid";
            this.btn_viewTenants.UseVisualStyleBackColor = true;
            this.btn_viewTenants.Click += new System.EventHandler(this.btn_viewTenants_Click);
            // 
            // btn_viewUnits
            // 
            this.btn_viewUnits.Location = new System.Drawing.Point(6, 48);
            this.btn_viewUnits.Name = "btn_viewUnits";
            this.btn_viewUnits.Size = new System.Drawing.Size(98, 23);
            this.btn_viewUnits.TabIndex = 3;
            this.btn_viewUnits.Text = "Unit Data Grid";
            this.btn_viewUnits.UseVisualStyleBackColor = true;
            this.btn_viewUnits.Click += new System.EventHandler(this.btn_viewUnits_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_viewTenants);
            this.groupBox1.Controls.Add(this.btn_viewUnits);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Tables";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(296, 31);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 5;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_Search
            // 
            this.lbl_Search.AutoSize = true;
            this.lbl_Search.Location = new System.Drawing.Point(374, 60);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(84, 13);
            this.lbl_Search.TabIndex = 6;
            this.lbl_Search.Text = "Search by name";
            // 
            // btn_newContract
            // 
            this.btn_newContract.Location = new System.Drawing.Point(160, 31);
            this.btn_newContract.Name = "btn_newContract";
            this.btn_newContract.Size = new System.Drawing.Size(86, 23);
            this.btn_newContract.TabIndex = 7;
            this.btn_newContract.Text = "New Contract";
            this.btn_newContract.UseVisualStyleBackColor = true;
            this.btn_newContract.Click += new System.EventHandler(this.btn_newContract_Click);
            // 
            // btn_editContract
            // 
            this.btn_editContract.Location = new System.Drawing.Point(160, 58);
            this.btn_editContract.Name = "btn_editContract";
            this.btn_editContract.Size = new System.Drawing.Size(86, 23);
            this.btn_editContract.TabIndex = 8;
            this.btn_editContract.Text = "Edit Contract";
            this.btn_editContract.UseVisualStyleBackColor = true;
            this.btn_editContract.Click += new System.EventHandler(this.btn_editContract_Click);
            // 
            // FormContractGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(674, 340);
            this.Controls.Add(this.btn_editContract);
            this.Controls.Add(this.btn_newContract);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormContractGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contracs";
            this.Load += new System.EventHandler(this.FormContractGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button btn_viewTenants;
        private System.Windows.Forms.Button btn_viewUnits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_Search;
        private System.Windows.Forms.Button btn_newContract;
        private System.Windows.Forms.Button btn_editContract;
    }
}

