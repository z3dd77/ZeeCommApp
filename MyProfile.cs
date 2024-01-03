using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using ZeeCommApp.Properties;

namespace ZeeCommApp
{
    public partial class MyProfile : Form
    {
        public string emailName { set; get; }
        public MyProfile()
        {
            InitializeComponent();
        }

        string constring = "Data Source=ZEDD;Initial Catalog=ZeeComm;Integrated Security=True";

        // same function as logout, returns to the LoginAndReg form
        private void returnBTN_Click(object sender, EventArgs e)
        {
            LoginAndReg loginAndReg = new LoginAndReg();
            this.Hide();
            loginAndReg.Show();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(timer2_Tick);
            timer.Start();

            // depending on the email you logged in with
            // this displays the first name linked to that specific email
            textBox1.Text = emailName;
            byte[] getimage = new byte[0];
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "Select * from LoginAndReg WHERE email = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                textBox1.Text = dataReader[0].ToString(); // display user name in menu

                // display information in account tab
                showFirstNameTB.Text = dataReader["firstname"].ToString();
                showLastNameTB.Text = dataReader["lastname"].ToString();
                showEmailTB.Text = dataReader["email"].ToString();
                showPasswordTB.Text = dataReader["password"].ToString();

                // display information in settings tab to update information
                FirstNameTextBox.Text = dataReader["firstname"].ToString();
                LastNameTextBox.Text = dataReader["lastname"].ToString();
                updateEmailTB.Text = dataReader["email"].ToString();

                byte[] images = (byte[])dataReader["image"];
                if (images == null)
                {
                    profilePicture2.Image = null;
                    showProfilePicture2.Image = null;
                    updateProfilePicture.Image = null;
                }
                else
                {
                    MemoryStream me = new MemoryStream(images);
                    profilePicture2.Image = Image.FromStream(me); // profile pic in menu
                    showProfilePicture2.Image = Image.FromStream(me); // profile pic in account tab
                    updateProfilePicture.Image = Image.FromStream(me); // profile pic in settings tab
                }
            }
            con.Close();
        }

        // minimize app
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        // close app
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool check;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // open and closes menu tab
            if (check)
            {
                panel1.Width += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Stop();
                    check = false;
                    pictureBox4.Image = Resources.icons8_arrow_100;
                }
            }
            else
            {
                panel1.Width -= 23;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    check = true;
                    pictureBox4.Image = Resources.icons8_menu_100;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            LoginAndReg loginAndReg = new LoginAndReg();
            this.Hide();
            loginAndReg.Show();
        }

        private void accBTN_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Width -= 23;
            if (panel1.Size == panel1.MinimumSize)
            {
                timer1.Stop();
                check = true;
                pictureBox4.Image = Resources.icons8_menu_100;
                
            }

            if (accountPanel.Visible == false)
            {
                accountPanel.Visible = true;
            }
            else
            {
                accountPanel.Visible = false;
            }

        }

        private void settingsBTN_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Width -= 23;
            if (panel1.Size == panel1.MinimumSize)
            {
                timer1.Stop();
                check = true;
                pictureBox4.Image = Resources.icons8_menu_100;

            }

            if (updatePanel.Visible == false)
            {
                updatePanel.Visible = true;
            }
            else
            {
                updatePanel.Visible = false;
            }
        }

        private void updateProfilePicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*jpg, *png, *gif|*.jpg; *.png; *.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                updateProfilePicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        public void showProfile()
        {
            // depending on the email you logged in with
            // this displays the first name linked to that specific email
            textBox1.Text = emailName;
            byte[] getimage = new byte[0];
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "Select * from LoginAndReg WHERE email = '" + updateEmailTB.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                textBox1.Text = dataReader[0].ToString(); // display name in menu

                // display information in account tab
                showFirstNameTB.Text = dataReader["firstname"].ToString();
                showLastNameTB.Text = dataReader["lastname"].ToString();
                showEmailTB.Text = dataReader["email"].ToString();
                showPasswordTB.Text = dataReader["password"].ToString();

                // display information in settings tab to update information
                FirstNameTextBox.Text = dataReader["firstname"].ToString();
                LastNameTextBox.Text = dataReader["lastname"].ToString();
                updateEmailTB.Text = dataReader["email"].ToString();

                byte[] images = (byte[])dataReader["image"];
                if (images == null)
                {
                    profilePicture2.Image = null;
                    showProfilePicture2.Image = null;
                    updateProfilePicture.Image = null;
                }
                else
                {
                    MemoryStream me = new MemoryStream(images);
                    profilePicture2.Image = Image.FromStream(me); // profile pic in menu
                    showProfilePicture2.Image = Image.FromStream(me); // profile pic in account tab
                    updateProfilePicture.Image = Image.FromStream(me); // profile pic in settings tab
                }
            }
            con.Close();
        }

        private void updateBTN_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(FirstNameTextBox.Text.Trim()))
            {
                errorProvider1.SetError(FirstNameTextBox, "Please enter your first name!");
                return;
            }
            else
            {
                errorProvider1.SetError(FirstNameTextBox, string.Empty);
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text.Trim()))
            {
                errorProvider1.SetError(LastNameTextBox, "Please enter your last name!");
                return;
            }
            else
            {
                errorProvider1.SetError(LastNameTextBox, string.Empty);
            }

            if (string.IsNullOrEmpty(updateEmailTB.Text.Trim()))
            {
                errorProvider1.SetError(updateEmailTB, "Please enter your email!");
                return;
            }
            else
            {
                errorProvider1.SetError(updateEmailTB, string.Empty);
            }

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "UPDATE LoginAndReg SET password = '" + showPasswordTB.Text + "', firstname = @fname, lastname = @lname, email = @email, image = @image";
            MemoryStream me = new MemoryStream();
            updateProfilePicture.Image.Save(me, profilePicture2.Image.RawFormat);
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@fname", FirstNameTextBox.Text);
            cmd.Parameters.AddWithValue("@lname", LastNameTextBox.Text);
            cmd.Parameters.AddWithValue("@email", updateEmailTB.Text);
            cmd.Parameters.AddWithValue("@image", me.ToArray());
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Profile updated successfully!", "Success!");
            showProfile();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (accountPanel.Visible == true)
            {
                accountPanel.Visible = false;
            }
            else
            {
                accountPanel.Visible = true;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (updatePanel.Visible == true)
            {
                updatePanel.Visible = false;
            }
            else
            {
                updatePanel.Visible = true;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (passwordPanel.Visible == true)
            {
                passwordPanel.Visible = false;
            }
            else
            {
                passwordPanel.Visible = true;
            }
        }

        private void helpBTN_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Width -= 23;
            if (panel1.Size == panel1.MinimumSize)
            {
                timer1.Stop();
                check = true;
                pictureBox4.Image = Resources.icons8_menu_100;

            }

            if (passwordPanel.Visible == false)
            {
                passwordPanel.Visible = true;
            }
            else
            {
                passwordPanel.Visible = false;
            }
        }

        private void updatePasswordBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentPasswordTB.Text.Trim()))
            {
                errorProvider1.SetError(currentPasswordTB, "Please enter your current password!");
                return;
            }
            else
            {
                errorProvider1.SetError(currentPasswordTB, string.Empty);
            }

            if (string.IsNullOrEmpty(newPasswordTB.Text.Trim()))
            {
                errorProvider1.SetError(newPasswordTB, "Please enter your new password!");
                return;
            }
            else
            {
                errorProvider1.SetError(newPasswordTB, string.Empty);
            }

            if (string.IsNullOrEmpty(confirmNewPasswordTB.Text.Trim()))
            {
                errorProvider1.SetError(confirmNewPasswordTB, "Please confirm your new password!");
                return;
            }
            else
            {
                errorProvider1.SetError(confirmNewPasswordTB, string.Empty);
            }

            if (newPasswordTB.Text == confirmNewPasswordTB.Text)
            {
                validatePassword();
                currentPasswordTB.Clear();
                newPasswordTB.Clear();
                confirmNewPasswordTB.Clear();
            }
            else
            {
                MessageBox.Show("Passwords do not match!", "Error!");
            }

        }

        public void validatePassword()
        {
            var input = newPasswordTB.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorProvider1.SetError(newPasswordTB, "Please enter your current password!");
                return;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinMaxChars = new Regex(@".{8,8}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>./?,-]");

            if(!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain a minimum of ONE lower case letter!");
                return;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain a minimum of ONE upper case letter!");
                return;
            }
            else if (!hasMinMaxChars.IsMatch(input))
            {
                MessageBox.Show("Password should not be less than AND greater than 8 characters!");
                return;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least ONE numerical value!");
                return;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                MessageBox.Show("Password should contain at least ONE special character!");
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE LoginAndReg SET Password = @NewPassword, confirmpass = @ConfirmPassword WHERE email = @Email AND password = @CurrentPassword", con);
                cmd.Parameters.AddWithValue("@NewPassword", newPasswordTB.Text);
                cmd.Parameters.AddWithValue("@ConfirmPassword", confirmNewPasswordTB.Text);
                cmd.Parameters.AddWithValue("@Email", showEmailTB.Text); // if doesnt work change to textbox1 and change dataReader to 2 not 0
                cmd.Parameters.AddWithValue("@CurrentPassword", currentPasswordTB.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password updated successfully!", "Success!");
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e) // show password
        {
            confirmNewPasswordTB.UseSystemPasswordChar = !confirmNewPasswordTB.UseSystemPasswordChar;
        }

        private void showCurrentPwBTN_Click(object sender, EventArgs e)
        {
            currentPasswordTB.UseSystemPasswordChar = !currentPasswordTB.UseSystemPasswordChar;
        }

        private void showNewPwBTN_Click(object sender, EventArgs e)
        {
            newPasswordTB.UseSystemPasswordChar = !newPasswordTB.UseSystemPasswordChar;
        }

        private void commBTN_Click(object sender, EventArgs e)
        {
            UserItem();
            timer1.Start();
            panel1.Width -= 23;
            if (panel1.Size == panel1.MinimumSize)
            {
                timer1.Stop();
                check = true;
                pictureBox4.Image = Resources.icons8_menu_100;

            }

            if (chatPanel.Visible == true)
            {
                chatPanel.Visible = false;
            }
            else
            {
                chatPanel.Visible = true;
            }
        }

        private void UserItem()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter("select * from LoginandReg", constring);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table != null)
            {
                if(table.Rows.Count > 0)
                {
                    UserControl1[] userControls = new UserControl1[table.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            userControls[i] = new UserControl1();
                            MemoryStream stream = new MemoryStream((byte[]) row["image"]);
                            userControls[i].Icon = new Bitmap(stream);
                            userControls[i].Title = row["firstname"].ToString();
                            if (userControls[i].Title == textBox1.Text)
                            {
                                flowLayoutPanel1.Controls.Remove(userControls[i]);
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Add(userControls[i]);
                            }
                            userControls[i].Click += new System.EventHandler(this.userControl1_Load);
                        }
                    }
                }
            }
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            if (chatPanel.Visible == true)
            {
                chatPanel.Visible = false;
            }
            else
            {
                chatPanel.Visible = true;
            }

            if (panel2.Visible == true && panel3.Visible == true && flowLayoutPanel2.Visible == true)
            {
                panel2.Visible = false;
                panel3.Visible = false;
                flowLayoutPanel2.Visible = false;
            }

        }

        private void sendMessageBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "insert into Chat(userone, usertwo, message)values(@userone, @usertwo, @message)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@userone", textBox1.Text);
            cmd.Parameters.AddWithValue("@usertwo", textBox2.Text);
            cmd.Parameters.AddWithValue("@message", textTB.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageChat();
            textTB.Clear();
        }

        private void MessageChat()
        {
            flowLayoutPanel2.Controls.Clear();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter("select * from Chat", constring);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table != null)
            {

                if (table.Rows.Count > 0)
                {



                    UserControl2[] userControl2s = new UserControl2[table.Rows.Count];
                    UserControl3[] userControl3s = new UserControl3[table.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (textBox1.Text == row["userone"].ToString() && textBox2.Text == row["usertwo"].ToString())
                            {
                                userControl2s[i] = new UserControl2();
                                userControl2s[i].Dock = DockStyle.Top;
                                userControl2s[i].BringToFront();
                                userControl2s[i].Title = row["message"].ToString();

                                flowLayoutPanel2.Controls.Add(userControl2s[i]);
                                flowLayoutPanel2.ScrollControlIntoView(userControl2s[i]);

                            }
                            else if (textBox2.Text == row["userone"].ToString() && textBox1.Text == row["usertwo"].ToString())
                            {
                                userControl3s[i] = new UserControl3();
                                userControl3s[i].Dock = DockStyle.Top;
                                userControl3s[i].BringToFront();
                                userControl3s[i].Title = row["message"].ToString();
                                userControl3s[i].Icon = roundPictureBox1.Image;

                                flowLayoutPanel2.Controls.Add(userControl3s[i]);
                                flowLayoutPanel2.ScrollControlIntoView(userControl3s[i]);

                            }
                        }
                    }
                }
            }
        }

        private void userControl1_Load(object sender, EventArgs e)
        {
            if (panel2.Visible == false && panel3.Visible == false && flowLayoutPanel2.Visible == false)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                flowLayoutPanel2.Visible = true;
            }

            UserControl1 control = (UserControl1)sender;
            textBox2.Text = control.Title;
            roundPictureBox1.Image = control.Icon;
            MessageChat();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageChat();
        }
    }
}
