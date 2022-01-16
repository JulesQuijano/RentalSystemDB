using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormUnit : Form
    {
        public FormUnit()
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
        const int FLD_UnitType = 1;
        const int FLD_UnitArea = 2;
        const int FLD_RentalAmount = 3;
        const int FLD_TenantLimit = 4;
        const int FLD_UnitStatus = 5;

        /// <summary>
        /// Property for unitId
        /// </summary>
        DataTable dt = new DataTable();
        private string m_unitId = "-1";
        public OpType Op;
        
        public string unitId
        {
            set
            {
                m_unitId = value;
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormUnit_Shown(object sender, EventArgs e)
        {
            if(Op == OpType.Edit)
            {
                SetView();
                this.Text = "Edit Unit";
            } else
            {
                cb_type.SelectedIndex = 0;
                lbl_unitStatus.Hide();
                txt_unitStatus.Hide();
                this.Text = "New Unit";
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (NoError())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Field entries cannot be blank.", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// implementation
        /// </summary>
        private void SetView()
        {
            con.Open();

            #region This query has been replaced with Unit_Get_Data_V
            /*
            string q = "SELECT UnitId, UnitType, UnitArea, RentalAmount, TenantLimit, UnitStatus " +
                "FROM units WHERE UnitId = " + m_unitId + ";";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Unit_Get_Data_V" , con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_UnitId", Int32.Parse(m_unitId));
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
            msda.Fill(dt);

            cb_type.SelectedIndex = cb_type.FindString(dt.Select()[0][FLD_UnitType].ToString());
            txt_area.Text = dt.Select()[0][FLD_UnitArea].ToString();
            txt_rentalFee.Text = dt.Select()[0][FLD_RentalAmount].ToString();
            txt_tenantLimit.Text = dt.Select()[0][FLD_TenantLimit].ToString();
            txt_unitStatus.Text = dt.Select()[0][FLD_UnitStatus].ToString();

            con.Close();
        }
        private void SaveData()
        {
            con.Open();

            MySqlCommand cmdSave = new MySqlCommand("Unit_New_Update", con);
            cmdSave.CommandType = CommandType.StoredProcedure;

            cmdSave.Parameters.AddWithValue("_UnitId", Int32.Parse(m_unitId));

            if(Op == OpType.New)
            {
                cmdSave.Parameters.AddWithValue("_UnitType", cb_type.Text);
            } else
            {
                cmdSave.Parameters.AddWithValue("_UnitType", dt.Select()[0][FLD_UnitType].ToString());
            }

            cmdSave.Parameters.AddWithValue("_UnitArea", txt_area.Text);
            cmdSave.Parameters.AddWithValue("_RentalAmount", txt_rentalFee.Text);
            cmdSave.Parameters.AddWithValue("_TenantLimit", Int32.Parse(txt_tenantLimit.Text));

            cmdSave.ExecuteNonQuery();

            con.Close();
        }
        private Boolean NoError()
        {
            return (!String.IsNullOrEmpty(txt_area.Text) && !String.IsNullOrEmpty(txt_rentalFee.Text) &&
                !String.IsNullOrEmpty(txt_tenantLimit.Text));
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
                    // Determine whether the keystroke is a backspace or a period.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod)
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

        private void txt_area_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_area_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
        private void txt_rentalFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_rentalFee_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
        private void txt_tenantLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_tenantLimit_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
    }
}
