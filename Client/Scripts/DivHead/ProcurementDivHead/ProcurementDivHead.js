$(document).ready(function () {
    $(function () {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            todayHighlight: true,
        });
    });
    LoadIndexProcurement();
    LoadTypeItemProject();
    LoadItemProject();
    $('#tableProcurement').DataTable({
        "ajax": LoadIndexProcurement()
    })
})

function LoadIndexProcurement() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Procurement/LoadProcurement/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Procurement + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + moment(val.Date_Procurement).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + val.Quantity + '</td>';
                html += '<td>' + val.Item.Name_Item + '</td>';
                html += '<td>' + val.TypeItem.Name_TypeItem + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td>' + '<a href="#" onclick="return GetById(' + val.Id + ')">Confirmation</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}



function LoadTypeItemProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Procurement/GetTypeItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
                    html += '<option value = "" selected disabled hidden>Choose Type Item</option>';
            $.each(data,
                function (index, val) {
                    html += '<option value="' + val.Id + '">' + val.Name_TypeItem + '</option>';
                });
            $('#TypeItem').html(html);
        }
    });
}

function LoadItemProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Procurement/GetItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
                    html += '<option value = "" selected disabled hidden>Choose Item</option>';
            $.each(data,
                function (index, val) {
                    html += '<option value="' + val.Id + '">' + val.Name_Item + '</option>';
                });
            $('#Item').html(html);
        }
    });
}


function Save() {
    var procurement = new Object();
    procurement.Name_Procurement = $('#Name').val();
    procurement.Description = $('#Description').val();
    procurement.Price = $('#Price').val();
    procurement.Date_Procurement = $('#DateProcurement').val();
    procurement.Quantity = $('#Quantity').val();
    procurement.Item_Id = $('#Item').val();
    procurement.TypeItem_Id = $('#TypeItem').val();
    procurement.Status = $('#Status1').val();
    $.ajax({
        url: "/Procurement/InsertOrUpdate/",
        data: procurement,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Procurement/Index/';
                });
            LoadIndexProcurement();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var procurement = new Object();
    procurement.Id = $('#Id').val();
    procurement.Name_Procurement = $('#Name').val();
    procurement.Description = $('#Description').val();
    procurement.Price = $('#Price').val();
    procurement.Date_Procurement = $('#DateProcurement').val();
    procurement.Quantity = $('#Quantity').val();
    procurement.Item_Id = $('#Item').val();
    procurement.TypeItem_Id = $('#TypeItem').val();
    procurement.Status = $('#Status1').val();
    $.ajax({
        url: "/Procurement/InsertOrUpdate/",
        data: procurement,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexProcurement();
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Procurement/GetById/",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Procurement);
            $('#Description').val(result.Description);
            $('#Price').val(result.Price);
            $('#DateProcurement').val(moment(result.Date_Procurement).format('MM/DD/YYYY'));
            $('#Quantity').val(result.Quantity);
            $('#TypeItem').val(result.TypeItem_Id);
            $('#Item').val(result.Item_Id);
            $('#Status1').val(result.Status);

            $('#myModal').modal('show');
            $('#Approve').show();
            $('#Reject').show();
        }
    })
}


function ClearScreen() {
    $('#TypeItem').val('');
    $('#Item').val('');
    $('#Quantity').val('');
    $('#DateProcurement').val('');
    $('#Price').val('');
    $('#Description').val('');
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Description').val() == "" || $('#Description').val() == " ") {
        swal("Oops", "Please Insert Description", "error")
    } else if ($('#Price').val() == "" || $('#Price').val() == " ") {
        swal("Oops", "Please Insert Price", "error")
    } else if ($('#DateProcurement').val() == "" || $('#DateProcurement').val() == " ") {
        swal("Oops", "Please Insert Date Procurement", "error")
    } else if ($('#Quantity').val() == "" || $('#Quantity').val() == " ") {
        swal("Oops", "Please Insert Quantity", "error")
    } else if ($('#TypeItem option:selected').val() == "" || $('#TypeItem option:selected').val() == " ") {
        swal("Oops", "Please Insert Type Item", "error")
    } else if ($('#Item option:selected').val() == "" || $('#Item option:selected').val() == " ") {
        swal("Oops", "Please Insert Item", "error")
    } else if ($('#Status1').val() == "" || $('#Status1').val() == " ") {
        swal("Oops", "Please Insert Status", "error")
    } else if ($('#Id').val() == "" || $('#Id').val() == " ") {
        Save();
    } else {
        Edit();
    }
}


function Approve() {
    document.getElementById('Status1').value = "Approved";
    Edit();
}

function Reject() {
    document.getElementById('Status1').value = "Reject";
    Edit();
}