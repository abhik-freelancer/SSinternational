$(document).ready(function () {

    $("#short-tbl").DataTable({
        "columnDefs": [{
            "targets": 2,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $(document).on("click", ".short-del", function () {
        var shortId = $(this).data("id");
        $("#hd-shortId").val(shortId);
    });

    $(document).on("click", ".short-del-confirm", function () {
        //alert($("#hd-custid").val());
        var shortId = $("#hd-shortId").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Shorttype/DeleteShort",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { shortId: shortId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".message-short").html(result.msg_data);
                    $("#est-delete-success").modal("show");
                    return false;
                } else {
                    $(".message-short").html(result.msg_data);
                    $("#est-delete-success").modal("show");
                    return false;
                }
            }, error: function (jqXHR, exception) {
                var msg = '';
                if (jqXHR.status === 0) {
                    msg = 'Not connect.\n Verify Network.';
                } else if (jqXHR.status == 404) {
                    msg = 'Requested page not found. [404]';
                } else if (jqXHR.status == 500) {
                    msg = 'Internal Server Error [500].';
                } else if (exception === 'parsererror') {
                    msg = 'Requested JSON parse failed.';
                } else if (exception === 'timeout') {
                    msg = 'Time out error.';
                } else if (exception === 'abort') {
                    msg = 'Ajax request aborted.';
                } else {
                    msg = 'Uncaught Error.\n' + jqXHR.responseText;
                }
                alert(msg);
            }
        });



    });

    $(document).on("click", ".btn-shortsuccdel", function () {
        window.location = "/Shorttype/Index";
    });

});