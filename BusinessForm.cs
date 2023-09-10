using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Food_Delivery_Platform
{
    public partial class BusinessForm : Form
    {
        RestourantAction rsaction = new RestourantAction();
        int id;
        private string localusername;
        public string Localusername { get => localusername; set => localusername = value; }
        public BusinessForm()
        {
            InitializeComponent();
            
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            
            id = rsaction.GetRestourantId(localusername);
            string name = rsaction.GetRestourantName(id);

            if (name == DBNull.Value.ToString())
            {
                MessageBox.Show("Welcome to the LOW BUDGET YEMEKSEPETI \n first please enter your Restourant name");
                groupBoxnoname.Visible = true;
                btnstart.Visible = false;
            }
            else
            {
                lblrestourantname.Visible = true;
                lblrestourantname.Text = name;
                groupBoxactions.Visible = true;
            }
            btnstart.Visible = false;
        }
        string action = "";

        private void btnset_Click(object sender, EventArgs e)
        {
            if (txtbxrestorantname.Text != "" && txtbxloc.Text != "")
            {
                id = rsaction.GetRestourantId(localusername);
                string restourantname = txtbxrestorantname.Text.ToString();
                string newrestourant = "";
                foreach (char letter in restourantname)
                {
                    if (letter.ToString() != " ")
                    {
                        newrestourant += letter.ToString();
                    }
                    else
                    {
                        newrestourant += "_";
                    }
                }
                string location = txtbxloc.Text.ToString();                
                if (rsaction.NewRestourant(id, newrestourant, location) == true)
                {
                    lblrestourantname.Visible = true;
                    lblrestourantname.Text = restourantname;
                    groupBoxactions.Visible = true;
                    groupBoxnoname.Visible = false;
                    MessageBox.Show("Your restourant created successfully ");
                }
                else
                {
                    MessageBox.Show("An error occurred in database ");
                }
            }          
            else
            {
                MessageBox.Show("Fill the textboxes to create you restourant");
            }

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            comboBoxproducts.Items.Clear();
            comboBoxproducts.Visible = true;
            groupBoxdata.Visible = true;
            id = rsaction.GetRestourantId(localusername);
            string restourantname = rsaction.GetRestourantName(id);
            List<string> products = rsaction.ViewProduct(restourantname);
            foreach (string product in products)
            {
                comboBoxproducts.Items.Add(product);
            }
        }
        private void comboBoxproducts_SelectedValueChanged(object sender, EventArgs e)
        {
            string productname = comboBoxproducts.SelectedItem.ToString();
            id = rsaction.GetRestourantId(localusername);
            string restourantname = rsaction.GetRestourantName(id);
            List<string> productinfo = new List<string>();
            productinfo = rsaction.ViewProductInfo(restourantname, productname);
            txtbxproductname.Text = productinfo[0];
            txtbxingredients.Text = productinfo[1];
            txtbxprice.Text = productinfo[2];
            comboBoxstatus.Text = productinfo[3];
            txtbximageloc.Text = productinfo[4];
            picturebxproduct.ImageLocation = txtbximageloc.Text.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Save  ";
            groupBoxdata.Visible = true;
            btnsave.Visible = true;
            btngetimage.Visible = true;
            action = "add";
            
        }

        private void btngetimage_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            picturebxproduct.ImageLocation = openFileDialog1.FileName;
            txtbximageloc.Text = openFileDialog1.FileName;                       
        }
        private void ClearDatas()
        {
            txtbxproductname.Clear();
            txtbxingredients.Clear();
            txtbxprice.Clear();
            comboBoxstatus.Text = "";
            txtbximageloc.Clear();
            picturebxproduct.Image = null;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            id = rsaction.GetRestourantId(localusername);
            string restourantname = rsaction.GetRestourantName(id);
            if (txtbxproductname.Text != "" && txtbxingredients.Text != "" && txtbxprice.Text != "" && action == "add" && comboBoxstatus.SelectedIndex != -1)
            {                
                string productname = txtbxproductname.Text.ToString();
                string ingredients = txtbxingredients.Text.ToString();
                string price = txtbxprice.Text.ToString();
                string status = comboBoxstatus.Text.ToString();
                string imageloc = txtbximageloc.Text.ToString();
                if (rsaction.AddProduct(restourantname, productname, ingredients, price, status, imageloc) == true)
                {
                    ClearDatas();
                    MessageBox.Show("Product added successfully");
                    btnview.PerformClick();
                }
            }
            else if (action == "update" && txtbxproductname.Text != "" && txtbxingredients.Text != "" && txtbxprice.Text != "" && comboBoxstatus.SelectedIndex != -1)
            {
                string oldproductname = comboBoxproducts.SelectedItem.ToString();
                string newproductname = txtbxproductname.Text.ToString();
                string newingredients = txtbxingredients.Text.ToString();
                string newprice = txtbxprice.Text.ToString();
                string newstatus = comboBoxstatus.Text.ToString();
                string newimageloc = txtbximageloc.Text.ToString();
                if (rsaction.UpdateProduct(restourantname, oldproductname , newproductname , newingredients , newprice , newstatus , newimageloc) == true)
                {
                    ClearDatas();
                    MessageBox.Show("Product updated successfully");
                    btnview.PerformClick();
                }
            }
            else if (comboBoxproducts.SelectedIndex != -1 && action == "delete")
            {
                string productname = comboBoxproducts.SelectedItem.ToString();
                if (rsaction.DeleteProduct(restourantname, productname) == true)
                {
                    MessageBox.Show("Product deleted successfully !");
                    ClearDatas();
                }
            }
            else
            {
                MessageBox.Show("Name , ingredients , price and status are needed for saving");
            }                       
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Update";
            comboBoxproducts.Visible = true;
            btnview.PerformClick();
            groupBoxdata.Visible = true;           
            btnsave.Visible = true;
            btngetimage.Visible = true;
            action = "update";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Delete";
            comboBoxproducts.Visible = true;
            btnview.PerformClick();
            groupBoxdata.Visible = true;
            btnsave.Visible = true;
            btngetimage.Visible = false;
            action = "delete";
        }
        string actionchange = "";
        private void btnvieworders_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            id = rsaction.GetRestourantId(localusername);
            string name = rsaction.GetRestourantName(id);
            List<string> orderedproductnames;
            List<int> orderedcounts;
            List<int> orderedprices;
            List<string> orderedstatus;
            List<string> orderedingredients;
            List<string> orderedlocation;
            List<string> orderedby;
            int x = 12;
            int y = 20;
            
            rsaction.GetOrders(name, out orderedproductnames, out orderedcounts, out  orderedprices,
                                out orderedstatus, out orderedingredients , out orderedlocation , out orderedby);
            System.Windows.Forms.Button[] buttonchange;
            buttonchange = new System.Windows.Forms.Button[orderedproductnames.Count];
            for (int q = 0; q < orderedproductnames.Count; q++)
            {
                int currentq = q;
                System.Windows.Forms.Label labelproductname = new System.Windows.Forms.Label();
                labelproductname.Name = "orderedproductname" + q.ToString();
                labelproductname.Text = orderedproductnames[q];
                labelproductname.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelproductname.ForeColor = System.Drawing.Color.Black;
                labelproductname.AutoSize = true;
                labelproductname.Location = new Point(x, y);
                panel1.Controls.Add(labelproductname);
                //
                System.Windows.Forms.Label labelorderedcount = new System.Windows.Forms.Label();
                labelorderedcount.Name = "orderedcount" + q.ToString();
                labelorderedcount.Text = orderedcounts[q].ToString();
                labelorderedcount.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelorderedcount.ForeColor = System.Drawing.Color.Black;
                labelorderedcount.AutoSize = true;
                labelorderedcount.Location = new Point(x, y + 29);
                panel1.Controls.Add(labelorderedcount);
                //
                System.Windows.Forms.Label labelorderedprice = new System.Windows.Forms.Label();
                labelorderedprice.Name = "orderedprice" + q.ToString();
                labelorderedprice.Text = orderedprices[q].ToString();
                labelorderedprice.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelorderedprice.ForeColor = System.Drawing.Color.Black;
                labelorderedprice.AutoSize = true;
                labelorderedprice.Location = new Point(x + 119, y + 29);
                panel1.Controls.Add(labelorderedprice);
                //
                System.Windows.Forms.Label labelorderedingredients = new System.Windows.Forms.Label();
                labelorderedingredients.Name = "orderedprice" + q.ToString();
                int m = 0;
                foreach (char p in orderedingredients[q])
                {
                    labelorderedingredients.Text += p.ToString();
                    if (m == 45)
                    {
                        labelorderedingredients.Text += "\n";
                    }
                    m++;
                }
                labelorderedingredients.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelorderedingredients.ForeColor = System.Drawing.Color.Black;
                labelorderedingredients.AutoSize = true;
                labelorderedingredients.Location = new Point(x, y + 61);
                panel1.Controls.Add(labelorderedingredients);
                //                              
                System.Windows.Forms.Label labelorderedlocation = new System.Windows.Forms.Label();
                labelorderedlocation.Name = "orderedlocation" + q.ToString();
                int o = 0;
                foreach (char p in orderedlocation[q])
                {
                    labelorderedlocation.Text += p.ToString();
                    if (o == 45)
                    {
                        labelorderedlocation.Text += "\n";
                    }
                    o++;
                }                
                labelorderedlocation.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelorderedlocation.ForeColor = System.Drawing.Color.Black;
                labelorderedlocation.AutoSize = true;
                labelorderedlocation.Location = new Point(x , y + 105);
                panel1.Controls.Add(labelorderedlocation);
                //
                System.Windows.Forms.Label labelorderedby = new System.Windows.Forms.Label();
                labelorderedby.Name = "orderedby" + q.ToString();
                labelorderedby.Text =  "@" + orderedby[q].ToString();
                labelorderedby.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelorderedby.ForeColor = System.Drawing.Color.Black;
                labelorderedby.AutoSize = true;
                labelorderedby.Location = new Point(x + 151, y );
                panel1.Controls.Add(labelorderedby);
                //
                buttonchange[q] = new System.Windows.Forms.Button();
                buttonchange[q].Name = "btnchange" + q.ToString();
                buttonchange[q].Size = new Size(110, 32);
                buttonchange[q].Location = new Point(x + 287, y + 22);
                buttonchange[q].Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                buttonchange[q].ForeColor = System.Drawing.Color.Black;
                buttonchange[q].BackColor = System.Drawing.Color.White;                
                if (orderedstatus[currentq] == "Order Taken")
                {
                    buttonchange[currentq].Text = "Preparing";
                    actionchange = "prepare";
                    buttonchange[currentq].Click += (s, ev) => ChangeStatus(s, ev, name, orderedby[currentq], orderedproductnames[currentq], actionchange);
                    panel1.Controls.Add(buttonchange[q]);
                    
                    
                }
                else if (orderedstatus[currentq] == "Preparing")
                {
                    buttonchange[currentq].Text = "On the way";
                    actionchange = "on the way";
                    buttonchange[currentq].Click += (s, ev) => ChangeStatus(s, ev, name, orderedby[currentq], orderedproductnames[currentq], actionchange);
                    panel1.Controls.Add(buttonchange[q]);
                }
                else if (orderedstatus[currentq] == "On the way")
                {
                    buttonchange[currentq].Text = "Deliver";
                    actionchange = "deliver";
                    buttonchange[currentq].Click += (s, ev) => ChangeStatus(s, ev, name, orderedby[currentq] , orderedproductnames[currentq] , actionchange);
                   panel1.Controls.Add(buttonchange[q]);
                }
                else if (orderedstatus[currentq] == "Delivered")
                {

                }
                y += 136;
            }
      
        }
        private void ChangeStatus (object sender , EventArgs e , string restourantnameO , string usernameO ,
                                    string productnameO ,  string orderaction)
        {
            if (orderaction == "prepare")
            {
                rsaction.UpdateStatus(restourantnameO, "Preparing", productnameO, usernameO);
                panel1.Controls.Clear();
                btnvieworders.PerformClick();
            }
            else if (orderaction == "on the way")
            {
                rsaction.UpdateStatus(restourantnameO, "On the way", productnameO, usernameO);
                panel1.Controls.Clear();
                btnvieworders.PerformClick();
            }
            else if (orderaction == "deliver")
            {
                rsaction.UpdateStatus(restourantnameO, "Delivered", productnameO, usernameO);
                panel1.Controls.Clear();
                btnvieworders.PerformClick();
            }
        }  
    }
}
