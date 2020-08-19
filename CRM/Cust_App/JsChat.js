
$(document).ready(function () {
    fromsize();
    getchat();

    setInterval(getchat, 3000);
})

function fromsize() {

    var _h = $(window).height();
    $("#_scroll").height(_h - 220);

}

function getchat() {

    var user = $("#hidUserID").val();

    var content = "";
    if (user != '') {

        handelAjax('Chat.aspx/GetChat', 'Post', { user: user }, function (data) {

            data = jQuery.parseJSON(data.d);
            if (data.length > 0) {
                $("#dv_content").empty();
                $.each(data, function (i, item) {

                    if (item.C_UID == user) {

                        content += '<p style="padding: 10px 0px 10px 0px; text-align:right">' + item.USERNAME + '&nbsp;&nbsp;' + timestampToTime(item.D_DT) + '</p>';
                        content += '<p style="text-align:right;"><code style="white-space: pre-wrap;font-size:14px; background: #eff3f6; color:black">' + item.C_CONTENT + '</code></p>';
                    }
                    else {

                        content += '<p style="padding: 10px 0px 10px 0px; text-align:left">' + item.USERNAME + '&nbsp;&nbsp;' + timestampToTime(item.D_DT) + '</p>';
                        content += '<p ><code style="white-space: pre-wrap;font-size:14px; background: #eff3f6; color:black">' + item.C_CONTENT + '</code></p>';
                    }
                });
            }
            $("#dv_content").append(content);

            $("#_scroll").scrollTop($("#_scroll")[0].scrollHeight);

        });
    }
}

function timestampToTime(time) {
    var date = new Date(parseInt(time.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var Hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    return currentDate + ":" + Hour + ":" + minutes;

}

function insert() {
    var content = $.trim($("#txtContent").val());

    var uid = $("#hidUserID").val();
    if (content != '') {

        handelAjax('Chat.aspx/SetChat', 'Post', { content: content, uid: uid }, function (data) {
            if (data.d) {
                $("#txtContent").val("");
                getchat();
            }

        });
    }
}


function handelAjax(url, method, parm, callback) {
    $.ajax({
        url: url,
        type: method,
        dataType: 'json',
        data: pram,
        success: function (data) {
            callback(data);
        },
        error: function (err) {
            alert(err);
        }
    })
}