using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TagMaster 
{
    public int Id { set; get; }
    public string Title { set; get; }
    public string Url { set; get; }
    public string ImageUrl { set; get; }
    public string Tag { get; set; }
    public string ShortDesc { set; get; }
    public string DisplayOrder { set; get; }
    public string DisplayHome { set; get; }
    public string PageTitle { set; get; }
    public string MetaDesc { set; get; }
    public string MetaKey { set; get; }
    public DateTime AddedOn { set; get; }
    public string AddedIp { set; get; }
    public string AddedBy { set; get; }
    public DateTime UpdatedOn { set; get; }
    public string UpdatedIp { set; get; }
    public string UpdatedBy { set; get; }
    public string Status { set; get; }
    #region Admin TagMaster region
    public static DataTable GetAllTagsMenu(SqlConnection conAP)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select top 2 *,(select UserName from CreateUser where UserGuid=TagMaster.AddedBy) adby,(select UserName from CreateUser where UserGuid=TagMaster.UpdatedBy) upby from TagMaster where Status='Active' and DisplayHome='Yes' order by try_convert(decimal,DisplayOrder)";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTagsMenu", ex.Message);
        }
        return dt;
    }



    public static List<ProductDetails> GetProductById(SqlConnection conAP, string id)
    {
        List<ProductDetails> pdsL = new List<ProductDetails>();
        try
        {
            var uid = HttpContext.Current.Request.Cookies["arch_i"] != null ? HttpContext.Current.Request.Cookies["arch_i"].Value : HttpContext.Current.Request.Cookies["arch_v"] != null ? HttpContext.Current.Request.Cookies["arch_v"].Value : "";
            if (uid != "")
            {
                string query = "Select *,(select Count(pid) cnt from Wishlist where UserGuid=@uid and Pid=ProductDetails.Id) WishCount from ProductDetails where Status='Active' and (Id=@id or ProductUrl=@id)";
                using (SqlCommand cmd = new SqlCommand(query, conAP))
                {
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = uid;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ProductDetails pds = new ProductDetails();
                        //pds = new ProductDetails();
                        pds.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                        pds.Category = Convert.ToString(dt.Rows[0]["Category"]);
                        pds.SubCategory = Convert.ToString(dt.Rows[0]["SubCategory"]);
                        pds.ProductGuid = Convert.ToString(dt.Rows[0]["ProductGuid"]);
                        pds.SKUCode = Convert.ToString(dt.Rows[0]["SKUCode"]);
                        pds.ProductName = Convert.ToString(dt.Rows[0]["ProductName"]);
                        pds.ProductUrl = Convert.ToString(dt.Rows[0]["ProductUrl"]);
                        pds.ProductImage = Convert.ToString(dt.Rows[0]["ProductImage"]);
                        pds.TaxGroup = Convert.ToString(dt.Rows[0]["TaxGroup"]);
                        pds.ShortDesc = Convert.ToString(dt.Rows[0]["ProductDesc"]);
                        pds.FullDesc = Convert.ToString(dt.Rows[0]["ProductFullDesc"]);
                        pds.PageTitle = Convert.ToString(dt.Rows[0]["PageTitle"]);
                        pds.MetaKey = Convert.ToString(dt.Rows[0]["MetaKey"]);
                        pds.MetaDesc = Convert.ToString(dt.Rows[0]["MetaDesc"]);
                        pds.InStock = Convert.ToString(dt.Rows[0]["InStock"]);
                        pds.productprs = ProductPrices.GetProductPriceByPId(conAP, Convert.ToString(dt.Rows[0]["Id"])).OrderBy(s => Convert.ToDouble(s.DiscountPrice)).ToList();
                        pds.productgly = ProductGallery.GetProductGallery(conAP, Convert.ToString(dt.Rows[0]["Id"]));
                        pds.productrvs = ProductReviews.GetProductReviews(conAP, Convert.ToString(dt.Rows[0]["Id"]));
                        pds.productfaqs = ProductFAQs.GetAllFAQS(conAP, Convert.ToString(dt.Rows[0]["Id"]));
                        pds.WishCount = Convert.ToInt32(dt.Rows[0]["WishCount"]);
                        pds.RelatedProducts = Convert.ToString(dt.Rows[0]["RelatedProducts"]);
                        pdsL.Add(pds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProductByGuid", ex.Message);
        }
        return pdsL;
    }

    public static List<TagMaster> GetAllTags(SqlConnection conAP)
    {
        List<TagMaster> categories = new List<TagMaster>();
        try
        {
            string query = "Select *,(select UserName from CreateUser where UserGuid=TagMaster.AddedBy) adby,(select UserName from CreateUser where UserGuid=TagMaster.UpdatedBy) upby from TagMaster where Status='Active'";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TagMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Tag = Convert.ToString(dr["TagName"]),
                                  Url = Convert.ToString(dr["TagUrl"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"]),
                                  ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedBy = Convert.ToString(dr["adby"]),
                                  UpdatedBy = Convert.ToString(dr["upby"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  UpdatedOn = Convert.ToDateTime(Convert.ToString(dr["UpdatedOn"])),
                                  UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  DisplayOrder = Convert.ToString(dr["DisplayOrder"]),
                                  MetaKey = Convert.ToString(dr["MetaKeys"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();

            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTags", ex.Message);
        }
        return categories;
    }

    public static List<TagMaster> GetTagMaster(SqlConnection conAP, string id)
    {
        List<TagMaster> categories = new List<TagMaster>();
        try
        {
            int ids = 0;
            int.TryParse(id, out ids);
            string query = "Select * from TagMaster Where Status='Active' and (Id=@Id or TagUrl=@TagUrl)";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                DataTable dt = new DataTable();
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = ids;
                cmd.Parameters.AddWithValue("@TagUrl", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TagMaster cat = new TagMaster();
                    cat.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    cat.Tag = Convert.ToString(dt.Rows[0]["TagName"]);
                    cat.Url = Convert.ToString(dt.Rows[0]["TagUrl"]);
                    cat.DisplayHome = Convert.ToString(dt.Rows[0]["DisplayHome"]);
                    cat.ImageUrl = Convert.ToString(dt.Rows[0]["ImageUrl"]);
                    cat.ShortDesc = Convert.ToString(dt.Rows[0]["ShortDesc"]);
                    cat.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    cat.UpdatedIp = Convert.ToString(dt.Rows[0]["UpdatedIp"]);
                    cat.DisplayOrder = Convert.ToString(dt.Rows[0]["DisplayOrder"]);
                    cat.MetaDesc = Convert.ToString(dt.Rows[0]["MetaDesc"]);
                    cat.MetaKey = Convert.ToString(dt.Rows[0]["MetaKeys"]);
                    cat.PageTitle = Convert.ToString(dt.Rows[0]["PageTitle"]);
                    cat.AddedOn = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["AddedOn"]));
                    cat.UpdatedOn = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["UpdatedOn"]));
                    cat.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    categories.Add(cat);
                }
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTagMaster", ex.Message);
        }
        return categories;
    }

    public static int InsertTagMaster(SqlConnection conAP, TagMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Insert Into TagMaster (DisplayOrder,TagName,TagUrl,MetaKeys,MetaDesc,PageTitle,AddedOn,AddedIp,Status,UpdatedOn,UpdatedIp,DisplayHome,AddedBy,UpdatedBy,ShortDesc) values(@DisplayOrder,@TagName,@TagUrl,@MetaKeys,@MetaDesc,@PageTitle,@AddedOn,@AddedIp,@Status,@UpdatedOn,@UpdatedIp,@DisplayHome,@AddedBy,@UpdatedBy,@ShortDesc) SELECT SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@DisplayOrder", SqlDbType.NVarChar).Value = cat.DisplayOrder;
                cmd.Parameters.AddWithValue("@TagName", SqlDbType.NVarChar).Value = cat.Tag;
                cmd.Parameters.AddWithValue("@TagUrl", SqlDbType.NVarChar).Value = cat.Url;
                cmd.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKey;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.UpdatedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.UpdatedIp;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = cat.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = cat.UpdatedIp;
                cmd.Parameters.AddWithValue("@DisplayHome", SqlDbType.NVarChar).Value = cat.DisplayHome;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                conAP.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertTagMaster", ex.Message);
        }
        return result;
    }

    public static int AddTagImage(SqlConnection conAP, TagMaster cts)
    {
        int result = 0;
        try
        {
            string query = "Update TagMaster Set ImageUrl=@ImageUrl Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cts.Id;
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = cts.ImageUrl;
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTagImage", ex.Message);
        }
        return result;
    }

    public static int UpdateTagMaster(SqlConnection conAP, TagMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Update TagMaster Set DisplayOrder=@DisplayOrder, TagName=@TagName,TagUrl=@TagUrl,MetaKeys=@MetaKeys,MetaDesc=@MetaDesc,PageTitle=@PageTitle,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp,DisplayHome=@DisplayHome,ImageUrl=@ImageUrl,UpdatedBy=@UpdatedBy,ShortDesc=@ShortDesc Where Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@DisplayOrder", SqlDbType.NVarChar).Value = cat.DisplayOrder;
                cmd.Parameters.AddWithValue("@TagName", SqlDbType.NVarChar).Value = cat.Tag;
                cmd.Parameters.AddWithValue("@TagUrl", SqlDbType.NVarChar).Value = cat.Url;
                cmd.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKey;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = CommonModel.UTCTime();
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                cmd.Parameters.AddWithValue("@DisplayHome", SqlDbType.NVarChar).Value = cat.DisplayHome;
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = cat.ImageUrl;
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateTagMaster", ex.Message);
        }
        return result;
    }

    public static int DeleteTagMaster(SqlConnection conAP, TagMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Update TagMaster Set Status=@Status,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp,UpdatedBy=@UpdatedBy Where Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = CommonModel.UTCTime();
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTagMaster", ex.Message);
        }
        return result;
    }
    #endregion
}