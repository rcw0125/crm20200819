$(function () {
    fromsize();
});


function fromsize() {

    var _h = document.documentElement.clientHeight;
    var _w = document.documentElement.clientWidth;
    $("#flow1").height(_h - 170);
    $("#flow1").width(_w - 250);
    $("#td1").width(_w - 250);
    $("#content2").height(_h - 190);


}
function UpdateWWPrintStatus() {
    var pStatus = $("#ddlPrintStatus").val();
    if (pStatus == -1) {
        alert("请选择打印状态！");
        return;
    }
    var fyd = "";
    $('input[type=checkbox]:checked').each(function () {
        fyd += fyd == "" ? "" : ","
        fyd += $.trim($(this).parent().parent().find("input.fyd").val());//发运单

    });
    if (fyd != "") {
        var parm = {  fyd: fyd, printStatus: $("#ddlPrintStatus").val() };
        $.ajax({
            url: "/api/ApiOrderGZ/UpdateWWPrint",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                if (data.Code == "1") {
                    alert("更新打印成功");
                    $("#btncx").click();
                }
                else {
                    alert("更新打印失败");
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else {
        alert("请选择要修改状态的数据！");
    }
}
function UpdatePrintStatus() {
    var pStatus = $("#ddlPrintStatus").val();
    if (pStatus == -1) {
        alert("请选择打印状态！");
        return;
    }
    var ckd = "";
    var batch = "";
    var stove = "";
    var mb = "";
    $('input[type=checkbox]:checked').each(function () {
        if (ckd == "") {
            ckd = $.trim($(this).parent().parent().find("input.ckd").val()) ;//出库单      
        }
        else {
            ckd += "," + $.trim($(this).parent().parent().find("input.ckd").val());
        }
        if (batch == "") {
            batch = $.trim( $(this).parent().parent().find("input.batch").val());//批号
        }
        else {
            batch += "," + $.trim($(this).parent().parent().find("input.batch").val()); //批号
        }  
        if (stove == "") {
            stove = $.trim($(this).parent().parent().find("input.stove").val());//炉号
        }
        else {
            stove += "," + $.trim($(this).parent().parent().find("input.stove").val()); //炉号
        }

        mb = $("#dropmb").val(); //类型
    });
    if (ckd != "") {
        var parm = { batch: batch, chd: ckd, stove: stove, type: mb, printStatus: $("#ddlPrintStatus").val() };
        $.ajax({
            url: "/api/ApiOrderGZ/UpdatePrint",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(parm),
            success: function (data) {
                if (data.Code == "1") {
                    alert("更新打印成功");
                    $("#btncx").click();
                }
                else {
                    alert("更新打印失败");
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    else {
        alert("请选择要修改状态的数据！");
    }
}

function GetCFXN(batchNo, stlgrd, stdcode,stove) {
    var mb = $("#dropmb").val(); 
    $("#content2").empty();
    var parm = { batchNo: batchNo, stlgrd: stlgrd, stdcode: stdcode, stove: stove, type: mb };
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
                    content += " <td style='width:10px;'>" + (i + 1) + "</td>";
                    content += " <td style='width:140px;'>" + item.C_NAME + "</td>";
                    content += " <td style='width:100px;'>" + item.C_VALUE + "</td>";
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

function print_zcmx() {

    var arrfyd = [];
    var arrckd = [];
    var batch = "";
    var empname = $("#hidempname").val();//签证人
    $('input[type=checkbox]:checked').each(function () {

        var fyd = $.trim($(this).parent().parent().find("input.fyd").val());//发运单      
        var ckd = $.trim($(this).parent().parent().find("input.ckd").val());//出库单
        if (batch == "") {
            batch = $.trim($(this).parent().parent().find("input.batch").val());//出库单
        }
        if (fyd != "") {
            arrfyd.push(fyd);
        }
        if (ckd != "") {
            arrckd.push(ckd);
        }
    });

    var result = true;
    for (var i = 0; i < arrfyd.length - 1; i++) {
        if (arrfyd[i] != arrfyd[i + 1]) {
            result = false;
            break;
        }
    }
    if (result) {
        var parm = { fyd: arrfyd[0], empname: empname};   
        $.ajax({
            url: "/api/ApiOrderGZ/SaveCKDPrint",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(parm),
            success: function (data) {
                var code = JSON.parse(data.Code);
                var objData = JSON.parse(data.Result);
                var visTime = objData.D_visa_dt;              
                var visDate = getNowFormatDate(visTime);
                if (code == "1") {
                    if (batch == "" || batch.indexOf("4") == 0) {
                        window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_FYMX_GP.cpt&fyd=" + arrfyd[0] + "&ckd=" + arrckd[0] + "&emp=" + FR.cjkEncode(objData.C_attestor)
                            + "&qzrq=" + visDate, "_blank");
                    }
                    else {
                        window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_FYMX.cpt&fyd=" + arrfyd[0] + "&ckd=" + arrckd[0] + "&emp=" + FR.cjkEncode(objData.C_attestor)
                            + "&qzrq=" + visDate, "_blank");
                    }
                }
            },
            error: function (err) {
                alert(err);
            }
        });
     
    }
    else {
        alert("请选择相同发运单")
    }
}
function print_bxg_zcmx() {

    var arrfyd = [];
    var arrckd = [];
    var empname = $("#hidempname").val();//签证人
    $('input[type=checkbox]:checked').each(function () {

        var fyd = $.trim($(this).parent().parent().find("input.fyd").val());//发运单      
        var ckd = $.trim($(this).parent().parent().find("input.ckd").val());//出库单
        if (fyd != "") {
            arrfyd.push(fyd);
        }
        if (ckd != "") {
            arrckd.push(ckd);
        }
    });

    var result = true;
    for (var i = 0; i < arrfyd.length - 1; i++) {
        if (arrfyd[i] != arrfyd[i + 1]) {
            result = false;
            break;
        }
    }
    if (result) {
        var parm = { fyd: arrfyd[0], empname: empname };
        $.ajax({
            url: "/api/ApiOrderGZ/SaveCKDPrint",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(parm),
            success: function (data) {
                var code = JSON.parse(data.Code);
                var objData = JSON.parse(data.Result);
                var visTime = objData.D_visa_dt;
                var visDate = getNowFormatDate(visTime);
                if (code == "1") {
                    window.open("http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_BXGFYMX.cpt&fyd=" + arrfyd[0] + "&ckd=" + arrckd[0] + "&emp=" + FR.cjkEncode(objData.C_attestor)
                        + "&qzrq=" + visDate, "_blank");
                }
            },
            error: function (err) {
                alert(err);
            }
        });
       
    }
    else {
        alert("请选择相同发运单")
    }
}




function getNowFormatDate(currDate) {
    var date = new Date(currDate);
    var seperator1 = "/";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}

//质证书打印
function _print_zzs(flag) {
    var mb = $("#dropmb").val();//模板1套打，2轴承普通 3轴承特殊 4钢坯
    var remark = $.trim($("#txtremark").val());//备注
    var arrckd = [];
    var flaNo = "";;//车牌号 
    var stlgrd = "";//钢种;
    var stdcode = "";//执行标准
    var fyd = "";//发运单号
    var spec = "";//规格
    var arrbatch = [];//批号
    var arrstove = [];//炉号
    var empname = $("#hidempname").val();//签证人
    var result = true;
    $('input[type=checkbox]:checked').each(function () {
        var ckd = $.trim($(this).parent().parent().find("input.ckd").val());//出库单      
        var batch = $.trim($(this).parent().parent().find("input.batch").val());//批号

        var _flaNo = $.trim($(this).parent().parent().find("input.flaNo").val());//车牌号      
        var _stlgrd = $.trim($(this).parent().parent().find("input.stlgrd").val());//钢种
        var _stdcode = $.trim($(this).parent().parent().find("input.stdcode").val());//执行标准      
        var _fyd = $.trim($(this).parent().parent().find("input.fyd").val());//发运单号
        var _spec = $.trim($(this).parent().parent().find("input.spec").val());//规格

        var stove = $.trim($(this).parent().parent().find("input.stove").val());//炉号
        if (ckd != "" ) {           
            arrckd.push(ckd);            
        }
        if (batch != "") {
            arrbatch.push(batch);
        }
        if (stove != "") {
            arrstove.push(stove);
        }
        if (_flaNo != "" && _stlgrd != "" && _stdcode != "" && _fyd != "" && _spec!="")
        {
            if (flaNo == "") {
                flaNo = _flaNo;
                stlgrd = _stlgrd;
                stdcode = _stdcode;
                fyd = _fyd;
                spec = _spec;
            }
            else {
                if (flaNo != _flaNo || stlgrd != _stlgrd || stdcode != _stdcode || fyd != _fyd || spec != _spec) {
                    alert("请确认同钢种，同规格，同执行标准，同车号，同发运单号！");
                    result = false;
                    return;
                }
            }
        }
    });
    if (result) {
        var parm = { flaNo: flaNo, stlgrd: stlgrd, stdcode: stdcode, fyd: fyd, spec: spec, bz: remark, empname: empname, mb: mb, printType: flag };   
        var isPass = true;
        if (flag == 1) { //flag为1  普通质证书打印 2: 委外质证书打印  
            if (arrbatch.length > 0 || arrstove.length > 0) {               
                $.ajax({
                    url: "/api/ApiOrderGZ/CheckStdCodeRemark",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    data: JSON.stringify(parm),
                    success: function (d) {
                        var dd = JSON.parse(d.Result);
                        if (dd == 1 && remark=="") {
                            alert("请勾选备注信息！");
                            isPass = false;
                            return; 
                        }
                        if (isPass) {
                            var batch1 = arrbatch[0];
                            var batch2 = arrbatch.join(",");                            
                            $.ajax({
                                url: "/api/ApiOrderGZ/GetZZH",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                async: false,
                                data: JSON.stringify(parm),
                                success: function (data) {
                                    var code = JSON.parse(data.Code);
                                    if (code == "1") {
                                        var objData = JSON.parse(data.Result);
                                        var zsh = objData.C_certificate_no;
                                        var visTime = objData.D_visa_dt;
                                        var visPersion = objData.C_attestor;
                                        remark = objData.C_remark == null ? "":objData.C_remark;                                       
                                        var visDate = getNowFormatDate(visTime);
                                        switch (mb) {
                                            case "1"://线材
                                                var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_DY.cpt&BATCH=" + batch1 + "&BATCHS=" + batch2 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&BZ="
                                                    + FR.cjkEncode(remark.replaceAll("%", "%25")) + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate;
                                                window.open(url, "_blank");
                                                break;
                                            case "2": //特殊
                                                var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_THG.cpt&BATCH=" + batch1 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&CKD="
                                                    + fyd + "&ZSH=" + zsh + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate;
                                                window.open(url, "_blank");
                                                break;
                                            case "3": //认证
                                                var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_ZCG.cpt&BATCH=" + batch1 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&ZSH="
                                                    + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate;
                                                window.open(url, "_blank");
                                                break;
                                            case "4": //钢坯       
                                                var stove1 = arrstove[0];
                                                var stove2 = arrstove.join(",");
                                                var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=GPCFZZS_DY.cpt&BATCH=" + stove1 + "&BATCHS=" + stove2 + "&STD="
                                                    + stdcode + "&STLGRD=" + stlgrd + "&BZ=" + FR.cjkEncode(remark.replaceAll("%", "%25")) + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate; 
                                                window.open(url, "_blank");
                                                break;
                                            case "5": //空白                          
                                                var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=ZZS_ZCG.cpt&BATCH=" + batch1 + "&STD=" + stdcode + "&STLGRD="
                                                    + stlgrd + "&ZSH=" + zsh + "&CKD=" + fyd + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate;
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
                });
            }           

        }
        else {
            $.ajax({
                url: "/api/ApiOrderGZ/GetWWZZH",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: false,
                data: JSON.stringify(parm),
                success: function (data) {
                    var code = JSON.parse(data.Code);
                    var batch1 = arrbatch[0];
                    var batch2 = arrbatch.join(",");    
                    if (code == "1") {
                        var objData = JSON.parse(data.Result);
                        var zsh = objData.C_certificate_no;
                        var visTime = objData.D_visa_dt;
                        var visPersion = objData.C_attestor;
                        var visDate = getNowFormatDate(visTime);
                        var url = "http://192.168.2.96:8080/WebReport/ReportServer?reportlet=WY_ZZS_DY.cpt&BATCH=" + batch1 + "&BATCHS=" + batch2 + "&STD=" + stdcode + "&STLGRD=" + stlgrd + "&BZ="
                            + FR.cjkEncode(remark.replaceAll("%", "%25")) + "&ZSH=" + zsh + "&FYD=" + fyd + "&QZR=" + FR.cjkEncode(visPersion) + "&QZRQ=" + visDate;
                        window.open(url, "_blank");
                    }
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    }   
}