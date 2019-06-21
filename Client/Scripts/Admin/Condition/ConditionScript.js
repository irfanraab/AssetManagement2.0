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
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick=return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}