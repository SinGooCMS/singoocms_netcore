//v1.2
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
            var nav = $("#menu-list");
            var releft = selDom.offset().left;
            var wwidth = parseInt($("#page-tab").width());
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
            var nav = $("#menu-list");
            var wwidth = parseInt($("#page-tab").width());
            var navwidth = parseInt(nav.width());
            if (wwidth - operationWidth < navwidth) {
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
                console.log(nowShow);
                top.$("#page-content .iframe-content").eq(nowShow).addClass("active");
                top.$("#menu-list a").eq(nowShow).addClass("active");

             
         
              

                top.$("#menu-all-ul li").each(function(i,ele){
                    if($(ele).find("span").attr("title")==$(jthis.attr("data-value")).html()){
                        $(ele).remove();
                    }
                })
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

        this.bind("click", function (event) {

            if($(this).attr("confirm")){
                //弹出对话框并点击确认后打开新的选项卡
                    var confirmMsg=top.confirm("确定打开吗？");
                    if(confirmMsg){
                            var linkUrl = this.href;

                            var testIconFont=$(this).hasClass("iconfont")?true:false;
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
                                }).bind("click", function () {
                                    var jthis = $(this);
                                    linkframe(jthis.data("url"), jthis.data("value"));
                                    move($("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']"));
                                    top.$("#menu-all").hide();
                                    top.event.stopPropagation();
                                }).appendTo(top.$("#menu-all-ul"));
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
                
                    var linkUrl = this.href;
                    var testIconFont=$(this).hasClass("iconfont")?true:false;
                    var linkHtml = testIconFont?"<span title='"+this.text.trim().slice(1)+"'>"+this.text.trim().slice(1)+"</span>":"<span title='"+this.text.trim()+"'>"+this.text.trim()+"</span>";
                    var selDom = top.$("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']");
                    if (selDom.length === 0) {
                        var iel = $("<i>", {
                            "class": "menu-close iconfont",
                            "html":"&#xe641;"
                        }).on("click", closemenu);

                        $("<a>",{
                            "html": linkHtml,
                            "href": "javascript:void(0);",
                            "data-url": linkUrl,
                            "data-value": linkHtml
                        }).on("click", function () {
                            var jthis = $(this);//这里出了问题导致母窗口关闭口，子窗口无法获取
                            console.log(jthis);
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
                        }).bind("click", function () {
                            var jthis = $(this);
                            linkframe(jthis.data("url"), jthis.data("value"));
                            move($("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']"));
                            top.$("#menu-all").hide();
                            top.event.stopPropagation();
                        }).appendTo(top.$("#menu-all-ul"));
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


function rightClick(obj,callback){
    var menu,thisobjnum,thisobjname;
    if (!menu) {
        $("<div id='wrapper'><div class='wrapper-sline'></div><div class='wrapper-li refresh'>刷新<span class='refresh-span iconfont'></span></div><div class='wrapper-line'></div><div class='wrapper-li close'>关闭<span class='close-span iconfont'></span></div><div class='wrapper-li close-other'>关闭其它</div><div class='wrapper-li close-all'>关闭全部</div></div>").appendTo('body').hide();
    }
     
    $("#menu-list").bind("contextmenu",function(e){
        //thisobjnum=$(this).children("a").index();
        //得到点击标题
        thisobjname=e.target.title
        //得到点击序号
         parent.$("#menu-list a").each(function(i,ele){
            //console.log($(ele).children("span").html());
             if($(ele).children("span").html()==thisobjname){
                thisobjnum=i  
                return false;    
             }
        })
         //console.log(thisobjnum);
        //当为第1个时取消关闭按钮
        if(thisobjnum==0){
            $(".close").addClass('prohibit');
        }else{
            $(".close").removeClass('prohibit');
        } 
        var key = e.which; //获取鼠标键位  
        if(key == 3)  //(1:代表左键； 2:代表中键； 3:代表右键)  
        {//获取右键点击坐标 
            var x = e.clientX;  
            var y = e.clientY;  
            $("#wrapper").show().css({left:x,top:y});
             return false;
        }
    });  
    //点击任意部位隐藏  
    $(document).click(function(){  
        parent.$("#wrapper").hide();  
    })
    $("a").click(function(event) {
         parent.$("#wrapper").hide(); 
    });
    /*$("#wrapper").mouseout(function(){
        parent.$("#wrapper").hide();
    }); */


    //刷新
    $(".refresh").click(function() {
       parent.$("#page-content iframe").eq(thisobjnum).attr("src",parent.$("#page-content iframe").eq(thisobjnum).attr("src"))
    });

    //删除
      $(".close").click(function() {
       if(thisobjnum!=0){
        var jthis = parent.$("#page-content .iframe-content").eq(thisobjnum)
         parent.$("#menu-list a").eq(thisobjnum).remove();
         parent.$("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
         var nowShow=parent.$("#page-content .iframe-content").length-1;
         parent.$("#page-content .iframe-content").eq(nowShow).addClass('active');
         parent.$("#menu-list a").eq(nowShow).addClass("active");
       }
       createmenu();
    });



    //删除其它
      $(".close-other").click(function() {
       var numstr=parent.$("#menu-list a").length;
        var listobj = parent.$("#menu-list a");
        var contentobj = parent.$("#page-content .iframe-content");
        for (var i = 0; i <numstr; i++) {
            if(i!=0&&i!=thisobjnum){
                 listobj.eq(i).remove();
                 contentobj.eq(i).remove();
              }  
        }
        if(!$("#menu-list a").eq(thisobjnum).hasClass("active")){
         contentobj.eq(thisobjnum).addClass('active');
         listobj.eq(thisobjnum).addClass("active");
        }
        createmenu();

    });

    //全部删除
      $(".close-all").click(function() {
        var numstr=parent.$("#menu-list a").length;
        var listobj = parent.$("#menu-list a");
        var contentobj = parent.$("#page-content .iframe-content");
        for (var i = 0; i <numstr; i++) {
            if(i!=0){
                 listobj.eq(i).remove();
                 contentobj.eq(i).remove();
              }  
        }
        if(!$("#menu-list a").eq(0).hasClass("active")){
         contentobj.eq(0).addClass('active');
         listobj.eq(0).addClass("active");
         }
       createmenu();

    });


}

 function createmenu () {
            var nav = $("#menu-list");
            var wwidth = parseInt($("#page-tab").width());
            var navwidth = parseInt(nav.width());
            if (wwidth - 90 < navwidth) {
                nav.animate({
                    "margin-left": "-" + (navwidth - wwidth + 90) + "px"
                }, animatSpeed);
            }
        }

//删除指定名称
function closeMenuName(navName){
        var closeMenuNum=0;
        parent.$("#menu-list a").each(function(i, ele) {
           if($(ele).children("span").html()==navName){
                closeMenuNum=i  
                return false;    
             }
        });
        if(closeMenuNum!=0){
            var jthis = parent.$("#page-content .iframe-content").eq(closeMenuNum)
             parent.$("#menu-list a").eq(closeMenuNum).remove();
             parent.$("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove();
        }
    }
//刷新指定名称
function refreshMenuName(navName){
        var refreshMenuNum=0;
        parent.$("#menu-list a").each(function(i, ele) {
           if($(ele).children("span").html()==navName){
                closeMenuNum=i  
                return false;    
             }
        });
         parent.$("#page-content iframe").eq(closeMenuNum).attr("src",parent.$("#page-content iframe").eq(closeMenuNum).attr("src"))
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


