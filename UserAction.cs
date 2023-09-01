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
        string getProducts = "SELECT @info FROM @tablename";
        string getCount = "SELECT COUNT(ProductName) FROM @restourantname";
        
        
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
        public void ShowProducts (string restourantname , out int count  , out List<string> productname,
                                    out List<string> ingredients, out List<string> prices , out List<string> statuses,
                                    out List<string> imagelocations)
        {
            count = 0;
            productname = new List<string>();
            ingredients = new List<string>();
            prices = new List<string>();
            statuses = new List<string>();
            imagelocations = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    getCount = "SELECT COUNT(ProductName) FROM " + restourantname;
                    using (SqlCommand getcountcmd = new SqlCommand(getCount, connection))
                    {
                        count = Convert.ToInt32(getcountcmd.ExecuteScalar());
                    }
                    getProducts = "SELECT ProductName FROM " + restourantname;
                    using (SqlCommand getproductcmd = new SqlCommand(getProducts, connection))
                    {
                        using (SqlDataReader reader = getproductcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string product = reader["ProductName"].ToString();
                                productname.Add(product);
                            }
                        }
                    }
                    getProducts = "SELECT Ingredients FROM " + restourantname;
                    using (SqlCommand getproductcmd = new SqlCommand(getProducts, connection))
                    {
                        using (SqlDataReader reader = getproductcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string ingredient = reader["Ingredients"].ToString();
                                ingredients.Add(ingredient);
                            }
                        }
                    }
                    getProducts = "SELECT Price FROM " + restourantname;
                    using (SqlCommand getproductcmd = new SqlCommand(getProducts, connection))
                    {
                        using (SqlDataReader reader = getproductcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string price = reader["Price"].ToString();
                                prices.Add(price);
                            }
                        }
                    }
                    getProducts = "SELECT Status FROM " + restourantname;
                    using (SqlCommand getproductcmd = new SqlCommand(getProducts, connection))
                    {
                        using (SqlDataReader reader = getproductcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                statuses.Add(status);
                            }
                        }
                    }
                    getProducts = "SELECT ImageLocation FROM " + restourantname;
                    using (SqlCommand getproductcmd = new SqlCommand(getProducts, connection))
                    {
                        using (SqlDataReader reader = getproductcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string imagelocation = reader["ImageLocation"].ToString();
                                imagelocations.Add(imagelocation);
                            }
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }            
        }
        
        




    }
}
