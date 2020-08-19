$(function () {
    cshdate();
    fromsize();
});

function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#dvlist").height(_h - 100);
}

function timestampToTime(time) {
    var date = new Date(parseInt(time.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var Hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}

function cshdate() {

    var startDate = addDate(new Date(), 0);
    var endDate = addDate(new Date(), 30);

    $('#txtStart').val(formatDate(startDate));
    $('#txtEnd').val(formatDate(endDate));
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


function getList() {
    $("#content1").empty();
    var parm = {
        sendCode: $.trim($("#txtsendcode").val()),
        chehao: $.trim($("#txtchehao").val()),
        startDate: $("#txtStart").val(),
        endDate: $("#txtEnd").val()
    };
    var content = ""
 
    $.ajax({
        url: "/api/ApiOrderGZ/GetStock",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                content += "<tr>";
                content += "<td><input id=\"cbkfyd\" type=\"checkbox\" value='" + item.C_DISPATCH_ID + "' />" + $.trim(item.C_DISPATCH_ID) + "</td>";
                content += "<td>" + $.trim(item.C_CKDH) + "</td>";
                content += "<td>" + $.trim(item.C_SEND_STOCK) + "</td>";
                content += "<td>" + $.trim(item.BIANHAO) + "</td>";
                content += "<td>" + $.trim(item.C_MAT_NAME) + "</td>";
                content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                content += "<td>" + $.trim(item.N_NUM) + "</td>";
                content += "<td>" + $.trim(item.N_JZ) + "</td>";
                content += "<td>" + $.trim(item.C_TICK_STR) + "</td>";
                content += "</tr>";
            });
            
            $("#content1").append(content);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function printFY(flag) {
    var result = false;
    var arrfyd = [];
    var arrckd = [];
    var fyd;
    var ckd;
    $(".table tbody tr").find("td:first input:checkbox").each(function () {
        var ischecked = $(this).prop("checked");
        if (ischecked) {
            fyd = $(this).val();
            ckd = $.trim($(this).parent().next().text());
            arrfyd.push(fyd);
            arrckd.push(ckd);
            result = true;
        }
    });
    if (result) {
       
        if (flag == 1) {
            for (var i = 0; i < arrfyd.length-1; i++) {

                if (arrfyd[i] != arrfyd[i + 1]) {
                    result = false;
                    break;
                }
            }
        }
        else {
            for (var j = 0; j < arrckd.length-1; j++) {
                if (arrckd[j] != arrckd[j + 1]) {
                    result = false;
                    break;
                }
            }
        }
        if (result) {
            var userid = $("#hiduserid").val();
            if (flag == 1) {
                window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_fyd.cpt&fyd=" + fyd + "&czr=" + userid, "_blank");
            }
            else {
                window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_ckqd.cpt&ckd=" + ckd +"&fyd=" + fyd, "_blank");
            }
        }
        else {
            alert("请选择相同的发运单或出库单")
        }
    }
    else {
        alert("请先选择需要项！");
    }
}