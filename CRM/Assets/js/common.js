/*************************************
//全选和取消全选
*************************************/
function selectAll(selectAllObj, selectedObj) {
    $("body").on("click", selectAllObj, function () {
        var _this = $(this)[0];
        var che2 = $(selectedObj);
        if (_this.checked == true) {
            che2.each(function () {
                if (!$(this).prop("disabled")) {
                    $(this)[0].checked = true;
                };
            });
        } else {
            che2.each(function () {
                if (!$(this).prop("disabled")) {
                    $(this)[0].checked = false;
                };
            });
        };
    });
};

//选择提示
function SelectMsg() {
    var num = false;
    var checkes = document.getElementsByTagName("input");
    for (var i = 0; i < checkes.length; i++) {

        if (checkes[i].type == "checkbox" && checkes[i].checked) {
            num = true;
        }
    }
    if (!num)//没选任何一项
    {
        alert("请先选择需要项！");
        return false;
    }
    else {
        return confirm("是否对选中项进行操作?");
    }
}

//删除提示
function delMsg() {
    var num = false;
    var checkes = document.getElementsByTagName("input");
    for (var i = 0; i < checkes.length; i++) {

        if (checkes[i].type == "checkbox" && checkes[i].checked) {
            num = true;
        }
    }
    if (!num)//没选任何一项
    {
        alert("请先选择需要删除的项！");
        return false;
    }
    else {
        return confirm("是否对选中项进行删除操作?");
    }
}



//弹出新页面//
function openPage(url, w, h) {
    var iWidth = w;
    var iHeight = h;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
    var win = window.open(url, "new", "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no,alwaysRaised=yes,depended=yes,alwaysLowered=yes");
}


//弹出新页面//
function openPage2(url, w, h, name) {
    var iWidth = w;
    var iHeight = h;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
    var win = window.open(url, name, "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no,alwaysRaised=yes,depended=yes,alwaysLowered=yes,channelmode=yes");
}


//上传输入框内容(电子表格)验证
function fileUpLoad(_this) {
    if (!$(_this).val().match(/^.+\.xlsx?$/)) {
        alert("请上传 Excel 文件！");
        $(_this).val("");
    };
};

//导入电子表格时验证
function drExcel(_this) {
    var inpFile = $(_this).parents("div.edit_1").find("input.fileInp");
    if (!inpFile.val().match(/^.+\.xlsx?$/)) {
        alert("请导入 Excel 文件！");
        inpFile.val("");
        return false;
    } else {
        return true;
    };
};

$(function () {

	/****************************************************
		计算用js  //alert(11*22.9);alert(200*2.3);
	*****************************************************/
    //判断数量是否合法
    function judgeNum(str) {
        var patt = /^\-?[1-9]+\d*$/;
        if (str != "" && !str.match(patt)) {
            alert("您输入的字符不正确！");
            return false;
        };
    };
    //判断价格是否合法
    function judgePri(str) {
        var patt = /^(([1-9]+\d*)|0)(\.\d*)?$/;
        if (str != "" && !str.match(patt)) {
            alert("您输入的字符不正确！");
            return false;
        };
    };

    //判断 金额是否合法
    function judgeNumJe(obj) {
        $("body").on("blur", obj, function () {
            $(this).val($.trim($(this).val()));
            var str = $(this).val();
            var patt = /^(([1-9]+\d*)|0)(\.\d*)?$/;
            if (str != "" && !str.match(patt)) {
                alert("您输入的字符不正确！");
                $(this).val("");
                return false;
            };
        });
    };
    judgeNumJe("input.numJe");
    judgeNumJe("input.numJe2");

    //判断 自然数 是否合法
    function judgeNumZrs(obj) {
        $("body").on("blur", obj, function () {
            $(this).val($.trim($(this).val()));
            var str = $(this).val();
            var patt = /^(([1-9]+\d*)|0)$/;
            if (str != "" && !str.match(patt)) {
                alert("您输入的字符不正确！");
                $(this).val("");
                return false;
            };
        });
    };
    judgeNumZrs("input.numZrs");


    //数量 keyup 检测
    function numKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\-]/g, ""));
        });
    };
    numKeyup("input.num");
    numKeyup("input.num3");

    //价格 keyup 检测
    function priKeyup(obj) {
        $("body").on("keyup", obj, function () {
            var str = $(this).val();
            $(this).val(str.replace(/[^0-9\.]/g, ""));
        });
    };
    priKeyup("input.price");
    priKeyup("input.price3");
    priKeyup("input.numJe"); //金额检测

    //浮点数乘法运算结果精确校正
    function mulTip(num1, num2) {
        var m = 0;
        var s1 = num1.toString();
        var s2 = num2.toString();
        var m1 = Number(s1.replace(/\./g, ""));
        var m2 = Number(s2.replace(/\./g, ""));
        if (s1.search(/\./) > -1) {
            m += s1.split(".")[1].length;
        };
        if (s2.search(/\./) > -1) {
            m += s2.split(".")[1].length;
        };
        var jeAll = m1 * m2 / Math.pow(10, m);
        //var jeAll = m1 * m2;
        return jeAll.toFixed(2);
    };

    //数量 blur 检测 1
    function priceBlur(numObj, priceObj, taxrateObj, amountObj, amount2Obj, amount3Obj, amount4Obj, fObj) {
        $("body").on("blur", priceObj, function () {
            $(this).val($.trim($(this).val()));//含税单价
            var val_0 = $(this).parents(fObj).find(numObj)//数量
            var val_2 = $(this).parents(fObj).find(taxrateObj);//税率

            var price = $(this).val();//含税单价
            var taxrate = $.trim(val_2.val());//税率
            var wgt = $.trim(val_0.val());//数量
            var Amount = $(this).parents(fObj).find(amountObj);//无税单价
            var Amount2 = $(this).parents(fObj).find(amount2Obj);//无税金额
            var Amount3 = $(this).parents(fObj).find(amount3Obj);//价税合计
            var Amount4 = $(this).parents(fObj).find(amount4Obj);//税额
            if (judgePri(price) == false) {
                $(this).val("");
                Amount.val("");
                Amount2.val("");
                Amount3.val("");
                Amount4.val("");

            } else if (price == "" || wgt == "") {
                Amount.val("");
                Amount2.val("");
                Amount3.val("");
                Amount4.val("");
            } else {

                var Num_2 = Number(taxrate) + 1;//税率
                var Num_3 = price / Num_2; //无税单价

                Amount.val(Num_3);//赋值：无税单价

                if (wgt != "") {

                    var s1 = mulTip(wgt, Num_3);//无税金额
                    var s2 = mulTip(wgt, price);//价税合计
                    var s3 = Number(s2) - Number(s1);//税额
                    var s4 = s3.toFixed(2);//税额小数保留两位
                    Amount2.val(s1);//无税金额
                    Amount3.val(s2)//价税合计
                    Amount4.val(s4);//税额

                    sum();//汇总
                }

            };
        });
    };


    function sum() {

        //无税金额汇总
        var j = 0;
        $(".amount2").each(function () {
            var n = $(this).val();
            j += Number(n);
        });
        $("#txtN_ORIGINALCURMNY").val(j.toFixed(2));

        //价税汇总
        var k = 0;
        $(".amount3").each(function () {
            var n = $(this).val();
            k += Number(n);
        });
        $("#txtN_ORIGINALCURSUMMNY").val(k.toFixed(2));

        //税额汇总
        var d = 0;
        $(".amount4").each(function () {
            var n = $(this).val();
            d += Number(n);
        });

        $("#txtN_ORIGINALCURTAXMNY").val(d.toFixed(2));

    }

    priceBlur("input.price3", "input.price", "input.taxrate", "input.amount", "input.amount2", "input.amount3", "input.amount4", "tr"); //数量,含税单价，税率,无税单价,无税金额，价税合计,税额，同一父元素	
    numBlur("input.price3", "input.price", "input.taxrate", "input.amount", "input.amount2", "input.amount3", "input.amount4", "tr"); //数量,含税单价，税率，无税单价,无税金额，价税合计,税额，同一父元素	

    //数量 blur 检测 1
    function numBlur(numObj, priceObj, taxrateObj, amountObj, amount2Obj, amount3Obj, amount4Obj, fObj) {
        $("body").on("blur", numObj, function () {

            $(this).val($.trim($(this).val()));
            var val_0 = $(this).val();//数量
            var val_1 = $(this).parents(fObj).find(priceObj);//含税单价
            var val_2 = $(this).parents(fObj).find(taxrateObj);//税率

            var wgt = $.trim(val_0);//数量
            var prie = $.trim(val_1.val()); //含税单价
            var taxrate = $.trim(val_2.val());//税率

            var Amount = $(this).parents(fObj).find(amountObj);//无税单价
            var Amount2 = $(this).parents(fObj).find(amount2Obj);//无税金额
            var Amount3 = $(this).parents(fObj).find(amount3Obj);//价税合计
            var Amount4 = $(this).parents(fObj).find(amount4Obj);//税额

            //数量汇总
            var i = 0;
            $(".price3").each(function () {
                var n = $(this).val();
                i += Number(n);
            });
            $("#txtWGT_SUM").val(i);


            if (judgePri(wgt) == false) {
                $(this).val("");
                Amount.val("");
                Amount2.val("");
                Amount3.val("");
                Amount4.val("");

            } else if (wgt == "") {
                Amount2.val("");
                Amount3.val("");
                Amount4.val("");
            } else if (prie == "") {
                Amount.val("");
                Amount2.val("");
                Amount3.val("");
                Amount4.val("");
            }
            else {

                var Num_2 = Number(taxrate) + 1;//税率
                var Num_3 = prie / Num_2; //无税单价
                Amount.val(Num_3);//赋值：无税单价
                var s1 = mulTip(wgt, Num_3);//无税金额
                var s2 = mulTip(wgt, prie);//价税合计
                var s3 = Number(s2) - Number(s1);//税额
                var s4 = s3.toFixed(2);//税额小数保留两位
                Amount2.val(s1);//无税金额
                Amount3.val(s2)//价税合计
                Amount4.val(s4);//税额

                sum();//汇总
            };


        });
    };

});



