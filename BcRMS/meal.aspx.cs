using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class meal : System.Web.UI.Page
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
            txtBiriyaniPrice.Text = "150";
            txtPanjabiPrice.Text = "250";
            txtNorthPrice.Text = "200";
            txtSouthPrice.Text = "180";
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
 
        protected void HandleOrder(TextBox quantityTextBox, TextBox priceTextBox)
        {
            int quantity;
            int totalPrice;
            if (int.TryParse(quantityTextBox.Text, out quantity) && int.TryParse(priceTextBox.Text, out totalPrice))
            {
                // Add code to process the order
            }
            else
            {
                // Handle invalid input
            }
        }
 
        protected void txtBiriyaniQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtBiriyaniQty, txtBiriyaniPrice, 150);
        }
 
        protected void btnBiryani_Click(object sender, EventArgs e)
        {
            HandleOrder(txtBiriyaniQty, txtBiriyaniPrice);
        }
 
        protected void txtPanjabiQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtPanjabiQty, txtPanjabiPrice, 250);
        }
 
        protected void btnPanjabi_Click(object sender, EventArgs e)
        {
            HandleOrder(txtPanjabiQty, txtPanjabiPrice);
        }
 
        protected void txtNorthQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtNorthQty, txtNorthPrice, 200);
        }
 
        protected void btnNorth_Click(object sender, EventArgs e)
        {
            HandleOrder(txtNorthQty, txtNorthPrice);
        }
 
        protected void txtSouthQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtSouthQty, txtSouthPrice, 180);
        }
 
        protected void btnSouth_Click(object sender, EventArgs e)
        {
            HandleOrder(txtSouthQty, txtSouthPrice);
        }
    }
}
