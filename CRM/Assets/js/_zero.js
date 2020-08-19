
//弹出框_iframe
function _iframe(url, w, h, title) {
    zeroModal.show({
        title: title,
        iframe: true,
        url: url,
        width: w,
        height: h,
        cancel: false,
        overlay: true,
        resize: true,
        max: true,
        min: true
    });
}

//关闭弹出框
function close() {
    zeroModal.closeAll();
}

//等待框
function _loading(type) {

    zeroModal.loading(type);
}

function _closemsg(str) {
    alert(str);
    zeroModal.closeAll();
}