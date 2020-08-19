
$(function () {

    fromsize();

    //数量keyup 检测
    function wgtKeyup(obj) {
        $("body").on("keyup", obj, function () {

            var wgt = $(this).val();//重量
            $(this).val(wgt.replace(/[^0-9\.]/g, ""));//验证是否有效数字 
        });
    }

    wgtKeyup("input.wgt");//合同数量
});


function fromsize() {

    var _h = document.documentElement.clientHeight
    $("#flow1").height(_h - 120);
}

function checksave() {


    if (confirm("请认真核实钢种自由项、包装，没有问题点击确定！")) {
        _loading(1);
        return true;
    }
    return true;
}


function selectcheck(check) {
    var input = $(check).children(0).find("input");
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
            var url = 'MatMain3.aspx';
            _iframe(url, '900', '450', '产品');
            break;
    }
}

function openWeb2(ID) {
    var url = 'Pack.aspx?ID=' + ID;
    _iframe(url, '800', '350', '包装标准');
}

function openWeb3(ID) {

    var url = '../../Common/_CustList2.aspx?ID=' + ID;
    _iframe(url, '800', '350', '客户名称');
}
function openWeb4(ID) {

    var url = '../../Common/_CustList3.aspx?ID=' + ID;
    _iframe(url, '800', '350', '客户名称');
}


function SetPack(pack, id) {
    var txtPack = "#rptList_Add_txtPack_Code_" + id;
    $(txtPack).val(pack);
    close();
}

function SetCustName(name, index) {
    var txtcustName = "#rptList_Add_txtCustName_" + index;
    $(txtcustName).val(name);
    close();
}

function SetCustName_bxg(name, index) {
    var txtcustName = "#rptList_Add_txtBXGCustName_" + index;
    $(txtcustName).val(name);
    close();
}