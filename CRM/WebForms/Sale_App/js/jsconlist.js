$(function () {
    $(".table-hover tbody tr").dblclick(function () {
        var con = $.trim($(this).children(0).eq(0).html());
        var status = $(this).find("input.status").val();//合同状态
        var oldcon = $(this).find("input.oldcon").val();//原合同号
        if ($.trim(oldcon) != "" && status == "0") {
            window.location.href = "ConEdit_BG.aspx?ID=" + con + "&YID=" + oldcon;
        }
        else {
            window.location.href = "ConEdit.aspx?ID=" + con;
        }
    });
});