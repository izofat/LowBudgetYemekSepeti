using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery_Platform
{
    internal class UserAction
    {
        string Path = "Data Source=DESKTOP-MK22APG\\SQLEXPRESS;Initial Catalog=FoodCompany;Integrated Security=True";
        string getLocation = "SELECT Location From Users WHERE UserName = @username";


        public string CheckLocation(string username)
        {
            string location = "";
            using (SqlConnection connection = new SqlConnection(Path))
            {
                connection.Open();
                using (SqlCommand getloccmd = new SqlCommand(getLocation, connection))
                {
                    getloccmd.Parameters.AddWithValue("@username", username);
                    location = getloccmd.ExecuteScalar().ToString();
                }
            }
            return location;

        }












    }
}
