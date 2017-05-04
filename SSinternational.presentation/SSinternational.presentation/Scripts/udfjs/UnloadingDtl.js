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

    //invoiceList-tbl
    $("#invoiceList-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $(".dmg-add").click(function () {
        
        if (damageRowValidation()) {
            
            var damageTypeId = $("#dmgType").val()||"";
            var damageType = $("#dmgType :selected").text() || "";
          
            var dmgPktNet = $("#dmgPktNet").val() || "";
            var dmgSerial = $("#dmgSerial").val() || "";

            var row = "<tr>" + "<td> <input type='hidden' id='damagetypeId' value='" + damageTypeId + "'" + "/>" + damageType + "</td>"
                + "<td>" + dmgPktNet + "</td>"
                +"<td>"+ dmgSerial+"</td>"
                +"<td><button type='button' class='btn btn-danger btn-xs dmg-del'>Del</button></td>"
                + "</tr>";

           // console.log(row);
            $("#damageTable").append(row);
            clearDamageField();
        }

    });

    $(".shrt-add").click(function () {
        if (shortageRowvalidation()) {
            var shortatageTypeId = $("#shrtType").val() || "";
            var shortageType = $("#shrtType option:selected").text() || "";
            
            var shortageNet = $("#shrtgPktNet").val() || "";
            var shortageSerial = $("#shrtgSerial").val() || "";

            var row = "<tr>" 
                + "<td> <input type='hidden' id='shrtTypeId' value='" + shortatageTypeId + "'"+"/>" + shortageType + "</td>"
                + "<td>" + shortageNet + "</td>"
                + "<td>" + shortageSerial + "</td>"
                + "<td><button type='button' class='btn btn-danger btn-xs shrtg-del'>Del</button></td>"
                + "</tr>";
            //console.log(row);

            $("#tblShort").append(row);
            clearShortageField();

        }

    });

    $("#pkgsrlto").blur(function () {
        var SerialFrom = parseInt($("#pkgsrlfrm").val() || 0);
        var SerialTo = parseInt($("#pkgsrlto").val() || 0);
        calculateSerial(SerialFrom, SerialTo);
    });

    $("#tblShort").on("click", ".shrtg-del", function () {
        $(this).closest("tr").remove();
    });

    $("#damageTable").on("click", ".dmg-del", function () {

        $(this).closest("tr").remove();

    });


    $(".numericOnly").bind('keypress', function (e) {
        if (e.keyCode == '9' || e.keyCode == '16') {
            return;
        }
        var code;
        if (e.keyCode) code = e.keyCode;
        else if (e.which) code = e.which;
        if (e.which == 46)
            return false;
        if (code == 8 || code == 46)
            return true;
        if (code < 48 || code > 57)
            return false;
    });

    //Disable paste
    $(".numericOnly").bind("paste", function (e) {
        e.preventDefault();
    });

    $(".numericOnly").bind('mouseenter', function (e) {
        var val = $(this).val();
        if (val != '0') {
            val = val.replace(/[^0-9]+/g, "")
            $(this).val(val);
        }
    });


   
    $('.decimalonly').keypress(function (event) {
        return isNumber(event, this)
    });

    /*
    * Unload invoicesave
    */
    $(".btnUnldInvoiceSave").click(function () {
        
        var unloadingDetailId = $("#unloadingDetailId").val() || 0;
        var unloadingmasterid = $("#unloadingmasterid").val() || 0;
       
        var invoice = $("#invoice").val() || "";
        var grade = $("#grade").val() || "";
        var packages = $("#package").val() || "";
        var yearofproduction = $("#yearofproduction").val() || "";
        var pkgsrlfrm = $("#pkgsrlfrm").val() || "";
        var pkgsrlto = $("#pkgsrlto").val() || "";
        var invoicequantity = $("#invoicequantity").val() || "";
        var receivequantity = $("#receivequantity").val() || "";
        var gross = $("#gross").val() || "";
        var tare = $("#tare").val() || "";
        var net = $("#net").val() || "";
        var floorId = $("#floorId").val() || "";
        var damageBagDetail = getDamageBagDetails();
        var shortBagDetails = getShortBagDetails();

        var unloadingDtl = {
            unloadingDetailId: unloadingDetailId,
            unloadingmasterid: unloadingmasterid,
            invoice: invoice,
            grade: grade,
            package: packages,
            yearofproduction: yearofproduction,
            pkgsrlfrm: pkgsrlfrm,
            pkgsrlto: pkgsrlto,
            invoicequantity: invoicequantity,
            receivequantity: receivequantity,
            gross: gross,
            tare: tare,
            net: net,
            floorId: floorId,
            damageBagDtls: damageBagDetail,
            shortBagDtls: shortBagDetails
        };

        var unloadingInvoice = JSON.stringify(unloadingDtl);
       // alert(unloadingInvoice);
        //return false;
        

        var url = $("#hdbasepth").val();
        var redirectPathLogin = $("#hdRedirectpath").val();
        var listRedirect = $("#hdListPath").val();
        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: unloadingInvoice,
            success: function (result) {
                if (result.status==1) {
                    window.location = listRedirect;
                } else if (result.status == 0) {
                    //alert("Data fail to save");
                    $("#unload-dtl-saveunsuccess").modal("show");
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


       // console.log(unloadingDtl);



    });


    $(document).on("blur", "#Sfx", function () {
       
        var invoicenumber = getGeneratedInvoicceNumber();
        $("#invoice").val(invoicenumber);

    });


/**********************************/
});
/**********************************/

function getGeneratedInvoicceNumber() {
    var pfx = $("#prfx").val();
    var garden = $("#grcode").val();
    var serial = parseInt($("#srl").val()||0);
    var sfx = $("#Sfx").val();

    var invoiceNumber = pfx + "/" + garden + "/" + serial + "/" + sfx;
    return invoiceNumber;

}

function getDamageBagDetails() {

    var damageDtl = [];
    var damageTypeId = 0;
    var net = 0;
    var serial = 0;


    $("#damageTable tr:gt(0)").each(function () {
        var this_row = $(this);
        damageTypeId = $.trim(this_row.find('td:eq(0)').children('input').val());//td:eq(0) means first td of this row
        net = parseFloat($.trim(this_row.find('td:eq(1)').html()));
        serial = parseInt($.trim(this_row.find('td:eq(2)').html()));

       
        damageDtl.push({
            "damageTypeId": damageTypeId,
            "net": net,
            "serial":serial
            });
       

    });
    return damageDtl;
}

function getShortBagDetails() {
    var shortBagDtl = [];
    var shortTypeId = 0;
    var shortPkgNet = 0;
    var serial = 0;

    $("#tblShort tr:gt(0)").each(function () {
        var this_row = $(this);
        shortTypeId = $.trim(this_row.find('td:eq(0)').children('input').val());//td:eq(0) means first td of this row
        shortPkgNet = parseFloat($.trim(this_row.find('td:eq(1)').html()));
        serial = parseInt($.trim(this_row.find('td:eq(2)').html()));


        shortBagDtl.push({
            "shortTypeId": shortTypeId,
            "shortPkgNet": shortPkgNet,
            "serial": serial
        });


    });
    return shortBagDtl;

}

function isNumber(evt, element) {

    var charCode = (evt.which) ? evt.which : event.keyCode

    if (
        (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
        (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
        (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function clearDamageField() {
    $("#dmgType").val("");
    $("#dmgPktNet").val("");
    $("#dmgSerial").val("");
}

function clearShortageField() {
    $("#shrtType").val("");
    $("#shrtgPktNet").val("");
    $("#shrtgSerial").val("");
}

function calculateSerial(SerialFrom, SerialTo) {
    if(SerialFrom!=0 && SerialTo!=0){
        var fromSerialLength = SerialFrom.toString().length;
        var toSerialLenght = SerialTo.toString().length;
        var toSeialNumber = 0;
        var invoiceQty = 0;
        if (toSerialLenght >= fromSerialLength) {
            //toSeialNumber = parseInt(SerialTo) - parseInt(SerialFrom) + parseInt(1);
            $("#pkgsrlto").val("");
            $("#pkgsrlto").val(SerialTo);
        } else if (fromSerialLength > toSerialLenght) {
            
            var lengthDiff = fromSerialLength - toSerialLenght;
            var substr = SerialFrom.toString().substring(0, lengthDiff);
            var stringSerialTo = substr + SerialTo.toString();

            toSeialNumber = parseInt(stringSerialTo);//(parseInt(stringSerialTo) - parseInt(SerialFrom)) + parseInt(1);
            $("#pkgsrlto").val("");
            $("#pkgsrlto").val(toSeialNumber);
        }

        invoiceQty = parseInt($("#pkgsrlto").val()) - parseInt(SerialFrom)+parseInt(1);
        $("#invoicequantity").val(invoiceQty);
        $("#receivequantity").val(invoiceQty);
    }
}


function damageRowValidation() {
    if ($("#dmgType").val() == "") { return false; }
    if ($("#dmgPktNet").val() == "") { return false;}
    if ($("#dmgSerial").val() == "") { return false; }

    var pkgsrlfrm =parseInt($("#pkgsrlfrm").val());
    var pkgsrlto = parseInt($("#pkgsrlto").val());
    var dmgsrl = parseInt($("#dmgSerial").val());

    if (dmgsrl >= pkgsrlfrm && dmgsrl <= pkgsrlto) {
        return true;
    } else {
        return false;
    }

    return true;
}

function shortageRowvalidation() {
    if ($("#shrtType").val() == "") { return false;}
    if ($("#shrtgPktNet").val() == "") { return false; }
    if ($("#shrtgSerial").val() == "") { return false; }

    var pkgsrlfrm = parseInt($("#pkgsrlfrm").val());
    var pkgsrlto = parseInt($("#pkgsrlto").val());
    var shrtgsrl = parseInt($("#shrtgSerial").val());

    if (shrtgsrl >= pkgsrlfrm && shrtgsrl <= pkgsrlto) {
        return true;
    } else {
        return false;
    }

    return true;
}

 