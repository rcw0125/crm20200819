$(function () {
    var str = getQueryString("key");
    fyd(str);
});


function fyd(orderNo) {
    $("#fyd-content").empty();
    var parm = { orderNo: orderNo };
    var content = "";
    $.ajax({
        url: "/api/ApiOrderGZ/GetFYD",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            if (code == "1") {
                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {
                    content += "<tr style=\"cursor: pointer\" onclick=\"fydList('" + item.C_DISPATCH_ID + "','" + item.C_ORDER_TYPE + "');\"><td>" + item.C_DISPATCH_ID + "</td><td>" + item.C_DETAILNAME + "</td><td>" + item.C_LIC_PLA_NO + "</td><td>" + item.C_ATSTATION + "</td></tr>";
                })
                $("#fyd-content").append(content);
            }

        },
        error: function (err) {
            alert(err);
        }
    });
}

function fydList(sendCode, orderType) {

    $("#fydList-content").empty();
    var parm = { sendCode: sendCode, orderType: orderType };
    var content = "";
    $.ajax({
        url: "/api/ApiOrderGZ/GetFYDList",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            if (code == "1") {
                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {
                    content += "<tr><td>" + item.C_BATCH_NO + "</td><td>" + item.C_STOVE + "</td><td>" + item.MATNAME + "</td><td>" + item.JIANSHU + "</td><td>" + item.N_WGT + "</td></tr>";
                })
                $("#fydList-content").append(content);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}


function getQueryString(name) {
    var result = window.location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}