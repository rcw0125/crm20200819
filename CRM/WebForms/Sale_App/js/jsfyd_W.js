
$(function () {

    $("#txtfydt").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
        todayBtn: true,//显示今日按钮
        startDate: new Date()
    });

    //浮点数乘法运算结果精确校正
    function mulTip(num1, num2) {
        var m = 0;
        var s1 = num1.toString();
        var s2 = num2.toString();
        var m1 = Number(s1.replace(/\./g, ""));
        var m2 = Number(s2.replace(/\./g, ""));
        if (s1.search(/\./) > -1) {
            m += s1.split(".")[1].length;
        };
        if (s2.search(/\./) > -1) {
            m += s2.split(".")[1].length;
        };
        var jeAll = m1 * m2 / Math.pow(10, m);
        //var jeAll = m1 * m2;
        return jeAll.toFixed(2);
    };

    //价格 keyup 检测
    function quaKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\.]/g, ""));

            var jhfyl = $(this).parents("tr").find("input.jhfyl");//计划发运量
            var num1 = Number(str);//发运支数
            if (num1 > 0) {
                var sumwgt = num1 * 2;
                jhfyl.val(sumwgt);

            }
            sum();//合计
        });
    };

    //价格 keyup 检测
    function wgtKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\.]/g, ""));

            sum();//合计
        });
    };

    quaKeyup("input.fyzs");
    wgtKeyup("input.jhfyl");

    function sum() {

        var j = 0;
        $(".fyzs").each(function () {
            var n = $(this).val();
            j += Number(n);
        });
        $("#txtcount").val(j.toFixed(2));
        var s = 0;
        $(".jhfyl").each(function () {
            var n = $(this).val();
            s += Number(n);
        });
        $("#txtsumwgt").val(s.toFixed(4));
    }
});
function save() {


    var zd = $("#dropfyfs");
    var zdnr = $("#txtdz");
    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    if (zd.val() != "0001NC10000000003ILQ" && $.trim($("#txtcph").val()) == "") {
        alert("请输入车牌号");
        return false;
    }



    var rownum = $("#table1 tbody").find("tr").length;
    if (rownum == 0) {
        alert("请添加发运明细");
        return false;
    }

    _loading(1);
    return true;

}

//车牌号验证方法

function isVehicleNumber(vehicleNumber) {

    var xreg = /^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}(([0-9]{5}[DF]$)|([DF][A-HJ-NP-Z0-9][0-9]{4}$))/;

    var creg = /^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-HJ-NP-Z0-9]{4}[A-HJ-NP-Z0-9挂学警港澳]{1}$/;

    if (vehicleNumber.length == 7) {

        return creg.test(vehicleNumber);

    } else if (vehicleNumber.length == 8) {

        return xreg.test(vehicleNumber);

    } else {

        return false;
    }
}

function selectcheck(check) {
    var input = $(check).children(0).find("input:checkbox");
    var ischecked = input.prop('checked');
    if (ischecked) {
        input.prop('checked', '');
    }
    else {
        input.prop('checked', 'checked');
    }
}

function openWeb(index) {
    switch (index) {
        case 1:
            _iframe('../../Common/_Site.aspx?flag=1', '490', '350', '站点');
            break;
        case 2:
            _iframe('OrderList.aspx', '1000', '450', '订单查询');
            break;
        case 3:
            var matcode = "";
            var stdcode = "";
            var area = "";
            var pack = "";
            var lev = "";
            var orderID = "";
            $('input[type=checkbox]:checked').each(function () {
                orderID = $(this).val();//订单ID
                matcode = $.trim($(this).parent().parent().find("input.matcode").val());//物料编码     
                stdcode = $.trim($(this).parent().parent().find("input.stdcode").val());//执行标准     
                area = $.trim($(this).parent().parent().find("input.area").val());//区域     
                pack = $.trim($(this).parent().parent().find("input.pack").val());//包装
                lev = $.trim($(this).parent().parent().find("select.lev option:selected").text());//质量等级
            });

            var url = '_ZTFYD.aspx?matcode=' + matcode + '&stdcode=' + stdcode + '&area=' + area + '&pack=' + pack + '&lev=' + lev + '&orderid=' + orderID;
            _iframe(url, '900', '450', '可发运量');
            break;
    }
}
function openWeb2(index, ID) {
    switch (index) {
        case 1:
            var url = 'Pack.aspx?ID=' + ID;
            _iframe(url, '800', '350', '包装标准');
            break;
        case 2:
            var url = 'custList.aspx?ID=' + ID;
            _iframe(url, '490', '350', '收货单位');
            break;
        case 3:
            var url = '../../Common/_Site.aspx?flag=0&ID=' + ID;
            _iframe(url, '490', '350', '到货地区');
            break;
        case 4:
            var url = '_ckSLAB.aspx?ID=' + ID;
            _iframe(url, '650', '350', '线材/钢坯仓库');
            break;
    }
}

function openstd(index, gz) {

    var url = '_StdCode.aspx?ID=' + index + "&gz=" + gz;
    _iframe(url, '800', '350', '执行标准');
}

function SetCK(id, name, index) {
    var txtckname = "#rptList_txtckname_" + index;
    var hidckid = "#rptList_hidckid_" + index;
    $(txtckname).val(name);
    $(hidckid).val(id);
    close();
}

function SetSite(siteName, siteID) {
    $("#txtdz").val(siteName);
    close();
}

function SetSHDW(id, name, index) {
    var txtC_CGC = "#rptList_txtC_CGC_" + index;
    var hidC_CGID = "#rptList_hidC_CGID_" + index;
    $(txtC_CGC).val(name);
    $(hidC_CGID).val(id);
    close();
}

function SetDWDQ(id, name, index) {
    var txtshdq = "#rptList_txtshdq_" + index;
    var hidshdq = "#rptList_hidshdq_" + index;
    $(txtshdq).val(name);
    $(hidshdq).val(id);
    close();
}

function SetPack(pack, id) {
    var txtPack = "#rptList_txtPack_Code_" + id;
    $(txtPack).val(pack);
    close();
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