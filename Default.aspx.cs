using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection conAP = new SqlConnection(ConfigurationManager.ConnectionStrings["conAP"].ConnectionString);

    public string strBlog, strClientStories , strFeatureProducts, strBannerImages , strTags, strResources = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindTop3Blog();
        BindClientStories();
        BindFeatureProducts();
        BindBannerImages();
        BindTop4Tags();
        GetAllResources();
    }
    public void GetAllResources()
    {
        try
        {
            strResources = "";
            string Resources = "";
            List<Brochures> cas = Brochures.GetAllBrochures(conAP).OrderByDescending(s => Convert.ToDateTime(s.AddedOn)).ToList();
            int i = 0;
            foreach (Brochures nb in cas)
            {

                Resources += @"<div class='col-xl-3 col-md-6 col-6 animate__fadeInUp animate__animated' data-animate='fadeInUp'>
                        <div class='icon-box icon-box-style-1 card border-0 text-center'>
                            <div class='icon-box-icon card-img text-primary'>
                                <img src='/"+nb.Image+@"' width='65' />
                            </div>
                            <div class='icon-box-content card-body pt-4'>
                                <h3 class='icon-box-title card-title fs-5 mb-0 pb-0'>"+nb.Title+@"</h3>
                                <a href='/"+nb.PDF+@"' download class='btn btn-link p-0 mt-2 text-decoration-none green-text fw-semibold'>Download<i class='far fa-download ps-2 fs-13px'></i>
                                </a>
                            </div>
                        </div>
                    </div>";
                i++;
            }
            strResources += @" <section class='pt-lg-10 pb-lg-10 py-15 bg-warning-hover'>
            <div class='container'>
                <div class='text-center section-title' data-animate='fadeInUp'>
                    <h2 class='mb-6'>Resources</h2>
                    <p class=''>
                        Our bundles were designed to conveniently package your tanning essentials while saving you money.
                    </p>
                </div>
            </div>
            <div class='container-xxl mt-10'>
                <div class='row gy-4'>"+ Resources + @"</div>
            </div>
        </section>";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBrochures", ex.Message);
        }
    }
    public void BindTop3Blog()
    {
        try
        {
            strBlog = "";
            List<Blogs> blogs = Blogs.GetAllListBlogs(conAP, 1);
            if (blogs.Count > 0)
            {
                foreach (Blogs blog in blogs)
                {
                    strBlog += @"<div class='slick-slide slick-current slick-active' data-slick-index='0' aria-hidden='false' tabindex='0' style='width: 480px;'>
                    <article class='card card-post-grid-3 bg-transparent border-0 animate__fadeInUp animate__animated' data-animate='fadeInUp'>
                        <figure class='card-img-top mb-8 position-relative'>
                            <a href='/blog/" + blog.Url +"' class='hover-shine hover-zoom-in d-block' title='"+blog.Title+@"' tabindex='0'>
                                <img data-src='"+blog.ImageUrl+ @"' class='img-fluid w-100 loaded' alt='unavailable' width='450' height='290' src='"+blog.ImageUrl+@"' loading='lazy' data-ll-status='loaded'>
                            </a>
                        </figure>
                        <div class='card-body p-0'>
                            <ul class='post-meta list-inline lh-1 d-flex flex-wrap fs-13px text-uppercase ls-1 fw-semibold m-0'>

                                <li class='border-start list-inline-item'>" + (blog.PostedOn).ToString("MMM dd, yyyy") + @"</li>
                            </ul>
                            <h4 class='card-title lh-base mt-5 pt-2 mb-0 fs-20px'>
                                <a class='text-decoration-none' href='/blog/" + blog.Url +"' title='" + blog.Title+@"' tabindex='0'>"+blog.Title+@"</a>
                            </h4>
                        </div>
                    </article>
                </div>";
                }
            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTop3Blog", ex.Message);
        }
    }
    public void BindClientStories()
    {
        try
        {
            strClientStories = "";
            List<ClientStories> Stories = ClientStories.GetAllClientStories(conAP);
            if (Stories.Count > 0)
            {
                foreach (ClientStories story in Stories)
                {
                    strClientStories += @" <div class='mb-6'>
                    <div class='card card-product grid-2 bg-transparent border-0'>
                        <div class='testimonial-card' data-animate='fadeInUp'>
                            <p>"+ story.Details+ @"</p>
                            <div class='meta-details'>
                                <h4>"+ story.Name + @"</h4>
                                <span>"+story.Designation+@"</span>
                            </div>
                        </div>
                    </div>
                </div>";
                }
            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTop3Blog", ex.Message);
        }
    }
    public void BindTop4Tags()
    {
        try
        {
            strTags = "";
            List<Tags> tag = Tags.GetTop4Tags(conAP);
            if (tag.Count > 0)
            {
                foreach (Tags t in tag)
                {
                    strTags += @" <div class='col-md-6 col-xl-3 col-6' data-animate='fadeInUp'>
                        <div class='card border-0 rounded-0 hover-zoom-in hover-shine'>
                            <img class='lazy-image card-img object-fit-cover new-heigh' src='/"+t.TagImage+@"'  width='330' height='450' alt='Not Avail' />
                            <div class='card-img-overlay d-inline-flex flex-column p-lg-8 p-4 justify-content-end text-center bg-dark bg-opacity-25'>
                                <h3 class='card-title text-white lh-25px lh-lg-45px font-primary fw-normal  fs-6 fs-lg-3'>"+t.Title+@"
                                </h3>
                                <div>
                                    <a href='/shop/"+t.TagURL+@"' class='btn btn btn-link new-font p-0 fw-semibold text-white border-bottom border-0 rounded-0 border-currentColor text-decoration-none'>Shop Now</a>
                                </div>
                            </div>
                        </div>
                    </div>";
                }
            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTop3Blog", ex.Message);
        }
    }
    public void BindFeatureProducts()
    {
        try
        {
            strFeatureProducts = "";
            List<ProductDetails> products = ProductDetails.GetAllFeaturedProducts(conAP);
            if (products.Count > 0)
            {
                foreach (ProductDetails pd in products)
                {
                    strFeatureProducts += @" <div data-animate='fadeInUp'>
                    <div class='card card-product grid-1 bg-transparent border-0'>
                        <figure class='card-img-top position-relative mb-7 overflow-hidden'>
                            <a href='/shop-products/" + pd.ProductUrl+@"'
                               class='hover-zoom-in d-block'
                               title='Perfecting Facial Oil'>
                                <img src='/"+pd.ProductImage+@"' class='img-fluid lazy-image w-100' alt='"+pd.ProductName+ @"' width='330' height='440' />
                            </a>
                        </figure>
                        <div class='card-body text-center p-0'>
                            <div class='product-details'>
                               <a href='/shop-products/" + pd.ProductUrl+@"'><h3>" + pd.ProductName+ @"</h3></a>
                            </div>
                        </div>
                    </div>
                </div>";
                }
            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTop3Blog", ex.Message);
        }
    }
    protected void Subscribe_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                EmailSubscribe cat = new EmailSubscribe();
                cat.EmailId = txtSubscribeEmail.Text.Trim();
                List<EmailSubscribe> EmailExist = EmailSubscribe.GetAllEmailSubscribedCheck(conAP, txtSubscribeEmail.Text.Trim());
                if (EmailExist.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Subscribed successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    txtSubscribeEmail.Text = "";
                    return;
                }

                int result = EmailSubscribe.InserEmailSubscribe(conAP, cat);
                if (result > 0)
                {
                    txtSubscribeEmail.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Subscribed successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Subscribe_Click", ex.Message);
        }

    }
    public void BindBannerImages()
    {
        try
        {
            string images = "";
            List<BannerImages> banner = BannerImages.GetBannerImage(conAP);
            if (banner.Count > 0)
            {
                foreach (BannerImages ban in banner)
                {
                    images += @"<div class='vh-100 d-flex align-items-center'>
      <div class='z-index-2 container container-xxl py-21 pt-xl-10 pb-xl-11'>
          <div class='hero-content text-start'>"+ban.Description+@"
              <div class='cta-btn' data-animate='fadeInDown'>
                  <a href='/"+ban.Link+@"' class='btn orange-btn'>
                      Explore Now <i class='fa-solid fa-arrow-circle-right'></i>
                  </a>
              </div>
          </div>
      </div>
      <div class='lazy-bg bg-overlay position-absolute z-index-1 w-100 h-100'
           data-bg-src='" + ban.DesktopImage + @"'></div>
  </div>";
                }
                strBannerImages += @"<section class='home-banner'>
         <div class='slick-slider hero hero-header-02 slick-slider-dots-inside'
              data-slick-options='{&#34;arrows&#34;:true,&#34;autoplay&#34;:true,&#34;autoplaySpeed&#34;:9000,&#34;cssEase&#34;:&#34;ease-in-out&#34;,&#34;dots&#34;:false,&#34;fade&#34;:true,&#34;infinite&#34;:true,&#34;slidesToShow&#34;:1,&#34;speed&#34;:600}'>
           " + images + @"
         </div>
     </section>";
            }
        }
        catch (Exception ex)
        {

            CommonModel.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTop3Blog", ex.Message);
        }
    }
}