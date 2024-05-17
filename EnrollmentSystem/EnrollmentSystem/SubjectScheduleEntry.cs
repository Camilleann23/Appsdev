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
    public partial class SubjectScheduleEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\1\Desktop\Appsdev-main\Final\PepitoC.accdb";
        public SubjectScheduleEntry()
        {
            InitializeComponent();
        }

        private void SubjectScheduleEntry_Load(object sender, EventArgs e)
        {

        }

        private void AMPMComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Ensure the connection string is not empty or null
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string is invalid.");
            }
            else
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string Ole = "Select * From SUBJECTSCHEDULEFILE";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();

                try
                {
                    thisConnection.Open();

                    thisAdapter.Fill(thisDataset, "SubjectScheduleFile");

                    // Check if the required fields are not empty and if Days, Room, and Curriculum Year are numeric
                    if (string.IsNullOrEmpty(EDPtextBox.Text) ||
                        string.IsNullOrEmpty(SubjectCodeTextBox.Text) ||
                        string.IsNullOrEmpty(DateTimePicker1.Text) ||
                        string.IsNullOrEmpty(DateTimePicker2.Text) ||
                        string.IsNullOrEmpty(DaystextBox.Text) ||
                        string.IsNullOrEmpty(RoomTextBox.Text) ||
                        string.IsNullOrEmpty(SectionTextBox.Text) ||
                        string.IsNullOrEmpty(AMPMComboBox.Text))
                    {
                        MessageBox.Show("Please fill in all fields.");
                    }
                   
                   else if (!int.TryParse(RoomTextBox.Text, out _))
                    {
                        MessageBox.Show("Room must be a numeric value.");
                    }
                   
                    else
                    {
                        DataRow thisRow = thisDataset.Tables["SubjectScheduleFile"].NewRow();
                        thisRow["SSFEDPCODE"] = EDPtextBox.Text;
                        thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
                        thisRow["SSFSTARTTIME"] = DateTimePicker1.Text;
                        thisRow["SSFENDTIME"] = DateTimePicker2.Text;
                        thisRow["SSFDAYS"] = DaystextBox.Text;
                        thisRow["SSFROOM"] = RoomTextBox.Text;
                        thisRow["SSFSECTION"] = SectionTextBox.Text;
                        thisRow["SSFXM"] = AMPMComboBox.Text.Substring(0, 2);

                        thisDataset.Tables["SubjectScheduleFile"].Rows.Add(thisRow);

                        try
                        {
                            thisAdapter.Update(thisDataset, "SubjectScheduleFile");
                            MessageBox.Show("Recorded");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while updating the dataset: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    thisConnection.Close();
                }
            }
        
        }

        private void SubjectCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();

                string sql = "SELECT * FROM SUBJECTFILE";
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();
                //  
                bool found = false;
               
                string description = "";
               

                while (thisDataReader.Read())
                {
                    //MessageBox.Show("thisDataReader["SFSSUBJCODE"]".ToString());
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBox.Text.Trim().ToUpper())
                    {
                        found = true;
                        
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        
                        break;

                        

                    }
                    
                }
                if (found == false)
                    MessageBox.Show("Subject Code not found");
                else {
                    DescriptionLabel2.Text = description;

                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menufinal form = new menufinal();
            form.Show();
            this.Hide();

        }

        private void DescriptionLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
