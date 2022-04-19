using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_Abstraction_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for(int i = 0; i < readAllLine.Length; i++)
                {
                    string allDATASRAW = readAllLine[i];
                    string[] allDATAsplited = allDATASRAW.Split(',');
                    this.dataGridView2.Rows.Add(allDATAsplited[0], allDATASRAW[1], allDATASRAW[2], allDATASRAW[3]);
                }

            }

        }

        private double sum1 = 0;
        private double sum2 = 1;


        private void button1_Click(object sender, EventArgs e)
        {
            this.sum1 += sum2;

            string User_or_Id = textBoxUser_or_Id.Text;
            string Password = textBoxPassword.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = "staff";
            dataGridView1.Rows[n].Cells[1].Value = sum1;
            dataGridView1.Rows[n].Cells[2].Value = User_or_Id;
            dataGridView1.Rows[n].Cells[3].Value = Password;

            textBoxUser_or_Id.Text = "";
            textBoxPassword.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Major = comboBoxMajor.Text;
            string SSID = textBoxSSID.Text;
            string Name = textBoxName.Text;
            string Password = textBoxPassword2.Text;

            int n = dataGridView2.Rows.Add();

            if( Major == "Staff")
            {
                Staff staff = new Staff();

                staff.Name = Name;
                staff.Password = Password;
                staff.SSID = SSID; 

                dataGridView2.Rows[n].Cells[2].Value=staff.Name;
                dataGridView2.Rows[n].Cells[3].Value=staff.Password;
                dataGridView2.Rows[n].Cells[1].Value=staff.SSID;
            }
            if(Major == "Teacher")
            {
                Teacher teacher = new Teacher();

                teacher.Name = Name;
                teacher.Major = Major;
                teacher.SSID = SSID;

                dataGridView2.Rows[n].Cells[2].Value = teacher.Name;
                dataGridView2.Rows[n].Cells[3].Value = teacher.Major;
                dataGridView2.Rows[n].Cells[1].Value = teacher.SSID;
            }
            if(Major == "Student")
            {
                Student student = new Student();

                student.Name = Name;
                student.SSID = SSID;

                dataGridView2.Rows[n].Cells[2].Value = student.Name;
                dataGridView2.Rows[n].Cells[1].Value = student.SSID;
            }

            comboBoxMajor.Text = "";
            textBoxSSID.Text = "";
            textBoxName.Text = "";
            textBoxPassword2.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV(*.csv) | *.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columCount = dataGridView2.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView2.Rows.Count + 1];
                            for(int i = 0; i < columCount; i++)
                            {
                                column += dataGridView2.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column += column;
                            for (int i = 1; (i - 1) < dataGridView2.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                                {
                                    outputCSV[i] += dataGridView2.Rows[i - 1].Cells[j].Value .ToString() + ","; 
                                }
                            }
                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
