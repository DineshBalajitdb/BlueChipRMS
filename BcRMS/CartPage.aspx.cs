using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }

        private void BindCartItems()
        {
            List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;
            if (cartItems != null && cartItems.Count > 0)
            {
                RepeaterCartItems.DataSource = cartItems;
                RepeaterCartItems.DataBind();

                decimal totalPrice = 0;
                foreach (MenuItem item in cartItems)
                {
                    totalPrice += item.Price;
                }
                lblTotalPrice.Text = "Total: " + totalPrice.ToString("C");
            }
            else
            {
                RepeaterCartItems.DataSource = null;
                RepeaterCartItems.DataBind();
                lblTotalPrice.Text = "Your cart is empty.";
            }
        }

        protected void RepeaterCartItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                RemoveItemFromCart(foodItemId);
                BindCartItems();
            }
        }

        private void RemoveItemFromCart(int foodItemId)
        {
            List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;
            if (cartItems != null)
            {
                MenuItem itemToRemove = cartItems.Find(item => item.FoodItemID == foodItemId);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);
                    Session["CartItems"] = cartItems;
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Implement checkout logic here
            Response.Redirect("~/Checkout.aspx");
        }
    }
}