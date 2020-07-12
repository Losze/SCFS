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
namespace SFCS
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void loadUserData()
        {
            
        }
        private void Signup_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please fill in blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool result = txtFullname.Text.All(c=>Char.IsLetter(c)||c==' ');
            if (!result)
            {
                MessageBox.Show("Your name mustn't contain any number or special character.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Select();
                return;
            }
            bool a = txtPhone.Text.All(char.IsDigit);
            if (!a)
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
            if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Please confirm your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Select();
                return;
            }
            if (txtConfirm.Text != txtPass.Text)
            {
                MessageBox.Show("Your password and confirmation password do not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Select();
                return;
            }
            string yourSQL = "SELECT Phone_Number FROM customerTbl WHERE Phone_Number = '"+txtPhone.Text+"'";
            DataTable checkDuplicates = SFCS.ServerConnection.ServerConnection.executeSQL(yourSQL);
            if (checkDuplicates.Rows.Count > 0)
            {
                MessageBox.Show("The phone number already exist. Please try another phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Select();
                return;
            }
            string mySQL = string.Empty;
            
            string pass = Cryptography.Encrypt(txtPass.Text.ToString());
            mySQL += "INSERT INTO customerTbl (Full_Name, Phone_Number, Password) ";
            mySQL += "VALUES ('" + txtFullname.Text + "',";
            mySQL += "'" + txtPhone.Text + "','" + pass + "')";
            SFCS.ServerConnection.ServerConnection.executeSQL(mySQL);
            MessageBox.Show("Sign up successfull. Please log in.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            loadUserData();
 
            this.Close();

        }
    }
}
