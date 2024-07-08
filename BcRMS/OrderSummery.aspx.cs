//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace BcRMS
//{
//    public partial class OrderSummery : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                // Check if OrderId is in query string
//                if (Session["OrderItems"] != null)
//                {
//                    int orderId = Convert.ToInt32(Request.QueryString["OrderId"]);
//                    DisplayOrderSummary(orderId);
//                }
//            }
//        }

//        private void DisplayOrderSummary(int orderId)
//        {
//            // Retrieve order details from session or database (depending on your implementation)
//            List<BcRMS.Cart.OrderItem> orderItems = Session["OrderItems"] as List<BcRMS.Cart.OrderItem>;

//            // Assuming you have a method to get order details from database
//            // List<OrderItem> orderItems = GetOrderItemsFromDatabase(orderId);

//            if (orderItems != null && orderItems.Count > 0)
//            {
//                // Display order ID
//                lblOrderIdValue.Text = orderId.ToString();

//                // Calculate and display total amount
//                decimal totalAmount = CalculateTotalAmount(orderItems);
//                lblTotalAmountValue.Text = totalAmount.ToString("C");

//                // Bind order items to GridView
//                gvOrderDetails.DataSource = orderItems;
//                gvOrderDetails.DataBind();
//            }
//        }

//        private decimal CalculateTotalAmount(List<BcRMS.Cart.OrderItem> orderItems)
//        {
//            decimal totalAmount = 0;
//            foreach (BcRMS.Cart.OrderItem item in orderItems)
//            {
//                totalAmount += item.TotalPrice;
//            }
//            return totalAmount;
//        }
//    }
//}