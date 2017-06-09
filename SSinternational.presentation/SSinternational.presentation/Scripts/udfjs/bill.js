$(document).ready(function () {

    $("#buyerBilllst-tbl").DataTable({
        "columnDefs": [{
            "targets": 7,
            "orderable": false
        }],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $('#deliverydate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    })
   

    $('#doDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });

    $('#doLodgDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });

    $('#promptdate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });

    $('#extdDate').datepicker({
        autoclose: true,
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        forceParse: false

    });


    $("#Searchgarden").change(function () {
        var garden = $("#Searchgarden option:selected").text().trim();
        getInvoice(garden);
       
    });
    $(document).on("change", "#srchInvoice", function () {
        var garden = $("#Searchgarden option:selected").text().trim();
        var invoice = $("#srchInvoice").val().trim();
        getGrade(garden, invoice);
    });

    $(document).on("change", "#srchGrade", function () {
        var garden = $("#Searchgarden option:selected").text().trim();
        var invoice = $("#srchInvoice").val().trim();
        var grade = $("#srchGrade").val().trim();
        getNettByGardenAndInvoiceAndGrade(garden, invoice, grade);
    });

    $(document).on("change", "#srchNett", function () {
        var garden = $("#Searchgarden option:selected").text().trim();
        var invoice = $("#srchInvoice").val().trim();
        var grade = $("#srchGrade").val().trim();
        var nett = $("#srchNett").val();

        getStock(garden, invoice, grade, nett);
        getStockLedgerId(garden, invoice, grade, nett);
        getInvoiceId(garden, invoice, grade, nett);
    });

    $(".adddtl").click(function () {

        var invoiceId = $("#hdArrivalInvoiceId").val();
        var stockLedgerId = $("#hdStockLedgerId").val();

        var invoice = $("#invoice-string").val().trim();
        var stockBag = $("#stkBag").val() || 0;
        var Sale = $("#saleno").val() || "";
        var lotnumber = $("#lotnumber").val() || "";
        var doLodgDate = $("#doLodgDate").val();
        var promptDate = $("#promptdate").val();
        var extdDate = $("#extdDate").val();
        var weeksdue = $("#weeksdue").val();
        var addlBag = $("#addlBag").val()||0;
        var addlBagRent = $("#additionalRent").val() || 0;
        var addlBagAmount = $("#addlBagAmount").val() || 0;
        var strtBag = $("#strtBag").val() || 0;
        var strtRate = $("#streetRemovalRent").val() || 0;
        var strtAmount = $("#strtAmount").val() || 0;
        var chkwghmnt = $("#chkwghmnt").val() || 0;
        var chkRate = $("#checkWeighmentRent").val() || 0;
        var chkAmount = $("#chkAmount").val() || 0;
        var samplBag = $("#samplBag").val() || 0;
        var samplRate = $("#samplingRate").val() || 0;
        var samplAmount = $("#samplAmount").val() || 0;
        var totalAmount = $(".totalAmt").text().trim() || 0;

        var row = "<tr>" +
                        "<td style='display:none'>" + "<input type='hidden' id='invoice-id' value='" + invoiceId + "'/> </td>" +
                        "<td style='display:none'>" + "<input type='hidden' id='stock-id' value='" + stockLedgerId + "'/> </td>" +
                        "<td>" + invoice +" </td>" +
                        "<td>" + stockBag + "</td>" +
                        "<td>" + Sale + "</td>" +
                        "<td>" + lotnumber + "</td>" +
                        "<td>" + doLodgDate + "</td>" +
                        "<td>" + promptDate + "</td>" +
                        "<td>" + extdDate + "</td>" +
                        "<td>" + weeksdue + "</td>" +
                        "<td>" + addlBag + "</td>" +
                        "<td>" + addlBagRent + "</td>" +
                        "<td>" + addlBagAmount + "</td>" +
                        "<td>" + strtBag + "</td>" +
                        "<td>" + strtRate + "</td>" +
                        "<td>" + strtAmount + "</td>" +
                        "<td>" + chkwghmnt + "</td>" +
                        "<td>" + chkRate + "</td>" +
                        "<td>" + chkAmount + "</td>" +
                        "<td>" + samplBag + "</td>" +
                        "<td>" + samplRate + "</td>" +
                        "<td>" + samplAmount + "</td>" +
                        "<td>" + totalAmount + "</td>" +
                        "<td>" +
                        "<button class='btn btn-primary btn-xs bill-dtl-edit'>Edit</button>"
                        +"<button class='btn btn-danger btn-xs bill-dtl-del'>DEL</button></td>"
                    +"</tr>"
        console.log(row);
        if (rowValidation()) {
            $(".tblDtl").append(row);
            calculateGrandTotal();
            ClearDetailData();
        } else {
            alert("Fields are not valid");
        }
    });

    $(".tblDtl").on("click", ".bill-dtl-edit", function () {
        var this_row = jQuery(this).closest('tr');
       
        
        $("#hdArrivalInvoiceId").val($.trim(this_row.find('td:eq(0)').children('input').val()));
        $("#hdStockLedgerId").val($.trim(this_row.find('td:eq(1)').children('input').val()));
        $("#invoice-string").val($.trim(this_row.find('td:eq(2)').html()));
        $("#stkBag").val(parseInt($.trim(this_row.find('td:eq(3)').html())));
        $("#saleno").val($.trim(this_row.find('td:eq(4)').html()));
        $("#lotnumber").val($.trim(this_row.find('td:eq(5)').html()));
        $("#doLodgDate").val($.trim(this_row.find('td:eq(6)').html()));
        $("#promptdate").val($.trim(this_row.find('td:eq(7)').html()));
        $("#extdDate").val($.trim(this_row.find('td:eq(8)').html()));
        $("#weeksdue").val($.trim(this_row.find('td:eq(9)').html()));
        $("#addlBag").val($.trim(this_row.find('td:eq(10)').html()));
        $("#additionalRent").val($.trim(this_row.find('td:eq(11)').html()));
        $("#addlBagAmount").val($.trim(this_row.find('td:eq(12)').html()));
        $("#strtBag").val($.trim(this_row.find('td:eq(13)').html()));
        $("#streetRemovalRent").val($.trim(this_row.find('td:eq(14)').html()));
        $("#strtAmount").val($.trim(this_row.find('td:eq(15)').html()));
        $("#chkwghmnt").val($.trim(this_row.find('td:eq(16)').html()));
        $("#checkWeighmentRent").val($.trim(this_row.find('td:eq(18)').html()));
        $("#chkAmount").val($.trim(this_row.find('td:eq(19)').html()));
        $("#samplBag").val($.trim(this_row.find('td:eq(20)').html()));
        $("#samplingRate").val($.trim(this_row.find('td:eq(20)').html()));
        $("#samplAmount").val($.trim(this_row.find('td:eq(21)').html()));
        $(".totalAmt").text($.trim(this_row.find('td:eq(22)').html()));
        $(this).closest("tr").remove();
    });


    $(".tblDtl").on("click", ".bill-dtl-del", function () {
        $(this).closest("tr").remove();
    });
   


    $("#stkBag").blur(function () {
        globalCall();
    });

    $("#chkwghmnt").blur(function () {

        globalCall();
    });

    $("#samplBag").blur(function () {
        globalCall();
    });

  
    $("#deliverydate").change(function () {
        globalCall();
    });
    $("#doDate").change(function () {
        globalCall();
    });
    $("#saleno").blur(function () {
        globalCall();
    });
    $("#doLodgDate").change(function () {
        globalCall();
    });
    $("#promptdate").change(function () {
        globalCall();
    });

    $("#extdDate").change(function () {
        globalCall();
    });

    $(".btnBillSave").click(function () {
        var url = $("#hdSavePath").val();
        var logoutPath = $("#hdLogoutPath").val();
        var listRedirect = $("#listRedirect").val();


        var billid = $("#billId").val() || 0;
        var billnumber = $("#billnumber").val() || "";
        var deliveryDate = $("#deliverydate").val();
        var doNumber = $("#doNumber").val();
        var doDate = $("#doDate").val();
        var sarkar = $("#sarkar").val();
        var buyer = $("#buyer").val();
        var grandtotalamount = parseFloat($(".grandtotalAmt").text().toString());
        var BillDetails = getBillDetails();
        var bills = {
            "billId": billid,
            "billnumber":billnumber,
            "deliverydate": deliveryDate,
            "buyer": buyer,
            "sarkar": sarkar,
            "doNumber": doNumber,
            "doDate": doDate,
            "grandtotalamount":grandtotalamount,
            "BillDetails": BillDetails,

        };
        var billsData = JSON.stringify(bills);


        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: billsData,
            success: function (result) {
                if (result.status == 1) {
                    window.location = listRedirect;
                } else if (result.status == 0) {
                    //alert("Data fail to save");
                    $("#bill-unsuccsavemsg").modal("show");
                } else if (result.status == 3) {
                    $("#bill-validationmsg").modal("show");

                } else {

                    window.location = logoutPath;
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

    //document
});


//***************************************user defined function***********************************//
function ClearDetailData() {
    $("#hdArrivalInvoiceId").val("");
    $("#invoice-string").val("");
    $("#hdStockLedgerId").val("");
    $("#Searchgarden").val("");
    $("#srchInvoice").val("");
    $("#srchGrade").val("");
    $("#srchNett").val("");
    $("#stkBag").val("");
    $("#saleno").val("");
    $("#lotnumber").val("");
    $("#doLodgDate").val("");
    $("#promptdate").val("");
    $("#extdDate").val("");
    $("#weeksdue").val("");
    $("#addlBag").val("");
    $("#additionalRent").val("");
    $("#addlBagAmount").val("");
    $("#strtBag").val("");
    
    $("#strtAmount").val("");
    $("#chkwghmnt").val("");
    
    $("#chkAmount").val("");
    $("#samplBag").val("");
    
    $("#samplAmount").val("");
    $(".totalAmt").text("").trim();

}

function getBillDetails() {
    var billDetail = [];
    var stockid = 0;
    var invoiceId = 0;
    var numberofbags = "";
    var saleno = "";
    var lotnumber = "";
    var doLodgDate = "";
    var promptdate = "";
    var extdDate = "";
    var weeksdue = "";
    var addtionalRentBgas = "";
    var addtionalRentRate = "";
    var addtionalRentAmount = "";
    var streetRmvBags = "";
    var streetRmvRent = "";
    var streetRmvAmount = "";
    var chkWghBags = "";
    var chkWghRate = "";
    var chkWghAmount = "";
    var samplingWghBag = "";
    var samplingRate = "";
    var samplingAmount = "";
    var totalAmount = "";

    var damageDtl = [];
    var damageTypeId = 0;
    var net = 0;
    var serial = 0;


    $(".tblDtl tr:gt(0)").each(function () {
        var this_row = $(this);
       
        invoiceId = $.trim(this_row.find('td:eq(0)').children('input').val());
        stockid = $.trim(this_row.find('td:eq(1)').children('input').val());
        numberofbags = parseInt($.trim(this_row.find('td:eq(3)').html()));
        saleno = $.trim(this_row.find('td:eq(4)').html());
        lotnumber = $.trim(this_row.find('td:eq(5)').html());
        doLodgDate = $.trim(this_row.find('td:eq(6)').html());
        promptdate = $.trim(this_row.find('td:eq(7)').html());
        extdDate = $.trim(this_row.find('td:eq(8)').html());
        weeksdue = $.trim(this_row.find('td:eq(9)').html());
        addtionalRentBgas = $.trim(this_row.find('td:eq(10)').html());
        addtionalRentRate = $.trim(this_row.find('td:eq(11)').html());
        addtionalRentAmount = $.trim(this_row.find('td:eq(12)').html());
        streetRmvBags = $.trim(this_row.find('td:eq(13)').html());
        streetRmvRent = $.trim(this_row.find('td:eq(14)').html());
        streetRmvAmount = $.trim(this_row.find('td:eq(15)').html());
        chkWghBags = $.trim(this_row.find('td:eq(16)').html());
        chkWghRate = $.trim(this_row.find('td:eq(17)').html());
        chkWghAmount = $.trim(this_row.find('td:eq(18)').html());
        samplingWghBag = $.trim(this_row.find('td:eq(19)').html());
        samplingRate = $.trim(this_row.find('td:eq(20)').html());
        samplingAmount = $.trim(this_row.find('td:eq(21)').html());
        totalAmount = $.trim(this_row.find('td:eq(22)').html());
        
        
        billDetail.push({
            "stockid": stockid,
            "invoiceId": invoiceId,
            "numberofbags": numberofbags,
            "saleno": saleno,
            "lotnumber": lotnumber,
            "doLodgDate": doLodgDate,
            "promptdate": promptdate,
            "extdDate": extdDate,
            "weeksdue": weeksdue,
            "addtionalRentBgas": addtionalRentBgas,
            "addtionalRentRate": addtionalRentRate,
            "addtionalRentAmount": addtionalRentAmount,
            "streetRmvBags": streetRmvBags,
            "streetRmvRent": streetRmvRent,
            "streetRmvAmount": streetRmvAmount,
            "chkWghBags": chkWghBags,
            "chkWghRate": chkWghRate,
            "chkWghAmount": chkWghAmount,
            "samplingWghBag": samplingWghBag,
            "samplingRate": samplingRate,
            "samplingAmount": samplingAmount,
            "totalAmount": totalAmount
        });


    });
    console.log(billDetail);
    return billDetail;



}

function globalCall() {
   
    DateAndWeekCalculation();
    weekSlabClaculate();
    calculateRentAmount();
    calculateCheckWeigmenAmount();
    calculateSamplingAmount();
    totalAmountCalculate();

}

function calculateGrandTotal() {
    var grandTotal = 0;

    $(".tblDtl tr:gt(0)").each(function () {
        var this_row = $(this);
        var totalAmount = parseFloat($.trim(this_row.find('td:eq(22)').html()));
        grandTotal = grandTotal + totalAmount;
    });

    $(".grandtotalAmt").text(grandTotal.toFixed(2));

}

function totalAmountCalculate() {
    
    
    var weghmentAmount = calculateCheckWeigmenAmount();
    var samplAmount = calculateSamplingAmount();
    var additionalRent = $("#addlBagAmount").val();
    var strtRemRent = $("#strtAmount").val();
    
   

   var  totalAmount = parseFloat(additionalRent) + parseFloat(strtRemRent) + parseFloat(weghmentAmount) + parseFloat(samplAmount);
    console.log(totalAmount);
    $(".totalAmt").text("");
    $(".totalAmt").text(totalAmount.toFixed(2));

}
function calculateCheckWeigmenAmount() {
    var checkWeighMenAmount = 0;
    var checkWeighmenBag = $("#chkwghmnt").val() || 0;
    var checkWghmenRate = $("#checkWeighmentRent").val() || 0;

    checkWeighMenAmount = parseFloat(checkWghmenRate) * parseInt(checkWeighmenBag);

    $("#chkAmount").val(checkWeighMenAmount.toFixed(2));
    return checkWeighMenAmount;

}

function calculateSamplingAmount() {
    var samplingamount = 0;
    var samplingBag = $("#samplBag").val() || 0;
    var samplingRate = $("#samplingRate").val() || 0;

    samplingamount = parseFloat(samplingRate) * parseInt(samplingBag);
    $("#samplAmount").val(samplingamount.toFixed(2));
    return samplingamount;
}

function calculateRentAmount(){
    var baginstock = $("#stkBag").val() || 0;

    var rateSlab1 = parseFloat($(".slab-one-rate").text().toString()||0);
    var rateSlab2 = parseFloat($(".slab-two-rate").text().toString()||0);
    var rateSlab3 = parseFloat($(".slab-three-rate").text().toString()||0);
    var rateSlab4 = parseFloat($(".slab-rest-rate").text().toString()||0);

    var week_one = parseFloat($(".slab-one").text().toString()||0);
    var week_two = parseFloat($(".slab-two").text().toString()||0);
    var week_three = parseFloat($(".slab-three").text().toString()||0);
    var week_rest = parseFloat($(".slab-rest").text().toString()||0);
    



    $("#addlBag").val(baginstock);
    $("#strtBag").val(baginstock);

    var additionalBagRent = $("#addlBag").val() || 0;
    var streetRemovalRent = $("#streetRemovalRent").val()||0;

    var additinalRentAmount = (parseFloat(additionalBagRent) * (week_one) * (rateSlab1)) + (parseFloat(additionalBagRent) * (week_two) * (rateSlab2)) + (parseFloat(additionalBagRent) * (week_three) * (rateSlab3)) + (parseFloat(additionalBagRent)*(week_rest)*(rateSlab4));
    console.log(additinalRentAmount + " <-additinalRentAmount");

    var streetRemovalRentAmount = parseFloat(streetRemovalRent) * parseInt(baginstock);

    $("#addlBagAmount").val(additinalRentAmount.toFixed(2));
    $("#strtAmount").val(streetRemovalRentAmount.toFixed(2));

}

function DateAndWeekCalculation() {

    var SaleNo = ($("#saleno").val().toUpperCase() || "");
    var promptDate = $('#promptdate').val()||"";
    var extendedDate = $("#extdDate").val()||"";
    var deliveryDate = $("#deliverydate").val() || "";
    var doDate = $("#doDate").val() || "";
    var doLodgeDate = $("#doLodgDate").val()||"";
    var weekDue = 0;
    
        if (SaleNo == "PS") {
            //
            
            d = $('#doDate').datepicker('getDate');
            d.setDate(d.getDate() + 14);
            var datestring = ("0" + d.getDate()).slice(-2) + "-" + ("0" + (d.getMonth() + 1)).slice(-2) + "-" + d.getFullYear();
            $('#promptdate').val(datestring);

            ExtDt = $('#doDate').datepicker('getDate');
            ExtDt.setDate(ExtDt.getDate() + 28);
            var extdDtString = ("0" + ExtDt.getDate()).slice(-2) + "-" + ("0" + (ExtDt.getMonth() + 1)).slice(-2) + "-" + ExtDt.getFullYear();
            $("#extdDate").val(extdDtString);

            deliveryDate = $("#deliverydate").datepicker('getDate');

            if (deliveryDate >= ExtDt) {
                weekDue = Math.ceil(((deliveryDate - ExtDt) / 1000 / 60 / 60 / 24) / 7);
            } else {
                weekDue = 0;
            }

            //
        } else {
            doLodgeDate = $("#doLodgDate").datepicker('getDate')||"";
            if (doLodgeDate == "") {
                deliveryDate = $("#deliverydate").datepicker('getDate');
                promptDate = $("#promptdate").datepicker('getDate');

                if (deliveryDate >= promptDate) {
                    weekDue = Math.ceil(((deliveryDate - promptDate) / 1000 / 60 / 60 / 24) / 7);
                } else {
                    weekDue = 0;
                }

            } else {
                var prmDt = $("#promptdate").datepicker('getDate');
                prmDt.setDate(prmDt.getDate() + 14);
                var extstr = ("0" + prmDt.getDate()).slice(-2) + "-" + ("0" + (prmDt.getMonth() + 1)).slice(-2) + "-" + prmDt.getFullYear();
                $("#extdDate").val(extstr);

                extendedDate = $("#extdDate").datepicker('getDate');
                promptDate = $("#promptdate").datepicker('getDate');
                deliveryDate = $("#deliverydate").datepicker('getDate');
                if (deliveryDate >= extendedDate) {

                    weekDue = Math.ceil(((deliveryDate - extendedDate) / 1000 / 60 / 60 / 24) / 7);
                } else {
                    weekDue = 0;
                }

            }

        }
  
    //alert(weekDue);
    $("#weeksdue").val(weekDue);
    return weekDue;
   
}
function weekSlabClaculate() {
    var weekDays = $("#weeksdue").val() || 0;
    var totalWeek = weekDays;
    var WEEK_SLAB1 = 2;
    var WEEK_SLAB2 = 2;
    var WEEK_SLAB3 = 4;
    var m_difference = 0;
    

    if (weekDays != 0) {
        if (totalWeek >= 2) {
            $(".slab-one").text(WEEK_SLAB1);
            m_difference = parseInt(totalWeek - WEEK_SLAB1);
            if (m_difference <= WEEK_SLAB1) {
                $(".slab-two").text(m_difference);
                $(".slab-three").text(0);
                $(".slab-rest").text(0);
            } else {
                $(".slab-two").text(WEEK_SLAB2);
                m_difference = parseInt(totalWeek - (WEEK_SLAB1 + WEEK_SLAB2));
                if (m_difference <= WEEK_SLAB3) {
                    $(".slab-three").text(m_difference);
                    $(".slab-rest").text(0);
                } else {
                    $(".slab-three").text(WEEK_SLAB3);
                    m_difference = parseInt(totalWeek - (WEEK_SLAB1 + WEEK_SLAB2 + WEEK_SLAB3))
                    $(".slab-rest").text(m_difference);
                }
            }
        } else {
            $(".slab-one").text(totalWeek);
            $(".slab-two").text(0);
            $(".slab-three").text(0);
            $(".slab-rest").text(0);
        }
    }


}

function rowValidation() {
    
    if ($(".totalAmt").text().trim() == "") { return false; }
    if ($("#stkBag").val() == 0 || $("#stkBag").val()=="") { return false; }
    if (!duplicateInvoiceCheck()) { return false; }
    return true;
}

function duplicateInvoiceCheck() {
    var currentInvoiceId = $("#hdArrivalInvoiceId").val();
    var existingInvoiceId = 0;
    var flag = true;
    $(".tblDtl tr:gt(0)").each(function () {
        var this_row = $(this);
        existingInvoiceId = $.trim(this_row.find('td:eq(0)').children('input').val());
        console.log(existingInvoiceId + " table invoice -" + currentInvoiceId);
        if (currentInvoiceId == existingInvoiceId) {
           
            flag = false;
        } 
        
    });
    if (flag == false) {
        return false;
    } else {
        return true;
    }
}



function getStockLedgerId(garden, invoice, grade, nett) {
    var url = $("#hdStockLedgerPath").val();
    var logoutpath = $("#hdLogoutPath").val();
    if (garden != "--Select--" && invoice != "" && grade != "" && nett != "") {
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { garden: garden, invoice: invoice, grade: grade, nett: nett },
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.Data == "LOGOUT") {
                    window.location = logoutpath;
                } else {
                    $("#hdStockLedgerId").val(data.Data);
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

}




function getInvoiceId(garden, invoice, grade, nett) {
    var url = $("#hdInvoiceidpath").val();
    var logoutpath = $("#hdLogoutPath").val();
    if (garden != "--Select--" && invoice != "" && grade != "" && nett != "") {
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { garden: garden, invoice: invoice, grade: grade, nett: nett },
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.Data == 3) {
                    window.location = logoutpath;
                } else {
                    $("#hdArrivalInvoiceId").val(data.Data);
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

}


function getStock(garden,invoice,grade,nett) {
    var url = $("#hdStockBagPath").val();
    var logoutpath = $("#hdLogoutPath").val();
    if (garden != "--Select--" && invoice != "" && grade != "" && nett!="") {
        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { garden: garden,invoice:invoice,grade:grade,nett:nett },
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                
                if (data.Data != "3") {
                    $("#stkBag").val(data.Data);
                    $("#stkBag").focus();
                    $("#stkBag").css("background-color", "#AAF1BE");
                    var invoice = $("#srchInvoice").val();
                    $("#invoice-string").val(invoice);
                } else {
                   
                   window.location = logoutpath;
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
}


function getInvoice(garden) {
    var url = $("#hdInvoicePath").val();

    if (garden != "--Select--") {
        $.ajax({

            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { garden: garden },
            type: 'GET',
            dataType: 'html',
            success: function (data) {

                $('#invoiceList').html(data);
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

function getGrade(garden, invoice) {

    if (garden != "--Select--" && invoice != "") {
        var url = $("#hdGradePath").val();

        $.ajax({
            contentType: 'application/html; charset=utf-8',
            url: url,
            cache: false,
            data: { garden: garden, invoice: invoice },
            type: 'GET',
            dataType: 'html',
            success: function (data) {

                $('#gradeList').html(data);
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

function getNettByGardenAndInvoiceAndGrade(garden,invoice,grade) {

        if (garden != "--Select--" && invoice != "" && grade != "") {
            var url = $("#hdNettPath").val();

            $.ajax({
                contentType: 'application/html; charset=utf-8',
                url: url,
                cache: false,
                data: { garden: garden, invoice: invoice,grade:grade },
                type: 'GET',
                dataType: 'html',
                success: function (data) {

                    $('#nettList').html(data);
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


