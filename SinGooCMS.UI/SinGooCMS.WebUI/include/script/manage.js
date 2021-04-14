var h5 = new Object();

h5 = {
    Controller: "", //MVC控制器
    ActionName: "", //MVC方法
    PagerUrl: "", //列表异步分页地址
    ParamAction: "", //传参Action 如 Action=Add
    OpID: 0, //传参OpID 如OpID=1
    ajaxLogin: function (sender, name, pwd, checkCode) { //管理员异步登录
        $(sender).val("登 录 中...");
        var postData = "type=AdminLogin&_accountname=" + name + "&_accountpwd=" + pwd.toSHA() + "&_checkcode=" + checkCode + "&temp=" + Math.random();
        singoo.ajaxSubmit(postData, function (data) {
            if (data.url == "") { showtip(data.msg); $(sender).val("登 录"); } else { location = data.url }
        }, "/account/login");
    },
    render: function (obj, tmpl, data) { //mustache 渲染模板: obj容器对象，tmpl模板文本，data Json数据
        Mustache.parse(tmpl); //编译，类似缓存
        var view = Mustache.render(tmpl, data);
        $(obj).html(view);
    },
    loadData: function (page) {
        $('#checkall').prop('checked', false); //分页后，清除上页的全选状态 
        $.getJSON(this.PagerUrl + (this.PagerUrl.indexOf("?") == -1 ? "?" : "&") + "page=" + page + "&temp=" + Math.random(), function (json) {
            var tmpl = $("#singoo-template").html(); //列表模板
            h5.render($("#singoo-content"), tmpl, json.result);

            if (json.result.pager != null) {
                $.get("/views/platform/h5/inc/pager-mvc-template.html?temp=" + Math.random(), function (ptmpl) { //分页模板
                    h5.render($("#singoo-pager"), ptmpl, json.result);
                });
            }

            $("body").find("img[viewer='true'],div[viewer='true']").viewer({ url: "data-original" });
        });
    },
    del: function (sender) { //删除
        var action = arguments.length > 1 ? arguments[1] : "Delete"; //操作
        var checkboxName = arguments.length > 2 ? arguments[2] : "chk"; //选择框的name
        var opid = $(sender).attr("singoo-data-id"); //写在触发表单项（按钮）的id
        var globalOpID = $("#singoo-data-opid").val();
        if ((opid == null || opid == undefined || opid == "" || opid == "0") && globalOpID != null && !isNaN(globalOpID))
            opid = globalOpID;
        var ids = singoo.getIds(checkboxName); //所有已选择的id集合
        var urlExt = $(sender).attr("singoo-data-urlext"); //自定义参数 类似于 &cateid=1，可多个
        if (urlExt == null) urlExt = "";

        if (action == "BatDelete" && ids == "")
            showtip("没有选择任何项");
        else {
            var d = $.dialog.confirm('操作不可恢复，确定删除吗？', function () {
                switch (action) {
                    case "BatDelete":
                        singoo.ajaxSubmit("ids=" + ids + urlExt, null, "/platform/" + h5.Controller + "/BatDelete");
                        return true;
                    case "Delete":
                        singoo.ajaxSubmit("opid=" + opid + urlExt, null, "/platform/" + h5.Controller + "/Delete");
                        return true;
                }
                return false;
            }, function () {
                return true;
            });
        }
        return false;
    }
}

$(function () {
    //优先与调用赋值
    h5.PagerUrl = $("#singoo-data-dataurl").val(); //默认的获取ajax分页数据的地址,在条件搜索时需要被改变
    h5.Controller = $("#singoo-data-controller").val();
    h5.ActionName = $("#singoo-data-action").val();
    h5.ParamAction = $("#singoo-data-paramaction").val();
    h5.OpID = parseInt($("#singoo-data-opid").val());
    if (h5.OpID == null || h5.OpID == undefined || isNaN(h5.OpID))
        h5.OpID = 0;

    //执行标签属性
    $("body").find("textarea[singoo-editor='true']").each(function (i, item) {
        var toolbar = $(item).attr("singoo-editor-toolbar"); // Full/Basic
        var param = $(item).attr("singoo-editor-param"), width = "", height = "";
        width = param != null ? param.split('|')[0] : ""; height = param != null ? param.split('|')[1] : "";
        CKEDITOR.replace($(item).attr("id"), { "allowedContent": true, "htmlEncodeOutput": true, "pasteFromWordPromptCleanup": true, "toolbar": toolbar, "width": width, "height": height });
    });
    $("body").find("input[singoo-dialog-close='true']").click(function () { art.dialog.close(); });
    $("body").find("input[singoo-upload='true'],a[singoo-upload='true']").click(function () {
        var param = $(this).attr("singoo-upload-param"); var items = param.split('|'); //最多6个参数
        new UploadTool(items[0], items[1], items[2]).open();
    });
    $("body").find("a[singoo-showimg='true'],input[singoo-showimg='true']").click(function () { var targetId = $(this).attr("singoo-showimg-target"); showimg($('#' + targetId).val()); });
    $("body").find("a[singoo-date='true'],input[singoo-date='true']").bind("click focus", function () { WdatePicker({ dateFmt: $(this).attr("singoo-date-format") }) })
    $("body").find("a[singoo-tmplselector='true'],input[singoo-tmplselector='true']").click(function () {
        var target = $(this).attr("singoo-tmplselector-target");
        $.dialog.open('/platform/TmplSelector/Index?elementid=' + target, { title: '选择模板', width: 680, height: 500 }, false);
    });

    //form提交
    $("form[singoo-data-ajax='true']").submit(function () {
        singoo.ckeditorUpdate();
        var isEdit = $(this).attr("singoo-data-edit") == "true";
        var postData = $(this).serialize();
        if (h5.OpID > 0) postData = postData + "&opid=" + h5.OpID;
        if ($(this).attr("singoo-data-dialog") == "true") { //弹出的对话框，执行操作后，父框架异步加载           
            singoo.ajaxSubmit(postData, function (data) {
                if (data.url == "reload") { //原调用页（上级页）主动刷新
                    $.dialog.open.origin.location.reload();
                } else if (data.url != "") {
                    $.dialog.open.origin.location = data.url;
                } else if (data.ret == "Success") { //成功的
                    $.dialog.close();
                    $.dialog.open.origin.showtip(data.msg);
                    $.dialog.open.origin.h5.loadData(1); //原调用页无刷新加载
                } else {
                    showtip(data.msg); //失败的
                }
            }, $(this).attr("action"), $(this).attr("method"));
        } else {
            if (isEdit) {
                singoo.ajaxSubmit(postData, function (data) {
                    if (data.msg != "") showtip(data.msg); //提示
                    if (data.ret == "Success") {
                        //选项卡在url中，如TabControl:栏目设置
                        if (data.url.indexOf("TabControl") != -1) {
                            setTimeout(function () { window.parent.closeThisAndRefMenu(data.url.split(':')[1]); }, 1500);
                        } else {
                            setTimeout(function () { window.parent.closeThisMenu(); }, 1500);
                        }
                    }                    
                }, $(this).attr("action"), $(this).attr("method"));
            }
            else singoo.ajaxSubmit(postData, null, $(this).attr("action"), $(this).attr("method"));
        }

        return false;
    });
    //input、button、a标签等触发的提交，前提是有属性singoo-action，如singoo-action="Delete"
    $("body").on("click", "a[singoo-action],input[singoo-action],button[singoo-action]", function () {
        singoo.ckeditorUpdate();
        var action = $(this).attr("singoo-action"); //操作命令
        var confirmTxt = $(this).attr("singoo-data-confirm");
        var id = $(this).attr("singoo-data-id"); //操作的id/key
        var url = "", formAction = $(this).parents("form").attr("action"), specialUrl = $(this).attr("singoo-data-url"); //指定提交的url,默认是当前地址        
        if (specialUrl != null && specialUrl != "")
            url = specialUrl; //当前按钮标签内指定了url
        else if (formAction != null && formAction != "")
            url = formAction; //form指定了action
        var urlExt = $(this).attr("singoo-data-urlext"); //自定义参数 类似于 &cateid=1，可多个
        if (urlExt == null) urlExt = "";

        var isDialog = $(this).attr("singoo-dialog") == "true";
        var dialogParam = $(this).attr("singoo-dialog-param");
        var dialogTitle = (dialogParam != null && dialogParam.split('|').length > 0) ? dialogParam.split('|')[0] : "";
        var dialogWidth = (dialogParam != null && dialogParam.split('|').length > 1) ? parseInt(dialogParam.split('|')[1]) : 0;
        var dialogHeight = (dialogParam != null && dialogParam.split('|').length > 2) ? parseInt(dialogParam.split('|')[2]) : 0;

        if (isDialog || dialogParam || action == "Add" || action == "Modify")
            $.dialog.open(url + (url.indexOf("?") == -1 ? "?" : "&") + "Action=" + action + urlExt, { title: dialogTitle, width: dialogWidth, height: dialogHeight }, false);
        else {
            switch (action) {
                case "Search":
                    {
                        var keys = "", values = "";
                        $.each($("input[singoo-search-item='true'],select[singoo-search-item='true']"), function (index, item) {
                            //alert(item.type)
                            switch (item.type) {
                                case "text":
                                    //param += "&" + item.name + "=" + encodeURI(item.value);
                                    keys += item.name + ","; values += encodeURI(item.value) + ",";
                                    break;
                                case "radio":
                                    var val = $('input[name="' + item.name + '"]:checked').val();
                                    //param += "&" + item.name + "=" + encodeURI(val);
                                    keys += item.name + ","; values += encodeURI(val) + ","
                                    break;
                                case "checkbox":
                                    var val = $('input[name="' + item.name + '"]:checked').val();
                                    //param += "&" + item.name + "=" + encodeURI(val);
                                    keys += item.name + ","; values += encodeURI(val) + ","
                                    break;
                                case "select-one": //select
                                    //param += "&" + item.name + "=" + encodeURI(item.value);
                                    keys += item.name + ","; values += encodeURI(item.value) + ",";
                                    break;
                            }
                        });
                        keys = keys.cutRight(); values = values.cutRight();
                        h5.PagerUrl = singoo.createUrl(h5.PagerUrl, (keys.length > 0 ? "," + keys : "") + ",temp", (values.length > 0 ? "," + values : "") + "," + Math.random());
                        //console.log(h5.PagerUrl);
                        h5.loadData(1);
                    }
                    break;
                case "Delete":
                    h5.del(this);
                    break;
                case "BatDelete":
                    h5.del(this, 'BatDelete', 'chk');
                    break;
                default:
                    {
                        var data = $(this).parents("form").serialize() + "&opid=" + id + urlExt;
                        if (confirmTxt != null && confirmTxt != undefined) {
                            var d = $.dialog.confirm(confirmTxt, function () { //先要确认操作                            
                                if (url != "") singoo.ajaxSubmit(data, null, url);
                                else singoo.ajaxSubmit(data);
                                return true;
                            }, function () {
                                return true;
                            });
                        } else {
                            if (url != "") singoo.ajaxSubmit(data, null, url);
                            else singoo.ajaxSubmit(data);
                            return false;
                        }
                    }
                    break;
            }
        }
    });

    //检查输入长度限制
    $("input[maxlength],textarea[maxlength]").bind("keydown keyup paste", function () { //检查输入长度
        var len = $(this).val().length;
        var maxlen = 0;
        if (typeof ($(this).attr("lenlimit")) != "undefined")
            maxlen = parseInt($(this).attr("lenlimit"));
        else if (typeof ($(this).attr("maxlength")) != "undefined")
            maxlen = parseInt($(this).attr("maxlength"));

        if (len >= maxlen) {
            $(this).qtip({
                content: "最多可输入 " + maxlen + " 个字符", position: { my: 'bottom center', at: 'top center' },
                show: { event: 'mouseenter', solo: false, ready: false, modal: false }, hide: { event: 'mouseleave' },
                style: 'ui-tooltip-default'
            });
            $(this).val($(this).val().cut(maxlen)); //截断超出的长度
        }
    });

    //列表初始化
    if ($("form").attr("singoo-data-list") == "true") {
        h5.loadData(1);
    }
})