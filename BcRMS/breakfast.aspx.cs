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
 
        protected void txtidliQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtidliQty, txtidliPrice, 40);
        }
 
        protected void btnidli_Click(object sender, EventArgs e)
        {
            HandleOrder(txtidliQty, txtidliPrice);
        }
 
        protected void txtdosaQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtdosaQty, txtdosaPrice, 50);
        }
 
        protected void btndosa_Click(object sender, EventArgs e)
        {
            HandleOrder(txtdosaQty, txtdosaPrice);
        }
 
        protected void txtpuriQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtpuriQty, txtpuriPrice, 60);
        }
 
        protected void btnpuri_Click(object sender, EventArgs e)
        {
            HandleOrder(txtpuriQty, txtpuriPrice);
        }
 
        protected void txtteaQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtteaQty, txtteaPrice, 10);
        }
        protected void btntea_Click(object sender, EventArgs e)
        {
            HandleOrder(txtteaQty, txtteaPrice);
        }
    }
 }
