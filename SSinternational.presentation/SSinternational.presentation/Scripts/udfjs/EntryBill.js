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



});