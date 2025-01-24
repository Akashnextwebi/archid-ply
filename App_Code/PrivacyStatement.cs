using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class PrivacyStatement 
{
    public int Id { set; get; }
    public string Title { set; get; }

    public DateTime AddedOn { set; get; }
    public string AddedIp { set; get; }
    public string AddedBy { set; get; }
    public string Status { set; get; }
    #region Admin PrivacyStatement region
    public static List<PrivacyStatement> GetAllPrivacyStatement(SqlConnection conAP)
    {
        List<PrivacyStatement> categories = new List<PrivacyStatement>();
        try
        {
            string query = "Select *,(Select Top 1 UserName From CreateUser Where UserGuid=pd.AddedBy) AddedBy1 from PrivacyStatement pd where pd.Status='Active'";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new PrivacyStatement()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Title = Convert.ToString(dr["PrivacyContent"]),
                                  AddedBy = Convert.ToString(dr["AddedBy1"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllPrivacyStatement", ex.Message);
        }
        return categories;
    }
    public static int InsertPrivacyStatement(SqlConnection conAP, PrivacyStatement cat)
    {
        int result = 0;
        try
        {
            string query = "Insert Into PrivacyStatement (PrivacyContent,AddedOn,AddedIp,Status,AddedBy) values (@PrivacyContent,@AddedOn,@AddedIp,@Status,@AddedBy)";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@PrivacyContent", SqlDbType.NVarChar).Value = cat.Title;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value =CommonModel.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value ="Active";
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertPrivacyStatement", ex.Message);
        }
        return result;
    }
    public static int UpdatePrivacyStatement(SqlConnection conAP, PrivacyStatement cat)
    {
        int result = 0;
        try
        {
            string query = "Update PrivacyStatement Set PrivacyContent=@PrivacyContent,AddedOn=@UpdatedOn,AddedIp=@UpdatedIp,AddedBy=@UpdatedBy";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@PrivacyContent", SqlDbType.NVarChar).Value = cat.Title;
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = CommonModel.UTCTime();
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePrivacyStatement", ex.Message);
        }
        return result;
    }
    #endregion
}