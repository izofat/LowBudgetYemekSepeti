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
        string getorderIds = "SELECT ID FROM Orders";
        string createneworder = "INSERT INTO ORDERS (ID,RestourantName,ProductName,Ingredients,Count,Price,OrderedBy,Location,Status) " +
                            "VALUES ( @id , @restourantname , @productname ,  @ingredients ," +
                            " @count , @price ,  @username ,  @location ,  @status )";
        string getorders = "SELECT @something FROM Orders WHERE OrderedBy = @username";
        string checkproducts = "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tablename";
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
        public object CheckProducts(string restourantname)
        {
            object stat = "";
            try
            {
                using(SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using(SqlCommand checkcmd = new SqlCommand(checkproducts, connection))
                    {
                        checkcmd.Parameters.AddWithValue("@tablename", restourantname);
                        stat = checkcmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
            return stat;
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
        
        public bool NewOrder (string restourantname , List<string> productnames , List<string>ingredients,
                    List<int> Counts  , List<int> price , string username , string location)
        {
            bool hownow = false;
            try
            {   using (SqlConnection connection = new SqlConnection(Path))
                { 
                    connection.Open();
                    for (int i = 0; i < price.Count; i++)
                    {
                        int newid = 1;
                        List<int> ids = new List<int>();
                        using (SqlCommand newidcmd = new SqlCommand(getorderIds, connection))
                        {
                            using (SqlDataReader reader = newidcmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int existid = Convert.ToInt32(reader["ID"]);
                                    ids.Add(existid);
                                }
                            }
                            while (ids.Contains(newid))
                            {
                                newid++;
                            }
                            using (SqlCommand createordercmd = new SqlCommand(createneworder, connection))
                            {
                                createordercmd.Parameters.AddWithValue("@id", newid.ToString());
                                createordercmd.Parameters.AddWithValue("@restourantname", restourantname);
                                createordercmd.Parameters.AddWithValue("@productname", productnames[i]);
                                createordercmd.Parameters.AddWithValue("@ingredients", ingredients[i]);
                                createordercmd.Parameters.AddWithValue("@count", Counts[i].ToString());
                                createordercmd.Parameters.AddWithValue("@price", price[i].ToString());
                                createordercmd.Parameters.AddWithValue("@username", username);
                                createordercmd.Parameters.AddWithValue("@location", location);
                                createordercmd.Parameters.AddWithValue("@status", "Order Taken");
                                createordercmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                hownow = true;
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
            return hownow;
        }

        public void GetOrders(string username ,  out List<string> productnames , out List<int> counts , 
                            out List<int> prices , out List<string> status )
        {
            productnames = new List<string>(); 
            counts = new List<int>();
            prices = new List<int>();
            status = new List<string>();
            
            
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            getorders = "SELECT ProductName FROM Orders WHERE OrderedBy = @username";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string thing = reader["ProductName"].ToString();
                                        productnames.Add(thing);
                                    }
                                }
                            }
                            break;
                        case 1:
                            getorders = "SELECT Count FROM Orders WHERE OrderedBy = @username";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int thing = Convert.ToInt32(reader["Count"]);
                                        counts.Add(thing);
                                    }
                                }
                            }
                            break;
                        case 2:
                            getorders = "SELECT Price FROM Orders WHERE OrderedBy = @username";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        int thing = Convert.ToInt32(reader["Price"]);
                                        prices.Add(thing);
                                    }
                                }
                            }
                            break;
                        case 3:
                            getorders = "SELECT Status FROM Orders WHERE OrderedBy = @username";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string thing = reader["Status"].ToString();
                                        status.Add(thing);
                                    }
                                }                               
                            }
                            break;       
                    }
                }
                
            }
        }
    }
}
