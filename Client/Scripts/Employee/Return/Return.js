$(document).ready(function () {
    $(function () {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            todayHighlight: true,
        });
    });
    LoadIndexReturn();
    LoadItemProject();
    LoadTypeItemProject();
    LoadConditionProject();
    $('#tableReturn').DataTable({
        "ajax": LoadIndexReturn()
    })
})

function LoadIndexReturn() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Return/LoadReturn/",
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
                html += '<td>' + val.Condition.Condition_Name + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + moment(val.Date_Return).format("MM/DD/YYYY") + '</td>';
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
    debugger;
    var return1 = new Object();
    return1.Quantity = $('#Quantity').val();
    return1.Description = $('#Description').val();
    return1.Condition_Id = $('#Condition').val();
    return1.Date_Return = $('#Date_Return').val();
    return1.User_Id = $('#User_Id').val();
    return1.Item_Id = $('#Item_Id').val();
    return1.TypeItem_Id = $('#TypeItem_Id').val();
    $.ajax({
        url: "/Return/InsertOrUpdate/",
        data: return1,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Return/Index/';
                });
            LoadIndexReturn();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    debugger;
    var return1 = new Object();
    return1.Id = $('#Id').val();
    return1.Quantity = $('#Quantity').val();
    return1.Description = $('#Description').val();
    return1.Condition_Id = $('#Condition').val();
    return1.Date_Return = $('#Date_Return').val();
    return1.User_Id = $('#User_Id').val();
    return1.Item_Id = $('#Item_Id').val();
    return1.TypeItem_Id = $('#TypeItem_Id').val();
    $.ajax({
        url: "/Return/InsertOrUpdate/",
        data: return1,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexReturn();
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $('#myModal').modal('show');
    $.ajax({
        url: "/Return/GetById/",
        type: "GET",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#User_Id').val(result.User_Name);
            $('#Item_Id').val(result.Name_Item);
            $('#TypeItem_Id').val(result.Name_TypeItem);
            $('#Quantity').val(result.Quantity);
            $('#Condition').val(result.Condition_Id);
            $('#Description').val(result.Description);
            $('#Date_Return').val(moment(result.Date_Return).format('MM/DD/YYYY'));

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
            url: "/Return/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Return/Index/';
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
        url: "/Return/GetItemProject/",
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
        url: "/Return/GetTypeItemProject/",
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

function LoadConditionProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Return/GetConditionProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Condition_Name + '</option>';
                });
            $('#Condition').html(html);
        }
    });
}


function ClearScreen() {
    $('#User_Id').val('');
    $('#Item_Id').val('');
    $('#TypeItem_Id').val('');
    $('#Quantity').val('');
    $('#Condition').val('');
    $('#Description').val('');
    $('#Date_Return').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#User_Id').val() == "" || $('#User_Id').val() == " ") {
        swal("Oops", "Please Insert User ID", "error")
    } else if ($('#Item_Id').val() == "" || $('#Item_Id').val() == " ") {
        swal("Oops", "Please Insert Item ID", "error")
    } else if ($('#TypeItem_Id').val() == "" || $('#TypeItem_Id').val() == " ") {
        swal("Oops", "Please Insert Type Item ID", "error")
    } else if ($('#Quantity').val() == "" || $('#Quantity').val() == " ") {
        swal("Oops", "Please Insert Quantity", "error")
    } else if ($('#Condition').val() == "" || $('#Condition').val() == " ") {
        swal("Oops", "Please Insert Condition", "error")
    } else if ($('#Description').val() == "" || $('#Description').val() == " ") {
        swal("Oops", "Please Insert Description", "error")
    } else if ($('#Date_Return').val() == "" || $('#Date_Return').val() == " ") {
        swal("Oops", "Please Insert Date Return", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}