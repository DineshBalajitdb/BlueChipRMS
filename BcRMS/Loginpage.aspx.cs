using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Net;
using System.Net.Mail;

namespace BcRMS
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
                lblError.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginType = ddlLoginType.SelectedValue;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();


            AuthenticateUser(username, password, loginType);
        }
        protected void btnSendPasswordReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetUserPassword", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", email);
                    cmd.Parameters.AddWithValue("@mobileNumber", phoneNumber);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@Password";
                    outputParameter.SqlDbType = SqlDbType.VarChar;
                    outputParameter.Size = 100; // Adjust the size as needed
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string userPassword = outputParameter.Value.ToString();

                    if (!string.IsNullOrEmpty(userPassword))
                    {
                        SendPasswordResetEmail(email, userPassword);
                        lblError.Text = "Password reset link has been sent to your phone number.";
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "User not found.";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Visible = true;
                    }
                }
            }
            
            ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "closeModal();", true);
        }

        protected void btnSendUsername_Click(object sender, EventArgs e)
        {
            string MobileNumber = txtMobileNumber.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetUserNameByNumber",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Number", MobileNumber);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@Username";
                    outputParameter.SqlDbType = SqlDbType.VarChar;
                    outputParameter.Size = 100;
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string UserName = outputParameter.Value.ToString();
                    if (!string.IsNullOrEmpty(UserName))
                    {
                        SendUserNameEmail(UserName);
                    }
                }
            }
            lblError.Text = "Your username has been sent to your email address.";
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "closeModal", "closeModal();", true);
        }
        // Method to send UserName By Email
        private void SendUserNameEmail( string UserName)
        {
            var fromAddress = "dineshbalajitdb@gmail.com";
            var mailMessage = new MailMessage(fromAddress, UserName)
            { 
              Subject = "UserId Remainder",
                
                Body = String.Format(" Dear {0},\n\n"+

                "We have received a request to remind your UserId. Your UserId is provided below:\n\n"+

                "UserId: {1}\n\n"+

                "For security reasons, we recommend save the UserId after logging in.\n\n"+

                "If you did not request a password UserId, please contact our support team immediately.\n\n"+

                "Thank you,\n"+
                "BcRMS Support Team\n", UserName, UserName)
                };
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network

            };
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("UserId sented through Email successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(String.Format("SmtpException caught: {0}", ex.Message));
                if (ex.InnerException != null)
                {
                    Console.WriteLine(String.Format("Inner Exception: {0}", ex.InnerException.Message));
                }
                throw; // Re-throw the exception to let it propagate further if needed
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Exception caught: {0}", ex.Message));
                throw; // Re-throw the exception to let it propagate further if needed
            }
        }
        // Method to send password reset email
         private void SendPasswordResetEmail(string recipientEmail, string password)
        {
            var fromAddress = "dineshbalajitdb@gmail.com";
            var fromPassword = "phmu xoru wqoc rxoa"; // Use the app-specific password here
            var mailMessage = new MailMessage(fromAddress, recipientEmail)
            {
                Subject = "Password Reset Request",
                
                Body = String.Format(" Dear {0},\n\n"+

                "We have received a request to reset your password. Your current password is provided below:\n\n"+

                "Password: {1}\n\n"+

                "For security reasons, we recommend changing your password after logging in. You can do this by navigating to the 'Change Password' section under your account settings.\n\n"+

                "If you did not request a password reset, please contact our support team immediately.\n\n"+

                "Thank you,\n"+
                "BcRMS Support Team\n", recipientEmail, password)
                };


            var smtpClient = new SmtpClient("smtp.gmail.com", 587) // Use port 587 for TLS
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Password reset email sent successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(String.Format("SmtpException caught: {0}",ex.Message));
                if (ex.InnerException != null)
                {
                    Console.WriteLine(String.Format("Inner Exception: {0}",ex.InnerException.Message));
                }
                throw; // Re-throw the exception to let it propagate further if needed
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Exception caught: {0}", ex.Message));
                throw; // Re-throw the exception to let it propagate further if needed
            }
        }


        private void AuthenticateUser(string username, string password, string loginType)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("spAuthenticationUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", loginType);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string roleName = reader["roleName"].ToString();
                            Session["UserName"] = reader["username"].ToString();
                            Session["MobileNo"] = reader["mobilenumber"].ToString();

                            if (roleName == "admin")
                            {
                                Response.Redirect("~/AdminPage.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/MealPage.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login failed. Please check your credentials.'); window.location='Loginpage.aspx';", true);
                           
                            //lblError.Text = "Login failed. Please check your credentials.";
                        }
                    }
                }
            }
        }

 
    }
}
