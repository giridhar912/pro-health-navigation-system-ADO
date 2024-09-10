using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace pro_health_navigation
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
            panel1.Visible = false; // Hide the panel on form load
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Ensure all fields are populated and not just whitespace
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter all the details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert inputs to integers and calculate the total bill
            if (int.TryParse(textBox2.Text.Trim(), out int numOfTests) &&
                int.TryParse(textBox3.Text.Trim(), out int testCost))
            {
                int totalBill = numOfTests * testCost;
                textBox4.Text = totalBill.ToString();

                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91733\\OneDrive\\Documents\\HNS.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bill (PATIENT_NAME, NUM_OF_TESTS, EACH_TEST_COST, TOTAL_BILL) VALUES (@PATIENT_NAME, @NUM_OF_TESTS, @EACH_TEST_COST, @TOTAL_BILL)", conn);
                    cmd.Parameters.AddWithValue("@PATIENT_NAME", textBox1.Text.Trim()); // Assuming PATIENT_NAME is in textBox3
                    cmd.Parameters.AddWithValue("@NUM_OF_TESTS", numOfTests);
                    cmd.Parameters.AddWithValue("@EACH_TEST_COST", testCost);
                    cmd.Parameters.AddWithValue("@TOTAL_BILL", totalBill);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex) when (ex.Number == 2627) // Unique constraint error
                    {
                        MessageBox.Show("A bill with this patient name already exists. Please use a unique patient name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error while saving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for the number of tests and test cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve data based on the patient name
            string patientName = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(patientName))
            {
                MessageBox.Show("Please enter the patient name to retrieve data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\91733\\OneDrive\\Documents\\HNS.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT NUM_OF_TESTS, EACH_TEST_COST, TOTAL_BILL FROM Bill WHERE PATIENT_NAME = @PATIENT_NAME", conn);
                cmd.Parameters.AddWithValue("@PATIENT_NAME", patientName);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int numOfTests = reader.GetInt32(0);
                        int testCost = reader.GetInt32(1);
                        int totalBill = reader.GetInt32(2);

                        // Display the retrieved data
                        textBox1.Text = numOfTests.ToString();
                        textBox2.Text = testCost.ToString();
                        textBox4.Text = totalBill.ToString();

                        // Display the bill details in the panel
                        panel1.Visible = true;
                        label9.Text = patientName;
                        label10.Text = numOfTests.ToString();
                        label11.Text = testCost.ToString();
                        label12.Text = totalBill.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found for the given patient name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while retrieving the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            panel1.Visible = false; // Hide the panel when clearing fields
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveBillToFile();
        }

        private void SaveBillToFile()
        {
            using (Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height))
            {
                panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png";
                    saveFileDialog.Title = "Save Bill as Image";
                    saveFileDialog.FileName = "PatientBill.png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                            MessageBox.Show("Bill saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while saving the bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
