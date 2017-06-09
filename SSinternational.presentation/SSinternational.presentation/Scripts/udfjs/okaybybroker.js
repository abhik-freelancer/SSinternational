$(document).ready(function () {


    $("#arrival").change(function () {
        var arrivalId = $("#arrival").val() || "";
        var url = $("#hdListOfInvoicesPath").val();
        var logoutpath = $("#hdLogoutPath").val();
        //arrival-lstdata
        //alert(arrivalId);
        if (arrivalId != "") {

            $.ajax({
                url: url,
                contentType: 'application/html; charset=utf-8',
                cache: false,
                data: { arrivalId: arrivalId },
                type: 'GET',
                dataType: 'html',
                success: function (result) {
                    if (result == 3) {

                        window.location = logoutpath;
                    } else {
                        $("#arrival-lstdata").html(result);
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

        }

    });

    $(".btnOkayBySave").click(function () {
        
        var selectedbroker = $("#brokerId").val();
        var arrvDtlId = $("#arrivalDetailId").val();
        var dmgBagDtls = getDamageBagDetail();
        var dtlData = {
            arrivalDetailId: arrvDtlId,
            brokerId: selectedbroker,
            damageBagDetails: dmgBagDtls
        };
        
        var inspectionResult = JSON.stringify(dtlData);
        //console.log(inspectionResult);
        var url = $("#savePath").val();
        var listRedirect = $("#retrnPath").val();
        var redirectPathLogin = $("#LogoutPath").val();

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: inspectionResult,
            success: function (result) {
                if (result.status == 1) {
                    window.location = listRedirect;
                    //alert("Data successfully saved");
                } else if (result.status == 0) {
                    //alert("Data fail to save");
                    $("#okaybybroker-dtl-saveunsuccess").modal("show");
                } else if (result.status == 3) {
                    $("#unload-dtl-form-validmsg").modal("show");

                } else {

                    window.location = redirectPathLogin;
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



//js end
});

function getDamageBagDetail() {
    var damageDtl = [];
    var damageTypeId = 0;
    var net = 0;
    var serial = 0;

    $("#tbl-damagebagdtl tr:gt(0)").each(function () {
        var this_row = $(this);
        damageTypeId = $.trim(this_row.find('td:eq(0)').children('select').val());
        net = $.trim(this_row.find('td:eq(1)').children('input').val()||0);
        serial = $.trim(this_row.find('td:eq(2)').html());

        damageDtl.push({
            "damageTypeId": damageTypeId,
            "net": net,
            "serial": serial
        });

    });
    //console.log(damageDtl);
    return damageDtl;

}