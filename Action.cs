using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Delivery_Platform
{
    internal class Action : FoodDeliveryPlatform
    {
        string Path = "Data Source=DESKTOP-MK22APG\\SQLEXPRESS;Initial Catalog=FoodCompany;Integrated Security=True";
        string idsPathBs = "SELECT ID FROM BusinessUsers";
        string SignUpPathBs = "INSERT INTO BusinessUsers (ID,UserName,Password) VALUES(@id , @username,@password) ";
        string CheckPathBs = "SELECT COUNT(*) FROM BusinessUsers WHERE UserName = @username";
        string getPwPathBs = "SELECT Password FROM BusinessUsers WHERE UserName = @username";
        string idsPathUs = "SELECT ID FROM Users";
        string SignUpPathUs = "INSERT INTO Users (ID,UserName,Password,Balance) VALUES(@id , @username,@password , @balance) ";
        string CheckPathUs = "SELECT COUNT(*) FROM Users WHERE UserName = @username";
        string getPwPathUs = "SELECT Password FROM Users WHERE UserName = @username";
        public void SignUpBusiness(string username, string password)
        {


            try
            {
                using (SqlConnection userconnection = new SqlConnection(Path))
                {
                    userconnection.Open();
                    using (SqlCommand checkcmd = new SqlCommand(CheckPathBs, userconnection))
                    {
                        checkcmd.Parameters.AddWithValue("username", username);
                        int i = Convert.ToInt32(checkcmd.ExecuteScalar());
                        userconnection.Close();
                        if (i == 0)
                        {
                            int newid = 0;
                            using (SqlConnection idconnection = new SqlConnection(Path))
                            {
                                idconnection.Open();

                                List<int> ids = new List<int>();
                                using (SqlCommand findidcmd = new SqlCommand(idsPathBs, idconnection))
                                {

                                    using (SqlDataReader reader = findidcmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            int id = Convert.ToInt32(reader["ID"]);
                                            ids.Add(id);
                                        }
                                    }

                                }
                                idconnection.Close();
                                while (ids.Contains(newid))
                                {
                                    newid++;
                                }
                            }
                            using (SqlConnection connectionsign = new SqlConnection(Path))
                            {
                                connectionsign.Open();
                                using (SqlCommand signupcmd = new SqlCommand(SignUpPathBs, connectionsign))
                                {
                                    string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
                                    signupcmd.Parameters.AddWithValue("@id", newid.ToString());
                                    signupcmd.Parameters.AddWithValue("@username", username);
                                    signupcmd.Parameters.AddWithValue("@password", hashedpassword);

                                    signupcmd.ExecuteNonQuery();
                                }
                                connectionsign.Close();
                            }
                            MessageBox.Show("Sign up successfully !");
                        }
                        else
                        {
                            MessageBox.Show("an error occurred in database");

                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occurred in database");
            }
        }
        public int LogInBusiness(string username, string password)
        {
            int num = 1;
            using (SqlConnection connectionlogin = new SqlConnection(Path))
            {

                int i = 0;
                connectionlogin.Open();
                using (SqlCommand checkusernamecmd = new SqlCommand(CheckPathBs, connectionlogin))
                {
                    checkusernamecmd.Parameters.AddWithValue("@username", username);
                    i = Convert.ToInt32(checkusernamecmd.ExecuteScalar());
                }
                connectionlogin.Close();
                if (i == 1)
                {
                    connectionlogin.Open();
                    using (SqlCommand getpassword = new SqlCommand(getPwPathBs, connectionlogin))
                    {
                        getpassword.Parameters.AddWithValue("@username", username);
                        string encryptedpassword = getpassword.ExecuteScalar()?.ToString();
                        bool check = BCrypt.Net.BCrypt.Verify(password, encryptedpassword);

                        if (check == true)
                        {
                            connectionlogin.Close();
                            num = 0;
                        }
                        else
                        {
                            MessageBox.Show("Password or Username is wrong !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password or Username is wrong !");
                }
            }
            return num;
        }
        public void SignUpCustomer(string username, string password)
        {
            string error;
            try
            {
                using (SqlConnection userconnection = new SqlConnection(Path))
                {
                    userconnection.Open();
                    using (SqlCommand checkcmd = new SqlCommand(CheckPathUs, userconnection))
                    {
                        checkcmd.Parameters.AddWithValue("username", username);
                        int i = Convert.ToInt32(checkcmd.ExecuteScalar());
                        userconnection.Close();
                        if (i == 0)
                        {
                            int newid = 0;
                            using (SqlConnection idconnection = new SqlConnection(Path))
                            {
                                idconnection.Open();

                                List<int> ids = new List<int>();
                                using (SqlCommand findidcmd = new SqlCommand(idsPathUs, idconnection))
                                {

                                    SqlDataReader reader = findidcmd.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        int id = Convert.ToInt32(reader["ID"]);
                                        ids.Add(id);
                                    }

                                }
                                idconnection.Close();
                                while (ids.Contains(newid))
                                {
                                    newid++;
                                }
                            }
                            using (SqlConnection connectionsign = new SqlConnection(Path))
                            {
                                connectionsign.Open();
                                using (SqlCommand signupcmd = new SqlCommand(SignUpPathUs, connectionsign))
                                {
                                    string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
                                    signupcmd.Parameters.AddWithValue("@id", newid.ToString());
                                    signupcmd.Parameters.AddWithValue("@username", username);
                                    signupcmd.Parameters.AddWithValue("@password", hashedpassword);
                                    signupcmd.Parameters.AddWithValue("@balance", 0);
                                    signupcmd.ExecuteNonQuery();
                                }
                                connectionsign.Close();
                            }
                            MessageBox.Show("Sign up successfully !");
                        }
                        else
                        {
                            error = "u";
                            ErrorAccrued(error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                error = "d";
                ErrorAccrued(error);
            }
        }
        public int LogIncustomer(string username, string password)
        {
            int num = 1;
            using (SqlConnection connectionlogin = new SqlConnection(Path))
            {
                int i = 0;
                connectionlogin.Open();
                using (SqlCommand checkusernamecmd = new SqlCommand(CheckPathUs, connectionlogin))
                {
                    checkusernamecmd.Parameters.AddWithValue("@username", username);
                    i = Convert.ToInt32(checkusernamecmd.ExecuteScalar());
                }
                connectionlogin.Close();
                if (i == 1)
                {
                    connectionlogin.Open();
                    using (SqlCommand getpassword = new SqlCommand(getPwPathUs, connectionlogin))
                    {
                        getpassword.Parameters.AddWithValue("@username", username);
                        string encryptedpassword = getpassword.ExecuteScalar()?.ToString();
                        bool check = BCrypt.Net.BCrypt.Verify(password, encryptedpassword);
                        connectionlogin.Close();
                        if (check == true)
                        {
                            num = 0;
                        }
                        else
                        {
                            MessageBox.Show("Password or Username is wrong !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password or Username is wrong !");
                }
            }
            return num;
        }
    }
}
