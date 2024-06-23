using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace BcRMS
{
    public partial class Registrationpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
              notificationlbl.Visible = false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                // Get the form values
                string userName = TextBox6.Text;
                string password = TextBox7.Text;
                string mobilenumber = TextBox4.Text;                


                // Hash the password
                string passwordHash = ComputeSha256Hash(password);

                // Save the user data to the database
                string errorMessage;
                bool success = SaveUser(userName, passwordHash, mobilenumber,out errorMessage);

                if (success)
                {
                    // Redirect to the login page
                   
                    notificationlbl.Text = "Registered successful!";
                    notificationlbl.Visible = true;
                    Response.Redirect("Loginpage.aspx");
                }
                else
                {
                    // Display the error message
                    
                    notificationlbl.Text = errorMessage;
                    notificationlbl.ForeColor = System.Drawing.Color.Red; // Set the text color to red for error messages
                    notificationlbl.Visible = true;
                }
            }
        


        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool SaveUser(string userName, string passwordHash, string mobilenumber,out string errorMessage)
        {
            string connectionString = @"Data Source=BC-SL2024A\MSSQLSERVER1;Initial Catalog=RMS;Integrated Security=True";
            errorMessage = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Check if the username  already exists
                    string checkQuery = "SELECT COUNT(*) FROM tbl_Registration WHERE username = @UserName AND password=@Password";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@UserName", userName);
                        checkCommand.Parameters.AddWithValue("@Password", passwordHash);
                      

                        connection.Open();
                        int count = (int)checkCommand.ExecuteScalar();
                        connection.Close();

                        if (count > 0)
                        {
                            errorMessage = "A user with the same username already exists.";
                            return false;
                        }
                        else
                        {
                            string query = "INSERT INTO tbl_Registration (username, password, mobilenumber)" +
                                 "VALUES (@UserName, @PasswordHash, @MobileNumber)";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@UserName", userName);
                                command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                                command.Parameters.AddWithValue("@MobileNumber", mobilenumber);
                               

                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();

                            }

                            return true;
                        }
                    }

                    // If no duplicate is found, proceed to insert the new user

                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }

    }
}