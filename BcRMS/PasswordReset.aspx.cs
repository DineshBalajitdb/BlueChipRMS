using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BcRMS
{
    public partial class PassWordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool CompareStrings(string str1, string str2)
        {
            // Using string.Equals() method for comparison
            return string.Equals(str1, str2);
        }

        protected void btnSendPasswordReset_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text.Trim();
            string OldPassword = txtoldPassword.Text.Trim();
            string Password = txtconformPassword.Text.Trim();
            string MobileNumber = txtPhoneNumber.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con =new SqlConnection(connectionString))
            {
                con.Open();
                using(SqlCommand cmd =new SqlCommand("spGetUserPassword",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", Email);
                    cmd.Parameters.AddWithValue("@mobileNumber", MobileNumber);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@Password";
                    outPutParameter.SqlDbType = SqlDbType.VarChar;
                    outPutParameter.Size = 100;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    cmd.ExecuteNonQuery();
                    string PassWord = outPutParameter.Value.ToString();

                    if (!string.IsNullOrEmpty(Password)&&CompareStrings(OldPassword,Password))
                    {
                          string Query = "UPDATE tbl_Registration SET password=@Password WHERE username=@UserName AND mobilenumber=@MobileNUmber";
                          using (SqlCommand updateCmd = new SqlCommand(Query, con))
                          {
                              updateCmd.Parameters.AddWithValue("@Password", Password);
                              updateCmd.Parameters.AddWithValue("@UserName", Email);
                              updateCmd.Parameters.AddWithValue("@MobileNUmber", MobileNumber);

                              int rowsAffected = updateCmd.ExecuteNonQuery();
                              if (rowsAffected > 0)
                              {
                                  // Password updated successfully                                  
                                  Response.Write("<script>alert('Password updated successfully!');</script>");
                              }
                              else
                              {
                                  // No rows affected; handle accordingly
                                  Response.Write("<script>alert('Password update failed!');</script>");
                              }

                          }
                    }
                    else
                    {
                        // Handle incorrect old password scenario
                        Response.Write("<script>alert('Incorrect old password!');</script>");
                    }
                }
            }
        }
    }
}