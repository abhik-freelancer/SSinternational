$(document).ready(function () {

    $("#arrvlDtl-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });


    
    //arrvlPartialDtl-tbl
    $("#arrvlPartialDtl-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $(".dmg-add-arrival").click(function () {
        
        if (damageRowValidationArrival()) {
            
            var damageTypeId = $("#dmgType_arrival").val()||"";
            var damageType = $("#dmgType_arrival :selected").text() || "";
          
            var dmgPktNet = $("#dmgPktNet_arrival").val() || "";
            var dmgSerial = $("#dmgSerial_arrival").val() || "";

            var row = "<tr>" + "<td> <input type='hidden' id='damagetypeId_arrival' value='" + damageTypeId + "'" + "/>" + damageType + "</td>"
                + "<td>" + dmgPktNet + "</td>"
                +"<td>"+ dmgSerial+"</td>"
                +"<td><button type='button' class='btn btn-danger btn-xs dmg-del'>Del</button></td>"
                + "</tr>";

            // console.log(row);
            $("#damageTableArrival").append(row);
            clearDamageFieldArrival();
            createRemarks();
        }

    });

    $(".shrt-add-arrival").click(function () {
        if (shortageRowvalidationArrival()) {
            var shortatageTypeId = $("#shrtType_arrival").val() || "";
            var shortageType = $("#shrtType_arrival option:selected").text() || "";
            
            var shortageNet = $("#shrtgPktNet_arrival").val() || "";
            var shortageSerial = $("#shrtgSerial_arrival").val() || "";

            var row = "<tr>" 
                + "<td> <input type='hidden' id='shrtTypeId_arrival' value='" + shortatageTypeId + "'" + "/>" + shortageType + "</td>"
                + "<td>" + shortageNet + "</td>"
                + "<td>" + shortageSerial + "</td>"
                + "<td><button type='button' class='btn btn-danger btn-xs shrtg-del'>Del</button></td>"
                + "</tr>";
            //console.log(row);

            $("#tblShort_arrival").append(row);
            clearShortageFieldArrival();
            createRemarks();

        }

    });

    $("#pkgsrlto_arrival").blur(function () {
        var SerialFrom = parseInt($("#pkgsrlfrm_arrival").val() || 0);
        var SerialTo = parseInt($("#pkgsrlto_arrival").val() || 0);
        calculateSerialArrival(SerialFrom, SerialTo);
    });

    $("#tblShort_arrival").on("click", ".shrtg-del", function () {
        $(this).closest("tr").remove();
        createRemarks();
    });

    $("#damageTableArrival").on("click", ".dmg-del", function () {

        $(this).closest("tr").remove();
        createRemarks();

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
    $(".btnArrivalInvoicesSave").click(function () {
        
       
        var arrivalDetailid = $("#arrivalDetailid").val() || 0;
        var arrivalId = $("#arrivalId").val() || 0;
       
        var invoice = $("#invoice_arrival").val() || "";
        var grade = $("#grade_arrival").val() || "";
        var packages = $("#package_arrival").val() || "";
        var yearofproduction = $("#yearofproduction_arrival").val() || "";
        var pkgsrlfrm = $("#pkgsrlfrm_arrival").val() || "";
        var pkgsrlto = $("#pkgsrlto_arrival").val() || "";
        var invoicequantity = $("#invoicequantity_arrival").val() || "";
        var receivequantity = $("#receivequantity_arrival").val() || "";
        var gross = $("#gross_arrival").val() || "";
        var tare = $("#tare_arrival").val() || "";
        var net = $("#net_arrival").val() || "";
        var floorId = $("#floorId_arrival").val() || "";
        var remarks = $("#remarks").val() || "";
        
        var damageBagDetail = getDamageBagDetailsArrival();
        
        var shortBagDetails = getShortBagDetailsArrival();
        console.log(shortBagDetails);
        var arrivalDTL = {
            arrivalDetailid: arrivalDetailid,
            arrivalId: arrivalId,
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
            shortBagDtls: shortBagDetails,
            remarks: remarks
        };
       // console.log("data" + ":" + arrivalDTL);
        //alert("abhik");
        var arrivalInvoice = JSON.stringify(arrivalDTL);
        //alert(arrivalInvoice);

        //return false;
        

        var url = $("#hdbasepthSave").val();
        var redirectPathLogin = $("#hdArrivalRedirectpath").val();
        var listRedirect = $("#hdArrivalListPath").val();
        
        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: arrivalInvoice,
            success: function (result) {
                if (result.status==1) {
                    window.location = listRedirect;
                } else if (result.status == 0) {
                    //alert("Data fail to save");
                    $("#arrival-dtl-saveunsuccess").modal("show");
                } else if (result.status == 3) {
                    $("#arrival-dtl-form-validmsg").modal("show");

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


    $(document).on("blur", "#Sfx-arrival", function () {
       
        var invoicenumber = getGeneratedInvoicceNumberArrival();
        $("#invoice_arrival").val(invoicenumber);

    });


    $(document).on("blur", "#tare_arrival", function () {

        var netAmount = CalculateNetArrival();
        console.log(netAmount);
        $("#net_arrival").val(netAmount);
        $("#dmgPktNet_arrival").val(netAmount);

    });

    /**********************************/
});
/**********************************/

function getGeneratedInvoicceNumberArrival() {
    var pfx = $("#prfx-arrival").val();
    var garden = $("#grcode-arrival").val();
    var serial = parseInt($("#srl-arrival").val() || 0);
    var sfx = $("#Sfx-arrival").val();

    var invoiceNumber = pfx + "" + garden + "" + serial + "" + sfx;
    return invoiceNumber;

}

function createRemarks() {
    var str = "";
    $("#damageTableArrival tr:gt(0)").each(function () {

        var this_row = $(this);
        var damage = $.trim(this_row.find('td:eq(0)').text());
        var nett = $.trim(this_row.find('td:eq(1)').html());
        var serial = $.trim(this_row.find('td:eq(2)').html());

        str += "[Type: "+damage + " Nett: " + nett + " Srl: " + serial + "] ";

    });

    $("#tblShort_arrival tr:gt(0)").each(function () {
        var this_row = $(this);
        var shortType = $.trim(this_row.find('td:eq(0)').text());//td:eq(0) means first td of this row
        var shortPkgNet = parseFloat($.trim(this_row.find('td:eq(1)').html()));
        var serial = parseInt($.trim(this_row.find('td:eq(2)').html()));

        str += "[Type: " + shortType + " Nett: " + shortPkgNet + " Srl: " + serial + "] ";
    });
    $("#remarks").val(str);
    console.log(str);
}

function getDamageBagDetailsArrival() {

    var damageDtl = [];
    var damageTypeId = 0;
    var net = 0;
    var serial = 0;


    $("#damageTableArrival tr:gt(0)").each(function () {
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
    console.log(damageDtl);
    return damageDtl;
}

function getShortBagDetailsArrival() {
    var shortBagDtl = [];
    var shortTypeId = 0;
    var shortPkgNet = 0;
    var serial = 0;

    $("#tblShort_arrival tr:gt(0)").each(function () {
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

function clearDamageFieldArrival() {
    $("#dmgType_arrival").val("");
    //$("#dmgPktNet_arrival").val("");
    $("#dmgSerial_arrival").val("");
}

function clearShortageFieldArrival() {
    $("shrtType_arrival").val("");
    $("#shrtgPktNet_arrival").val("");
    $("#shrtgSerial_arrival").val("");
}

function calculateSerialArrival(SerialFrom, SerialTo) {
    if(SerialFrom!=0 && SerialTo!=0){
        var fromSerialLength = SerialFrom.toString().length;
        var toSerialLenght = SerialTo.toString().length;
        var toSeialNumber = 0;
        var invoiceQty = 0;
        if (toSerialLenght >= fromSerialLength) {
            //toSeialNumber = parseInt(SerialTo) - parseInt(SerialFrom) + parseInt(1);
            $("#pkgsrlto_arrival").val("");
            $("#pkgsrlto_arrival").val(SerialTo);
        } else if (fromSerialLength > toSerialLenght) {
            
            var lengthDiff = fromSerialLength - toSerialLenght;
            var substr = SerialFrom.toString().substring(0, lengthDiff);
            var stringSerialTo = substr + SerialTo.toString();

            toSeialNumber = parseInt(stringSerialTo);//(parseInt(stringSerialTo) - parseInt(SerialFrom)) + parseInt(1);
            $("#pkgsrlto_arrival").val("");
            $("#pkgsrlto_arrival").val(toSeialNumber);
        }

        invoiceQty = parseInt($("#pkgsrlto_arrival").val()) - parseInt(SerialFrom)+parseInt(1);
        $("#invoicequantity_arrival").val(invoiceQty);
        $("#receivequantity_arrival").val(invoiceQty);
    }
}


function damageRowValidationArrival() {
    if ($("#dmgType_arrival").val() == "") { return false; }
    if ($("#dmgPktNet_arrival").val() == "") { return false;}
    if ($("#dmgSerial_arrival").val() == "") { return false; }

    var pkgsrlfrm =parseInt($("#pkgsrlfrm_arrival").val());
    var pkgsrlto = parseInt($("#pkgsrlto_arrival").val());
    var dmgsrl = parseInt($("#dmgSerial_arrival").val());

    if (dmgsrl >= pkgsrlfrm && dmgsrl <= pkgsrlto) {
        return true;
    } else {
        return false;
    }

    return true;
}

function shortageRowvalidationArrival() {
    if ($("shrtType_arrival").val() == "") { return false;}
    if ($("#shrtgPktNet_arrival").val() == "") { return false; }
    if ($("#shrtgSerial_arrival").val() == "") { return false; }

    var pkgsrlfrm = parseInt($("#pkgsrlfrm_arrival").val());
    var pkgsrlto = parseInt($("#pkgsrlto_arrival").val());
    var shrtgsrl = parseInt($("#shrtgSerial_arrival").val());

    if (shrtgsrl >= pkgsrlfrm && shrtgsrl <= pkgsrlto) {
        return true;
    } else {
        return false;
    }

    return true;
}
function CalculateNetArrival() {

    var gross = $("#gross_arrival").val() || 0;
    var tare = $("#tare_arrival").val() || 0;
    var net_amount = 0;

    net_amount = parseFloat(gross) - parseFloat(tare);

    return net_amount;
}




