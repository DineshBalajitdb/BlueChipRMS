using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public class CartItem
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }

    public partial class MealPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayUserId();
                BindCategories();
                BindMenuItems(0);
                if (Session["OrderItems"] == null)
                {
                    Session["OrderItems"] = new List<MenuItem>();
                }
            }
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
        protected void btncartClick(object sender, EventArgs e)
        {
            // Your server-side logic here
            Response.Redirect("~/Cart.aspx"); // Example: Redirect to the cart page
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            // Server-side logic here
            // Example: Response.Redirect("ChangePassword.aspx");
        }
        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                DropDownList ddlQuantity = (DropDownList)e.Item.FindControl("ddlQuantity");
                int quantity = int.Parse(ddlQuantity.SelectedValue);
                AddItemToOrder(foodItemId, quantity);

            }
        }
        private void AddItemToOrder(int foodItemId, int quantity)
        {
            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);
            if (menuItem != null)
            {
                List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;
                if (cartItems == null)
                {
                    cartItems = new List<CartItem>();
                }

                // Check if the item is already in the cart
                CartItem existingCartItem = cartItems.FirstOrDefault(item => item.MenuItem.FoodItemID == foodItemId);
                if (existingCartItem != null)
                {
                    // Update the quantity of the existing item
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    // Add a new item to the cart
                    CartItem newCartItem = new CartItem
                    {
                        MenuItem = menuItem,
                        Quantity = quantity
                    };
                    cartItems.Add(newCartItem);
                }

                Session["CartItems"] = cartItems;
            }
            // Show confirmation alert without redirecting
            string script = @"
                alert('Order Added in Cart successful. Visit Cart to Conforme Order.');
                setTimeout(function(){ window.location.href = 'Loginpage.aspx'; }, 5000);";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "OrderSuccessScript", script, true);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedCategoryId = int.Parse(DropDownList1.SelectedValue);
            if (selectedCategoryId != 0)
            {
                BindMenuItems(selectedCategoryId);
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
            }
        }
        private void BindCategories()
        {
            List<BcRMS.CategoryListDataAccessLayer.FoodMenuCategory> categories = CategoryListDataAccessLayer.GetAllCategory();
            DropDownList1.DataSource = categories;
            DropDownList1.DataTextField = "CategoryName";
            DropDownList1.DataValueField = "CategoryId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select a Category", "0"));
        }


      }
}