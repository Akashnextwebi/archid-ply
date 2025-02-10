<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay-now.aspx.cs" Inherits="pay_now" %>

<!DOCTYPE html>
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>ARCHID PLY DECOR</title>
    <script src="/Admin/assets/js/jquery-3.6.0.min.js"></script>
    <link href="/Admin/assets/plugins/sweetalerts/sweetalert.css" rel="stylesheet" />
    <link href="/Admin/assets/plugins/sweetalerts/sweetalert2.min.css" rel="stylesheet" />
    <link rel="icon" href="/assets/imgs/archidply-favicon.png" />
    <script src="/assets/vendors/bootstrap/bootstrap-notify.min.js"></script>
    <script src="/assets/vendors/bootstrap/bootstrap.bundle.min.js"></script>
    <script src="/assets/vendors/bootstrap/popper.min.js"></script>
    <link rel="stylesheet"
        href="/assets/vendors/lightgallery/css/lightgallery-bundle.min.css" />
    <link rel="stylesheet" href="/assets/vendors/fontawesome/css/all.min.css" />
    <link rel="stylesheet" href="/assets/vendors/animate/animate.min.css" />
    <link rel="stylesheet" href="/assets/vendors/slick/slick.css" />
    <link rel="stylesheet" href="/assets/vendors/mapbox-gl/mapbox-gl.min.css" />
    <link rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" />
    <link href="https://fonts.googleapis.com/css2?family=Urbanist:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap"
        rel="stylesheet" />
    <link rel="stylesheet" href="/assets/css/theme.css" />
    <link rel="stylesheet" href="/assets/css/custom.css" />
    <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap"
        rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"
        rel="stylesheet" />
    <link href="/Admin/assets/plugins/notification/snackbar/snackbar.min.css" rel="stylesheet" />
    <style>
        /*
        This is extra css later need to modify
    */
        .cartSec .allCartProduct .cartBox .detailBox h6 {
            font-size: calc(13px + 4*(100vw - 320px)/1600);
            margin-bottom: 10px;
        }

        .payNowPageSec {
            margin: 30px 0;
        }

            .payNowPageSec .payNowProductContainer {
                background: #f7f7f7;
                padding: 25px;
                border-radius: 10px;
            }

                .payNowPageSec .payNowProductContainer .cartBox {
                    background: #ffffff;
                }

                .payNowPageSec .payNowProductContainer > h3 {
                    margin-bottom: 20px;
                    margin-left: 5px;
                }


            .payNowPageSec .AddressBox {
                background: #f7f7f7;
                padding: 25px;
                border-radius: 10px;
                margin-bottom: 20px;
            }

                .payNowPageSec .AddressBox > h3 {
                    margin-bottom: 20px;
                    margin-left: 5px;
                }

                .payNowPageSec .AddressBox .infoBox {
                    background: #ffffff;
                    padding: 20px;
                    border-radius: 10px;
                }

                    .payNowPageSec .AddressBox .infoBox p:last-child {
                        margin-bottom: 0px;
                    }

        .paySuccessPage .breadscrumb-section {
            background: #fff !important;
        }

        .user-dashboard-section .dashboard-right-sidebar .dashboard-order .order-contain > .row {
            --bs-gutter-x: 0rem !important;
        }

        .cartSec .allCartProduct .cartBox .ImgBox {
            text-align: center;
        }

            .cartSec .allCartProduct .cartBox .ImgBox img {
                /*height: 150px;*/
            }

        .cartSec .allCartProduct .cartBox .detailBox {
            padding: 20px;
        }

        .cartSec .allCartProduct .cartBox .qty-box {
            max-width: 100% !important;
        }

        .cartSec .BagDetails p {
            font-size: calc(14px + 3*(100vw - 320px)/1600) !important;
        }

        .cartSec .allCartProduct .cartBox .detailBox h5 {
            font-size: 16px
        }

        .cartSec .allCartProduct .cartBox .detailBox h3 {
            font-size: 18px;
        }

        
    </style>

</head>
<body>
    <div class="sticky-area">
        <div class="main-header nav navbar bg-body navbar-light navbar-expand-xl py-6 py-xl-0">
            <div class="container-xxl container">
                <div class="d-flex d-xl-none w-100">
                    <div class="w-72px d-flex d-xl-none">
                        <button class="navbar-toggler align-self-center border-0 shadow-none px-0 canvas-toggle p-4"
                            type="button"
                            data-bs-toggle="offcanvas"
                            data-bs-target="#offCanvasNavBar"
                            aria-controls="offCanvasNavBar"
                            aria-expanded="false"
                            aria-label="Toggle Navigation">
                            <span class="fs-24 toggle-icon"></span>
                        </button>
                    </div>

                    <div class="d-flex mx-auto">
                        <a href="/" class="navbar-brand px-8 py-4 mx-auto">
                            <img class="light-mode-img"
                                src="/assets/imgs/logo.png"
                                width="179"
                                height="26"
                                alt="Archidply Logo" />
                            <img class="dark-mode-img"
                                src="/assets/imgs/logo.png"
                                width="179"
                                height="26"
                                alt="Archidply Logo" />
                        </a>
                    </div>
                    <div class="icons-actions d-flex justify-content-end w-xl-50 fs-28px text-body-emphasis">
                        <div class="px-xl-5 d-inline-block">
                            <a class="lh-1 color-inherit text-decoration-none"
                                href="#"
                                data-bs-toggle="offcanvas"
                                data-bs-target="#searchModal"
                                aria-controls="searchModal"
                                aria-expanded="false">
                                <svg class="icon icon-magnifying-glass-light">
                                    <use xlink:href="#icon-magnifying-glass-light"></use>
                                </svg>
                            </a>
                        </div>

                        <div class="color-modes position-relative ps-5">
                            <a class="bd-theme btn btn-link nav-link dropdown-toggle d-inline-flex align-items-center justify-content-center text-primary p-0 position-relative rounded-circle"
                                href="#"
                                aria-expanded="true"
                                data-bs-toggle="dropdown"
                                data-bs-display="static"
                                aria-label="Toggle theme (light)">
                                <svg class="bi my-1 theme-icon-active">
                                    <use href="#sun-fill"></use>
                                </svg>
                            </a>
                            <ul class="dropdown-menu dropdown-menu-end fs-14px"
                                data-bs-popper="static">
                                <li>
                                    <button type="button"
                                        class="dropdown-item d-flex align-items-center active"
                                        data-bs-theme-value="light"
                                        aria-pressed="true">
                                        <svg class="bi me-4 opacity-50 theme-icon">
                                            <use href="#sun-fill"></use>
                                        </svg>
                                        Light
                                       
                                        <svg class="bi ms-auto d-none">
                                            <use href="#check2"></use>
                                        </svg>
                                    </button>
                                </li>
                                <li>
                                    <button type="button"
                                        class="dropdown-item d-flex align-items-center"
                                        data-bs-theme-value="dark"
                                        aria-pressed="false">
                                        <svg class="bi me-4 opacity-50 theme-icon">
                                            <use href="#moon-stars-fill"></use>
                                        </svg>
                                        Dark
                                       
                                        <svg class="bi ms-auto d-none">
                                            <use href="#check2"></use>
                                        </svg>
                                    </button>
                                </li>
                                <li>
                                    <button type="button"
                                        class="dropdown-item d-flex align-items-center"
                                        data-bs-theme-value="auto"
                                        aria-pressed="false">
                                        <svg class="bi me-4 opacity-50 theme-icon">
                                            <use href="#circle-half"></use>
                                        </svg>
                                        Auto
                                       
                                        <svg class="bi ms-auto d-none">
                                            <use href="#check2"></use>
                                        </svg>
                                    </button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div class="d-none d-xl-flex flex-column flex-xl-row w-100">
                    <div class="w-auto w-xl-50 d-flex align-items-center">
                        <div class="icons-actions icon-search-actions d-none d-xl-flex justify-content-start me-auto fs-28px text-body-emphasis">
                            <div class="pe-6">
                                <a class="lh-1 color-inherit text-decoration-none"
                                    href="#"
                                    data-bs-toggle="offcanvas"
                                    data-bs-target="#searchModal"
                                    aria-controls="searchModal"
                                    aria-expanded="false">
                                    <svg class="icon icon-magnifying-glass-light fs-5">
                                        <use xlink:href="#icon-magnifying-glass-light"></use>
                                    </svg>
                                    <span class="fs-15px">Search</span>
                                </a>
                            </div>
                        </div>
                        <ul class="navbar-nav w-100 w-xl-auto">
                            <li class="nav-item transition-all-xl-1 py-xl-11 py-0 px-xxl-8 px-xl-6">
                                <a class="nav-link d-flex justify-content-between position-relative py-xl-0 px-xl-0 text-uppercase fw-semibold ls-1 fs-15px fs-xl-14px"
                                    href="/"
                                    id="menu-item-home">Home</a>
                            </li>
                            <li class="nav-item transition-all-xl-1 py-xl-11 py-0 px-xxl-8 px-xl-6">
                                <a class="nav-link d-flex justify-content-between position-relative py-xl-0 px-xl-0 text-uppercase fw-semibold ls-1 fs-15px fs-xl-14px"
                                    href="/about-us"
                                    id="menu-item-pages">About Us</a>
                            </li>
                            <li class="nav-item transition-all-xl-1 py-11 me-xxl-12 me-xl-10 dropdown dropdown-hover dropdown-fullwidth position-static">
                                <a class="nav-link d-flex justify-content-between position-relative py-0 px-0 text-uppercase fw-semibold ls-1 fs-14px dropdown-toggle"
                                    href="#" data-bs-toggle="dropdown" id="menu-item-shop" aria-haspopup="true" aria-expanded="false">Our Products</a><div class="dropdown-menu mega-menu start-0 py-6  w-100"
                                        aria-labelledby="menu-item-shop">
                                        <div class="megamenu-shop container-wide py-8 px-12">
                                            <div class="row">
                                                <%=strDeskMenu %>
                                                <%--                                            <div class='col'>
                                                <h6 class='fs-18px'>Gurjan Based Plywood</h6>
                                                <ul class='list-unstyled mb-0'>
                                                    <li>
                                                        <a href='product-category.aspx' class='border-hover text-decoration-none py-3 d-block'><span class='border-hover-target'>Bon Vivant Premium Plywood  </span></a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col">
                                                <h6 class="fs-18px">The Decorative Veneer Collection</h6>
                                                    <ul class="list-unstyled mb-0">
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Bon Vivant Premium </span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Decorative Veneers  </span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Teak Veneers </span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Engineered Veneer</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">New Arivals </span></a>
                                                    </li>
                                                </ul>
                                            </div>

                                            <div class="col">
                                                <h6 class="fs-18px">Pre-laminated Particle Board</h6><ul class="list-unstyled mb-0">
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Pre-laminated Particle Board and MDF</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Pre-laminated MDF Board</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Plain Particle Board </span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Plain MDF</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Pre-veneered Particle Board and MDF </span></a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="col">
                                                <h6 class="fs-18px">Bon Vivant</h6><ul class="list-unstyled mb-0">
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Bon Vivant Coating Services</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Bon Vivant Decorative Lumber</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Bon Vivant Solid Wood Flooring </span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Bon Vivant Tabletops</span></a>
                                                    </li>
                                                    <li>
                                                        <a href="product-category.aspx" class="border-hover text-decoration-none py-3 d-block"><span class="border-hover-target">Veneered Wallpanel </span></a>
                                                    </li>
                                                </ul>
                                            </div>--%>

                                                <div class="col">
                                                    <h6 class="fs-18px">PUREPLY</h6>
                                                    <img src="/assets/imgs/pure-ply-logo.jpg" width="200" class="img-fluid mb-10" />
                                                    <a href="/products-categories/pureply">
                                                        <h6 class="fs-18px">Decorative Veneered Doors</h6>
                                                    </a>
                                                    <a href="/products-categories/pureply">
                                                        <h6 class="fs-18px">Veneered Wallpanel</h6>
                                                    </a>
                                                    <h6 class="fs-18px"></h6>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                            </li>

                        </ul>
                    </div>
                    <div class="px-10 d-none d-xl-flex align-items-center">
                        <a href="/" class="navbar-brand px-8 py-4 mx-auto">
                            <img class="light-mode-img"
                                src="/assets/imgs/logo.png"
                                width="250"
                                alt="Archidply" />
                        </a>
                    </div>
                    <div class="w-auto w-xl-50 d-flex align-items-center">
                        <ul class="navbar-nav w-100 w-xl-auto">
                            <li class="nav-item transition-all-xl-1 py-xl-11 py-0 px-xxl-8 px-xl-6">
                                <a class="nav-link d-flex justify-content-between position-relative py-xl-0 px-xl-0 text-uppercase fw-semibold ls-1 fs-15px fs-xl-14px"
                                    href="/shop"
                                    id="menu-item-blocks"
                                    aria-haspopup="true"
                                    aria-expanded="false">Shop</a>
                            </li>
                            <li class="nav-item transition-all-xl-1 py-xl-11 py-0 px-xxl-8 px-xl-6">
                                <a class="nav-link d-flex justify-content-between position-relative py-xl-0 px-xl-0 text-uppercase fw-semibold ls-1 fs-15px fs-xl-14px"
                                    href="/investorsList"
                                    id="menu-item-docs">Investors</a>
                            </li>

                            <li class="nav-item transition-all-xl-1 py-xl-11 py-0 px-xxl-8 px-xl-6 dropdown dropdown-hover dropdown-fullwidth">
                                <a class="nav-link d-flex justify-content-between position-relative py-xl-0 px-xl-0 text-uppercase fw-semibold ls-1 fs-15px fs-xl-14px dropdown-toggle"
                                    href="#"
                                    data-bs-toggle="dropdown"
                                    id="menu-item-docs"
                                    aria-haspopup="true"
                                    aria-expanded="false">Contact Us</a>
                                <div class="dropdown-menu mega-menu start-0 py-6"
                                    aria-labelledby="menu-item-docs">
                                    <div class="menumega-docs px-8" style="min-width: 250px">
                                        <a href="/factory"
                                            class="d-flex text-decoration-none mb-4 mb-lg-0"
                                            title="Documentation">
                                            <div class="flex-grow-1 ps-6">
                                                <h6 class="mb-2">Factory</h6>
                                            </div>
                                        </a>

                                        <hr class="dropdown-divider mx-n8" />

                                        <a href="/showroom"
                                            class="d-flex text-decoration-none mb-4 mb-lg-0"
                                            title="UI Kit">
                                            <div class="flex-grow-1 ps-6">
                                                <h6 class="mb-2">Showroom</h6>
                                            </div>
                                        </a>

                                        <hr class="dropdown-divider mx-n8" />

                                        <a href="/contact-us"
                                            class="d-flex text-decoration-none mb-4 mb-lg-0"
                                            title="Changelog">
                                            <div class="flex-grow-1 ps-6">
                                                <h6 class="mb-2">Offices</h6>
                                            </div>
                                        </a>

                                        <hr class="dropdown-divider mx-n8" />

                                        <a href="/dealers"
                                            class="d-flex text-decoration-none mb-4 mb-lg-0"
                                            title="Support"
                                            target="_blank">
                                            <div class="flex-grow-1 ps-6">
                                                <h6 class="mb-2">Dealers</h6>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <div class="icons-actions d-none d-xl-flex justify-content-end ms-auto fs-28px text-body-emphasis">
                            <div class="px-5 d-none d-xl-inline-block">
                                <a class="lh-1 color-inherit text-decoration-none"
                                    href="javascruipt:void(0)" data-bs-toggle="modal" data-bs-target="#signInModal">
                                    <svg class="icon icon-user-light">
                                        <use xlink:href="#icon-user-light"></use>
                                    </svg>
                                </a>
                            </div>
                            <div class="px-5 d-none d-xl-inline-block">
                                <a class="position-relative lh-1 color-inherit text-decoration-none"
                                    href="/cart">
                                    <svg class="icon icon-star-light">
                                        <use xlink:href="#icon-shopping-bag-open-light"></use>
                                    </svg>
                                    <span class="badge bg-dark text-white position-absolute top-0 start-100 translate-middle mt-4 rounded-circle fs-13px p-0 square Qty"
                                        style="--square-size: 18px">3</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="InsidePageContainer">
        <div class="payNowPageSec cartSec">

            <div class="container-fluid-lg">
            </div>
            <div class="row fullCartBag" style="display: flex;">
                <!-- Price Box -->



                <!-- Address Box -->
                <div class="col-lg-12 col-md-12">
                    <div class="allCartProduct">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="AddressBox">
                                    <h3>
                                        <img src="images_/carting.png" width="50" height="50" />
                                        Address</h3>
                                    <div class="infoBox">
                                        <%=strDelivery %>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-8">
                                <div class="payNowProductContainer">
                                    <h3>
                                        Ordered Items
                                    </h3>
                                    <div class="infoBox">
                                        <%=strAllOrderItems %>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-md-12 justify-content-center">
                    <div class="AddressBox">
                        <h3>Price Details</h3>
                        <div class="infoBox">
                        <div class="ToAppendCouponApplied">
                            <p runat="server" id="divsub">Item Total <span class="toRight total"><span class="DiscountEleClass"><%=strSubTotal %></span><del runat="server" id="divDiscount" class="ActualEleClass"><%=strSubTotalWithDiscount %></del></span></p>
                            <p>Advance Amount <span class="toRight total"><span class="DiscountEleClass"><%=strAdv %></span></span></p>
                            <p>Balance Amount <span class="toRight total"><span class="DiscountEleClass"><%=strBal %></span></span></p>
                            <p runat="server" id="divship">Delivery Fee <span class="toRight DeliveryFee"><%=strShipping %></span></p>
                            <p runat="server" id="divCouponDis" class="RemoveOnCouponRemoved">Applied Offer <span class="toRight DeliveryFee"><%=strCoupnDiscount %></span></p>
                        </div>
                            <hr />
                        <div class="grandTotal">
                            <p runat="server" id="divgrand">Grand Total <span class="toRight"><span class="DiscountEleClass GrandTotalForCoupon"><%=strTotal %></span></span></p>
                        </div>
                            <br />
                        <div class="totalOffer">
                            <p class="text-success"><span class="DifferenceEleClass"><%=strTotalDiscount %></span> saved so far on this order!</p>
                        </div>
                        </div>
                        <div class="placeOrderBtn">
                            <form action="payment-status.aspx" method="post">
                                <input class="btn btn-animation" type="hidden" value="<%=Request.QueryString["order"]%>" name="orderIdd" />
                                <input class="btn btn-animation" type="hidden" value="<%=buyerAmount %>" name="buyerAmount" />
                                <script
                                    src="https://checkout.razorpay.com/v1/checkout.js"
                                    data-key="<%=ConfigurationManager.AppSettings["razorid"] %>"
                                    data-amount="<%=buyerAmount %>"
                                    data-name="ArchidPly Decor"
                                    data-description="ArchidPly Decor Order"
                                    data-order_id="<%=orderIdd%>"
                                    data-image="<%=ConfigurationManager.AppSettings["domain"]+"/assets/imgs/archidply-favicon.png" %>"
                                    data-prefill.name="<%=buyerName%>"
                                    data-prefill.email="<%=buyerEmail%>"
                                    data-prefill.contact="<%=BuyerMobile%>"
                                    data-theme.color="#2A007C"></script>
                                <input type="hidden" class="btn btn-animation" value="Hidden Element" id="btnSubmit1" name="hidden" />
                                <script>
                                    $(document).ready(function () {
                                        $(".razorpay-payment-button").click();
                                        $(".razorpay-payment-button").addClass("btn btn-primary btn-hover-dark rounded-pill mt-3");
                                    });
                                </script>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer bg-image">
        <div class="container container-xxl pt-4">
            <div class="row">
                <div class="col-lg-5 col-12 mb-13 mb-lg-0">
                    <div class="mb-6 footer-logo">
                        <img src="/assets/imgs/logo.png" width="300" alt="" />
                    </div>
                    <p class="lh-2 me-xl-24 mb-lg-8 mb-9">
                        Our products are crafted with care, ensuring that you receive only
                    the best materials for your projects.
               
                    </p>
                    <div class="social-icons">
                        <ul class="list-inline fs-5 mb-0">
                            <li class="list-inline-item me-8">
                                <a class="" href="#">
                                    <i class="fab fa-pinterest-p"></i>
                                </a>
                            </li>
                            <li class="list-inline-item me-8">
                                <a class="" href="#">
                                    <i class="fab fa-facebook-f"></i>
                                </a>
                            </li>
                            <li class="list-inline-item me-8">
                                <a class="" href="#">
                                    <i class="fab fa-instagram"></i>
                                </a>
                            </li>
                            <li class="list-inline-item">
                                <a class="" href="#">
                                    <i class="fab fa-twitter"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-lg col-md-4 col-12 mb-11 mb-md-8 mb-lg-0">
                    <h3 class="fs-5 mb-6">Company</h3>

                    <ul class="footer-contact-list">
                        <li>
                            <a href="#">
                                <i class="fa-solid fa-location-dot"></i>
                                <span>No.50, Millenium Towrs, Shivajinagar Bangalore —
                                560051
                            </span>
                            </a>
                        </li>
                        <li>
                            <a href="tel:+917022012573">
                                <i class="fa-solid fa-phone"></i>
                                <span><strong>+91 7022012573</strong></span>
                            </a>
                        </li>
                        <li>
                            <a href="mailto:bangalore@archidply.com">
                                <i class="fa-solid fa-envelope"></i>
                                <span>bangalore@archidply.com</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="col-lg col-md-4 col-12 mb-11 mb-lg-0">
                    <h3 class="fs-5 mb-6">Useful links</h3>

                    <ul class="list-unstyled mb-0 fw-medium">
                        <li class="pt-3 mb-4">
                            <a href="/about-us" title="New Products" class="">About Us</a>
                        </li>

                        <li class="pt-3 mb-4">
                            <a href="/blogs" title="Best Sellers" class="">Blogs</a>
                        </li>

                        <li class="pt-3 mb-4">
                            <a href="#" title="Bundle &amp; Save" class="">Return Policy</a>
                        </li>

                        <li class="pt-3 mb-4">
                            <a href="/privacy-policy" title="Online Gift Card" class="">Privacy policy</a>
                        </li>
                    </ul>
                </div>
                <div class="col-lg col-md-4 col-12 mb-11 mb-lg-0">
                    <h3 class="fs-5 mb-6">Categories</h3>

                    <ul class="list-unstyled mb-0 fw-medium">
                        <%=strFooterCat %>
                        <%--                    <li class="pt-3 mb-4">
                        <a href="#" title="New Products" class="">Plywood & Blockboard</a>
                    </li>

                    <li class="pt-3 mb-4">
                        <a href="#" title="Best Sellers" class="">Doors</a>
                    </li>

                    <li class="pt-3 mb-4">
                        <a href="#" title="Bundle &amp; Save" class="">Veneers</a>
                    </li>

                    <li class="pt-3 mb-4">
                        <a href="#" title="Online Gift Card" class="">MDF</a>
                    </li>--%>
                    </ul>
                </div>
                <!-- <div class="col-lg col-md-4 col-12 mb-11 mb-lg-0">
              <h3 class="fs-5 mb-6 text-white">Social Media</h3>
              <ul class="list-inline fs-5 mb-0">
                <li class="list-inline-item me-8">
                  <a class="text-light" href="#">
                    <i class="fab fa-pinterest-p"></i>
                  </a>
                </li>
                <li class="list-inline-item me-8">
                  <a class="text-light" href="#">
                    <i class="fab fa-facebook-f"></i>
                  </a>
                </li>
                <li class="list-inline-item me-8">
                  <a class="text-light" href="#">
                    <i class="fab fa-instagram"></i>
                  </a>
                </li>
                <li class="list-inline-item">
                  <a class="text-light" href="#">
                    <i class="fab fa-twitter"></i>
                  </a>
                </li>
              </ul>
            </div> -->
            </div>
            <div class="row mt-0 mt-lg-16 align-items-center">
                <div class="col-12 col-md-6 col-lg-4 mx-auto">
                    <p class="mb-0">
                        © ARCHIDPLY DECOR 2024 | Design By
                   
                        <a class="nweb-link"
                            href="https://www.nextwebi.com/"
                            target="_blank">Nextwebi</a>
                    </p>
                </div>
            </div>
        </div>
    </footer>
</body>

<script src="/assets/vendors/bootstrap/js/bootstrap.bundle.js"></script>
<script src="/assets/vendors/clipboard/clipboard.min.js"></script>
<script src="/assets/vendors/vanilla-lazyload/lazyload.min.js"></script>
<script src="/assets/vendors/waypoints/jquery.waypoints.min.js"></script>
<script src="/assets/vendors/lightgallery/lightgallery.min.js"></script>
<script src="/assets/vendors/lightgallery/plugins/zoom/lg-zoom.min.js"></script>
<script src="/assets/vendors/lightgallery/plugins/thumbnail/lg-thumbnail.min.js"></script>
<script src="/assets/vendors/lightgallery/plugins/video/lg-video.min.js"></script>
<script src="/assets/vendors/lightgallery/plugins/vimeoThumbnail/lg-vimeo-thumbnail.min.js"></script>
<script src="/assets/vendors/isotope/isotope.pkgd.min.js"></script>
<script src="/assets/vendors/slick/slick.min.js"></script>
<script src="/assets/vendors/gsap/gsap.min.js"></script>
<script src="/assets/vendors/gsap/ScrollToPlugin.min.js"></script>
<script src="/assets/vendors/gsap/ScrollTrigger.min.js"></script>
<script src="/assets/vendors/mapbox-gl/mapbox-gl.js"></script>
<script src="/assets/js/theme.min.js"></script>
<script src="/assets/js/script.js"></script>
<script src="/assets/js/Pages/user-master.js"></script>
<script src="/Admin/assets/plugins/notification/snackbar/snackbar.min.js"></script>
<script src="/Admin/assets/plugins/sweetalerts/custom-sweetalert.js"></script>
<script src="/Admin/assets/plugins/sweetalerts/sweetalert2.min.js"></script>
<script src="/Admin/assets/plugins/sweetalerts/sweetalert.js"></script>
