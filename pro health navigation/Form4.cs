using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_health_navigation
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text ==  "")
            {
                MessageBox.Show("Enter your details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91733\\OneDrive\\Documents\\s.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into s values(@NAME,@PHN_NO,@GMAIL,@BLOOD_GROUP,@AGE,@DISEASE,@CONDITION)", conn);
                cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@PHN_NO", textBox2.Text);
                cmd.Parameters.AddWithValue("@GMAIL", textBox3.Text);
                cmd.Parameters.AddWithValue("@BLOOD_GROUP", textBox4.Text);
                cmd.Parameters.AddWithValue("@AGE", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@DISEASE", textBox6.Text);
                cmd.Parameters.AddWithValue("@CONDITION", textBox7.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Succesfully created");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91733\\OneDrive\\Documents\\s.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("update s set NAME=@NAME,PHN_NO=@PHN_NO,GMAIL=@GMAIL,BLOOD_GROUP=@BLOOD_GROUP,AGE=@AGE,DISEASE=@DISEASE,CONDITION=@CONDITION where NAME=@NAME", conn);
                cmd1.Parameters.AddWithValue("@NAME", textBox1.Text);
                cmd1.Parameters.AddWithValue("@PHN_NO", textBox2.Text);
                cmd1.Parameters.AddWithValue("@GMAIL", textBox3.Text);
                cmd1.Parameters.AddWithValue("@BLOOD_GROUP", textBox4.Text);
                cmd1.Parameters.AddWithValue("@AGE", Convert.ToInt32(textBox5.Text));
                cmd1.Parameters.AddWithValue("@DISEASE", textBox6.Text);
                cmd1.Parameters.AddWithValue("@CONDITION", textBox7.Text);
                cmd1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Succesfully Updated");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91733\\OneDrive\\Documents\\s.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("delete s where NAME=@NAME", conn);
                cmd2.Parameters.AddWithValue("@NAME", textBox1.Text);
                cmd2.Parameters.AddWithValue("@PHN_NO", textBox2.Text);
                cmd2.Parameters.AddWithValue("@GMAIL", textBox3.Text);
                cmd2.Parameters.AddWithValue("@BLOOD_GROUP", textBox4.Text);
                cmd2.Parameters.AddWithValue("@AGE", Convert.ToInt32(textBox5.Text));
                cmd2.Parameters.AddWithValue("@DISEASE", textBox6.Text);
                cmd2.Parameters.AddWithValue("@CONDITION", textBox7.Text);
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Succesfully deleted");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Succesfully cleared");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textUsername_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}