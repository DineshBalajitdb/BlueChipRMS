using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BcRMS
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Optional: Initialize fields or perform any setup on page load
            }
        }

        protected void btnProcessPayment_Click(object sender, EventArgs e)
        {
            // Retrieve payment information from form controls
            string cardNumber = txtCardNumber.Text.Trim();
            string nameOnCard = txtNameOnCard.Text.Trim();
            int expirationMonth = Convert.ToInt32(ddlExpirationMonth.Value);
            // Retrieve CVV and Billing Address from form controls as needed
            string cvv = txtCVV.Text.Trim();
            string billingAddress = txtBillingAddress.Text.Trim();

            // Validate payment details (example validation)
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(nameOnCard) || expirationMonth <= 0 || string.IsNullOrEmpty(cvv) || string.IsNullOrEmpty(billingAddress))
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Process payment (example: save to database or send to payment gateway)
            bool paymentProcessedSuccessfully = ProcessPayment(cardNumber, nameOnCard, expirationMonth, cvv, billingAddress);

            if (paymentProcessedSuccessfully)
            {

                string script = @"
                alert('Payment successful. You will be redirected to the Menu page shortly.');
                setTimeout(function(){ window.location.href = 'MealPage.aspx'; }, 5000);";
                ClientScript.RegisterStartupScript(this.GetType(), "PaymentSuccessScript", script, true);
               
                
            }
            else
            {
                lblErrorMessage.Text = "Payment processing failed. Please try again later.";
                lblErrorMessage.Visible = true;
            }
        }

        private bool ProcessPayment(string cardNumber, string nameOnCard, int expirationMonth, string cvv, string billingAddress)
        {
            // Implement your payment processing logic here
            // For demonstration, this method always returns true (simulates successful payment)

            // Connection string (make sure to replace with your actual connection string)
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            // SQL query to insert payment data into the database
            string query = "INSERT INTO CustomerCardDetails (CardNumber, NameOnCard, ExpirationMonth, CVV, BillingAddress) VALUES (@CardNumber, @NameOnCard, @ExpirationMonth, @CVV, @BillingAddress)";

            // Use ADO.NET to connect to the database and execute the query
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CardNumber", cardNumber);
                    command.Parameters.AddWithValue("@NameOnCard", nameOnCard);
                    command.Parameters.AddWithValue("@ExpirationMonth", expirationMonth);
                    command.Parameters.AddWithValue("@CVV", cvv);
                    command.Parameters.AddWithValue("@BillingAddress", billingAddress);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        lblErrorMessage.Text = "Error: " + ex.Message;
                        lblErrorMessage.Visible = true;
                        return false;
                    }
                }
            }
            
        }
    }
}