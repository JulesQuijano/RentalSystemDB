using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormUnitGrid : Form
    {
        public FormUnitGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets connection settings from AppConfid and instantiates connections
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);

        /// <summary>
        /// Constants
        /// </summary>
        const string UNIT_VACANT = "vacant";
        const string UNIT_OCCUPIED = "occupied";
        const string UNIT_UNAVAILABLE = "unavailable";

        /// <summary>
        /// Properties
        /// </summary>
        DataTable dt = new DataTable();

        /// <summary>
        /// Events
        /// </summary>
        private void FormUnitGrid_Load(object sender, EventArgs e)
        {
            ToggleBtn(false);
        }
        private void FormUnitGrid_Shown(object sender, EventArgs e)
        {
            FillGrid();
            CheckUnavailable();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchData();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            CheckUnavailable();
        }
        private void btn_newUnit_Click(object sender, EventArgs e)
        {
            FormUnit newUnit = new FormUnit();
            newUnit.Op = OpType.New;
            if(newUnit.ShowDialog() == DialogResult.OK)
            {
                FillGrid();
                CheckUnavailable();
            }
        }
        private void btn_editUnit_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells["ID"].Value.ToString(); ;

            FormUnit editUnit = new FormUnit();
            editUnit.unitId = s;
            editUnit.Op = OpType.Edit;
            if(editUnit.ShowDialog() == DialogResult.OK)
            {
                FillGrid();
                CheckUnavailable();
            }
        }
        private void btn_expireUnit_Click(object sender, EventArgs e)
        {
            if(IsDeletable())
            {
                DialogResult dr_delete = MessageBox.Show("This unit has no existing records in Contracts." +
                    " Expiring this unit will permanently remove it from Units. Proceed?", "Warning!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(dr_delete == DialogResult.OK)
                {
                    DeleteUnit();
                    FillGrid();
                    CheckUnavailable();
                }
            } else
            {
                if (IsExpirable())
                {
                    DialogResult dr_expire = MessageBox.Show("This unit has an existing record in Contracts." +
                        " It will not be deleted from Units but its status will permanently be unavailable. Proceed?",
                        "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if(dr_expire == DialogResult.OK)
                    {
                        ExpireUnit();
                        MessageBox.Show("Unit expired");
                    }
                } else
                {
                    MessageBox.Show("Unit is not deletable or expirable since it has a record  in Contracts and its " +
                        "status is occupied.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Functions implementations
        /// </summary>
        private void FillGrid()
        {
            dt.Clear();
            con.Open();

            #region This query has been replaced by Unit_Get_Data_G
            /*
            string q = "SELECT UnitId AS 'ID', UnitType AS 'Type', UnitArea AS 'Area', " +
                "RentalAmount AS 'Rental Amount', TenantLimit AS 'Tenant Limit', " +
                "UnitStatus AS 'Unit Status' FROM units;";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Unit_Get_Data_G", con);
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

            string searchText = txt_search.Text;

            #region This query has been replaced with Unit_Search_Data_G
            /*
            string q = "SELECT UnitId AS 'ID', UnitType AS 'Type', UnitArea AS 'Area', RentalAmount AS 'Rental Amount', TenantLimit AS 'Tenant Limit', UnitStatus AS 'Unit Status' FROM units " +
                "WHERE UnitType LIKE '%" + searchText + "%' OR UnitArea LIKE '%" + searchText + "%' " +
                "OR RentalAmount LIKE '%" + searchText + "%' OR TenantLimit LIKE '%" + searchText + "%';";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Unit_Search_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_SearchText", searchText);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            msda.Fill(dt);
            dataGridView1.DataSource = dt;

            ToggleBtn(dt.Rows.Count > 0);
            txt_search.Clear();

            con.Close();
        }
        private void ToggleBtn(Boolean a)
        {
            btn_editUnit.Enabled = a;
            btn_expireUnit.Enabled = a;
        }
        private void CheckUnavailable()
        {
            if (dataGridView1.CurrentRow != null)
            {
                string status = dataGridView1.CurrentRow.Cells["Unit Status"].Value.ToString();
                btn_expireUnit.Enabled = (status != UNIT_UNAVAILABLE);
            }
        }
        private Boolean IsDeletable()
        {
            con.Open();

            string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string q = "SELECT COUNT(*)>0 AS HasUnit FROM contracts WHERE UnitId = " + id + ";";

            MySqlCommand checkDelete = new MySqlCommand(q, con);

            Boolean result = Convert.ToBoolean(checkDelete.ExecuteScalar());

            con.Close();
            return !result;
        }
        private Boolean IsExpirable()
        {

            string status = dataGridView1.CurrentRow.Cells["Unit Status"].Value.ToString();
            return status == UNIT_VACANT;
        }
        private void DeleteUnit()
        {
            con.Open();

            int id = Int32.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            MySqlCommand cmdDelete = new MySqlCommand("Unit_Delete", con);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("_UnitId", id);

            cmdDelete.ExecuteNonQuery();

            con.Close();
        }
        private void ExpireUnit()
        {
            con.Open();

            int id = Int32.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            MySqlCommand cmdExpire = new MySqlCommand("Unit_Expire", con);
            cmdExpire.CommandType = CommandType.StoredProcedure;
            cmdExpire.ExecuteNonQuery();
        }
    }
}
