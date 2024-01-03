using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeeCommApp
{
    public partial class LoginAndReg : Form
    {
        public LoginAndReg()
        {
            InitializeComponent();
        }

        string constring = "Data Source=ZEDD;Initial Catalog=ZeeComm;Integrated Security=True";

        // bring panel that has the login components to the front
        private void loginPanelBTN_Click(object sender, EventArgs e)
        {
            loginPanel.BringToFront();
        }

        // bring panel that has the register components to the front
        private void regPanelBTN_Click(object sender, EventArgs e)
        {
            regPanel.BringToFront();
        }

        private void regBTN_Click(object sender, EventArgs e)
        {
            // checks if any of the fields are empty
            if (profilePicture.Image == null)
            {
                MessageBox.Show("Profile picture cannot be empty!", "Error!");
            }

            if (string.IsNullOrEmpty(firstNameTB.Text.Trim()))
            {
                errorProvider1.SetError(firstNameTB, "Please enter your first name!");
                return;
            }
            else
            {
                errorProvider1.SetError(firstNameTB, string.Empty);
            }

            if (string.IsNullOrEmpty(lastNameTB.Text.Trim()))
            {
                errorProvider1.SetError(lastNameTB, "Please enter your last name!");
                return;
            }
            else
            {
                errorProvider1.SetError(lastNameTB, string.Empty);
            }

            if (string.IsNullOrEmpty(regEmailTB.Text.Trim()))
            {
                errorProvider1.SetError(regEmailTB, "Please enter your email!");
                return;
            }
            else
            {
                errorProvider1.SetError(regEmailTB, string.Empty);
            }

            if (string.IsNullOrEmpty(regPasswordTB.Text.Trim()))
            {
                errorProvider1.SetError(regPasswordTB, "Please set a password!");
                return;
            }
            else
            {
                errorProvider1.SetError(regPasswordTB, string.Empty);
            }

            if (string.IsNullOrEmpty(regConfirmPwTB.Text.Trim()))
            {
                errorProvider1.SetError(regConfirmPwTB, "Please re-enter to confirm your password!");
                return;
            }
            else
            {
                errorProvider1.SetError(regConfirmPwTB, string.Empty);
            }

            if (regPasswordTB.Text != regConfirmPwTB.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error!");
            }
            else
            {
                // if all fields are filled, this will save the info to the database
                SqlConnection con = new SqlConnection(constring);
                string q = "insert into LoginAndReg(firstname, lastname, email, password, confirmpass, image)values(@firstname, @lastname, @email, @password, @confirmpass, @image)";
                SqlCommand cmd = new SqlCommand(q, con);
                MemoryStream me = new MemoryStream();
                profilePicture.Image.Save(me, profilePicture.Image.RawFormat);
                cmd.Parameters.AddWithValue("firstname", firstNameTB.Text);
                cmd.Parameters.AddWithValue("lastname", lastNameTB.Text);
                cmd.Parameters.AddWithValue("email", regEmailTB.Text);
                cmd.Parameters.AddWithValue("password", regPasswordTB.Text);
                cmd.Parameters.AddWithValue("confirmpass", regConfirmPwTB.Text);
                cmd.Parameters.AddWithValue("image", me.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration Successful!", "Success!");
                firstNameTB.Clear();
                lastNameTB.Clear();
                regEmailTB.Clear();
                regPasswordTB.Clear();
                regConfirmPwTB.Clear();
                profilePicture.Image = null;
            }
        }

        // to upload a profile picture
        private void profilePicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*jpg, *png, *gif|*.jpg; *.png; *.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                profilePicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            // checks if any of the fields are empty
            if (string.IsNullOrEmpty(emailTB.Text.Trim()))
            {
                errorProvider1.SetError(emailTB, "Please enter your email!");
                return;
            }
            else
            {
                errorProvider1.SetError(emailTB, string.Empty);
            }

            if (string.IsNullOrEmpty(passwordTB.Text.Trim()))
            {
                errorProvider1.SetError(passwordTB, "Please enter your password!");
                return;
            }
            else
            {
                errorProvider1.SetError(emailTB, string.Empty);
            }

            // retieves email and password from database to match with what
            // you have entered in the login panel
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "Select * from LoginAndReg WHERE email = '" + emailTB.Text + "'AND password = '" + passwordTB.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader;
            dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows == true)
            {
                MyProfile myProfile = new MyProfile();
                this.Hide();
                myProfile.emailName = emailTB.Text;
                myProfile.Show();
            }
            else
            {
                MessageBox.Show("Please ensure your email and password are correct!", "Error!");
            }
            con.Close();
        }

        // minimize app
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        // close app
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginShowPwBTN_Click(object sender, EventArgs e)
        {
            passwordTB.UseSystemPasswordChar = !passwordTB.UseSystemPasswordChar;
        }

        private void regShowPwBTN_Click(object sender, EventArgs e)
        {
            regPasswordTB.UseSystemPasswordChar = !regPasswordTB.UseSystemPasswordChar;
        }

        private void regShowConPwBTN_Click(object sender, EventArgs e)
        {
            regConfirmPwTB.UseSystemPasswordChar = !regConfirmPwTB.UseSystemPasswordChar;
        }
    }
}
