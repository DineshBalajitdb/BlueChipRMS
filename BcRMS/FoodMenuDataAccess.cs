 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BcRMS
{
    public class FoodMenu
    {
       
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageDataBase64 { get; set; }
        
    }
    public class FoodListDataAccessLayer
    {
        public static List<FoodMenu> GetAllFoodMenuItem(string sortColumn)
        {
            List<FoodMenu> listFoodMenu = new List<FoodMenu>();
            string connectionString = @"Data Source=BC-SL2024A\MSSQLSERVER1;Initial Catalog=RMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT  CategoryId, ItemName, Price, ImageData FROM tbl_FoodMenus";
                if (!string.IsNullOrEmpty(sortColumn))
                {
                    sqlQuery += " Order by " + sortColumn;
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    
                    
                    while (rdr.Read())
                    {

                            FoodMenu FoodMenu = new FoodMenu();
                            FoodMenu.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                            FoodMenu.ItemName = rdr["ItemName"].ToString();
                            FoodMenu.Price = Convert.ToDecimal(rdr["Price"]);
                            FoodMenu.ImageData = (byte[])rdr["ImageData"];
                           if (FoodMenu.ImageData != null && FoodMenu.ImageData.Length > 0)
                            {
                                FoodMenu.ImageDataBase64 ="data:image/jpeg;base64,"+Convert.ToBase64String(FoodMenu.ImageData);
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

        internal static object GetAllFoodMenuItem()
        {
            throw new NotImplementedException();
        }
    }
}