using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormInitPay : Form
    {
        public FormInitPay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets connection settings from AppConfid and instantiates connections
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);

        const int INIT_PAY_TYPE_ID = 5;

        /// <summary>
        /// Properties
        /// </summary>
        private int m_contractId;

        public int contractId
        {
            set
            {
                m_contractId = value;
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormInitPay_Shown(object sender, EventArgs e)
        {
            dtp_initPayment.CustomFormat = "yyyy-MM-dd";
            dtp_initPayment.Format = DateTimePickerFormat.Custom;            
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// Functions Implementations
        /// </summary>
        private void SaveData()
        {
            con.Open();

            MySqlCommand cmdSave = new MySqlCommand("Payment_New_Update", con);
            cmdSave.CommandType = CommandType.StoredProcedure;

            cmdSave.Parameters.AddWithValue("_PaymentId", -1);
            cmdSave.Parameters.AddWithValue("_ContractId", m_contractId);
            cmdSave.Parameters.AddWithValue("_PaymentTypeId", INIT_PAY_TYPE_ID);
            cmdSave.Parameters.AddWithValue("_PaymentDate", dtp_initPayment.Text);
            cmdSave.Parameters.AddWithValue("_ReceiptNo", txt_receiptNo.Text);
            cmdSave.Parameters.AddWithValue("_PaymentAmount", txt_amount.Text);
            cmdSave.Parameters.AddWithValue("_PaymentStatus", "Paid");
            cmdSave.Parameters.AddWithValue("_Comment", rtx_comment.Text);

            cmdSave.ExecuteNonQuery();

            con.Close();
        }
    }
}
