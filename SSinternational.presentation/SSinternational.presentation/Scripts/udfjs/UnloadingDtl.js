$(document).ready(function () {

    $("#unloadDtl-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });
});