$(document).ready(function () {
    $(function () {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            todayHighlight: true,
        });
    });
    LoadIndexItem();
    $('#tableItem').DataTable({
        "ajax": LoadIndexItem()
    })
})

function LoadIndexItem() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Items/LoadItem/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Item + '</td>';
                html += '<td>' + val.Merk + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Photo_Item + '</td>';
                html += '<td>' + moment(val.Year_Procurement).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + val.Stock + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.TypeItem.Name_TypeItem + '</td>';
                html += '<td>' + val.Location.Name_Location + '</td>';
                html += '<td>' + val.Condition.Condition_Name + '</td>';
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Save() {
    var item = new Object();
    item.Name_Item = $('#Name').val();
    item.Merk = $('#Merk').val();
    item.Description = $('#Description').val();
    item.Photo_Item = $('#PhotoItem').val();
    item.Year_Procurement = $('#YearProcurement').val();
    item.Stock = $('#Stock').val();
    item.Price = $('#Price').val();
    item.TypeItem_Id = $('#TypeItem').val();
    item.Location_Id = $('#Location').val();
    item.Condition_Id = $('#Condition').val();
    $.ajax({
        url: "/Items/InsertOrUpdate/",
        data: item,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Items/Index/';
                });
            LoadIndexItem();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var item = new Object();
    item.Id = $('#Id').val();
    item.Name_Item = $('#Name').val();
    item.Merk = $('#Merk').val();
    item.Description = $('#Description').val();
    item.Photo_Item = $('#PhotoItem').val();
    item.Year_Procurement = $('#YearProcurement').val();
    item.Stock = $('#Stock').val();
    item.Price = $('#Price').val();
    item.TypeItem_Id = $('#TypeItem').val();
    item.Location_Id = $('#Location').val();
    item.Condition_Id = $('#Condition').val();
    $.ajax({
        url: "/Items/InsertOrUpdate/",
        data: item,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Items/Index/';
                });
            LoadIndexItem();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $('#myModal').modal('show');
    $.ajax({
        url: "/Items/GetById/",
        data: { Id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Item);
            $('#Merk').val(result.Merk);
            $('#Description').val(result.Description);
            $('#PhotoItem').val(result.Photo_Item);
            $('#YearProcurement').val(moment(result.Year_Procurement).format('MM/DD/YYYY'));
            $('#Stock').val(result.Stock);
            $('#Price').val(result.Price);
            $('#TypeItem').val(result.TypeItem_Id);
            $('#Location').val(result.Location_Id);
            $('#Condition').val(result.Condition_Id);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "/Items/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Items/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Condition').val('');
    $('#Location').val('');
    $('#TypeItem').val('');
    $('#Price').val('');
    $('#Stock').val('');
    $('#YearProcurement').val('');
    $('#PhotoItem').val('');
    $('#Description').val('');
    $('#Merk').val('');
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Merk').val() == "" || $('#Merk').val() == " ") {
        swal("Oops", "Please Insert Merk", "error")
    } else if ($('#Description').val() == "" || $('#Description').val() == " ") {
        swal("Oops", "Please Insert Description", "error")
    } else if ($('#PhotoItem').val() == "" || $('#PhotoItem').val() == " ") {
        swal("Oops", "Please Insert PhotoItem", "error")
    } else if ($('#YearProcurement').val() == "" || $('#YearProcurement').val() == " ") {
        swal("Oops", "Please Insert Year Procurement", "error")
    } else if ($('#Stock').val() == "" || $('#Stock').val() == " ") {
        swal("Oops", "Please Insert Stock", "error")
    } else if ($('#Price').val() == "" || $('#Price').val() == " ") {
        swal("Oops", "Please Insert Price", "error")
    } else if ($('#TypeItem').val() == "" || $('#TypeItem').val() == " ") {
        swal("Oops", "Please Insert Type Item", "error")
    } else if ($('#Location').val() == "" || $('#Location').val() == " ") {
        swal("Oops", "Please Insert Location", "error")
    } else if ($('#Condition').val() == "" || $('#Condition').val() == " ") {
        swal("Oops", "Please Insert Condition", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}