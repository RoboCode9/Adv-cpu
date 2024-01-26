using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Number of days on the trip text field
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true; // Block non-numeric characters
            }

            if (e.KeyChar == '.' && textBox1.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox1.Text.Length >= 3 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 3 characters
            }
        }

        //Amount of air fare text field
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox2.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox2.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Amount of car rental fees text field
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox3.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox3.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Number of miles driven text field
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox4.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox4.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Amount of parking fees text field
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox5.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox5.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Amount of taxi charges text field
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox6.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox6.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Conference or seminar registration fees text field
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox7.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox7.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        //Lodging charges, per night text field
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric and non-decimal characters
            }

            if (e.KeyChar == '.' && textBox8.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }

            if (textBox8.Text.Length >= 9 && e.KeyChar != 8)
            {
                e.Handled = true; // Block input after reaching 9 characters
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //collect user input
            int daysTrip = int.Parse(textBox1.Text);
            double airFare = double.Parse(textBox2.Text);
            double carRentalFees = double.Parse(textBox3.Text);
            double milesDriven = double.Parse(textBox4.Text);
            double parkingFees = double.Parse(textBox5.Text);
            double taxiCharges = double.Parse(textBox6.Text);
            double conferenceFees = double.Parse(textBox7.Text);
            double lodgingCharges = double.Parse(textBox8.Text);

            //constants
            const double daylyMeal = 37.00;
            const double parkingFee = 10.00;
            const double taxiFee = 20.0;
            const double lodgingCharge = 95.00;
            const double rentCar = 0.27;

            //calculate individual expenses
            double totalMilesDriven = milesDriven * rentCar;
            double totalAirfare = airFare;
            double totalCarRental = carRentalFees;
            double totalParkingFees = Math.Min(parkingFees, parkingFee * daysTrip);
            double totalTaxiCharges = Math.Min(taxiCharges, taxiFee * daysTrip);
            double totalSeminarFees = conferenceFees;
            double totalLodgingCharges = lodgingCharges * daysTrip;

            //calculate total expenses
            double totalExpenses = totalAirfare + totalCarRental + totalMilesDriven + totalParkingFees + totalTaxiCharges + totalSeminarFees + totalLodgingCharges;

            //calculate total allowed expenses
            double totalAllowed = (daylyMeal * daysTrip) + (parkingFee * daysTrip) + (taxiFee * daysTrip) + (lodgingCharge * daysTrip) + (totalMilesDriven);

            //calculate owed or saved
            double totalOwe = Math.Max(0, totalExpenses - totalAllowed);
            double totalSaved = Math.Max(0, totalAllowed - totalExpenses);

            //Display results
            label9.Text = totalExpenses.ToString("C");
            label10.Text = totalAllowed.ToString("C");
            label11.Text = totalOwe.ToString("C");
            label12.Text = totalSaved.ToString("C");
        }
    }
}
