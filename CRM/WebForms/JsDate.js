$(function () {
    $("#Start").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true

    }).on("changeDate", function (ev) {
        $("#End").datetimepicker('setStartDate', $("#Start").val())
    });
    $("#End").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true
    }).on("changeDate", function (ev) {
        $("#Start").datetimepicker('setEndDate', $("#End").val())
        });

    $("#txtStart").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true

    }).on("changeDate", function (ev) {
        $("#txtEnd").datetimepicker('setStartDate', $("#txtStart").val())
    });
    $("#txtEnd").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true
    }).on("changeDate", function (ev) {
        $("#txtStart").datetimepicker('setEndDate', $("#txtEnd").val())
    });
});