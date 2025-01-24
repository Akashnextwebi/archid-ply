using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Razorpay.Api;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shop_checkout : System.Web.UI.Page
{
    SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);
    public string strSubTotal = "", strTotal = "", strShipping = "", strCarts = "", strDiscount = "", strTax = "", strDeskLogin = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        BindCart();
        if (Request.Cookies["arch_i"] == null)
        {
            Loginlink.Visible = true;
        }
        GetUserDetailsByUid();
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (!customCheck5.Checked)
        {
          
            DeliveryDiv.Visible = true;
            txtDelAddress1.Text = txtAddress1.Text;
            txtDelAddress2.Text = txtAddress2.Text;
            txtDelCity.Text = txtCity.Text;
            txtDelState.Text = txtState.Text;
            txtDelZip.Text = txtZip.Text;
            txtDelEmailID.Text = txtEmail.Text;
            txtDelPhone.Text = txtPhone.Text;
        }
        else
        {
            DeliveryDiv.Visible = false;
            txtDelAddress1.Text = txtAddress1.Text;
            txtDelAddress2.Text = txtAddress2.Text;
            txtDelCity.Text = txtCity.Text;
            txtDelState.Text = txtState.Text;
            txtDelZip.Text = txtZip.Text;
            txtDelEmailID.Text = txtEmail.Text;
            txtDelPhone.Text = txtPhone.Text;
        }
        txtDelEmailID.Focus();
    }
    
    public void GetUserDetailsByUid()
    {
        try
        {
            List<UserAddress> Details = UserDetails.GetLoggedUserAddress(conAP, Convert.ToString(Request.Cookies["arch_i"].Value)).ToList();
            if (Details.Count > 0)
            {
                txtFName.Text = Details[0].FirstName;
                txtLName.Text = Details[0].LastName;
                txtEmail.Text = Details[0].Email;
                txtPhone.Text = Details[0].Phone;
                txtAddress1.Text = Details[0].AddressLine1;
                txtAddress2.Text = Details[0].AddressLine2 == "" ? Details[0].AddressLine1 : Details[0].AddressLine2;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllMemberDetails", ex.Message);
        }
    }
    public void BindCart()
    {
        try
        {
            List<CartDetails> carts = CartDetails.GetAllCartDetails(conAP);
            if (carts.Count > 0)
            {
                string listings = "";
                decimal price = 0, mincart = 0, shipAmount = 0, pqtys = 0, shpAmt = 0, Actprice = 0;

                for (var i = 0; i < carts.Count; i++)
                {
                    var qty = Convert.ToDecimal(carts[i].Qty);
                    price += (Convert.ToDecimal(carts[i].DiscountPrice) * qty);
                    pqtys += Convert.ToDecimal(carts[i].Qty);
                    Actprice += (Convert.ToDecimal(carts[i].ActualPrice) - (Convert.ToDecimal(carts[i].DiscountPrice)));
                    

                    string cutPrice = "";
                    if (carts[i].ActualPrice != "")
                    {
                        cutPrice = "<span class='old-price'>₹" + carts[i].ActualPrice + @"</span>";
                    }

                    listings += @" <div class='d-flex w-100 mb-7'>
                                    <div class='me-6'>
                                        <img src='/" + carts[i].ProductImage + @"'  class='lazy-image' width='70' alt='" + carts[i].ProductName + @"'>
                                    </div>
                                    <div class='d-flex flex-grow-1'>
                                        <div class='pe-6'>
                                            <a href='/shop-products/" + carts[i].ProductUrl + @"' class=''>" + carts[i].ProductName + @"<span class='text-body'><span> x </span> " + qty + @" </span></a>
                                        <p class='fs-14px text-body-emphasis mb-0 mt-1'>Size:<span class='text-body'>" + carts[i].ProductSize + "<span> x </span>  " + carts[i].ProductThickness + @"</span></p>
                                            <span class='small-green-text'>Your Savings ₹" + Actprice * qty + @"</span></div>
                                        <div class='ms-auto'>
                                            <p class='fs-14px text-body-emphasis mb-0 fw-bold'>₹" + (Convert.ToDecimal(carts[i].DiscountPrice) * qty) + @"</p>
                                        </div>
                                    </div>
                                </div>";
                }
                strCarts = listings;
                lblCoupon.Text = "";
                decimal dis = 0;
                if (txtCoupon.Text.Trim() != "")
                {
                    var coupon = CouponCode.GetAllCoupon(conAP).Where(s => s.CCode == txtCoupon.Text.Trim()).FirstOrDefault();
                    if (coupon != null)
                    {
                        lblCoupon.Visible = true;
                        if (coupon.ExpiryDate.Date >= TimeStamps.UTCTime().Date)
                        {
                            if (coupon.CType == "Value")
                            {
                                decimal.TryParse(coupon.CValue, out dis);
                                lblCoupon.Text = "Coupon added successfully";
                                lblCoupon.Attributes.Add("class", "alert alert-success m-5");

                                btnApply.Visible = false;
                                btnRemove.Visible = true;
                            }
                            else
                            {
                                decimal perV = 0;
                                decimal.TryParse(coupon.CValue, out perV);
                                dis = (price / (decimal)100) * perV;
                                lblCoupon.Text = "Coupon added successfully";
                                lblCoupon.Attributes.Add("class","alert alert-success m-5");
                                btnApply.Visible = false;
                                btnRemove.Visible = true;
                            }
                        }
                        else
                        {
                            lblCoupon.Text = "Invalid coupon code.";
                            lblCoupon.Attributes.Add("class", "alert alert-danger m-5");

                        }
                    }
                    else
                    {
                        lblCoupon.Text = "Invalid coupon code.";
                        lblCoupon.Attributes.Add("class", "alert alert-danger m-5");

                    }

                }
                mincart += Convert.ToDecimal(carts[0].MinCartPrice);
                shipAmount += Convert.ToDecimal(carts[0].ShippingCharge);
                decimal tax = 0;
                decimal sh = price > mincart ? 0 : shipAmount;
                strSubTotal = "₹" + Math.Round(price);
                strTax = "₹" + (Math.Round(price) * (Convert.ToDecimal(0) / Convert.ToDecimal(100)));
                strShipping = "₹" + sh;
                strDiscount = "₹" + Math.Round(dis);
                strTotal = "₹" + Math.Round((price + sh) - dis + (price * (Convert.ToDecimal(0) / Convert.ToDecimal(100))));
            }
            else
            {
                Response.Redirect("/checkout");
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCart", ex.Message);
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        try
        {
            lblCoupon.Visible = true;

            List<CartDetails> carts = CartDetails.GetAllCartDetails(conAP);
            if (carts.Count > 0)
            {
                string listings = "";
                decimal price = 0, mincart = 0, shipAmount = 0, pqtys = 0, shpAmt = 0, Actprice = 0;

                for (var i = 0; i < carts.Count; i++)
                {

                    var qty = Convert.ToDecimal(carts[i].Qty);
                    price += (Convert.ToDecimal(carts[i].DiscountPrice) * qty);
                    pqtys += Convert.ToDecimal(carts[i].Qty);
                    Actprice += (Convert.ToDecimal(carts[i].ActualPrice) - (Convert.ToDecimal(carts[i].DiscountPrice)));
                    
                    string cutPrice = "";
                    if (carts[i].ActualPrice != "")
                    {
                        cutPrice = "<span class='old-price'>₹" + carts[i].ActualPrice + @"</span>";
                    }

                    listings += @" <div class='d-flex w-100 mb-7'>
                                    <div class='me-6'>
                                        <img src='/" + carts[i].ProductImage + @"'  class='lazy-image' width='70' alt='" + carts[i].ProductName + @"'>
                                    </div>
                                    <div class='d-flex flex-grow-1'>
                                        <div class='pe-6'>
                                            <a href='/shop-products/" + carts[i].ProductUrl + @"' class=''>" + carts[i].ProductName + @"<span class='text-body'><span> x </span> " + qty + @" </span></a>
                                        <p class='fs-14px text-body-emphasis mb-0 mt-1'>Size:<span class='text-body'>" + carts[i].ProductSize + "<span> x </span>  " + carts[i].ProductThickness + @"</span></p>
                                            <span class='small-green-text'>Your Savings ₹" + Actprice * qty + @"</span></div>
                                        <div class='ms-auto'>
                                            <p class='fs-14px text-body-emphasis mb-0 fw-bold'>₹" + (Convert.ToDecimal(carts[i].DiscountPrice) * qty) + @"</p>
                                        </div>
                                    </div>
                                </div>";
                }

                strCarts = listings;
                lblCoupon.Text = "";
                decimal dis = 0;

                if (txtCoupon.Text.Trim() != "")
                {
                    var coupon = CouponCode.GetAllCoupon(conAP).Where(s => s.CCode == txtCoupon.Text.Trim()).FirstOrDefault();
                    if (coupon != null)
                    {
                        if (coupon.ExpiryDate.Date >= TimeStamps.UTCTime().Date)
                        {
                            if (coupon.CType == "Value")
                            {
                                decimal.TryParse(coupon.CValue, out dis);
                                lblCoupon.Text = "Coupon added successfully";
                                lblCoupon.ForeColor = System.Drawing.Color.Green;
                                btnApply.Visible = false;
                                btnRemove.Visible = true;
                            }
                            else
                            {
                                decimal perV = 0;
                                decimal.TryParse(coupon.CValue, out perV);
                                dis = (price / (decimal)100) * perV;
                                lblCoupon.Text = "Coupon added successfully";
                                lblCoupon.ForeColor = System.Drawing.Color.Green;
                                btnApply.Visible = false;
                                btnRemove.Visible = true;
                            }
                        }
                        else
                        {
                            lblCoupon.Text = "Invalid coupon code.";
                            lblCoupon.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblCoupon.Text = "Invalid coupon code.";
                        lblCoupon.ForeColor = System.Drawing.Color.Red;
                    }

                }
                mincart += Convert.ToDecimal(carts[0].MinCartPrice);
                shipAmount += Convert.ToDecimal(carts[0].ShippingCharge);
                decimal tax = 0;
                decimal sh = price > mincart ? 0 : shipAmount;
                strSubTotal = "₹" + Math.Round(price).ToString("##");
                strTax = "₹" + (Math.Round(price) * (Convert.ToDecimal(0) / Convert.ToDecimal(100)));
                strShipping = "₹" + sh;
                strDiscount = "₹" + Math.Round(dis);
                strTotal = "₹" + Math.Round((price + sh) - dis + (price * (Convert.ToDecimal(0) / Convert.ToDecimal(100))));
            }
            else
            {
                Response.Redirect("/checkout");

            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCart", ex.Message);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            List<CartDetails> carts = CartDetails.GetAllCartDetails(conAP);
            if (carts.Count > 0)
            {
                string listings = "";
                decimal price = 0, mincart = 0, shipAmount = 0, pqtys = 0, shpAmt = 0, Actprice = 0;




                for (var i = 0; i < carts.Count; i++)
                {
                    var qty = Convert.ToDecimal(carts[i].Qty);
                    price += (Convert.ToDecimal(carts[i].DiscountPrice) * qty);
                    pqtys += Convert.ToDecimal(carts[i].Qty);
                    Actprice += (Convert.ToDecimal(carts[i].ActualPrice) - (Convert.ToDecimal(carts[i].DiscountPrice)));
                    
                    string cutPrice = "";
                    if (carts[i].ActualPrice != "")
                    {
                        cutPrice = "<span class='old-price'>₹" + carts[i].ActualPrice + @"</span>";
                    }

                    listings += @" <div class='d-flex w-100 mb-7'>
                                    <div class='me-6'>
                                        <img src='/" + carts[i].ProductImage + @"'  class='lazy-image' width='70' alt='" + carts[i].ProductName + @"'>
                                    </div>
                                    <div class='d-flex flex-grow-1'>
                                        <div class='pe-6'>
                                            <a href='/shop-products/" + carts[i].ProductUrl + @"' class=''>" + carts[i].ProductName + @"<span class='text-body'><span> x </span> " + qty + @" </span></a>
                                        <p class='fs-14px text-body-emphasis mb-0 mt-1'>Size:<span class='text-body'>" + carts[i].ProductSize + "<span> x </span>  " + carts[i].ProductThickness + @"</span></p>
                                            <span class='small-green-text'>Your Savings ₹" + Actprice * qty + @"</span></div>
                                        <div class='ms-auto'>
                                            <p class='fs-14px text-body-emphasis mb-0 fw-bold'>₹" + (Convert.ToDecimal(carts[i].DiscountPrice) * qty) + @"</p>
                                        </div>
                                    </div>
                                </div>";

                }
                strCarts = listings;
                lblCoupon.Text = "";
                decimal dis = 0;
                lblCoupon.Text = "";
                if (txtCoupon.Text.Trim() != "")
                {
                    txtCoupon.Focus();
                    txtCoupon.Text = "";
                    btnRemove.Visible = false;
                    btnApply.Visible = true;
                }

                decimal tax = 0;

                mincart += Convert.ToDecimal(carts[0].MinCartPrice);
                shipAmount += Convert.ToDecimal(carts[0].ShippingCharge);
                decimal sh = price > mincart ? 0 : shipAmount;
                strSubTotal = "₹" + Math.Round(price);
                strTax = "₹" + (Math.Round(price) * (Convert.ToDecimal(0) / Convert.ToDecimal(100)));
                strShipping = "₹" + sh;
                strDiscount = "₹" + Math.Round(dis);
                strTotal = "₹" + Math.Round((price + sh) - dis + (price * (Convert.ToDecimal(0) / Convert.ToDecimal(100))));

            }
            else
            {
                Response.Redirect("/checkout");
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCart", ex.Message);
        }
    }

    #region Create User Order   
    public string GenerateNumber()
    {
        Random random = new Random();
        string r = "";
        int i;
        for (i = 1; i < 6; i++)
        {
            r += random.Next(0, 9).ToString();
        }
        return r;
    }
    #endregion
    protected void submit_Click(object sender, EventArgs e)
    {
        string res = "";
        try
        {
             List<PinCode> pin = PinCode.GetPincodeByPinCode(conAP, txtDelZip.Text.Trim());
            if (pin.Count<=0)
            {
                lblzip.Visible = true;
                lblzip.Text = "Delivery is not available for the entered pincode";
                lblzip.Attributes.Add("Class", "text-danger");
                txtDelZip.Focus();
                return;
            }
            decimal discprice = 0, actprice = 0, price = 0;
            List<CartDetails> cart = CartDetails.GetAllCartDetails(conAP);

            discprice = cart.Sum(x => (Convert.ToDecimal(x.DiscountPrice) * Convert.ToDecimal(x.Qty)));
            actprice = cart.Sum(x => (Convert.ToDecimal(x.ActualPrice) * Convert.ToDecimal(x.Qty)));

            if (cart.Count > 0)
            {
                string OrderStatus = "Initiated";
                string oid = UserCheckout.GetOMax(conAP);
                string rMax = UserCheckout.GetRMax(conAP);
                string oGuid = Guid.NewGuid().ToString();
                string uid = HttpContext.Current.Request.Cookies["arch_i"] != null ? HttpContext.Current.Request.Cookies["arch_i"].Value : HttpContext.Current.Request.Cookies["arch_v"] != null ? HttpContext.Current.Request.Cookies["arch_v"].Value : "";
                string bType = HttpContext.Current.Request.Cookies["arch_i"] != null ? "Customer" : "Guest";
                
                
                string payType = "";
                if (rbCOD.Checked)
                {
                    payType = "COD20";
                }
                else
                {
                    payType = "PaymentGateway";
                }
                string ipAddress = CommonModel.IPAddress();
                DateTime orderedOn = CommonModel.UTCTime();
                double taxAmount = 0;
                #region Coupon Code
                decimal dis = 0;
                CouponCode coupon = null;
                if (txtCoupon.Text.Trim() != "")
                {
                    coupon = CouponCode.GetAllCoupon(conAP).Where(s => s.CCode == txtCoupon.Text.Trim()).FirstOrDefault();
                    if (coupon != null)
                    {
                        if (coupon.ExpiryDate.Date >= CommonModel.UTCTime().Date)
                        {
                            if (coupon.CType == "Value")
                            {
                                decimal.TryParse(coupon.CValue, out dis);
                            }
                            else
                            {
                                decimal perV = 0;
                                decimal.TryParse(coupon.CValue, out perV);
                                dis = (discprice / (decimal)100) * perV;
                            }
                        }
                    }
                }

                #endregion

                price = (discprice - dis);
                if (price > 0)
                {
                    #region Order Items Table
                    foreach (CartDetails cd in cart)
                    {
                        double tax_ = 0, prc = 0, fTax = 0;
                        double.TryParse(cd.TaxGroup, out tax_);

                        double.TryParse(cd.DiscountPrice, out prc);
                        fTax = ((Convert.ToDouble(100) + tax_) / Convert.ToDouble(100));

                        taxAmount += ((Convert.ToDouble(prc) * cd.Qty) - ((Convert.ToDouble(prc) * cd.Qty) / fTax));

                        CheckoutItems items = new CheckoutItems();
                        items.OrderGuid = oGuid;
                        items.ProductId = cd.ProductId.ToString();
                        items.ProductName = cd.ProductName;
                        items.TaxGroup = "";//cd.TaxGroup == "" ? "18" : cd.TaxGroup;
                        items.PriceId = cd.PriceId.ToString();
                        items.Qty = Convert.ToString(cd.Qty);
                        items.Price = cd.DiscountPrice;
                        items.ActualPrice = cd.ActualPrice;
                        items.Size = cd.ProductSize;
                        items.Thickness = cd.ProductThickness;
                        items.AddedOn = orderedOn;
                        items.ProductUrl = cd.ProductUrl;
                        items.ProductImage = cd.ProductImage;
                        items.ProductGuid = cd.ProductGuid;
                        UserCheckout.InsertCheckOutItem(conAP, items);
                    }
                    #endregion

                    #region User Billing Address
                    UserBillingAddress bill = new UserBillingAddress();
                    bill.FirstName = txtFName.Text.Trim();
                    bill.LastName = txtLName.Text.Trim();
                    bill.EmailId = txtEmail.Text.Trim();
                    bill.Address1 = txtAddress1.Text.Trim();
                    bill.Address2 = txtAddress2.Text.Trim();
                    bill.Zip = txtZip.Text.Trim();
                    bill.City = txtCity.Text.Trim();
                    bill.State = txtState.Text.Trim();
                    bill.AddedDateTime = orderedOn;
                    bill.Block = "";
                    bill.Country = ddlCountry.SelectedValue;
                    bill.Mobile = txtPhone.Text.Trim();
                    bill.OrderGuid = oGuid;
                    bill.UserGuid = uid;
                    bill.AddedIp = ipAddress;
                    bill.CustomerGSTN = "";
                    bill.CompanyName = "";
                    bill.Salutation = "";
                    bill.Landmark = "";
                    UserCheckout.InsertBillingAddress(conAP, bill);
                    #endregion
                    if (customCheck5.Checked)
                    {
                        #region User Delivery Address
                        UserDeliveryAddress delA = new UserDeliveryAddress();
                        delA.AddedDateTime = orderedOn;
                        delA.Apartment = "";
                        delA.Block = "";
                        delA.Landmark = "";
                        delA.Salutation = "";
                        delA.Address1 = txtAddress1.Text.Trim();
                        delA.Address2 = txtAddress2.Text.Trim();
                        delA.City = txtCity.Text.Trim();
                        delA.Country = "India";
                        delA.State = txtState.Text.Trim();
                        delA.FirstName = txtFName.Text.Trim();
                        delA.LastName = txtLName.Text.Trim();
                        delA.Email = txtEmail.Text.Trim();
                        delA.Mobile = txtPhone.Text.Trim();
                        delA.OrderGuid = oGuid;
                        delA.UserGuid = uid;
                        delA.AddedIp = ipAddress;
                        delA.Zip = txtZip.Text.Trim();

                        UserCheckout.InsertDeliveryAddress(conAP, delA);
                        #endregion
                    }
                    else
                    {
                        #region User Delivery Address
                        UserDeliveryAddress delA = new UserDeliveryAddress();
                        delA.AddedDateTime = orderedOn;
                        delA.Apartment = "";
                        delA.Block = "";
                        delA.Landmark = "";
                        delA.Salutation = "";
                        delA.Address1 = txtDelAddress1.Text.Trim();
                        delA.Address2 = txtDelAddress2.Text.Trim();
                        delA.City = txtDelCity.Text.Trim();
                        delA.Country = "India";
                        delA.State = txtDelState.Text.Trim();
                        delA.FirstName = txtFName.Text.Trim();
                        delA.LastName = txtLName.Text.Trim();
                        delA.Email = txtDelEmailID.Text.Trim();
                        delA.Mobile = txtDelPhone.Text.Trim();
                        delA.OrderGuid = oGuid;
                        delA.UserGuid = uid;
                        delA.AddedIp = ipAddress;
                        delA.Zip = txtDelZip.Text.Trim();

                        UserCheckout.InsertDeliveryAddress(conAP, delA);
                        #endregion
                    }

                    decimal actdis = 0;
                    decimal mincart = 0;
                    decimal shipAmount = 0;
                    actdis = Convert.ToDecimal(actprice) - Convert.ToDecimal(discprice);
                    #region Shipping price

                     mincart += Convert.ToDecimal(cart[0].MinCartPrice);
                     shipAmount += Convert.ToDecimal(cart[0].ShippingCharge);

                    decimal sh = price > mincart ? 0 : shipAmount;
                  //  shipAmount = discprice > 10000 ? 0 : Convert.ToDecimal(1);
                    #endregion
                    decimal finalPrice = 0;
                    finalPrice = Convert.ToDecimal(price) + Convert.ToDecimal(sh);
                    decimal adv = 0, blnc = 0;
                    if (payType == "COD20")
                    {
                        adv = 0;
                        blnc = Math.Round(finalPrice - adv);
                        OrderStatus = "In-Process";
                    }
                    else
                    {
                        adv = finalPrice;
                        blnc = 0;
                    }
                    #region Order Table
                    string orid = UserCheckout.GetOMax(conAP);
                    Orders od = new Orders();
                    od.LastUpdatedOn = orderedOn;
                    od.LastUpdatedIp = ipAddress;
                    od.OrderedIp = ipAddress;
                    od.OrderGuid = oGuid;
                    od.OrderId = "APDORD" + GenerateNumber() + orid;
                    od.UserName = txtFName.Text.Trim();
                    od.EmailId = txtEmail.Text.Trim();
                    //od.EmailId = txtDelEmailID.Text.Trim();
                    od.Contact = txtPhone.Text.Trim();
                    od.OrderMax = oid;
                    od.OrderOn = orderedOn;
                    od.OrderStatus = OrderStatus;
                    od.PaymentId = "";
                    od.PaymentMode = payType;
                    od.PaymentStatus = "Initiated";
                    od.ReceiptNo = "";
                    od.RMax = "";
                    od.PromoCode = coupon != null ? "" : "";
                    od.PromoType = coupon != null ? coupon.CType : "";
                    od.PromoValue = coupon != null ? coupon.CValue : "";
                    od.AddDiscount = dis.ToString(".##");
                    od.CODAmount = "0";
                    od.AdvAmount = Convert.ToString(adv);
                    od.BalAmount = Convert.ToString(blnc);
                    od.Discount = actdis.ToString(".##");
                    od.ShippingPrice = sh.ToString(".##");
                    od.SubTotal = discprice.ToString(".##");
                    od.SubTotalWithoutTax = (Convert.ToDecimal(discprice) - Convert.ToDecimal(taxAmount)).ToString(".##");
                    od.Tax = taxAmount.ToString(".##");
                    od.TotalPrice = (finalPrice).ToString(".##");
                    od.UserGuid = uid;
                    od.UserType = bType;

                    int ord = UserCheckout.CreateUserOrder(conAP, od);
                    if (ord > 0)
                    {
                        if (payType == "COD20")
                        {
                            Orders orders = new Orders();

                            string Oid = UserCheckout.GetOrderId(conAP, oGuid);
                            string rId = UserCheckout.GetRMax(conAP);
                            orders.OrderGuid = oGuid;
                            orders.PaymentStatus = "Pending";
                            orders.OrderStatus = "In-Process";
                            orders.PaymentId = "";
                            orders.hostedCheckoutId = "";
                            orders.RMax = rId;
                            orders.ReceiptNo = "APDREC" + GenerateNumber() + rId;
                            int x = UserCheckout.UpdateUserOrder(conAP, orders);
                            if (x > 0)
                            {
                                int createOrder = ShipRocket.CreatShipRocketOrder(conAP, oGuid);
                                if (createOrder == 0)
                                {
                                    Emails.ShiprocketOrderFailedRequest(Oid);
                                }
                                CartDetails.RemoveAllItemsFromCart(conAP, uid);
                                UserCheckout.SendToUser(conAP, oGuid);
                                Response.Redirect("/pay-success.aspx?o=" + oGuid);
                            }
                        }
                        else
                        {
                            Response.Redirect("/pay-now.aspx?order=" + oGuid);
                        }
                    }
                    else
                    {
                        Response.Redirect("/Pay-Error.aspx");
                    }
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "submit_Click", ex.Message);
        }
    }
}