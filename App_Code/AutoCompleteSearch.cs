using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class AutoCompleteSearch
{

    #region AutoCompleteSearch
    public string value { get; set; }
    public string label { get; set; }
    public string surl { get; set; }
    public string imgurl { get; set; }
    #endregion

    #region AutoCompleteSearch Methods
    public static List<AutoCompleteSearch> GetSearchedProduct(SqlConnection conAP, string para)
    {
        List<AutoCompleteSearch> slp = new List<AutoCompleteSearch>();
        try
        {
            SqlCommand cmd = new SqlCommand("Select top 12 pds.* from ProductDetails pds where (pds.ProductName like '%'+@para+'%' or pds.Category like '%'+@para+'%' or pds.Brand like '%'+@para+'%' or pds.SubCategory like '%'+@para+'%' or pds.ProductTags like '%'+@para+'%') and pds.Status= 'Active'", conAP);
            cmd.Parameters.AddWithValue("@para", SqlDbType.NVarChar).Value = para;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow row in ds.Rows)
                {
                    AutoCompleteSearch fp1 = new AutoCompleteSearch();
                    fp1.value = Convert.ToString(row["Id"]);
                    fp1.imgurl = Convert.ToString(row["ProductImage"]);
                    fp1.label = Convert.ToString(row["ProductName"]);
                    fp1.surl = Convert.ToString(row["ProductUrl"]);
                    slp.Add(fp1);
                }
            }
        }
        catch (Exception es)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetSearchedProduct", es.Message);
        }
        return slp;
    }
    #endregion
}