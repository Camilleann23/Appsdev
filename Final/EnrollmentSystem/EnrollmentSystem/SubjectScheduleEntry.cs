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
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"\\\\Server2\\second semester 2023-2024\\LAB802\\79286_CC_APPSDEV22_1030_1230_PM_MW\\79286-23234826\\Desktop\\Final\\PepitoC.accdb\"";
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
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string Ole = "Select * From SubjectFile";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(Ole, thisConnection);
            OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
            DataSet thisDataset = new DataSet();
            thisAdapter.Fill(thisDataset, "SubjectFile");

            DataRow thisRow = thisDataset.Tables["SubjectFile"].NewRow();
            thisRow["SSFEDPCODE"] = Convert.ToInt16(EDPtextBox.Text);
            thisRow["SSFSUBJCODE"] = SubjectCodeTextBox.Text;
            thisRow["SSFSTARTTIME"] = DateTimePicker1.Text;
            thisRow["SSFENDTIME"] = DateTimePicker2.Text.Substring(0, 1);
            thisRow["SSFDAYS"] = DaystextBox.Text.Substring(0, 1);
            thisRow["SSFROOM"] = RoomTextBox.Text;
            thisRow["SSFMAXSIZE"] = RoomTextBox.Text;
            thisRow["SSFCLASSSIZE"] = SectionTextBox.Text;
            thisRow["SFSUBJREGOFRING"] = AMPMComboBox.Text.Substring(0,1);


            thisDataset.Tables["SubjectFile"].Rows.Add(thisRow);
            thisAdapter.Update(thisDataset, "SubjectScheduleFile");
             MessageBox.Show("Recorded");
        }
    }
}
