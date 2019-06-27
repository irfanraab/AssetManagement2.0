$(document).ready(function () {
    $(function () {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            todayHighlight: true,
        });
    });
    LoadIndexLoaning();
    LoadItemProject();
    LoadTypeItemProject();
    $('#tableLoaning').DataTable({
        "ajax": LoadIndexLoaning()
    })
})

function LoadIndexLoaning() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Loaning/LoadLoaning/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + 0 + '</td>';
                html += '<td>' + val.TypeItem.Name_TypeItem + '</td>';
                html += '<td>' + val.Item.Name_Item + '</td>';
                html += '<td>' + val.Quantity + '</td>';
                html += '<td>' + moment(val.Date_Return).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + moment(val.Date_Loaning).format("MM/DD/YYYY") + '</td>';
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
    var loaning = new Object();
    loaning.Quantity = $('#Quantity').val();
    loaning.Date_Loaning = $('#Date_Loaning').val();
    loaning.Date_Return = $('#Date_Return').val();
    loaning.User_Id = $('#User_Id').val();
    loaning.Item_Id = $('#Item_Id').val();
    loaning.TypeItem_Id = $('#TypeItem_Id').val();
    $.ajax({
        url: "/Loaning/InsertOrUpdate/",
        data: loaning,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Loaning/Index/';
                });
            LoadIndexLoaning();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var loaning = new Object();
    loaning.Id = $('#Id').val();
    loaning.Quantity = $('#Quantity').val();
    loaning.Date_Loaning = $('#Date_Loaning').val();
    loaning.Date_Return = $('#Date_Return').val();
    loaning.User_Id = $('#User_Id').val();
    loaning.Item_Id = $('#Item_Id').val();
    loaning.TypeItem_Id = $('#TypeItem_Id').val();
    $.ajax({
        url: "/Loaning/InsertOrUpdate/",
        data: loaning,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexLoaning();
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Loaning/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#User_Id').val(result.User_Name);
            $('#Item_Id').val(result.Name_Item);
            $('#TypeItem_Id').val(result.Name_TypeItem);
            $('#Quantity').val(result.Quantity);
            $('#Date_Return').val(moment(result.Date_Return).format('MM/DD/YYYY'));
            $('#Date_Loaning').val(moment(result.Date_Loaning).format('MM/DD/YYYY'));

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
            url: "/Loaning/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Loaning/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function LoadItemProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Loaning/GetItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Name_Item + '</option>';
                });

            $('#Item_Id').html(html);
        }
    });
}

function LoadTypeItemProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Loaning/GetTypeItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Name_TypeItem + '</option>';
                });

            $('#TypeItem_Id').html(html);
        }
    });
}
function ClearScreen() {
    $('#User_Id').val('');
    $('#Item_Id').val('');
    $('#TypeItem_Id').val('');
    $('#Date_Return').val('');
    $('#Date_Loaning').val('');
    $('#Quantity').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#User_Id').val() == "" || $('#User_Id').val() == " ") {
        swal("Oops", "Please Insert User ID", "error")
    } else if ($('#Item_Id').val() == "" || $('#Item_Id').val() == "") {
        swal("Oops", "Please Insert Item ID", "error")
    } else if ($('#TypeItem_Id').val() == "" || $('#TypeItem_Id').val() == "") {
        swal("Oops", "Please Insert Type Item ID", "error")
    } else if ($('#Date_Return').val() == "" || $('#Date_Return').val() == " ") {
        swal("Oops", "Please Insert Date Return", "error")
    } else if ($('#Date_Loaning').val() == "" || $('#Date_Loaning').val() == " ") {
        swal("Oops", "Please Insert Date Loaning", "error")
    } else if ($('#Quantity').val() == "" || $('#Quantity').val() == " ") {
        swal("Oops", "Please Insert Quantity", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}