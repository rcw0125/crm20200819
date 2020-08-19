
$(function () {
    fromsize();

    //全选
    selectAll("input.qx1", "input.che1");
});



function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#flow1").height(_h - 100);
}


function _eidt() {

    if (confirm("确定要调配该批次号区域资源吗")) {
        _loading(1);
        return true;
    }
    return false;
}
function _eidtCust() {


    if ($("#txtC_CGC").val() == "") {
        alert("请选择需求客户");
        return false;
    }

    if (confirm("确定要调配该批次号客户资源吗")) {
        _loading(1);
        return true;
    }
    return false;
}



function getapply() {
    var arr = [];
    $.each($('input:checkbox:checked'), function () {
        arr.push($(this).val());
    });
    if (arr.length > 0) {

        window.location.href = "roll_apply.aspx?batchno=" + arr.join(",");
    }
    else {
        window.location.href = "roll_apply.aspx";
    }
}

function openWeb2(batch, matcode, area, lev) {
    var url = 'roll_prodcut2_sub.aspx?batch=' + batch + "&matcode=" + matcode + "&area=" + area + "&lev=" + lev;
    _iframe(url, '1126', '606', '批次资源详细列表');
}