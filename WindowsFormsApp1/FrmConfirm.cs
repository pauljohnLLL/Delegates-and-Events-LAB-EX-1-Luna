using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Form1;
using static WindowsFormsApp1.Form1.StudentInformationClass;

namespace WindowsFormsApp1
{
    public partial class FrmConfirm : Form
    {
        public FrmConfirm()
        {
            InitializeComponent();
          
        }                      
        private void FrmConfirm_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthday;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Your Information is Submitted! ", " Data Saved! ");
            Application.Exit();
        }
    }
}