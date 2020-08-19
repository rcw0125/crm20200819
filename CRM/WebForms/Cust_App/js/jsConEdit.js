$(function () {


    txtSaleUser.onblur = function () {
        if (this.value != "") {
            var parm = {
                Name: $.trim($("#txtSaleUser").val())
            };
            $.ajax({
                url: "/api/ApiCon/SalesEmpPC",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(parm),
                success: function (data) {
                    code = jQuery.parseJSON(data.Code);
                    data = jQuery.parseJSON(data.Result);
                    if (code == "0") {
                        openWeb(4);
                    }
                    else {
                        $.each(data, function (i, item) {
                            $("#txtSaleUser").val(item.C_NAME);
                            $("#hidsaleempid").val(item.C_ID);
                            $("#hiddeptid").val(item.DEPTID);
                        })
                    }

                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    }

    fromsize();

    btn();

    $("#txtDate").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
        todayBtn: true,//显示今日按钮
        startDate: new Date()
    });

    $("#txtStart").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
        todayBtn: true,
        startDate: new Date()

    }).on("changeDate", function (ev) {
        $("#txtEnd").datetimepicker('setStartDate', $("#txtStart").val())
    });
    $("#txtEnd").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
        todayBtn: true,
        startDate: new Date()
    }).on("changeDate", function (ev) {
        $("#txtStart").datetimepicker('setEndDate', $("#txtEnd").val())
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

    //数量keyup 检测
    function wgtKeyup(obj) {
        $("body").on("keyup", obj, function () {
           
            var wgt = $(this).val();//重量
            $(this).val(wgt.replace(/[^0-9\.]/g, ""));//验证是否有效数字 
            var txtprice = $(this).parents("tr").find("input.price");//价格
            var txtsumprice = $(this).parents("tr").find("input.sumprice");//合计价格
            var price = txtprice.val() == "" ? "0" : txtprice.val();//价格
            var num1 = Number(wgt);
            var num2 = Number(price);
            var count = mulTip(num1, num2);
            txtsumprice.val(count);

            sum();//合计
        });
    }

    //价格keyup 检测
    function priceKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var price = $(this).val();//价格
            $(this).val(price.replace(/[^0-9\.]/g, ""));//验证是否有效数字 
            var txtwgt = $(this).parents("tr").find("input.wgt");//重量
            var txtsumprice = $(this).parents("tr").find("input.sumprice");//合计价格
            var wgt = txtwgt.val() == "" ? "0" : txtwgt.val();//重量
            var num1 = Number(wgt);
            var num2 = Number(price);
            var count = mulTip(num1, num2);
            txtsumprice.val(count);

            sum();//合计
        });
    }

    wgtKeyup("input.wgt");//合同数量
    priceKeyup("input.price");//合同价格

});

function sum() {//合计

    var j = 0;
    $(".wgt").each(function () {
        var n = $(this).val();
        j += Number(n);
    });
    $("#txtWgtSum").val(j.toFixed(2));
    var s = 0;
    $(".price").each(function () {
        var n = $(this).val();
        s += Number(n);
    });
    $("#txtPriceSum").val(s.toFixed(4));
}

function btn() {
    var status = $("#hidstatus").val();
    $("a").each(function () {
        if (status == "-1" || status == "") {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });

    $("input:text").each(function () {
        if (status == "-1" || status == "") {
            $(this).removeAttr("disabled");


        }
        else {
            $(this).attr("disabled", "disabled");
        }
    });

    $("#txtConNO").attr("disabled", "disabled");

    $("select").each(function () {
        if (status == "-1" || status == "") {

            $(this).removeAttr("disabled");
        }
        else {
            $(this).attr("disabled", "disabled")

        }
    });
}

function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#flow1").height(_h - 200);
}






function openWeb(index) {

    var strid = $("#hidC_CGID").val();
    var custno = $("#hidCustNO").val();
    switch (index) {
        case 1:
            _iframe('../../Common/_CustList.aspx?flag=1', '490', '350', '收货单位');
            break;
        case 2:
            _iframe('../../Common/_CustList.aspx?flag=2', '490', '350', '客户名称');
            break;
        case 3:
            _iframe('../../Common/_Site.aspx?flag=1', '490', '350', '站点');
            break;
        case 4:
            _iframe('../../Common/_Sales_Emp.aspx', '490', '350', '业务员');
            break;
        case 5:
            var url = '../../Common/CGAddr.aspx?ID=' + strid;
            _iframe(url, '490', '350', '收货地址');
            break;
        case 6:
            _iframe('OrderList.aspx', '800', '450', '历史签单');
            break;
        case 7:
            var url = 'MatList5.aspx?custno=' + custno;
            _iframe(url, '850', '500', '产品');
            break;
        case 8:
            var url = 'MatList6.aspx?custno=' + custno;
            _iframe(url, '850', '500', '副产品');
            break;
    }
}


function SetAddr(id, name) {

    $("#txtC_CGC").val(name);
    $("#hidC_CGID").val(id);
    close();
}

function SetAddr2(name) {

    $("#txtAddr").val(name);
    close();
}

function SetOT(id, company, code) {

    $("#txtCust").val(company);
    $("#txtCustName").val(company);
    $("#txtC_CGC").val(company);
    $("#hidC_CGID").val(id);
    $("#txtC_OTC").val(company);
    $("#hidC_OTCID").val(id);
    $("#hidCustNO").val(code);
    close();

}

function SetSite(siteName, siteID) {
    $("#txtC_STATION").val(siteName);
    close();
}

function openWeb2(ID) {

    var url = 'Pack.aspx?ID=' + ID;
    _iframe(url, '800', '350', '包装标准');

}

function SetPack(pack, id) {
    var txtPack = "#rptList_txtPack_Code_" + id;
    $(txtPack).val(pack);
    close();
}


function SetEmp(userName, saleEmpID, deptID) {

    $("#txtSaleUser").val(userName);
    $("#hidsaleempid").val(saleEmpID);
    $("#hiddeptid").val(deptID);
    close();
}
function checkInfo(n) {
    var ywy = $("#txtSaleUser");
    var zd = $("#dropShipVia");
    var zdnr = $("#txtC_STATION");

    var zc = $("#dropConPolicyArea");

    if ($.trim(ywy.val()) == "") {
        alert("请选择业务员");
        return false;
    }
    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    var rownum = $("#table1 tbody").find("tr").length;
    if (rownum == 0) {
        alert("请添加合同明细");
        return false;
    }

    var result = true;

    $('#table1 tbody tr').each(function () {
        var code = $(this).find("td").eq(0).html();
        var wgt = $(this).find("input.numJe");
        var price = $(this).find("input.price");
        if (wgt.val() == "" || wgt.val() == "0" || price.val() == "" || price.val() == "0") {
            var msg = "编码:" + $.trim(code) + ",请输入数量或单价大于0的数字"
            alert(msg);
            wgt.focus();
            result = false;
            return false;
        }
    });

    if (n == 0) {
        return result;
    }
    else {
        if (result) {
            return confirm("提交后将无法修改，确定提交吗?")
        }
    }
}

function checkInfo2() {
    var ywy = $("#txtSaleUser");
    var zd = $("#dropShipVia");
    var zdnr = $("#txtC_STATION");

    if ($.trim(ywy.val()) == "") {
        alert("请选择业务员");
        return false;
    }
    if (zd.val() == "0001NC10000000003ILQ" && $.trim(zdnr.val()) == "") {
        alert("请选择站点");
        return false;
    }

    var rownum = $("#table1 tbody").find("tr").length;
    if (rownum == 0) {
        alert("请添加合同明细");
        return false;
    }

    var sumwgt = $("#txtWgtSum").val();//新合同总数量
    var sfwgt = $("#hidsf").val();//允许上幅数量
    var xfwgt = $("#hidxf").val();//允许下幅数量
    var msg = $("#hidmsg").val();//提示

   

    var result = true;

    $('#table1 tbody tr').each(function () {
        var code = $(this).find("td").eq(0).html();
        var wgt = $(this).find("input.numJe");
        var price = $(this).find("input.price");
        if (wgt.val() == "" || wgt.val() == "0" || price.val() == "" || price.val() == "0") {
            var msg = "编码:" + $.trim(code) + ",请输入数量或单价大于0的数字"
            alert(msg);
            wgt.focus();
            result = false;
            return false;
        }
    });

    var num1 = Number(sfwgt); //允许上幅数量
    var num2 = Number(xfwgt); //允许下幅数量
    var num3 = Number(sumwgt);//新合同总数量

    if (num3 > num1) {
        alert(msg);
        return false;
    }
    return result;
}