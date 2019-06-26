$(document).ready(function () {
    LoadIndexCondition();
    $('#tableCondition').DataTable({
        "ajax": LoadIndexCondition()
    })
})

function LoadIndexCondition() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Conditions/LoadCondition/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Condition_Name + '</td>';
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
    var condition = new Object();
    condition.Condition_Name = $('#Name').val();
    $.ajax({
        url: "/Conditions/InsertOrUpdate/",
        data: condition,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    window.location.href = '/Conditions/Index/';
                });
            LoadIndexCondition();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function Edit() {
    var condition = new Object();
    condition.Id = $('#Id').val();
    condition.Condition_Name = $('#Name').val();
    $.ajax({
        url: "/Conditions/InsertOrUpdate/",
        data: condition,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexCondition();
            ClearScreen();
        } 
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Conditions/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            console.log(result);
            $('#Id').val(result.Id);
            $('#Name').val(result.Condition_Name);

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
            url: "/Conditions/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Conditions/Index/';
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
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}