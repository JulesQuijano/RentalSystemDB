using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormTenantGrid : Form
    {
        public FormTenantGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets connection settings from AppConfid and instantiates connections
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);

        /// <summary>
        /// Properties
        /// </summary>
        DataTable dt = new DataTable();

        /// <summary>
        /// Events
        /// </summary>
        private void FormTenantGrid_Load(object sender, EventArgs e)
        {
            ToggleBtn(false);
        }
        private void FormTenantGrid_Shown(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchData();
        }
        private void btn_editTenant_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            FormTenant editTenant = new FormTenant();
            editTenant.tenantId = s;
            editTenant.Op = OpType.Edit;
            editTenant.ShowDialog();
            FillGrid();
        }

        /// <summary>
        /// Function implimantations
        /// </summary>
        private void FillGrid()
        {
            dt.Clear();
            con.Open();

            #region This query has been replaced with Tenant_Get_Data_G
            /*
            string q = "SELECT TenantId AS ID, CONCAT(FirstName, \" \", MiddleName, \" \", LastName) AS 'Full Name', " +
                "MobileNo AS 'Mobile Number', EmailAddress AS 'Email Address', PermaAddress AS 'Permanent Address', Company, AnnualIncome AS 'Annual Income', " +
                "HouseholdNum AS 'Household Number' FROM tenants; ";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Tenant_Get_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
            msda.Fill(dt);

            ToggleBtn(dt.Rows.Count > 0);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        private void SearchData()
        {
            con.Open();

            string searcnText = txt_search.Text;

            #region This query has been replaced with Tenant_Search_Data_G
            /*
            string q = "SELECT TenantId AS ID, CONCAT(FirstName, \" \", MiddleName, \" \", LastName) AS 'Full Name', " +
                "MobileNo AS 'Mobile Number', EmailAddress AS 'Email Address', PermaAddress AS 'Permanent Address', Company, AnnualIncome AS 'Annual Income', " +
                "HouseholdNum AS 'Household Number' FROM tenants " +
                "WHERE CONCAT(FirstName, \" \", MiddleName, \" \", LastName) LIKE '%" + searcnText + "%'; ";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Tenant_Search_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_SearchText", searcnText);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);

            dt.Clear();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;

            ToggleBtn(dt.Rows.Count > 0);
            txt_search.Clear();

            con.Close();
        }
        private void ToggleBtn(Boolean a)
        {
            btn_editTenant.Enabled = a;
        }
    }
}
