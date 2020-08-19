$(function () {
    $(".table-hover tbody tr").dblclick(function () {
        var con = $.trim($(this).children(0).eq(0).html());
        var len = $(this).find("input.len").val();

        if (len == "0") {
            window.location.href = "ConEdit.aspx?ID=" + con;
        }
        else {
            window.location.href = "MyCon_Sub.aspx?ID=" + con;
        }

        //var parm = { conNO: con };
        //$.ajax({
        //    url: "/api/ApiCon/GetConNum",
        //    type: "POST",
        //    contentType: "application/json; charset=utf-8",
        //    data: JSON.stringify(parm),
        //    success: function (data) {

        //        var result = data.Code;
        //        if (result == "1") {
        //            window.location.href = "MyCon_Sub.aspx?ID=" + con;
        //        }
        //        else {
        //            window.location.href = "ConEdit.aspx?ID=" + con;
        //        }
        //    },
        //    error: function (err) {
        //        alert(err);
        //    }
        //});

    });
});