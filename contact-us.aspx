<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .input-error {
            border: 2px solid red !important;
            box-shadow: 0 0 5px red;
        }
    </style>
    <link href="Admin/assets/libs/snackbar/snackbar.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="content" class="wrapper layout-page">
        <section class="position-relative custom-overlay" id="about_introduction">

            <div class="lazy-bg bg-overlay position-absolute z-index-1 w-100 h-100   light-mode-img" data-bg-src="assets/imgs/about-banner.jpg">
            </div>
            <div class="lazy-bg bg-overlay dark-mode-img position-absolute z-index-1 w-100 h-100" data-bg-src="assets/imgs/banner-2.png">
            </div>
            <div class="position-relative z-index-2 container py-15 py-lg-22">
                <h2 class="fs-56px mb-0 text-white text-center">Contact Us</h2>
            </div>
        </section>
        <section data-animated-id="1">
            <div class="container">
                <div class="py-5">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb breadcrumb-site py-0 d-flex justify-content-start">
                            <li class="breadcrumb-item">
                                <a class="text-decoration-none text-body" href="/">Home</a>
                            </li>
                            <li class="breadcrumb-item active pl-0 d-flex align-items-center" aria-current="page">Contact Us</li>
                        </ol>
                    </nav>
                </div>
            </div>
            <div class="container pt-13">
                <div class="text-center">
                    <div class="text-center">
                        <h2 class="fs-36px mb-9">Keep In Touch with Us</h2>
                        <p class="fs-18px mb-14 w-lg-60 w-xl-50 mx-md-12 mx-lg-auto">We’re talking about clean beauty gift sets, of course – and we’ve got a bouquet of beauties for yourself or someone you love.</p>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-4 mb-12 mb-md-0">
                        <div class="d-flex align-items-start">
                            <div class="pe-lg-9 pe-8 text-primary">
                                <svg class="icon fs-2">
                                    <use xlink:href="#icon-box-07"></use>
                                </svg>
                            </div>
                            <div>
                                <h3 class="fs-5 mb-6">Address</h3>
                                <div class="fs-6">
                                    <p class="mb-2 pb-4 fs-6">
                                        No.50, Millenium Towrs,
                                        <br>
                                        Shivajinagar Bangalore — 560051
                                    </p>
                                </div>
                                <div class="fs-6">
                                    <p class="mb-2 pb-4 fs-6">
                                        No.50, Millenium Towrs,
                                        <br>
                                        Shivajinagar Bangalore — 560051
                                    </p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4 mb-12 mb-md-0">
                        <div class="d-flex align-items-start">
                            <div class="pe-lg-9 pe-8 text-primary">
                                <svg class="icon fs-2">
                                    <use xlink:href="#icon-box-05"></use>
                                </svg>
                            </div>
                            <div>
                                <h3 class="fs-5 mb-6">Contact</h3>
                                <div class="fs-6">
                                    <p class="mb-3 fs-6">Mobile:<span class="text-body-emphasis"> +91 7022012573</span></p>
                                    <p class="mb-3 fs-6">Tollfree:<span class="text-body-emphasis"> 1900 26886</span></p>
                                    <p class="mb-0 fs-6">E-mail: info@archidplydecor.com</p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4 mb-12 mb-md-0">
                        <div class="d-flex align-items-start">
                            <div class="pe-lg-9 pe-8 text-primary">
                                <svg class="icon fs-2">
                                    <use xlink:href="#icon-box-06"></use>
                                </svg>
                            </div>
                            <div>
                                <h3 class="fs-5 mb-6">Hour of operation</h3>
                                <div class="fs-6">
                                    <dl class="d-flex mb-0">
                                        <dt class="pe-3 fs-6 text-body-emphasis fw-500" style="width: 110px">Mon – Fri:</dt>
                                        <dd class="mb-0">08:30 – 20:00</dd>
                                    </dl>
                                    <dl class="d-flex mb-0">
                                        <dt class="pe-3 fs-6 text-body-emphasis fw-500" style="width: 110px">Sat &amp; Sun:</dt>
                                        <dd class="mb-0">09:30 – 21:30</dd>
                                    </dl>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>



        <section class="pt-15 pb-16 pt-lg-17 pb-lg-18 mx-auto" style="max-width: 750px" data-animated-id="3">
            <div class="container text-center">
                <h2 class="mb-10 fs-3">Get in Touch</h2>
                <div class="contact-form" method="post" action="#">
                    <div class="row mb-8 mb-md-10">
                        <div class="col-md-6 col-12 mb-8 mb-md-0">
                            <asp:TextBox runat="server" MaxLength="100" ID="txtName" CssClass="form-control acceptOnlyAlpha" placeholder="Name" data-val-id="rfv1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv1"  runat="server" Display="None" ForeColor="Red" ControlToValidate="txtName" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 col-12">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control onlyNum" MaxLength="10" placeholder="Phone" data-val-id="rfv2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtPhone" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone" Display="None" ValidationGroup="ContactUs" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter 10 Digit Valid Phone Number" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                        </div>
                           <div class="col-md-12 mt-8 col-12">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="100" placeholder="Email" data-val-id="rfv2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtEmail" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="txtEmail" Display="None" ValidationGroup="ContactUs" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Invalid E-mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <asp:TextBox ID="txtMessage" TextMode="MultiLine" Rows="6" MaxLength="250" placeholder="Message" runat="server" CssClass="form-control mb-6" data-val-id="rfv3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv3" runat="server" Display="None" ForeColor="Red" ControlToValidate="txtMessage" SetFocusOnError="true" ValidationGroup="ContactUs" ErrorMessage="Fields can't be blank"></asp:RequiredFieldValidator>
                    <asp:LinkButton runat="server" ValidationGroup="ContactUs" OnClick="submit_Click" ID="submit" CssClass="btn btn-dark btn-hover-bg-primary btn-hover-border-primary px-11" Text="Submit" />
                </div>
            </div>
        </section>
    </main>
    <script src="Admin/assets/libs/snackbar/snackbar.min.js"></script>
</asp:Content>

