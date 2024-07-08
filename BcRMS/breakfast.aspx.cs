using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class breakfast : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialPrices();
            }
        }

        private void SetInitialPrices()
        {
            txtidliPrice.Text = "40";
            txtdosaPrice.Text = "50";
            txtpuriPrice.Text = "60";
            txtteaPrice.Text = "10";
        }

        protected void UpdatePrice(TextBox quantityTextBox, TextBox priceTextBox, int unitPrice)
        {
            int quantity;
            if (int.TryParse(quantityTextBox.Text, out quantity))
            {
                priceTextBox.Text = (quantity * unitPrice).ToString();
            }
            else
            {
                // Handle invalid input
                quantityTextBox.Text = "1";
                priceTextBox.Text = unitPrice.ToString();
            }
        }

        protected void HandleOrder(TextBox quantityTextBox, TextBox priceTextBox, string itemName)
        {
            int quantity;
            int totalPrice;
            if (int.TryParse(quantityTextBox.Text, out quantity) && int.TryParse(priceTextBox.Text, out totalPrice))
            {
                // Store order details in session (you can use a database or other storage as well)
                List<OrderItem> cartItems = Session["CartItems"] as List<OrderItem>;

                if (cartItems == null)
                {
                    cartItems = new List<OrderItem>();
                }

                cartItems.Add(new OrderItem { Item = itemName, Quantity = quantity, TotalPrice = totalPrice });
                Session["CartItems"] = cartItems;

                // Optionally, redirect to cart page after adding item
                Response.Redirect("cart.aspx");
            }
            else
            {
                // Handle invalid input
            }
        }

        protected void txtidliQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtidliQty, txtidliPrice, 40);
        }

        protected void btnidli_Click(object sender, EventArgs e)
        {
            HandleOrder(txtidliQty, txtidliPrice, "Idli");
        }

        protected void txtdosaQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtdosaQty, txtdosaPrice, 50);
        }

        protected void btndosa_Click(object sender, EventArgs e)
        {
            HandleOrder(txtdosaQty, txtdosaPrice, "Dosa");
        }

        protected void txtpuriQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtpuriQty, txtpuriPrice, 60);
        }

        protected void btnpuri_Click(object sender, EventArgs e)
        {
            HandleOrder(txtpuriQty, txtpuriPrice, "Puri");
        }

        protected void txtteaQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtteaQty, txtteaPrice, 10);
        }

        protected void btntea_Click(object sender, EventArgs e)
        {
            HandleOrder(txtteaQty, txtteaPrice, "Tea");
        }
    }
}