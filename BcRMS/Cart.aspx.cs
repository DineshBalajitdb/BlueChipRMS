using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check for session data and populate the GridView
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4]
            {
                new DataColumn("ItemName"),
                new DataColumn("Quantity"),
                new DataColumn("Price"),
                new DataColumn("TotalPrice")
            });

            List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;

            if (cartItems != null)
            {
                foreach (CartItem cartItem in cartItems)
                {
                    decimal totalPrice = cartItem.MenuItem.Price * cartItem.Quantity;

                    dt.Rows.Add(cartItem.MenuItem.ItemName, cartItem.Quantity, cartItem.MenuItem.Price.ToString("0.00"), totalPrice.ToString("0.00"));
                }

                gvCart.DataSource = dt;
                gvCart.DataBind();

                decimal totalAmount = CalculateTotalAmount(cartItems);
                lblTotalAmount.Text = "Total Amount: " + totalAmount.ToString("0.00");
            }
        }


        protected decimal CalculateTotalAmount(List<CartItem> cartItems)
        {
            decimal totalAmount = 0;

            foreach (CartItem cartItem in cartItems)
            {
                totalAmount += cartItem.MenuItem.Price * cartItem.Quantity;
            }

            return totalAmount;
        }


        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Retrieve cart items from session
            List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;

            if (cartItems != null && cartItems.Count > 0)
            {
                // Save order details to database
                int orderId = SaveOrderToDatabase(cartItems);

                if (orderId > 0)
                {
                    // Clear cart session
                    Session["CartItems"] = null;

                    // Redirect to order confirmation page with order ID
                    Response.Redirect("orderConfiramtion.aspx?OrderId=" + orderId);
                }
                else
                {
                    // Handle database error or order processing failure
                    Response.Write("<script>alert('Failed to process order. Please try again later.');</script>");
                }
            }
            else
            {
                // Handle case where cart is empty (though button should ideally be disabled in this case)
                Response.Write("<script>alert('Your cart is empty. Please add items to your cart.');</script>");
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            // Retrieve the index of the item to remove from the CommandArgument
            int rowIndex = Convert.ToInt32((sender as Button).CommandArgument);

            // Retrieve cart items from session
            List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;

            if (cartItems != null && cartItems.Count > rowIndex)
            {
                // Remove the item from the list
                cartItems.RemoveAt(rowIndex);

                // Update session with modified cart items
                Session["CartItems"] = cartItems;

                // Rebind the GridView to reflect the changes
                BindGrid();

                // Optionally, you may update the total amount displayed
                decimal totalAmount = CalculateTotalAmount(cartItems);
                lblTotalAmount.Text = "Total Amount: " + totalAmount.ToString("0.00");
            }
        }


        private int SaveOrderToDatabase(List<MenuItem> cartItems)
        {
            // Connection string to your SQL Server database
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Insert into Orders table
                    string insertOrderQuery = "INSERT INTO Orders (OrderDate) VALUES (@OrderDate); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdInsertOrder = new SqlCommand(insertOrderQuery, con);
                    cmdInsertOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    int orderId = Convert.ToInt32(cmdInsertOrder.ExecuteScalar());

                    // Insert into OrderItems table for each item
                    foreach (MenuItem item in cartItems)
                    {
                        // Assuming quantity is 1 for now, you can modify as per your requirements
                        int quantity = 1;
                        decimal totalPrice = item.Price * quantity;

                        string insertItemQuery = "INSERT INTO OrderItems (OrderId, ItemName, Quantity, TotalPrice) " +
                                                 "VALUES (@OrderId, @ItemName, @Quantity, @TotalPrice)";
                        SqlCommand cmdInsertItem = new SqlCommand(insertItemQuery, con);
                        cmdInsertItem.Parameters.AddWithValue("@OrderId", orderId);
                        cmdInsertItem.Parameters.AddWithValue("@ItemName", item.ItemName);
                        cmdInsertItem.Parameters.AddWithValue("@Quantity", quantity);
                        cmdInsertItem.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        cmdInsertItem.ExecuteNonQuery();
                    }

                    return orderId;
                }
            }
            catch (Exception ex)
            {
                // Log error or handle exception
                Console.WriteLine("Error saving order to database: " + ex.Message);
                return 0; // Return 0 to indicate failure
            }
        }
    }
}
