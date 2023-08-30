using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Delivery_Platform
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        private string localusername;
        public string Localusername { get => localusername; set => localusername = value; }

        UserAction usaction = new UserAction();
        
        private void UserForm_Load(object sender, EventArgs e)
        {
            
            string location = usaction.CheckLocation(localusername);
            List<string> restourants = usaction.ShowRestourants();
            foreach (string restourant in restourants)
            {
                comboBoxrestourants.Items.Add(restourant);
            }           
            if (location == DBNull.Value.ToString())
            {
                MessageBox.Show("Welcome to the LOW BUDGET YEMEKSEPETI \n firstly enter your location");
                groupBoxgetloc.Visible = true;
            }
            else
            {
                groupBoxgetloc.Visible = true;
                btnsave.Visible = false;
                txtbxlocation.Text = location;
                txtbxlocation.ReadOnly = true;
                comboBoxrestourants.Visible = true;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string location = txtbxlocation.Text;
            if (location != "" && usaction.SetLocation(localusername, location))
            {
                MessageBox.Show("Location Updated Successfully");
                btnsave.Visible = false;
                txtbxlocation.ReadOnly = true;
                comboBoxrestourants.Visible = true;
            } 
            else
            {
                MessageBox.Show("Enter a location to set ");
            }
        }

        private void comboBoxrestourants_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string restourantname = comboBoxrestourants.SelectedItem.ToString();
            int count;
            List<string> productname;
            List<string> ingredients;
            List<string> price;
            List<string> status;
            List<string> imagelocation;
            usaction.ShowProducts(restourantname, out count, out productname, out ingredients, out price, out status, out imagelocation);            
            int x = 29;
            int y = 42;            
            int xl = 288;
            int u = 1;
            int m = 0;
            for (int i = 0; i < count; i++)
            {
                int yl = y;
                PictureBox picturebox = new PictureBox();
                picturebox.Name = "picturebx" + i.ToString();
                picturebox.ImageLocation = imagelocation[i];
                picturebox.Location = new Point(x,y);
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.Size = new Size(243,191);
                
                y += 275;
                for (int k = 0; k < 4; k++)
                {
                    Label label = new Label();
                    label.Name = "lblproduct" + u;
                    if (u % 4 == 1)
                    {
                        label.Text = productname[m];
                    }
                    else if (u % 4 == 2)
                    {
                        label.Text = price[m];
                    }
                    else if (u %4 == 3)
                    {
                        label.Text = status[m];
                    }
                    else if (u % 4 == 0)
                    {
                        int p = 1;
                        foreach (char letter in ingredients[m])
                        {
                            label.Text += letter;
                            if (p == 50)
                            {
                                label.Text += "\n";
                            }
                            p++;
                        }
                        
                    }
                    if (u % 4 != 0)
                    {                        
                        label.Location = new Point(xl, yl);
                        if (u % 4 != 3)
                        {
                            yl += 48;
                        }
                        else
                        {
                            yl += 95;
                        }                        
                    }
                    else
                    {
                        label.Location = new Point(x,yl);
                    }
                    label.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.ForeColor = System.Drawing.Color.Black;
                    label.AutoSize = true;                                        
                    panel1.Controls.Add(label);
                    panel1.Controls.Add(picturebox);
                    
                    u++;
                }
                m++;
            }
        }

        
    }
}
