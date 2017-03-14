//js for company master
/**
*Author : Abhik
*Date :08-03-2017
**/
$(document).ready(function () {

    $("#company-tbl").DataTable({
        "columnDefs": [ {
            "targets": 3,
            "orderable": false
        } ],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

   $(document).on("click", ".cus-del", function () {
         var cusId = $(this).data("id");
        $("#hd-custid").val(cusId);
    });

    $(document).on("click", ".cus-del-confirm", function () {
        //alert($("#hd-custid").val());
        var customerId = $("#hd-custid").val() || 0;
        $.ajax({
            type: "POST",
            url: "/Customer/DeleteCustomer",
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { customerId: customerId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".message").html(result.msg_data);
                    $("#cus-delete-success").modal("show");
                    return false;
                } else  {
                    $(".message").html(result.msg_data);
                    $("#cus-delete-success").modal("show");
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
        window.location = "/Customer/Index";
     });


});