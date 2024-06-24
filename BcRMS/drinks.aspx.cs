using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class drinks : System.Web.UI.Page
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
            txtLassiPrice.Text = "40";
            txtLimbuPrice.Text = "20";
            txtFaludaPrice.Text = "80";
            txtChocoPrice.Text = "50";
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
 
        protected void txtLassiQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtLassiQty, txtLassiPrice, 40);
        }
 
        protected void btnLassi_Click(object sender, EventArgs e)
        {
            HandleOrder(txtLassiQty, txtLassiPrice);
        }
 
        protected void txtLimbuQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtLimbuQty, txtLimbuPrice, 20);
        }
 
        protected void btnLimbu_Click(object sender, EventArgs e)
        {
            HandleOrder(txtLimbuQty, txtLimbuPrice);
        }
 
        protected void txtFaludaQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtFaludaQty, txtFaludaPrice, 80);
        }
 
        protected void btnFaluda_Click(object sender, EventArgs e)
        {
            HandleOrder(txtFaludaQty, txtFaludaPrice);
        }
 
        protected void txtChocoQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtChocoQty, txtChocoPrice, 50);
        }
        protected void btnChoco_Click(object sender, EventArgs e)
        {
            HandleOrder(txtChocoQty, txtChocoPrice);
        }
    }
}
