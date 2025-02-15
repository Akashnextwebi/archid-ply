﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view-invoice.aspx.cs" Inherits="Admin_view_invoice" %>

<!doctype html>
<html lang="en">

<head runat="server">

    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="assets/images/archidply-favicon.png">
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/plugins/fontawesome/css/fontawesome.min.css" rel="stylesheet" />
    <link href="assets/plugins/fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="assets/webfonts/gordita.css" rel="stylesheet" />
    <link href="assets/fonts/flaticon_leadsguru.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/custom.css" rel="stylesheet" />
    <link href="assets/css/custom-invoice.css" rel="stylesheet" />
    <title>ArchidPly | Invoice-001</title>
</head>
<body>

    <div class="main-wrapper">
        <div class="container">
            <div class="row justify-content-center">

                <div class="col-xl-9 col-md-8">
                    <div class="settings-widget profile-details mar-top-20">
                        <div class="settings-menu invoice-list-blk p-0 ">
                            <div class="card pro-post border-0 mb-0">
                                <div class="card-body">
                                    <div class="invoice-item">
                                        <div class="row" style="width: 100%;">
                                            <div class="col-md-6" style="width: 50%;">
                                                <div class="invoice-logo">
                                                    <img src="assets/images/logo-head.jpg" class="img-fluid  w__70-xs-en pad-t-b-5-xs" alt="Logo">
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="width: 50%;">
                                                <p class="invoice-details">
                                                    <strong>VEER HANUMAN ENTERPRISE.</strong><br />
                                                    S-28-29,<br />
                                                    2nd floor, orbit mall,<br />
                                                    Civil lines metro station,<br />
                                                    Jaipur, Rajasthan - 302006
                                                   
                                                    <br />
                                                    <strong>GSTIN:</strong> 08DYSPA5136G1ZA<br />
                                                    <strong>PAN:</strong> DYSPA5136G
                                                </p>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="invoice-item">
                                        <div class="row" style="width: 100%;">
                                            <div class="col-md-12">
                                                <div class="bg-light-gray-2 p-2 mb-3">
                                                    <span><strong>Invoice#:</strong> <%=strInvoiceNo %> </span>
                                                    <br />
                                                    <span><strong>Invoice Date:</strong> <%=strOrderDate %></span><br />
                                                    <span><strong>Status:</strong> <%=strPaymentStatus %></span>
                                                    <p runat="server" id="paymentId" visible="false">
                                                        <strong>Payment Id:
                                                        </strong>
                                                        <span><%=strPaymentId %></span>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="invoice-item">
                                        <div class="row" style="width: 100%;">
                                            <div class="col-md-6" style="width: 50%;">
                                                <div class="invoice-info">
                                                    <strong class="customer-text">Invoice From</strong>
                                                    <p class="invoice-details invoice-details-two">
                                                        VEER HANUMAN ENTERPRISE
                                                        <br>
                                                        S-28-29,<br />
                                                        2nd floor, orbit mall,<br />
                                                        Civil lines metro station,<br />
                                                        Jaipur, Rajasthan - 302006
                                                   
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="width: 50%;">
                                                <div class="invoice-info invoice-info2">
                                                    <strong class="customer-text">Invoice To</strong>
                                                    <p class="invoice-details">
                                                        <%=strName %>
                                                        <br>
                                                        <%=strAddressLine1 %><br>
                                                        <%=strAddressLine2 %>
                                                        <br>
                                                        <%=strAddressLine3 %>
                                                        <br />
                                                        <%=strAddressLine4 %>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="invoice-item invoice-table-wrap">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <table class="invoice-table table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th>Product</th>
                                                                <th>Amount</th>
                                                                <th class="text-center">Quantity</th>
                                                                <th class="text-end">Total</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%=strItems %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>


                                            <div class="col-md-6 col-xl-4 ms-auto">
                                                <div class="table-responsive">
                                                    <table class="invoice-table-two table table-borderless">
                                                        <tbody>
                                                            <tr runat="server" id="discountWrap" visible="false">
                                                                <th>Total Discount:</th>
                                                                <td><span><%=strDiscount %></span></td>
                                                            </tr>
                                                            <tr>
                                                                <th>Sub Total :</th>
                                                                <td><span><%=strSunTotalWithoutTax %></span></td>
                                                            </tr>
                                                            <tr>
                                                                <th>GST:</th>
                                                                <td><span><%=strTax %></span></td>
                                                            </tr>
                                                            <tr>
                                                                <th>Total Amount:</th>
                                                                <td><span><%=strFinalAmount %></span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="invoice-item">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="invoice-info d-print-none">
                                                    <p><strong>Declaration: We declare that this invoice shows the actual price of the goods/ services described and that all particulars are true and correct.</strong></p>
                                                    <p class="mt-4 text-center"><strong>This is a Computer Generated Invoice. No Signature Required.</strong></p>
                                                </div>
                                            </div>


                                            <div class="col-md-12 d-print-none">
                                                <div class="invoice-info text-center">
                                                    <a href="javascript:void(0)" class="new_btn yellow" onclick="window.print();return false;">
                                                        <span><i class="feather-printer me-2"></i>Download/Print</span>
                                                    </a>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <form id="form1" runat="server">
            <div>
            </div>
        </form>
    </div>

    <!-- Script section goes here -->
    <script src="assets/js/jquery-3.6.0.min.js"></script>
</body>
</html>
