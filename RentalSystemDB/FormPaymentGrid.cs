using MySql.Data.MySqlClient;   //add MySql.Data reference
using System;
using System.ComponentModel;
using System.Configuration;     //add System.Configuration reference
using System.Data;
using System.Windows.Forms;

namespace RentalSystemDB
{
    public partial class FormPaymentGrid : Form
    {
        public FormPaymentGrid()
        {
            InitializeComponent();
        }

        const string INITIAL_PAYMENT = "Initial Payment";

        /// <summary>
        /// Gets connection settings from AppConfid and instantiates connections
        /// </summary>
        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        MySqlConnection con = new MySqlConnection(stdConnection);

        /// <summary>
        /// Property for id
        /// </summary>
        private string m_contractId;
        private string m_tenantName;

        public string contractId
        {
            set
            {
                m_contractId = value;
            }
        }
        public string tenantName
        {
            set
            {
                m_tenantName = value;
            }
        }

        /// <summary>
        /// Events
        /// </summary>
        private void FormPaymentGrid_Load(object sender, EventArgs e)
        {
            ToggleBtn(false);
            FillGrid();
            this.Text = m_tenantName + "'s Payments";
        }
        private void btn_search_Click(object sender, EventArgs e) => SearchData();
        private void btn_newPayment_Click(object sender, EventArgs e)
        {
            FormPayment newPayment = new FormPayment();
            newPayment.Operation = OpType.New;
            newPayment.contractId = m_contractId;
            if (newPayment.ShowDialog() == DialogResult.OK)
                FillGrid();
        }
        private void btn_editPayment_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            FormPayment editPayment = new FormPayment();
            editPayment.Operation = OpType.Edit;
            editPayment.paymentId = s;
            editPayment.contractId = m_contractId;
            if (editPayment.ShowDialog() == DialogResult.OK)
                FillGrid();
        }
        private void btn_deletePayment_Click(object sender, EventArgs e) 
        {
            if(Deletable())
            {
                DialogResult r = MessageBox.Show("Payment record will be deleted permanently!", "Warning!", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(r == DialogResult.OK)
                {
                    DeletePayment();
                    FillGrid();
                }
            } else
            {
                MessageBox.Show(INITIAL_PAYMENT + " cannot be deleted!", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// implementation
        /// </summary>   
        private void FillGrid()

        {
            con.Open();

            #region This query has been replaced with Payment_Get_Data_G stored procedure
            /*
            string q = "SELECT p.PaymentId AS ID, pt.TypeName AS 'Payment Type', " + 
                    "p.PaymentDate AS 'Payment Date', p.ReceiptNo AS 'Receipt #', " + 
                    "p.PaymentAmount AS 'Amount', p.PaymentStatus AS 'Status', p.Comment " +
                "FROM payments AS p INNER JOIN contracts AS c " +
                "ON p.ContractId = c.ContractId INNER JOIN payment_type AS pt " +
                "ON p.PaymentTypeId = pt.TypeId WHERE c.ContractId = " + m_contractId + ";";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Payment_Get_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_ContractId", Int32.Parse(m_contractId));
            MySqlDataAdapter mdsa = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            mdsa.Fill(dt);

            ToggleBtn(dt.Rows.Count > 0);
            dataGridView1.DataSource = dt;

            dataGridView1.Sort(dataGridView1.Columns["ID"], ListSortDirection.Ascending);

            con.Close();
        }
        private void SearchData()
        {
            con.Open();

            string searchText = txt_search.Text;

            #region This query has been replaced with Payment_Search_Data_G stored procedure
            /*
            string q = "SELECT p.PaymentId AS ID, pt.TypeName AS 'Payment Type', " +
                    "p.PaymentDate AS 'Payment Date', p.ReceiptNo AS 'Receipt #', " +
                    "p.PaymentAmount AS 'Amount', p.PaymentStatus AS 'Status', p.Comment " +
                "FROM payments AS p INNER JOIN contracts AS c " +
                "ON p.ContractId = c.ContractId INNER JOIN payment_type AS pt " +
                "ON p.PaymentTypeId = pt.TypeId " +
                "WHERE (pt.TypeName LIKE '%" + s + "%' OR p.PaymentDate LIKE '%" + s + "%' " +
                "OR p.ReceiptNo LIKE '%" + s + "%' OR p.PaymentAmount LIKE '%" + s + "%' " +
                "OR p.PaymentStatus LIKE '%" + s + "%' OR p.Comment LIKE '%" + s + "%') " +
                "AND c.ContractId = " + m_contractId + ";";
            */
            #endregion

            MySqlCommand cmd = new MySqlCommand("Payment_Search_Data_G", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("_SearchText", searchText);
            cmd.Parameters.AddWithValue("_ContractId", Int32.Parse(m_contractId));
            MySqlDataAdapter mdsa = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            mdsa.Fill(dt);

            ToggleBtn(dt.Rows.Count > 0);
            dataGridView1.DataSource = dt;
            txt_search.Clear();

            con.Close();
        }
        private void ToggleBtn(Boolean a)
        {
            btn_editPayment.Enabled = a;
            btn_deletePayment.Enabled = a;
        }
        private Boolean Deletable()
        {
            string type = dataGridView1.CurrentRow.Cells["Payment Type"].Value.ToString();

            return (type != INITIAL_PAYMENT) ? true : false;
        }
        private void DeletePayment()
        {
            con.Open();

            int paymentId = Int32.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            MySqlCommand cmdDelete = new MySqlCommand("Payment_Delete", con);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("_PaymentId", paymentId);
            cmdDelete.ExecuteNonQuery();

            con.Close();
        }
    }
}
