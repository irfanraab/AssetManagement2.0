$(document).ready(function () {
    LoadIndexTypeItem();
    $('#tableTypeItem').DataTable({
        "ajax": LoadIndexTypeItem()
    })
})

function LoadIndexTypeItem() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/TypeItems/LoadTypeItem/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_TypeItem + '</td>';
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
    var typeItem = new Object();
    typeItem.Name_TypeItem = $('#Name').val();
    $.ajax({
        url: "/TypeItems/InsertOrUpdate/",
        data: typeItem,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/TypeItems/Index/';
                });
            LoadIndexTypeItems();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var typeItem = new Object();
    typeItem.Id = $('#Id').val();
    typeItem.Name_TypeItem = $('#Name').val();
    $.ajax({
        url: "/TypeItems/InsertOrUpdate/",
        data: typeItem,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexTypeItem();
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/TypeItems/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_TypeItem);

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
            url: "/TypeItems/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/TypeItems/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Type Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}