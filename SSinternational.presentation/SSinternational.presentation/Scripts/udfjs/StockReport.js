$(document).ready(function () {
    $("#stockAsondateid").datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        //defaultDate:new Date(),
        forceParse: false,
    }).datepicker("setDate", new Date());
    //tbl-ctlgList
    $(document).on("click", "#PrintStockReport", function () {
        
        var asondate = $("#stockAsondateid").val().trim();
        var url = $("#StockReportprinturl").val()+'?AsonDate='+asondate;
        window.open(url);
    });

    $(document).on("click", "#ShowStockReport", function () {
       
        var asondate = $("#stockAsondateid").val().trim();
        if (asondate!="")
        {
            var url = $("#StockReportshowurl").val();
            $.ajax({

                contentType: 'application/html; charset=utf-8',
                url: url,
                cache: false,
                data: { AsonDate: asondate },
                type: 'GET',
                dataType: 'html',
                success: function (data) {

                    $('#StockDetailView').html(data);
                    setdatatable();
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
       
    });
   
    function setdatatable() {
        $("#Stock-tbl").DataTable({
            "columnDefs": [{
                "targets": [5],
                "orderable": false
            }],
            language: {
                search: "_INPUT_",
                searchPlaceholder: "Search..."
            }
        });
    }
});