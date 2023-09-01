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
    }
}
