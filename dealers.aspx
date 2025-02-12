<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="dealers.aspx.cs" Inherits="dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    <style>
        #map { height: 100vh; width: 100%; background:#f1f1f1 }

        .custom-label {
            background: #007bff;
            color: white;
            padding: 5px 8px;
            border-radius: 5px;
            font-size: 12px;
            white-space: nowrap;
        }

        .form-select {
            background-color: #fff;
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
                            <div class="mx-auto">
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
        <%--for map start--%>
        <section class="container container-xxl">
            <div id="map"></div>
        </section>
        <script>
            var map = L.map('map', {
                center: [22.3511148, 78.6677428], // Center India
                zoom: 5,
                minZoom: 4,
                maxZoom: 10,
                zoomControl: true, // Enable zoom buttons
                scrollWheelZoom: true, // Enable scroll zoom
                doubleClickZoom: true, // Enable double-click zoom
                touchZoom: true, // Enable touch zoom
                dragging: true // Allow panning within India
            });

            // Restrict users to India's bounds
            var indiaBounds = [
                [6.746, 68.162],  // Southwest corner
                [35.674, 97.395]  // Northeast corner
            ];
            map.setMaxBounds(indiaBounds);
            map.on('drag', function () { map.panInsideBounds(indiaBounds, { animate: false }); });

            // Load India GeoJSON for state boundaries
            fetch("https://raw.githubusercontent.com/geohacker/india/master/state/india_telengana.geojson")
                .then(response => response.json())
                .then(data => {
                    L.geoJson(data, {
                        style: function (feature) {
                            return {
                                color: "#242020",  // Black outline
                                weight: 1,
                                fillColor: "#fff", // Orange fill for India
                                fillOpacity: 0.7
                            };
                        }
                    }).addTo(map);
                });

            // Define locations with markers
            var locations = [
                { state: "Jammu & Kashmir", lat: 32.7266, lon: 74.8570, cities: ["Jammu"] },
                { state: "Uttarakhand", lat: 30.3165, lon: 78.0322, cities: ["Dehradun"] },
                { state: "Punjab", lat: 30.9010, lon: 75.8573, cities: ["Mohali", "Ludhiana"] },
                { state: "Haryana", lat: 30.6942, lon: 76.8606, cities: ["Panchkula", "Faridabad"] },
                { state: "Delhi", lat: 28.7041, lon: 77.1025, cities: ["Delhi"] },
                { state: "Rajasthan", lat: 26.9124, lon: 75.7873, cities: ["Udaipur", "Jaipur"] },
                { state: "Assam", lat: 26.1445, lon: 91.7362, cities: ["Guwahati"] },
                { state: "Uttar Pradesh", lat: 26.8467, lon: 80.9462, cities: ["Lucknow", "Varanasi", "Kanpur", "Prayagraj"] },
                { state: "West Bengal", lat: 22.5726, lon: 88.3639, cities: ["Kolkata"] },
                { state: "Gujarat", lat: 23.0225, lon: 72.5714, cities: ["Ahmedabad", "Vadodara", "Surat"] },
                { state: "Madhya Pradesh", lat: 22.7196, lon: 75.8577, cities: ["Jabalpur", "Indore", "Ratlam", "Bhopal", "Gwalior"] },
                { state: "Maharashtra", lat: 19.0760, lon: 72.8777, cities: ["Pune", "Mumbai"] },
                { state: "Odisha", lat: 20.2961, lon: 85.8245, cities: ["Bhubaneswar", "Brahmapur", "Sonepur"] },
                { state: "Chhattisgarh", lat: 21.2514, lon: 81.6296, cities: ["Raipur", "Bilaspur", "Bhilai"] },
                { state: "Karnataka", lat: 12.9716, lon: 77.5946, cities: ["Bangalore", "Belgaum", "Mangalore", "Davangere", "Hubli", "Chikmagalur", "Mysore", "Bellary"] },
                { state: "Andhra Pradesh & Telangana", lat: 16.5062, lon: 80.6480, cities: ["Vijayawada", "Anantapur", "Guntur", "Rajahmundry", "Hyderabad", "Kakinada", "Nellore"] },
                { state: "Tamil Nadu & Puducherry", lat: 13.0827, lon: 80.2707, cities: ["Chennai", "Coimbatore", "Salem", "Pondicherry", "Tiruppur", "Namakkal", "Dharmapuri", "Krishnagiri"] }
            ];

            // Add markers to the map
            locations.forEach(location => {
                L.marker([location.lat, location.lon])
                    .addTo(map)
                    .bindPopup(`<b>${location.state}</b><br>${location.cities.join(", ")}`);
            });

    </script>
 <%--<script>
     var map = L.map('map', {
         center: [22.3511148, 78.6677428],
         zoom: 5,
         minZoom: 4,
         maxZoom: 10,
         maxBounds: [
             [6.746, 68.162],
             [35.674, 97.395]
         ],
         maxBoundsViscosity: 1.0
     });

     L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
         attribution: '&copy; OpenStreetMap contributors'
     }).addTo(map);

     // Load India GeoJSON for state boundaries
     fetch("https://raw.githubusercontent.com/geohacker/india/master/state/india_telengana.geojson")
         .then(response => response.json())
         .then(data => {
             L.geoJson(data, {
                 style: function (feature) {
                     return {
                         color: "#000",  // Black outline
                         weight: 1,
                         fillColor: "#f4a261", // Orange fill for India
                         fillOpacity: 0.5
                     };
                 }
             }).addTo(map);
         });

     var locations = [
         { state: "Jammu & Kashmir", lat: 32.7266, lon: 74.8570, cities: ["Jammu"] },
         { state: "Uttarakhand", lat: 30.3165, lon: 78.0322, cities: ["Dehradun"] },
         { state: "Punjab", lat: 30.9010, lon: 75.8573, cities: ["Mohali", "Ludhiana"] },
         { state: "Haryana", lat: 30.6942, lon: 76.8606, cities: ["Panchkula", "Faridabad"] },
         { state: "Delhi", lat: 28.7041, lon: 77.1025, cities: ["Delhi"] },
         { state: "Rajasthan", lat: 26.9124, lon: 75.7873, cities: ["Udaipur", "Jaipur"] },
         { state: "Assam", lat: 26.1445, lon: 91.7362, cities: ["Guwahati"] },
         { state: "Uttar Pradesh", lat: 26.8467, lon: 80.9462, cities: ["Lucknow", "Varanasi", "Kanpur", "Prayagraj"] },
         { state: "West Bengal", lat: 22.5726, lon: 88.3639, cities: ["Kolkata"] },
         { state: "Gujarat", lat: 23.0225, lon: 72.5714, cities: ["Ahmedabad", "Vadodara", "Surat"] },
         { state: "Madhya Pradesh", lat: 22.7196, lon: 75.8577, cities: ["Jabalpur", "Indore", "Ratlam", "Bhopal", "Gwalior"] },
         { state: "Maharashtra", lat: 19.0760, lon: 72.8777, cities: ["Pune", "Mumbai"] },
         { state: "Odisha", lat: 20.2961, lon: 85.8245, cities: ["Bhubaneswar", "Brahmapur", "Sonepur"] },
         { state: "Chhattisgarh", lat: 21.2514, lon: 81.6296, cities: ["Raipur", "Bilaspur", "Bhilai"] },
         { state: "Karnataka", lat: 12.9716, lon: 77.5946, cities: ["Bangalore", "Belgaum", "Mangalore", "Davangere", "Hubli", "Chikmagalur", "Mysore", "Bellary"] },
         { state: "Andhra Pradesh & Telangana", lat: 16.5062, lon: 80.6480, cities: ["Vijayawada", "Anantapur", "Guntur", "Rajahmundry", "Hyderabad", "Kakinada", "Nellore"] },
         { state: "Tamil Nadu & Puducherry", lat: 13.0827, lon: 80.2707, cities: ["Chennai", "Coimbatore", "Salem", "Pondicherry", "Tiruppur", "Namakkal", "Dharmapuri", "Krishnagiri"] }
     ];

     locations.forEach(location => {
         L.marker([location.lat, location.lon])
             .addTo(map)
             .bindPopup(`<b>${location.state}</b><br>${location.cities.join(", ")}`);
     });

    </script>--%>

        <%--end--%>



   <%--<script>
       var map = L.map('map').setView([22.9734, 78.6569], 5); // Centered in India

       L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
           maxZoom: 18,
           attribution: '© OpenStreetMap contributors'
       }).addTo(map);

       // Grouped cities by state
       var stateLocations = {
           "Jammu & Kashmir": [{ name: "Jammu", lat: 32.7266, lng: 74.8570 }],

           "Uttarakhand": [{ name: "Dehradun", lat: 30.3165, lng: 78.0322 }],

           "Punjab": [
               { name: "Mohali", lat: 30.7046, lng: 76.7179 },
               { name: "Ludhiana", lat: 30.9009, lng: 75.8573 }
           ],

           "Haryana": [
               { name: "Panchkula", lat: 30.6952, lng: 76.8537 },
               { name: "Faridabad", lat: 28.4089, lng: 77.3178 }
           ],

           "Delhi": [{ name: "Delhi", lat: 28.6139, lng: 77.2090 }],

           "Rajasthan": [
               { name: "Udaipur", lat: 24.5854, lng: 73.7125 },
               { name: "Jaipur", lat: 26.9124, lng: 75.7873 }
           ],

           "Assam": [{ name: "Guwahati", lat: 26.1445, lng: 91.7362 }],

           "Uttar Pradesh": [
               { name: "Lucknow", lat: 26.8467, lng: 80.9462 },
               { name: "Varanasi", lat: 25.3176, lng: 82.9739 },
               { name: "Kanpur", lat: 26.4499, lng: 80.3319 },
               { name: "Prayagraj", lat: 25.4358, lng: 81.8463 }
           ],

           "West Bengal": [{ name: "Kolkata", lat: 22.5726, lng: 88.3639 }],

           "Gujarat": [
               { name: "Ahmedabad", lat: 23.0225, lng: 72.5714 },
               { name: "Vadodara", lat: 22.3072, lng: 73.1812 },
               { name: "Surat", lat: 21.1702, lng: 72.8311 }
           ],

           "Madhya Pradesh": [
               { name: "Jabalpur", lat: 23.1815, lng: 79.9864 },
               { name: "Indore", lat: 22.7196, lng: 75.8577 },
               { name: "Ratlam", lat: 23.3303, lng: 75.0403 },
               { name: "Bhopal", lat: 23.2599, lng: 77.4126 },
               { name: "Gwalior", lat: 26.2183, lng: 78.1828 }
           ],

           "Maharashtra": [
               { name: "Pune", lat: 18.5204, lng: 73.8567 },
               { name: "Mumbai", lat: 19.0760, lng: 72.8777 }
           ],

           "Odisha": [
               { name: "Bhubaneswar", lat: 20.2961, lng: 85.8245 },
               { name: "Brahmapur", lat: 19.3149, lng: 84.7941 },
               { name: "Sonepur", lat: 20.8383, lng: 83.8963 }
           ],

           "Chhattisgarh": [
               { name: "Raipur", lat: 21.2514, lng: 81.6296 },
               { name: "Bilaspur", lat: 22.0796, lng: 82.1409 },
               { name: "Bhilai", lat: 21.1938, lng: 81.3509 }
           ],

           "Karnataka": [
               { name: "Bangalore", lat: 12.9716, lng: 77.5946 },
               { name: "Belgaum", lat: 15.8497, lng: 74.4977 },
               { name: "Mangalore", lat: 12.9141, lng: 74.8560 },
               { name: "Davangere", lat: 14.4644, lng: 75.9211 },
               { name: "Hubli", lat: 15.3647, lng: 75.1240 },
               { name: "Chikmagalur", lat: 13.3161, lng: 75.7726 },
               { name: "Mysore", lat: 12.2958, lng: 76.6394 },
               { name: "Bellary", lat: 15.1394, lng: 76.9214 }
           ],

           "Andhra Pradesh & Telangana": [
               { name: "Vijayawada", lat: 16.5062, lng: 80.6480 },
               { name: "Anantapur", lat: 14.6819, lng: 77.6006 },
               { name: "Guntur", lat: 16.3067, lng: 80.4365 },
               { name: "Rajahmundry", lat: 17.0005, lng: 81.8040 },
               { name: "Hyderabad", lat: 17.3850, lng: 78.4867 },
               { name: "Kakinada", lat: 16.9891, lng: 82.2475 },
               { name: "Nellore", lat: 14.4426, lng: 79.9865 }
           ],

           "Tamil Nadu & Puducherry": [
               { name: "Chennai", lat: 13.0827, lng: 80.2707 },
               { name: "Coimbatore", lat: 11.0168, lng: 76.9558 },
               { name: "Salem", lat: 11.6643, lng: 78.1460 },
               { name: "Pondicherry", lat: 11.9139, lng: 79.8145 },
               { name: "Tiruppur", lat: 11.1085, lng: 77.3411 },
               { name: "Namakkal", lat: 11.2213, lng: 78.1652 },
               { name: "Dharmapuri", lat: 12.1357, lng: 78.1554 },
               { name: "Krishnagiri", lat: 12.5170, lng: 78.2134 }
           ]
       };

       // Add markers for each state with multiple cities in popups
       for (var state in stateLocations) {
           var cities = stateLocations[state].map(city => city.name).join(", ");
           var firstCity = stateLocations[state][0]; // Choose first city for marker

           L.marker([firstCity.lat, firstCity.lng])
               .addTo(map)
               .bindPopup(`<b>${state}</b><br>${cities}`);
       }
    </script>--%>
    </main>
</asp:Content>

