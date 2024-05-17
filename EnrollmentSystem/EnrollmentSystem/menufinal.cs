using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class menufinal : Form
    {
        public menufinal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubjectEntry subEntry = new SubjectEntry();
            subEntry.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry subSched = new SubjectScheduleEntry();
            subSched.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           EnrollmentEntryForm form = new EnrollmentEntryForm();
        form.Show();
            this.Hide();
        }
    }
}
