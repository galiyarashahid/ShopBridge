function filldetail(routeId) {
    $.ajax({
        url: "/api/item/" + routeId,
        method: "GET",
        success: function (data) {
            $("#lblname").text(data.name);
            $("#lblprice").text(data.price);
            $("#lbldesc").text(data.desc);
        }
    });
}