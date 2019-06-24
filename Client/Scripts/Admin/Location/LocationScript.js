﻿$(document).ready(function () {
    LoadIndexLocation();
    $('#tableLocation').DataTable({
        "ajax": LoadIndexLocation()
    })
})

function LoadIndexLocation() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Locations/LoadLocation/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Location + '</td>';
                html += '<td>' + val.Floor + '</td>';
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
    var location = new Object();
    location.Name_Location = $('#Name').val();
    location.Floor = $('#Floor').val();
    $.ajax({
        url: "/Locations/InsertOrUpdate/",
        data: location,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Locations/Index/';
                });
            LoadIndexLocation();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var location = new Object();
    location.Id = $('#Id').val();
    location.Name_Location = $('#Name').val();
    location.Floor = $('#Floor').val();
    $.ajax({
        url: "/Locations/InsertOrUpdate/",
        data: location,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Locations/Index/';
                });
            LoadIndexLocation();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Locations/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Location);
            $('#Floor').val(result.Floor);

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
            url: "/Locations/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Locations/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Floor').val('');
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Floor').val() == "" || $('#Floor').val() == " ") {
        swal("Oops", "Please Insert Floor", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}