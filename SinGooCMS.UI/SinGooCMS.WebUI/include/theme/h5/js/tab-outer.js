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
                }, animatSpeed)
            } else {
                if (releft + selDom.width() > wwidth - operationWidth) {
                    nav.animate({
                        "margin-left": (left - releft + wwidth - selDom.width() - operationWidth) + "px"
                    }, animatSpeed)
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
                }, animatSpeed)
            }
        },
        closemenu = function () {
            console.log(this.parentElement);
            $(this.parentElement).animate({
                "width": "0",
                "padding": "0"
            }, 0, function () {
                var jthis = $(this);
                if (jthis.hasClass("active")) {
                    var linext = jthis.next();
                    if (linext.length > 0) {
                        linext.click();
                        move(linext)
                    } else {
                        var liprev = jthis.prev();
                        if (liprev.length > 0) {
                            liprev.click();
                            move(liprev)
                        }
                    }
                }
                this.remove();
                $("#page-content .iframe-content[data-url='" + jthis.data("url") + "'][data-value='" + jthis.data("value") + "']").remove()
            });
            top.event.stopPropagation()
        },
        init = function () {
            $("#page-prev").bind("click", function () {
                var nav = $("#menu-list");
                var left = parseInt(nav.css("margin-left"));
                if (left !== 0) {
                    nav.animate({
                        "margin-left": (left + scrollSetp > 0 ? 0 : (left + scrollSetp)) + "px"
                    }, animatSpeed)
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
                    }, animatSpeed)
                }
            });
            $("#page-operation").bind("click", function () {
                var menuall = $("#menu-all");
                if (menuall.is(":visible")) {
                    menuall.hide()
                } else {
                    menuall.show()
                }
            });
            $("body").bind("mousedown", function (event) {
                if (!(event.target.id === "menu-all" || event.target.id === "menu-all-ul" || event.target.id === "page-operation" || event.target.id === "page-operation" || event.target.parentElement.id === "menu-all-ul")) {
                    $("#menu-all").hide()
                }
            })
        };
    $.fn.tab = function () {
        init();        

        this.bind("click", function () {
            var linkUrl = this.href;
            var linkHtml = this.text.trim();
            var selDom = top.$("#menu-list a[data-url='" + linkUrl + "'][data-value='" + linkHtml + "']");
            if (selDom.length === 0) {
                var iel = $("<i>", {
                    "class": "menu-close iconfont",
                    "html":"&#xe641;"
                }).bind("click", closemenu);

                $("<a>", {
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
                    top.event.stopPropagation()
                }).appendTo(top.$("#menu-all-ul"));
                
                createmove()
            } else {
                move(selDom)
            }
            linkframe(linkUrl, linkHtml);
            return false;
        });
        return this;
    }

})();