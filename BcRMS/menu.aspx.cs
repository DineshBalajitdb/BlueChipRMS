using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace BcRMS
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add any necessary code for page load events
        }
 
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Navigate to the Breakfast page
            Response.Redirect("Breakfast.aspx");
        }
 
        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Navigate to the Meals page
            Response.Redirect("Meals.aspx");
        }
 
        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Navigate to the Drinks page
            Response.Redirect("Drinks.aspx");
        }
   }
    
}