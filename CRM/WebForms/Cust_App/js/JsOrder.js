
$(document).ready(function () {

    var orderNo = $.trim($("#hidOrderNo").val());
    if (orderNo != '') {

        var parm = { c_no: orderNo };

        $.ajax({
            type: "Post",
            url: "OrderAdd.aspx/GetOrderInfo",
            data: JSON.stringify(parm),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                data = jQuery.parseJSON(data.d);
                $.each(data, function (i, item) {
                    $("#txtMatCode").val(item.C_MAT_CODE);
                    $("#txtMatName").val(item.C_MAT_NAME);
                    $("#txtStlGrd").val(item.C_STL_GRD);
                    $("#txtSpec").val(item.C_SPEC);
                    $("#selectTechProt").append("<option value='" + item.C_STD_ID + "'>" + item.C_TECH_PROT + "</option>");
                    $("#txtPack").val(item.C_PACK);
                    $("#txtUse").val(item.C_PRO_USE);
                    $("#dropUnit").find("option:contains('" + item.C_UNITIS + "')").attr("selected", true);
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
                });
            },
            error: function (err) {
                alert(err);
            }
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

        var parm={ C_STD_ID: STD_ID };

        $.ajax({
            type: "Post",
            url: "OrderAdd.aspx/GetUSES",
            data: JSON.stringify(parm),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                $("#txtUse").val(data.d);
            },
            error: function (err) {
                alert(err);
            }
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

        var parm = {
            stlgrd: stlgrd,
            spec: spec,
            stdcode: protNo,
            num: num
        };
        $.ajax({
            type: "Post",
            url: "OrderAdd.aspx/GetTime",
            data: JSON.stringify(parm),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                if (data.d != '') {
                    var time = data.d;
                    $("#txtDate").val(time);
                    $("#hidSysDate").val(time);
                }
            },
            error: function (err) {
                alert(err);
            }
        });

    });
});

function openWeb(index) {

    switch (index) {
        case 0:
            openPage2("../../Common/MatCode.aspx", "850", "350", "new2");
            break;
        case 1:
            openPage2("../../Common/CGAddr.aspx", "720", "350", "new2");
            break;
        case 2:
            openPage2("../../Common/OTCompany.aspx", "720", "350", "new2");
            break;
        case 3:
            openPage2("../../Common/Pack.aspx", "800", "350", "new2");
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

    var parm = { stl_grd: grd };

    if (grd != "") {

        $.ajax({
            type: "Post",
            url: "OrderAdd.aspx/GetCUST_TECH_PROT",
            data: JSON.stringify(parm),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                data = jQuery.parseJSON(data.d);
                $.each(data, function (i, item) {
                    $("#selectTechProt").append("<option value='" + item.C_STD_ID + "'>" + item.C_CUST_TECH_PROT + "</option>");
                    if (i == 0) {
                        $.ajax({
                            type: "Post",
                            url: "OrderAdd.aspx/GetUSES",
                            data: "{'C_STD_ID':'" + item.C_STD_ID + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                debugger;
                                $("#txtUse").val(data.d);
                            },
                            error: function (err) {
                                alert(err);
                            }
                        });
                    }
                });
            },
            error: function (err) {
                alert(err);
            }
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
    var orderNo = $.trim($("#hidOrderNo").val());
    var con_no = $.trim(window.opener.$("#txtConNO").val());
    var con_name = $.trim(window.opener.$("#txtConName").val());
    var currency_type = $.trim(window.opener.$("#dropCurrType option:selected").text());
    var area = $.trim(window.opener.$("#dropConArea option:selected").text());
    var matcode = $.trim($("#txtMatCode").val());
    var matname = $("#txtMatName").val();
    var stlgrd = $("#txtStlGrd").val();
    var spec = $("#txtSpec").val();
    var protNo = $.trim($("#selectTechProt option:selected").text());
    var c_std_code = $("#selectTechProt option:selected").val();
    var pack = $("#txtPack").val();
    var use = $("#txtUse").val();
    var unit = "吨";
    var num = $.trim($("#txtNum").val());
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
    var shipvia = window.opener.$("#dropShipVia option:selected").text();

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
        shipvia: shipvia
    };

    $.ajax({
        type: "Post",
        url: "OrderAdd.aspx/AddOrder",
        data: JSON.stringify(parm),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.d) {
                if (orderNo != '') {
                    alert("修改成功");
                    window.opener.document.getElementById("btnSearch").click();
                    window.close();
                    return false;
                }
                else {
                    //alert("添加成功");
                    window.opener.document.getElementById("btnSearch").click();
                    return false;
                }
            }
            else {
                alert("当前没有质量设计号，该钢种暂时无法使用！");
                return false;
            }
        },
        error: function (err) {
            alert(err);
        }
    });

}



