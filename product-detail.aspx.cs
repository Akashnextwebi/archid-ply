using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class product_detail : System.Web.UI.Page
{
    SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);
    public string strProductGallery, strProductName, strProducts, strRelatedProducts, strProductCategory, strUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strUrl = Convert.ToString(RouteData.Values["subcaturl"]);
        if (RouteData.Values["subcaturl"] == null)
        {
            Response.Redirect("/404");
        }
        if (!IsPostBack)
        {
            bindProduct();
            bindRelatedPrdoucts();
            HiddenField1.Value = strProductName;
        }
    }
    public void bindProduct()
    {
        try
        {
            string currentUrl = Request.Url.AbsoluteUri;
            string[] segments = currentUrl.Split('/');
            var divCatelog = "";
            string url = segments.Length > 4 ? segments[segments.Length - 1] : string.Empty;
            List<EnquiryProduct> products = EnquiryProduct.GetEnquiryProductByUrl(conAP, strUrl).ToList();
            if (products.Count > 0)
            {
                foreach (EnquiryProduct prod in products)
                {
                    strProductName = prod.ProductName;
                    strProductCategory = prod.Category;
                    if (prod.Category == "2")
                    {
                        divCatelog = @"<div class='col-md-5'>
<a href='/images_/others/venner-catelog.pdf' download class='btn w-100 bg-new-color btn-hover-bg-white btn-hover-border-warning' title='Catalouge'>Catalouge <i class='far fa-download ps-2 fs-13px'></i></a>
                        </div>";
                    }
                    else
                    {
                        divCatelog = "";

                    }
                    #region features divided
                    List<ProductFeatures> features = ProductFeatures.GetProductFeatures(conAP, prod.Features);
                    var sksloop = "";
                    var sksloop1 = "";

                    int i = 1;
                    if (features.Count > 0)
                    {
                        foreach (ProductFeatures x in features)
                        {
                            if (i % 2 == 0)
                            {
                                sksloop1 += @"<li>
                                        <img src='/" + x.Image + @"' width='45' class='img-fluid' />
                                        <span class='icon-box-title card-title'>" + x.Title + @"</span>
                                     </li>";
                            }
                            else
                            {
                                sksloop += @"<li>
                                        <img src='/" + x.Image + @"' width='45' class='img-fluid' />
                                        <span class='icon-box-title card-title'>" + x.Title + @"</span>
                                     </li>";
                            }
                            i++;
                        }


                    }
                    #endregion

                    #region Specification divided
                    List<ProductSpecifications> specifications = ProductSpecifications.GetAllFAQS(conAP, Convert.ToString(prod.Id));
                    var specLoop = "";

                    int j = 1;
                    if (specifications.Count > 0)
                    {
                        foreach (ProductSpecifications x in specifications)
                        {
                            if (j % 2 == 0)
                            {
                                specLoop += @"<div class='d-flex align-items-center justify-content-between bg-transparent-white'>
                                                    <span class='font-bold'>" + x.Title + @"</span>
                                                    <span class='d-block ml-auto text-body-emphasis fw-bold fea'>" + x.Description + @"</span>
                                                </div>";

                            }
                            else
                            {
                                specLoop += @"<div class='d-flex align-items-center justify-content-between mb-0 bg-transparent-blue'>
                                                    <span>" + x.Title + @"</span>
                                                    <span class='d-block ml-auto text-body-emphasis fw-bold fea'>" + x.Description + @"</span>
                                                </div>";
                            }
                            j++;
                        }


                    }
                    #endregion

                    List<EnquiryProductGallery> galleries = EnquiryProductGallery.GetEnquiryProductGallery(conAP, products[0].ProductGuid);
                    if (galleries.Count > 0)
                    {

                        string menuImg = "";
                        string mainImg = "";
                        foreach (EnquiryProductGallery gal in galleries)
                        {
                            menuImg += @"<img src='/" + gal.Images + @"' lass='cursor-pointer lazy-image mx-3 mx-xl-0 px-0 mb-xl-7' width='75' height='100' title='' alt=''/>";
                            mainImg += @"<a href='/" + gal.Images + @"' data-gallery='product-gallery' data-thumb-src='/" + gal.Images + @"'><img src='/" + gal.Images + @"' width='540' height='720' title='' class='h-auto lazy-image' alt=''/></a>";
                        }


                        strProductGallery += @"<div class='col-md-6 pe-lg-13'>
                    <div class='position-sticky top-0'>
                        <div class='row'>
                            <div class='col-xl-2 pe-xl-0 order-1 order-xl-0 mt-5 mt-xl-0'>
                                <div id='vertical-slider-thumb' class='slick-slider slick-slider-thumb ps-1 ms-n3 me-n4 mx-xl-0' data-slick-options='{&#34;arrows&#34;:false,&#34;asNavFor&#34;:&#34;#vertical-slider-slides&#34;,&#34;dots&#34;:false,&#34;focusOnSelect&#34;:true,&#34;responsive&#34;:[{&#34;breakpoint&#34;:1260,&#34;settings&#34;:{&#34;vertical&#34;:false}}],&#34;slidesToShow&#34;:4,&#34;vertical&#34;:true}'>
                                " + menuImg + @"
                               </div>
                            </div>
                            <div class='col-xl-10 ps-xl-8 pe-xl-0 order-0 order-xl-1'>
                                <div id='vertical-slider-slides' class='slick-slider slick-slider-arrow-inside slick-slider-dots-inside slick-slider-dots-light g-0' data-slick-options='{&#34;arrows&#34;:false,&#34;asNavFor&#34;:&#34;#vertical-slider-thumb&#34;,&#34;dots&#34;:false,&#34;slidesToShow&#34;:1,&#34;vertical&#34;:true}'>
                                    " + mainImg + @"
                                </div>
                            </div>
                        </div>
                    </div>
                </div>";
                    }
                    strProducts += @"<div class='row justify-content-center'>" + strProductGallery + @"<div class='col-md-4 pt-md-0 pt-10'>
                    <h1 class='mb-4 pb-2 fs-3'>" + prod.ProductName + @"</h1>
                    <p class='fs-17px'>" + prod.ShortDesc + @"</p>
<h4 class='text-left mb-8'>Features</h4>
                    <div class='product-features mb-10'>
                        <div class='row'>
                           <div class='col-md-6'>
                                <ul>" + sksloop + @"</ul>
                            </div>
                            <div class='col-md-6'>
                                <ul>" + sksloop1 + @"</ul>
                            </div>
                        </div>
                    </div>
                   <div class='card border border-2  rounded mb-8' style='box-shadow: 0 0 10px 0 rgba(0,0,0,0.1)'>
                        <div class='card-body py-0 px-0'>
                            <div class='product-features'>
                                <div class='row align-items-center'>
                                    <div class='col-md-12'>
                                        <div class='card border-2 mb-0'>
                                            <div class='card-body px-0 pt-0 pb-0'>" + specLoop + @"</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    <div class='row justify-content-center'>
                        <div class='col-md-5'>
                            <a href='javascript:void(0);' class='btn w-100 green-btn btn-hover-bg-primary btn-hover-border-primary' data-bs-toggle='modal' data-bs-target='#contactUsModal' title='Check Out'>Enquiry </a>
                        </div> 
" + divCatelog + @"
                    </div>
                    </div>
                </div>";
                }
            }
            else
            {
                Response.Redirect("/404");
            }
        }
        catch (Exception ex)
        {
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "bindMenu()", ex.Message);
        }
    }
    public void bindRelatedPrdoucts()
    {
        try
        {
            strRelatedProducts = "";
            //List<SubCategory> subcategories = SubCategory.GetSubCategoryByUrl(conAP, subcaturl).Where(s => s.DisplayHome == "Yes").OrderBy(s => s.DisplayOrder).ToList();
            //if (subcategories.Count > 0)
            // {
            // foreach (SubCategory category in subcategories)
            //{
            List<EnquiryProduct> products = EnquiryProduct.GetAllEnquiryProductByCategory(conAP, strProductCategory).ToList();
            if (products.Count > 0)
            {
                foreach (EnquiryProduct prodd in products)
                {
                    strRelatedProducts += @"<div class='mb-6'>
                        <div class='card card-product grid-2 bg-transparent border-0'>
                            <figure class='card-img-top position-relative mb-0 overflow-hidden'>
                                <a href='/products/" + prodd.ProductUrl + @"' class='hover-zoom-in d-block' title='" + prodd.ProductName + @"'>
                                    <img src='/" + prodd.ProductImage + @"' class='img-fluid lazy-image w-100' alt='" + prodd.ProductName + @"' width='330' height='440'>
                                </a>
                            </figure>
                            <div class='card-body text-center p-0'>
                                <h4 class='product-title card-title text-primary-hover text-body-emphasis fs-15px fw-500 mb-3'><a class='text-decoration-none text-reset' href='/products/" + prodd.ProductUrl + @"'>" + prodd.ProductName + @"</a></h4>
                                <a href='/products/" + prodd.ProductUrl + @"' class='btn btn-link p-0 mt-2 text-decoration-none text-primary fw-semibold'>
                                    Read More<i class='far fa-arrow-right ps-2 fs-13px'></i>
                                </a>
                            </div>
                        </div>
                    </div>";

                }
            }
            //}
            //}
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "bindRelatedPrdoucts", ex.Message);

        }
    }
    protected void btnSendMessage_click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                Enquiry cat = new Enquiry();
                cat.UserName = txtFullName.Text.Trim();
                cat.EmailId = txtEmail.Text.Trim();
                cat.ContactNo = txtPhone.Text.Trim();
                cat.Message = txtMessage.Text.Trim();
                cat.ProductType = "Enquiry Products";
                cat.Products = HiddenField1.Value;
                int result = Enquiry.InserEnquiry(conAP, cat);
                if (result > 0)
                {
                    Emails.sendEnquiryToCustomer(cat.UserName, cat.EmailId);
                    Emails.SendEnquiryRequestToAdmin(txtFullName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.Trim(), HiddenField1.Value, txtMessage.Text.Trim());
                    txtFullName.Text = txtEmail.Text = txtMessage.Text = txtPhone.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Your enquiry has been submitted successfully!',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                }
                bindProduct();
                bindRelatedPrdoucts();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }
}