//传递的参数 选择的类型type: single mutil 回调的标签elementid 回调的属性attr: value src 回调的类型backtype names ids
singoo.initRequest();

var ids = "";
var names = "";
function selectOk() {
    $.each($('#rowItems').find("input"), function (i, item) {
        if ($(item).prop("checked")) { //被选中
            if ($(this).attr("type") == "radio") {
                ids = $(item).attr("id");
                names = $(item).attr("value");
            } else {
                ids += $(item).attr("id") + ",";
                names += $(item).attr("value") + ",";
            }
        }
    });

    if (ids != "" && names != "") {
        callback((ids.lastIndexOf(',') != -1 ? ids.cutRight() : ids), (names.lastIndexOf(',') != -1 ? names.cutRight() : names));
        $.dialog.close();
    } else {
        showtip("没有选择任何项");
    }
}
//回调,给调用的标签赋值
function callback(strIds, strNames) {
    for (var i = 0; i < singoo.request["elementid"].split(',').length; i++) {
        var t = singoo.request["backtype"].split(',')[i]; //回调类型
        var e = singoo.request["elementid"].split(',')[i]; //赋值表单
        var a = singoo.request["attr"].split(',')[i]; //赋值属性
        if (a == "value")
            $($.dialog.open.origin.document.getElementById(e)).val(t == "ids" ? strIds : strNames);
        else if(a=="dowork")
            $.dialog.open.origin.dowork(t == "ids" ? strIds : strNames);
        else
            $($.dialog.open.origin.document.getElementById(e)).attr(a, t == "ids" ? strIds : strNames);
    }
}