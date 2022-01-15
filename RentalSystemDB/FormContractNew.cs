using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormContractNew : Form
    {
        public FormContractNew()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets connection settings from AppConfid and instantiates connections
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);


        /// <summary>
        /// Constatns
        /// </summary>
        const string CB_ITEMS = "Items";

        /// <summary>
        /// Properties
        /// </summary>
        private int m_contractId = 0;
        private DataTable dtTenant = new DataTable();
        private DataTable dtUnit = new DataTable();

        /// <summary>
        /// Events
        /// </summary>
        private void FormNewContract_Load(object sender, EventArgs e)
        {
            LoadTenantUnitCB();

            dtp_contractStart.CustomFormat = "yyyy-MM-dd";
            dtp_contractStart.Format = DateTimePickerFormat.Custom;

            dtp_contractEnd.CustomFormat = "yyy-MM-dd";
            dtp_contractEnd.Format = DateTimePickerFormat.Custom;

            ToggleBtn(dtTenant.Rows.Count > 0 && dtUnit.Rows.Count > 0);
        }
        private void btn_newTenant_Click(object sender, EventArgs e)
        {
            FormTenant newTenant = new FormTenant();
            newTenant.Op = OpType.New;
            newTenant.ShowDialog();
            LoadTenantUnitCB();
        }
        private void btn_newUnit_Click(object sender, EventArgs e)
        {
            FormUnit newUnit = new FormUnit();
            newUnit.Op = OpType.New;
            if(newUnit.ShowDialog() == DialogResult.OK)
            {
                LoadTenantUnitCB();
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (DateCorrect())
            {
                SaveData();
                FormInitPay initPay = new FormInitPay();
                initPay.contractId = m_contractId;
                initPay.ShowDialog();
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Contract End cannot be before or the same as Contract Start.", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Function Implementations
        /// </summary>
        private void LoadTenantUnitCB()
        {
            con.Open();

            #region These queries have been replaced by stored procedures
            /*
            string tenantQ = "SELECT TenantId, " +
                "CONCAT(TenantId, \" - \", FirstName, \" \", MiddleName, \" \", LastName) AS Items FROM tenants;";
            string unitQ = "SELECT UnitId, CONCAT(UnitId, \" - \", UnitType) as Items " +
                "FROM units WHERE UnitStatus = 'vacant';";
            */
            #endregion

            // uses stored procedure to get data from db
            MySqlCommand tenantCmd = new MySqlCommand("Tenant_CB_Data_N", con);
            tenantCmd.CommandType = CommandType.StoredProcedure;
            MySqlCommand unitCmd = new MySqlCommand("Unit_CB_Data_N", con);
            unitCmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter tMsda = new MySqlDataAdapter(tenantCmd);
            MySqlDataAdapter uMsda = new MySqlDataAdapter(unitCmd);

            dtTenant.Clear();
            dtUnit.Clear();

            // stores data in separate datatables
            tMsda.Fill(dtTenant);
            uMsda.Fill(dtUnit);

            cb_tenant.DataSource = dtTenant;
            cb_tenant.DisplayMember = CB_ITEMS;

            cb_unit.DataSource = dtUnit;
            cb_unit.DisplayMember = CB_ITEMS;

            con.Close();
        }
        private void SaveData()
        {
            
            con.Open();

            int tenantId = ((DataRowView)cb_tenant.SelectedItem).Row.Field<Int32>("TenantId");
            int unitId = ((DataRowView)cb_unit.SelectedItem).Row.Field<Int32>("UnitId");

            MySqlCommand cmdSave = new MySqlCommand("Contract_New", con);
            cmdSave.CommandType = CommandType.StoredProcedure;

            cmdSave.Parameters.AddWithValue("_TenantId", tenantId);
            cmdSave.Parameters.AddWithValue("_UnitId", unitId);
            cmdSave.Parameters.AddWithValue("_ContractStart", dtp_contractStart.Text);
            cmdSave.Parameters.AddWithValue("_ContractEnd", dtp_contractEnd.Text);
            cmdSave.Parameters.AddWithValue("_Comment", rtx_comment.Text);

            cmdSave.ExecuteNonQuery();
            
            //gets inserted id
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(ContractId) as Id FROM contracts;",con);
            m_contractId = (Int32)cmd.ExecuteScalar();

            //sets unit to occupied once saved
            int Id = ((DataRowView)cb_unit.SelectedItem).Row.Field<Int32>("UnitId");
            MySqlCommand cmdSetOccupied = new MySqlCommand("UPDATE units SET UnitStatus = 'occupied' WHERE UnitId =" + Id.ToString() + ";", con);
            cmdSetOccupied.ExecuteNonQuery();

            con.Close();
        }
        private Boolean DateCorrect()
        {
            DateTime start = dtp_contractStart.Value;
            DateTime end = dtp_contractEnd.Value;

            return start.CompareTo(end) < 0;
        }
        private void ToggleBtn(Boolean a)
        {
            btn_save.Enabled = a;
        }
    }
}
