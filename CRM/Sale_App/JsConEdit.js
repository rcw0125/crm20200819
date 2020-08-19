$(document).ready(function () {

    fromsize();

    $('#myTab li:eq(0) a').tab('show');
    $('#myTab2 li:eq(0) a').tab('show');

})

function fromsize() {

    var _w = $("#form1").width();
    var _h = $(window).height();

    $("#td1").width(_w * 0.55);
    $("#td2").width(_w - (_w * 0.55) - 20);
    $("#iframe1").height(_h - 130);
    $("#iframe2").height(_h - 180);

}

function openWeb(index) {

    switch (index) {
        case 0:
            openPage2("../Common/_Dept.aspx", "600", "500", "new2");
            break;
        case 1:
            openPage2("../Common/_Dept_EMP.aspx", "600", "500", "new2");
            break;
    }
}

function SetDetp(name, id) {

    $("#txtDept").val(name);
    $("#hidDeptID").val(id);
}

function SetEmp(name, id) {

    $("#txtSaleUser").val(name);
    $("#hidEmpID").val(id);
}

function SaveCon() {

    var conNo = $("#txtConNO").val();
    var conName = $("#txtConName").val();
    var conType = $("#dropConType option:selected").val();
    var qdDT = $("#txtQianDanDT").val();
    var planStartDT = $("#txtPlanStartDT").val();
    var planEndDT = $().val();
    var fayun = $("#dropFaYun option:selected").val();
    var bizhong = $("#dropBiZhong option:selected").val();
    var yewu = $("#dropYeWuType option:selected").val();
    var deptID = $("#hidDeptID").val();
    var empID = $("#hidEmpID").val();
    var salezhuzhi = $("#dropSale option:selected").val();
    var conClass = $("#dropClass option:selected").val();
    var kucun = $("#txtKC").val();
    var shouhuodw = $("#txtShuoHuoCompany").val();
    var address = $("#txtShuoHuoAddr").val();

    var id = "aaa";
    var pwd = "bbbb";
    $.ajax({
        url: 'ConHandler.ashx?action=save',
        data: { id: id, pwd: pwd },
        success: function (data) {
            debugger;
            alert(data);
        }
    });
}



