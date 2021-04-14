document.write("<script src='/include/script/md5.js' type='text/javascript'></script>");
document.write("<script src='/include/script/sha512.js'></script>");
var singoo = new Object();
singoo = {
    checkhHtml5: function () {
        return typeof (Worker) != null && typeof (Worker) != undefined; // typeof (Worker) = function
    },
    submitKey: function (evt, id_btn) { //触发按钮点击事件 调用 singoo.submitKey(event,'btnid');
        var evt = (evt) ? evt : ((window.event) ? window.event : "");
        var key = evt.keyCode ? evt.keyCode : evt.which;
        if (key == 13) { document.getElementById(id_btn).click(); return false; }
    },
    request: {},
    initRequest: function () { //获取查询参数
        var s = location.search, m, reg = /([a-z_\d]+)=([^&]+)/gi;
        s = s == '' ? '' : s.substring(1);
        while (m = reg.exec(s)) { this.request[m[1].toLowerCase()] = m[2]; }
    },
    createUrl: function (url, keys, values) { //如果url包括key则更新，否则增加
        if (url == null) return "";
        var path = url.split('?')[0], query = url.split('?')[1];
        var arrKey = keys.split(','), arrVal = values.split(',');
        if (query == null) query = "";
        for (var i = 0; i < arrKey.length; i++) {
            if (query.indexOf(arrKey[i] + "=") != -1) { //存在替换
                var arrQuery = query.split('&');
                for (var j = 0; j < arrQuery.length; j++) {
                    if (arrQuery[j].split('=')[0] == arrKey[i])
                        query = query.replace(arrQuery[j].split('=')[0] + "=" + arrQuery[j].split('=')[1], arrKey[i] + "=" + arrVal[i])
                }
            } else { //不存在增加
                query += (query.length > 0 ? "&" : "") + arrKey[i] + "=" + arrVal[i];
            }
        }

        return path + "?" + query;
    },
    createFeedback: function () { //调用 singoo.createFeedback(strUName, strUContent, yzm, strUTitle, strUEmail, strUTel).send();
        var feedback = new Object();
        feedback.data = {
            "uname": arguments[0], "content": arguments[1], "verifyCode": arguments[2],
            "title": arguments.length > 3 ? arguments[3] : arguments[0] + "的留言信息",
            "email": arguments.length > 4 ? arguments[4] : "",
            "phone": arguments.length > 5 ? arguments[5] : ""
        };
        feedback.send = function (customFun) { //customFun允许自定义发送留言事的自定义回调方法
            if (feedback.data.uname == "") showtip("请输入您的名称");
            else if (feedback.data.content == "") showtip("请输入留言内容");
            else if (feedback.data.verifyCode == "") showtip("请输入验证码");
            else {
                var urlParams = Object.keys(feedback.data).map(function (key) {
                    return encodeURIComponent(key) + "=" + encodeURIComponent(feedback.data[key]);
                }).join("&");

                singoo.ajaxSubmit(urlParams, customFun, "/api/common/SaveFeedback", "post");
            }
        }

        return feedback;
    },
    createComment: function () {
        var comment = new Object();
        comment.data = {
            "contid": arguments[0],
            "comment": arguments[1],
            "checkcode": arguments[2]
        };
        comment.send = function (customFun) {
            if (comment.data.contid <= 0) showtip("没有找到内容");
            else if (comment.data.uname == "" || comment.data.uname == "游客") showtip("会员未登录或登录超时");
            else if (comment.data.comment == "") showtip("请输入评论内容");
            else if (comment.data.comment.length <6) showtip("评论内容不少于6个字");
            else if (comment.data.checkcode == "") showtip("请输入验证码");
            else {
                var urlParams = Object.keys(comment.data).map(function (key) {
                    return encodeURIComponent(key) + "=" + encodeURIComponent(comment.data[key]);
                }).join("&");

                singoo.ajaxSubmit(urlParams, customFun, "/comment/save", "post");
            }
        }

        return comment;
    },
    loadComment: function () {
        var contId = arguments[0];//1、文章内容ID
        var pageIndex = arguments[1], pageSize = 10; //2、当前页号 3、分页记录数 
        var htmlContainer = "singoo-comment-content", pagerContainer = "singoo-comment-pager"; //4、列表容器ID 5、分页条容器
        var cmtPagerModel = "/views/templates/html/inc/_cmtpager.html"; //6、分页条模板
        if (arguments.length > 2) pageSize = arguments[2];
        if (arguments.length > 3) htmlContainer = arguments[3];
        if (arguments.length > 4) pagerContainer = arguments[4];
        if (arguments.length > 5) cmtPagerModel = arguments[5];        
        $("#" + htmlContainer).html("");
        $.getJSON("/comment/list?contid=" + contId + "&page=" + pageIndex + "&pagesize=" + pageSize + "&temp=" + Math.random(), function (json) {
            h5.render($("#" + htmlContainer), tmpl, json.result);
            if (json.result.pager != null && json.result.pager.totalRecord > 0) {
                $.get(cmtPagerModel+"?temp=" + Math.random(), function (ptmpl) {
                    h5.render($("#" + pagerContainer), ptmpl, json.result); //显示分页组件
                });
            }
        });
    },
    /*    
    模拟同步post 调用：singoo.httpPost('/shop/addtocart', { _protype: '普通订购', _pid:'${item.AutoID}', _buynumber: 1, _price: '$price1' });
    */
    httpPost: function (url, params) {
        var temp = document.createElement("form");
        temp.action = URL;
        temp.method = "post";
        temp.style.display = "none";
        for (var x in params) {
            var opt = document.createElement("textarea");
            opt.name = x;
            opt.value = params[x];
            temp.appendChild(opt);
        }
        document.body.appendChild(temp);
        temp.submit();
        return temp;
    },
    chkAll: function (controlObj, name_chk) { //全选/全不选 controlObj是控制表单 name_chk是成员表单name
        $.each($("input[name='" + name_chk + "']"), function (index, item) { $(controlObj).attr("checked") ? $(item).attr("checked", "checked") : $(item).removeAttr("checked") });
    },
    getIds: function (name_chk) { //获取checkbox/radio选中的值集合 表单要有value=""属性
        var ids = "";
        $("body").find("input[name='" + name_chk + "']").each(function (index, item) { if (item.checked) ids += $(item).val() + ","; });
        return ids.cutRight(',');
    },
    getRandStr: function (len) { //获取随机字段串
        len = len || 32;
        var temp = 'ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz2345678';
        var maxPos = temp.length;
        var str = '';
        for (i = 0; i < len; i++) { str += temp.charAt(Math.floor(Math.random() * maxPos)); }
        return str;
    },
    initArea: function () {
        var objProvince = jQuery("#" + arguments[0]);
        var objCity = jQuery("#" + arguments[1]);
        var objCounty = jQuery("#" + arguments[2]);

        objProvince.html(this.getAreaOption(0)); //填充省份
        objCity.html(this.getAreaOption(1));  //填充默认城市
        objCounty.html(this.getAreaOption(35));  //填充默认区县

        objProvince.change(function () {
            var pid = objProvince.find("option:selected").attr("rel"); //rel保存地区ID
            objCity.html(singoo.getAreaOption(pid));

            var cid = objCity.find("option:eq(0)").attr("rel");
            objCounty.html(singoo.getAreaOption(cid)); //显示第一个城市的区县列表
        });

        objCity.change(function () {
            var cid = objCity.find("option:selected").attr("rel");
            objCounty.html(singoo.getAreaOption(cid));
        });
    },
    getAreaOption: function (parentID) {
        var str = "";
        //jQuery.ajaxSettings.async = false;
        jQuery.getJSON("/Config/zone.json", function (data) {
            jQuery.each(data, function (i, item) {
                if (item.ParentID == parentID)
                    str += "<option rel=" + item.AutoID + " value=\"" + item.ZoneName + "\">" + item.ZoneName + "</option>";
            });
        });
        //jQuery.ajaxSettings.async = true;
        return str;
    },
    showJumpPage: function (msg, url) {
        location = "/include/jump.html?msg=" + encodeURIComponent(msg) + "&redirecturl=" + encodeURIComponent(url);
    },
    ckeditorUpdate: function () { //更新编辑器，让它有值
        if (typeof (CKEDITOR) != "undefined" && CKEDITOR != null && CKEDITOR.instances != null) {
            for (instance in CKEDITOR.instances)
                CKEDITOR.instances[instance].updateElement();
        }
    },
    ajaxSubmit: function () { //异步提交 data必填，url默认本页，type默认post 示例： singoo.ajaxSubmit($(this).serialize(),dowork,$(this).attr("action"),$(this).attr("method"));
        var ajaxOption = {
            type: "post", //默认post方式
            url: "", //默认提交到本页
            data: arguments[0], //提交的数据 必填
            cache: false,
            timeout: 10000, //超时 10秒
            dataType: "JSON" //返回的数据类型          
        };
        if (arguments.length > 2 && arguments[2] != null)
            ajaxOption.url = arguments[2]; //选填参数 指定提交的url
        if (arguments.length > 3 && arguments[3] != null)
            ajaxOption.type = arguments[3]; //选填参数 指定提交的方式
        if (arguments.length > 4 && arguments[4] == true) {
            /*html5异步上传时，需要封装一个formdata 
            var formData = new FormData($('#form')[0]);
            自动搜索表单信息(表单内没有name属性的input不会被搜索到)，IE<=9不支持FormData
            以下两个参数需要设置成false,并且必须是post方式
            */
            ajaxOption.contentType = false; // 当有文件要上传时，此项是必须的，否则后台无法识别文件流的起始位置
            ajaxOption.processData = false; // 是否序列化data属性，默认true(注意：false时type必须是post)
        }

        if (arguments.length > 1 && arguments[1] != null) {
            var dowork = arguments[1];
            $.ajax(ajaxOption).done(function (data) { dowork(data) }); //选填的扩展方法
        } else {
            var ajax = $.ajax(ajaxOption);
            ajax.done(function (data) { //默认的处理方法
                if (data.msg != "") showtip(data.msg); //提示
                if (data.url != null && data.url != "") {
                    if (data.url == "loadData") h5.loadData(1); //异步加载第一页
                    else if (data.delay > 0) setTimeout(function () { location = data.url }, data.delay); //延期跳转
                    else location = data.url; //直接跳转到链接
                }
            });
            ajax.fail(function () { showtip("操作失败！请检查网络是否畅通。") });
        }
        return false;
    }
}

/*String扩展*/
String.prototype.toMD5 = function () { var md5 = hex_md5(this).toUpperCase().replace("-", "").substr(6, 13); return hex_md5(md5).toUpperCase().replace("-", "").substr(6, 13); }
String.prototype.toSHA = function () { return CryptoJS.SHA512(this.toString()); }
String.prototype.cut = function (len) { return this.length > len ? this.substr(0, len) : this; }
String.prototype.cutLeft = function (str) { if (str == null || str == "") return this.length > 1 ? this.substr(1) : this; else return this.substr(this.indexOf(str) + 1); }
String.prototype.cutRight = function (str) { if (str == null || str == "") return this.length > 1 ? this.substr(0, this.length - 1) : this; else return this.substr(0, this.lastIndexOf(str)); }
String.prototype.replaceAll = function (s1, s2) { return this.replace(new RegExp(s1, "gm"), s2); }
String.prototype.startWith = function (str) { return str != null && str != "" && this.substr(0, str.length) == str; }
String.prototype.endWith = function (str) { return str != null && str != "" && this.substring(this.length - str.length) == str; }
String.prototype.IsPicture = function () { //判断是否图片文件
    var strFilter = ".jpeg|.gif|.jpg|.png|.bmp|"
    if (this.indexOf(".") > -1) {
        var p = this.lastIndexOf(".");
        var strPostfix = this.substring(p, this.length) + '|';
        strPostfix = strPostfix.toLowerCase();
        if (strFilter.indexOf(strPostfix) > -1) {
            return true;
        }
    }

    return false;
}
String.prototype.encodeHtml = function () { // HTML编码
    var re = this;
    var q1 = ["&", "<", ">", " ", "'", "\""];
    var q2 = ["&amp;", "&lt;", "&gt;", "&nbsp;", "&#39;", "&quot;"];
    for (var i = 0; i < q1.length; i++)
        re = re.replaceAll(q1[i], q2[i]);
    return re;
}
String.prototype.decodeHtml = function () { // HTML解码
    var re = this;
    var q1 = ["&amp;", "&lt;", "&gt;", "&nbsp;", "&#39;", "&quot;"];
    var q2 = ["&", "<", ">", " ", "'", "\""];
    for (var i = 0; i < q1.length; i++)
        re = re.replaceAll(q1[i], q2[i]);
    return re;
}
String.prototype.toTxt = function () { return this.replace(/<[^>]*>|/g, ""); }
Date.prototype.format = function (format) { //日期格式化 new Date().format("yyyy-MM-dd hh:mm:ss")
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(), //day
        "h+": this.getHours(), //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
function showmsg(msg) { art.dialog({ title: '系统提示', content: msg, width: 260, height: 60, lock: false }) }
function showalert(msg) { art.dialog({ title: '系统提示', content: msg, width: 260, height: 60, icon: 'warning', lock: false }) }
function showsuccess(msg) { art.dialog({ title: '系统提示', content: msg, width: 260, height: 60, icon: 'succeed', lock: false }) }
function showtip(msg) { art.dialog.tips(msg, 3); }
function showimg(imgsrc) {
    if (imgsrc == null || imgsrc == "") showalert("没有找到文件");
    else if (imgsrc.indexOf(".") == -1) showalert("没有找到文件");
    else if (!imgsrc.IsPicture()) window.open(imgsrc); //showalert("非图片格式");
    else $.dialog({ padding: 0, title: '查看图片', content: '<a href="' + imgsrc + '" target="_blank"><img src="' + imgsrc + '" style="max-width:400px"/><a/>', lock: false });
}
function upImg(files, elementID) { //ckeditor 编辑器上传图片后回调，传图片显示在编辑器
    if (files == null || files == "") { return; }
    $.each(files.split(','), function (i, item) {
        if (item != "") {
            var element = CKEDITOR.dom.element.createFromHtml('<img src="' + item + '" alt="" />');
            CKEDITOR.instances[elementID].insertElement(element);
        }
    });
}
$(function () {
    singoo.initRequest(); //初始化
});