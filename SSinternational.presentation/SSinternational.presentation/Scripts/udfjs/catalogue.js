$(document).ready(function () {

    //tbl-ctlgList
    $("#tbl-ctlgList").DataTable({
        "columnDefs": [{
            "targets": [5],
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $("#garden").change(function () {

        var gardenId = $("#garden").val();
        var url = $("#hdlstpath").val();
        $.ajax({
            url: url,
            contentType: 'application/html; charset=utf-8',
            cache: false,
            data: { gardenId: gardenId },
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                $("#lstdata").html(result)
            },
            error: function (jqXHR, exception) {
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

    $("#catalougedate").datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false
    });

    $(document).on("click", ".catlgadd", function () {
        var arrivalDtlId = $(this).data("id");
        $("#arrivalInvoiceId").val(arrivalDtlId);
        var url = $("#hdlstatlgadd").val();

        $.ajax({
            url: url,
            contentType: 'application/html; charset=utf-8',
            cache: false,
            data: { arrivalDtlId: arrivalDtlId },
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                $(".catlog").html(result);
                $("#catlogModal").modal("show");
                $("#ctlgDt").datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: 'dd-mm-yyyy',
                    forceParse: false
                });
                
            },
            error: function (jqXHR, exception) {
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


    $(document).on("click", ".save-catalogue", function () {
        var catalougedate = $("#ctlgDt").val();
        var arrivalInvoiceId = $("#arrivalInvoiceId").val();
        var saleNumber = $("#catlgSale").val();
        var lotNumber = $("#catlgLot").val();
        var brokerId = $("#catlgbroker").val();
        var bagSerial = $("#chstSerial").val();

        var catalogDtl = {
            catalougedate: catalougedate,
            arrivalInvoiceId: arrivalInvoiceId,
            saleNumber: saleNumber,
            lotNumber: lotNumber,
            brokerId: brokerId,
            bagSerial: bagSerial
        };
        
        var catalog = JSON.stringify(catalogDtl);
        console.log(catalog);
        url = $("#savepath").val();
        if(validate()){
        $.ajax({
            url: url,
            contentType: 'application/json; charset=utf-8',
            cache: false,
            data: catalog,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                if (result.msg_code == 1) {
                    //msg-area
                    //
                    $("#catlogModal").modal("hide");
                    $("#msg-area").html(result.msg_data)
                    $("#message-modal").modal("show");
                    // alert(result.msg_data);
                } else {
                    $("#msg-area").html(result.msg_data)
                    $("#message-modal").modal("show");
                }

            },
            error: function (jqXHR, exception) {
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
    }else{
            $(".alert-danger").show();
    }

    });
    $(document).on("click", ".alclose", function () {
        $(".alert-danger").hide();
    });

    
/*******/
});
function validate() {
    var catalougedate = $("#ctlgDt").val()||"";
    var arrivalInvoiceId = $("#arrivalInvoiceId").val()||"";
    var saleNumber = $("#catlgSale").val()||"";
    var lotNumber = $("#catlgLot").val()||"";
    var brokerId = $("#catlgbroker").val()||"";
    var bagSerial = $("#chstSerial").val()||"";

    if (catalougedate == "") { return false; }
    if (arrivalInvoiceId == "") { return false; }
    if (saleNumber == "") { return false; }
    if (lotNumber == "") { return false; }
    if (brokerId == "") { return false;}
    if (bagSerial == "") { return false;}
    return true;

}