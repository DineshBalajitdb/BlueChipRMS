using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace BcRMS
{
    public partial class demomenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    DisplayUserId();
            //    BindCategoriesDropDown();
            //    DropDownList1_SelectedIndexChanged(sender, e);
                
            //}
            

            if (!IsPostBack)
            {
                //DropDownList1_SelectedIndexChanged(sender, e);
                DisplayUserId();
                BindCategoriesDropDown();
                //DropDownList1_SelectedIndexChanged(sender, e);
                
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory = int.Parse(DropDownList1.SelectedValue);
            ViewState["SelectedCategory"] = selectedCategory;
            BindMenuItems(selectedCategory);
            
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

        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                AddItemToOrder(foodItemId);
            }
            else if (e.CommandName == "cart")
            {
                int foodItemId = Convert.ToInt32(e.CommandArgument);
                AddItemToCart(foodItemId);
            }
        }

        private void AddItemToOrder(int foodItemId)
        {
            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);
            if (menuItem != null)
            {
                List<MenuItem> orderItems = Session["OrderItems"] as List<MenuItem>;
                if (orderItems == null)
                {
                    orderItems = new List<MenuItem>();
                }
                orderItems.Add(menuItem);
                Session["OrderItems"] = orderItems;
                Response.Redirect("~/OrderSummery.aspx");
            }
        }

        private void AddItemToCart(int foodItemId)
        {
            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);
            if (menuItem != null)
            {
                List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;
                if (cartItems == null)
                {
                    cartItems = new List<MenuItem>();
                }
                cartItems.Add(menuItem);
                Session["CartItems"] = cartItems;
                Response.Redirect("~/Cart.aspx");
            }
        }

        private void BindCategoriesDropDown()
        {
            try
            {
                List<BcRMS.CategoryListDataAccessLayer.FoodMenuCategory> categories = CategoryListDataAccessLayer.GetAllCategory();
                DropDownList1.DataSource = categories;
                DropDownList1.DataTextField = "CategoryName";
                DropDownList1.DataValueField = "CategoryId";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select Category", "0"));
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or display error messages
                Response.Write("Error fetching categories: " + ex.Message);
            }
        }
    }
}//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Web.UI.WebControls;
//using System.Web.UI;

//namespace BcRMS
//{
//    public partial class demomenu : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                 DisplayUserId();
//                 // Bind categories to DropDownList
//                 BindCategoriesDropDown();
//                 if (Session["OrderItems"] == null)
//                 {
//                     Session["OrderItems"] = new List<MenuItem>();
//                 }

//            }
            
              
//       }
//        //protected void Page_PreLoad(object sender, EventArgs e)
//        //{
//        //    if (ViewState["SelectedCategory"] != null)
//        //    {
//        //        int selectedCategory = (int)ViewState["SelectedCategory"];
//        //        BindMenuItems(selectedCategory);
//        //    }
//        //}
        
//        private void BindMenuItems(int categoryId)
//        {
//            List<MenuItem> menuItems = MenuDataAccessLayer.GetMenuItemByCategory(categoryId);
//            Repeater1.DataSource = menuItems;
//            Repeater1.DataBind();
//        }

//        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            int selectedCategory = int.Parse(DropDownList1.SelectedValue);
//            ViewState["SelectedCategory"] = selectedCategory;
//            if (ViewState["SelectedCategory"] != null)
//            {
//                selectedCategory = (int)ViewState["SelectedCategory"];
//                BindMenuItems(selectedCategory);
//            }

         

//        }
//        protected string GetBase64Image(object dataItem)
//        {
//            try
//            {
//                if (dataItem == null) return "";
//                MenuItem menuItem = dataItem as MenuItem;
//                if (menuItem == null || menuItem.ImageData == null || menuItem.ImageData.Length == 0) return "";
//                return "data:image/jpeg;base64," + Convert.ToBase64String(menuItem.ImageData);
//            }
//            catch (Exception)
//            {
//                return ""; // Optionally log the error
//            }
//        }
//        private void DisplayUserId()
//        {
//            if (Session["UserName"] != null)
//            {
//                string userId = Session["UserName"].ToString();
//                lblUserId.Text = "User ID: " + userId;
//            }
//        }
        
//        protected void btnLogout_Click(object sender, EventArgs e)
//        {
                
//            Session.Clear();
//            Response.Redirect("~/Loginpage.aspx");
//        }
//        protected void Repeater1_ItemCommand1(object source, RepeaterCommandEventArgs e)
//        {
//            DataBind();
//            if (e.CommandName == "Order")
//            {
//                int foodItemId = Convert.ToInt32(e.CommandArgument);
//                AddItemToOrder(foodItemId);

//            }
//            else if (e.CommandName == "cart")
//            {
//                int foodItemId = Convert.ToInt32(e.CommandArgument);
//                AddItemToCart(foodItemId);


//            }
//        }
//        private void AddItemToOrder(int foodItemId)
//        {
//            // Retrieve the selected menu item from database or session
//            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);
//            if (menuItem != null)
//            {
//                List<MenuItem> orderItems = Session["OrderItems"] as List<MenuItem>;
//                if (orderItems == null)
//                {
//                    orderItems = new List<MenuItem>();
//                }
//                orderItems.Add(menuItem);
//                Session["OrderItems"] = orderItems;

//                // Optionally, you can redirect to an order summary page or update UI to reflect item added to order
//                Response.Redirect("~/OrderSummery.aspx");
//            }
//        }
//        private void AddItemToCart(int foodItemId)
//        {
//            // Retrieve the selected menu item from database or session
//            MenuItem menuItem = MenuDataAccessLayer.GetMenuItemByFoodId(foodItemId);
//            if (menuItem != null)
//            {
//                List<MenuItem> cartItems = Session["CartItems"] as List<MenuItem>;
//                if (cartItems == null)
//                {
//                    cartItems = new List<MenuItem>();
//                }
//                cartItems.Add(menuItem);
//                Session["CartItems"] = cartItems;

//                // Optionally, you can redirect to a cart page or update UI to reflect item added to cart
//                Response.Redirect("~/Cart.aspx");
//            }
//        }

       
//        // Get the Binding the Category 
//        private void BindCategoriesDropDown()
//        {
//            try
//            {
//                List<CategoryListDataAccessLayer.FoodMenuCategory> categories = CategoryListDataAccessLayer.GetAllCategory();

//                DropDownList1.DataSource = categories;
//                DropDownList1.DataTextField = "CategoryName";
//                DropDownList1.DataValueField = "CategoryId";
//                DropDownList1.DataBind();

//                // Optionally, add a default "Select Category" item
//                DropDownList1.Items.Insert(0, new ListItem("Select Category", "0"));
           
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions, log errors, or display error messages
//                Response.Write("Error fetching categories: " + ex.Message);
//            }
//        }
//    }
//}
