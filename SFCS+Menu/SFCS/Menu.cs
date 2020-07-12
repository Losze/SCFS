using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFCS
{
    public partial class Menu : Form
    {
        int CB, BM, CCB, CCGC, Drink, K, Total;
        public Menu()
        {
            InitializeComponent();
        }
        private void Label4_Click(object sender, EventArgs e) {}
        private void PlusCB_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtCB.Text);
            txtCB.Text = (a + 1).ToString();
        }
        private void MinusCG_Click(object sender, EventArgs e) {
            int a = Convert.ToInt32(txtCB.Text);
            if (a > 0) txtCB.Text = (a - 1).ToString();
            else txtCB.Text = "0";
        }
        private void MinusBM_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtBM.Text);
            if (a > 0) txtBM.Text = (a - 1).ToString();
            else txtBM.Text = "0";
        }
        private void PlusBM_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtBM.Text);
            txtBM.Text = (a + 1).ToString();
        }

        private void MinusCCB_Click(object sender, EventArgs e) {
            int a = Convert.ToInt32(txtCCB.Text);
            if (a > 0) txtCCB.Text = (a - 1).ToString();
            else txtCCB.Text = "0";
        }
        private void PlusCCB_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtCCB.Text);
            txtCCB.Text = (a + 1).ToString();
        }
        private void MinusCCGC_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtCCGC.Text);
            if (a > 0) txtCCGC.Text = (a - 1).ToString();
            else txtCCGC.Text = "0";

        }

        private void PlusCCGC_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtCCGC.Text);
            txtCCGC.Text = (a + 1).ToString();
        }

        private void buttonBasket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Presented by students of Ho Chi Minh University of Technology", "SFCS", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void buttonFoods_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void MinusDrink_Click(object sender, EventArgs e){
            int a = Convert.ToInt32(txtDrink.Text);
            if (a > 0) txtDrink.Text = (a - 1).ToString();
            else txtDrink.Text = "0";
        }

        private void PlusDrink_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtDrink.Text);
            txtDrink.Text = (a + 1).ToString();
        }

        private void MinusK_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtK.Text);
            if (a > 0) txtK.Text = (a - 1).ToString();
            else txtK.Text = "0";
        }

        private void PlusK_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtK.Text);
            txtK.Text = (a + 1).ToString();
        }

        private void BtnCOrder_Click(object sender, EventArgs e){
            if (MessageBox.Show("Confirm your order?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CB = Convert.ToInt32(txtCB.Text) * 56000;
                BM = Convert.ToInt32(txtBM.Text) * 66000;
                CCB = Convert.ToInt32(txtCCB.Text) * 79000;
                CCGC = Convert.ToInt32(txtCCGC.Text) * 79000;
                Drink = Convert.ToInt32(txtDrink.Text) * 20000;
                K = Convert.ToInt32(txtK.Text) * 10000;
                Total = CB + BM + CCB + CCGC + Drink + K;
                if(Total==0)
                {
                    MessageBox.Show("You must order at least 1 product.", "SFCS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Cheese Burger: " + CB + "VND" + Environment.NewLine + "BigMac: " + BM +"VND"+ Environment.NewLine + "Combo Cheese Burger: " + CCB +"VND" + Environment.NewLine +
                    "Frice chicken rice: " + CCGC +"VND" + Environment.NewLine + "Drink: " + Drink +"VND"+ Environment.NewLine + "Ice cream: " + K +"VND"+ Environment.NewLine +
                    "Total: " + Total+"VND", "Receipt", MessageBoxButtons.OK);
            }
        }
        private void BtnClear_Click(object sender, EventArgs e) {
            txtCB.Text = "0";
            txtBM.Text = "0";
            txtCCB.Text = "0";
            txtCCGC.Text = "0";
            txtDrink.Text = "0";
            txtK.Text = "0";
            CB = 0; BM = 0; CCB = 0; CCGC = 0; Drink = 0; K = 0; Total = 0;
        }
    }
}
