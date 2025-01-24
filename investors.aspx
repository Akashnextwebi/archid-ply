<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="investors.aspx.cs" Inherits="investors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="content" class="wrapper layout-page">
        <section class="position-relative custom-overlay" id="about_introduction">

            <div class="lazy-bg bg-overlay position-absolute z-index-1 w-100 h-100   light-mode-img" data-bg-src="assets/imgs/investor-banner.jpg">
            </div>
            <div class="lazy-bg bg-overlay dark-mode-img position-absolute z-index-1 w-100 h-100" data-bg-src="assets/imgs/investor-banner.jpg">
            </div>

            <div class="position-relative z-index-2 container py-18 py-lg-20">

                <h2 class="fs-56px mb-7 text-white text-center">Investors</h2>
            </div>
        </section>
        <section class="pt-lg-10 pb-lg-10 bg-investors">
            <!--<div class="container pt-lg-10 pb-lg-0 pb-15 pt-11 mb-lg-4">
            <div class="text-center py-5">
                <div class="container">
                    <div class="row justify-content-center">

                        <div class="col-xl-10">
                            <h2 class="mb-0">Investors</h2>
                            <p class=" ms-auto me-auto mt-7 mb-3 pb-2">
                It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

                      </p>


                        </div>
                    </div>
                </div>
            </div>

        </div>-->
            <div class="container ">
                <div class="row">
                    <div class="col-xl-3 col-lg-4 col-md-6">
                        <a href="/investor-contact">
                            <div class="bd-callout bd-callout-info">
                                Investor contact
                            </div>
                        </a>
                    </div>
                    <%=strInvestor %>
                    <%--   <div class="col-xl-3 col-lg-4 col-md-6">
                    <a href="annual-report.aspx">
                        <div class="bd-callout bd-callout-info">
                            Annual report
                        </div>
                    </a>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <a href="quartarly-results.aspx">
                        <div class="bd-callout bd-callout-info">
                            Quarterly results
                        </div>
                    </a>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <a href="investor-contact.aspx">
                        <div class="bd-callout bd-callout-info">
                            Investor contact
                        </div>
                    </a>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Corporate Governance
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Unpaid dividend
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Code of conduct
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Code of conduct for employees
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Whistle blower policy
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Corporate social responsibility policy
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Risk management policy
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Nomination &amp; remuneration policy
                    </div>
                </div>

                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Annual general meeting reports
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Appointment of directors
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        AGM 2015
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        AGM 2016
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Disclosure under clause 53
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Insider trading regulation
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Postal ballot 2017
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Board of directors
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Corporate announcements
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Familiarization programme for independent directors
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Party transcations policy
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Policy on determination
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        AGM 2017
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Committee
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Demerger
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        AGM-2020
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        EGM 2021
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        AGM-2021 & 2022
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Contact details
                    </div>
                </div>
                <div class="col-xl-3 col-lg-4 col-md-6">
                    <div class="bd-callout bd-callout-info">
                        Annual return 2021
                    </div>
                </div>--%>
                </div>
            </div>
        </section>











    </main>
</asp:Content>

