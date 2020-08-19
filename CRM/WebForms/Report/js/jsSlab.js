$(function () {
    cshdate();
    getSlab();

});

function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#dv_slab").height(_h - 50);
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
    var endDate = addDate(new Date(), 60);

    $('#txtStart').val(formatDate(startDate));
    $('#txtEnd').val(formatDate(endDate));
}

/*日期初始化*/
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

function strsplit(strdate) {

    var arr = strdate.split("T");
    return arr[0];
}

/*------------------------------钢坯库查询-------------------------------------*/
function getSlab() {

    $("#content1").empty();
    var parm =
        {
            matCode: $.trim($("#txtmatcode").val()),
            stlGrd: $.trim($("#txtstlgrd").val()),
            spec: $.trim($("#txtspec").val()),
            startDate: $.trim($("#txtStart").val()),
            endDate: $.trim($("#txtEnd").val()),
            slabCK: $.trim($("#txtslabCK").val())
        };
    var content = '';
    $.ajax({
        url: "/api/ApiOrderGZ/GetSlab",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                content += "<tr>";
                content += "<td>" + item.C_SLABWH_CODE + "</td>";
                content += "<td>" + $.trim(item.C_BATCH_NO) + "</td>";
                content += "<td>" + item.C_STOVE + "</td>";
                content += "<td>" + item.C_MAT_CODE + "</td>";
                content += "<td>" + item.C_MAT_NAME + "</td>";
                content += "<td>" + item.C_STL_GRD + "</td>";
                content += "<td>" + item.C_SPEC + "</td>";
                content += "<td>" + item.N_LEN + "</td>";
                content += "<td>" + item.SUMWGT + "</td>";
                content += "<td>" + item.SUMQUA + "</td>";
                content += "<td>" + item.C_STD_CODE + "</td>";
                content += "<td>" + item.C_MAT_TYPE + "</td>";
                content += "<td>" + $.trim(item.C_STOCK_STATE) + "</td>";
                content += "<td>" + strsplit(item.D_WE_DATE) + "</td>";
                content += "</tr>";
            });
            $("#content1").append(content);
        },
        error: function (err) {//icon-glass
            alert(err);
        }
    });
}


/*----------------------end--------------------------*/



