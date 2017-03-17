$(document).ready(function () {

    $("#garden-tbl").DataTable({
        "columnDefs": [{
            "targets": 3,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });



    $(document).on("click", ".garden-del", function () {
        var gardenId = $(this).data("id");
        $("#hd-gardenId").val(gardenId);
    });

    $(document).on("click", ".garden-del-confirm", function () {
        //alert($("#hd-custid").val());
        var gardenId = $("#hd-gardenId").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Garden/DeleteGarden",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { gardenId: gardenId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".message").html(result.msg_data);
                    $("#garden-delete-success").modal("show");
                    return false;
                } else {
                    $(".message").html(result.msg_data);
                    $("#garden-delete-success").modal("show");
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


    $(document).on("click", ".btn-succdel", function () {
        window.location = "/Garden/Index";
    });

});