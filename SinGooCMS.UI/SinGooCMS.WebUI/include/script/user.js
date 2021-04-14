/*
* 会员 注意：需要引用 jquery.cookie.js
*/
var user = new Object();
var totaltime = 60;
var d = null;
user = {
    logincookie: $.cookie('singoocms_uid'),
    isLogined: function () {
        return this.logincookie != null;
    },
    getcode: function (sender,inputId) {
        var mediaVal = $("#" + inputId).val(); //邮箱或者手机号
        if (mediaVal == "") {
            showtip("请输入邮箱或者手机验证来源");
            $("#" + inputId).focus();
        } else {
            $("#vcode_CodeImg").click();
            var localCheck = $.dialog({ padding: 10, title: '输入图形验证码', content: document.getElementById("vcode_pane"), width: 280, height: 30, lock: false });
            $("#vcode_submit").click(function () {                
                if (localVCode == "")
                    showtip("验证码不能为空");
                else {
                    localCheck.close();
                    var loaddingShow = $.dialog({ cancel: false, padding: 10, title: '正在处理中...', content: "<img src='/include/images/loading.gif' alt='' /> 正在玩命处理中，请稍候...", width: 260, height: 30, lock: false });

                    var localVCode = $("#vcode_localVal").val(); //本地图形验证码，只有验证正确才会发送邮件或者短信
                    var sendUrl = "/Common/SendCheckCode";
                    $.post(sendUrl, { receiver: mediaVal, vcode: localVCode, temp: Math.random() }, function (json) {
                        if (json != null && json != "") {
                            loaddingShow.close();
                            showtip(json.msg);
                            if (json.timeout > 0) {
                                totaltime = json.timeout;
                                d = setInterval(user.showTimeout, 1000, sender);
                            }
                        }
                    }, "JSON");

                    $("#vcode_CodeImg").click();
                }                
            });
        }
    },
    showTimeout: function (sender) {
        console.log(totaltime)
        totaltime--;
        if (totaltime > 0) {
            $(sender).text("获取验证码(" + totaltime + ")");
            $(sender).attr("disabled", "disabled");
        } else {
            $(sender).text("获取验证码");
            $(sender).removeAttr("disabled");
            clearInterval(d);
        }
    },
    bind: function (type, paramval, validatecode) { //个人资料 邮箱/手机绑定
        jQuery.getJSON("/ajax/ajaxmethod?t=userbind&type=" + type + "&paramval=" + paramval + "&checkcode=" + validatecode + "&temp=" + Math.random(), function (json) {
            if (json.ret == "success") {
                showtip(json.msg);
                location.reload();
            } else {
                showtip(json.msg);
            }
        });
    },
    readMsgAll: function (name_chk) {
        var ids = singoo.getIds(name_chk);
        if (ids != "")
            location = "?action=read&opid=" + ids;
    },
    delMsgAll: function (name_chk) {
        if (confirm('确定删除吗？')) {
            var ids = singoo.getIds(name_chk);
            if (ids != "")
                location = "?action=delete&opid=" + ids;
        }
    },
    delAccAll: function (name_chk) {
        if (confirm('确定删除吗？')) {
            var ids = singoo.getIds(name_chk);
            if (ids != "")
                location = "?action=delete&opid=" + ids;
        }
    },
    delIntegralAll: function (name_chk) {
        if (confirm('确定删除吗？')) {
            var ids = singoo.getIds(name_chk);
            if (ids != "")
                location = "?action=delete&opid=" + ids;
        }
    }
}