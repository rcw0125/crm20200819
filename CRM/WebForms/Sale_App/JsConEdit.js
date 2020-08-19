
$(function () {

    fromsize();

    btn();

    //$("#txtQianDanDT").datetimepicker({
    //    format: 'yyyy-mm-dd',
    //    minView: 'month',
    //    language: 'zh-CN',
    //    autoclose: true,
    //    todayBtn: true,//显示今日按钮
    //    startDate: new Date()
    //});

    //$("#txtPlanStartDT").datetimepicker({
    //    format: 'yyyy-mm-dd',
    //    minView: 'month',
    //    language: 'zh-CN',
    //    autoclose: true,
    //    todayBtn: true,
    //    startDate: new Date()

    //}).on("changeDate", function (ev) {
    //    $("#txtPlanEndDT").datetimepicker('setStartDate', $("#txtPlanStartDT").val())
    //});
    //$("#txtPlanEndDT").datetimepicker({
    //    format: 'yyyy-mm-dd',
    //    minView: 'month',
    //    language: 'zh-CN',
    //    autoclose: true,
    //    todayBtn: true,
    //    startDate: new Date()
    //}).on("changeDate", function (ev) {
    //    $("#txtPlanStartDT").datetimepicker('setEndDate', $("#txtPlanEndDT").val())
    //});

    //$("#txtD_DELIVERY_DT").datetimepicker({
    //    format: 'yyyy-mm-dd',
    //    minView: 'month',
    //    language: 'zh-CN',
    //    autoclose: true,
    //    todayBtn: true,//显示今日按钮
    //    startDate: new Date()
    //});
});


function btn() {
    var status = $("#hidstatus").val();
    $("a").each(function () {
        if (status == "0") {

            $(this).show();
        }
        else {

            $(this).hide();
        }
    });

    $("a.flow").show();
    $("a.a_wgt").show();

    $("input:text").each(function () {
        if (status == "0") {
            $(this).removeAttr("disabled");
        }
        else {

            $(this).attr("disabled", "disabled")
        }
    });

    //设置税率是否只读
    //$("input.taxrate").each(function () {
    //    if (status == "0") {

    //        var lx = $("#dropYeWuType").val();
    //        if (lx == "1001NC10000000005EI8") {
    //            $(this).removeAttr("readOnly");
    //        }
    //        else {
    //            $(this).attr("readOnly", "true")
    //        }

    //    }
    //    else {

    //        $(this).attr("readOnly", "true")
    //    }
    //});


    //$("#txtConNO").attr("disabled", "disabled");

    $("select").each(function () {
        if (status == "0") {
            $(this).removeAttr("disabled");
        }
        else {
            $(this).attr("disabled", "disabled")
        }
    });
}

function fromsize() {

    var _h = document.documentElement.clientHeight
    $("#flow1").height(_h - 280);
}



function openWeb(index) {

    var con = $("#txtConNO").val();

    var remarkcon = con.substring(15);

    switch (index) {
        case 0:
            _iframe('../../Common/_Dept.aspx', '600', '500', '部门');
            break;
        case 1:
            _iframe('../../Common/_Dept_EMP.aspx', '600', '500', '业务员');
            break;
        case 2:
            _iframe('../../Common/_Site.aspx?flag=1', '490', '350', '站点');
            break;
        case 3:
            var url = 'MatList4.aspx?ID=' + con;
            _iframe(url, '900', '450', '产品');
            break;
        case 4:
            var url = '../../Common/_ConDoc.aspx?pk=' + con;
            _iframe(url, '500', '400', '文档');
            break;
        case 5:
           
          //  window.open("http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/con_001.cpt&conno=" + FR.cjkEncode(con), "_blank");

            window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=con_001.cpt&conno=" + FR.cjkEncode(con), "_blank");
            break;
        case 6:
            _iframe('_remark.html?key=' + encodeURI(remarkcon), '400', '100', '合同号备注');
            break;
        case 7:
            _iframe('../../Common/_CustList.aspx?flag=1', '490', '350', '收货单位');
            break;
        case 8:
            _iframe('../../Common/_CustList.aspx?flag=2', '490', '350', '开票单位');
            break;
        case 9:

            var orderID = "";
            $('input[type=checkbox]:checked').each(function () {

                orderID = $.trim($(this).val());
            });

            var url = '../Report/roll_prodcut_CKORDER.aspx?ID=' + orderID;
            _iframe(url, '900', '450', '当前库存');
            break;
        case 10://头尾材
            var url = 'MatList5.aspx?ID=' + con;
            _iframe(url, '900', '450', '头尾材');
            break;
    }
}

function openWeb2(ID) {
    var url = 'Pack.aspx?ID=' + ID;
    _iframe(url, '800', '350', '包装标准');
}
function openWeb3(area) {
    var url = '../../Common/_PlanWgt.aspx?area=' + area;
    _iframe(url, '600', '350', area);
}


function geturl() {
    var ID = "";
    $('input[type=checkbox]:checked').each(function () {
        ID = $.trim($(this).parent().parent().find("input.order").val());
    });

    var url = '../Report/KC_ORDER.aspx?ID=' + ID;
    _iframe(url, '500', '400', '库存订单');
}

function openstd(index, gz) {

    var url = '_StdCode.aspx?ID=' + index + "&gz=" + gz;
    _iframe(url, '800', '350', '执行标准');
}
function SetStdCode(stlcode, zyx1, zyx2, id) {
    var txtstdcode = "#rptList_txtStd_Code_" + id;
    var txtzyx1 = "#rptList_txtC_FREE1_" + id;
    var txtzyx2 = "#rptList_txtC_FREE2_" + id;
    $(txtstdcode).val(stlcode);
    $(txtzyx1).val(zyx1);
    $(txtzyx2).val(zyx2);
    close();
}


//收货单位
function SetAddr(id, name) {

    $("#txtShuoHuoCompany").val(name);
    $("#hidC_CGID").val(id);
    close();
}
//开票单位
function SetOT(id, company, code) {

    $("#txtKaiPiaoCompany").val(company);
    $("#hidC_OTCID").val(id);
    close();

}
//合同
function SetCon(str) {
    if ($.trim(str) == "") {
        $("#txtConNO").val($("#hidconno").val());
    }
    else {
        var con = $("#txtConNO").val();
        var remarkcon = con.substr(0,15);
        $("#txtConNO").val(remarkcon + str);
    }
    close();
}
//包装
function SetPack(pack, id) {
    var txtPack = "#rptList_txtPack_Code_" + id;
    $(txtPack).val(pack);
    close();
}

//部门
function SetDetp(name, id) {

    $("#txtDept").val(name);
    $("#hidC_DEPT_ID").val(id);
    close();
}
//业务员
function SetEmp(name, id) {

    $("#txtSaleUser").val(name);
    $("#hidC_SALESMAN").val(id);
    close();
}
//站点
function SetSite(siteName, siteID) {
    $("#txtC_STATION").val(siteName);
    close();
}

function checkInfo() {

    var zd = $("#dropFaYun");
    var zdnr = $("#txtC_STATION");
    if ($.trim($("#txtDept").val()) == "") {
        alert("请选择部门");
        return false;
    }
    if ($.trim($("#txtSaleUser").val()) == "") {
        alert("请选择业务员");
        return false;
    }

    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    if ($.trim($("#dropConType").val()) == "") {
        alert("合同类型不能为空！");
        return false;
    }
    if ($.trim($("#dropYeWuType").val()) == "") {
        alert("业务类型不能为空！");
        return false;
    }
    if ($.trim($("#txtKaiPiaoCompany").val()) == "") {
        alert("开票单位不能为空！");
        return false;
    }
    if ($.trim($("#dropSale").val()) == "") {
        alert("销售组织不能为空！");
        return false;
    }


    if ($.trim($("#hidycon").val()) != "") {
        var sumwgt = $("#txtWGT_SUM").val();//新合同总数量
        var sfwgt = $("#hidsf").val();//允许上幅数量
        var xfwgt = $("#hidxf").val();//允许下幅数量
        var msg = $("#hidmsg").val();//提示

        var num1 = Number(sfwgt); //允许上幅数量
        var num2 = Number(xfwgt); //允许下幅数量
        var num3 = Number(sumwgt);//新合同总数量

        if (num3 < num2 || num3 > sfwgt) {
            alert(msg);
            return false;
        }
        else {
            _loading(1);
            return true;
        }
    }
    else {
        _loading(1);
        return true;
    }
}

function checkInfo_bg() {

    var zd = $("#dropFaYun");
    var zdnr = $("#txtC_STATION");
    if ($.trim($("#txtDept").val()) == "") {
        alert("请选择部门");
        return false;
    }
    if ($.trim($("#txtSaleUser").val()) == "") {
        alert("请选择业务员");
        return false;
    }

    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    if ($.trim($("#dropConType").val()) == "") {
        alert("合同类型不能为空！");
        return false;
    }
    if ($.trim($("#dropYeWuType").val()) == "") {
        alert("业务类型不能为空！");
        return false;
    }
    if ($.trim($("#txtKaiPiaoCompany").val()) == "") {
        alert("开票单位不能为空！");
        return false;
    }
    if ($.trim($("#dropSale").val()) == "") {
        alert("销售组织不能为空！");
        return false;
    }

    var sumwgt = $("#txtWGT_SUM").val();//新合同总数量
    var sfwgt = $("#hidsf").val();//允许上幅数量
    var xfwgt = $("#hidxf").val();//允许下幅数量
    var msg = $("#hidmsg").val();//提示

    var num1 = Number(sfwgt); //允许上幅数量
    var num2 = Number(xfwgt); //允许下幅数量
    var num3 = Number(sumwgt);//新合同总数量

    if (num3 < num2 || num3 > sfwgt) {
        alert(msg);
        return false;
    }
    else {
        _loading(1);
        return true;
    }
}

function CheckMsg() {
    if (confirm("确定要操作吗")) {
        _loading(1);
        return true;
    }
    return false;
}

