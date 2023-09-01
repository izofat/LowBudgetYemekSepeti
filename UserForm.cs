using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


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
        
        int count;
        List<string> productname;
        List<string> ingredients;
        List<string> price;
        List<string> status;
        List<string> imagelocation;
        private void comboBoxrestourants_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string restourantname = comboBoxrestourants.SelectedItem.ToString();                  
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
                Button newbtn = new Button();
                newbtn.Name = "btnorder" + i;
                newbtn.Size = new Size(88, 49);
                newbtn.Location = new Point(xl, y + 132);
                newbtn.Text = "+";
                newbtn.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newbtn.ForeColor = System.Drawing.Color.Black;
                newbtn.BackColor = System.Drawing.Color.White;
                newbtn.Click += (s, ev) => Button_ClickOrder(s, ev, newbtn.Name, productname , count);
                y += 275;
                for (int k = 0; k < 4; k++)
                {
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
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
                            if (p == 60  || p == 120)
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
                                       
                    u++;
                }
                m++;                                
                panel1.Controls.Add(picturebox);
                panel1.Controls.Add(newbtn);               
            }
        }
        List<string> order = new List<string>();
        private void Button_ClickOrder (object sender, EventArgs e, string buttonname , List<string> productnames , int count)
        {
            string actualname = buttonname.Remove(0, 8);
            order.Add(productname[Convert.ToInt32(actualname)]);                                    
            btnviewbucket.Visible = true;
            MessageBox.Show("Product added to the bucket");
        }
       
        private void btnviewbucket_Click(object sender, EventArgs e)
        {             
            int[] countsofproducts = new int[count];
            int[] pricesofproducts = new int[count];
            panel1.Controls.Clear();    
            for (int i = 0; i < order.Count; i++)
            {
                string element = order[i]; 
                int index = productname.IndexOf(element);

                if (index != -1)
                {
                    countsofproducts[index]++;
                    pricesofproducts[index] += Convert.ToInt32(price[index]);
                }
            }
            int x = 29;
            int y = 42;
            int xl = 288;
            int u = 1;            
            int a = 0;
            foreach (int m in countsofproducts)
            {
                int yl = y;
                if (m != 0)
                {                   
                    
                    PictureBox picturebox = new PictureBox();
                    picturebox.Name = "picturebx" + a.ToString();
                    picturebox.ImageLocation = imagelocation[Array.IndexOf(countsofproducts,m)];
                    
                    picturebox.Location = new Point(x, y);
                    picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox.Size = new Size(243, 191);
                    panel1.Controls.Add(picturebox);
                    
                    //
                    Button newbtn = new Button();
                    newbtn.Name = "btnedit" + a.ToString();
                    newbtn.Size = new Size(88, 49);
                    newbtn.Location = new Point(xl, y + 132);
                    newbtn.Text = "Edit Product";
                    newbtn.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newbtn.ForeColor = System.Drawing.Color.Black;
                    newbtn.BackColor = System.Drawing.Color.White;
                    newbtn.Click += (s, ev) => Button_ClickEdit(s, ev , Array.IndexOf(countsofproducts, m));
                    panel1.Controls.Add(newbtn);
                    y += 275;
                    for (int k = 0; k < 4; k++)
                    {
                        System.Windows.Forms.Label newlabel = new System.Windows.Forms.Label();
                        
                        newlabel.Name = "lblproduct" + u;
                        
                        if (u % 4 == 1)
                        {
                            newlabel.Text = productname[Array.IndexOf(countsofproducts, m)];
                        }
                        else if (u % 4 == 2)
                        {
                            newlabel.Text = price[Array.IndexOf(countsofproducts, m)];
                        }
                        else if (u % 4 == 3)
                        {
                            newlabel.Text = status[Array.IndexOf(countsofproducts, m)];
                        }
                        else if (u % 4 == 0)
                        {
                            int p = 1;
                            foreach (char letter in ingredients[Array.IndexOf(countsofproducts, m)])
                            {
                                newlabel.Text += letter;
                                if (p == 60 || p == 120)
                                {
                                    newlabel.Text += "\n";
                                }
                                p++;
                            }

                        }
                        if (u % 4 != 0)
                        {
                            newlabel.Location = new Point(xl, yl);
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
                            newlabel.Location = new Point(x, yl);
                        }
                        newlabel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        newlabel.ForeColor = System.Drawing.Color.Black;
                        newlabel.AutoSize = true;
                        panel1.Controls.Add(newlabel);
                        
                        u++;
                    }
                    System.Windows.Forms.Label newlabelcount = new System.Windows.Forms.Label();
                    newlabelcount.Name = "lblcount" + a.ToString();
                    newlabelcount.Text = "Count : " + m.ToString();
                    newlabelcount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newlabelcount.ForeColor = System.Drawing.Color.Black;
                    newlabelcount.Location = new Point(xl +100 , yl - 90);
                    newlabelcount.AutoSize = true;
                    panel1.Controls.Add(newlabelcount);
                    ////
                    System.Windows.Forms.Label newlabelprice = new System.Windows.Forms.Label();
                    newlabelprice.Name = "lblprice" + a.ToString();
                    newlabelprice.Text = "Price : " + pricesofproducts[Array.IndexOf(countsofproducts, m)];
                    newlabelprice.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newlabelprice.ForeColor = System.Drawing.Color.Black;
                    newlabelprice.Location = new Point(xl + 100, yl - 60);
                    newlabelprice.AutoSize = true;
                    panel1.Controls.Add(newlabelprice);
                    a++;
                }
                countsofproducts[Array.IndexOf(countsofproducts, m)] = 0;
            }
        }

        private void Button_ClickEdit(object sender , EventArgs e , int index)
        {
            
        }
    }
}
