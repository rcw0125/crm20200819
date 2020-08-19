function _print_qtck() {
    var empname = $("#hidempname").val();//签字人
    var arrfyd = [];
    $.each($('input:radio:checked'), function () {
        var ckd = $.trim($(this).parents("tr").find("input.ckd").val());//发运单      
        if (ckd != "") {
            arrfyd.push(ckd);
        }
    });

    if (arrfyd.length > 0) {
        window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=cpt_wwjg.cpt&ckd=" + arrfyd[0], "_blank");
    }
    else
    {
        alert("请选择打印项")
    }
}
