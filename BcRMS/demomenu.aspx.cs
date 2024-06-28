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
                BindMenuItems(0); // 0 for all categories
            }
        }
        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory = int.Parse(ddlCategories.SelectedValue);
            BindMenuItems(selectedCategory);
        }

        private void BindMenuItems(int categoryId)
        {
            List<MenuItem> menuItems = MenuDataAccessLayer.GetMenuItemByCategory(categoryId);
            Repeater1.DataSource = menuItems;
            Repeater1.DataBind();
        }
     
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                // Perform action based on the Buy command
            }
            else if (e.CommandName == "cart")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                // Perform action based on the cart command
            }

            // Optionally, rebind data after command execution
            BindMenuItems(int.Parse(ddlCategories.SelectedValue));
        }
        protected string GetBase64Image(object dataItem)
        {
            try
            {
                if (dataItem == null)
                {
                    // Handle null dataItem
                    return ""; // or return a default image URL
                }

                MenuItem menuItem = dataItem as MenuItem;
                if (menuItem == null)
                {
                    // Handle case where dataItem is not a MenuItem
                    return ""; // or return a default image URL
                }

                if (menuItem.ImageData == null || menuItem.ImageData.Length == 0)
                {
                    // Handle the case where ImageData is null or empty
                    return ""; // or return a default image URL
                }

                // Convert byte array (ImageData) to base64 string
                string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(menuItem.ImageData);
                return base64String;
            }
            catch (Exception ex)
            {
                // Log the exception (using your logging mechanism)
                // Example: Logger.LogError("Error in GetBase64Image: " + ex.Message);

                // Optionally, return a default image URL or an empty string
                return ""; // or return a default image URL
            }
        }

    }
}
