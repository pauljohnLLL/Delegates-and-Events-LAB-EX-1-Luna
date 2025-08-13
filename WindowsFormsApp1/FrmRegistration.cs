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

        public class StudentInfoClass
        {
            public static string FirstName { get; set; } = "";
            public static string LastName { get; set; } = "";
            public static string MiddleName { get; set; } = "";
            public static string Address { get; set; } = "";
            public static string Program { get; set; } = "";
            public static long Age { get; set; } = 0;
            public static long ContactNo { get; set; } = 0;
            public static long StudentNo { get; set; } = 0;

            public delegate long DelegateNumber(long number);
            public delegate string DelegateText(string txt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfoClass.Program = comboBox1.Text;
            StudentInfoClass.FirstName = textBox3.Text;
            StudentInfoClass.LastName = textBox2.Text;
            StudentInfoClass.MiddleName = textBox7.Text;
            StudentInfoClass.Address = textBox6.Text;

            if (long.TryParse(textBox4.Text, out long age))
            {
                StudentInfoClass.Age = age;
            }
            if (long.TryParse(textBox5.Text, out long contactNo))
            {
                StudentInfoClass.ContactNo = contactNo;
            }
            if (long.TryParse(textBox1.Text, out long studentNo))
            {
                StudentInfoClass.StudentNo = studentNo;
            }

            FrmConfirm frmConfirm = new FrmConfirm(); 
            if (frmConfirm.ShowDialog() == DialogResult.OK)
            {           
                comboBox1.Text = ""; textBox3.Text = ""; textBox2.Text = ""; textBox7.Text = ""; textBox6.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox1.Text = "";
            }          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("BS Information Technology");
            comboBox1.Items.Add("BS Computer Science");
            comboBox1.Items.Add("BS Business Administration");
            comboBox1.Items.Add("BS Hospitality Management");
        }
    }
}
    



