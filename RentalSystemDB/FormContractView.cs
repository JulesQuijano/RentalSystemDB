using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormContractView : Form
    {
        public FormContractView()
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
        const int FLD_NAME = 0;
        const int FLD_UNIT_TYPE = 1;
        const int FLD_UNIT_TYPE_DISPLAY = 2;
        const int FLD_CONTRACT_START = 3;
        const int FLD_CONTRACT_END = 4;
        const int FLD_COMMENT = 5;
        const int FLD_OLD_UNIT_ID = 6;
        const int FLD_CONTACT_DONE = 7;
        const string CB_UNIT_ITEM = "Item";

        /// <summary>
        /// Properties for id
        /// </summary>
        private string m_contractId;
        private DataTable dt = new DataTable();
        private DataTable dtUnit = new DataTable();

        public string contractId
        {
            set
            {
                m_contractId = value;
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormContractView_Shown(object sender, EventArgs e)
        { 
            SetView();
        }
        private void chk_contractDone_Click(object sender, EventArgs e)
        {
            ShowWarning();
            ToggleControls(!chk_contractDone.Checked);
        }
        private void btn_editTenant_Click(object sender, EventArgs e)
        {
            FormTenant editTenant = new FormTenant();
            editTenant.contractId = m_contractId;
            editTenant.Op = OpType.Edit;
            editTenant.ShowDialog();
            SetView();
        }
        private void btn_paymentGrid_Click(object sender, EventArgs e)
        {
            FormPaymentGrid paymentGrid = new FormPaymentGrid();
            paymentGrid.contractId = m_contractId;
            paymentGrid.tenantName = dt.Select()[0][FLD_NAME].ToString();
            paymentGrid.ShowDialog();
        }
        private void btn_saveClose_Click(object sender, EventArgs e)
        {
            if (DateCorrect())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Contract End cannot be before or the same as Contract Start.", 
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        /// <summary>
        /// implementation here
        /// </summary>
        private void LoadUnits()
        {
            string unit_type = dt.Select()[0][FLD_UNIT_TYPE].ToString();

            #region This query has been replaced with Unit_CB_Data_V stored procedure
            /*
            string q = "SELECT UnitId, CONCAT(UnitId, \" - \", UnitType) AS Item " +
                "FROM units WHERE UnitStatus = 'vacant' OR UnitType = '" + unit_type + "';";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Unit_CB_Data_V", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_UnitType", unit_type);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);

            dtUnit.Clear();
            msda.Fill(dtUnit);

            cb_unit.DataSource = dtUnit;
            cb_unit.DisplayMember = CB_UNIT_ITEM;
        }
        private void SetView()
        {
            con.Open();

            #region this query has been replaced with Contract_Get_Data_V stored procedure
            /*
            string q = "SELECT CONCAT(t.FirstName, \" \", t.MiddleName, \" \", t.LastName) AS Name, " +
                "u.UnitType, CONCAT(u.UnitId, \" - \", u.UnitType), c.ContractStart, c.ContractEnd, " +
                "c.Comment, u.UnitId, c.ContractDone " +
                "FROM contracts AS c INNER JOIN tenants AS t " +
                "ON c.TenantId = t.TenantId INNER JOIN units AS u " +
                "ON c.UnitId = u.UnitId " +
                "WHERE c.ContractId = " + m_contractId + ";";
            */
            #endregion

            // Needs CONCAT(u.UnitId, \" - \", u.UnitType) to be able to select at cb_unit.SelectedIndex
            MySqlCommand cmd = new MySqlCommand("Contract_Get_Data_V", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_ContractId", m_contractId);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
            dt.Clear();
            msda.Fill(dt);

            // Loads units combo box from separate dt
            LoadUnits();

            // Populates fields
            cb_unit.SelectedIndex = cb_unit.FindString(dt.Select()[0][FLD_UNIT_TYPE_DISPLAY].ToString());
            txt_Name.Text = dt.Select()[0][FLD_NAME].ToString();

            dtp_contractStart.Text = dt.Select()[0][FLD_CONTRACT_START].ToString();
            dtp_contractStart.CustomFormat = "yyyy-MM-dd";
            dtp_contractStart.Format = DateTimePickerFormat.Custom;

            dtp_contractEnd.Text = dt.Select()[0][FLD_CONTRACT_END].ToString();
            dtp_contractEnd.CustomFormat = "yyyy-MM-dd";
            dtp_contractEnd.Format = DateTimePickerFormat.Custom;

            chk_contractDone.Checked = (dt.Select()[0][FLD_CONTACT_DONE].ToString() == "True");
            ToggleControls(!chk_contractDone.Checked);

            rtx_comment.Text = dt.Select()[0][FLD_COMMENT].ToString();

            con.Close();
        }
        private void SaveData()
        {
            con.Open();

            int unitId = ((DataRowView)cb_unit.SelectedItem).Row.Field<Int32>("UnitId");
            int oldUnitId = Int32.Parse(dt.Select()[0][FLD_OLD_UNIT_ID].ToString());

            MySqlCommand cmdSave = new MySqlCommand("Contract_Update", con);
            cmdSave.CommandType = CommandType.StoredProcedure;


            cmdSave.Parameters.AddWithValue("_ContractId", Int32.Parse(m_contractId.Trim()));
            cmdSave.Parameters.AddWithValue("_UnitId", unitId);
            cmdSave.Parameters.AddWithValue("_ContractStart", dtp_contractStart.Text);
            cmdSave.Parameters.AddWithValue("_ContractEnd", dtp_contractEnd.Text);
            cmdSave.Parameters.AddWithValue("_ContractDone", chk_contractDone.Checked);
            cmdSave.Parameters.AddWithValue("_Comment", rtx_comment.Text.Trim());

            cmdSave.ExecuteNonQuery();

            // Switch unit status when selecting new unit.
            if (unitId != oldUnitId)
            {
                UpdateUnit(unitId, "occupied");
                UpdateUnit(oldUnitId, "vacant");
            }
            // Set Unit status to vacant if contract done.
            if (chk_contractDone.Checked)
            {
                unitId = ((DataRowView)cb_unit.SelectedItem).Row.Field<Int32>("UnitId");
                UpdateUnit(unitId, "vacant");
            }

            con.Close();
        }
        private void UpdateUnit(int Id, string status)
        {
            #region
            /*
            ConnectionState s = con.State;
            if(s != ConnectionState.Open)
            {
                con.Open();
            }
            */
            #endregion
            string q = "UPDATE units SET UnitStatus = '" + status + "' WHERE UnitId =" + Id.ToString() + ";";
            MySqlCommand cmd = new MySqlCommand(q, con);
            cmd.ExecuteNonQuery();
            #region
            /*
            if (s != ConnectionState.Open)
            {
                con.Close();
            }
            */
            #endregion
        }
        private void ShowWarning()
        {

            string m = "Checking Contract Done will prematurely end the contract. " +
                "This process cannot be undone. Proceed?";
            string c = "Warning! Contract Done checked!";

            DialogResult r = MessageBox.Show(m, c, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            chk_contractDone.Checked = (r == DialogResult.Yes);
        }
        private void ToggleControls(Boolean t)
        {
            chk_contractDone.Enabled = t;
            dtp_contractStart.Enabled = t;
            dtp_contractEnd.Enabled = t;
            cb_unit.Enabled = t;
        }
        private Boolean DateCorrect()
        {
            DateTime start = dtp_contractStart.Value;
            DateTime end = dtp_contractEnd.Value;

            return start.CompareTo(end) < 0;
        }
    }
}
