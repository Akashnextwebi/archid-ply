using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Razorpay.Api;
using RestSharp;
using RestClient = RestSharp.RestClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;


/// <summary>
/// Summary description for ShipRocket
/// </summary>
public class ShipRocket 
{
    public ShipRocket()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string CreateToken()
    {
        string token = "";
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var clientToken = new RestClient("https://apiv2.shiprocket.in/v1/external/auth/login");
            clientToken.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""email"": """ + ConfigurationManager.AppSettings["ShipRocketEmail"] + @""",
" + "\n" +
            @"    ""password"": """ + ConfigurationManager.AppSettings["ShipRocketPwd"] + @"""
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = clientToken.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ShipRocketToken myDeserializedClass = JsonConvert.DeserializeObject<ShipRocketToken>(response.Content);
                if (myDeserializedClass != null)
                {
                    token = myDeserializedClass.token;
                }

            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatShipRocketOrder", ex.Message);
        }
        return token;
    }

    
    public static int  CreatShipRocketOrder(SqlConnection conAP, string OrderGuidForSR)
    {
        int result = 0;
        string token = CreateToken();
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string OrderId = "", OrderDate = "", TotalPrice = "", TotalDiscount = "", BAFirstName = "", 
                BALastName = "", BAaddress1 = "", BAaddress2 = "", BAcity = "", BAPincode = "", 
                BAState = "", BAcountry = "", BAemail = "", BAphone = "", DAFirstName = "", 
                DALastName = "", DAaddress1 = "", DAaddress2 = "", DAcity = "", DAPincode = "", 
                DAState = "", DAcountry = "", DAemail = "", DAphone = "", allOrderdItems = "",
                paymentmode="",advancePayment="",balPayment="", PaymentType="";


            if (OrderGuidForSR != ""  &&token!="")

            {

                UserBillingAddress UserBillingAddress = UserCheckout.GetFullUserBillingAddressByOrderGuid(conAP, OrderGuidForSR).FirstOrDefault();
                UserDeliveryAddress UserDeliveryAddress = UserCheckout.GetFullUserDeliveryAddressByOrderGuid(conAP, OrderGuidForSR).FirstOrDefault();
                List<CheckoutItems> OrderItem = UserCheckout.GetOrderdProductDetailByOrderGuid(conAP, OrderGuidForSR);
                Orders ord = UserCheckout.GetOrderDetailsByOrderGuid(conAP, OrderGuidForSR).FirstOrDefault();
                if (UserBillingAddress != null && UserDeliveryAddress != null && OrderItem != null && ord != null)
                {
                    int i = 1;
                    BAFirstName = UserBillingAddress.FirstName;
                    BALastName = UserBillingAddress.LastName;
                    BAaddress1 = UserBillingAddress.Address1;
                    BAaddress2 = UserBillingAddress.Address2;
                    BAcity = UserBillingAddress.City;
                    BAPincode = UserBillingAddress.Zip;
                    BAState = UserBillingAddress.State;
                    BAcountry = UserBillingAddress.Country;
                    BAemail = UserBillingAddress.EmailId;
                    BAphone = UserBillingAddress.Mobile;
                    DAFirstName = UserDeliveryAddress.FirstName;
                    DALastName = UserDeliveryAddress.LastName;
                    DAaddress1 = UserDeliveryAddress.Address1;
                    DAaddress2 = UserDeliveryAddress.Address2;
                    DAcity = UserDeliveryAddress.City;
                    DAPincode = UserDeliveryAddress.Zip;
                    DAState = UserDeliveryAddress.State;
                    DAcountry = UserDeliveryAddress.Country;
                    DAemail = UserDeliveryAddress.Email;
                    DAphone = UserDeliveryAddress.Mobile;
                    OrderId = ord.OrderId;
                    OrderDate = ord.OrderOn.ToString("yyyy-MM-dd");
                    TotalPrice = ord.TotalPrice;
                    TotalDiscount = ord.Discount;
                    paymentmode = ord.PaymentMode;
                    advancePayment = ord.AdvAmount;
                    balPayment= ord.BalAmount;

                    if (paymentmode.ToLower() == "cod20")
                    {
                        TotalPrice = ord.BalAmount;
                        PaymentType = "COD";

                    }
                    else
                    {
                        PaymentType = "Prepaid";

                    }

                    foreach (CheckoutItems Pro in OrderItem)
                    {
                        if (OrderItem.Count == 1)
                        {
                            allOrderdItems = @"    {
" + "\n" +
        @"      ""name"": """ + Pro.ProductName + @""",
" + "\n" +
        @"      ""sku"": """ + Pro.ProductId + @""",
" + "\n" +
        @"      ""units"": " + Convert.ToInt32(Pro.Qty) + @",
" + "\n" +
        @"      ""selling_price"": """ + Convert.ToInt32(Pro.Price) + @""",
" + "\n" +
        @"      ""discount"": """",
" + "\n" +
        @"      ""tax"": """",
" + "\n" +
        @"      ""hsn"": """"
" + "\n" +
        @"    }";
                        }
                        else if (OrderItem.Count != 1 && i == 1)
                        {
                            allOrderdItems = @"    {
" + "\n" +
        @"      ""name"": """ + Pro.ProductName + @""",
" + "\n" +
        @"      ""sku"": """ + Pro.ProductId + @""",
" + "\n" +
        @"      ""units"": " + Convert.ToInt32(Pro.Qty) + @",
" + "\n" +
        @"      ""selling_price"": """ + Convert.ToInt32(Pro.Price) + @""",
" + "\n" +
        @"      ""discount"": """",
" + "\n" +
        @"      ""tax"": """",
" + "\n" +
        @"      ""hsn"": """"
" + "\n" +
        @"    },
" + "\n";
                        }
                        else if (OrderItem.Count == i)
                        {
                            allOrderdItems += @"    {
" + "\n" +
        @"      ""name"": """ + Pro.ProductName + @""",
" + "\n" +
        @"      ""sku"": """ + Pro.ProductId + @""",
" + "\n" +
        @"      ""units"": " + Convert.ToInt32(Pro.Qty) + @",
" + "\n" +
        @"      ""selling_price"": """ + Convert.ToInt32(Pro.Price) + @""",
" + "\n" +
        @"      ""discount"": """",
" + "\n" +
        @"      ""tax"": """",
" + "\n" +
        @"      ""hsn"": 441122
" + "\n" +
        @"    }";
                        }
                        else
                        {
                            allOrderdItems += @"    {
" + "\n" +
        @"      ""name"": """ + Pro.ProductName + @""",
" + "\n" +
        @"      ""sku"": """ + Pro.ProductId + @""",
" + "\n" +
        @"      ""units"": " + Convert.ToInt32(Pro.Qty) + @",
" + "\n" +
        @"      ""selling_price"": """ + Convert.ToInt32(Pro.Price) + @""",
" + "\n" +
        @"      ""discount"": """",
" + "\n" +
        @"      ""tax"": """",
" + "\n" +
        @"      ""hsn"": 441122
" + "\n" +
        @"    },
" + "\n";
                        }

                        i++;


                    }
                }


          
                var client = new RestClient("https://apiv2.shiprocket.in/v1/external/orders/create/adhoc");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + token + "");

                var body = @"{
" + "\n" +
                @"  ""order_id"": """ + OrderId + @""",
" + "\n" +
                @"  ""order_date"": """ + OrderDate + @""",
" + "\n" +
                @"  ""pickup_location"": ""other"",
" + "\n" +
                @"  ""channel_id"": """",
" + "\n" +
                @"  ""comment"": """",
" + "\n" +
                @"  ""billing_customer_name"": """ + BAFirstName + @""",
" + "\n" +
                @"  ""billing_last_name"": """ + BALastName + @""",
" + "\n" +
                @"  ""billing_address"": """ + BAaddress1.Replace('\n',' ') + @""",
" + "\n" +
                @"  ""billing_address_2"": """ + BAaddress2.Replace('\n', ' ') + @""",
" + "\n" +
                @"  ""billing_city"": """ + BAcity + @""",
" + "\n" +
                @"  ""billing_pincode"": """ + BAPincode + @""",
" + "\n" +
                @"  ""billing_state"": """ + BAState + @""",
" + "\n" +
                @"  ""billing_country"": """ + BAcountry + @""",
" + "\n" +
                @"  ""billing_email"": """ + BAemail + @""",
" + "\n" +
                @"  ""billing_phone"": """ + BAphone + @""",
" + "\n" +
                @"  ""shipping_is_billing"": false,
" + "\n" +
                @"  ""shipping_customer_name"": """ + DAFirstName + @""",
" + "\n" +
                @"  ""shipping_last_name"": """ + DALastName + @""",
" + "\n" +
                @"  ""shipping_address"": """ + DAaddress1.Replace('\n', ' ') + @""",
" + "\n" +
                @"  ""shipping_address_2"": """ + DAaddress2.Replace('\n', ' ') + @""",
" + "\n" +
                @"  ""shipping_city"": """ + DAcity + @""",
" + "\n" +
                @"  ""shipping_pincode"": """ + DAPincode + @""",
" + "\n" +
                @"  ""shipping_country"": """ + DAcountry + @""",
" + "\n" +
                @"  ""shipping_state"": """ + DAState + @""",
" + "\n" +
                @"  ""shipping_email"": """ + DAemail + @""",
" + "\n" +
                @"  ""shipping_phone"": """ + DAphone + @""",
" + "\n" +
        @"  ""order_items"": [
" + "\n" +
        @"" + allOrderdItems + @"
" + "\n" +
        @"  ],
" + "\n" +
                @"  ""payment_method"": """ + PaymentType + @""",
" + "\n" +
                @"  ""shipping_charges"": 0,
" + "\n" +
                @"  ""giftwrap_charges"": 0,
" + "\n" +
                @"  ""transaction_charges"": 0,
" + "\n" +
                @"  ""total_discount"": 0,
" + "\n" +
                @"  ""sub_total"": " + Convert.ToInt32(TotalPrice) + @",
" + "\n" +
                @"  ""length"": 10,
" + "\n" +
                @"  ""breadth"": 10,
" + "\n" +
                @"  ""height"": 10,
" + "\n" +
                @"  ""weight"": 1
" + "\n" +

                @"}";


                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ShipRocketCreateOrderResponse myDeserializedClass = JsonConvert.DeserializeObject<ShipRocketCreateOrderResponse>(response.Content);
                    if (myDeserializedClass != null)
                    {
                        string TrackingId = Convert.ToString(myDeserializedClass.awb_code);
                        result = UserCheckout.AddTrackingCodeToOrder(conAP, OrderGuidForSR, TrackingId);

                    }

                }



                //List<string> spiltJson = body.Split('\n').ToList();
                //foreach (string st in spiltJson)
                //{
                //    strToCheckJsonBody += st + "<br/>";
                //}
            }

        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatShipRocketOrder", ex.Message);
        }

        return result;

    }

}

