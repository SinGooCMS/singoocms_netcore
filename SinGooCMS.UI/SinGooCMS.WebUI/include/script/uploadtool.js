/*
* singoocms@2018-08-24
* 文件上传工具 uploadTool
* 参数一：回调的对象键 paramKeys : "textbox1,img1,span1"
* 参数二：回调的对象值 paramVals : "val,src,text"
* 回调对象键值分别对应标签的id和被赋值的属性名称，它们是一一对应的
* 参数三：回调方法 doWork 
* 指定的回调函数优先于回调对象
* 参数四：选择类型 selectType ：single/mutil 单选/多选
* 参数五：上传人 userType ：manager/user 管理员/普通会员 管理员上传无容量限制，会员上传有容量限制。都需要判断是否登录
* 参数六：是否批量上传 isBat 批量上传没有回调，上传完成后就刷新父页面
* 示例：new UploadTool("textbox1,img1","val,src",doWork,SelectType.Single,UserType.Manager,isBat).open();
*/

var SelectType = {
    Single: 0,
    Mutile: 1
};
var UserType = { //数字对应C# UserType枚举的值
    Manager: 1,
    User: 2
}

function UploadTool(paramKeys, paramVals) {
    this.paramKeys = paramKeys;
    this.paramVals = paramVals;
    this.callbackFun = "single";
    if (arguments.length > 2)
        this.callbackFun = arguments[2]; //回调方式
    this.selectType = SelectType.Single;
    if (arguments.length > 3)
        this.selectType = arguments[3];
    this.userType = UserType.Manager;
    if (arguments.length > 4)
        this.userType = arguments[4];
    this.isBat = 0;
    if (arguments.length > 5)
        this.isBat = arguments[5];

    this.open = function () { //打开上传窗口,注意：参数名字都要小写
        $.dialog.open('/platform/Tools/Uploader?usertype=' + this.userType + '&selecttype=' + this.selectType + '&paramkeys=' + this.paramKeys + '&paramvals=' + paramVals + '&callbackfun=' + this.callbackFun + "&isbat=" + this.isBat, { title: '上传工具', width: 780, height: 490 }, false);
    };
}

UploadTool.prototype.callback = function (fileNames) { //回调    
    var paramkeys = singoo.request["paramkeys"], paramvals = singoo.request["paramvals"], callbackFun = singoo.request["callbackfun"];
    if (callbackFun == null || callbackFun == "") callbackFun = "single"; //默认直接给输入框赋值
    if (callbackFun == "ckeditor") {
        art.dialog.open.origin.upImg(fileNames, paramkeys);
    } else if (callbackFun == "single") {
        var arrElements = paramkeys.split(',');
        for (var i = 0; i < arrElements.length; i++) {
            $(art.dialog.open.origin.document.getElementById(arrElements[i])).attr(paramvals.split(',')[i], fileNames);
        }
    } else {
        art.dialog.open.origin.callbackFun(strFileName); //让父页自行处理数据
    }

    art.dialog.close();
}

$(function () {
    $("#upnetfile").click(function () {
        var netfile = $("#networkfile").val();
        if (netfile == "")
            showtip("请输入网络文件地址");
        else if (netfile.length > 255)
            showtip("网络地址长度不能超过255个字符");
        else {
            new UploadTool().callback(netfile);
        }
    });
});