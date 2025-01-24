<%@ Page Title="Order Placed Successfully | ARCHIDPLY DECORE" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Pay-Success.aspx.cs" Inherits="Pay_Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
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

        .paySuccessPage {
            margin: 30px 0;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="paySuccessPage">
        <section class="breadscrumb-section payNowPageSec cartSec pt-0">
            <div class="container-fluid-lg ">
                <div class="row">
                    <div class="col-12 mb-5">
                        <div class="breadscrumb-contain breadscrumb-order">
                            <div class="order-box">
                                <div class="order-image">
                                    <div class="checkmark">
                                        <div class="text-center">
                                            <img src="/images_/thank-you-tick.gif" img="img-fluid mb-3" style="width: 300px;" />
                                        </div>
                                    </div>
                                </div>
                                <div class="order-contain text-center">
                                    <h3 class="">Order Success</h3>
                                    <h5 class="text-content">Order Placed Successfully And Your Order Is On The Way</h5>
                                    <h6>Order ID: <%=strOrderId %></h6>
                                    <a href="<%=strInvoiceLink %>" target="_blank" class="btn btn-animation mt-3 mb-3 d-inline-block">View Invoice
                                    </a><br />
                                         <a href="/shop" title="Countinue Shopping"
    class="btn btn-outline-dark me-8 text-nowrap my-5">
     Countinue Shopping
 </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12">
                        <div class="allCartProduct">
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="AddressBox">
                                        <h3>
                                            <img src="images_/carting.png" width="50" height="50" />
                                            Address</h3>
                                        <div class="infoBox">
                                            <%=strBilling %>
                                            <%--                             <p><span class="left">Name : </span><span>Karthik S</span></p>
                                    <p><span class="left">Email Id : </span><span>Karthik@nextwebi.in</span></p>
                                    <p><span class="left">Mobile No : </span><span>8050490576</span></p>
                                    <p><span class="left">Address : </span><span>No 4,Sri Nidhi Nilaya,2nd cross,pipelineroad,Vijaynagar,Karnataka ,Bangalore 560023</span></p>
                                    <p><span class="left">City : </span><span>Bangalore</span></p>
                                    <p><span class="left">State : </span><span>Karnataka</span></p>
                                    <p><span class="left">GST Number : </span><span>sdfjgkhgijofnvkhfgj</span></p>
                                    <p><span class="left">Company Name : </span><span>Nextwebi</span></p>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <div class="payNowProductContainer">
                                        <h3><i class="mdi mdi-cart"></i>Ordered Items</h3>
                                        <%=strAllOrderItems %>
                                        <%--<div class="cartBox wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">
                                    <div class="row align-items-center">
                                        <div class="col-lg-3 col-md-3">
                                            <div class="ImgBox">
                                                <img src="/assets/img/productwb/1.webp" class="img-fluid" />
                                            </div>
                                        </div>
                                        <div class="col-lg-9 col-md-9 ">
                                            <div class="detailBox">
                                                <h3>Product Name</h3>
                                                <h5 class="price"><span class="theme-color">₹25,000</span> <del>₹30,000</del><span class="OfferApplied">10% off</span></h5>
                                                <h6 class="price">(1pc * 30 caps)</h6>
                                                <p class="amountSaved">You saved ₹50</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                    </div>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>
            </div>
        </section>


    </section>
</asp:Content>

