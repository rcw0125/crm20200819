$(function () {
    $(".table tbody tr").click(function () {

        var input = $(this).children(0).find("input");
        var ischecked = input.prop('checked');
        if (ischecked) {
            input.prop('checked', '');
        }
        else {
            input.prop('checked', 'checked');
        }
    });
});