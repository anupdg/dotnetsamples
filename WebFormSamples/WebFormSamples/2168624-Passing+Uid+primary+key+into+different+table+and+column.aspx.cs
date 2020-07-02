using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class _2168624_Passing_Uid_primary_key_into_different_table_and_column : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = -1;

            SqlConnection connection = new SqlConnection("connectionString");
            // define query to be executed
            string query = @"INSERT INTO user (Email, Password, ...)
                              VALUES (@email, @password,......);
                     SELECT SCOPE_IDENTITY();";

            // set up SqlCommand in a using block   
            using (SqlCommand objCMD = new SqlCommand(query, connection))
            {
                // add parameters using regular ".Add()" method 
                objCMD.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = "'aaaa@gmail.com'";
                objCMD.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = "pwd";
                //...Other parameters
                //..
                // open connection, execute query, close connection
                connection.Open();
                object returnObj = objCMD.ExecuteScalar();

                if (returnObj != null)
                {
                    int.TryParse(returnObj.ToString(), out userId);
                }
            }

            if (userId > 0) {
                query = @"INSERT INTO Wallet (Uid, amount) VALUES (@userId,@amount)";
                using (SqlCommand objCMD = new SqlCommand(query, connection))
                {
                    // add parameters using regular ".Add()" method 
                    objCMD.Parameters.Add("@userId", SqlDbType.Int, 50).Value = userId;
                    objCMD.Parameters.Add("@amount", SqlDbType.Float, 100).Value = 0; //Change type here accordingly
                    //...Other parameters
                    //..
                    // open connection, execute query, close connection
                    connection.Open();
                    object returnObj = objCMD.ExecuteScalar();

                    if (returnObj != null)
                    {
                        int.TryParse(returnObj.ToString(), out userId);
                    }

                }
            }
            connection.Close();
        }
    }
}