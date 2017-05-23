$(document).ready(function () {


    //arrivalmaster-tbl
    $("#arrivalmaster-tbl").DataTable({
        "columnDefs": [{
            "targets": 6,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });


    $('#arvlDt').datepicker({
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

   

    


    /***********************************/

});