using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_health_navigation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "siva.naredla14@gmail.com" && textBox2.Text == "2222")
            {
                MessageBox.Show("successfully logined");
                Form3 form3 = new Form3();
                form3.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("tryagain");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}