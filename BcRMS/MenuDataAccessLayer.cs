using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BcRMS
{
    public class MenuItem
    {
        public int FoodItemID { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageDataBase64 { get; set; }

    }
    public static class MenuDataAccessLayer
    {
        public static List<MenuItem> GetMenuItemByCategory(int categoryId)
        
        {
            
            List<MenuItem> BasicMenuItem = new List<MenuItem>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("spGetMenuItemByCategory", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        MenuItem menuItem = new MenuItem();
                        menuItem.FoodItemID = Convert.ToInt32(rdr["FoodItemID"]);
                        menuItem.CategoryName = rdr["CategoryName"].ToString();
                        menuItem.ItemName = rdr["ItemName"].ToString();
                        menuItem.Price = Convert.ToDecimal(rdr["Price"]);
                        menuItem.ImageData = (byte[])rdr["ImageData"];
                        if (menuItem.ImageData != null && menuItem.ImageData.Length > 0)
                        {
                            menuItem.ImageDataBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(menuItem.ImageData);
                        }
                        else
                        {
                            menuItem.ImageDataBase64 = ""; // or set to a default image URL
                        }

                        BasicMenuItem.Add(menuItem);
                    }
                }

            }
            return BasicMenuItem;
        }

        public static MenuItem GetMenuItemByFoodId(int foodItemId)
        {
            MenuItem menuItem = null;
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("spGetFoodItembyFoodId", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@FoodItemID", foodItemId));
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        menuItem = new MenuItem();
                        menuItem.FoodItemID = Convert.ToInt32(rdr["FoodItemID"]);
                        menuItem.CategoryName = rdr["CategoryName"].ToString();
                        menuItem.ItemName = rdr["ItemName"].ToString();
                        menuItem.Price = Convert.ToDecimal(rdr["Price"]);
                        menuItem.ImageData = (byte[])rdr["ImageData"];
                        if (menuItem.ImageData != null && menuItem.ImageData.Length > 0)
                        {
                            menuItem.ImageDataBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(menuItem.ImageData);
                        }
                        else
                        {
                            menuItem.ImageDataBase64 = ""; // or set to a default image URL
                        }
                       
                    }
                }
                return menuItem;
            }
        }
    }
}