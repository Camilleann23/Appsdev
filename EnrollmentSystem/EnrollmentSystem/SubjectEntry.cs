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
    public partial class SubjectEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\1\Desktop\Appsdev-main\Final\PepitoC.accdb";
        public SubjectEntry()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string is invalid.");
                return;
            }

            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                // Open the connection
                thisConnection.Open();

                string Ole = "Select * From SUBJECTFILE";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
                OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
                DataSet thisDataset = new DataSet();

                // Fill the dataset with data from the SUBJECTFILE table
                thisAdapter.Fill(thisDataset, "SubjectFile");

                // Check if required fields are not empty and UnitsTextBox contains only numbers
                if (string.IsNullOrEmpty(SubjectCodeTextBox.Text) ||
                    string.IsNullOrEmpty(DescriptionTextBox.Text) ||
                    string.IsNullOrEmpty(UnitsTextBox.Text) ||
                    string.IsNullOrEmpty(OfferingComboBox.Text) ||
                    string.IsNullOrEmpty(CategoryComboBox.Text) ||
                    string.IsNullOrEmpty(CourseCodeComboBox.Text) ||
                    string.IsNullOrEmpty(CurriculumYearTextBox.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (!int.TryParse(UnitsTextBox.Text, out _))
                {
                    MessageBox.Show("Units must be a numeric value.");
                    return;
                }

                // Check for duplicate Subject Code
                DataRow[] existingRows = thisDataset.Tables["SubjectFile"].Select($"SFSUBJCODE = '{SubjectCodeTextBox.Text}'");
                if (existingRows.Length > 0)
                {
                    MessageBox.Show("A subject with this code already exists.");
                    return;
                }

                // Create a new row and add data
                DataRow thisRow = thisDataset.Tables["SubjectFile"].NewRow();
                thisRow["SFSUBJCODE"] = SubjectCodeTextBox.Text;
                thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;
                thisRow["SFSUBJUNITS"] = UnitsTextBox.Text;
                thisRow["SFSUBJREGOFRING"] = OfferingComboBox.Text.Substring(0, 1);
                thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 1);
                thisRow["SFSUBJSTATUS"] = "AC";
                thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
                thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

                thisDataset.Tables["SubjectFile"].Rows.Add(thisRow);

                if (PreRadioButton.Checked || (radioButton2.Checked && RequisiteTextBox.Text != string.Empty))
                {
                    Requisite();
                }

                // Update the dataset and save changes to the database
                thisAdapter.Update(thisDataset, "SubjectFile");
                MessageBox.Show("Recorded");
            }
        }

        private void RequisiteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection= new OleDbConnection(connectionString); 
                thisConnection.Open();
                OleDbCommand thisCommand =thisConnection.CreateCommand(); 
                 
                string sql = "SELECT * FROM SUBJECTFILE"; 
                thisCommand.CommandText = sql;

                OleDbDataReader thisDataReader = thisCommand.ExecuteReader(); 
                //  
                bool found = false;
                string subjectCode = "";
                string description = "";
                string units = ""; 
                 
                while(thisDataReader.Read())
                {
                    //MessageBox.Show("thisDataReader["SFSSUBJCODE"]".ToString());
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper()== RequisiteTextBox.Text.Trim().ToUpper())
                    {  
                        found = true;  
                        subjectCode= thisDataReader["SFSUBJCODE"].ToString(); 
                        description= thisDataReader["SFSUBJDESC"].ToString();  
                        units= thisDataReader["SFSUBJUNITS"].ToString() ;
                        break; 

                    }
                }
                if (found == false)
                    MessageBox.Show("Subject Code not found");
                else
                {
                    SubjectDataGridView.Rows[0].Cells[0].Value = subjectCode;
                    SubjectDataGridView.Rows[0].Cells[1].Value = subjectCode;
                    SubjectDataGridView.Rows[0].Cells[2].Value = units;
                }

                OleDbConnection requisiteConnection = new OleDbConnection(connectionString);
                requisiteConnection.Open();
                OleDbCommand requisiteCommand = requisiteConnection.CreateCommand();

                string requisitesql = "Select * From SubjectPreqFile";
                requisiteCommand.CommandText = requisitesql;

                OleDbDataReader requisiteDataReader = requisiteCommand.ExecuteReader();
                while (requisiteDataReader.Read())
                {
                    if (requisiteDataReader["SUBJCODE"].ToString().Trim().ToUpper() == RequisiteTextBox.Text.Trim().ToUpper())
                    {
                        SubjectDataGridView.Rows[0].Cells[3].Value = requisiteDataReader["SUBJPRECODE"].ToString().Trim().ToUpper();
                        break;
                    }
                    else
                        SubjectDataGridView.Rows[0].Cells[3].Value = string.Empty;
                }

            }
        }

        public void Requisite()
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From SubjectPreqFile";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();

            thisAdapter.Fill(thisDataSet, "SubjectPreqFile");

            DataRow thisRow = thisDataSet.Tables["SubjectPreqFile"].NewRow();
            thisRow["SUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SUBJPRECODE"] = RequisiteTextBox.Text;

            if (PreRadioButton.Checked)
                thisRow["SUBJCATEGORY"] = "PR";
            else
                thisRow["SUBJCATEGORY"] = "CR";


            thisDataSet.Tables["SubjectPreqFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataSet, "SubjectPreqFile");

        }

        private void CourseCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menufinal form = new menufinal();
            form.Show();
            this.Hide();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            SubjectCodeTextBox.Text = null;
            DescriptionTextBox.Text = null;
            UnitsTextBox.Text = null;
            OfferingComboBox.Text = null;
            CategoryComboBox.Text = null;
            CourseCodeComboBox.Text = null;
            CurriculumYearTextBox.Text = null;
            RequisiteTextBox.Text = null;
        }
    }
}

