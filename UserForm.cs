using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
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
            panel1.Controls.Clear();
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
        List<int> willuse = new List<int>();
        string[] productsindex;
        int h = 0;
        private void btnviewbucket_Click(object sender, EventArgs e)
        {             
            int[] countsofproducts = new int[count];
            int[] pricesofproducts = new int[count];
            panel1.Controls.Clear();
            int index = -1;
            for (int i = 0; i < order.Count; i++)
            {
                string element = order[i]; 
                index = productname.IndexOf(element);

                if (index != -1)
                {
                    countsofproducts[index]++;
                    pricesofproducts[index] += Convert.ToInt32(price[index]);
                }
            }            
            
            if (h == 0)
            {                              
                foreach (int c in countsofproducts)
                {

                    willuse.Add(c);
                }
                h++;
            }
            
            int buttoncount = 0;
            productsindex = new string[count];
            for (int z  =  0; z < count; z++)
            {
                productsindex[z] = z.ToString() + "," + countsofproducts[z].ToString();
                if (countsofproducts[z] != 0)
                {
                    buttoncount++;
                }
                
            }           
            int x = 29;
            int y = 42;
            int xl = 288;
            int u = 1;            
            int a = 0;
            int q = 0;
            Button[] newbtn = new Button[buttoncount];
            foreach (int m in countsofproducts)
            {
                int yl = y;
                if (m != 0)
                {
                    string newq = productsindex[q];
                    PictureBox picturebox = new PictureBox();
                    picturebox.Name = "picturebx" + a.ToString();
                    picturebox.ImageLocation = imagelocation[Array.IndexOf(countsofproducts,m)];                    
                    picturebox.Location = new Point(x, y);
                    picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox.Size = new Size(243, 191);
                    panel1.Controls.Add(picturebox);
                    //
                    newbtn[a] = new Button();
                    newbtn[a].Name = "btnedit" + a.ToString();
                    newbtn[a].Size = new Size(88, 49);
                    newbtn[a].Location = new Point(xl, y + 132);
                    newbtn[a].Text = "Edit Product";
                    newbtn[a].Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newbtn[a].ForeColor = System.Drawing.Color.Black;
                    newbtn[a].BackColor = System.Drawing.Color.White;
                    newbtn[a].Click += (s, ev) => Button_ClickEdit(s, ev , newq );
                    
                    panel1.Controls.Add(newbtn[a]);
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
                    panel1.Controls.Remove(newlabelcount);
                    int newcount = willuse[q];
                    
                    newlabelcount.Name = "lblcount" + a.ToString();
                    newlabelcount.Text = "Count : " + newcount.ToString();
                    newlabelcount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newlabelcount.ForeColor = System.Drawing.Color.Black;
                    newlabelcount.Location = new Point(xl +100 , yl - 90);
                    newlabelcount.AutoSize = true;
                    panel1.Controls.Add(newlabelcount);
                    ////
                    System.Windows.Forms.Label newlabelprice = new System.Windows.Forms.Label();
                    panel1.Controls.Remove(newlabelprice);
                    
                    newlabelprice.Name = "lblprice" + a.ToString();
                    newlabelprice.Text = "Price : " + Convert.ToInt32(price[q]) * newcount;
                    newlabelprice.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newlabelprice.ForeColor = System.Drawing.Color.Black;
                    newlabelprice.Location = new Point(xl + 100, yl - 60);
                    newlabelprice.AutoSize = true;
                    panel1.Controls.Add(newlabelprice);
                    a++;
                }
                countsofproducts[Array.IndexOf(countsofproducts, m)] = 0;
                q++;
            }            
            btnorder.Click += (s, ev) => OrderClick(s, ev);
            btnorder.Visible = true;
            
            
        }


        int editcount;
        private void Button_ClickEdit(object sender , EventArgs e , string inq )
        {
            int index = Convert.ToInt32(inq.Substring(0, 1));
            int countofproduct = Convert.ToInt32(inq.Substring(2,1));
            editcount = countofproduct;
            panel1.Controls.Clear();
            
            //
            PictureBox pictureboxedit = new PictureBox();
            pictureboxedit.Name = "picturebxedit";
            pictureboxedit.Size = new Size(210, 185);
            pictureboxedit.ImageLocation = imagelocation[index];
            pictureboxedit.Location = new Point(38, 26);
            pictureboxedit.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Controls.Add(pictureboxedit);
            //
            System.Windows.Forms.Label labelproductname = new System.Windows.Forms.Label();
            labelproductname.Name = "lblproductname";
            labelproductname.Text = productname[index];
            labelproductname.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelproductname.ForeColor = System.Drawing.Color.Black;
            labelproductname.AutoSize = true;
            labelproductname.Location = new Point(281, 26);
            panel1.Controls.Add(labelproductname);
            //
            System.Windows.Forms.Label labelcount = new System.Windows.Forms.Label();
            labelcount.Name = "lblcount";
            labelcount.Text = "Count : "+ willuse[index].ToString();
            labelcount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelcount.ForeColor = System.Drawing.Color.Black;
            labelcount.AutoSize = true;
            labelcount.Location = new Point(281, 108);
            panel1.Controls.Add(labelcount);
            // 
            Button buttonplus = new Button();
            buttonplus.Name = "buttonplus";
            buttonplus.Text = "+";
            buttonplus.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonplus.ForeColor = System.Drawing.Color.Black;
            buttonplus.BackColor = System.Drawing.Color.White;
            buttonplus.Size = new Size(43,26);
            buttonplus.Location = new Point(370,108);
            buttonplus.Click += (s, ev) => CountChanged(s, ev, "+" , index);
            panel1.Controls.Add(buttonplus);
            //
            Button buttonminus = new Button();
            buttonminus.Name = "buttonminus";
            buttonminus.Text = "-";
            buttonminus.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonminus.ForeColor = System.Drawing.Color.Black;
            buttonminus.BackColor = System.Drawing.Color.White;
            buttonminus.Size = new Size(43, 26);
            buttonminus.Location = new Point(419, 108);
            buttonminus.Click += (s, ev) => CountChanged(s, ev, "-" , index);
            panel1.Controls.Add(buttonminus);
            //
            

            //
            System.Windows.Forms.Label labelprice = new System.Windows.Forms.Label();
            labelprice.Name = "lblprice0";
            labelprice.Text =  "Price : "+ (Convert.ToInt32(price[index]) * willuse[index]).ToString();
            labelprice.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelprice.ForeColor = System.Drawing.Color.Black;
            labelprice.AutoSize = true;
            labelprice.Location = new Point(281, 198);
            panel1.Controls.Add(labelprice);
            //
            int ingredientcount = 1;
            foreach (char letter in ingredients[index])
            {
                if (letter.ToString() == ",")
                {
                    ingredientcount++;
                }
            }
            List<CheckBox> checkbxingredient = new List<CheckBox>();
            int i = 0;
            int y = 247;
            int x = 25;
            string ingredient = "";
            foreach(char letter in ingredients[index])
            {                
                if (letter.ToString() != "," )
                {
                    ingredient += letter;         
                    
                }
                else 
                {
                    CheckBox chcbx = new CheckBox();
                    chcbx.Text = ingredient;
                    chcbx.Name = "checkbx" + i.ToString();
                    chcbx.Font = new System.Drawing.Font("Arial Black", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    chcbx.ForeColor = System.Drawing.Color.Black;
                    chcbx.AutoSize = true;
                    chcbx.Checked = true;
                    chcbx.Location = new Point(x, y);
                    checkbxingredient.Add(chcbx);
                    panel1.Controls.Add(chcbx);
                    ingredient = "";
                    y += 32;
                    i++;
                }
                
            }
            CheckBox chcbxm = new CheckBox();
            chcbxm.Text = ingredient;
            chcbxm.Name = "checkbx" + i.ToString();
            chcbxm.Font = new System.Drawing.Font("Arial Black", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chcbxm.ForeColor = System.Drawing.Color.Black;
            chcbxm.AutoSize = true;
            chcbxm.Checked = true;
            chcbxm.Location = new Point(x, y);
            checkbxingredient.Add(chcbxm);
            panel1.Controls.Add(chcbxm);
            //
            Button buttonset = new Button();
            buttonset.Name = "buttonset";
            buttonset.Text = "Set";
            buttonset.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonset.ForeColor = System.Drawing.Color.Black;
            buttonset.BackColor = System.Drawing.Color.White;
            buttonset.Size = new Size(78, 39);
            buttonset.Location = new Point(388, 323);
            buttonset.Click += (s, ev) => ProductChanged(s, ev, index , checkbxingredient);
            panel1.Controls.Add(buttonset);
        }
        private void CountChanged(object sender , EventArgs e , string action , int index )
        {
            
            if (action == "-" && editcount > 0)
            {
                willuse[index]--;
                
            }
            else if ( action == "+" && editcount < 9)
            {
                willuse[index]++;
                
            }
            foreach (int o in willuse)
            {
                
            }
            System.Windows.Forms.Label labelcount = new System.Windows.Forms.Label();
            panel1.Controls.Remove(labelcount);
            labelcount.Name = "lblcount";
            labelcount.Text = "Count : " + willuse[index].ToString();
            labelcount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelcount.ForeColor = System.Drawing.Color.Black;
            labelcount.AutoSize = true;
            labelcount.Location = new Point(281, 108);
            panel1.Controls.Add(labelcount);
            labelcount.BringToFront();
            //
            System.Windows.Forms.Label labelprice = new System.Windows.Forms.Label();
            panel1.Controls.Remove(labelprice);
            labelprice.Name = "lblprice0";
            labelprice.Text = "Price :  " + (Convert.ToInt32(price[index]) * willuse[index]).ToString();
            labelprice.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelprice.ForeColor = System.Drawing.Color.Black;
            labelprice.AutoSize = true;
            labelprice.Location = new Point(281, 198);
            panel1.Controls.Add(labelprice);
            labelprice.BringToFront();
        }

        private void ProductChanged(object sender , EventArgs e , int index , List<CheckBox> checkBoxes)
        {            
            string newingredients = "";
            foreach (CheckBox checkbx in checkBoxes)
            {
                if (checkbx.Checked == true)
                {
                    newingredients += checkbx.Text + ",";
                }
            }
            newingredients = newingredients.Substring(0, newingredients.Length - 1);
            ingredients[index] = newingredients;            
            btnviewbucket.PerformClick();
        }

        private void OrderClick(object sender , EventArgs e  )
        {
            string orderrestourantname = comboBoxrestourants.Text;
            string orderedby = localusername;
            string location = usaction.CheckLocation(localusername);
            List<string> orderedproducts = new List<string>();
            List<string> orderedingredients = new List<string>();
            List<int> orderedcounts = new List<int>();
            List<int> orderedprices = new List<int>();
            
            try
            {
                for (int i = 0; i < productname.Count; i++)
                {

                    if (willuse[i] != 0)
                    {

                        orderedproducts.Add(productname[i]);
                        orderedingredients.Add(ingredients[i]);
                        orderedcounts.Add(willuse[i]);
                        orderedprices.Add(Convert.ToInt32(price[i]) * willuse[i]);
                    }
                    
                }
            }
            catch (Exception)
            {
               
            }           
            if (usaction.NewOrder(orderrestourantname, orderedproducts,
                orderedingredients, orderedcounts, orderedprices, orderedby, location) == true)
            {
                MessageBox.Show("Order taken successfully");
                btnorder.Visible = false;
                h = 0;
                willuse = new List<int>();
                panel1.Controls.Clear();
                btnvieworders.Visible = true;
            }
        }

        private void btnvieworders_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<string> orderedproducts;
            List<int> orderedcounts;
            List<int> orderedprice;
            List<string> orderedstatus;
            usaction.GetOrders(localusername, out orderedproducts, out orderedcounts, out orderedprice, out orderedstatus);
            int namey = 28;
            for (int i = 0; i < orderedproducts.Count; i++)
            {
                if (orderedstatus[i] != "Delivered")
                {
                    System.Windows.Forms.Label labelordername = new System.Windows.Forms.Label();
                    labelordername.Name = "labelordername" + i.ToString();
                    labelordername.Text = orderedproducts[i];
                    labelordername.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelordername.ForeColor = System.Drawing.Color.Black;
                    labelordername.AutoSize = true;
                    labelordername.Location = new Point(50, namey);
                    panel1.Controls.Add(labelordername);
                    //
                    System.Windows.Forms.Label labelordercount = new System.Windows.Forms.Label();
                    labelordercount.Name = "labelordercount" + i.ToString();
                    labelordercount.Text =  "Count : " + orderedcounts[i].ToString();
                    labelordercount.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelordercount.ForeColor = System.Drawing.Color.Black;
                    labelordercount.AutoSize = true;
                    labelordercount.Location = new Point(50, namey + 41);
                    panel1.Controls.Add(labelordercount);
                    //
                    System.Windows.Forms.Label labelorderprice = new System.Windows.Forms.Label();
                    labelorderprice.Name = "labelorderprice" + i.ToString();
                    labelorderprice.Text = "Price : " + orderedprice[i].ToString();
                    labelorderprice.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelorderprice.ForeColor = System.Drawing.Color.Black;
                    labelorderprice.AutoSize = true;
                    labelorderprice.Location = new Point(150, namey + 41);
                    panel1.Controls.Add(labelorderprice);
                    //
                    System.Windows.Forms.Label labelorderstatus = new System.Windows.Forms.Label();
                    labelorderstatus.Name = "labelorderstatus" + i.ToString();
                    labelorderstatus.Text = orderedstatus[i];
                    labelorderstatus.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    labelorderstatus.ForeColor = System.Drawing.Color.Gray;
                    labelorderstatus.AutoSize = true;
                    labelorderstatus.Location = new Point(257, namey + 9);
                    panel1.Controls.Add(labelorderstatus);
                    namey += 103;
                }
            }
            int totalprice = 0;
            foreach (int p in orderedprice)
            {
                totalprice += p;
            }
            System.Windows.Forms.Label labelordertotalprice = new System.Windows.Forms.Label();
            labelordertotalprice.Name = "labelordertotal" ;
            labelordertotalprice.Text = "Total Price : " + totalprice.ToString();
            labelordertotalprice.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelordertotalprice.ForeColor = System.Drawing.Color.Black;
            labelordertotalprice.AutoSize = true;
            labelordertotalprice.Location = new Point(353, namey +50);
            panel1.Controls.Add(labelordertotalprice);
        }
    }

}
