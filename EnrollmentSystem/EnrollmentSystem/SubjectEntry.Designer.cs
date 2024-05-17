namespace EnrollmentSystem
{
    partial class SubjectEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CourseCodeComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.OfferingComboBox = new System.Windows.Forms.ComboBox();
            this.CurriculumYearTextBox = new System.Windows.Forms.TextBox();
            this.UnitsTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SubjectCodeTextBox = new System.Windows.Forms.TextBox();
            this.CurriculumYlabel = new System.Windows.Forms.Label();
            this.CourseClabel = new System.Windows.Forms.Label();
            this.Categorylabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Unitslabel = new System.Windows.Forms.Label();
            this.Descriptionlabel = new System.Windows.Forms.Label();
            this.SubjectClabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SubjectDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.PreRadioButton = new System.Windows.Forms.RadioButton();
            this.RequisiteTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject Entry";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox1.Controls.Add(this.CourseCodeComboBox);
            this.groupBox1.Controls.Add(this.CategoryComboBox);
            this.groupBox1.Controls.Add(this.OfferingComboBox);
            this.groupBox1.Controls.Add(this.CurriculumYearTextBox);
            this.groupBox1.Controls.Add(this.UnitsTextBox);
            this.groupBox1.Controls.Add(this.DescriptionTextBox);
            this.groupBox1.Controls.Add(this.SubjectCodeTextBox);
            this.groupBox1.Controls.Add(this.CurriculumYlabel);
            this.groupBox1.Controls.Add(this.CourseClabel);
            this.groupBox1.Controls.Add(this.Categorylabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Unitslabel);
            this.groupBox1.Controls.Add(this.Descriptionlabel);
            this.groupBox1.Controls.Add(this.SubjectClabel);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subject Information";
            // 
            // CourseCodeComboBox
            // 
            this.CourseCodeComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.CourseCodeComboBox.FormattingEnabled = true;
            this.CourseCodeComboBox.Items.AddRange(new object[] {
            "BSIT ",
            "BSIS ",
            "ACT ",
            "BSMT ",
            "BSTM ",
            "BSHM"});
            this.CourseCodeComboBox.Location = new System.Drawing.Point(122, 218);
            this.CourseCodeComboBox.Name = "CourseCodeComboBox";
            this.CourseCodeComboBox.Size = new System.Drawing.Size(104, 23);
            this.CourseCodeComboBox.TabIndex = 14;
            this.CourseCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseCodeComboBox_SelectedIndexChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "LAB ",
            "LEC"});
            this.CategoryComboBox.Location = new System.Drawing.Point(122, 181);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(104, 23);
            this.CategoryComboBox.TabIndex = 13;
            // 
            // OfferingComboBox
            // 
            this.OfferingComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.OfferingComboBox.FormattingEnabled = true;
            this.OfferingComboBox.Items.AddRange(new object[] {
            "1 ",
            "2 ",
            "3"});
            this.OfferingComboBox.Location = new System.Drawing.Point(122, 140);
            this.OfferingComboBox.Name = "OfferingComboBox";
            this.OfferingComboBox.Size = new System.Drawing.Size(104, 23);
            this.OfferingComboBox.TabIndex = 12;
            // 
            // CurriculumYearTextBox
            // 
            this.CurriculumYearTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.CurriculumYearTextBox.Location = new System.Drawing.Point(126, 250);
            this.CurriculumYearTextBox.Name = "CurriculumYearTextBox";
            this.CurriculumYearTextBox.Size = new System.Drawing.Size(100, 20);
            this.CurriculumYearTextBox.TabIndex = 11;
            // 
            // UnitsTextBox
            // 
            this.UnitsTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.UnitsTextBox.Location = new System.Drawing.Point(122, 105);
            this.UnitsTextBox.Name = "UnitsTextBox";
            this.UnitsTextBox.Size = new System.Drawing.Size(100, 20);
            this.UnitsTextBox.TabIndex = 10;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.DescriptionTextBox.Location = new System.Drawing.Point(122, 67);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 9;
            // 
            // SubjectCodeTextBox
            // 
            this.SubjectCodeTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.SubjectCodeTextBox.Location = new System.Drawing.Point(122, 32);
            this.SubjectCodeTextBox.Name = "SubjectCodeTextBox";
            this.SubjectCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubjectCodeTextBox.TabIndex = 8;
            // 
            // CurriculumYlabel
            // 
            this.CurriculumYlabel.AutoSize = true;
            this.CurriculumYlabel.Location = new System.Drawing.Point(28, 255);
            this.CurriculumYlabel.Name = "CurriculumYlabel";
            this.CurriculumYlabel.Size = new System.Drawing.Size(92, 15);
            this.CurriculumYlabel.TabIndex = 7;
            this.CurriculumYlabel.Text = "Curriculum Year";
            // 
            // CourseClabel
            // 
            this.CourseClabel.AutoSize = true;
            this.CourseClabel.Location = new System.Drawing.Point(28, 221);
            this.CourseClabel.Name = "CourseClabel";
            this.CourseClabel.Size = new System.Drawing.Size(65, 15);
            this.CourseClabel.TabIndex = 6;
            this.CourseClabel.Text = "Course Code";
            // 
            // Categorylabel
            // 
            this.Categorylabel.AutoSize = true;
            this.Categorylabel.Location = new System.Drawing.Point(28, 181);
            this.Categorylabel.Name = "Categorylabel";
            this.Categorylabel.Size = new System.Drawing.Size(49, 15);
            this.Categorylabel.TabIndex = 5;
            this.Categorylabel.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Offering";
            // 
            // Unitslabel
            // 
            this.Unitslabel.AutoSize = true;
            this.Unitslabel.Location = new System.Drawing.Point(28, 105);
            this.Unitslabel.Name = "Unitslabel";
            this.Unitslabel.Size = new System.Drawing.Size(33, 15);
            this.Unitslabel.TabIndex = 3;
            this.Unitslabel.Text = "Units";
            // 
            // Descriptionlabel
            // 
            this.Descriptionlabel.AutoSize = true;
            this.Descriptionlabel.Location = new System.Drawing.Point(28, 67);
            this.Descriptionlabel.Name = "Descriptionlabel";
            this.Descriptionlabel.Size = new System.Drawing.Size(64, 15);
            this.Descriptionlabel.TabIndex = 2;
            this.Descriptionlabel.Text = "Description";
            // 
            // SubjectClabel
            // 
            this.SubjectClabel.AutoSize = true;
            this.SubjectClabel.Location = new System.Drawing.Point(28, 37);
            this.SubjectClabel.Name = "SubjectClabel";
            this.SubjectClabel.Size = new System.Drawing.Size(69, 15);
            this.SubjectClabel.TabIndex = 1;
            this.SubjectClabel.Text = "Subject Code";
            this.SubjectClabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RosyBrown;
            this.groupBox2.Controls.Add(this.SubjectDataGridView);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.PreRadioButton);
            this.groupBox2.Controls.Add(this.RequisiteTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(344, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 241);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requisite Information";
            // 
            // SubjectDataGridView
            // 
            this.SubjectDataGridView.BackgroundColor = System.Drawing.Color.Linen;
            this.SubjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.SubjectDataGridView.Location = new System.Drawing.Point(6, 77);
            this.SubjectDataGridView.Name = "SubjectDataGridView";
            this.SubjectDataGridView.Size = new System.Drawing.Size(386, 127);
            this.SubjectDataGridView.TabIndex = 19;
            this.SubjectDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Subject Code";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Units";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Co/Pre";
            this.Column4.Name = "Column4";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(241, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 19);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Co-requisite";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // PreRadioButton
            // 
            this.PreRadioButton.AutoSize = true;
            this.PreRadioButton.Location = new System.Drawing.Point(241, 19);
            this.PreRadioButton.Name = "PreRadioButton";
            this.PreRadioButton.Size = new System.Drawing.Size(96, 19);
            this.PreRadioButton.TabIndex = 17;
            this.PreRadioButton.TabStop = true;
            this.PreRadioButton.Text = "Pre- Requisite";
            this.PreRadioButton.UseVisualStyleBackColor = true;
            this.PreRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RequisiteTextBox
            // 
            this.RequisiteTextBox.Location = new System.Drawing.Point(95, 32);
            this.RequisiteTextBox.Name = "RequisiteTextBox";
            this.RequisiteTextBox.Size = new System.Drawing.Size(100, 20);
            this.RequisiteTextBox.TabIndex = 16;
            this.RequisiteTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RequisiteTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Subject Code";
            // 
            // Savebutton
            // 
            this.Savebutton.BackColor = System.Drawing.Color.Linen;
            this.Savebutton.Location = new System.Drawing.Point(287, 386);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(75, 39);
            this.Savebutton.TabIndex = 3;
            this.Savebutton.Text = "Save";
            this.Savebutton.UseVisualStyleBackColor = false;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.BackColor = System.Drawing.Color.Linen;
            this.Cancelbutton.Location = new System.Drawing.Point(399, 386);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 39);
            this.Cancelbutton.TabIndex = 4;
            this.Cancelbutton.Text = "Clear";
            this.Cancelbutton.UseVisualStyleBackColor = false;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubjectEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(754, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "SubjectEntry";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label SubjectClabel;
        private System.Windows.Forms.Label CurriculumYlabel;
        private System.Windows.Forms.Label CourseClabel;
        private System.Windows.Forms.Label Categorylabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Unitslabel;
        private System.Windows.Forms.Label Descriptionlabel;
        private System.Windows.Forms.ComboBox CourseCodeComboBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.ComboBox OfferingComboBox;
        private System.Windows.Forms.TextBox CurriculumYearTextBox;
        private System.Windows.Forms.TextBox UnitsTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox SubjectCodeTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton PreRadioButton;
        private System.Windows.Forms.TextBox RequisiteTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView SubjectDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button button1;
    }
}

