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
                        alert("没有该业务员，请重新查询！");
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
});


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
            _iframe('../../Common/_CustList.aspx?flag=2', '490', '350', '二级客户');
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

    $("#hidCustID").val(id);
    $("#txtCustName").val(company);
    //$("#txtC_CGC").val(company);
    //$("#hidC_CGID").val(id);
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
    if ($.trim(zc.val()) == "") {
        alert("请选择合同政策区域");
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