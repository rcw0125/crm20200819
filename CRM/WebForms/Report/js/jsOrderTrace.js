$(function () {
    cshdate();
    fromsize();

});

function fromsize() {
    var _h = document.documentElement.clientHeight
    $(".orderList").height(_h - 300);
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

/*订单/计划/生产/出库跟踪*/
function getOrder() {

    $("#order").empty();
    var parm =
        {
            custName: $.trim($("#txtcustname").val()),
            saleEmp: $.trim($("#txtsaleemp").val()),
            conNO: $.trim($("#txtconno").val()),
            startDate: $.trim($("#txtStart").val()),
            endDate: $.trim($("#txtEnd").val())
        };
    var content ="";
   
    $.ajax({
        url: "/api/ApiOrderGZ/GetConTrace",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                content += "<tr ondblclick=\"GetRollSlab('" + item.C_ORDER_NO + "','" + item.N_TYPE + "');\" title='双击查看'>";
                content += "<td>" + $.trim(item.C_CON_NO) + "</td>";
                content += "<td>" + item.C_AREA + "</td>";
                content += "<td>" + item.C_MAT_NAME + "</td>";
                content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                content += "<td>" + $.trim(item.C_FREE1) + "</td>";
                content += "<td>" + $.trim(item.C_FREE2) + "</td>";
                content += "<td>" + item.C_PACK + "</td>";
                content += "<td>" + item.N_WGT + "</td>";
                content += "<td>" + $.trim(item.N_SMS_PROD_WGT) + "</td>";
                content += "<td>" + $.trim(item.N_ROLL_PROD_WGT) + "</td>";
                content += "<td>" + $.trim(item.SCWGT) + "</td>";
                content += "<td>" + GetCKWGT(item.C_MAT_CODE, item.C_ORDER_NO, item.N_TYPE) + "</td>";
                content += "<td>" + strsplit(item.D_DELIVERY_DT) + "</td>";
                content += "</tr>";
            });
            $("#order").append(content);

        },
        error: function (err) {
            alert(err);
        }
    });
}

/*--------------获取出库量------------------------------*/
function GetCKWGT(matCode, orderNo, flag) {

    var res = 0;
    var parm = {
        matCode: matCode,
        orderNo: orderNo,
        flag: flag
    };
    $.ajax({
        url: "/api/ApiOrderGZ/GetCKWGT",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            res= data.Result;           
        },
        error: function (err) {
            alert(err);
        }
    });
    return res;
}


function GetRollSlab(orderNO, flag) {
    $("#roll-slab").empty();
    var parm = {
        orderNo: orderNO,
        flag: flag
    };

    switch (flag) {
        case "8":
            var content = '';
          
            $.ajax({
                url: "/api/ApiOrderGZ/GetRollAndSlab",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(parm),
                success: function (data) {
                    data = jQuery.parseJSON(data.Result);
                    $.each(data, function (i, item) {
                        content += "<tr>";
                        content += "<td>" + item.C_BATCH_NO + "</td>";
                        content += "<td>" + item.item.C_STOVE + "</td>";
                        content += "<td>" + $.trim(item.C_CON_NO) + "</td>";
                        content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                        content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                        content += "<td>" + $.trim(item.JIANSHU) + "</td>";
                        content += "<td>" + $.trim(item.SUMWGT) + "</td>";
                        content += "<td>" + item.C_JUDGE_LEV_ZH + "</td>";
                        content += "<td>" + $.trim(item.C_STA_DESC) + "</td>";
                        content += "<td>" + $.trim(item.C_LINEWH_CODE) + "</td>";
                        content += "</tr>";
                    })
                  
                    $("#roll-slab").append(content);
                },
                error: function (err) {
                    alert(err);
                }
            });

            break;
        case "6":
            var content = '';
        
            $.ajax({
                url: "/api/ApiOrderGZ/GetRollAndSlab",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(parm),
                success: function (data) {
                    data = jQuery.parseJSON(data.Result);
                    $.each(data, function (i, item) {
                        content += "<tr>";
                        content += "<td>" + item.C_BATCH_NO + "</td>";
                        content += "<td>" + item.C_STOVE + "</td>";
                        content += "<td>" + $.trim(item.C_CON_NO) + "</td>";
                        content += "<td>" + $.trim(item.C_STL_GRD) + "</td>";
                        content += "<td>" + $.trim(item.C_SPEC) + "</td>";
                        content += "<td>" + $.trim(item.JIANSHU) + "</td>";
                        content += "<td>" + $.trim(item.SUMWGT) + "</td>";
                        content += "<td>" + item.C_JUDGE_LEV_ZH + "</td>";
                        content += "<td>" + $.trim(item.C_STA_DESC) + "</td>";
                        content += "<td>" + $.trim(item.C_SLABWH_CODE) + "</td>";
                        content += "</tr>";
                    })
                  
                    $("#roll-slab").append(content);

                },
                error: function (err) {
                    alert(err);
                }
            });

            break;
    }


}

/*----------------------end--------------------------*/



/*--------------添加火运计划查看记录------------------------------*/
function AddTrainLog() {

    var res = 0;
    var parm = {
    };
    $.ajax({
        url: "/api/ApiOrderGZ/InertTrainLog",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            res = data.Code;
            var url = "http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/cpt_train_day.cpt";
            window.open(url, "_blank");
        },
        error: function (err) {
            alert(err);
        }
    });
    return res;
}


