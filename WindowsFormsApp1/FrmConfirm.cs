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
        //private StudentInfoClass.DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;
        //private StudentInfoClass.DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;
        public FrmConfirm()
        {
            InitializeComponent();
            //DelProgram = new StudentInfoClass.DelegateText(GetProgram);
            //DelFirstName = new StudentInfoClass.DelegateText(GetFirstName);
            //DelLastName = new StudentInfoClass.DelegateText(GetLastName);
            //DelMiddleName = new StudentInfoClass.DelegateText(GetMiddleName);
            //DelAddress = new StudentInfoClass.DelegateText(GetAddress);
            //DelNumAge = new StudentInfoClass.DelegateNumber(GetAge);
            //DelNumContactNo = new StudentInfoClass.DelegateNumber(GetContactNo);
            //DelStudNo = new StudentInfoClass.DelegateNumber(GetStudentNo);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthday;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();

            //label1.Text = DelStudNo(StudentInfoClass.StudentNo).ToString(); 
            //label2.Text = DelProgram(StudentInfoClass.Program); 
            //label4.Text = DelLastName(StudentInfoClass.LastName);  
            //label16.Text = DelFirstName(StudentInfoClass.FirstName);
            //label3.Text = DelMiddleName(StudentInfoClass.MiddleName); 
            //label6.Text = DelNumAge(StudentInfoClass.Age).ToString(); 
            //label5.Text = DelNumContactNo(StudentInfoClass.ContactNo).ToString();
            //label7.Text = DelAddress(StudentInfoClass.Address);
        }      
        //private string GetFirstName(string firstName) { return StudentInfoClass.FirstName; }
        //private string GetLastName(string lastName) { return StudentInfoClass.LastName; }
        //private void button1_Click(object sender, EventArgs e)
        //{      
        //    MessageBox.Show("Your Information Is Already Submitted!  Thank You!", "Data Saved!");
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    this.DialogResult = DialogResult.OK;
        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        //private string GetMiddleName(string middleName) { return StudentInfoClass.MiddleName; }
        //private string GetAddress(string address) { return StudentInfoClass.Address; }
        //private string GetProgram(string program) { return StudentInfoClass.Program; }
        //private long GetAge(long age) { return StudentInfoClass.Age; }
        //private long GetContactNo(long contactNo) { return StudentInfoClass.ContactNo; }
        //private long GetStudentNo(long studentNo) { return StudentInfoClass.StudentNo; }
    }
}