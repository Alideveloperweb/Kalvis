


$(document).ready(function () {


    $(".modal-trigger").click(function (e) {

        var dataModal = $(this).attr("data-modal");
        var width = $(this).attr("data-width");
        var url = $(this).attr("data-url");
        var type = $(this).attr("data-type");

        $("#" + dataModal).css({
            "display": "block",
        });
        $(".modal-box").css({
            "width": width,
        });

        $(".close-modal,.modal-sandbox,.exist-modal").click(function (e) {
            $(".modal").fadeOut(300);
        });

        $.ajax({
            url: url,
            type: type,
            success: function (data) {
                $(".body").html(data);
                $("#StartDate,#EndDate").persianDatepicker({
                    formatDate: "YYYY/0M/0D"
                });
                const container = $(".body");
                const forms = container.find("form");
                const newForm = forms[forms.length - 1];
                $.validator.unobtrusive.parse(newForm);

                $(".close-modal,.modal-sandbox,.exist-modal").click(function (e) {
                    $(".modal").fadeOut(300);
                });

            }
            , error: function () {
                alert("لطفا با پشتیبانی تماس بگیرید .")
            }

        });

    });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();

            var form = $(this);
            var urlback = form.attr("data-urlback");
            var url = form.attr("action");
            var method = form.attr("data-method");

            var formData = new FormData(this);

            $.ajax({
                url: url,
                type: method,
                data: formData,
                enctype: "multipart/form-data",
                dataType: "json",
                processData: false,
                contentType: false,
                success: function (data) {
                    message(data.code, data.message, urlback);
                },
                error: function (data) {
                    alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                }
            });

            return false;
        });

    function message(code, message, url) {

        switch (code) {
            case 1://Success
                toastr.options.progressBar = true;
                toastr.success(message);

                setTimeout(function () {
                    //window.location.reload();
                    window.location.href = url;
                }, 2000);
                break;

            case 2://Dublicade
                toastr.options.progressBar = true;
                toastr.warning(message);
                break;

            case 3://Nullabel
                toastr.options.progressBar = true;
                toastr.warning(message);
                break;

            case 4://Error
                toastr.options.progressBar = true;
                toastr.error(message);
                break;

            default:
        }

    }


});