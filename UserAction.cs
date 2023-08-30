using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Food_Delivery_Platform
{
    internal class UserAction
    {
        string Path = "Data Source=DESKTOP-MK22APG\\SQLEXPRESS;Initial Catalog=FoodCompany;Integrated Security=True";
        string getLocation = "SELECT Location From Users WHERE UserName = @username";
        string updateLocation = "Update Users SET Location = @location WHERE UserName = @username";

        public string CheckLocation(string username)
        {
            string location = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using (SqlCommand getloccmd = new SqlCommand(getLocation, connection))
                    {
                        getloccmd.Parameters.AddWithValue("@username", username);
                        location = getloccmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }          
            return location;
        }

        public bool SetLocation(string username , string location)
        {
            bool stat = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using(SqlCommand updateloccmd = new SqlCommand(updateLocation, connection))
                    {
                        updateloccmd.Parameters.AddWithValue("@username", username);
                        updateloccmd.Parameters.AddWithValue("@location", location);
                        updateloccmd.ExecuteNonQuery();
                    }
                }
                stat = true;
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
            return stat;
        }










    }
}
