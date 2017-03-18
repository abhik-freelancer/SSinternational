$(document).ready(function () {


    $("#package-tbl").DataTable({
        "columnDefs": [{
            "targets": 2,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $(document).on("click", ".package-del", function () {
        var packageId = $(this).data("id");
        $("#hd-package").val(packageId);
    });


    $(document).on("click", ".package-del-confirm", function () {
        //alert($("#hd-custid").val());
        var packageId = $("#hd-package").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Package/DeletePackage",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { packageId: packageId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".package-message").html(result.msg_data);
                    $("#package-delete-success").modal("show");
                    return false;
                } else {
                    $(".package-message").html(result.msg_data);
                    $("#package-delete-success").modal("show");
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



    $(document).on("click", ".btn-package-succdel", function () {
        window.location = "/Package/Index";
    });
});