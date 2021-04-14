var menu, thisobjnum, thisobjname;
if (!menu) {
    $("<div id='wrapper'><div class='wrapper-sline'></div><div class='wrapper-li refresh'>刷新<span class='refresh-span iconfont'></span></div><div class='wrapper-line'></div><div class='wrapper-li close'>关闭<span class='close-span iconfont'></span></div><div class='wrapper-li close-other'>关闭其它</div><div class='wrapper-li close-all'>关闭全部</div></div>").appendTo('body').hide();
}

$("#menu-list").bind("contextmenu", function (e) {
    //thisobjnum=$(this).children("a").index();
    //得到点击标题
    thisobjname = e.target.title
    //得到点击序号
    $("#menu-list a").each(function (i, ele) {
        //console.log($(ele).children("span").html());
        if ($(ele).children("span").html() == thisobjname) {
            thisobjnum = i
            return false;
        }
    })
    //console.log(thisobjnum);
    //当为第1个时取消关闭按钮
    if (thisobjnum == 0) {
        $(".close").addClass('prohibit');
    } else {
        $(".close").removeClass('prohibit');
    }
    var key = e.which; //获取鼠标键位  
    if (key == 3)  //(1:代表左键； 2:代表中键； 3:代表右键)  
    {//获取右键点击坐标 
        var x = e.clientX;
        var y = e.clientY;
        $("#wrapper").show().css({ left: x, top: y });
        return false;
    }
});
//点击任意部位隐藏  
$(document).click(function () {
    $("#wrapper").hide();
})
$("a").click(function (event) {
    $("#wrapper").hide();
});




$(document).on('click', "#menu-list a", function (event) {
    var tnum = $(this).index();
    $("#menu-list a.active").removeClass("active");
    $("#menu-list a").eq(tnum).addClass("active");
    $("#page-content iframe.active").removeClass("active");
    $("#page-content .iframe-content").eq(tnum).addClass("active");
    $("#menu-all-ul li.active").removeClass("active");
    $("#menu-all-ul li").eq(tnum).addClass("active");
    event.stopPropagation();
});

$(document).on("click", "#menu-list .menu-close", function (event) {
    var tnum = $(this).parent("a").index();
    //var jdata=$(this).parent("a").attr("data-url");
    //var jvalue=$(this).parent("a").attr("data-value");
    if (tnum != 0) {
        //$("#menu-list a[data-url='" + jdata + "'][data-value='" + jvalue + "']").remove();
        //$("#page-content .iframe-content[data-url='" + jdata + "'][data-value='" + jvalue + "']").remove();
        $("#menu-list a").eq(tnum).remove();
        $("#page-content .iframe-content").eq(tnum).remove();
        var nowShow = $("#menu-list a").length - 1;
        if ($(this).parent("a").hasClass("active")) {
            $("#page-content .iframe-content").eq(nowShow).addClass('active');
            $("#menu-list a").eq(nowShow).addClass("active");
        }
        $("#menu-all-ul li").eq(tnum).remove();
    }
    event.stopPropagation();
    createmenu();
});

//右键刷新
$(document).on("click", ".refresh", function (event) {
    $("#menu-list a.active").removeClass("active");
    $("#page-content iframe.active").removeClass("active");
    $("#page-content .iframe-content").eq(thisobjnum).addClass('active');
    $("#menu-list a").eq(thisobjnum).addClass("active");
    $("#page-content iframe").eq(thisobjnum).attr("src", $("#page-content iframe").eq(thisobjnum).attr("src"))
});


//右键删除
$(document).on("click", ".close", function (event) {
    if (thisobjnum != 0) {
        var jthis = $("#page-content .iframe-content").eq(thisobjnum)
        $("#menu-list a").eq(thisobjnum).remove();
        $("#menu-all-ul li").eq(thisobjnum).remove();
        $("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
        var nowShow = $("#page-content .iframe-content").length - 1;
        $("#page-content .iframe-content").eq(nowShow).addClass('active');
        $("#menu-list a").eq(nowShow).addClass("active");

    }
    createmenu();
});


//右键删除其它
$(document).on("click", ".close-other", function (event) {
    var numstr = $("#menu-list a").length;
    var listobj = $("#menu-list a");
    var contentobj = $("#page-content .iframe-content");
    var allobj = $("#menu-all-ul li");
    for (var i = 0; i < numstr; i++) {
        if (i != 0 && i != thisobjnum) {
            listobj.eq(i).remove();
            contentobj.eq(i).remove();
            allobj.eq(i).remove();
        }
    }
    if (!$("#menu-list a").eq(thisobjnum).hasClass("active")) {
        contentobj.eq(thisobjnum).addClass('active');
        listobj.eq(thisobjnum).addClass("active");
        allobj.eq(0).addClass("active");
    }
    createmenu();

});

//右键全部删除
$(document).on("click", ".close-all", function (event) {
    var numstr = $("#menu-list a").length;
    var listobj = $("#menu-list a");
    var contentobj = $("#page-content .iframe-content");
    var allobj = $("#menu-all-ul li");
    for (var i = 0; i < numstr; i++) {
        if (i != 0) {
            listobj.eq(i).remove();
            contentobj.eq(i).remove();
            allobj.eq(i).remove();
        }
    }
    if (!$("#menu-list a").eq(0).hasClass("active")) {
        contentobj.eq(0).addClass('active');
        listobj.eq(0).addClass("active");
        allobj.eq(0).addClass("active");
    }
    createmenu();

});

//点击右侧菜单
$(document).on("click", "#menu-all-ul li", function (event) {
    if ($(this).find("span").length > 0) { var tnum = $(this).index(); } else { var tnum = $(this).parent("li").index(); }
    $("#menu-list a.active").removeClass("active");
    $("#menu-list a").eq(tnum).addClass("active");
    $("#page-content iframe.active").removeClass("active");
    $("#page-content .iframe-content").eq(tnum).addClass("active");
    $("#menu-all-ul li.active").removeClass("active");
    $("#menu-all-ul li").eq(tnum).addClass("active");
    event.stopPropagation();
});

//关闭当前窗口
function closeThisMenu() {
    var closeMenuNum = 0;
    closeMenuNum = $("#menu-list a.active").index();
    if (closeMenuNum != 0) {
        var jthis = $("#page-content .iframe-content").eq(closeMenuNum)
        $("#menu-list a").eq(closeMenuNum).remove();
        //$("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
        jthis.remove();
    }
    var nowShow = $("#menu-list a").length - 1;
    $("#page-content .iframe-content").eq(nowShow).addClass('active');
    $("#menu-list a").eq(nowShow).addClass("active");
    $("#menu-all-ul li").eq(closeMenuNum).remove();
}

//关闭当前窗口并激活指定选项卡刷新
function closeThisAndRefMenu(navName) {
    //关闭的选项卡下标
    var closeMenuNum = 0;
    closeMenuNum = $("#menu-list a.active").index();
    if (closeMenuNum != 0) {
        var jthis = $("#page-content .iframe-content").eq(closeMenuNum)
        $("#menu-list a").eq(closeMenuNum).remove();
        jthis.remove();
    }

    //被激活刷新的选项卡下标
    var refreshMenuNum = 0;
    $("#menu-list a").each(function (i, ele) {
        if ($(ele).children("span").html() == navName) {
            refreshMenuNum = i
            return false;
        }
    });

    if (refreshMenuNum > closeMenuNum) refreshMenuNum = refreshMenuNum - 1;
    //如果指定的选项卡不存在，则定位到最后一个选项卡
    var activeIndex = $("#menu-list a").length - 1;
    if (refreshMenuNum > 0) activeIndex = refreshMenuNum;
    $("#page-content .iframe-content").eq(activeIndex).addClass('active');
    $("#menu-list a").eq(activeIndex).addClass("active");
    $("#menu-all-ul li").eq(closeMenuNum).remove();
    if (refreshMenuNum) $("#page-content iframe").eq(refreshMenuNum).attr("src", $("#page-content iframe").eq(refreshMenuNum).attr("src"))
}


//删除指定名称
function closeMenuName(navName) {
    var closeMenuNum = 0;
    $("#menu-list a").each(function (i, ele) {
        if ($(ele).children("span").html() == navName) {
            closeMenuNum = i
            return false;
        }
    });
    if (closeMenuNum != 0) {
        var jthis = $("#page-content .iframe-content").eq(closeMenuNum)
        $("#menu-list a").eq(closeMenuNum).remove();
        $("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
    }
    var nowShow = $("#menu-list a").length - 1;
    $("#page-content .iframe-content").eq(nowShow).addClass('active');
    $("#menu-list a").eq(nowShow).addClass("active");
    $("#menu-all-ul li").eq(closeMenuNum).remove();
}

//刷新指定名称
function refreshMenuName(navName) {
    var refreshMenuNum = 0;
    $("#menu-list a").each(function (i, ele) {
        if ($(ele).children("span").html() == navName) {
            refreshMenuNum = i
            return false;
        }
    });
    if (refreshMenuNum > 0) {
        $("#menu-list a.active").removeClass("active");
        $("#page-content iframe.active").removeClass("active");
        $("#page-content .iframe-content").eq(refreshMenuNum).addClass('active');
        $("#menu-list a").eq(refreshMenuNum).addClass("active");
        $("#page-content iframe").eq(refreshMenuNum).attr("src", $("#page-content iframe").eq(refreshMenuNum).attr("src"))
    }
}