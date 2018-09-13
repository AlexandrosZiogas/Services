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
    public partial class FrmConnect : Form
    {
        public FrmConnect()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Db.Connect(
                    txtServer.Text,
                    txtPort.Text,
                    "service",
                    txtRoot.Text,
                    txtPass.Text);
            }

            finally
            {
                ShowState();

                if (Db.Cn.State != ConnectionState.Open)
                    Db.Cn.Close();
            }
        }

        private void btnDisconect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Db.Cn.State != ConnectionState.Closed)
                    Db.Cn.Close();
            }

            finally
            {
                ShowState();
            }
        }

        private void ShowState()
        {
            if (Db.Cn.State != ConnectionState.Open)
                BackColor = Color.Red;

            else
            {
                BackColor = Color.LightGreen;
            }
        }
    }
}
