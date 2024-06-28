using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
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
                string errorMessage = (string)Session["LoginError"] ?? string.Empty;
                lblError.Text = errorMessage;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string LoginType = ddlLoginType.SelectedValue;
            int loginType = Convert.ToInt16(LoginType);

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string EncrPassword = ComputeSha256Hash(password);
            DataSet dsUser = AuthenticateUser(username,EncrPassword,loginType);
            if (loginType == 0)
            {
                Response.Redirect("~/AdminPage.aspx");
            }
            else
            {
                if (dsUser != null && dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                {
                    Session["UserName"] = dsUser.Tables[0].Rows[0]["username"].ToString();
                    Session["MobileNo"] = dsUser.Tables[0].Rows[0]["mobilenumber"].ToString();
                    Response.Redirect("~/menu.aspx");
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login failed. Please check your credentials.');", true);
                }
            }
        }
        public DataSet AuthenticateUser(string strUserId, string strPassword, int loginType)
        {
        DataSet dsUser = new DataSet();
        string connectionString = @"Data Source=BC-SL2024A\MSSQLSERVER1;Initial Catalog=RMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlDataAdapter sdaAut = new SqlDataAdapter("spAuthenticationUser", con))
                    {
                        if (loginType == 0 || loginType == 1)
                        {
                            sdaAut.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sdaAut.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 40).Value = strUserId;
                            sdaAut.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = strPassword;
                            sdaAut.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar, 30).Value = loginType;
                            sdaAut.Fill(dsUser);

                  
                        }
                    }
                }
                catch (Exception)
                {
                     if (con.State == ConnectionState.Open)
                      con.Close();
                }
            }
             return dsUser;
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
    }
}