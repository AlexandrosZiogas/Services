using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace MyG
{
    public partial class FrmServices : Form
    {
        string SQL;
        // OdbcDataReader reader;
        OdbcDataAdapter dacustomers;
        OdbcDataAdapter daservices;
        OdbcDataAdapter dadetails;
        OdbcCommand cmd = new OdbcCommand();
        DataTable dtcustomers = new DataTable();
        DataTable dtservices = new DataTable();
        DataTable dtdetails = new DataTable();


        public FrmServices()
        {
            
            InitializeComponent();
        }

        /*private void getCusomers()
        {
            SQL ="SELECT `customerId` , `lname` ,`fname`,`phone` FROM customers WHERE lname LIKE ?";

            try
            {
                cmd.CommandText = SQL;
                cmd.Connection = Db.Cn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@lname", txtSearch.Text + "%");
                //reader = cmd.ExecuteReader();
                dtcustomers.Clear();
                dtservices.Clear();
                //dtcustomers.Load(reader);
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = dtcustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "oops!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
            }
            finally
            {
                try
                {
                    if (reader != null)
                        reader.Close();
                }
                finally { }
            }
        }
        */

        private void getCustomers()
        {

            SQL = "SELECT `customerId` , `lname` ,`fname`,`phone` FROM customers WHERE lname LIKE ?";
            try
            {

                dacustomers = new OdbcDataAdapter();
                dacustomers.SelectCommand = new OdbcCommand(SQL, Db.Cn);
                dacustomers.SelectCommand.Parameters.AddWithValue("@lname", txtSearch.Text + "%");
                OdbcCommandBuilder builder = new OdbcCommandBuilder(dacustomers);
                //dtcustomers.Clear();
                //dtdetails.Clear();
                dacustomers.Fill(dtcustomers);
                //dgvServices.DataSource = null;
                dgvCustomers.DataSource = null;
                // dgvDetails.DataSource = null;
                dgvServices.DataSource = dtservices;
                dgvCustomers.DataSource = dtcustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "oops!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                this.Close();
            }
        }


        private void getServices(string id)
        {
            SQL = "SELECT `servicesId` ,`customerId`,`model`,`outdate`,`indate`,`notesin`,`notesout`" +
                " FROM `services` WHERE customerId='"+id +"'";
            daservices = new OdbcDataAdapter();
            daservices.SelectCommand = new OdbcCommand(SQL, Db.Cn);
            OdbcCommandBuilder builder = new OdbcCommandBuilder(daservices);
            dtservices.Clear();
            dtdetails.Clear();
            daservices.Fill(dtservices);
            dgvServices.DataSource = null;
           // dgvDetails.DataSource = null;
            dgvServices.DataSource = dtservices;
            
        }
        
        private void getDetails(string id)
        {
            SQL = "SELECT `servicesId`,`empId`,`servicedt`,`notes` FROM `details` WHERE servicesId='" + id + "'";
            dadetails = new OdbcDataAdapter();
            dadetails.SelectCommand = new OdbcCommand(SQL, Db.Cn);
            OdbcCommandBuilder builder = new OdbcCommandBuilder(dadetails);
            dtdetails.Clear();
            dadetails.Fill(dtdetails);
            // dgvDetails.DataSource = null;
            //dtdetails.Rows.Clear();
            dgvDetails.DataSource = dtdetails;
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                getCustomers();
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int row = e.RowIndex;
            string id = dgvCustomers.Rows[row].Cells[0].Value.ToString();
            dtservices.Clear();
            getServices(id);
            
        }


        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            int row = e.RowIndex;
            if (row >= dgvCustomers.Rows.Count-1) return;
            string id = dgvCustomers.Rows[row].Cells[0].Value.ToString();
            getDetails(id);
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            try
            {
                dadetails.Update(dtdetails);

            }
            catch (Exception)
            {

                
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                daservices.Update(dtservices);
            }
            catch (Exception)
            {

                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dacustomers.Update(dtcustomers);
            }
            catch (Exception)
            {


            }

        }
    }
}
