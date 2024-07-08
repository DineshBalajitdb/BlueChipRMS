using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace BcRMS
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmail.Text.Trim();

            // Check if the email exists in the database
            if (IsEmailRegistered(userEmail))
            {
                // Generate a password reset link
                string resetLink = GeneratePasswordResetLink(userEmail);

                // Send the password reset link to the user's email
                if (SendPasswordResetEmail(userEmail, resetLink))
                {
                    lblMessage.Text = "A password reset link has been sent to your email address.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Error sending email. Please try again.";
                }
            }
            else
            {
                lblMessage.Text = "This email address is not registered.";
            }
        }

        private bool IsEmailRegistered(string email)
        {

            return true;
        }

        private string GeneratePasswordResetLink(string email)
        {
            // Generate a unique token and create a reset link
            // This is a placeholder, replace it with actual token generation and link creation
            string token = Guid.NewGuid().ToString();
            string resetLink = "http://yourwebsite.com/ResetPassword.aspx?token=" + token;
            return resetLink;
        }

        private bool SendPasswordResetEmail(string email, string resetLink)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("your-email@example.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Password Reset";
                mailMessage.Body = "Please click the following link to reset your password: " + resetLink;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.example.com");
                smtpClient.Port = 25;
                smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-email-password");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}