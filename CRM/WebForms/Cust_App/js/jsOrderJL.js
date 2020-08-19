$(function () {
    fromsize();
    cshdate();

});


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

function cshdate() {

    var  endDate = addDate(new Date(), 0);
    var startDate = addDate(new Date(), -30);

    $('#txtStart').val(formatDate(startDate));
    $('#txtEnd').val(formatDate(endDate));
}

function fromsize() {
    var _h = document.documentElement.clientHeight
    $(".orderList").height(_h - 50);
}

function GetOrder() {

    $("#content1").empty()
    var parm = {
        conNO: $.trim($("#txtconno").val()),
        startDate: $.trim($("#txtStart").val()),
        endDate: $.trim($("#txtEnd").val()
        )
    };
    var content = "";

    $.ajax({
        url: "/api/ApiOrderGZ/GetOrderZG",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            if (code == "1") {
                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {
                    content += "<tr>";
                    content += "<td>" + item.C_CON_NO + "</td>";
                    content += "<td>" + item.C_MAT_NAME + "</td>";
                    content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                    content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                    content += "<td>" + item.C_PACK + "</td>";
                    content += "<td>" + item.N_WGT + "</td>";
                    content += "<td>" + item.N_STATUS + "</td>";
                    content += "<td>" + $.trim(item.SCZT) + "</td>";
                    content += "<td><a href=\"javascript:void (0);\" onclick=\"geturl('" + item.C_ORDER_NO + "'); \"><span class=\"glyphicon glyphicon-search\" style=\"margin-right:10px;\"></span>" + $.trim(item.YLXNUM) + "</a></td>";

                    content += "</tr>";
                })

                $("#content1").append(content);
            }
           
            //fromsize();
        },
        error: function (err) {
            alert(err);
        }
    });
}

function geturl(id) {
    var url = 'con_GZ.html?key=' + id;
    _iframe(url, '720', '350', '发运跟踪');
}
