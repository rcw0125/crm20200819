﻿$(function () {
    var sendcode = getQueryString("key");
    getList(sendcode);
});

function getQueryString(name) {
    var result = window.location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}

function getList(sendcode) {

    var parm = {
        sendCode: sendcode
    };

    var content = "";
    $.ajax({
        url: "/api/ApiOrderGZ/GetFydTrace",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var rs = jQuery.parseJSON(data.Code);
            data = jQuery.parseJSON(data.Result);
            if (rs == '1') {
                $.each(data, function (i, item) {
                    content += "<tr>";
                    content += "<td>" + $.trim(item.C_DISPATCH_ID) + "</td>";
                    content += "<td>" + $.trim(item.C_CKDH) + "</td>";
                    content += "<td>" + $.trim(item.C_SEND_STOCK) + "</td>";
                    content += "<td>" + $.trim(item.C_BATCH_NO) + "</td>";
                    content += "<td>" + $.trim(item.C_MAT_NAME) + "</td>";
                    content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                    content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                    content += "<td>" + $.trim(item.N_NUM) + "</td>";
                    content += "<td>" + $.trim(item.N_JZ) + "</td>";
                    content += "<td>" + $.trim(item.C_TICK_STR) + "</td>";
                    content += "<td>" + strsplit($.trim(item.D_CKSJ)) + "</td>";
                    content += "</tr>";
                });
                $("#content1").append(content);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function strsplit(strdate) {

    var arr = strdate.split("T");
    return arr[0];
}