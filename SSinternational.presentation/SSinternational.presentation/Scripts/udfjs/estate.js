//js for company master
/**
*Author : Abhik
*Date :08-03-2017
**/
$(document).ready(function () {

    $("#estate-tbl").DataTable({
        "columnDefs": [{
            "targets": 2,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    //deletion

    $(document).on("click", ".estate-del", function () {
        var estateId = $(this).data("id");
        $("#hd-estateId").val(estateId);
    });

    $(document).on("click", ".est-del-confirm", function () {
        //alert($("#hd-custid").val());
        var estateId = $("#hd-estateId").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Estate/DeleteEstate",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { estateId: estateId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".message-estate").html(result.msg_data);
                    $("#est-delete-success").modal("show");
                    return false;
                } else {
                    $(".message-estate").html(result.msg_data);
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


    $(document).on("click", ".btn-estatesuccdel", function () {
        window.location = "/Estate/Index";
    });


});