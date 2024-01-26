using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public partial class Form1 : Form
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=#after this equals sign replace with directory where the restaurantmenu.db file is located";
        private const double TipsPercentage = 0.15;
        private double subtotal = 0;

        public Form1()
        {
            InitializeComponent();
            LoadMenuItems();

            // Set TextBox properties
            textBox2.ReadOnly = true; // Subtotal
            textBox5.ReadOnly = true; // Total

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            subtotal = 0;
            listBox1.Items.Clear();
            selectedPrices.Clear();
            // make sure no item is selected
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            // Enable editing tips
            textBox4.Enabled = true;
        }

        private void LoadMenuItems()
        {
            LoadMenuItems("Main Course", comboBox1);
            LoadMenuItems("Appetizer", comboBox2);
            LoadMenuItems("Beverage", comboBox3);
            LoadMenuItems("Dessert", comboBox4);
        }

        private void LoadMenuItems(string category, ComboBox comboBox)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Menu WHERE Category = '{category}'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox.DisplayMember = "ItemName";
                comboBox.DataSource = dataTable;
            }
        }

        private List<double> selectedPrices = new List<double>(); // new code

        private void CalculateSubtotal()
        {
            
            double itemPrice = selectedPrices.Sum(); // Sum the prices

            subtotal += itemPrice;

            textBox2.Text = subtotal.ToString("C");

            double tax;
            if (double.TryParse(textBox3.Text, out tax))
            {
                // Calculation using the user-entered tax rate
                tax = subtotal * tax;
                textBox3.Text = tax.ToString("C");
            }
            else
            {
                MessageBox.Show("Please enter a valid tax rate.");
                textBox3.Text = "0.00";
            }

            int partySize;
            if (int.TryParse(textBox1.Text, out partySize) && partySize >= 7)
            {
                // Automatically set tips to 15% if party size is 7 or more
                double tips = subtotal * TipsPercentage;
                textBox4.Text = tips.ToString();

                double tipsAmount;
                double.TryParse(textBox4.Text, out tipsAmount);
                textBox4.Text = tips.ToString("C");
                double total = subtotal + tax + tipsAmount;
                textBox5.Text = total.ToString("C");
            }
            else
            {
                // else tips will be based on user entered value from textbox4
                double tips;
                if (double.TryParse(textBox4.Text, out tips))
                {
                    textBox4.Text = tips.ToString();

                    double tipsAmount;
                    double.TryParse(textBox4.Text, out tipsAmount);
                    textBox4.Text = tips.ToString("C");
                    double total = subtotal + tax + tipsAmount;
                    textBox5.Text = total.ToString("C");
                }
                else
                {
                    MessageBox.Show("Please enter a valid tip amount.");
                    textBox4.Text = "0.00";
                }
            }

            selectedPrices.Clear();
        }


        private double GetSelectedItemPrice(ComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
            {
                DataRowView selectedItem = (DataRowView)comboBox.SelectedItem;
                double price = Convert.ToDouble(selectedItem["Price"]);

                // Add the selected item price to the list
                selectedPrices.Add(price);

                // Add the selected item to the list box
                listBox1.Items.Add($"{selectedItem["ItemName"]} - {selectedItem["Price"]:C}");
                return price;
            }
            return 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemPrice(comboBox1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemPrice(comboBox2);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemPrice(comboBox3);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemPrice(comboBox4);
        }

        private void button1_Click_1(object sender, EventArgs e) //submit button
        {
            CalculateSubtotal();
        }

        private void button2_Click_1(object sender, EventArgs e) // clear button
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            subtotal = 0;
            listBox1.Items.Clear();
            selectedPrices.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            // Enable editing tips
            textBox4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int partySize;
            if (int.TryParse(textBox1.Text, out partySize) && partySize >= 7)
            {
                textBox4.Clear();
                textBox4.Enabled = false; // Disable editing tips
            }
            else
            {
                // Enable editing tips if party size is less than 7
                textBox4.Enabled = true;
                textBox4.Text = "0.00";
            }
        }
    }
}
