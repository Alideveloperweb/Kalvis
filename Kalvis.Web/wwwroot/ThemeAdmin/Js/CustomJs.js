

$(".add-sub").click(function () {
    var dataname = $(this).data("name");
    if ($("#sublist").val()) {
        var value = $("#sublist").children("option:selected").val();
        var text = $("#sublist").children("option:selected").text();
        $(".sublist").append("<div class='category_inline'><button style='margin-left:0' type='button' class='close pull-left btn-remove'>×</button>" +
            "<input type='hidden' value='" + value + "' name='" + dataname + "' /><span style='margin-left:10px' class='subtext'>" + text + "</span> </div>");
        $("#sublist").children("option:selected").remove();
    } else {
        alert("مقداری را وارد نمایید")
    }
});

$('.sublist').delegate(".btn-remove", 'click', function () {
    var text = $(this).nextAll($(".subtext")).text();
    var value = $(this).nextAll($("input [type=hidden]")).val();

    $("#sublist").append($('<option>', {
        value: value,
        text: text
    }));
    $(this).parent().remove();
});

//----------------CKEdITOR
CKEDITOR.replace('CreateCourse_CourseSummery');
CKEDITOR.replace('CreateCourse_CourseDescription');

CKEDITOR.replace('EditCourse_CourseSummery');
CKEDITOR.replace('EditCourse_CourseDescription');

CKEDITOR.replace('CreateBlog_BlogDescription');
CKEDITOR.replace('EditBlog_BlogDes');

CKEDITOR.replace('GetComment_CommentText');
//----------------CKEDITOR