//For Right Slide
        var next_move = "closed";
        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-search\"></i>");
        $(".right-slidePanel .slidePanel-btn, .right-slidePanel #rtSearch")
                .click(function () {
                    console.log(next_move);
                    var css = {};
                    if (next_move == "closed") {
                        css = {
                            right: '0'
                        };
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-chevron-right\"></i>");
                        next_move = "shrink";
                    } else {
                        css = {
                            right: '-300px'
                        };
                        console.log('hi');
                        next_move = "closed";
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-search\"></i>");
                    }
                    $(this).closest(".right-slidePanel").animate(css, 200);
                });
        $(".right-slidePanel .slidePanel-Content-fields").css('max-height', $(".k-grid").height() + 30);


        //For Grid Commands Icons
        function onRowBound(e) {
            $(".k-grid-Update, .Update_Icon").find("span").addClass("glyphicon glyphicon-pencil");
            $(".k-grid-Delete, .Delete_Icon").find("span").addClass("glyphicon glyphicon-trash");
            $(".Attache_Icon").find("span").addClass("glyphicon glyphicon-paperclip");
        }


        function showCommandIcons() {
            $(".Update_Icon").find("span").addClass("glyphicon glyphicon-pencil");
            $(".Delete_Icon").find("span").addClass("glyphicon glyphicon-trash");
            $(".Remove_Icon").find("span").addClass("glyphicon glyphicon-remove");
            //$(".Attache_Icon").find("span").addClass("glyphicon glyphicon-paperclip");
            $(".Show_Icon").find("a").addClass("k-button k-button-icontext")
            $(".Show_Icon").find("a").html("<span class='glyphicon glyphicon-picture'></span>");
        }