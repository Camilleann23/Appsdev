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
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"\\\\Server2\\second semester 2023-2024\\LAB802\\79286_CC_APPSDEV22_1030_1230_PM_MW\\79286-23234826\\Desktop\\Final\\PepitoC.accdb\"";
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
            OleDbConnection thisConnection= new OleDbConnection(connectionString);
            string Ole = "Select * From SubjectFile"; 
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter); 
            DataSet thisDataset= new DataSet();
            thisAdapter.Fill(thisDataset, "SubjectFile");

            DataRow thisRow = thisDataset.Tables["SubjectFile"].NewRow();
            thisRow["SFSUBJCODE"] = Convert.ToInt16(SubjectCodeTextBox.Text);
            thisRow["SFSUBJDESC"] = DescriptionTextBox.Text;/
            thisRow["SFSUBJUNITS"] = UnitsTextBox.Text;
            thisRow["SFSUBJREGOFRING"] = OfferingComboBox.Text.Substring(0, 1);
            thisRow["SFSUBJCATEGORY"] = CategoryComboBox.Text.Substring(0, 1);
            thisRow["SFSUBJSTATUS"] = "AC";
            thisRow["SFSUBJCOURSECODE"] = CourseCodeComboBox.Text;
            thisRow["SFSUBJCURRCODE"] = CurriculumYearTextBox.Text;

            thisDataset.Tables["SubjectFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataset, "SubjectFile");

            MessageBox.Show("Recorded");
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
                    if (thisDataReader["SFSSUBJCODE"].ToString().Trim().ToUpper()== RequisiteTextBox.Text.Trim().ToUpper())
                    {  
                        found = true;  
                        subjectCode= thisDataReader["SFSSUBJCODE"].ToString(); 
                        description= thisDataReader["SFSSUBJDESC"].ToString();  
                        units= thisDataReader["SFSSUBJUNITS"].ToString() ;
                        break; 

                    }
                }
                if (found == false)
                    MessageBox.Show("Subject Code not found");
                else
                {
                    SubjectDataGridView.Rows[0].Cells[0].Value = subjectCode;
                    SubjectDataGridView.Rows[0].Cells[0].Value = subjectCode;
                    SubjectDataGridView.Rows[0].Cells[0].Value = units;


                }
            }
        }

        private void CourseCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

