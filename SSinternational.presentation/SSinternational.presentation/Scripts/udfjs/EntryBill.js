$(document).ready(function () {
    $("#table-entryBill").DataTable({
        "columnDefs": [{
            "targets": 6,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $('#fromDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    })


    $('#toDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });

    $("#CustomerId").change(function () {

        var customerId = $("#CustomerId").val();
        //alert(customerId);
        getGardenByCustomer(customerId);
    });

    $(".btn-show").click(function () {
        var fromDate = $("#fromDate").val();
        var toDate = $("#toDate").val();
        var gardenId = $("#Garden").val();
        var brokerId = $("#BrokerId").val();

        
        getArrivalList(fromDate, toDate, gardenId, brokerId);

    });

    $(document).on("click", ".add-invoice", function () {

        var arrivalId = $(this).attr("id");
        //alert(arrivalId);
        var url = $("#hdArrivalInvoicesList").val();
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { arrivalId: arrivalId },
            type: 'GET',
            dataType: 'html',
            success: function (data) {

                $('#arrival-invoices').append(data);
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

});
//*************************************user defined function*********************************//
function getArrivalList(fromDate, toDate, gardenId, BrokerId) {
    //alert(fromDate +" : " + toDate+" : " + gardenId+" : " + gardenId);
    var url = $("#hdArrivallistPath").val();
    $.ajax({
        contentType: 'application/html; charset=utf-8',
        url: url,
        cache: false,
        data: { from: fromDate, to: toDate, gardenid: gardenId, brokerid: BrokerId },
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $(".arrival-table > tbody  tr").empty();
            $('.arrival-table tbody').append(data);
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

}

function getGardenByCustomer(customerid) {
    if (customerid != "") {
        var url = $("#hdGardenListPath").val();
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { customerId: customerid},
            type: 'GET',
            dataType: 'html',
            success: function (data) {

                $('#gardenlst').html(data);
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

    }
}