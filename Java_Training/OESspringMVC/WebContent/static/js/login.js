$(function() {
    var nameCookie = getcookie("NAMECOOKIE");
    var pwdCookie = getcookie("PWDCOOKIE");
    if (nameCookie && pwdCookie) {
        $("#userName").val(nameCookie);
        $("#password").val(pwdCookie);
        $(".rem").prev("label").addClass("remSelected");
        $("input[name='remember'][type='hidden']").val("1");
    }
    $(".rem").prev("label").click(function() {
        $(this).toggleClass("remSelected");
        var isCheck = 0;
        if ($(this).hasClass("remSelected")) {
            isCheck = 1;
        }
        $("input[name='remember'][type='hidden']").val(isCheck);
    });
    var queryString = location.hash;
    $("input[name='queryString']").val(queryString);
})
function getcookie(objname) {//Get specific name of Cookie's value.
    var arrstr = document.cookie.split("; ");
    for (var i = 0;i < arrstr.length;i ++) {
        var temp = arrstr[i].split("=");
        if (temp[0] == objname) {
            return unescape(temp[1]);
        }
    }
}
function login() {
    var isSubmitForm = true;
    /*
    if (!$.trim($("#userName").val())) {
        isSubmitForm = false;
        $("#userName").after($("<i class='err'></i>")).focus();
        $(".panel li:eq(2)>p").remove();
        $(".panel li:eq(2)").wrapInner($("<p class='errMsgLoginShow'>Field name for User is required.</p>"));
    } else {
        $("#userName").siblings(".err").remove();
        $(".panel li:eq(2)>p").remove();
    }
    if (!$.trim($("#password").val())) {
        if (isSubmitForm) {
            $("#password").focus();
        }
        isSubmitForm = false;
        $("#password").after($("<i class='err'></i>"));
        $(".panel li:eq(4)>p").remove();
        $(".panel li:eq(4)").wrapInner($("<p  class='errMsgLoginShow'>Field password for User is required.</p>"));
    } else {
        $("#password").siblings(".err").remove();
        $(".panel li:eq(4)>p").remove();
    }
    */
    if (isSubmitForm) {
        $("#loginForm").submit();
    }
}