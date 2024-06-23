using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BcRMS
{
    public partial class ViewIteam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = FoodListDataAccessLayer.GetAllFoodMenuItem("CategoryId");
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
       
            //Response.Write("Sort Expression +" + e.SortExpression);
            //Response.Write("</br>");
            //Response.Write("Sort Direction +" + e.SortDirection);

            string strSortDirection = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            FoodListDataAccessLayer.GetAllFoodMenuItem(e.SortExpression + " " + strSortDirection);
            GridView1.DataBind();

        }


        
    }
}