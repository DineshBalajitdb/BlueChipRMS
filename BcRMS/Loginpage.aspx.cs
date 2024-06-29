using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;
using System.Web.UI;

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
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string encryptedPassword = ComputeSha256Hash(password);

            AuthenticateUser(username, encryptedPassword, loginType);
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
                                Response.Redirect("~/demomenu.aspx");
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

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
