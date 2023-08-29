using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Delivery_Platform
{
    public partial class FoodDeliveryPlatform : Form
    {
        public FoodDeliveryPlatform()
        {
            InitializeComponent();
        }
        string acctype;
        string action;

        private void btncustomer_Click(object sender, EventArgs e)
        {
            groupBoxstartup.Visible = true;
            groupBoxactions.Visible = false;
            acctype = "Customer";
            lblinfoacc.Text = "";
            lblinfoacc.Text = "Customer Account";
            btnlogin.Visible = true;
            btnsignup.Visible = true;
            btncustomer.Visible = false;
            btnbuniness.Visible = true;
            txtbxpassword.Clear();
            txtbxusername.Clear();
        }

        private void btnbuniness_Click(object sender, EventArgs e)
        {
            groupBoxstartup.Visible = true;
            groupBoxactions.Visible = false;
            acctype = "Business";
            lblinfoacc.Text = "";
            lblinfoacc.Text = "Business Account";
            btnlogin.Visible = true;
            btnsignup.Visible = true;
            btncustomer.Visible = true;
            btnbuniness.Visible = false;
            txtbxpassword.Clear();
            txtbxusername.Clear();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            action = "log in";
            groupBoxactions.Visible = true;
            btnlogin.Visible = false;
            btnsignup.Visible = true;
            lblinfoacc.Text = acctype + " Account log in";
            btnaction.Text = "Log in";
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            action = "sign up";
            groupBoxactions.Visible = true;
            btnlogin.Visible = true;
            btnsignup.Visible = false;
            lblinfoacc.Text = acctype + " Account sign up";
            btnaction.Text = "Sign up";
        }
        int b = 0;
        private void btnshow_Click(object sender, EventArgs e)
        {
            if (b % 2 == 0)
            {
                btnshow.Image = Image.FromFile("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Food Delivery Platform\\images\\show.png");
                txtbxpassword.UseSystemPasswordChar = false;
            }
            else if (b % 2 == 1)
            {
                btnshow.Image = Image.FromFile("C:\\Users\\gorke\\OneDrive\\Documents\\C#\\Food Delivery Platform\\images\\unshow.png");
                txtbxpassword.UseSystemPasswordChar = true;
            }
            b++;
        }
        public void ErrorAccrued(string error)
        {
            if (error == "u")
            {
                MessageBox.Show("This username already taken");
            }
            else if (error == "d")
            {
                MessageBox.Show("An Error occurred in database");
            }           
        }
        string localusername;
        private void btnaction_Click(object sender, EventArgs e)
        {
            Action loginsignup = new Action();
            string username = txtbxusername.Text.ToString();
            string password = txtbxpassword.Text.ToString();
            localusername = username;
            if (action == "sign up" && acctype == "Customer" && username != "" && password != "")
            {
                if (password.Any(char.IsDigit) == true && password.Any(char.IsLetter) == true && password.Length >= 6)
                {
                    loginsignup.SignUpCustomer(username, password);
                    
                    txtbxpassword.Clear();
                    txtbxusername.Clear();
                }
                else if (password.Any(char.IsDigit) == false && password.Length >= 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password must contain at least 1 number !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length < 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password length must be at least 6 character !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length >= 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password must contain at least 1 letter !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length < 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                          "Password must contain at least 1 letter!");

                }
                else if (password.Any(char.IsDigit) == false && password.Length >= 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password must contain at least 1 number ! \n" +
                                            "Password must contain at least 1 letter !");

                }
                else if (password.Any(char.IsDigit) == false && password.Length < 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                               " Password must contain at least 1 number!");
                }
                else
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                            "Password must contain at least 1 number ! \n" +
                                                 "Password must contain at least 1 letter !");
                }
            }            
            else if (action == "log in" && acctype == "Customer" && username != "" && password != "")
            {
                if (loginsignup.LogIncustomer(username, password) == 0)
                {

                    UserForm usform = new UserForm();
                    usform.Localusername = username;
                    usform.Show();
                }
                
            }
            else if (action == "sign up" && acctype == "Business" && username != "" && password != "")
            {
                if (password.Any(char.IsDigit) == true && password.Any(char.IsLetter) == true && password.Length >= 6)
                {
                    loginsignup.SignUpBusiness(username, password);                    
                    txtbxpassword.Clear();
                    txtbxusername.Clear();
                }
                else if (password.Any(char.IsDigit) == false && password.Length >= 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password must contain at least 1 number !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length < 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password length must be at least 6 character !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length >= 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password must contain at least 1 letter !");
                }
                else if (password.Any(char.IsDigit) == true && password.Length < 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                          "Password must contain at least 1 letter!");

                }
                else if (password.Any(char.IsDigit) == false && password.Length >= 6 && password.Any(char.IsLetter) == false)
                {
                    MessageBox.Show("Password must contain at least 1 number ! \n" +
                                            "Password must contain at least 1 letter !");

                }
                else if (password.Any(char.IsDigit) == false && password.Length < 6 && password.Any(char.IsLetter) == true)
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                               " Password must contain at least 1 number!");
                }
                else
                {
                    MessageBox.Show("Password length must be at least 6 character ! \n" +
                                            "Password must contain at least 1 number ! \n" +
                                                 "Password must contain at least 1 letter !");
                }
            }
            else if (action == "log in" && acctype == "Business" && username != "" && password != "")
            {                               
                if (loginsignup.LogInBusiness(username, password) == 0)
                {
                    
                    BusinessForm bsform = new BusinessForm();                   
                    bsform.Localusername = username;
                    bsform.Show();
                    
                }                                   
            }
            else
            {
                MessageBox.Show("Username And Password required ! ");
            }

        }   
        
    }
}
