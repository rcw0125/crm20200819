$(function () {
    $(".table-hover tbody tr").dblclick(function () {
        var sendcode = $.trim($(this).children(0).eq(0).html());
        window.location.href = "fydEdit_W.aspx?ID=" + sendcode;
    });
});