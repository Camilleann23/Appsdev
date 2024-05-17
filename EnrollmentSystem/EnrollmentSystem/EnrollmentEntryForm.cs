using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class EnrollmentEntryForm : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\1\Desktop\Appsdev-main\Final\PepitoC.accdb";

        public EnrollmentEntryForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menufinal form = new menufinal();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Enter ID Number");
                return;
            }

            if (dataGridView1.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Please add schedule");
                return;
            }

            // Check if student is already enrolled
            bool found = false;
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                {
                    thisCommand.CommandText = "SELECT * FROM ENROLLMENTHEADERFILE";
                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["ENRHFSTUDID"].ToString().Trim().ToUpper() == textBox1.Text.Trim().ToUpper())
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!found)
            {
                // Enroll the student
                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    using (OleDbDataAdapter thisAdapter = new OleDbDataAdapter("Select * From ENROLLMENTHEADERFILE", thisConnection))
                    {
                        using (OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter))
                        {
                            DataSet thisDataSet = new DataSet();
                            thisAdapter.Fill(thisDataSet, "EnrollmentHeaderFile");

                            DataRow thisRow = thisDataSet.Tables["EnrollmentHeaderFile"].NewRow();
                            thisRow["ENRHFSTUDID"] = textBox1.Text;
                            thisRow["ENRHFSTUDDATEENROLL"] = DateTime.Now;
                            thisRow["ENRHFSTUDSCHLYR"] = "2023-2024";
                            thisRow["ENRHFSTUDENCODER"] = "CAMILLE";
                            thisRow["ENRHFSTUDTOTALUNITS"] = UnitsTextBox.Text.Substring((UnitsTextBox.Text.IndexOf(':') + 1));
                            thisRow["ENRHFSTUDSTATUS"] = "EN";

                            thisDataSet.Tables["EnrollmentHeaderFile"].Rows.Add(thisRow);
                            thisAdapter.Update(thisDataSet, "EnrollmentHeaderFile");
                        }
                    }
                }

                // Enroll the student in each class
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                    {
                        thisConnection.Open();
                        using (OleDbDataAdapter thisAdapter = new OleDbDataAdapter("Select * From ENROLLMENTDETAILFILE", thisConnection))
                        {
                            using (OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter))
                            {
                                DataSet thisDataSet = new DataSet();
                                thisAdapter.Fill(thisDataSet, "EnrollmentDetailFile");

                                DataRow thisRow = thisDataSet.Tables["EnrollmentDetailFile"].NewRow();
                                thisRow["ENRDFSTUDID"] = textBox1.Text;
                                thisRow["ENRDFSTUDSUBJCDE"] = row.Cells[1].Value;
                                thisRow["ENRDFSTUDEDPCODE"] = row.Cells[0].Value;

                                thisDataSet.Tables["EnrollmentDetailFile"].Rows.Add(thisRow);
                                thisAdapter.Update(thisDataSet, "EnrollmentDetailFile");
                            }
                        }
                    }

                    // Update class size and status
                    int classSize = 0;
                    using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                    {
                        thisConnection.Open();
                        using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                        {
                            thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                            using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                            {
                                while (thisDataReader.Read())
                                {
                                    if (thisDataReader["SSFEDPCODE"].ToString() == row.Cells[0].Value.ToString())
                                    {
                                        if (thisDataReader["SSFCLASSSIZE"] != DBNull.Value && !string.IsNullOrEmpty(thisDataReader["SSFCLASSSIZE"].ToString()))
                                        {
                                            classSize = Convert.ToInt32(thisDataReader["SSFCLASSSIZE"]);
                                            break;
                                        }
                                        else
                                        {
                                            // Handle the case where SSFCLASSSIZE is DBNull or empty
                                            // For example, set classSize to 0 or handle it according to your application's logic
                                            classSize = 0; // Setting classSize to 0 as an example, replace it with your logic
                                        }
                                    }
                                }
                            }

                            string sql = "UPDATE SUBJECTSCHEDULEFILE SET SSFCLASSSIZE = @ClassSize Where SSFEDPCODE = @EDPCode";
                            string classSizeUpdate = (classSize + 1).ToString();
                            string edpCode = row.Cells[0].Value.ToString();

                            using (OleDbCommand updateCommand = new OleDbCommand(sql, thisConnection))
                            {
                                updateCommand.Parameters.AddWithValue("@ClassSize", classSizeUpdate);
                                updateCommand.Parameters.AddWithValue("@EDPCode", edpCode);
                                updateCommand.ExecuteNonQuery();
                            }

                            thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";
                            using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                            {
                                while (thisDataReader.Read())
                                {
                                    if (thisDataReader["SSFEDPCODE"].ToString() == row.Cells[0].Value.ToString())
                                    {
                                        if (thisDataReader["SSFMAXSIZE"].ToString() == thisDataReader["SSFCLASSSIZE"].ToString())
                                        {
                                            sql = "UPDATE SUBJECTSCHEDULEFILE SET SSFSTATUS = @Status Where SSFEDPCODE = @EDPCode";
                                            string statusUpdate = "IN";

                                            using (OleDbCommand updateCommand = new OleDbCommand(sql, thisConnection))
                                            {
                                                updateCommand.Parameters.AddWithValue("@Status", statusUpdate);
                                                updateCommand.Parameters.AddWithValue("@EDPCode", edpCode);
                                                updateCommand.ExecuteNonQuery();
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Enrolled");
            }
            else
            {
                MessageBox.Show("Student is already enrolled");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                    {
                        string sql = "SELECT * FROM STUDENTFILE";
                        thisCommand.CommandText = sql;

                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            bool found = false;
                            string lastname = "";
                            string firstname = "";
                            string middlename = "";
                            string course = "";
                            int year = 0;

                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["STFSTUDID"].ToString().Trim().ToUpper() == textBox1.Text.Trim().ToUpper())
                                {
                                    lastname = thisDataReader["STFSTUDLNAME"].ToString();
                                    firstname = thisDataReader["STFSTUDFNAME"].ToString();
                                    middlename = thisDataReader["STFSTUDMNAME"].ToString();
                                    course = thisDataReader["STFSTUDCOURSE"].ToString();
                                    year = Convert.ToInt16(thisDataReader["STFSTUDYEAR"]);
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                string fullname = "";
                                if (!string.IsNullOrEmpty(middlename))
                                    fullname = $"{lastname}, {firstname} {middlename[0]}.";
                                else
                                    fullname = $"{lastname}, {firstname}";
                                textBox2.Text = fullname;
                                textBox3.Text = course;
                                textBox4.Text = year.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Student ID not Found");
                            }
                        }
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            string days = "";
            string start = "";
            string end = "";
            bool conflict = false;
            bool closed = false;

            // Fetch schedule details for the given EDP code
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                {
                    thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";

                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == textBox5.Text.Trim().ToUpper())
                            {
                                days = thisDataReader["SSFDAYS"].ToString().ToUpper();
                                start = thisDataReader["SSFSTARTTIME"].ToString();
                                end = thisDataReader["SSFENDTIME"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            // Check for conflicts in the schedule
            for (int i = (dataGridView1.Rows[0].Cells[0].Value != null) ? -1 : 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string daysInDataGrid = dataGridView1.Rows[i + 1].Cells[4].Value.ToString().ToUpper();
                if (days == daysInDataGrid ||
                    (days == "MW" && (daysInDataGrid == "MON" || daysInDataGrid == "WED")) ||
                    (daysInDataGrid == "MW" && (days == "MON" || days == "WED")) ||
                    (days == "MWF" && (daysInDataGrid == "MON" || daysInDataGrid == "WED" || daysInDataGrid == "FRI")) ||
                    (daysInDataGrid == "MWF" && (days == "MON" || days == "WED" || days == "FRI")) ||
                    (days == "TTH" && (daysInDataGrid == "TUE" || daysInDataGrid == "THU")) ||
                    (daysInDataGrid == "TTH" && (days == "TUE" || days == "THU")) ||
                    (days == "TTHS" && (daysInDataGrid == "TUE" || daysInDataGrid == "THU" || daysInDataGrid == "SAT")) ||
                    (daysInDataGrid == "TTHS" && (days == "TUE" || days == "THU" || days == "SAT")) ||
                    (days == "FS" && (daysInDataGrid == "FRI" || daysInDataGrid == "SAT")) ||
                    (daysInDataGrid == "FS" && (days == "FRI" || days == "SAT")))
                {
                    conflict = true;
                    break;
                }
            }

            if (conflict)
            {
                for (int i = (dataGridView1.Rows[0].Cells[0].Value != null) ? -1 : 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    TimeSpan startTime1 = DateTime.Parse(DateTime.Parse(start).ToString("HH:mm")).TimeOfDay;
                    TimeSpan startTime2 = DateTime.Parse(DateTime.Parse(dataGridView1.Rows[i + 1].Cells[2].Value.ToString()).ToString("HH:mm")).TimeOfDay;
                    TimeSpan endTime1 = DateTime.Parse(DateTime.Parse(end).ToString("HH:mm")).TimeOfDay;
                    TimeSpan endTime2 = DateTime.Parse(DateTime.Parse(dataGridView1.Rows[i + 1].Cells[3].Value.ToString()).ToString("HH:mm")).TimeOfDay;

                    if ((startTime1 < endTime2 && endTime1 > startTime2) || (startTime1 == startTime2 && endTime1 == endTime2))
                    {
                        conflict = true;
                        break;
                    }
                    else
                    {
                        conflict = false;
                    }
                }
            }

            // Check if the schedule is closed
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                {
                    thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";

                    using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                    {
                        while (thisDataReader.Read())
                        {
                            if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == textBox5.Text.Trim().ToUpper())
                            {
                                if (thisDataReader["SSFSTATUS"].ToString().Trim().ToUpper() == "IN")
                                {
                                    closed = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (!conflict && !closed)
            {
                if (dataGridView1.Rows[0].Cells[0].Value != null)
                    dataGridView1.Rows.Insert(0, new object[] { });

                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                    {
                        thisCommand.CommandText = "SELECT * FROM SUBJECTSCHEDULEFILE";

                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["SSFEDPCODE"].ToString().Trim().ToUpper() == textBox5.Text.Trim().ToUpper())
                                {
                                    DateTime startTime = DateTime.Parse(thisDataReader["SSFSTARTTIME"].ToString());
                                    DateTime endTime = DateTime.Parse(thisDataReader["SSFENDTIME"].ToString());
                                    dataGridView1.Rows[0].Cells[0].Value = textBox5.Text.Trim().ToUpper();
                                    dataGridView1.Rows[0].Cells[1].Value = thisDataReader["SSFSUBJCODE"].ToString();
                                    dataGridView1.Rows[0].Cells[2].Value = startTime.ToShortTimeString();
                                    dataGridView1.Rows[0].Cells[3].Value = endTime.ToShortTimeString();
                                    dataGridView1.Rows[0].Cells[4].Value = thisDataReader["SSFDAYS"].ToString();
                                    dataGridView1.Rows[0].Cells[5].Value = thisDataReader["SSFROOM"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }

                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    using (OleDbCommand thisCommand = thisConnection.CreateCommand())
                    {
                        thisCommand.CommandText = "SELECT * FROM SUBJECTFILE";

                        using (OleDbDataReader thisDataReader = thisCommand.ExecuteReader())
                        {
                            while (thisDataReader.Read())
                            {
                                if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == dataGridView1.Rows[0].Cells[1].Value.ToString().Trim().ToUpper())
                                {
                                    dataGridView1.Rows[0].Cells[6].Value = thisDataReader["SFSUBJUNITS"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }

                int totalUnits = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[6].Value != null)
                        totalUnits += Convert.ToInt32(row.Cells[6].Value);
                }
                UnitsTextBox.Text = "Units: " + totalUnits;
            }
            else if (conflict)
            {
                MessageBox.Show("Schedule is Conflict");
            }
            else if (closed)
            {
                MessageBox.Show("Schedule is Closed");
            }
        }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
