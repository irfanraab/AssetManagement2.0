$(document).ready(function () {
    LoadItemProject();
    LoadTypeItemProject();
    LoadIndexHandover();
    $('#tableHandover').DataTable({
        "ajax": LoadIndexHandover()
    })
})

function LoadIndexHandover() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Handovers/LoadHandover/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Loaning.Id + '</td>';
                html += '<td>' + val.Return.Id + '</td>';
                html += '<td>' + val.User_Id + '</td>';
                html += '<td>' + val.Divhead_Id + '</td>';
                html += '<td>' + val.TypeItem.Name_TypeItem + '</td>';
                html += '<td>' + val.Item.Name_Item + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
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
        url: "/Handovers/GetTypeItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Name_TypeItem + '</option>';
                });

            $('#TypeItem').html(html);
        }
    });
}

function LoadItemProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Handovers/GetItemProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Name_Item + '</option>';
                });

            $('#Item').html(html);
        }
    });
}

function Save() {
    var handover = new Object();
    handover.Loaning_Id = $('#LoaningId').val();
    handover.Return_Id = $('#ReturnId').val();
    handover.User_Id = $('#NameUser').val();
    handover.Divhead_Id = $('#NameDivHead').val();
    handover.TypeItem_Id = $('#TypeItem').val();
    handover.Item_Id = $('#Item').val();
    handover.Description = $('#Description').val();
    $.ajax({
        url: "/Handovers/InsertOrUpdate/",
        data: handover,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Handovers/Index/';
                });
            LoadIndexHandover();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var handover = new Object();
    handover.Id = $('#Id').val();
    handover.Loaning_Id = $('#LoaningId').val();
    handover.Return_Id = $('#ReturnId').val();
    handover.User_Id = $('#NameUser').val();
    handover.Divhead_Id = $('#NameDivHead').val();
    handover.TypeItem_Id = $('#TypeItem').val();
    handover.Item_Id = $('#Item').val();
    handover.Description = $('#Description').val();
    $.ajax({
        url: "/Handovers/InsertOrUpdate/",
        data: handover,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexHandover();
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Handovers/GetById/",
        data: {id: Id},
        success: function (result) {
            $('#Id').val(result.Id);
            $('#LoaningId').val(result.Loaning_Id);
            $('#ReturnId').val(result.Return_Id);
            $('#NameUser').val(result.User_Id);
            $('#NameDivHead').val(result.Divhead_Id);
            $('#TypeItem').val(result.TypeItem_Id);
            $('#Item').val(result.Item_Id);
            $('#Description').val(result.Description);

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
            url: "/Handover/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Handovers/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Description').val('');
    $('#Item').val('');
    $('#TypeItem').val('');
    $('#NameDivHead').val('');
    $('#NameUser').val('');
    $('#ReturnId').val('');
    $('#LoaningId').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#LoaningId').val() == "" || $('#LoaningId').val() == " ") {
        swal("Oops", "Please Insert Loaning ID", "error")
    } else if ($('#ReturnId').val() == "" || $('#ReturnId').val() == " ") {
        swal("Oops", "Please Insert Return ID", "error")
    } else if ($('#NameUser').val() == "" || $('#NameUser').val() == " ") {
        swal("Oops", "Please Insert Name User", "error")
    } else if ($('#NameDivHead').val() == "" || $('#NameDivHead').val() == " ") {
        swal("Oops", "Please Insert Name Divison Head", "error")
    } else if ($('#TypeItem').val() == "" || $('#TypeItem').val() == " ") {
        swal("Oops", "Please Insert Date TypeItem", "error")
    } else if ($('#Item').val() == "" || $('#Item').val() == " ") {
        swal("Oops", "Please Insert Item", "error")
    } else if ($('#Description').val() == "" || $('#Description').val() == " ") {
        swal("Oops", "Please Insert Type Description", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}