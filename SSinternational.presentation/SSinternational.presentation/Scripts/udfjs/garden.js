$(document).ready(function () {

    $("#garden-tbl").DataTable({
        "columnDefs": [{
            "targets": 3,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

});