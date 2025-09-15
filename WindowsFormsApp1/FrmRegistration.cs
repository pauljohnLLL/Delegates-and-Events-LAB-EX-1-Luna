using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public Form1()
        {

            InitializeComponent();
        }

        public class StudentInformationClass
        {
            public static long SetStudentNo { get; set; } = 0;
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

                using (SqlConnection con = new SqlConnection(
            "Data Source=ASUS\\SQLEXPRESS;Initial Catalog=RegistrationDB;Integrated Security=True"))
                {
                    con.Open();

                    string query = "INSERT INTO Students (StudentNo, FirstName, LastName, MiddleInitial, Age, Gender, Program, ContactNo, Birthday) " +
                                   "VALUES (@StudentNo, @FirstName, @LastName, @MiddleInitial, @Age, @Gender, @Program, @ContactNo, @Birthday)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StudentNo", txtStudentNo.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@MiddleInitial", txtMiddleInitial.Text);
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                        cmd.Parameters.AddWithValue("@Program", cbPrograms.Text);
                        cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                        cmd.Parameters.AddWithValue("@Birthday", datePickerBirtday.Value);

                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                }
                MessageBox.Show("Record saved to database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);               
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
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("The Student Number you entered already exists. Please enter a unique Student Number.",
                                    "Duplicate Student Number",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

        }
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{11}$"))
            {
                if (long.TryParse(studNum, out long result))
                {
                    _StudentNo = result;
                    return _StudentNo;
                }
                else
                {
                    throw new FormatException("Student number is not numeric.");
                }
            }
            else
            {
                throw new ArgumentNullException("Student number must be 11 digits.");
            }
        }
        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                if (long.TryParse(Contact, out long result))
                {
                    if (Contact.Length > 11)
                        throw new OverflowException("Contact number too long.");

                    _ContactNo = result;
                    return _ContactNo;
                }
                else
                {
                    throw new FormatException("Contact number is not numeric.");
                }
            }
            else
            {
                throw new ArgumentNullException("Contact number must be 10–11 digits.");
            }
        }
        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(FirstName, @"^[a-zA-Z ]+$") &&
                Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + " " + MiddleInitial + ".";
                return _FullName;
            }
            else
            {
                throw new ArgumentNullException("Full name fields cannot be empty or contain numbers.");
            }
        }
        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                if (int.TryParse(age, out int result))
                {
                    if (result > 0 && result < 150)
                    {
                        _Age = result;
                        return _Age;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Age must be between 1 and 150.");
                    }
                }
                else
                {
                    throw new FormatException("Age is not numeric.");
                }
            }
            else
            {
                throw new ArgumentNullException("Age field cannot be empty.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cbPrograms.Items.Clear();
            cbGender.Items.Clear();
            string[] ListOfProgram = new string[]
            {
        "BS Information Technology",
        "BS Computer Science",
        "BS Information Systems",
        "BS in Accountancy",
        "BS in Hospitality Management",
        "BS in Tourism Management"
            };

            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i]);
            }
            string[] ListOfGender = new string[]
            {
        "Male",
        "Female"
            };

            for (int i = 0; i < ListOfGender.Length; i++)
            {
                cbGender.Items.Add(ListOfGender[i]);
            }
        }
    }
}
        






