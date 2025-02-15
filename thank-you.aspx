﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="thank-you.aspx.cs" Inherits="thank_you" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="error-area">
        <div class="container">
            <div class="row justify-content-center mt-10">
                <div class="col-lg-8">
                    <div class="error-wrap text-center">
                        <div class="error-img">
                            <img src="/images_/thankyou.png" alt="img" style="width: 600px;" class="injectable">
                        </div>
                        <div class="error-content mt-10">
                            <h2 class="title">Our team will reach out you soon!</h2>
                            <div class="tg-button-wrap mb-15 mt-12">
                                <a href="/" class="mt-3 btn green-btn shadow-sm mb-6">Go To Home Page<i class="fa-solid fa-arrow-circle-right"></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

