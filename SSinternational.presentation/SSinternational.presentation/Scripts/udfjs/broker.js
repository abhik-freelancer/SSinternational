$(document).ready(function () {

    $("#broker-tbl").DataTable({
        "columnDefs": [{
            "targets": 3,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });


    $(document).on("click", ".broker-del", function () {
      
        var BrokerId = $(this).data("id");
        $("#hd-BrokerId").val(BrokerId);
    });


    $(document).on("click", ".broker-del-confirm", function () {
        //alert($("#hd-custid").val());
        var BrokerId = $("#hd-BrokerId").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Brokers/DeleteBroker",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { BrokerId: BrokerId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".broker-message").html(result.msg_data);
                    $("#broker-delete-success").modal("show");
                    return false;
                } else {
                    $(".broker-message").html(result.msg_data);
                    $("#broker-delete-success").modal("show");
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

    $(document).on("click", ".btn-broker-succdel", function () {
        window.location = "/Brokers/Index";
    });
});