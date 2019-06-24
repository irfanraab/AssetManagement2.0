$(document).ready(function () {
    LoadIndexParameter();
    $('#tableParameter').DataTable({
        "ajax": LoadIndexParameter()
    })
})

function LoadIndexParameter() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Parameters/LoadParameter/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Validation + '</td>';
                html += '<td>' + val.Punishment + '</td>';
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick=return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Save() {
    var parameter = new Object();
    parameter.Name_Validation = $('#Name').val();
    parameter.Punishment = $('#Punishment').val();
    $.ajax({
        url: "/Parameters/InsertOrUpdate/",
        data: parameter,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Parameters/Index/';
                });
            LoadIndexParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var parameter = new Object();
    parameter.Id = $('#Id').val();
    parameter.Name_Validation = $('#Name').val();
    parameter.Punishment = $('#Punishment').val();
    $.ajax({
        url: "/Parameters/InsertOrUpdate/",
        data: parameter,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Punishments/Index/';
                });
            LoadIndexParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Parameters/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Validation);
            $('#Punishment').val(result.Punishment);

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
            url: "/Parameters/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Punishments/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Punishment').val('');
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Punishment').val() == "" || $('#Punishment').val() == " ") {
        swal("Oops", "Please Insert Punishment", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}