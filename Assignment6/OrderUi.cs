using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Assignment6.BLL;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string price = "";
            decimal black = 120;
            decimal cold = 100;
            decimal hot = 90;
            decimal regular = 80;
            if (itemComboBox.Text == "Black")
            {
                price = (black * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Cold")
            {
                price = (cold * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Hot")
            {
                price = (hot * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Regular")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Spacial")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            priceTextBox.Text = price;

            //Mandatory
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Customer Name can not be Empty!!");
                return;
            }
           
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity can not be Empty!!");
                return;
            }

            ////Unique
            //if (_itemManager.IsNameExist(nameTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exist!!");
            //    return;
            //}

            //Add/Insert
                
            if (_orderManager.Add(customerNameTextBox.Text,itemComboBox.Text,Convert.ToDouble(priceTextBox.Text),Convert.ToDouble(quantityTextBox.Text)))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            idTextBox.Clear();
            customerNameTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_orderManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _orderManager.Display();
            idTextBox.Clear();
            customerNameTextBox.Clear();
            itemComboBox.Items.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string price = "";
            decimal black = 120;
            decimal cold = 100;
            decimal hot = 90;
            decimal regular = 80;
            int id;

            if (itemComboBox.Text == "Black")
            {
                price = (black * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Cold")
            {
                price = (cold * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Hot")
            {
                price = (hot * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Regular")
            {
                price = (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }
            else if (itemComboBox.Text == "Spacial")
            {
                 price= (regular * Decimal.Parse(quantityTextBox.Text)).ToString();
            }

            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("CustomerName Can not be Empty!!!");
                return;
            }
            priceTextBox.Text = price;

            //Set Price as Mandatory

            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity Can not be Empty!!!");
                return;
            }

            if (_orderManager.Update(customerNameTextBox.Text,itemComboBox.Text, Convert.ToDouble(priceTextBox.Text),Convert.ToDouble(quantityTextBox.Text) ,Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _orderManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            idTextBox.Clear();
            customerNameTextBox.Clear();
            itemComboBox.Items.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();

        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Search(itemComboBox.Text);
            
        }
    }
}
