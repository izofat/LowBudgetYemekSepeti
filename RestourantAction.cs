using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Delivery_Platform
{
    internal class RestourantAction
    {
        string Path = "Data Source=DESKTOP-MK22APG\\SQLEXPRESS;Initial Catalog=FoodCompany;Integrated Security=True";
        string getId = "SELECT ID FROM BusinessUsers WHERE UserName = @username";
        string getName = "SELECT RestourantName FROM BusinessUsers WHERE ID = @id";
        string updateName = "UPDATE BusinessUsers SET RestourantName = @name WHERE ID = @id";
        string updateLoc = "UPDATE BusinessUsers SET Location = @location WHERE ID = @id";
        string viewProducts = "SELECT ProductName FROM @tablename ";
        string getProductInfo = "SELECT ProductName,Ingredients,Price,Status,ImageLocation FROM @tablename WHERE Productname = @productname";
        string updateProductInfo = "UPDATE @tablename SET ProductName = @productname , Ingredients = @ingredients ,Price = @price , Status = @status , ImageLocation = @imagelocation WHERE Productname = @oldproductname";
        string deleteProduct = "DELETE FROM @tablename WHERE Productname = @productname";
        string getorders = "SELECT @something FROM Orders WHERE RestourantName = @restourantname";
        string updatestatus = "UPDATE Orders SET Status = @status WHERE RestourantName = @restourantname AND " +
                            "OrderedBy = @username AND ProductName = @productname";
        public int GetRestourantId(string username)
        {
            int id = -1;
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                using (SqlCommand getidcmd = new SqlCommand(getId, connection))
                {
                    getidcmd.Parameters.AddWithValue("@username", username);
                    id = Convert.ToInt32(getidcmd.ExecuteScalar());
                }
                connection.Close();
            }
            return id;
        }
        public string GetRestourantName(int id) 
        {
            string name = "";
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                using (SqlCommand getnamecmd = new SqlCommand(getName, connection))
                {
                    getnamecmd.Parameters.AddWithValue("id", id.ToString());
                    name = getnamecmd.ExecuteScalar()?.ToString();
                }
            }
            return name;
        }
        public bool NewRestourant(int id , string name, string location)
        {
            bool status = false;
           
            
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using (SqlCommand updatenamecmd = new SqlCommand(updateName, connection))
                    {
                        updatenamecmd.Parameters.AddWithValue("@id", id.ToString());
                        updatenamecmd.Parameters.AddWithValue("@name", name);
                        updatenamecmd.ExecuteNonQuery();
                    }
                    using (SqlCommand updateloccmd = new SqlCommand(updateLoc, connection))
                    {
                        updateloccmd.Parameters.AddWithValue("@id", id);
                        updateloccmd.Parameters.AddWithValue("@location", location);
                        updateloccmd.ExecuteNonQuery();
                    }
                string newTable = "CREATE TABLE " + name + " (ID varchar(3) , ProductName varchar(30) , Ingredients varchar(200) , Price varchar(5) , Status varchar(15),ImageLocation varchar(200))";
                using (SqlCommand createtablecmd = new SqlCommand(newTable, connection))
                    {                   
                        createtablecmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    status = true;
                }                        
            return status;         
        }
        public bool AddProduct(string restourantname , string productname , string ingredients , string price , string status , string imagelocation)
        {
            bool check = false;
            try
            {
                int newid = 1;
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    string checkId = "SELECT ID FROM " + restourantname;
                    using (SqlCommand checkidcmd = new SqlCommand(checkId, connection))
                    {
                        using (SqlDataReader reader = checkidcmd.ExecuteReader())
                        {
                            List<int> ids = new List<int>();

                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                ids.Add(id);
                            }
                            while (ids.Contains(newid))
                            {
                                newid++;
                            }
                        }

                    }
                    string addProduct = "INSERT INTO " + restourantname + " (ID,ProductName,Ingredients,Price,Status,ImageLocation) VALUES (@id , @productname , @ingredients ,@price , @status ,@imageloc)";
                    using (SqlCommand addcmd = new SqlCommand(addProduct, connection))
                    {
                        addcmd.Parameters.AddWithValue("@id", newid);
                        addcmd.Parameters.AddWithValue("@productname", productname);
                        addcmd.Parameters.AddWithValue("@ingredients", ingredients);
                        addcmd.Parameters.AddWithValue("@price", price);
                        addcmd.Parameters.AddWithValue("@status", status);
                        addcmd.Parameters.AddWithValue("@imageloc", imagelocation);
                        addcmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    check = true;
                }
            }
            catch (Exception ea)
            {

                MessageBox.Show(ea.Message);
            }                
            return check;
        }
        public List<string> ViewProduct(string restourantname)
        {
            List<string> products = new List<string>();
            viewProducts = "SELECT ProductName FROM " + restourantname;
            using(SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                using (SqlCommand viewprodutctcmd = new SqlCommand(viewProducts, connection))
                {
                    using (SqlDataReader reader = viewprodutctcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productname = reader["ProductName"].ToString();
                            products.Add(productname);
                        }
                    }
                }
            }
            return products;
        }
        public List<string> ViewProductInfo (string restourantname , string productname)
        {
            List<string> productinfo = new List<string>();
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                getProductInfo = "SELECT ProductName,Ingredients,Price,Status,ImageLocation FROM "+ restourantname + " WHERE Productname = @productname";
                using (SqlCommand getinfocmd = new SqlCommand(getProductInfo, connection))
                {
                    getinfocmd.Parameters.AddWithValue("@productname", productname);
                    using (SqlDataReader reader = getinfocmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productinfo.Add(reader["ProductName"].ToString());
                            productinfo.Add(reader["Ingredients"].ToString());
                            productinfo.Add(reader["Price"].ToString());
                            productinfo.Add(reader["Status"].ToString());
                            productinfo.Add(reader["ImageLocation"].ToString());
                        }
                    }
                }
            }
            return productinfo;
        }
        public bool UpdateProduct(string restourantname , string oldproductname , string newproductname , string ingredients , string price , string status , string imagelocation)
        {
            bool stat = false;
            try
            {               
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    updateProductInfo = "UPDATE " + restourantname + " SET ProductName = @newproductname , Ingredients = @ingredients ,Price = @price ," +
                        " Status = @status , ImageLocation = @imagelocation WHERE Productname = @oldproductname ";
                    using (SqlCommand updatecmd = new SqlCommand(updateProductInfo, connection))
                    {
                        updatecmd.Parameters.AddWithValue("@oldproductname", oldproductname);
                        updatecmd.Parameters.AddWithValue("@newproductname", newproductname);
                        updatecmd.Parameters.AddWithValue("@ingredients", ingredients);
                        updatecmd.Parameters.AddWithValue("@price", price);
                        updatecmd.Parameters.AddWithValue("@status", status);
                        updatecmd.Parameters.AddWithValue("@imagelocation", imagelocation);
                        updatecmd.ExecuteNonQuery();
                        stat = true;
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
            }            
            return stat;
        }
        public bool DeleteProduct(string restourantname, string productname)
        {
            bool stat = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    deleteProduct = "DELETE FROM " + restourantname + " WHERE Productname = @productname";
                    using (SqlCommand deletecmd = new SqlCommand(deleteProduct, connection))
                    {
                        deletecmd.Parameters.AddWithValue("@productname", productname);
                        deletecmd.ExecuteNonQuery();
                    }                    
                }
            }
            catch(Exception ea)
            {
                MessageBox.Show(ea.Message);
            }
            
            return stat;
        }

        public void GetOrders(string restourantname, out List<string> productnames, out List<int> counts,
                            out List<int> prices, out List<string> status , out List<string> ingredients ,
                            out List<string> location , out List<string> orderedby)
        {
            productnames = new List<string>();
            counts = new List<int>();
            prices = new List<int>();
            status = new List<string>();
            ingredients = new List<string>();
            location = new List<string>();
            orderedby = new List<string>();
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();

                for (int i = 0; i < 7; i++)
                {
                    switch (i)
                    {
                        case 0:
                            getorders = "SELECT ProductName FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
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
                            getorders = "SELECT Count FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
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
                            getorders = "SELECT Price FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
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
                            getorders = "SELECT Status FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
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
                        case 4:
                            getorders = "SELECT Ingredients FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string thing = reader["Ingredients"].ToString();
                                        ingredients.Add(thing);
                                    }
                                }
                            }
                            break;
                        case 5:
                            getorders = "SELECT Location FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string thing = reader["Location"].ToString();
                                        location.Add(thing);
                                    }
                                }
                            }
                            break;
                        case 6:
                            getorders = "SELECT OrderedBy FROM Orders WHERE RestourantName = @restourantname";
                            using (SqlCommand cmd = new SqlCommand(getorders, connection))
                            {
                                cmd.Parameters.AddWithValue("@restourantname", restourantname);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string thing = reader["OrderedBy"].ToString();
                                        orderedby.Add(thing);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
        public void UpdateStatus (string restourantname , string status , string productname , string orderedby)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Path))
                {
                    connection.Open();
                    using (SqlCommand updatecmd = new SqlCommand(updatestatus, connection))
                    {
                        updatecmd.Parameters.AddWithValue("@restourantname", restourantname);
                        updatecmd.Parameters.AddWithValue("@username", orderedby);
                        updatecmd.Parameters.AddWithValue("@productname", productname);
                        updatecmd.Parameters.AddWithValue("@status", status);
                        updatecmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ea)
            {

                MessageBox.Show(ea.Message);
            }
        }
    }
}
