using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class StudentInformationClass
        {
            public static int SetStudentNo { get; set; } = 0;
            public static string SetFullName { get; set; } = "";
            public static string SetProgram { get; set; } = "";
            public static string SetGender { get; set; } = "";
            public static string SetBirthday { get; set; } = "";
            public static long SetContactNo { get; set; } = 0;
            public static int SetAge { get; set; } = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");

                
                FrmConfirm confirmForm = new FrmConfirm();
                confirmForm.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Format error: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Missing/invalid input: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Number too large: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Value out of range: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("BS Information Technology");
            comboBox1.Items.Add("BS Computer Science");
            comboBox1.Items.Add("BS Business Administration");
            comboBox1.Items.Add("BS Hospitality Management");
        }


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
    



