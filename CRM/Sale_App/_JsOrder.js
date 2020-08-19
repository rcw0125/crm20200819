
$(document).ready(function () {

    var orderNo = $("#hidOrderNo").val();
    if (orderNo != '') {
        handelAjax('Con_OrderAdd.aspx/GetOrderInfo', 'Post', { c_no: orderNo }, function (data) {

            data = jQuery.parseJSON(data.d);
            $.each(data, function (i, item) {
                $("#txtMatCode").val(item.C_MAT_CODE);
                $("#txtMatName").val(item.C_MAT_NAME);
                $("#txtStlGrd").val(item.C_STL_GRD);
                $("#txtSpec").val(item.C_SPEC);
                $("#selectTechProt").append("<option value='" + item.C_STD_ID + "'>" + item.C_TECH_PROT + "</option>");
                $("#txtPack").val(item.C_PACK);
                $("#txtUse").val(item.C_PRO_USE);
              
                $("#txtNum").val(item.N_WGT);
                var dt = timestampToTime(item.D_DELIVERY_DT);
                $("#txtDate").val(dt);
                $("#txtAddress").val(item.C_CGC);
                $("#txtOTCompany").val(item.C_OTC);
                $("#hidOrderType").val(item.N_TYPE);
                $("#hiddia").val(item.N_DIA);
                $("#hidCustNO").val(item.C_CUST_NO);
                $("#hidCustName").val(item.C_CUST_NAME);
                $("#hidCustLEV").val(item.N_USER_LEV);
                $("#hidCustType").val(item.C_SALE_CHANNEL);
                $("#hidSysDate").val(timestampToTime(item.D_SYS_DELIVERY_DT));
                $("#dropLEV").find("option:contains('" + item.C_LEV + "')").attr("selected", true);
                $("#txtNeedDate").val(timestampToTime(item.D_NEED_DT));
            });

        });
    }

    function timestampToTime(time) {
        var date = new Date(parseInt(time.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var Hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        return date.getFullYear() + "-" + month + "-" + currentDate;

    }

    $("#selectTechProt").change(function () {

        var STD_ID = $(this).children('option:selected').val();
        handelAjax('Con_OrderAdd.aspx/GetUSES', 'Post', { C_STD_ID: STD_ID }, function (data) {

            $("#txtUse").val(data.d);

        });

    });


    $("#txtNum").change(function () {
        var matcode = $.trim($("#txtMatCode").val());
        var protNo = $.trim($("#selectTechProt option:selected").val());
        var num = $.trim($("#txtNum").val());
        var stlgrd = $("#txtStlGrd").val();
        var spec = $("#txtSpec").val();

        if (matcode == '') {
            alert("请先选择物料编码");
            return false;
        }
        if (protNo == '') {

            alert("请选择协议号");
            return false;
        }
        if (num <= 0) {
            alert("请输入有效数量")
            return false;
        }

        handelAjax('Con_OrderAdd.aspx/GetTime', 'Post', { stlgrd: stlgrd, spec: spec, stdcode: protNo, num: num }, function (data) {
            if (data.d != '') {
                var time = data.d;
                $("#txtDate").val(time);
                $("#hidSysDate").val(time);
            }
        });

    });
});

function openWeb(index) {

    switch (index) {
        case 0:
            openPage2("../Common/MatCode.aspx", "800", "350", "new2");
            break;
        case 1:
            openPage2("../Common/CGAddr.aspx", "720", "350", "new2");
            break;
        case 2:
            openPage2("../Common/OTCompany.aspx", "720", "350", "new2");
            break;
        case 3:
            openPage2("../Common/Pack.aspx", "800", "350", "new2");
            break;
    }
}


function SetMat(code, name, grd, spec, type, dia) {

    $("#selectTechProt").empty();
    $("#txtMatCode").val(code);
    $("#txtMatName").val(name);
    $("#txtStlGrd").val(grd);
    $("#txtSpec").val(spec);
    $("#hidOrderType").val(type);
    $("#hiddia").val(dia);

    if (grd != "") {

        handelAjax('Con_OrderAdd.aspx/GetCUST_TECH_PROT', 'Post', { stl_grd: grd }, function (data) {

            data = jQuery.parseJSON(data.d);
            $.each(data, function (i, item) {
                $("#selectTechProt").append("<option value='" + item.C_STD_ID + "'>" + item.C_CUST_TECH_PROT + "</option>");
                if (i == 0) {

                    handelAjax('Con_OrderAdd.aspx/GetUSES', 'Post', { C_STD_ID: item.C_STD_ID }, function (data) {

                        $("#txtUse").val(data.d);

                    });
                }
            });

        });

    }
}


function SetAddr(id, company) {

    $("#txtAddress").val(company);
    $("#hidAddrID").val(id);
}


function SetOT(id, company) {

    $("#txtOTCompany").val(company);
}


function SetPack(pack) {
    $("#txtPack").val(pack);
}


function SavaData() {

    var con_no = $("#hidconNo").val();
    var con_name = $("#hidConName").val();
    var currency_type = $("#hidCurrType").val();
    var area = $("#hidConArea").val();
    var matcode = $("#txtMatCode").val();
    var matname = $("#txtMatName").val();
    var stlgrd = $("#txtStlGrd").val();
    var spec = $("#txtSpec").val();
    var protNo = $("#selectTechProt option:selected").text();
    var c_std_code = $("#selectTechProt option:selected").val();
    var pack = $("#txtPack").val();
    var use = $("#txtUse").val();
    var unit = "吨";
    var num = $("#txtNum").val();
    var jhdate = $("#txtDate").val();
    var addrID = $("#hidAddrID").val();
    var kpdw = $("#txtOTCompany").val();
    var type = $("#hidOrderType").val();
    var dia = $("#hiddia").val();
    var custNo = $("#hidCustNO").val();
    var custName = $("#hidCustName").val();
    var custLEV = $("#hidCustLEV").val();
    var custType = $("#hidCustType").val();
    var sysDate = $("#hidSysDate").val();
    var shipvia = $("#hidShipVia").val();
    var lev = $("#dropLEV option:selected").text();
    var need_date = $("#txtNeedDate").val();
    var orderNo = $("#hidOrderNo").val();

    if (con_no == '') {
        alert("当前没有合同号，暂不能添加订单");
        window.close();
        return false;
    }
    if (matcode == '') {
        alert("请选择物料");
        return false;
    }
    if (protNo == '') {
        alert("请选择协议号");
        return false;
    }
    if (num == '' || num <= 0) {

        alert("请输入有效数量");
        return false;
    }

    var parm = {
        c_con_no: con_no,
        c_con_name: con_name,
        c_area: area,
        c_mat_code: matcode,
        c_mat_name: matname,
        c_tech_prot: protNo,
        c_spec: spec,
        c_stl_grd: stlgrd,
        c_unitis: unit,
        c_pro_use: use,
        d_delivery_dt: jhdate,
        n_wgt: num,
        addrid: addrID,
        c_otc: kpdw,
        n_currency_type: currency_type,
        c_std_code: c_std_code,
        n_type: type,
        n_dia: dia,
        c_pack: pack,
        orderNo: orderNo,
        custNo: custNo,
        custName: custName,
        custLEV: custLEV,
        custType: custType,
        sysDate: sysDate,
        shipvia: shipvia,
        lev: lev,
        need_date: need_date,
        orderNo: orderNo
    };

    handelAjax('Con_OrderAdd.aspx/AddOrder', 'Post', parm, function (data) {

        if (data.d) {
            if (orderNo != '') {
                alert("修改成功");
                window.opener.location.reload();
                window.close();
                return false;
            }
            else {
                alert("添加成功");
                window.opener.location.reload();
                return false;
            }

        }

    });

}


function handelAjax(url, method, parm, callback) {
    $.ajax({
        url: url,
        type: method,
        dataType: 'json',
        data: parm,
        success: function (data) {
            callback(data);
        },
        error: function (err) {
            alert(err);
        }
    })
}
