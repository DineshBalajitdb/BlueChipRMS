using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Web;

namespace BcRMS
{
    public partial class InsertFoodItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void page_PreRender(object sender, EventArgs e)
        {
            DetailsView1.Visible = (GridView1.SelectedIndex != -1);

        }

        private bool ItemExists(int categoryId, string itemName)
        {
            string connectionString = @"Data Source=BC-SL2024A\MSSQLSERVER1;Initial Catalog=RMS;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM tbl_FoodMenus WHERE CategoryId = @CategoryId AND ItemName = @ItemName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                DetailsView1.Visible = true;
                DetailsView1.DataBind(); // Refresh the DetailsView data
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(-1);
        }


        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(-1);
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            GridView1.DataBind();
            GridView1.SelectRow(-1);
        }
        protected void DetailsView1_ItemInserting1(object sender, DetailsViewInsertEventArgs e)
        {
            DropDownList categoryDropDown = (DropDownList)DetailsView1.FindControl("DropDownList1");
            int categoryId = Convert.ToInt32(categoryDropDown.SelectedValue);
            string itemName = e.Values["ItemName"].ToString();
            decimal price = Convert.ToDecimal(e.Values["Price"]);
            FileUpload imageUpload = (FileUpload)DetailsView1.FindControl("FileUpload1");

            if (ItemExists(categoryId, itemName))
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This food item already exists in the selected category.');", true);
                return;
            }

            if (imageUpload != null && imageUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(imageUpload.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".png")
                {
                    byte[] bytes = imageUpload.FileBytes;

                    // Set the values for insertion
                    e.Values["categoryId"] = categoryId;
                    e.Values["itemName"] = itemName;
                    e.Values["price"] = price;
                    e.Values["bytes"] = bytes;

                    // The ObjectDataSource will handle the insertion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Image Uploaded Successfully');", true);
                }
                else
                {
                    e.Cancel = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only Image (.jpg, .png, .gif and .bmp) can be Uploaded');", true);
                }
            }
            else
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload an image for the food item.');", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            DropDownList categoryDropDown = (DropDownList)DetailsView1.FindControl("DropDownList1");
            int categoryId = Convert.ToInt32(categoryDropDown.SelectedValue);
            string itemName = e.NewValues["ItemName"].ToString();
            decimal price = Convert.ToDecimal(e.NewValues["Price"]);
            FileUpload imageUpload = (FileUpload)DetailsView1.FindControl("FileUpload1");
            if (imageUpload != null && imageUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(imageUpload.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".bmp" || fileExtension == ".gif" || fileExtension == ".png")
                {
                    byte[] bytes = imageUpload.FileBytes;

                    // Set the values for insertion
                    e.NewValues["categoryId"] = categoryId;
                    e.NewValues["itemName"] = itemName;
                    e.NewValues["price"] = price;
                    e.NewValues["bytes"] = bytes;

                    // The ObjectDataSource will handle the insertion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Image Uploaded Successfully');", true);
                }
                else
                {
                    e.Cancel = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only Image (.jpg, .png, .gif and .bmp) can be Uploaded');", true);
                }
            }
            else
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please upload an image for the food item.');", true);
            }
        }
    }        
}

