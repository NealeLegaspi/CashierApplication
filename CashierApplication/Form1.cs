using ItemNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class Form1 : Form
    {

        private DiscountedItem currentItem;
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = txtItemName.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                currentItem = new DiscountedItem(itemName, price, quantity, discount);
                txtTotalAmount.Text = currentItem.CalculateTotalPrice().ToString("0.00");
            }
            catch 
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void btnComputeChange_Click(object sender, EventArgs e)
        {
            try
            {
                if(currentItem != null)
                {
                    double payment = Convert.ToDouble(txtPayment.Text);
                    currentItem.SetPayment(payment);
                    txtChange.Text = currentItem.GetChange().ToString("0.00");
                }
                else
                {
                    MessageBox.Show("Calculate total amount first.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid input!");
            }
        }
    }
}
