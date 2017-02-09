//For Right Slide
        var next_move = "closed";
        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyph-icon icon-elusive-search\"></i>");
        $(".right-slidePanel .slidePanel-btn, .right-slidePanel #rtSearch")
                .click(function () {
                    console.log(next_move);
                    var css = {};
                    if (next_move == "closed") {
                        css = {
                            right: '0'
                        };
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyph-icon icon-elusive-right\"></i>");
                        next_move = "shrink";
                    } else {
                        css = {
                            right: '-300px'
                        };
                        console.log('hi');
                        next_move = "closed";
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyph-icon icon-elusive-search\"></i>");
                    }
                    $(this).closest(".right-slidePanel").animate(css, 200);
                });
        $(".right-slidePanel .slidePanel-Content-fields").css('max-height', $(".k-grid").height() + 30);


        //For Grid Commands Icons
        function onRowBound(e) {
            $(".k-grid-Update, .Update_Icon").find("span").addClass("glyph-icon icon-pencil");
            $(".k-grid-Delete, .Delete_Icon").find("span").addClass("glyph-icon icon-trash");
            $(".Attache_Icon").find("span").addClass("glyph-icon icon-paperclip");
        }


        function showCommandIcons() {
            $(".Update_Icon").find("span").addClass("glyph-icon icon-pencil");
            $(".Delete_Icon").find("span").addClass("glyph-icon icon-trash");
            $(".Remove_Icon").find("span").addClass("glyph-icon icon-remove");
            $(".Attache_Icon").find("span").addClass("glyph-icon icon-paperclip");
            $(".Show_Icon").find("a").addClass("k-button k-button-icontext")
            $(".Show_Icon").find("a").html("<span class='glyph-icon icon-picture'></span>");
        }



        //Grid height
        var headerHeight = $("#page-header").height();
        var toolbarHeight = $("#ToolBar").height();
        var gridHeight =
            $(window).height() - headerHeight - toolbarHeight - 90;
        $(".k-grid").height(gridHeight);
        //$(".k-grid").css("max-height", gridHeight);