
/**
 * 质证书打印
 */
$(function () {
    _getUserInfo();
    fromsize();

});
function fromsize() {
    var _h = document.documentElement.clientHeight
    $("#dvcfxn").height(_h - 180);
}

function _getUserInfo() {
    var parm = {};
    $.ajax({
        url: "/api/ApiOrderGZ/GetUserInfo",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = JSON.parse(data.Code);
            if (code == "1") {
                var name = JSON.parse(data.Result);
                $("#txtqzr").val(name);
            }
            else {
                window.location.href = "http://192.168.2.91:808/";
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function selectcheck(check) {
    var input = $(check).children(0).find("input:checkbox");
    var ischecked = input.prop('checked');
    if (ischecked) {
        input.prop('checked', '');
    }
    else {
        input.prop('checked', 'checked');
    }
}

function getInfo() {
    _loading(1);

    $("#selectmb").empty();
    var parm =
        {
            sendCode: $.trim($("#txtsendcode").val())
        };

    $.ajax({
        url: "/api/ApiOrderGZ/GetCQInfo",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = JSON.parse(data.Code);
            if (code == "1") {
                var jsonobj = JSON.parse(data.Result);
                $.each(jsonobj, function (i, item) {
                    $("#hidtype").val(item.C_EXTEND5);
                    switch (item.C_EXTEND5) {
                        case "6":
                            $("#selectmb").append("<option value='1'>钢坯</option>");//
                            break;
                        case "8":
                            $("#selectmb").append("<option value='4'>套打</option>");
                            $("#selectmb").append("<option value='2'>轴承普通</option>");
                            $("#selectmb").append("<option value='3'>轴承特殊</option>");
                           
                            break;
                    }

                });
                GetStlGrd();//加载钢种
            }
            else {
                $("#selectmb").append("<option value='4'>套打</option>");
                $("#selectmb").append("<option value='2'>轴承普通</option>");
                $("#selectmb").append("<option value='3'>轴承特殊</option>");
            }
        },
        error: function (err) {
            alert(err);
        }
    });

}

function GetStlGrd() {

    $("#selectstlgrd").empty();

    var parm = { sendCode: $.trim($("#txtsendcode").val()) };
    $.ajax({
        url: "/api/ApiOrderGZ/GetCQStlGrd",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = JSON.parse(data.Code);
            if (code == '1') {
                var jsonobj = JSON.parse(data.Result);
                $.each(jsonobj, function (i, item) {
                    $("#selectstlgrd").append("<option value='" + item.C_STL_GRD + "'>" + item.C_STL_GRD + "</option>");
                });
                GetStdCode();
            }
            else {
                $("#selectstlgrd").empty();
                $("#selectstdcode").empty();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function GetStdCode() {

    $("#selectstdcode").empty();
    var parm = { sendCode: $.trim($("#txtsendcode").val()), stlGrd: $("#selectstlgrd").val() };
    $.ajax({
        url: "/api/ApiOrderGZ/GetCQStdCode",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {

            var code = JSON.parse(data.Code);

            if (code == '1') {
                var jsonobj = JSON.parse(data.Result);
                $.each(jsonobj, function (i, item) {
                    $("#selectstdcode").append("<option value='" + item.C_STD_CODE + "'>" + item.C_STD_CODE + "</option>");
                });
                GetFydList();
            }
            else {
                $("#selectstdcode").empty();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function GetFydList() {

    $("#content1").empty();

    var parm = { sendCode: $("#txtsendcode").val(), flag: $("#hidtype").val(), stlGrd: $("#selectstlgrd").val(), stdCode: $("#selectstdcode").val() };

    var content = '';
    $.ajax({
        url: "/api/ApiOrderGZ/GetCQFyd",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {

            var code = JSON.parse(data.Code);
            if (code == "1") {
                var jsonobj = JSON.parse(data.Result);
                $.each(jsonobj, function (i, item) {
                    content += "<tr  onclick=\"GetCFXN('" + item.C_BATCH_NO + "' );\" title='双击查看' ondblclick=\"selectcheck(this);\" >";
                    content += " <td><input type=\"checkbox\" value=\"" + item.C_BATCH_NO + "\"><span class='ckd'>" + item.C_CKDH + "</span></td>";
                    content += " <td>" + item.C_DISPATCH_ID + "</td>";
                    content += " <td>" + item.C_BATCH_NO + "</td>";
                    content += " <td>" + item.N_NUM + "</td>";
                    content += " <td>" + item.N_JZ + "</td>";
                    content += " <td>" + item.C_STL_GRD + "</td>";
                    content += " <td>" + item.C_SPEC + "</td>";
                    content += " <td>" + item.C_STD_CODE + "</td>";
                    content += " <td>" + $.trim(item.C_ZLDJ) + "</td>";
                    content += "</tr>";
                    if (i == 0) {
                        GetCFXN(item.C_BATCH_NO);
                    }
                });

                $("#content1").append(content);
                close();
            }
            else {
                $("#content1").empty();
                close();
            }
        },
        error: function (err) {
            alert(err);
        }
    });
}

function GetCFXN(batchNo) {

    $("#content2").empty();
    var parm = { batchNo: batchNo };
    var content = '';
    $.ajax({
        url: "/api/ApiOrderGZ/GetCQCFXN",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {

            var code = JSON.parse(data.Code);
            if (code == "1") {
                var jsonobj = JSON.parse(data.Result);
                $.each(jsonobj, function (i, item) {
                    content += "<tr>";
                    content += " <td>" + item.C_NAME + "</td>";
                    content += " <td>" + item.C_VALUE + "</td>";
                    content += "</tr>";
                });

                $("#content2").append(content);
            }
            else {
                $("#content2").empty();
            }

        },
        error: function (err) {
            alert(err);
        }
    });

}

function _check() {
    var arr = [];
    $.each($('input:checkbox:checked'), function () {
        var ckd = $.trim($(this).parents("tr").find("span.ckd").html());
        arr.push(ckd);
    });
    var result = true;
    for (var i = 0; i < arr.length - 1; i++) {
        if (arr[i] != arr[i + 1]) {
            result = false;
            break;
        }
    }
    if (result) {
        _print(arr[0]);
    }
    else {
        alert("请选相同出库单打印");
        return false;
    }
}


function _print(ckd) {

    var fyd = ckd
    var mb = $("#selectmb").val();
    var batch1 = "";
    var batch2 = "";
    var arr = [];
    var stdcode = $("#selectstdcode").val();//执行标准
    var stlgrd = $("#selectstlgrd").val();//钢种
    var qzr = $("#txtqzr").val();//签证人
    var parm = {};
    $.each($('input:checkbox:checked'), function () {
        arr.push($(this).val());
    });
    if (arr.length > 0) {
        batch1 = arr[0];
        batch2 = arr.join(",");
        $.ajax({
            url: "/api/ApiOrderGZ/GetZZH",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                var code = JSON.parse(data.Code);
                if (code == "1") {
                    var zsh = JSON.parse(data.Result);
                    switch (mb) {
                        case "1": //钢坯                          
                            var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=GPCHZZS_YL.cpt&BATCH=" + batch1 + "&BATCHS=" + batch2 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&BZ=" + FR.cjkEncode($.trim($("#txtbz").val())) + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(qzr);
                            //window.location.href = "http://192.168.2.96:8080/WebReport/print.html?key=" + url;
                            window.open(url, "_blank");
                            break;
                        case "2"://轴承钢普通
                            var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_ZCG.cpt&BATCH=" + batch1 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(qzr);
                            window.open(url, "_blank");
                            break;
                        case "3"://轴承钢特殊
                            var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_ZCG.cpt&BATCH=" + batch1 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(qzr);
                            window.open(url, "_blank");

                            break;
                        case "4"://套打
                            var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_YL.cpt&BATCH=" + batch1 + "&BATCHS=" + batch2 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&BZ=" + FR.cjkEncode($.trim($("#txtbz").val())) + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(qzr);
                            //window.location.href = "http://192.168.2.96:8080/WebReport/print.html?key=" + url;
                            //var url2 = "http://192.168.2.96:8080/WebReport/print.html?key=" + url;
                            window.open(url, "_blank");
                            break;
                    }
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
}

function printdy() {
    window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_DY.cpt", "_blank");
}

function printyl() {
    window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_YL.cpt", "_blank");
}