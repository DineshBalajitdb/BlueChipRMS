using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BcRMS
{
    public class CategoryListDataAccessLayer
    {
        public class FoodMenuCategory
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

        }
        public static List<FoodMenuCategory> GetAllCategory()
        {
            List<FoodMenuCategory> FoodMenu = new List<FoodMenuCategory>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spGetCategory", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        FoodMenuCategory FoodMenuCategory = new FoodMenuCategory();

                        FoodMenuCategory.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        FoodMenuCategory.CategoryName = rdr["CategoryName"].ToString();

                        FoodMenu.Add(FoodMenuCategory);
                    }

                }
            }
            return FoodMenu;

        }
    }
}