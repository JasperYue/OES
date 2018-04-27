$(function() {
    loadingEffect();
    $("a[data-item='questionPanel']").click();
});
/* Hide the msgbox */
$(".close, .btn-group input:eq(1)").click(function() {
    $(".msgbox,.shade").hide();
});
/* toggle big pannel */
$("nav ul li a").click(function() {
    var currentPanel = $(this).parent().siblings().find("a").removeClass("panelChecked").attr("data-item");
    var targetPanel = $(this).addClass("panelChecked").attr("data-item");
    $("." + targetPanel).show();
    $("." + currentPanel).hide();
    if (targetPanel == 'questionPanel') {
        queryQuestionList();
    } else {
        queryExamList();
    }
});

/*------------------------About Ajax------------------------*/
/* Set the conditon in hidden*/
$(".questionPanel #questionList thead i").click(function() {
    $(this).toggleClass("decrease");
    if ($(this).hasClass("decrease")) {
        $(".questionPanel input[name='orderField']").val(1);
    } else {
        $(".questionPanel input[name='orderField']").val(0);
    }
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
$(".examPanel #examList thead i").click(function() {
    $(this).toggleClass("decrease");
    $(this).toggleClass("increase");
    var str = $(this).attr("data-item");
    if ($(this).hasClass("decrease")) {
        str += " ASC";
    } else {
        str += " DESC";
    }
    $("#examForm input[name='orderField']").val(str);
    queryExamList();
});
/* When select's option changed, send request to backend */
$(".questionPanel select[name='pageSize']").change(function() {
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
$(".examPanel select[name='pageSize']").change(function() {
    $(".examPanel input[name='pageNo']").val(1);
    queryExamList();
});
/* Fuzzy search */
$(".questionPanel .search").click(function() {
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
//TODO data validation
$(".examPanel .search, .queryDate").click(function() {
    /*
    if ($(this).hasClass('queryDate')) {
        var reg = /^((?:19|20)\d\d)-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])$/;
        var str = $(".examPanel input[name='timeBegin']").val();
        var arr = $(".examPanel input[name='timeEnd']").val();
        if (!str.match(reg) && !arr.match(reg)) {
            showAlert("Time Formatter error, example: 2016-11-01");
            return false;
        }
    }*/
    $(".examPanel input[name='pageNo']").val(1);
    queryExamList();
});
/* toTargetByPagination */
$(".questionPanel .pagination").delegate(".code", "click", function() {
    if ($(".questionPanel input[name='pageNo']").val() == $(this).text()) {
        return false;
    }
    $(".questionPanel input[name='pageNo']").val($(this).text());
    queryQuestionList();
});
$(".questionPanel .pagination").delegate(".prev, .next", "click", function() {
    if ($(".questionPanel input[name='pageNo']").val() == $(this).attr("data-item")) {
        return false;
    }
    $(".questionPanel input[name='pageNo']").val($(this).attr("data-item"));
    queryQuestionList();
});
$(".examPanel .pagination").delegate(".code", "click", function() {
    if ($(".examPanel input[name='pageNo']").val() == $(this).text()) {
        return false;
    }
    $(".examPanel input[name='pageNo']").val($(this).text());
    queryExamList();
});
$(".examPanel .pagination").delegate(".prev, .next", "click", function() {
    if ($(".examPanel input[name='pageNo']").val() == $(this).attr("data-item")) {
        return false;
    }
    $(".examPanel input[name='pageNo']").val($(this).attr("data-item"));
    queryExamList();
});
/* goTargetByInput */
$(".questionPanel .toolbar").delegate("a", "click", function() {
    //var target = parseInt($(".questionPanel #questionPageNo").val());
    var target = $(".questionPanel #questionPageNo").val();
    //TODO data validation
    /*
    // Pass 1:validate pageNo[numberic] not 12a aa 012  | -15 0
    if (!target.match(/^[0-9]+$/g)) {
        $(".questionPanel #questionPageNo").val("");
        showAlert("请输入有效的页码!");
        return false;
    }
    
    if (target <= 0) {
        target = 1;
    } else if (target >= 0x7fffffff) {
        target = 0x7fffffff;
    }
    */
    $(".questionPanel input[name='pageNo']").val(target);
    queryQuestionList();
});
$(".examPanel .toolbar").delegate("a", "click", function() {
    var target = $(".examPanel #examPageNo").val();
    //TODO data validation
    /*
    // Pass 1:validate pageNo[numberic] not 12a aa 012  | -15 0
    if (!target.match(/^[0-9]+$/g)) {
        $(".examPanel #examPageNo").val("");
        showAlert("请输入有效的页码!");
        return false;
    }
    
    if (target <= 0) {
        target = 1;
    } else if (target >= 0x7fffffff) {
        target = 0x7fffffff;
    }
    */
    $(".examPanel input[name='pageNo']").val(target);
    queryExamList();
});
/* Check all the checkbox whether it is checked */
function checkForm() {
    //TODO data validation
    if ($(".questionPanel :checkbox:not('#ckAll'):checked").size() > 0) {
        var url = "page/question/deleteQuestion"
        var data = $(".questionPanel #questionForm").serialize();
        $.post(url, data, function(msg) {
            queryQuestionList();
            hideMsgBox();
            showAlert(msg);
            //TODO 
            $(".questionPanel #ckAll").toggleClass("ckChecked").prop("checked", false);
            if ($(".questionPanel #ckAll").hasClass("ckChecked")) {
                $(".questionPanel #ckAll").removeClass("ckChecked");
            }
        }).error(function() {
            showAlert("Leaving time so long, need login again");
            setTimeout(function(){
                window.location.href="page/user/login";
            }, 2500);
        });
    } else {
        hideMsgBox();
        showAlert("No any entity Question selected.");
    }
}
$(".addPanel .cancelToList").prev().click(function() {
    var data = $(".examPanel #addForm").serialize();
    //TODO data
    /*
    var paramArr = ["name", "duration", "singleScore", "needQuantity", "totalScore", "passCriteria"];
    var dataArr = data.split("&");
    var flag = true;
    for (var i = 0; i < dataArr.length; i++) {
        var temp = dataArr[i].split("=");
        if (paramArr.indexOf(temp[0]) != -1 && temp[1] == "") {
            $(".examUlList input[name='" + temp[0] + "'], .examUlList textarea[name='" + temp[0] + "']").next("span").text("Field " + temp[0] + " for exam is required.");
            flag = false;
        } else {
            if (i > 1 && isNaN(temp[1])) {
                $(".examUlList input[name='"+ temp[0] +"']").next("span").text("Field " + temp[0] + " for exam is numberic.");
                flag = false;
            } else {
                $(".examUlList input[name='"+ temp[0] +"'], .examUlList textarea[name='"+ temp[0] +"']").next("span").text("");
            }
        }
    }
    var str = $(".examUlList input[name='effectiveTime']").val() + " " + $(".examUlList input[name='hour']").val() + ":" + $(".examUlList input[name='min']").val();
     
    if (!str.match(/^((?:19|20)\d\d)-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01]) (0\d{1}|1\d{1}|2[0-3]):([0-5]\d{1})$/)) {
        $(".examUlList input[name='min']").next("span").text("Field effectiveTime formatter error, example: 2016-11-01 11:00.");
        return;
    } else {
        $(".examUlList input[name='min']").next("span").text("");
    }
    
    if (!flag) {
        return;
    }
    */
    var url = "page/exam/addExam";
    $.post(url, data, function(result) {
        try {
            $(".examUlList li span:last-child").empty();
            $.each(result, function(i, j) {
                if (i == "name" || i == "effectiveTime" || i == "duration") {
                    $(".examUlList input[name='" + i + "']").siblings("span").text(j);
                } else {
                    var $obj = $(".examUlList input[name='" + i + "']").siblings("span");
                    $obj.text($obj.text() + "   " + j);
                }
            });
        } catch (e) {
            if (result.match("successfully")) {
                resetExamAll();
                queryExamList();
                /* Back to ListPanel*/
                toPanel("examPanel,list");
                showAlert(result);
            } else if (result.match("enough")) {
                showMsgBox(result, 1);
            } else {
                showAlert("Leaving time so long, need login again");
                setTimeout(function(){
                    window.location.href="page/user/login";
                }, 2500);
            }
        }
    });
});
function checkAll() {
    //TODO data
    var data = $(".questionPanel #addOrEditForm").serialize();
    /*
    var paramArr = ["title", "answer", "itemA", "itemB", "itemC", "itemD"];
    var arr = data.split("&");
    var flag = true;
    for (var i = 0; i < arr.length; i++) {
        var temp = arr[i].split("=");
        if (paramArr.indexOf(temp[0]) != -1 && temp[1] == "") {
            $(".questionUlList input[name='" + temp[0] + "'], .questionUlList textarea[name='" + temp[0] + "']").next("span").text("Field " + temp[0] + " for question is required.");
            flag = false;
        } else {
            $(".questionUlList input[name='" + temp[0] + "'], .questionUlList textarea[name='" + temp[0] + "']").next("span").text("");
        }
    }
    if (!flag) {
        return;
    }
    */
    var url = "page/question/addOrEditQuestion";
    $.post(url, data, function(result) {
        try {
            $(".questionUlList li span:last-child").empty();
            $.each(result, function(i, j) {
                $(".questionUlList input[name='" + i + "'], .questionUlList textarea[name='" + i + "']").next().text(j);
            });
        } catch (e) {
            if (result.match("successfully")) {
                resetQuestionAll();
                queryQuestionList();
                /* Back to ListPanel*/
                toPanel("questionPanel,list");
                showAlert(result);
            } else {
                showAlert("Leaving time so long, need login again");
                setTimeout(function(){
                    window.location.href="page/user/login";
                }, 2500);
            }
        }
    });
}
function toEdit(questionId) {
    var url="page/question/toEdit";
    $.post(url, {id : questionId}, function(question) {
       
        toPanel("questionPanel,"+question.num);
        
        $(".questionUlList li:eq(0)").append("<label>Question Num:</label><input type='text' name='num' value='" + question.num + "' readonly='readonly' />");
        
        $(".questionPanel input[name='id']").val(question.id);
        $(".questionPanel .question_title").val(question.title);
        $(".questionPanel input[name='itemA']").val(question.itemA);
        $(".questionPanel input[name='itemB']").val(question.itemB);
        $(".questionPanel input[name='itemC']").val(question.itemC);
        $(".questionPanel input[name='itemD']").val(question.itemD);
        
        $(".questionPanel input[type='radio']").removeClass("radioCK").prop("checked", false);
        
        $(".questionPanel input[class='questionInput questionAnswer']").removeClass("questionAnswer");
        
        $(".questionPanel input[type='radio'][value=" + question.answer + "]").prop("checked", true).
        toggleClass("radioCK").siblings(".questionPanel input[class='questionInput']").toggleClass("questionAnswer");
        
    }, "json").error(function() {
        showAlert("Leaving time so long, need login again");
        setTimeout(function(){
            window.location.href="page/user/login";
        }, 2500);
    });
}
function toDetail(questionId) {
    var url="page/question/toEdit";
    $.post(url, {id : questionId}, function(question) {
        // Pass 1: Reset content and style
        $(".questionDetailList li:gt(1) p").empty().removeClass("detailSelected");
        $(".questionPanel .nowBread").text(question.num);
        $(".questionPanel .list, .questionPanel.create").removeClass("selected");
        // Pass 2: Show panel
        $(".questionPanel .listPanel").hide().siblings(".detailPanel").show();
        
        $(".questionDetailList li:eq(0) p").text(question.num);
        
        $(".questionDetailList li:eq(1) div").html(question.title);
        $(".questionDetailList li:eq(1) div").attr("title", question.title);
        $(".questionDetailList li:eq(2) p").html("<i>A</i>" + question.itemA);
        $(".questionDetailList li:eq(3) p").html("<i>B</i>" + question.itemB);
        $(".questionDetailList li:eq(4) p").html("<i>C</i>" + question.itemC);
        $(".questionDetailList li:eq(5) p").html("<i>D</i>" + question.itemD);
        $(".questionDetailList li:eq(2) p").attr("title", question.itemA);
        $(".questionDetailList li:eq(3) p").attr("title", question.itemB);
        $(".questionDetailList li:eq(4) p").attr("title", question.itemC);
        $(".questionDetailList li:eq(5) p").attr("title", question.itemD);
        $(".questionDetailList li:eq(" + (1 + question.answer) + ") p").addClass("detailSelected");
        
        $(".questionDetailList + div > a:first").attr("onclick", "toEdit(" + question.id + ")");
        
        $(".questionDetailList + div > a:last").attr("onclick", "showMsgBox('Are you sure to delete " + question.num  + " ?', '" + question.num + "' )");
    }, "json").error(function() {
        showAlert("Leaving time so long, need login again");
        setTimeout(function(){
            window.location.href="page/user/login";
        }, 2500);
    });
}
/**
 * The common query list method by using Ajax, it can get parameters in form automaticlly
 */
function queryQuestionList() {
    var url="page/question/queryQuestionList";
    var data = $(".questionPanel #questionForm").serialize();
    $.post(url, data, function(jsonStr) {
        
        // Pass 1: Reset orderField
        if ($.trim(jsonStr["orderField"]) != "") {
            $(".questionPanel :input[type='hidden'][name='orderField']").val($.trim(jsonStr["orderField"]));
        }
        
        var page = jsonStr.page;
        
        // Pass 2: Reset pageNo
        $(".questionPanel :input[type='hidden'][name='pageNo']").val(page["pageNo"]);
        
        // Pass 3: Fill data in table
        $(".questionPanel #questionList tbody").empty();
        $.each(page.pageList, function(i, j) {
            /*
            var str = j["title"];
            var target = $(".questionPanel :input[name='titleStr']").val();
            if (target != "") {
                str = markUp(str, target);
            }
            */
            $(".questionPanel #questionList tbody").append("<tr>" +
                    "<td>" + ((page['pageNo'] - 1) * page['pageSize'] + parseInt(i + 1)) + "</td>" +
                    "<td>" + j["num"] + "</td>" +
                    "<td><a href='javascript:void(0)' onclick='toDetail(" + j["id"] + ")' title='" + j["title"] + "'>" + j["title"] + "</a></td>" +
                    "<td><a href='javascript:void(0)' onclick='toEdit(" + j['id'] + ")'></a></td>" +
                    "<td><input type='checkbox' name='delMark' class='ckUncheck' value='" + j["id"] + "' /></td>" +
                    "</tr>");
        });
        
        // Pass 4: Reset and fill parameter to pagination
        $(".questionPanel .pagination").empty();
        $(".questionPanel .pagination").prepend("<a href='javascript:void(0)' class='next' data-item='" + page['nextPage'] + "'></a>");
        var collection = page.paginationList;
        for (var i = page.paginationList.length - 1; i >= 0; i--) {
            if (collection[i] == page["pageNo"]) {
                $(".questionPanel .pagination").prepend("<a href='javascript:void(0)' class='code current'>" + collection[i] + "</a>");
            } else {
                $(".questionPanel .pagination").prepend("<a href='javascript:void(0)' class='code' >" + collection[i] + "</a>");
            }
        }
        $(".questionPanel .pagination").prepend("<a href='javascript:void(0)' class='prev' data-item='" + page['prevPage'] + "'></a>");
        $(".questionPanel .pagination").prepend("第&nbsp;" + page['pageNo'] + "&nbsp;页,共&nbsp;<span id='maxPageNo'>" + (page['totalPage']== 0 ? 1 : page['totalPage']) + "</span>&nbsp;页&nbsp;&nbsp;");
        
        // Pass 5: Amend the data in table if there has no data
        $(".questionPanel #questionList tbody:empty").html("<tr><td colspan='5'>No Record!</td></tr>");
    }, "json").error(function() {
        showAlert("Leaving time so long, need login again");
        setTimeout(function(){
            window.location.href="page/user/login";
        }, 2500);
    });
}
function queryExamList() {
    var url="page/exam/queryExamList";
    var data = $(".examPanel #examForm").serialize();
    $.post(url, data, function(jsonStr) {
        
        // Pass 1: Reset orderField
        if ($.trim(jsonStr["orderField"]) != "") {
            $(".examPanel :input[type='hidden'][name='orderField']").val($.trim(jsonStr["orderField"]));
        }
        
        var page = jsonStr.page;
        
        // Pass 2: Reset pageNo
        $(".examPanel :input[type='hidden'][name='pageNo']").val(page["pageNo"]);
        
        // Pass 3: Fill data in table
        $(".examPanel #examList tbody").empty();
        $.each(page.pageList, function(i, j) {
            /*
            var str = j["name"];
            var target = $(".examPanel :input[name='name']").val();
            if (target != "") {
                str = markUp(str, target);
            }
            */
            var status = j["status"];
            if (status == 2) {
                status = "<a style='background-color: #FE9901' href='javascript:void(0)'>Finished</a>";
            } else if (status == 1) {
                status = "<a style='background-color: #9da' href='javascript:void(0)'>In Use</a>";
            } else if (status == 0) {
                status = "<a style='background-color: #F2753F' href='javascript:void(0)'>Draft</a>";
            }
            $(".examPanel #examList tbody").append("<tr>" +
                    "<td>" + ((page['pageNo'] - 1) * page['pageSize'] + parseInt(i + 1)) + "</td>" +
                    "<td>" + j["num"] + "</td>" +
                    "<td><a href='javascript:void(0)' title='" + j["name"] + "'>" + j["name"] + "</a></td>" +
                    "<td>" + j["effectiveTime"] + "</td>" +
                    "<td>" + j["duration"] + "</td>" +
                    "<td>" + j["creator"] + "</td>" +
                    "<td>" + status + "</td>" +
                    "</tr>");
        });
        
        // Pass 4: Reset and fill parameter to pagination
        $(".examPanel .pagination").empty();
        $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='next' data-item='" + page['nextPage'] + "'></a>");
        var collection = page.paginationList;
        for (var i = page.paginationList.length - 1; i >= 0; i--) {
            if (collection[i] == page["pageNo"]) {
                $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='code current'>" + collection[i] + "</a>");
            } else {
                $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='code'>" + collection[i] + "</a>");
            }
        }
        $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='prev' data-item='" + page['prevPage'] + "'></a>");
        $(".examPanel .pagination").prepend("第&nbsp;" + page['pageNo'] + "&nbsp;页,共&nbsp;<span id='maxPageNo'>" + (page['totalPage']== 0 ? 1 : page['totalPage']) + "</span>&nbsp;页&nbsp;&nbsp;");
        
        // Pass 5: Amend the data in table if there has no data
        $(".examPanel #examList tbody:empty").html("<tr><td colspan='7'>No Record!</td><tr>");
        
    }, "json").error(function() {
        showAlert("Leaving time so long, need login again");
        setTimeout(function(){
            window.location.href="page/user/login";
        }, 2500);
    });
}

/*------------------------About Ajax------------------------*/
/* All check or not check at all */
$(".questionPanel #ckAll").click(function() {
    $(".questionPanel :checkbox:not('#ckAll')").prop("checked", this.checked);
});
$(".questionPanel tbody").delegate("input[type='checkbox']","click", function() {
    var size = $(".questionPanel :checkbox:not('#ckAll'):checked").size();
    var pageSize = $(".questionPanel select[name='pageSize']").val();
    var flag = size == pageSize ? true : false;
    $("#ckAll").prop("checked", flag);
});
$(".questionPanel .cancelToList").click(function() {
    resetQuestionAll();
    toPanel("questionPanel,list");
});
$(".examPanel .cancelToList").click(function() {
    resetExamAll();
    toPanel("examPanel,list");
});
/* toggle small panel*/
$(".questionPanel .list, .questionPanel .create").click(function() {
    $(this).addClass("selected").parent().siblings().find("a").removeClass("selected");
    $(".questionPanel ." + $(this).attr("data-item")).show();
    $(".questionPanel ." + $(this).parent().siblings().find("a").attr("data-item")).hide();
    $(".questionPanel .detailPanel").hide();
    $(".questionPanel .nowBread").text($(this).text());
    if ($(this).hasClass("create")) {
        /* When Click Create Question then reset all form*/
        resetQuestionAll();
        $(".questionPanel input[name='answer'][value='1']").addClass("radioCK").prop("checked", true).
        siblings(".questionPanel input[class='questionInput']").addClass("questionAnswer");
    }
});
$(".examPanel .list, .examPanel .create").click(function() {
    $(this).addClass("selected").parent().siblings().find("a").removeClass("selected");
    $(".examPanel ." + $(this).attr("data-item")).show();
    $(".examPanel ." + $(this).parent().siblings().find("a").attr("data-item")).hide();
    $(".examPanel .nowBread").text($(this).text());
    if ($(this).hasClass("create")) {
        /* When Click Create Exam then reset all form */
        resetExamAll();
    }
});
$(".questionPanel input[name='answer']").click(function() {
    $(".questionPanel input[type='radio'][name='answer']").removeClass("radioCK");
    $(".questionPanel input[class^='questionInput']").removeClass("questionAnswer");
    $(this).toggleClass("radioCK").prop("checked", this.checked).
    siblings(".questionPanel input[class='questionInput']").toggleClass("questionAnswer");
});
$(".msgbox input[value='Yes']").click(function() {
    var op = $(this).attr("data-item");
    if (op == "question") {
        checkForm();
    } else if (op == "exam") {
        hideMsgBox();
        $("#addForm input[name='saveFlag']").val("true");
        $(".addPanel .cancelToList").prev().click();
    } else {
        var id = parseInt(op.substr(1));
        var url = "page/question/deleteQuestion";
        $.post(url, {delMark : id}, function(result) {
            if (result.match("successfully")) {
                queryQuestionList();
                $(".questionPanel .list").click();
            }
            hideMsgBox();
            showAlert(result);
        }).error(function() {
            showAlert("Leaving time so long, need login again");
            setTimeout(function(){
                window.location.href="page/user/login";
            }, 2500);
        })
    }
})
/* Hide or Show */
function hideMsgBox() {
    $(".shade").hide();
    $(".msgbox").hide("fast");
};
function showMsgBox(str, option) {
    $(".msgbox h3").text(str);
    $(".shade").show();
    $(".msgbox,.shade").show("fast");
    if (option == 0) {
        $(".msgbox input[value='Yes']").attr("data-item","question");
    } else if (option == 1) {
        $(".msgbox input[value='Yes']").attr("data-item","exam");
    } else {
        $(".msgbox input[value='Yes']").attr("data-item", option);
    }
};
function showAlert(msg) {
    $(".alertbox h3").text(msg);
    $(".alertbox").show("fast", function() {
        setTimeout(function() {
            $(".alertbox,.shade").hide();
        }, 2500 );
    });
};
function resetQuestionAll() {
    $(".questionPanel #addOrEditForm")[0].reset();
    $(".questionPanel input[name='id']").val("");
    /* Clear num */
    $(".questionPanel .questionUlList li:eq(0)").empty();
    /* Clear All tips */
    $(".questionPanel .questionUlList li span").text("");
    /* Clear default checked*/
    $(".questionPanel input[type='radio']").removeClass("radioCK").prop("checked", false);
    $(".questionPanel input[class ~='questionAnswer']").removeClass("questionAnswer");
};
function resetExamAll() {
    $("#addForm")[0].reset();
    $(".examPanel .examUlList li span").text("");
}
function toPanel(str) {
    var panel = str.split(",");
    if (panel[1] == "list") {
        $("." + panel[0] + " ." + panel[1]).click();
    } else {
        $("." + panel[0] + " .create").click();
        $("." + panel[0] + " .nowBread").text(panel[1]);
        $("." + panel[0] + " .list,.create").removeClass("selected");
    }
}
function loadingEffect() {
    var loading = $('.spinner');
    loading.hide();
    $(document).ajaxStart(function () {
        loading.show();
    }).ajaxStop(function () {
        loading.hide();
    });
}
/*
function markUp(src, target) {
    target = $.trim(target);
    var len = target.length;
    var array = searchArr(src, target);
    var result = src.substring(0, array[0]);
    var prefix = "<font color='red'>";
    var subfix = "</font>";
    for (var i = 0; i < array.length; i++) {
        result += prefix;
        
        result += src.substr(array[i], len);
        
        result += subfix;
        
        if (array[i+1]) {
          result += src.substring(array[i] + len, array[i+1]);
        }
    }
    result += src.substr(array[array.length - 1] + len , src.length);
    
    return result;
}
function searchArr(src,target) {
    var arr = [];
    var startIndex = 0;
    var srcLow = src.toLowerCase();
    var targetLow = target.toLowerCase();
    while (true)
    {
        var location = srcLow.indexOf(targetLow, startIndex);
        if (location == -1){
            break;
        }
        arr.push(location);
        startIndex = location + target.length;
    }
    return arr;
}
*/