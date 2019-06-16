
function login(checkInfo) {
    if (checkInfo == "errorMSG1") {
        alert("账号不存在请重新输入用户名");
        $("#userName").focus();
    }
    else if (checkInfo == "errorMSG2") {
        alert("账号或密码错误");
        $("#pwd").focus();
    }
    else if (checkInfo == "success_admin") {
        alert("登录成功即将跳转 NIT 管理后台");
        window.setTimeout(function () { window.location.href = "/NITMange/Index" }, 500);
    }
    else if (checkInfo == "success_reader") {
        alert("登录成功即将跳转 NIT 图书借阅后台");
        window.setTimeout(function () { window.location.href = "/Reader/Index" }, 500);
    }
    else {
        alert(checkInfo);
    }
}

var inputName=$("#userNameinput");
inputName.change(function () {
    if(inputName.val().length<6){
        inputName.css('color', 'red');
        alert("用户名要大于 6 位有效字符");
        inputName.focus();
        return false;
    }
    else if (inputName.val().length > 12) {
        inputName.css('color', 'red');
        alert("用户名要小于 12 位有效字符");
        inputName.focus();
        return false;
    }
    else {
        inputName.css('color', '#000000');
    }
    
})

var pInput = $("#userPwdinput");
pInput.change(function () {
    if (pInput.val().length != 12) {
        pInput.css('color', 'red');
        alert("请输入 12 位有效注册密码" + "，当前密码长度" + pInput.val().length);
        pInput.focus();
    }
    else {
        pInput.css('color', '#000000');
    }
})

var pInput2 = $("#userPwdinput2")
pInput2.change(function () {
    if (pInput.val() == pInput2.val()) {
        pInput2.css('color', '#000000');
    }
    else {
        pInput2.css('color', 'red');
        alert("两次输入的密码不一致");
        pInput2.focus();
        
    }
})

function register(checkInfo) {
    if (checkInfo == "errorMSG1-1") {
        alert("账号已存在请重新输入用户名或登录已有账号");
        $("#userName").focus();
    }
    else if (checkInfo == "errorMSG2-1") {
        alert("账号或密码错误");
        $("#pwd").focus();
    }
    else if (checkInfo == "success_reader") {
        alert("注册成功即将跳转管理界面");
        window.setTimeout(function () { window.location.href = "/Reader/Index" }, 500);
    }
    else {
        alert(checkInfo);
    }
}