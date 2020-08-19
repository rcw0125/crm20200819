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

    //支数keyup 检测
    function quaKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\.]/g, ""));//验证是否有效数字            
            sum();//合计
        });
    };

    quaKeyup("input.fyzs");//发运支数
    quaKeyup("input.jhfyl");//发运量

    function sum() {//合计

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

    $("select").each(function () {
        if (status != "0") {
            $(this).attr("disabled", "disabled")

        }
        else {
            $(this).removeAttr("disabled");
        }
    });
    $(".pack").each(function () {
        if (status != "0") {
            $(this).attr("disabled", "disabled")
        }
        else {
            $(this).removeAttr("disabled");
        }
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
    window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_fyd_cy.cpt&fyd=" + fyd, "_blank");
}

//function _print() {
//    var fyd = $("#txtsendcode").val();
//    window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_fyd_xs.cpt&fyd=" + fyd, "_blank");
//}

function save() {//保存

    var zd = $("#dropfyfs");
    var zdnr = $("#txtdz");
    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    var sfbdj = $("#dropsfbdj").val();
    if (sfbdj == "0") {
        if (zd.val() != "0001NC10000000003ILQ" && $.trim($("#txtcph").val()) == "") {
            alert("请输入车牌号");
            return false;
        }
    }
    else {
        if ($.trim($("#txtxnch").val()) == "") {
            alert("请输入虚拟车号")
            return false;
        }
    }

    var rownum = $("#table1 tbody").find("tr").length;
    if (rownum == 0) {
        alert("请添加发运明细");
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
    if (confirm('确定要导入条吗？')) {
        _loading(1);
        return true;
    }
    return false;
}

//导入物流
function importWL() {
    if (confirm('确定要导入物流吗？')) {
        _loading(1);
        return true;
    }
    return false;
}

//虚拟导入物流
function importWL() {
    if (confirm('请确认首次是否导入物流系统，如已导入物流，方可操作虚拟导入物流系统！')) {
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


function openWeb(index) {
    switch (index) {
        case 1:
            _iframe('../../Common/_Site.aspx?flag=1', '490', '350', '站点');
            break;
        case 2:
            _iframe('OrderList.aspx', '900', '450', '订单查询');
            break;
        case 3:
            _iframe('OrderList2.aspx', '900', '450', '订单查询');//发运单编辑-订单查询
            break;
        case 4:
            var matcode = "";
            var stdcode = "";
            var area = "";
            var pack = "";
            var lev = "";

            $('input[type=checkbox]:checked').each(function () {
                matcode = $.trim($(this).parent().parent().find("input.matcode").val());//物料编码     
                stdcode = $.trim($(this).parent().parent().find("input.stdcode").val());//执行标准     
                area = $.trim($(this).parent().parent().find("input.area").val());//区域     
                pack = $.trim($(this).parent().parent().find("input.pack").val());//包装
                lev = $.trim($(this).parent().parent().find("select.lev option:selected").text());//质量等级
            });

            var url = '_ZTFYD.aspx?matcode=' + matcode + '&stdcode=' + stdcode + '&area=' + area + '&pack=' + pack + '&lev=' + lev;
            _iframe(url, '900', '450', '可发运量');
            break;
        case 5:
            var url = 'fyd_edit_ch.aspx?fyd=' + $("#txtsendcode").val();
            _iframe(url, '500', '500', '车牌号/日期更改');
            break;
        case 6:
            var url = 'fyd_edit_slabout.aspx?fyd=' + $("#txtsendcode").val();
            _iframe(url, '1050', '400', '钢坯销售出库');
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
        case 5:
            var url = '../Train/addrView.aspx?ID=' + ID;
            _iframe(url, '600', '400', '到货地点');
            break;
    }

}

function SetAddr(addrname, price, index) {
    var txtaddr = "#rptList_txtaddr_" + index;
    var txtprice = "#rptList_txtprice_" + index;
    $(txtaddr).val(addrname);
    $(txtprice).val(price);
    close();
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