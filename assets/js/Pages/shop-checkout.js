$(document).ready(function () {
    GetCartDetails();
});


function GetCartDetails() {
    $.ajax({
        type: "POST",
        url: "/WebService.asmx/GetUserCart",
        data: "{}",
        contentType: 'application/json; charset=utf-8',
        async: "false",
        success: function (res) {
            CartDetailBind(res.d);
        }
    });
};
function CartDetailBind(products) {
    $(".RemoveOnCouponRemoved").remove();
    var listings = "";
    var ProPrice = "";
    var ttSubtotal = 0, ttlGrandTotal = 0, ttlGrandDiff = 0, ttlDiscount = 0, ttlActual = 0, ttlDiff = 0;
    for (var i = 0; i < products.length; i++) {
        var url = "/shop-products/" + products[i].ProductUrl;
        var img = "/" + products[i].ProductImage;
        var pname = products[i].ProductName;
        var qty = parseFloat(products[i].Qty);
        var act = parseFloat(products[i].ActualPrice == "" ? products[i].DiscountPrice : products[i].ActualPrice);
        var disc = parseFloat(products[i].DiscountPrice);
        var diff = "";
        ttlDiscount = (disc * qty);
        ttlActual = (act * qty);
        ttSubtotal = parseFloat(ttSubtotal) + parseFloat(ttlDiscount);
        ttlGrandTotal = parseFloat(ttlGrandTotal) + parseFloat(ttlActual);
        ttlGrandDiff = parseFloat(ttlGrandTotal) - parseFloat(ttSubtotal);

        if (products[i].ActualPrice !== products[i].DiscountPrice) {
            ttlDiff = (act * qty) - (disc * qty);
            diff = parseFloat(act) - parseFloat(disc);
            var per = Math.floor(parseFloat(100) - (parseFloat(disc) / (parseFloat(act) / parseFloat(100))));
            ttlDiscount = parseFloat(ttlDiscount).toLocaleString('en-IN', {
                maximumFractionDigits: 2,
                style: 'currency',
                currency: 'INR'
            });
            ttlActual = ttlActual.toFixed(2);
            ttlActual = parseFloat(ttlActual).toLocaleString('en-IN', {
                maximumFractionDigits: 2,
                style: 'currency',
                currency: 'INR'
            });
            ttlDiff = ttlDiff.toFixed(2);
            ttlDiff = parseFloat(ttlDiff).toLocaleString('en-IN', {
                maximumFractionDigits: 2,
                style: 'currency',
                currency: 'INR'
            });
            ProPrice = "<span class='theme-color'>" + ttlDiscount + "</span> <del>" + ttlActual + "</del><span class='OfferApplied'>" + per + "% off</span>";
            diff = "<p class='amountSaved'>You saved " + ttlDiff + "</p>";

        } else {
            ProPrice = "<span class='theme-color'>" + ttlActual + "</span>";
        }

        ttlGrandDiff = ttlGrandDiff.toFixed(2);
        ttlGrandDiff = parseFloat(ttlGrandDiff).toLocaleString('en-IN', {
            maximumFractionDigits: 2,
            style: 'currency',
            currency: 'INR'
        });
        listings += "<div class='d-flex w-100 mb-7'>";
        listings += "<div class='me-6'>";
        listings += "<img src='" + img + "' class='lazy-image' width='60' alt='" + pname +"'>";
        listings += "</div>";
        listings += "<div class='d-flex flex-grow-1'>";
        listings += "<div class='pe-6'>";
        listings += "<a href='" + url + "' class=''>" + pname + "<span class='text-body'>  x  " + qty +" </span></a>";
        listings += "<p class='fs-14px text-body-emphasis mb-0 mt-1'>Size:<span class='text-body'>" + products[i].ProductSize + " x " + products[i].ProductThickness +"</span></p>";
        listings += "</div>";
        listings += "<div class='ms-auto'>";
        listings += "<p class='fs-14px text-body-emphasis mb-0 fw-bold'>" + ttlDiscount +"</p>";
        listings += "</div>";
        listings += "</div>";
        listings += "</div>";

    }
    if (products.length > 0) {
        ttlGrandTotal = ttlGrandTotal.toFixed(2);
        ttlGrandTotal = parseFloat(ttlGrandTotal).toLocaleString('en-IN', {
            maximumFractionDigits: 2,
            style: 'currency',
            currency: 'INR'
        });
        ttSubtotal = ttSubtotal.toFixed(2);
        ttSubtotal = parseFloat(ttSubtotal).toLocaleString('en-IN', {
            maximumFractionDigits: 2,
            style: 'currency',
            currency: 'INR'
        });
        $(".fullCartBag").css("display", "flex");
        $(".NoCartItemFound").css("display", "none");
        var bag = "<p>My Shopping Bag (" + products.length + " Items) <span>Total: <span class='TotalPrice''>" + ttSubtotal + "</span></span></p>";
        $(".TotalPrice").empty();
        $(".TotalPrice").append(ttSubtotal);
        /*$(".Shipping").empty();
        $(".Shipping").append(50);*/
        $(".BagDetails").empty();
        $(".BagDetails").append(bag);
        $(".Summery").empty();
        $(".Summery").append(listings);
        $(".DiscountEleClass").empty();
        $(".DiscountEleClass").text(ttSubtotal);
        $(".ActualEleClass").empty();
        $(".ActualEleClass").text(ttlGrandTotal);
        $(".DifferenceEleClass").empty();
        $(".DifferenceEleClass").text(ttlGrandDiff);
        // ApplyCoupon();
    }
    else {
        $(".fullCartBag").css("display", "none");
        $(".NoCartItemFound").css("display", "flex");
        var noItem = "";
        noItem += "<h1>No cart Found</h1>";
        $(".NoCartItemFound").append(noItem);
    }
}