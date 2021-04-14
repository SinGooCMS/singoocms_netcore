(function () {
    var scrollSetp = 500,
        operationWidth = 90,
        leftOperationWidth = 30,
        animatSpeed = 150,
        linkframe = function (url, value) {
            top.$("#menu-list a.active").removeClass("active");
            top.$("#menu-list a[data-url='" + url + "'][data-value='" + value + "']").addClass("active");
            top.$("#page-content iframe.active").removeClass("active");
            top.$("#page-content .iframe-content[data-url='" + url + "'][data-value='" + value + "']").addClass("active");
            top.$("#menu-all-ul li.active").removeClass("active");
            top.$("#menu-all-ul li[data-url='" + url + "'][data-value='" + value + "']").addClass("active");
            
        },
        move = function (selDom) {

            var nav = top.$("#menu-list");
            var releft = selDom.offset().left;
            var wwidth = parseInt(top.$("#page-tab").width());
            var left = parseInt(nav.css("margin-left"));
            if (releft < 0 && releft <= wwidth) {
                nav.animate({
                    "margin-left": (left - releft + leftOperationWidth) + "px"
                }, animatSpeed);
            } else {
                if (releft + selDom.width() > wwidth - operationWidth) {
                    nav.animate({
                        "margin-left": (left - releft + wwidth - selDom.width() - operationWidth) + "px"
                    }, animatSpeed);
                }
            }
        },
        createmove = function () {
            var nav = top.$("#menu-list");
            var wwidth = parseInt(top.$("#page-tab").width());
            var navwidth = parseInt(nav.width());
            if (wwidth - operationWidth < navwidth) {
                //console.log(navwidth - wwidth + operationWidth);
                nav.animate({
                    "margin-left": "-" + (navwidth - wwidth + operationWidth) + "px"
                }, animatSpeed);
            }
        },
        closemenu = function (event) {
            $(this.parentElement).animate({
                "width": "0",
                "padding": "0"
            }, 0, function () {
                var jthis = $(this);
                console.log(jthis);
                if (jthis.hasClass("active")) {
                    var linext = jthis.next();
                    if (linext.length > 0) {
                        linext.click();
                        move(linext);
                    } else {
                        var liprev = jthis.prev();
                        if (liprev.length > 0) {
                            liprev.click();
                            move(liprev);
                        }
                    }
                }

                this.remove();

                top.$("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
                
                var nowShow=top.$("#page-content .iframe-content").length-1;
                top.$("#page-content .iframe-content").eq(nowShow).addClass("active");
                top.$("#menu-list a").eq(nowShow).addClass("active");
                top.$("#menu-all-ul li").each(function(i,ele){
                    if($(ele).find("span").attr("title")==$(jthis.attr("data-value")).html()){
                        $(ele).remove();
                    }
                })
                console.log(this);
            });
            event.stopPropagation();
        },
        init = function () {
            $("#page-prev").bind("click", function () {
                var nav = $("#menu-list");
                var left = parseInt(nav.css("margin-left"));
                if (left !== 0) {
                    nav.animate({
                        "margin-left": (left + scrollSetp > 0 ? 0 : (left + scrollSetp)) + "px"
                    }, animatSpeed);
                }
            });
            $("#page-next").bind("click", function () {
                var nav = $("#menu-list");
                var left = parseInt(nav.css("margin-left"));
                var wwidth = parseInt($("#page-tab").width());
                var navwidth = parseInt(nav.width());
                var allshowleft = -(navwidth - wwidth + operationWidth);
                if (allshowleft !== left && navwidth > wwidth - operationWidth) {
                    var temp = (left - scrollSetp);
                    nav.animate({
                        "margin-left": (temp < allshowleft ? allshowleft : temp) + "px"
                    }, animatSpeed);
                }
            });
            $("#page-operation").bind("click", function () {
                var menuall = $("#menu-all");
                if (menuall.is(":visible")) {
                    menuall.hide();
                } else {
                    menuall.show();
                }
            });

            $("body").bind("mousedown", function (event) {
                if (!(event.target.id === "menu-all" || event.target.id === "menu-all-ul" || event.target.id === "page-operation" || event.target.id === "page-operation" || event.target.parentElement.id === "menu-all-ul")) {
                    $("#menu-all").hide();
                }
            })
        };
    jQuery.fn.tab = function () {
        init();
        var _this=this;
        rightClick(_this,function(){
            console.log("right");
        })

        //this.on("click", function (event) { //异步渲染模板之后，获取不到对象 this无效
        $("body").on("click", ".menu a,.tab-a",function (event) {
            if($(this).attr("confirm")){
                //弹出对话框并点击确认后打开新的选项卡
                var confirmMsg=top.confirm("确定打开吗？");
                if(confirmMsg){
                    var linkUrl = this.href;
                    var testIconFont = ($(this).find("i").hasClass("iconfont") || $(this).find("span").hasClass("iconfont")) ? true : false;
                    var linkHtml = testIconFont?"<span title='"+this.text.trim().slice(1)+"'>"+this.text.trim().slice(1)+"</span>":"<span title='"+this.text.trim()+"'>"+this.text.trim()+"</span>";
                    var selDom = top.$("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']");
                    if (selDom.length === 0) {
                        var iel = $("<i>", {
                            "class": "menu-close iconfont",
                            "html":"&#xe641;"
                        }).bind("click", closemenu);

                        $("<a>",{
                            "html": linkHtml,
                            "href": "javascript:void(0);",
                            "data-url": linkUrl,
                            "data-value": linkHtml
                        }).bind("click", function () {
                            var jthis = $(this);
                                    
                        linkframe(jthis.data("url"), jthis.data("value"));
                        }).append(iel).appendTo(top.$("#menu-list"));
                        $("<iframe>", {
                            "class": "iframe-content",
                            "data-url": linkUrl,
                            "data-value": linkHtml,
                            src: linkUrl
                        }).appendTo(top.$("#page-content"));


                        $("<li>", {
                            "html": linkHtml,
                            "data-url": linkUrl,
                            "data-value": linkHtml
                        }).appendTo(top.$("#menu-all-ul"));/*
                        .bind("click", function(){
                            var jthis = $(this);
                            linkframe(jthis.data("url"), jthis.data("value"));
                            move($("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']"));
                            top.$("#menu-all").hide();
                            top.event.stopPropagation();
                        })*/
                        createmove();
                    } else {
                        move(selDom);
                    }
                    linkframe(linkUrl, linkHtml);
                    return false;           
                }else{
                    return false;
                }
            }else{
                //直接添加选项卡
                    //console.log(this);
                    var linkUrl = this.href;
                    var testIconFont = ($(this).find("i").hasClass("iconfont") || $(this).find("span").hasClass("iconfont")) ? true : false;
                    var linkHtml = testIconFont?"<span title='"+this.text.trim().slice(1)+"'>"+this.text.trim().slice(1)+"</span>":"<span title='"+this.text.trim()+"'>"+this.text.trim()+"</span>";
                    var selDom = top.$("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']");
                    if (selDom.length === 0) {
                        var iel = top.$("<i>", {
                            "class": "menu-close iconfont",
                            "html":"&#xe641;"
                        })/*.on("click", closemenu);*/

                        top.$("<a>",{
                            "html": linkHtml,
                            "href": "javascript:void(0);",
                            "data-url": linkUrl,
                            "data-value": linkHtml
                        }).append(iel).appendTo(top.$("#menu-list"));/*.on("click", function () {
                            var jthis = $(this);
                            console.log(jthis);
                            linkframe(jthis.data("url"), jthis.data("value"));
                        })*/

                        top.$("<iframe>", {
                            "class": "iframe-content",
                            "data-url": linkUrl,
                            "data-value": linkHtml,
                            src: linkUrl
                        }).appendTo(top.$("#page-content"));


                        top.$("<li>", {
                            "html": linkHtml,
                            "data-url": linkUrl,
                            "data-value": linkHtml
                        }).appendTo(top.$("#menu-all-ul"));/*.bind("click", function () {
                            var jthis = $(this);
                            linkframe(jthis.data("url"), jthis.data("value"));
                            move($("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']"));
                            top.$("#menu-all").hide();
                            event.stopPropagation();
                        })*/
                        createmove();
                    } else {
                        move(selDom);
                    }
                    linkframe(linkUrl, linkHtml);
                    return false;                
            }

        });
        return this;
    }
})();

 /*方法重写
$("#menu-list").on("click",function(event){
    console.log(event.target);
    event.stopPropagation();
});*/
/*
$("#menu-list a",top.document).on('click', function(event) {
     var tnum=$(this).index();
     // console.log(tnum);
    $("#menu-list a.active",top.document).removeClass("active");
    $("#menu-list a",top.document).eq(tnum).addClass("active");
    $("#page-content iframe.active",top.document).removeClass("active");
    $("#page-content .iframe-content",top.document).eq(tnum).addClass("active");
    $("#menu-all-ul li.active",top.document).removeClass("active");
    $("#menu-all-ul li",top.document).eq(tnum).addClass("active");
    event.stopPropagation();
});

$("#menu-list .menu-close",top.document).on("click",function(event){
    var tnum=$(this).parent("a").index();
    var jdata=$(this).parent("a").attr("data-url");
    var jvalue=$(this).parent("a").attr("data-value");
    if(tnum!=0){
        //var jthis = $("#page-content .iframe-content",top.document).eq(tnum);
        $("#menu-list a[data-url='" + jdata + "'][data-value='" + jvalue + "']",top.document).remove();
        $("#page-content .iframe-content[data-url='" + jdata + "'][data-value='" + jvalue + "']",top.document).remove();
         //$("#menu-list a",top.document).eq(tnum).remove();
         //$("#page-content .iframe-content",top.document).eq(tnum).remove();
        // var nowShow=$("#menu-list a",top.document).length-1;
         if($(this).parent("a").hasClass("active")){
            // console.log(nowShow);
             $("#page-content .iframe-content",top.document).eq(nowShow).addClass('active');
             $("#menu-list a",top.document).eq(nowShow).addClass("active");
         }
       }
    event.stopPropagation();
    createmenu();
    
});
*/

function rightClick(obj,callback){
    
    /*$("#wrapper").mouseout(function(){
        parent.$("#wrapper").hide();
    }); */


    


}

 function createmenu () {
            var nav = top.$("#menu-list");
            var wwidth = parseInt(top.$("#page-tab").width());
            var navwidth = parseInt(nav.width());
            if (wwidth - 90 < navwidth) {
                nav.animate({
                    "margin-left": "-" + (navwidth - wwidth + 90) + "px"
                }, 150);
            }else{
                nav.animate({
                    "margin-left": "0px"
                }, 150);
            }
        }




$(document).ready(function(){
    var nowlength;
    function closeNow(){
    $(".closeNowBtn").each(function(i,ele){
            $(ele).click(function(){
            nowlength=top.$("#menu-list a").length;    
            top.$("#menu-list a.active").remove();
            top.$("#page-content .iframe-content").find("active").remove();
            top.$("#menu-list a").eq(nowlength-2).addClass("active");
            top.$("#page-content .iframe-content").eq(nowlength-2).addClass('active'); 
        })
    })


}
    closeNow();
    
})
