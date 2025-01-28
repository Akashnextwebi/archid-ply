<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="dealers.aspx.cs" Inherits="dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-select{
            background-color:#fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--<section class="position-relative custom-overlay" id="about_introduction">

        <div class="lazy-bg bg-overlay position-absolute z-index-1 w-100 h-100   light-mode-img" data-bg-src="assets/imgs/investor-banner.jpg">
        </div>
        <div class="lazy-bg bg-overlay dark-mode-img position-absolute z-index-1 w-100 h-100" data-bg-src="assets/imgs/investor-banner.jpg">
        </div>

        <div class="position-relative z-index-2 container py-18 py-lg-20">

            <h2 class="fs-56px mb-7 text-white text-center">Investor </h2>
        </div>
    </section>-->

    <main id="content" class="wrapper layout-page investor-contact pt-5 pb-10" style="background: #f1efec url('assets/imgs/bg-img2.png'); background-repeat: no-repeat; background-position: right; background-attachment: fixed">

        <div class="container">
            <nav class="py-2 lh-30px" aria-label="breadcrumb">
                <ol class="breadcrumb justify-content-start py-1">
                    <li class="breadcrumb-item"><a href="/">Home</a></li>

                    <li class="breadcrumb-item"><a href="/contact-us">Contact</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Dealers</li>
                </ol>
            </nav>
        </div>
        <div class="container">
    <div class="row justify-content-center mt-5">
       
    </div>
</div>
        <div class="container">
            <div class="row justify-content-center">
                <div class="dashboard-page-content" data-animated-id="1">
                    <div class="row mb-9 align-items-center">
                        <div class="col-lg-8 mb-10 mb-sm-0 text-start">
                            <h2 class=" mb-0">Dealers</h2>
                        </div>
                         <div class="col-lg-4 col-ms-6 col-sm-12 col-12">
     <div class="mx-auto" >
         <div class="input-group form-border-transparent d-flex">
             <asp:DropDownList runat="server" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" ID="ddlCity">
                 <asp:ListItem Value="">Select City</asp:ListItem>
             </asp:DropDownList>
         </div>
     </div>
 </div>
                    </div>
                    <div class="row">
                        <%=strDealers %>
                        <%--     <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">
                                    <div class="card-body p-0">
                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                        <%--   <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">

                                    <div class="card-body p-0">



                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>


                        </div>


                        <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">

                                    <div class="card-body p-0">



                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>


                        </div>

                        <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">

                                    <div class="card-body p-0">



                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>


                        </div>
                        <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">

                                    <div class="card-body p-0">



                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>


                        </div>

                        <div class="col-xl-4">
                            <div class="location-box">
                                <div class="card rounded-4 p-7 mb-7">

                                    <div class="card-body p-0">



                                        <h2 class="fs-28px mb-2 mb-md-2">Name</h2>
                                        <div class="col-md-12 mb-11">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-20px mb-2 mt-5">
                                                        Address
                                                    </h3>
                                                    <div class="fs-6">
                                                        <p class="mb-2 pb-4 fs-6">
                                                            Plot No-7, Sector-9,<br /> Integrated Industrial Area<br /> SIDCUL ,
                                                            PANT Nagar,<br />  Rudrapur,Udham Singh Nagar,<br /> RUDRAPUR-236125
                                                        </p>


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-6 mb-7">
                                            <div class="d-flex align-items-start">
                                                <div class="d-none">
                                                    <svg class="icon fs-2">
                                                        <use xlink:href="#"></use>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <h3 class="fs-5 mb-6">Contact</h3>
                                                    <div class="fs-6">
                                                        <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> 05944- 250270</span></p><p class="mb-0 fs-6">
                                                            E-mail: bangalore@archidply.com

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>


                        </div>--%>
                    </div>

                </div>

            </div>
        </div>
        <section id="special_offer_save_on_sets_2" class="">
            <div class="container container-xxl">
                <h2 class="mb-10 fs-2 text-center">Want to Become a <span class="text-primary">Dealer?</span></h2>
                <div class="row align-items-center">
                    <div class="container text-center col-lg-6 px-0  order-2">
                <%--<p class="mw-lg-100 fs-17px text-justify">Are you looking to grow your business by partnering with a trusted brand? Becoming a dealer with us gives you access to:</p>--%>
                        <h4 class="mb-10 fs-4">Join Our Dealer Network Today!</h4>

                        <div class="contact-form" method="post" action="#">
                            <div class="row mb-8 mb-md-10">
                                <div class="col-md-6 col-12 mb-8 mb-md-0">
                                    <asp:TextBox runat="server" MaxLength="100" ID="txtName" CssClass="form-control acceptOnlyAlpha" placeholder="Name" data-val-id="rfv1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtName" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6 col-12">
                                    <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control onlyNum" MaxLength="10" placeholder="Phone" data-val-id="rfv2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv4" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtPhone" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6 mt-8 col-12">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="200" placeholder="Email" data-val-id="rfv2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtEmail" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="txtEmail" Display="None" ValidationGroup="ContactUs" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Invalid E-mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-6 mt-8 col-12">
                                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control acceptOnlyAlpha" MaxLength="10" placeholder="City" data-val-id="rfv2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtCity" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:TextBox ID="txtMessage" TextMode="MultiLine" Rows="7" placeholder="Message" runat="server" CssClass="form-control mb-6" data-val-id="rfv3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtMessage" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                            <asp:LinkButton runat="server" ValidationGroup="ContactUs" OnClick="submit_Click" ID="submit" CssClass="btn btn-dark btn-hover-bg-primary btn-hover-border-primary px-11 mt-10 mb-10" Text="Submit" />
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </main>
</asp:Content>

