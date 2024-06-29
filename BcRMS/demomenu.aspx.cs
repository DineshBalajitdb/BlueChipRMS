using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class demomenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 DisplayUserId();
                
            }
               
       }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ViewState["SelectedCategory"] != null)
            {
                int selectedCategory = (int)ViewState["SelectedCategory"];
                BindMenuItems(selectedCategory);
            }
        }
        
        private void BindMenuItems(int categoryId)
        {
            List<MenuItem> menuItems = MenuDataAccessLayer.GetMenuItemByCategory(categoryId);
            Repeater1.DataSource = menuItems;
            Repeater1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory = int.Parse(DropDownList1.SelectedValue);
            ViewState["SelectedCategory"] = selectedCategory;
            //BindMenuItems(selectedCategory);

        }
        //protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int selectedCategory = int.Parse(ddlCategories.SelectedValue);
        //        ViewState["SelectedCategory"] = selectedCategory;
        //        BindMenuItems(selectedCategory);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Exception in ddlCategories_SelectedIndexChanged: " + ex.Message);
        //        // Handle parsing exception if necessary
        //        // Example: LogError(ex);
        //    }
        //}
        
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                // Perform action based on the Buy command
            }
            else if (e.CommandName == "cart")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                AddItemToCart(foodItemId);
                // Perform action based on the cart command
            }
            // Optionally, rebind data after command execution
            //BindMenuItems((int)ViewState["SelectedCategory"]);
        }
        protected string GetBase64Image(object dataItem)
        {
            try
            {
                if (dataItem == null) return "";
                MenuItem menuItem = dataItem as MenuItem;
                if (menuItem == null || menuItem.ImageData == null || menuItem.ImageData.Length == 0) return "";
                return "data:image/jpeg;base64," + Convert.ToBase64String(menuItem.ImageData);
            }
            catch (Exception)
            {
                return ""; // Optionally log the error
            }
        }
        private void DisplayUserId()
        {
            if (Session["UserName"] != null)
            {
                string userId = Session["UserName"].ToString();
                lblUserId.Text = "User ID: " + userId;
            }
        }
        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
                
            Session.Clear();
            Response.Redirect("~/Loginpage.aspx");
        }
        private void AddItemToCart(int foodItemId)
        {
            // Retrieve or initialize the cart items
            List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;
            if (cartItems == null)
            {
                cartItems = new List<MenuItem>();
            }

            // Retrieve the selected menu item from database or session
            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);

            // Add the selected menu item to the cart
            if (menuItem != null)
            {
                cartItems.Add(menuItem);

                // Store the updated cart items back in session
                Session["CartItems"] = cartItems;
            }

            // Optionally, you can redirect to a cart page or update UI to reflect item added to cart
            Response.Redirect("~/CartPage.aspx");
        }



       

        


    }
}
