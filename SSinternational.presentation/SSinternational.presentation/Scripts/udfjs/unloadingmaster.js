$(document).ready(function () {

    $('#rcptdt').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });
    //cnnDate
    $('#cnnDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });

    $("#unloadmaster-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $(document).on("click", ".unldmst-del", function () {
        var unldmstId = $(this).data("id");
        $("#hd-unldmst").val(unldmstId);
    });

    //unldmst-del-confirm

    $(document).on("click", ".unldmst-del-confirm", function () {
        //alert($("#hd-custid").val());
        var unloadmasterId = $("#hd-unldmst").val() || 0;
        var url = $("#hdbasepth").val() || "";
        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: { unloadmasterId: unloadmasterId },
            success: function (result) {
                if (result.msg_code == 1) {
                    $(".message-unldmst").html(result.msg_data);
                    $("#unloadmst-delete-success").modal("show");
                    return false;
                } else {
                    $(".message-unldmst").html(result.msg_data);
                    $("#unloadmst-delete-success").modal("show");
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

    /***********************************************/
    $(document).on("click", ".btn-unldmstsuccdel", function () {
        var redirect = $("#hdbasepthredirect").val();
        window.location = redirect;
    });

});