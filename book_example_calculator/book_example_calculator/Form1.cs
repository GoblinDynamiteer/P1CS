using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_example_calculator
{
    public partial class Form1 : Form
    {
        int sum = 0;
        string newNr = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void AddDigit(string digit)
        {
            TextBox.AppendText(digit);
            newNr += digit;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            sum += int.Parse(newNr);
            newNr = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sum += int.Parse(newNr);
            TextBox.Text = "" + Convert.ToString(sum);
            newNr = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            AddDigit("1");
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            AddDigit("2");
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            AddDigit("3");
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            AddDigit("7");
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            AddDigit("9");
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            AddDigit("0");
        }

        private void Btn_8_Click_1(object sender, EventArgs e)
        {
            AddDigit("8");
        }

        private void Btn_5_Click_1(object sender, EventArgs e)
        {
            AddDigit("5");
        }

        private void Btn_4_Click_1(object sender, EventArgs e)
        {
            AddDigit("4");
        }

        private void Btn_6_Click_1(object sender, EventArgs e)
        {
            AddDigit("6");
        }

        private void Btn_7_Click_1(object sender, EventArgs e)
        {
            AddDigit("7");
        }

        private void Btn_9_Click_1(object sender, EventArgs e)
        {
            AddDigit("9");
        }

        private void Btn_0_Click_1(object sender, EventArgs e)
        {
            AddDigit("0");
        }
    }
}
