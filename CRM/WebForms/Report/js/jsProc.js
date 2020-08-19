$(function () {
    fromsize();
    getProcType();
});

function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#dvList").height(_h - 100);
}
function getProcType() {
    $("#selectproctype").empty();
    $("#selectproctype").append("<option>请选择</option>");
    var parm = {};
    $.ajax({
        url: "/api/ApiProc/GetProcType",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                $("#selectproctype").append("<option>" + item.C_NAME + "</option>");
            });
        },
        error: function (err) {
            alert(err);
        }
    });
}

function getProcList() {
    $("#content1").empty();
    var stlgrd = $.trim($("#txtstlgrd").val());
    var proctype = $("#selectproctype").val();
    var parm = {
        ProcType: proctype,
        StlGrd: stlgrd
    };

    var content = "";
    $.ajax({
        url: "/api/ApiProc/GetProc",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            data = jQuery.parseJSON(data.Result);
            if (code == "1") {
                $.each(data, function (i, item) {
                    content += " <tr>";
                    content += " <td>" + item.C_PROCTYPE + "</td>";
                    content += " <td>" + item.C_STLGRD + "</td>";
                    content += " <td>" + item.C_SPEC + "</td>";
                    content += " <td>" + item.C_STDCODE + "</td>";
                    content += " <td>" + item.C_DESC + "</td>";
                    content += " <td><a href=\"javascript:void(0);\" onclick=\"editProc('" + item.C_ID + "');\" class='glyphicon glyphicon-pencil' style=' margin-right: 20px;'></a><a href=\"javascript:void(0);\" onclick=\"delProc('" + item.C_ID + "');\" class='glyphicon glyphicon-remove'></a></td>";

                    content += " </tr>";
                });

                $("#content1").append(content);
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function editProc(id) {
    var url = 'ProcAdd.aspx?ID=' + id;
    _iframe(url,'600','450', '添加产品')
}

function delProc(id) {


    if (confirm("确定要删除吗")) {
        var parm = {
            id: id
        };
        $.ajax({
            url: "/api/ApiProc/DelProc",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                var result = jQuery.parseJSON(data.Result);
                if (result) {
                    getProcList();
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
}

