
$(function () {
    getNotice();
    getwork();
    setInterval(getwork, 6000);
});

function geturl(id) {
    window.parent.addTabs({ id: '0', title: '公告详情', close: true, url: '/WebForms/Sale_App/NoticeView.aspx?ID=' + id + '' });
}

function geturl2(id, flag) {
    switch (flag) {
        case "0":
            window.parent.addTabs({ id: 'E8C1FBDEBF3A4299ADE43F6497207BAD', title: '待办文件', close: true, url: '/WebForms/Sale_App/Con_CheckList.aspx?ID=' + id + '&flag=0' });
            break;
        case "1":
            window.parent.addTabs({ id: 'E8C1FBDEBF3A4299ADE43F6497207BAD', title: '待办文件', close: true, url: '/WebForms/ZL/Quality_Check.aspx?ID=' + id + '&flag=0' });
            break;
        case "2":
            window.parent.addTabs({ id: 'E8C1FBDEBF3A4299ADE43F6497207BAD', title: '待办文件', close: true, url: '/WebForms/Roll/roll_applyCheck.aspx?ID=' + id + '&flag=0' });
            break;
    }

}

function strsplit(strdate) {

    var arr = strdate.split("T");
    return arr[0];
}

function getPG() {
    var parm = { };
    $.ajax({
        url: "/api/ApiMain/GetGPZZS",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
          
        },
        error: function (err) {
            //alert(err);
        }
    });
}

function getNotice() {

    $("#notice").empty();
    var content = "";
    var parm = { rowNum: 5 };
    $.ajax({
        url: "/api/ApiMain/GetNotice",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            if (code == "1") {
                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {
                    content += "<tr ondblclick=\"geturl('" + item.C_ID + "')\"  title='双击查看'>";
                    content += "<td>" + item.C_TITLE + "</td>";
                    content += "<td>" + item.C_EMP_NAME + "</td>";
                    content += "<td>" + strsplit($.trim(item.D_MOD_DT)) + "</td>";
                    content += "</tr>";
                })

                $("#notice").append(content);
            }
        },
        error: function (err) {
            //alert(err);
        }
    });
}

function getwork() {
    $("#work").empty();
    var content = "";
    var parm = { status: 0 };
    $.ajax({
        url: "/api/ApiMain/GetAffair",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parm),
        success: function (data) {
            var code = jQuery.parseJSON(data.Code);
            if (code == "1") {
                data = jQuery.parseJSON(data.Result);
                $.each(data, function (i, item) {
                    content += "<tr ondblclick=\"geturl2('" + item.C_ID + "','" + item.N_TYPE + "')\"  title='双击查看'>";
                    content += "<td>" + item.C_TITLE + "</td>";
                    content += "<td>" + item.C_EMP_ID + "</td>";
                    content += "<td>" + strsplit($.trim(item.D_SB_DT)) + "</td>";
                    content += "</tr>";
                })

                $("#work").append(content);
            }
        },
        error: function (err) {
            //alert(err);
        }
    });
}

