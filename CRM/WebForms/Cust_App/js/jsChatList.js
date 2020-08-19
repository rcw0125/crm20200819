$(function () {
    getSaleEmp();
    getUserID();
    //fromsize();

    setInterval(getContent, 5000);

});

function fromsize() {

    var _h = $(window).height();
    $("#dv_content").height(_h - 220);

}

function getUserID() {

    $("#hiduserid").empty();
    var parm = {};
    $.ajax({
        url: "/api/ApiChat/GetUserID",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            $("#hiduserid").val(data.Result);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function getSaleEmp() {
    var parm = {};
    $(".list-group").empty();
    var content = "";
    $.ajax({
        url: "/api/ApiChat/GetSaleEmp",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            console.log(data.Result);
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                content += " <li class=\"list-group-item\" style=\"cursor: pointer\" onclick=\"setSaleEmp('" + item.C_ID + "','" + item.C_NAME + "')\">" + item.C_NAME + "</li>"
            })
            $(".list-group").append(content);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function setSaleEmp(empID, empName) {
    $(".saleEmp").empty();
    $(".saleEmp").append(empName);
    $("#hidsaleempid").val(empID);
    $("#dv_content").empty();
    getContent();
}

function getContent() {

    if ($.trim($("#hidsaleempid").val()) != '') {

        var userid = $("#hiduserid").val();
        var count = 10;
        var fristtime = formatDate(addDate(new Date(), 0));
        var lasttime = formatDate(addDate(new Date(), 1));
        var array = new Array();
        $("span[class='sptime']").each(function () {
            array.push($(this).text());
        });
        if (array.length > 0) {
            fristtime = array[0];
        }
        var parm = { fID: $("#hidsaleempid").val(), Count: count, LastDT: lasttime, FristDT: fristtime };
        $("#dv_content").empty();
        var content = '';
        $.ajax({
            url: "/api/ApiChat/GetChatPC",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {

                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {

                    if (item.C_UID != userid) {
                        content += "<p style=\"padding: 5px 0px 10px 0px; text-align:left\">" + item.USERNAME + "&nbsp;&nbsp; <span class=\"sptime\">" + strsplit(item.D_DT) + "</span> </p>";
                        content += " <p style=\"text-align:left;\"> <code style=\"white-space: pre-wrap;font-size:14px; background: #eff3f6; color:black\">" + item.C_CONTENT + "</code> </p>";
                    }
                    else {
                        content += "<p style=\"padding: 5px 0px 10px 0px; text-align:right\"> " + item.USERNAME + "&nbsp;&nbsp; <span class=\"sptime\">" + strsplit(item.D_DT) + "</span></p>";
                        content += "<p style=\"text-align:right;\"><code style=\"white-space: pre-wrap;font-size:14px; background: #eff3f6; color:black\">" + item.C_CONTENT + "</code> </p>";
                    }
                })
                $("#dv_content").append(content);
                $("#dv_content").scrollTop($("#dv_content")[0].scrollHeight);
            },
            error: function (err) {
                alert(err);
            }
        });
    }
}

function send() {

    if ($.trim($("#txtContent").val()) == "") {
        alert("请输入内容");
        return false;
    }

    var parm = {
        fID: $("#hidsaleempid").val(),
        content: $("#txtContent").val()
    };
    $.ajax({
        url: "/api/ApiChat/ChatAddPC",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            $("#txtContent").empty();
            getContent();

        },
        error: function (err) {
            alert(err);
        }
    });

}

function strsplit(strdate) {

    var arr = strdate.split("T");
    return arr[0] + " " + arr[1];
}


var formatDate = function (date) {
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = (date.getMonth() + 1);
    var day = date.getDate();

    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (day >= 0 && day <= 9) {
        day = "0" + day;
    }
    var currentdate = year + seperator1 + month + seperator1 + day;
    return currentdate;

};
var addDate = function (date, n) {
    date.setDate(date.getDate() + n);
    return date;
};
