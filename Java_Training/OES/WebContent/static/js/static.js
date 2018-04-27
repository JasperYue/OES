$(function(){
    $("a[data-item='questionPanel']").click();
});
/* Hide the msgbox */
$(".close, .btn-group input:eq(1)").click(function(){
    $(".msgbox,.shade").hide();
});
/* toggle big pannel */
$("nav ul li a").click(function(){
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
$(".questionPanel #questionList thead i").click(function(){
    $(this).toggleClass("decrease");
    if ($(this).hasClass("decrease")) {
        $(".questionPanel input[name='orderField']").val(1);
    } else {
        $(".questionPanel input[name='orderField']").val(0);
    }
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
$(".examPanel #examList thead i").click(function(){
    $(this).toggleClass("decrease");
    var str = $(this).attr("data-item");
    if ($(this).hasClass("decrease")) {
        str += " ASC";
    } else {
        str += " DESC";
    }
    $("#examForm input[name='orderField']").val(str);
    queryExamList();
});
/* When select's option changed,send request to backend */
$(".questionPanel select[name='pageSize']").change(function(){
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
$(".examPanel select[name='pageSize']").change(function(){
    $(".examPanel input[name='pageNo']").val(1);
    queryExamList();
});
/* Fuzzy search */
$(".questionPanel .search").click(function(){
    $(".questionPanel input[name='pageNo']").val(1);
    queryQuestionList();
});
$(".examPanel .search, .queryDate").click(function(){
    $(".examPanel input[name='pageNo']").val(1);
    queryExamList();
});
/* toTargetByPagination */
$(".questionPanel .pagination").delegate(".code", "click", function(){
    if ($(".questionPanel input[name='pageNo']").val() == $(this).text()){
        return false;
    }
    $(".questionPanel input[name='pageNo']").val($(this).text());
    queryQuestionList();
});
$(".questionPanel .pagination").delegate(".prev, .next", "click", function(){
    if ($(".questionPanel input[name='pageNo']").val() == $(this).attr("data-item")){
        return false;
    }
    $(".questionPanel input[name='pageNo']").val($(this).attr("data-item"));
    queryQuestionList();
});
$(".examPanel .pagination").delegate(".code", "click", function(){
    if ($(".examPanel input[name='pageNo']").val() == $(this).text()){
        return false;
    }
    $(".examPanel input[name='pageNo']").val($(this).text());
    queryExamList();
});
$(".examPanel .pagination").delegate(".prev, .next", "click", function(){
    if ($(".examPanel input[name='pageNo']").val() == $(this).attr("data-item")) {
        return false;
    }
    $(".examPanel input[name='pageNo']").val($(this).attr("data-item"));
    queryExamList();
});
/* goTargetByInput */
$(".questionPanel .toolbar").delegate("a", "click", function(){
    var target = parseInt($(".questionPanel #questionPageNo").val());
    
    // Pass 1:validate pageNo[numberic] not 12a aa 012  | -15 0
    if(isNaN(target)) {
        $(".questionPanel #questionPageNo").val("");
        showAlert("请输入有效的页码!");
        return false;
    }
    
    if (target <= 0) {
        target = 1;
    }
    
    $(".questionPanel input[name='pageNo']").val(target);
    queryQuestionList();
});
$(".examPanel .toolbar").delegate("a", "click", function(){
    var target = parseInt($(".examPanel #examPageNo").val());
    
    // Pass 1:validate pageNo[numberic] not 12a aa 012  | -15 0
    if(isNaN(target)) {
        $(".examPanel #examPageNo").val("");
        showAlert("请输入有效的页码!");
        return false;
    }
    
    if (target <= 0) {
        target = 1;
    }
    
    $(".examPanel input[name='pageNo']").val(target);
    queryExamList();
});
/* Check all the checkbox whether it is checked */
function checkForm(){
    if ($(".questionPanel :checkbox:not('#ckAll'):checked").size() > 0) {
        var url = "deleteQuestion.action"
        var data = $(".questionPanel #questionForm").serialize();
        $.post(url, data, function(msg) {
            queryQuestionList();
            hideMsgBox();
            showAlert(msg);
            $(".questionPanel #ckAll").toggleClass("ckChecked").prop("checked",false);
            if ($(".questionPanel #ckAll").hasClass("ckChecked")) {
                $(".questionPanel #ckAll").removeClass("ckChecked");
            }
        });
    } else {
        hideMsgBox();
        showAlert("No any entity Question selected.");
    }
}
$(".addPanel .cancelToList").prev().click(function(){
    var data = $(".examPanel #addForm").serialize();
    //TODO
    var paramArr = ["name", "duration", "singleScore", "needQuantity", "totalScore", "passCriteria"];
    var dataArr = data.split("&");
    var flag = true;
    for (var i = 0; i < dataArr.length; i++) {
        var temp = dataArr[i].split("=");
        if (paramArr.indexOf(temp[0]) != -1 && temp[1] == "") {
            $(".examUlList input[name='"+ temp[0] +"'], .examUlList textarea[name='"+ temp[0] +"']").next("span").text("Field " + temp[0] + " for exam is required.");
            flag = false;
        } else {
            $(".examUlList input[name='"+ temp[0] +"'], .examUlList textarea[name='"+ temp[0] +"']").next("span").text("");
        }
    }
    var str = $(".examUlList input[name='effectiveTime']").val() + " " + $(".examUlList input[name='hour']").val() + ":" + $(".examUlList input[name='min']").val();
     
    if (!str.match(/^((?:19|20)\d\d)-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01]) (0\d{1}|1\d{1}|2[0-3]):([0-5]\d{1})$/)) {
        $(".examUlList input[name='min']").next("span").text("Field effectiveTime for exam is required.");
        return;
    } else {
        $(".examUlList input[name='min']").next("span").text("");
    }
    if (!flag) {
        return;
    }
    var url = "addExam.action";
    $.post(url, data, function(result){
        try {
            var jsonStr = JSON.parse(result);
            $(".examUlList li span:last-child").empty();
            $.each(jsonStr,function(i,j){
                if (i == "name" || i == "effectiveTime" || i == "duration") {
                    $(".examUlList input[name='"+ i +"']").next("span").text(j);
                } else {
                    var $obj = $(".examUlList input[name='"+ i +"']").siblings("span");
                    $obj.text($obj.text() + "   " + j);
                }
            });
        } catch (e) {
            if (result.match("successfully")){
                resetExamAll();
                queryExamList();
                /* Back to ListPanel*/
                toPanel("examPanel,list");
                showAlert(result);
            }else {
                showMsgBox(result,1);
            }
        }
    });
});
function checkAll(){
    var data = $(".questionPanel #addOrEditForm").serialize();
    var paramArr = ["title", "answer", "itemA", "itemB", "itemC", "itemD"];
    var arr = data.split("&");
    var flag = true;
    for (var i = 0; i < arr.length; i++) {
        var temp = arr[i].split("=");
        if (paramArr.indexOf(temp[0]) != -1 && temp[1] == "") {
            $(".questionUlList input[name='"+ temp[0] +"'], .questionUlList textarea[name='"+ temp[0] +"']").next("span").text("Field " + temp[0] + " for question is required.");
            flag = false;
        } else {
            $(".questionUlList input[name='"+ temp[0] +"'], .questionUlList textarea[name='"+ temp[0] +"']").next("span").text("");
        }
    }
    if (!flag) {
        return;
    }
    var url = "addOrEditQuestion.action";
    $.post(url, data, function(result){
        try {
            var jsonStr = JSON.parse(result);
            $(".questionUlList li span:last-child").empty();
            $.each(jsonStr,function(i,j){
                $(".questionUlList input[name='"+ i +"'], .questionUlList textarea[name='"+ i +"']").next().text(j);
            });
        } catch (e) {
            if (result.match("successfully")){
                resetQuestionAll();
                queryQuestionList();
                /* Back to ListPanel*/
                toPanel("questionPanel,list");
                showAlert(result);
            } else {
                showAlert(result);
            }
        }
    });
}
function toEdit(questionId){
    var url="toEdit.action";
    $.post(url, { id : questionId}, function(question){
       
        toPanel("questionPanel,"+question.num);
        
        $(".questionUlList li:eq(0)").append("<label>Question Num:</label><input type='text' name='num' value='"+ question.num +"' readonly='readonly' />");
        
        $(".questionPanel input[name='id']").val(question.id);
        $(".questionPanel .question_title").val(question.title);
        $(".questionPanel input[name='itemA']").val(question.itemA);
        $(".questionPanel input[name='itemB']").val(question.itemB);
        $(".questionPanel input[name='itemC']").val(question.itemC);
        $(".questionPanel input[name='itemD']").val(question.itemD);
        
        $(".questionPanel input[type='radio']").removeClass("radioCK").prop("checked",false);
        
        $(".questionPanel input[class='questionInput questionAnswer']").removeClass("questionAnswer");
        
        $(".questionPanel input[type='radio'][value="+ question.answer +"]").prop("checked",true).
        toggleClass("radioCK").siblings(".questionPanel input[class='questionInput']").toggleClass("questionAnswer");
        
    }, "json");
}
/**
 * The common query list method by using Ajax, it can get parameters in form automaticlly
 */
function queryQuestionList() {
    var url="queryQuestionList.action";
    var data = $(".questionPanel #questionForm").serialize();
    $.post(url, data, function(jsonStr) {
        
        // Pass 1: Reset title
        $(".questionPanel :input[name='titleStr']").val(removeSlash(removePercent($.trim(jsonStr["title"]))));
        
        // Pass 2: Reset orderField
        if ($.trim(jsonStr["orderField"]) != "") {
            $(".questionPanel :input[type='hidden'][name='orderField']").val($.trim(jsonStr["orderField"]));
        }
        
        // Pass 3: Reset pageSize
        var page = jsonStr.page;
        /* Keep current pageSize equals to select's options */
        $(".questionPanel select[name='pageSize'] option").each(function(i){
            if ($(this).val() == page["PageSize"]) {
                $(this).prop("selected", true);
            }
        });
        
        // Pass 4: Reset pageNo
        $(".questionPanel :input[type='hidden'][name='pageNo']").val(page["pageNo"]);
        
        // Pass 5: Fill data in table
        $(".questionPanel #questionList tbody").empty();
        $.each(page.pageList,function(i, j){
            $(".questionPanel #questionList tbody").append("<tr>" +
                    "<td>" + ((page['pageNo']-1)*page['pageSize']+parseInt(i+1)) + "</td>" +
                    "<td>" + j["num"] + "</td>" +
                    "<td><a href='javascript:void(0)' title='" + j["title"] + "'>"+ j["title"] + "</a></td>" +
                    "<td><a href='javascript:void(0)' onclick='toEdit(" + j['id'] + ")'></a></td>"+
                    "<td><input type='checkbox' name='delMark' class='ckUncheck' value='" + j["id"] + "' /></td>" +
                    "</tr>");
        });
        
        // Pass 6: Reset and fill parameter to pagination
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
        $(".questionPanel .pagination").prepend("当前第&nbsp;" + page['pageNo'] + "&nbsp;页,共&nbsp;<span id='maxPageNo'>"+ (page['totalPage']== 0 ? 1 : page['totalPage']) +"</span>&nbsp;页&nbsp;&nbsp;");
        
        // Pass 7: Amend the data in table if there has no data
        $(".questionPanel #questionList tbody:empty").html("<tr><td colspan='5'>当前无记录！</td><tr>");
    }, "json");
}
function queryExamList() {
    var url="queryExamList.action";
    var data = $(".examPanel #examForm").serialize();
    $.post(url, data, function(jsonStr) {
        // Pass 1: Reset title
        $(".examPanel :input[name='name']").val(removeSlash(removePercent($.trim(jsonStr["title"]))));
        
        // Pass 2: Reset orderField
        if ($.trim(jsonStr["orderField"]) != "") {
            $(".examPanel :input[type='hidden'][name='orderField']").val($.trim(jsonStr["orderField"]));
        }
        
        // Pass 3: Reset pageSize
        var page = jsonStr.page;
        /* Keep current pageSize equals to select's options */
        $(".examPanel select[name='pageSize'] option").each(function(i){
            if ($(this).val() == page["PageSize"]) {
                $(this).prop("selected", true);
            }
        });
        
        // Pass 4: Reset pageNo
        $(".examPanel :input[type='hidden'][name='pageNo']").val(page["pageNo"]);
        
        // Pass 5: Fill data in table
        $(".examPanel #examList tbody").empty();
        $.each(page.pageList,function(i, j){
            var status = j["status"];
            if (status == 2){
                status = "<a style='background-color: #FE9901' href='javascript:void(0)'>Finished</a>";
            } else if (status == 1) {
                status = "<a style='background-color: #9da' href='javascript:void(0)'>In Use</a>";
            } else if (status == 0) {
                status = "<a style='background-color: #F2753F' href='javascript:void(0)'>Draft</a>";
            }
            $(".examPanel #examList tbody").append("<tr>"+
                    "<td>" + ((page['pageNo']-1)*page['pageSize']+parseInt(i+1)) + "</td>" +
                    "<td>" + j["num"] + "</td>" +
                    "<td><a href='javascript:void(0)' title='"+ j["name"] +"'>"+ j["name"] +"</a></td>" +
                    "<td>" + j["effectiveTime"] + "</td>" +
                    "<td>" + j["duration"] + "</td>" +
                    "<td>" + j["creator"] + "</td>" +
                    "<td>" + status + "</td>" +
                    "</tr>");
        });
        
        // Pass 6: Reset and fill parameter to pagination
        $(".examPanel .pagination").empty();
        $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='next' data-item='" + page['nextPage'] + "'></a>");
        var collection = page.paginationList;
        for (var i = page.paginationList.length - 1; i >= 0; i--) {
            if (collection[i] == page["pageNo"]) {
                $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='code current'>" + collection[i] + "</a>");
            } else {
                $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='code'>"+ collection[i] +"</a>");
            }
        }
        $(".examPanel .pagination").prepend("<a href='javascript:void(0)' class='prev' data-item='" + page['prevPage'] + "'></a>");
        $(".examPanel .pagination").prepend("当前第&nbsp;" + page['pageNo'] + "&nbsp;页,共&nbsp;<span id='maxPageNo'>" + (page['totalPage']== 0 ? 1 : page['totalPage']) + "</span>&nbsp;页&nbsp;&nbsp;");
        
        // Pass 7: Amend the data in table if there has no data
        $(".examPanel #examList tbody:empty").html("<tr><td colspan='7'>当前无记录！</td><tr>");
        
    }, "json");
}

/*------------------------About Ajax------------------------*/
/* Function function*/
function removePercent(str) {
    return str.replace(new RegExp(/%/g),'');
}

function removeSlash(str) {
    return str.replace(new RegExp(/\\/g),'');
}
/* All check or not check at all */
$(".questionPanel #ckAll").click(function(){
    $(this).toggleClass("ckChecked");
    if (this.checked) {
        $(".questionPanel :checkbox:not('#ckAll')").addClass("ckChecked").prop("checked",true);
    } else {
        $(".questionPanel :checkbox:not('#ckAll')").removeClass("ckChecked").prop("checked",false);
    }
});
$(".questionPanel tbody").delegate("input[type='checkbox']","click",function(){
    if ($(".questionPanel #ckAll").prop("checked")) {
        $(".questionPanel #ckAll").prop("checked",false).toggleClass("ckChecked");
    }
    $(this).toggleClass("ckChecked");
});
$(".questionPanel .cancelToList").click(function(){
    resetQuestionAll();
    toPanel("questionPanel,list");
});
$(".examPanel .cancelToList").click(function(){
    resetExamAll();
    toPanel("examPanel,list");
});
/* toggle small panel*/
$(".questionPanel .list, .questionPanel .create").click(function(){
    $(this).addClass("selected").parent().siblings().find("a").removeClass("selected");
    $(".questionPanel ." + $(this).attr("data-item")).show();
    $(".questionPanel ." + $(this).parent().siblings().find("a").attr("data-item")).hide();
    $(".questionPanel .nowBread").text($(this).text());
    if ($(this).hasClass("create")) {
        /* When Click Create Question then reset all form*/
        resetQuestionAll();
        $(".questionPanel input[name='answer'][value='1']").addClass("radioCK").prop("checked", true).
        siblings(".questionPanel input[class='questionInput']").addClass("questionAnswer");
    }
});
$(".examPanel .list, .examPanel .create").click(function(){
    $(this).addClass("selected").parent().siblings().find("a").removeClass("selected");
    $(".examPanel ." + $(this).attr("data-item")).show();
    $(".examPanel ." + $(this).parent().siblings().find("a").attr("data-item")).hide();
    $(".examPanel .nowBread").text($(this).text());
    if ($(this).hasClass("create")) {
        /* When Click Create Exam then reset all form */
        resetExamAll();
    }
});
$(".questionPanel input[name='answer']").click(function(){
    $(".questionPanel input[type='radio'][name='answer']").removeClass("radioCK");
    $(".questionPanel input[class^='questionInput']").removeClass("questionAnswer");
    $(this).toggleClass("radioCK").prop("checked", this.checked).
    siblings(".questionPanel input[class='questionInput']").toggleClass("questionAnswer");
});
$(".msgbox input[value='Yes']").click(function(){
    var op = $(this).attr("data-item");
    if (op == "question") {
        checkForm();
    } else if (op == "exam") {
        hideMsgBox();
        $("#addForm input[name='saveFlag']").val("true");
        $(".addPanel .cancelToList").prev().click();
    }
})
/* Hide or Show */
function hideMsgBox(){
    $(".msgbox,.shade").hide();
};
function showMsgBox(str, option){
    $(".msgbox h3").text(str);
    $(".msgbox,.shade").show();
    if (option == 0) {
        $(".msgbox input[value='Yes']").attr("data-item","question");
    } else if (option == 1) {
        $(".msgbox input[value='Yes']").attr("data-item","exam");
    }
};
function showAlert(msg){
    $(".alertbox h3").text(msg);
    $(".alertbox").show("fast",function(){
        setTimeout(function(){
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
    $(".questionPanel input[type='radio']").removeClass("radioCK").prop("checked",false);
    $(".questionPanel input[class ~='questionAnswer']").removeClass("questionAnswer");
};
function resetExamAll() {
    $("#addForm")[0].reset();
    $(".examPanel .examUlList li span").text("");
}
function toPanel(str) {
    var panel = str.split(",");
    if (panel[1] == "list") {
        $("." + panel[0] +" ." + panel[1]).click();
    } else {
        $("." + panel[0] +" .create").click();
        $("." + panel[0] +" .nowBread").text(panel[1]);
        $("." + panel[0] +" .list,.create").removeClass("selected");
    }
}