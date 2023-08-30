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

        }
    }
}
