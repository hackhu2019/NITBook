$('#back').click(function () {
    history.back(-1);
});
function check(returnInfo) {
    if (returnInfo == "success") {
        layer.msg("密码修改成功", { icon: 2 });
        window.setTimeout(function () { window.location.href = "/Reader" }, 300);
    }
    else {
        alert("修改出错")
    }
}

function checkInfo(info) {
    if (info == "userNoExist" || info == "bookNoExist") {
        layer.msg("访问非法", { icon: 2 });
        window.setTimeout(function () { window.location.reload(); }, 300);
    }
    else if (info == "noEnough") {
        layer.msg("书籍库存不足", {icon:2});
    }
}
var pwd1=$("#pwd1");
pwd1.change(function() {
    if(pwd1.val().length<6){
        pwd1.css('color', 'red');
        layer.msg("密码要大于 6位" + "，当前密码长度" + pwd1.val().length, { icon: 2, time: 1000 });
        pwd1.focus();
    }
    else if(pwd1.val().length>12){
        pwd1.css('color', 'red');
        layer.msg("密码要小于 12位" + "，当前密码长度" + pwd1.val().length, { icon: 2, time: 1000 });
        pwd1.focus();
    }
    else {
        pwd1.css('color', '#000000');
    }
})

var pwd2=$("#pwd2");
pwd2.change(function(){
    if(pwd1.val!=pwd2.val){
        layer.msg('二次输入密码不一致，请重新输入密码！', { icon: 2, time: 1000 });
        pwd2.focus();
    }
})

$("#submit").click(function () {
    if (pwd1.val().trim().length <= 0) {
        layer.msg('请勿更改为空密码', { icon: 2, time: 1000 });
        pwd1.focus();
    }
    else if (pwd2.val().trim().length <= 0) {
        layer.msg('请勿更改为空密码', { icon: 2, time: 1000 });
        pwd2.focus();
    }
    else if (pwd1.val != pwd2.val) {
        layer.msg('二次输入密码不一致，请重新输入密码！', { icon: 2, time: 1000 });
        pwd2.focus();
    }
})

$("#imageFile").change(function () {
    var suffix = $(this).val().split('.')[1].toLowerCase();
    console.log($(this).val() + "," + suffix)
    if (suffix == "jpg" || suffix == "png" || suffix == "jpeg") {

    }
    else {
        layer.msg('请上传后缀为 jpg 或 png 格式的图片', { icon: 2 });
        $(this).val("");
        $(this).focus();
    }
})