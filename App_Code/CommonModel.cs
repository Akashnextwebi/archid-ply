﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class CommonModel
{
    public static string IPAddress()
    {
        string ipadd = "";
        try
        {
            String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {

                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                string ipStr = ip.Replace("::ffff:", "");
                ip = ipStr;
            }
            ipadd = ip;
        }
        catch (Exception ex)
        {

        }
        return ipadd;
    }
    public static string GetCountryFromIP()
    {
        string Country = "";
        try
        {
            string ipaddr = IPAddress();
            HttpWebRequest objreq = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ipaddr);
            HttpWebResponse objres = (HttpWebResponse)objreq.GetResponse();
            StreamReader resreader = new StreamReader(objres.GetResponseStream());
            string responseread = resreader.ReadToEnd();
            resreader.Close();
            resreader.Dispose();
            dynamic dynObj = JsonConvert.DeserializeObject(responseread);
            if (dynObj.country != null) 
            {
                Country = dynObj.country; 
            }
        }
        catch (Exception ex)
        {
        }
        return Country;
    }
    public static void SaveJpeg(string path, System.Drawing.Image img, int quality)
    {
        if (quality < 0 || quality > 100)
            throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

        // Encoder parameter for image quality 
        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        // JPEG image codec 
        ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        //img.Width = 800;
        img.Save(path, jpegCodec, encoderParams);
    }

    public static void SavePNG(string path, System.Drawing.Image img, int quality)
    {
        if (quality < 0 || quality > 100)
            throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

        // Encoder parameter for image quality 
        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        // JPEG image codec 
        ImageCodecInfo jpegCodec = GetEncoderInfo("image/png");
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        //img.Width = 800;
        img.Save(path, jpegCodec, encoderParams);
    }
    public static System.Drawing.Image ScaleImageBig(System.Drawing.Image image, int height, int width)
    {
        var newImage = new Bitmap(width, height);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, width, height);
        }
        return newImage;
    }
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats 
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        // Find the correct image codec 
        for (int i = 0; i < codecs.Length; i++)
            if (codecs[i].MimeType == mimeType)
                return codecs[i];

        return null;
    }
    public static string Encrypt(string clearText)
    {
        string EncryptionKey = "ARCHIDPLYDEV220919981510$%^&*ENCODE";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    public static string Decrypt(string cipherText)
    {
        string EncryptionKey = "ARCHIDPLYDEV220919981510$%^&*ENCODE";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    public static void ReassignCurrencyCookie(string val)
    {
        if (HttpContext.Current.Request.Cookies["ary_ctry"] == null)
        {
            HttpCookie cookie = new HttpCookie("ary_ctry");
            cookie.Value = val;
            cookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        else
        {
            var cookie = HttpContext.Current.Response.Cookies["ary_ctry"];
            cookie.Value = val;
            cookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
    public static void AddRecentProductCookie(string cid, string pdid)
    {
        try
        {
            if (HttpContext.Current.Request.Cookies["ary_rv"] == null)
            {
                HttpCookie rv = new HttpCookie("ary_rv");
                rv.Value = CommonModel.Encrypt(pdid);
                rv.Expires = TimeStamps.UTCTime().AddDays(10);
                HttpContext.Current.Response.Cookies.Add(rv);
            }
            else
            {
                string actval = CommonModel.Decrypt(HttpContext.Current.Request.Cookies["ary_rv"].Value);
                List<string> val = actval.Split(',').ToList();
                string exist = val.Where(s => s == pdid).SingleOrDefault();
                if (val.Count > 9)
                {
                    HttpCookie rv = new HttpCookie("ary_rv");
                    if (exist == null)
                    {
                        val.RemoveAt(val.Count - 1);
                        val.Reverse();
                        val.Add(pdid);
                        val.Reverse();
                    }
                    string retval = "";
                    foreach (var lp in val)
                    {
                        retval += lp + ",";
                    }
                    rv.Value = CommonModel.Encrypt(retval.Substring(0, retval.Length - 1));
                    rv.Expires = TimeStamps.UTCTime().AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(rv);
                }
                else
                {
                    HttpCookie rv = new HttpCookie("ary_rv");
                    if (exist == null)
                    {
                        actval = pdid + "," + actval;
                    }
                    rv.Value = CommonModel.Encrypt(actval);
                    rv.Expires = TimeStamps.UTCTime().AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(rv);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddRecentProduct", ex.Message);
        }
    }
    public static string urlval(string url)
    {
        string[] strArr = url.Split('-');
        string resulturl = string.Empty;
        for (int i = 0; i < strArr.Length; i++)
        {
            if (resulturl == "")
            {
                resulturl = strArr[i];
            }
            else
            {
                resulturl = resulturl + " " + strArr[i];
            }
        }
        return resulturl;
    }
    public static string seourl(string url)
    {
        string[] strArr = url.Split(' ');
        string resulturl = string.Empty;
        for (int i = 0; i < strArr.Length; i++)
        {
            if (resulturl == "")
            {
                resulturl = strArr[i];
            }
            else
            {
                resulturl = resulturl + "-" + strArr[i];
            }
        }
        return resulturl;
    }

    public static void CaptureException(string pg, string block, string excep)
    {
        try
        {
            if (excep.Trim() == "Thread was being aborted.")
            {
                return;
            }
            SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into CaptureException (Ex_Page, Ex_Block, Excep, Added_On, Added_IP) values(@Ex_Page, @Ex_Block, @Excep, @Added_On, @Added_IP)", conAP);
            cmd.Parameters.AddWithValue("@Ex_Page", SqlDbType.NVarChar).Value = pg;
            cmd.Parameters.AddWithValue("@Ex_Block", SqlDbType.NVarChar).Value = block;
            cmd.Parameters.AddWithValue("@Excep", SqlDbType.NVarChar).Value = excep;
            cmd.Parameters.AddWithValue("@Added_On", SqlDbType.DateTime).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@Added_IP", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
            conAP.Open();
            int res = cmd.ExecuteNonQuery();
            conAP.Close();
        }
        catch (Exception ex)
        {

        }
    }

    public static TimeZoneInfo TomeZoneInfoDetails(string olsonTimeZoneId)
    {
        var olsonWindowsTimes = new Dictionary<string, string>()
    {
        { "Africa/Bangui", "W. Central Africa Standard Time" },
        { "Africa/Cairo", "Egypt Standard Time" },
        { "Africa/Casablanca", "Morocco Standard Time" },
        { "Africa/Harare", "South Africa Standard Time" },
        { "Africa/Johannesburg", "South Africa Standard Time" },
        { "Africa/Lagos", "W. Central Africa Standard Time" },
        { "Africa/Monrovia", "Greenwich Standard Time" },
        { "Africa/Nairobi", "E. Africa Standard Time" },
        { "Africa/Windhoek", "Namibia Standard Time" },
        { "America/Anchorage", "Alaskan Standard Time" },
        { "America/Argentina/San_Juan", "Argentina Standard Time" },
        { "America/Asuncion", "Paraguay Standard Time" },
        { "America/Bahia", "Bahia Standard Time" },
        { "America/Bogota", "SA Pacific Standard Time" },
        { "America/Buenos_Aires", "Argentina Standard Time" },
        { "America/Caracas", "Venezuela Standard Time" },
        { "America/Cayenne", "SA Eastern Standard Time" },
        { "America/Chicago", "Central Standard Time" },
        { "America/Chihuahua", "Mountain Standard Time (Mexico)" },
        { "America/Cuiaba", "Central Brazilian Standard Time" },
        { "America/Denver", "Mountain Standard Time" },
        { "America/Fortaleza", "SA Eastern Standard Time" },
        { "America/Godthab", "Greenland Standard Time" },
        { "America/Guatemala", "Central America Standard Time" },
        { "America/Halifax", "Atlantic Standard Time" },
        { "America/Indianapolis", "US Eastern Standard Time" },
        { "America/Indiana/Indianapolis", "US Eastern Standard Time" },
        { "America/La_Paz", "SA Western Standard Time" },
        { "America/Los_Angeles", "Pacific Standard Time" },
        { "America/Mexico_City", "Mexico Standard Time" },
        { "America/Montevideo", "Montevideo Standard Time" },
        { "America/New_York", "Eastern Standard Time" },
        { "America/Noronha", "UTC-02" },
        { "America/Phoenix", "US Mountain Standard Time" },
        { "America/Regina", "Canada Central Standard Time" },
        { "America/Santa_Isabel", "Pacific Standard Time (Mexico)" },
        { "America/Santiago", "Pacific SA Standard Time" },
        { "America/Sao_Paulo", "E. South America Standard Time" },
        { "America/St_Johns", "Newfoundland Standard Time" },
        { "America/Tijuana", "Pacific Standard Time" },
        { "Antarctica/McMurdo", "New Zealand Standard Time" },
        { "Atlantic/South_Georgia", "UTC-02" },
        { "Asia/Almaty", "Central Asia Standard Time" },
        { "Asia/Amman", "Jordan Standard Time" },
        { "Asia/Baghdad", "Arabic Standard Time" },
        { "Asia/Baku", "Azerbaijan Standard Time" },
        { "Asia/Bangkok", "SE Asia Standard Time" },
        { "Asia/Beirut", "Middle East Standard Time" },
        { "Asia/Calcutta", "India Standard Time" },
        { "Asia/Colombo", "Sri Lanka Standard Time" },
        { "Asia/Damascus", "Syria Standard Time" },
        { "Asia/Dhaka", "Bangladesh Standard Time" },
        { "Asia/Dubai", "Arabian Standard Time" },
        { "Asia/Irkutsk", "North Asia East Standard Time" },
        { "Asia/Jerusalem", "Israel Standard Time" },
        { "Asia/Kabul", "Afghanistan Standard Time" },
        { "Asia/Kamchatka", "Kamchatka Standard Time" },
        { "Asia/Karachi", "Pakistan Standard Time" },
        { "Asia/Katmandu", "Nepal Standard Time" },
        { "Asia/Kolkata", "India Standard Time" },
        { "Asia/Krasnoyarsk", "North Asia Standard Time" },
        { "Asia/Kuala_Lumpur", "Singapore Standard Time" },
        { "Asia/Kuwait", "Arab Standard Time" },
        { "Asia/Magadan", "Magadan Standard Time" },
        { "Asia/Muscat", "Arabian Standard Time" },
        { "Asia/Novosibirsk", "N. Central Asia Standard Time" },
        { "Asia/Oral", "West Asia Standard Time" },
        { "Asia/Rangoon", "Myanmar Standard Time" },
        { "Asia/Riyadh", "Arab Standard Time" },
        { "Asia/Seoul", "Korea Standard Time" },
        { "Asia/Shanghai", "China Standard Time" },
        { "Asia/Singapore", "Singapore Standard Time" },
        { "Asia/Taipei", "Taipei Standard Time" },
        { "Asia/Tashkent", "West Asia Standard Time" },
        { "Asia/Tbilisi", "Georgian Standard Time" },
        { "Asia/Tehran", "Iran Standard Time" },
        { "Asia/Tokyo", "Tokyo Standard Time" },
        { "Asia/Ulaanbaatar", "Ulaanbaatar Standard Time" },
        { "Asia/Vladivostok", "Vladivostok Standard Time" },
        { "Asia/Yakutsk", "Yakutsk Standard Time" },
        { "Asia/Yekaterinburg", "Ekaterinburg Standard Time" },
        { "Asia/Yerevan", "Armenian Standard Time" },
        { "Atlantic/Azores", "Azores Standard Time" },
        { "Atlantic/Cape_Verde", "Cape Verde Standard Time" },
        { "Atlantic/Reykjavik", "Greenwich Standard Time" },
        { "Australia/Adelaide", "Cen. Australia Standard Time" },
        { "Australia/Brisbane", "E. Australia Standard Time" },
        { "Australia/Darwin", "AUS Central Standard Time" },
        { "Australia/Hobart", "Tasmania Standard Time" },
        { "Australia/Perth", "W. Australia Standard Time" },
        { "Australia/Sydney", "AUS Eastern Standard Time" },
        { "Etc/GMT", "UTC" },
        { "Etc/GMT+11", "UTC-11" },
        { "Etc/GMT+12", "Dateline Standard Time" },
        { "Etc/GMT+2", "UTC-02" },
        { "Etc/GMT-12", "UTC+12" },
        { "Europe/Amsterdam", "W. Europe Standard Time" },
        { "Europe/Athens", "GTB Standard Time" },
        { "Europe/Belgrade", "Central Europe Standard Time" },
        { "Europe/Berlin", "W. Europe Standard Time" },
        { "Europe/Brussels", "Romance Standard Time" },
        { "Europe/Budapest", "Central Europe Standard Time" },
        { "Europe/Dublin", "GMT Standard Time" },
        { "Europe/Helsinki", "FLE Standard Time" },
        { "Europe/Istanbul", "GTB Standard Time" },
        { "Europe/Kiev", "FLE Standard Time" },
        { "Europe/London", "GMT Standard Time" },
        { "Europe/Minsk", "E. Europe Standard Time" },
        { "Europe/Moscow", "Russian Standard Time" },
        { "Europe/Paris", "Romance Standard Time" },
        { "Europe/Sarajevo", "Central European Standard Time" },
        { "Europe/Warsaw", "Central European Standard Time" },
        { "Indian/Mauritius", "Mauritius Standard Time" },
        { "Pacific/Apia", "Samoa Standard Time" },
        { "Pacific/Auckland", "New Zealand Standard Time" },
        { "Pacific/Fiji", "Fiji Standard Time" },
        { "Pacific/Guadalcanal", "Central Pacific Standard Time" },
        { "Pacific/Guam", "West Pacific Standard Time" },
        { "Pacific/Honolulu", "Hawaiian Standard Time" },
        { "Pacific/Pago_Pago", "UTC-11" },
        { "Pacific/Port_Moresby", "West Pacific Standard Time" },
        { "Pacific/Tongatapu", "Tonga Standard Time" }
    };

        var windowsTimeZoneId = default(string);
        var windowsTimeZone = default(TimeZoneInfo);
        if (olsonWindowsTimes.TryGetValue(olsonTimeZoneId, out windowsTimeZoneId))
        {
            try { windowsTimeZone = TimeZoneInfo.FindSystemTimeZoneById(windowsTimeZoneId); }
            catch (TimeZoneNotFoundException) { }
            catch (InvalidTimeZoneException) { }
        }
        return windowsTimeZone;
    }

    private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

    public static long getUnixTimeMillis(System.DateTime d)
    {
        return (long)(d - Jan1st1970).TotalMilliseconds;
    }

    public static int CurrentUnixTimeMinutes(System.DateTime d)
    {
        return (int)(d - Jan1st1970).TotalMinutes;
    }

    public static System.DateTime getDateFromMSec(long msec)
    {
        return Jan1st1970.AddMilliseconds(msec);
    }

    public static System.DateTime getDateFromSec(long sec)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return origin.AddSeconds(sec);
    }

    /// <summary>
    /// Return Time in users local time
    /// </summary>
    /// <returns></returns>
    public static DateTime UserLocalTime()
    {
        DateTime localTime;
        DateTime utcTime = DateTime.UtcNow;
        string timezone = TimeZone.CurrentTimeZone.StandardName;
        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timezone);
        localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        return localTime;
    }


    /// <summary>
    /// Return Time in German Time zone 
    /// </summary>
    /// <returns></returns>
    public static DateTime UTCTime()
    {
        DateTime localTime;
        DateTime utcTime = DateTime.UtcNow;

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        return localTime;

        //DateTime utcTime = DateTime.UtcNow;
        //return utcTime;
    }
}
