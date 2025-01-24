using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop_products : System.Web.UI.Page
{
    SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllCategories();
    }
    [WebMethod]
    public static List<ProductDetails> AllShopProducts(string pno,string Pcat,string PTag)
    {
        SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);
        List<ProductDetails> products = null;
        try
        {
            products = ProductDetails.GetAllProductsByFilter(conAP, Convert.ToInt32(pno),Pcat,PTag);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AllShopProducts", ex.Message);
        }
        return products;
    }
    public void GetAllCategories()
    {
        try
        {
            List<Category> comps = Category.GetAllCategory(conAP);
            if (comps.Count > 0)
            {
                ddlCategory.Items.Clear();
                ddlCategory.DataSource = comps;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataBind();
            }
            ddlCategory.Items.Insert(0, new ListItem("Select a category to filter products", ""));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "BindCategories", ex.Message);
        }
    }
}