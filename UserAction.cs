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
        string updateLocation = "UPDATE Users SET Location = @location WHERE UserName = @username";
        string getRestourants = "SELECT RestourantName FROM BusinessUsers";
        string getProducts = "SELECT ProductName,Ingredients,Price,Status,ImageLocation FROM @tablename";
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

        public List<string> ShowRestourants()
        {
            List<string> restourants = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using (SqlCommand getrestourants = new SqlCommand(getRestourants, connection))
                    {
                        using (SqlDataReader reader = getrestourants.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string restourant = reader["RestourantName"].ToString();
                                restourants.Add(restourant);
                            }
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }            
            return restourants;
        }

        





    }
}
