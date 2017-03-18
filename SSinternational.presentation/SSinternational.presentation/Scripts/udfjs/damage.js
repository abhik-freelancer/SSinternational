$(document).ready(function () {
    $("#damage-tbl").DataTable({
        "columnDefs": [{
            "targets": 2,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });



    $(document).on("click", ".damage-del", function () {
        var DamageId = $(this).data("id");
        $("#hd-damage").val(DamageId);
    });

    $(document).on("click", ".damage-del-confirm", function () {
        //alert($("#hd-custid").val());
        var DamageId = $("#hd-damage").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Damage/DeleteDamageType",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { DamageId: DamageId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".damage-message").html(result.msg_data);
                    $("#damage-delete-success").modal("show");
                    return false;
                } else {
                    $(".damage-message").html(result.msg_data);
                    $("#damage-delete-success").modal("show");
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

    //btn-damage-succdel
    $(document).on("click", ".btn-damage-succdel", function () {
        window.location = "/Damage/Index";
    });
});