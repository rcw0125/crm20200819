$(function () {
    getProcType();

});


function addType() {

    if (procType == "") {
        alert("名称不能为空");
        return false;
    }
    var procType = $.trim($("#txtname").val());
    var isEdit = $.trim($("#hidedit").val());
    var status = $.trim($("#hidstatus").val());
    if (isEdit == "") {
        var parm = { procType: procType };
        $.ajax({
            url: "/api/ApiProc/AddProcType",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                var result = jQuery.parseJSON(data.Result);
                if (result) {
                    alert("保存成功");
                    $("#txtname").empty();
                    $("#hidedit").empty();
                    $("hidstatus").empty();
                    getProcType();
                }
                else {
                    alert("保存失败");
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else {
        var parm = {
            procType: procType,
            status: status,
            id: isEdit
        };
        $.ajax({
            url: "/api/ApiProc/UpdateProcType",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                var result = jQuery.parseJSON(data.Result);
                if (result) {
                    alert("保存成功");
                    $("#txtname").empty();
                    $("#hidedit").empty();
                    $("hidstatus").empty();
                    getProcType();
                }
                else {
                    alert("保存失败");
                    $("#txtname").empty();
                    $("#hidedit").empty();
                    $("hidstatus").empty();
                }
            },
            error: function (err) {
                alert(err);
            }
        });

    }
}

function getProcType() {

    $("#content1").empty();
    var parm = {};
    var content = "";

    $.ajax({
        url: "/api/ApiProc/GetProcType",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            data = jQuery.parseJSON(data.Result);
            $.each(data, function (i, item) {
                content += "<tr>";
                content += "<td>" + $.trim(item.C_NAME) + "</td>";
                content += " <td><a href=\"javascript:void(0);\" onclick=\"editProcType('" + item.C_ID + "','" + item.C_NAME + "','0');\" class='glyphicon glyphicon-pencil' style=' margin-right: 20px;'></a><a href=\"javascript:void(0);\" onclick=\"delProcType('" + item.C_ID + "','" + item.C_NAME + "','1');\" class='glyphicon glyphicon-remove'></a></td>";
                content += "</tr>";
            });
          
            $("#content1").append(content);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function editProcType(id, name, status) {
    $("#hidedit").val(id);
    $("#txtname").val(name);
    $("#hidstatus").val(status);
}

function delProcType(id, name, status) {


    if (confirm("确定要删除吗")) {
        var parm = {
            procType: name,
            status: status,
            id: id
        };
        $.ajax({
            url: "/api/ApiProc/UpdateProcType",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                var result = jQuery.parseJSON(data.Result);
                if (result) {
                    getProcType();
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
}