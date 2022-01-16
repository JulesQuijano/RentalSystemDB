using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormPayment : Form
    {
        public FormPayment()
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
        const int FLD_Payment_Type = 1;
        const int FLD_Paymen_Date = 2;
        const int FLD_Payment_Receipt = 3;
        const int FLD_Payment_Amount = 4;
        const int FLD_Payment_Status = 5;
        const int FLD_Payment_Comment = 6;

        const string INITIAL_PAYMENT = "Initial Payment";

        /// <summary>
        /// Property for paymentId
        /// </summary>
        private string m_paymentId = "-1";
        private int m_contractId = -1;
        DataTable dt = new DataTable();
        DataTable dtPT = new DataTable();
        public OpType Operation;       

        public string paymentId
        {
            set
            {
                m_paymentId = value;
            }
        }
        public string contractId
        {
            set
            {
                m_contractId = Int32.Parse(value);
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormPayment_Shown(object sender, EventArgs e)
        {
            dtp_Payment.CustomFormat = "yyyy-MM-dd";
            dtp_Payment.Format = DateTimePickerFormat.Custom;
            if (Operation==OpType.Edit)
            {
                SetView();
                this.Text = "Edit Payment";
            } else
            {
                LoadUnits();
                this.Text = "New Payment";
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(NoError())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Receipt Number and Amount fields cannot be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Functions implementations
        /// </summary>
        private void SetView()
        {
            con.Open();

            #region This query has been replaced with Payment_Get_Data_V stored procedure
            /*
            string q = "SELECT p.PaymentId, pt.TypeName AS Items, p.PaymentDate, p.ReceiptNo, " +
                    "p.PaymentAmount, p.PaymentStatus, p.Comment " +
                "FROM payments AS p INNER JOIN payment_type AS pt " +
                "ON p.PaymentTypeId = pt.TypeId WHERE p.PaymentId = " + m_paymentId + ";";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Payment_Get_Data_V", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_PaymentId", Int32.Parse(m_paymentId));
            MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
            msda.Fill(dt);

            dtp_Payment.Text = dt.Select()[0][FLD_Paymen_Date].ToString();

            txt_receiptNo.Text = dt.Select()[0][FLD_Payment_Receipt].ToString();
            txt_amount.Text = dt.Select()[0][FLD_Payment_Amount].ToString();
            rtxt_comment.Text = dt.Select()[0][FLD_Payment_Comment].ToString();

            LoadUnits();

            Boolean paid = dt.Select()[0][FLD_Payment_Status].ToString() == "Paid";
            rbtn_paid.Checked = paid;
            rbtn_unpaid.Checked = !paid;

            con.Close();
        }
        private void LoadUnits()
        {
            if (Operation == OpType.New)
            {
                con.Open();
                try
                {
                    PopulateUnits();
                    DataRow r = dtPT.Rows.Find(INITIAL_PAYMENT);
                    if (r != null)
                        dtPT.Rows.Remove(r);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                PopulateUnits();

                cb_type.SelectedIndex = cb_type.FindString(dt.Select()[0][FLD_Payment_Type].ToString());
                if (cb_type.Text == INITIAL_PAYMENT)
                {
                    cb_type.Enabled = false;
                } else
                {
                    DataRow r=dtPT.Rows.Find(INITIAL_PAYMENT);
                    if (r != null)
                        dtPT.Rows.Remove(r);
                }
            }

            void PopulateUnits()
            {
                string qPaymentType = "SELECT TypeId, TypeName FROM payment_type;";

                MySqlCommand cmdPT = new MySqlCommand(qPaymentType, con);
                MySqlDataAdapter msdaPT = new MySqlDataAdapter(cmdPT);
                msdaPT.Fill(dtPT);

                var key = new DataColumn[1];

                key[0] = dtPT.Columns[1];

                dtPT.PrimaryKey = key;

                cb_type.DataSource = dtPT;
                cb_type.DisplayMember = "TypeName";
            }
        }
        private void SaveData()
        {
            con.Open();

            int paymentTypeId = ((DataRowView)cb_type.SelectedItem).Row.Field<Int32>("TypeId");
            string isPaid = (rbtn_paid.Checked) ? "Paid" : "Unpaid";

            MySqlCommand cmdSave = new MySqlCommand("Payment_New_Update", con);
            cmdSave.CommandType = CommandType.StoredProcedure;

            cmdSave.Parameters.AddWithValue("_PaymentId", Int32.Parse(m_paymentId));
            
            
            cmdSave.Parameters.AddWithValue("_ContractId", m_contractId);
            
            cmdSave.Parameters.AddWithValue("_PaymentTypeId", paymentTypeId);
            cmdSave.Parameters.AddWithValue("_PaymentDate", dtp_Payment.Text);
            cmdSave.Parameters.AddWithValue("_ReceiptNo", txt_receiptNo.Text);
            cmdSave.Parameters.AddWithValue("_PaymentAmount", txt_amount.Text);
            cmdSave.Parameters.AddWithValue("_PaymentStatus", isPaid);
            cmdSave.Parameters.AddWithValue("_Comment", rtxt_comment.Text);

            cmdSave.ExecuteNonQuery();

            con.Close();
        }
        private Boolean NoError()
        {
            return !String.IsNullOrEmpty(txt_receiptNo.Text) && !String.IsNullOrEmpty(txt_amount.Text);
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

        private void txt_receiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_receiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKey(e);
        }
        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey(e);
        }
    }
}
