$(function () {
    $("#Start").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,

    }).on("changeDate", function (ev) {
        $("#End").datetimepicker('setStartDate', $("#Start").val())
    });
    $("#End").datetimepicker({
        format: 'yyyy-mm-dd',
        minView: 'month',
        language: 'zh-CN',
        autoclose: true,
    }).on("changeDate", function (ev) {
        $("#Start").datetimepicker('setEndDate', $("#End").val())
    });
});