using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormTenant : Form
    {
        public FormTenant()
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
        //const int FLD_TenantId = 0;
        const int FLD_FName = 1;
        const int FLD_MName = 2;
        const int FLD_LName = 3;
        const int FLD_MobileNo = 4;
        const int FLD_EmailAd = 5;
        const int FLD_PermaAd = 6;
        const int FLD_Company = 7;
        const int FLD_AnnualInc = 8;
        const int FLD_HouseholdNum = 9;

        /// <summary>
        /// Property for id
        /// </summary>
        private string m_contractId = "";
        private string m_tenantId = "-1";
        private DataTable dt = new DataTable();
        public OpType Op;

        public string contractId
        {
            set
            {
                m_contractId = value;
            }
        }
        public string tenantId
        {
            set
            {
                m_tenantId = value;
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormTenant_Shown(object sender, EventArgs e)
        {
            if (Op == OpType.Edit)
            {
                SetView();
            }            
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if (NoError())
            {
                SaveData();
                this.Close();
            } else
            {
                MessageBox.Show("Field entries cannot be blank.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Other functions
        /// </summary>
        private void SetView()
        {
            con.Open();

            string q;
            
            if(m_contractId != "")
            {
                q = "SELECT * FROM tenants " +
                "WHERE TenantId=(SELECT TenantId FROM contracts WHERE contractId=" + m_contractId + ");";
            } else
            {
                q = "SELECT * FROM tenants " +
                "WHERE TenantId = " + m_tenantId + ";";
            }

            MySqlCommand cmd = new MySqlCommand(q, con);
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);

            msda.Fill(dt);

            m_tenantId = dt.Rows[0].Field<int>("TenantId").ToString();

            txt_fName.Text = dt.Select()[0][FLD_FName].ToString();
            txt_mName.Text = dt.Select()[0][FLD_MName].ToString();
            txt_lName.Text = dt.Select()[0][FLD_LName].ToString();
            txt_mobileNo.Text = dt.Select()[0][FLD_MobileNo].ToString();
            txt_emailAd.Text = dt.Select()[0][FLD_EmailAd].ToString();
            txt_permaAd.Text = dt.Select()[0][FLD_PermaAd].ToString();
            txt_company.Text = dt.Select()[0][FLD_Company].ToString();
            txt_annualInc.Text = dt.Select()[0][FLD_AnnualInc].ToString();
            txt_houseHoldNum.Text = dt.Select()[0][FLD_HouseholdNum].ToString();

            con.Close();
        }
        private void SaveData()
        {
            con.Open();

            MySqlCommand cmdSave = new MySqlCommand("Tenant_New_Update", con);
            cmdSave.CommandType = CommandType.StoredProcedure;

            int tenant_id = Int32.Parse(m_tenantId);

            cmdSave.Parameters.AddWithValue("_TenantId", tenant_id);
            cmdSave.Parameters.AddWithValue("_FirstName", txt_fName.Text);
            cmdSave.Parameters.AddWithValue("_MiddleName", txt_mName.Text);
            cmdSave.Parameters.AddWithValue("_LastName", txt_lName.Text);
            cmdSave.Parameters.AddWithValue("_MobileNo", txt_mobileNo.Text);
            cmdSave.Parameters.AddWithValue("_EmailAddress", txt_emailAd.Text);
            cmdSave.Parameters.AddWithValue("_PermaAddress", txt_permaAd.Text);
            cmdSave.Parameters.AddWithValue("_Company", txt_company.Text);
            cmdSave.Parameters.AddWithValue("_AnnualIncome", txt_annualInc.Text);
            cmdSave.Parameters.AddWithValue("_HouseholdNum", txt_houseHoldNum.Text);

            cmdSave.ExecuteNonQuery();

            con.Close();
        }

        private Boolean NoError()
        {
            return (!String.IsNullOrEmpty(txt_fName.Text) && !String.IsNullOrEmpty(txt_mName.Text) &&
                !String.IsNullOrEmpty(txt_lName.Text) && !String.IsNullOrEmpty(txt_mobileNo.Text) &&
                !String.IsNullOrEmpty(txt_emailAd.Text) && !String.IsNullOrEmpty(txt_permaAd.Text) &&
                !String.IsNullOrEmpty(txt_company.Text) && !String.IsNullOrEmpty(txt_annualInc.Text) &&
                !String.IsNullOrEmpty(txt_houseHoldNum.Text));
        }


        /// <summary>
        /// number checker
        /// </summary>
        private Boolean nonNumberEntered = false;

        private void CheckKey(KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void InputKey(KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Oemcomma)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it's not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void txt_annualInc_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_annualInc_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
        private void txt_houseHoldNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_houseHoldNum_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
    }
}
