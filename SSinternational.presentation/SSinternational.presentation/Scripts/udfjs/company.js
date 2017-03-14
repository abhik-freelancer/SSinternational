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
 
    /**
        $('[data-toggle=customerdelete]').confirmation({
            rootSelector: '[data-toggle=customerdelete]'
            // other options
        });
        **/

   
    


});