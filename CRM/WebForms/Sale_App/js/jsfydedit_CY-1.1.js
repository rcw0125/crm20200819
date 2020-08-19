$(function () {

    $("#txtfydt").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
        todayBtn: true,//显示今日按钮
        startDate: new Date()
    });

    btn();

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
    function priKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\.]/g, ""));//验证是否有效数字
            sum();//合计
        });
    };
    priKeyup("input.fyzs");
    priKeyup("input.jhfyl");

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

function btn() {

    var status = $("#hidstatus").val();
    $("a").each(function () {
        if (status != "0") {
            $(this).hide();
        }
        else {
            $(this).show();
        }
    });

    $(".selectck").each(function () {
        $(this).show();
    });

    $(".fyzs").each(function () {
        if (status != "0") {
            $(this).attr("disabled", "disabled")
        }
        else {
            $(this).removeAttr("disabled");
        }
    });
    $(".jhfyl").each(function () {
        if (status != "0") {
            $(this).attr("disabled", "disabled")
        }
        else {
            $(this).removeAttr("disabled");
        }
    });
}

function _print() {
    var fyd = $("#txtsendcode").val();
    //window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_fyd_cy.cpt&fyd=" + fyd, "_blank");
    window.open("http://192.168.2.93:8685/webroot/decision/view/report?viewlet=xgcap/cpt_fyd_cy.cpt&fyd=" + fyd, "_blank");
}

function del() {
    var result = true;
    $.each($('input:checkbox:checked'), function () {
        var flag = $(this).parents("tr").find("input.flag").val();
        var rowno = $.trim($(this).parents("tr").find("span.rowno").html());//行号
        if (flag == "Y") {
            alert("当前行号：" + rowno + "原始数据不可删除");
            result = false;
            return false;
        }
    });
    return result;
}

function save() {
    var zd = $("#dropfyfs");
    var zdnr = $("#txtdz");
    //火运
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
    var fyqua = $.trim($("#txtcount").val());//发运支数
    var fywgt = $("#txtsumwgt").val();//发运数量
    var yfyqua = $.trim($("#txtfyqua").val());//原发运支数

    if (Number(fyqua) != Number(yfyqua)) {

        alert("发运单发运支数总和不能改变");
        return false;
    }
    return true;
}


//导入NC
function importNC() {
    if (confirm('确定要导入NC吗？')) {
        _loading(1);
        return true;
    }
    return false;
}

//导入条码
function importRF() {
    if (confirm('确定要导入条码吗？')) {
        _loading(1);
        return true;
    }
    return false;
}

//导入物流
function importWL() {
    if (confirm('确定虚拟导入物流吗？')) {
        _loading(1);
        return true;
    }
    return false;
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
            _iframe('OrderList.aspx', '900', '450', '订单查询');
            break;
        case 3:
            var url = 'fyd_zc_sj.html?key=' + $.trim($("#txtsendcode").val());
            _iframe(url, '800', '350', '发运单装车实绩');
            break;
        case 4:

            var ckcode = "";
            var fydID = "";
            $('input[type=checkbox]:checked').each(function () {
                fydID = $.trim($(this).parent().parent().find("input.pkid").val());//发运单明细主键     
                ckcode = $.trim($(this).parent().parent().find("input.ckname").val());//仓库编码     

            });

            var url = '../Report/roll_prodcut_CKFYD.aspx?ck=' + ckcode + '&ID=' + fydID;
            _iframe(url, '900', '450', '当前库存');
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
            var url = '_ck.aspx?ID=' + ID;
            _iframe(url, '490', '350', '仓库');
            break;
    }
}

function openck(ID, fyID) {

    var url = '_ck.aspx?ID=' + ID + '&fyID=' + fyID;
    _iframe(url, '490', '350', '仓库');
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