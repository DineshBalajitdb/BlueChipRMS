using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BcRMS
{
    public class FoodMenu
    {
        public int FoodItemID { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageDataBase64 { get; set; }

    }
    public class FoodListDataAccessLayer
    {
        public static List<FoodMenu> GetAllFoodMenuItem(int CategoryId)
        {
            List<FoodMenu> listFoodMenu = new List<FoodMenu>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("spGetFoodMenuByCategoryId", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter Parameter = new SqlParameter("@CategoryId", CategoryId);
                cmd.Parameters.Add(Parameter);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        FoodMenu FoodMenu = new FoodMenu();
                        FoodMenu.FoodItemID = Convert.ToInt32(rdr["FoodItemID"]);
                        FoodMenu.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        FoodMenu.CategoryName = rdr["CategoryName"].ToString();
                        FoodMenu.ItemName = rdr["ItemName"].ToString();
                        FoodMenu.Price = Convert.ToDecimal(rdr["Price"]);
                        FoodMenu.ImageData = (byte[])rdr["ImageData"];
                        if (FoodMenu.ImageData != null && FoodMenu.ImageData.Length > 0)
                        {
                            FoodMenu.ImageDataBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(FoodMenu.ImageData);
                        }
                        else
                        {
                            FoodMenu.ImageDataBase64 = ""; // or set to a default image URL
                        }

                        listFoodMenu.Add(FoodMenu);
                    }
                }

            }
            return listFoodMenu;
        }
        public static List<FoodMenu> GetAllFoodMenuItembyFooditemId(int FoodItemID)
        {
            List<FoodMenu> listFoodMenu = new List<FoodMenu>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("spGetFoodMenuByFoodItemId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Parameter = new SqlParameter("@FoodItemId", FoodItemID);
                cmd.Parameters.Add(Parameter);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        FoodMenu FoodMenu = new FoodMenu();
                        FoodMenu.FoodItemID = Convert.ToInt32(rdr["FoodItemID"]);
                        FoodMenu.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        FoodMenu.CategoryName = rdr["CategoryName"].ToString();
                        FoodMenu.ItemName = rdr["ItemName"].ToString();
                        FoodMenu.Price = Convert.ToDecimal(rdr["Price"]);
                        FoodMenu.ImageData = (byte[])rdr["ImageData"];
                        if (FoodMenu.ImageData != null && FoodMenu.ImageData.Length > 0)
                        {
                            FoodMenu.ImageDataBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(FoodMenu.ImageData);
                        }
                        else
                        {
                            FoodMenu.ImageDataBase64 = ""; // or set to a default image URL
                        }

                        listFoodMenu.Add(FoodMenu);
                    }
                }

            }
            return listFoodMenu;
        }
        public static List<FoodMenu> GetBasicFoodMenuItem()
        {
            List<FoodMenu> BasiclistFoodMenu = new List<FoodMenu>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("spGetBasicFoodMenu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        FoodMenu FoodMenu = new FoodMenu();
                        FoodMenu.FoodItemID = Convert.ToInt32(rdr["FoodItemID"]);                       
                        FoodMenu.CategoryName = rdr["CategoryName"].ToString();
                        FoodMenu.ItemName = rdr["ItemName"].ToString();
                        FoodMenu.Price = Convert.ToDecimal(rdr["Price"]);
                        FoodMenu.ImageData = (byte[])rdr["ImageData"];
                        if (FoodMenu.ImageData != null && FoodMenu.ImageData.Length > 0)
                        {
                            FoodMenu.ImageDataBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(FoodMenu.ImageData);
                        }
                        else
                        {
                            FoodMenu.ImageDataBase64 = ""; // or set to a default image URL
                        }

                        BasiclistFoodMenu.Add(FoodMenu);
                    }
                }

            }
            return BasiclistFoodMenu;
        }

        public static void InsertItem(int categoryId, string itemName, decimal price, byte[] bytes)
        {

            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string insertQuery = "Insert Into tbl_FoodMenus Values(@CategoryId,@ItemName,@Price,@ImageData)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);

                #region parameters

                SqlParameter parameter_CategoryId = new SqlParameter();
                parameter_CategoryId.ParameterName = "@CategoryId";
                parameter_CategoryId.Value = categoryId;
                cmd.Parameters.Add(parameter_CategoryId);


                SqlParameter parameter_ItemName = new SqlParameter();
                parameter_ItemName.ParameterName = "@ItemName";
                parameter_ItemName.Value = itemName;
                cmd.Parameters.Add(parameter_ItemName);

                SqlParameter parameter_Price = new SqlParameter();
                parameter_Price.ParameterName = "@Price";
                parameter_Price.Value = price;
                cmd.Parameters.Add(parameter_Price);

                SqlParameter parameter_Image = new SqlParameter();
                parameter_Image.ParameterName = "@ImageData";
                parameter_Image.Value = bytes;
                cmd.Parameters.Add(parameter_Image);

                #endregion
                con.Open();
                cmd.ExecuteNonQuery();



            }
        }

        public static void UpdateItem(int FoodItemId, int CategoryId, string ItemName, decimal Price, byte[] bytes)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string UpdateQuery = "UPDATE tbl_FoodMenus set CategoryId=@CategoryId,ItemName=@ItemName,Price=@Price";
                if (bytes != null)
                {
                    UpdateQuery += ", ImageData = @ImageData";
                }

                UpdateQuery += " WHERE FoodItemId = @FoodItemId";
               
                SqlCommand cmd = new SqlCommand(UpdateQuery, con);

                #region parameters

                SqlParameter parameter_FoodItemId = new SqlParameter();
                parameter_FoodItemId.ParameterName = "@FoodItemId";
                parameter_FoodItemId.Value = FoodItemId;
                cmd.Parameters.Add(parameter_FoodItemId);

                SqlParameter parameter_CategoryId = new SqlParameter();
                parameter_CategoryId.ParameterName = "@CategoryId";
                parameter_CategoryId.Value = CategoryId;
                cmd.Parameters.Add(parameter_CategoryId);


                SqlParameter parameter_ItemName = new SqlParameter();
                parameter_ItemName.ParameterName = "@ItemName";
                parameter_ItemName.Value = ItemName;
                cmd.Parameters.Add(parameter_ItemName);

                SqlParameter parameter_Price = new SqlParameter();
                parameter_Price.ParameterName = "@Price";
                parameter_Price.Value = Price;
                cmd.Parameters.Add(parameter_Price);

                if (bytes != null)
                {
                    SqlParameter parameter_Image = new SqlParameter();
                    parameter_Image.ParameterName = "@ImageData";
                    parameter_Image.Value = bytes;
                    cmd.Parameters.Add(parameter_Image);
                }
                #endregion
                con.Open();
                cmd.ExecuteNonQuery();


            }
        }

        public static void DeleteItem(int FoodItemId)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string DeleteQuery = "Delete From tbl_FoodMenus Where FoodItemId=@FoodItemId";
                SqlCommand cmd = new SqlCommand(DeleteQuery, con);

                #region parameters

                SqlParameter parameter_DeleteItemId = new SqlParameter();
                parameter_DeleteItemId.ParameterName = "@FoodItemId";
                parameter_DeleteItemId.Value = FoodItemId;
                cmd.Parameters.Add(parameter_DeleteItemId);

                #endregion
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
    
}
       
    