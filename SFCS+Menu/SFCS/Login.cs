using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFCS.ServerConnection;
using System.Data.SqlClient;
namespace SFCS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //minhanh
        public static string phone_number;
        public static string password;
        public static string name;
        public static string readphone
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public static string readpass
        {
            get { return password; }
            set { password = value; }
        }
        public static string readname
        {
            get { return name; }
            set { name = value; }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtPhone.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkCrt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup register = new Signup();
            register.ShowDialog();
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtPass.Text))
            {
                bool result = txtPhone.Text.All(char.IsDigit);
                if (!result)
                {
                    MessageBox.Show("Your phone number must contains only numbers. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPhone.Select();
                    return;
                }
                if (txtPhone.Text.Length != 10)
                {
                    MessageBox.Show("Your phone number must contains 10 numbers. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPhone.Select();
                    return;
                }
                string mySQL = string.Empty;
                mySQL += "SELECT * FROM customerTbl ";
                mySQL += "WHERE Phone_Number = '" + txtPhone.Text +"'";
                mySQL += "AND Password = '" + Cryptography.Encrypt(txtPass.Text) + "'";
                DataTable userdata = ServerConnection.ServerConnection.executeSQL(mySQL);
                if (userdata.Rows.Count > 0)
                {
                   
                    
                    readphone = txtPhone.Text;
                    readpass = txtPass.Text;
                    txtPhone.Clear();
                    txtPass.Clear();
                    checkShow.Checked = false;
                    this.Hide(); 
                    MessageBox.Show("Log in successfull!", "SFCS", MessageBoxButtons.OK, MessageBoxIcon.None);
                    
                    Menu menu = new Menu();
                    menu.ShowDialog();

                }
                else
                {
                    MessageBox.Show("The phone number or password is incorrect. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPhone.Focus();
                    txtPhone.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Please enter Phone number and Password.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhone.Select();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
