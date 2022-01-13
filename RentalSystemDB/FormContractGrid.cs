using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.ComponentModel;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public enum OpType { New, Edit };
    public partial class FormContractGrid : Form
    {
        public FormContractGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets connection settings from AppConfig and instantiates connection
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);

        /// <summary>
        /// Constants
        /// </summary>
        const string FLD_CONTRACT_ID = "ID";

        /// <summary>
        /// Properties
        /// </summary>
        private string m_searchTxt = "";

        /// <summary>
        /// Events
        /// </summary>
        private void FormContractGrid_Load(object sender, EventArgs e)
        {
            ToggleBtn(false);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            m_searchTxt = searchBox.Text;
            FillGrid();
            searchBox.Clear();
        }
        private void btn_viewTenants_Click(object sender, EventArgs e)
        {
            FormTenantGrid tenantGrid = new FormTenantGrid();
            tenantGrid.ShowDialog();
        }
        private void btn_viewUnits_Click(object sender, EventArgs e)
        {
            FormUnitGrid unitGrid = new FormUnitGrid();
            unitGrid.ShowDialog();
        }
        private void btn_newContract_Click(object sender, EventArgs e)
        {
            FormContractNew newContract = new FormContractNew();
            if (newContract.ShowDialog()==DialogResult.OK)
            {
                FillGrid();
            }
                
        }
        private void btn_editContract_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[FLD_CONTRACT_ID].Value.ToString();

            FormContractView contractView = new FormContractView();
            contractView.contractId = s;
            if (contractView.ShowDialog() == DialogResult.OK)
            {
                FillGrid();
            }
        }

        /// <summary>
        /// Function Imlementations
        /// </summary>
        private void FillGrid()
        {
            con.Open();

            #region This query has been replaced by the "Contracts_Get_Data" stored procedure
            /*
            string q = "SELECT ContractId AS ID, CONCAT(t.FirstName, \" \", t.MiddleName, \" \", t.LastName) AS 'Full Name', " +
                "h.UnitType AS 'Unit Type', c.ContractStart AS 'Contract Start', c.ContractEnd AS 'Contract End', c.ContractDone AS 'Contract Done', c.Comment " +
                "FROM contracts AS c INNER JOIN tenants AS t ON c.TenantId = t.TenantId " +
                "Inner JOIN units AS h ON c.UnitId = h.UnitId " +
                "WHERE CONCAT(t.FirstName, \" \", t.MiddleName, \" \", t.LastName) LIKE '%" + m_searchTxt + "%' OR h.UnitType LIKE '%" + m_searchTxt + "%' OR c.ContractStart LIKE '%" + m_searchTxt + "%' OR " +
                "c.ContractEnd LIKE '%" + m_searchTxt + "%' OR c.Comment LIKE '%" + m_searchTxt + "%'; ";
            */
            #endregion 

            // Uses stored procedure with parameters.
            MySqlCommand cmd = new MySqlCommand("Contracts_Search_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_SearchText", m_searchTxt);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            msda.Fill(dt);

            ToggleBtn(dt.Rows.Count > 0);

            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[FLD_CONTRACT_ID], ListSortDirection.Ascending);

            con.Close();
        }
        private void ToggleBtn(Boolean a)
        {
            btn_editContract.Enabled = a;
        }
    }
}
