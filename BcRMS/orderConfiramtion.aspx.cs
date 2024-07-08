using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BcRMS
{
    public partial class orderConfiramtion : System.Web.UI.Page
    {
        // Define public properties for order details accessible in the ASPX page
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve order ID from query string
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
                {
                    OrderId = Convert.ToInt32(Request.QueryString["OrderId"]);
 
                    // Fetch order details from database
                    FetchOrderDetails(OrderId);
                }
            }
        }
 
        private void FetchOrderDetails(int orderId)
        {
            // Connection string to your SQL Server database
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
 
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
 
                    // Query to fetch order details
                    string query = "SELECT OrderDate FROM Orders WHERE OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);
 
                    OrderDate = Convert.ToDateTime(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                // Log error or handle exception
                Console.WriteLine("Error fetching order details: " + ex.Message);
            }
        }
 
        protected void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            // Redirect to payment page
            Response.Redirect("payment.aspx");
        }
    }
}
