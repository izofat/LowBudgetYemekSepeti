using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
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
            
            if (location == DBNull.Value.ToString())
            {
                MessageBox.Show("Welcome to the LOW BUDGET YEMEKSEPETI \n firstly enter your location");
                string userInput = Interaction.InputBox
            }
        }
    }
}
