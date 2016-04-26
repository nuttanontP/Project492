//delete one by one in tab 1
function dels(j) {
    console.log("del it");
    $('#addrs' + j).remove();
}

//script1

$(document).ready(function () {
    var j = 1;
    functionOne();
    $("#add_rows").click(function () {
        $('#tab_logics').append('<tr id="addrs' + (j + 1) + '"></tr>');
        $('#addrs' + j).html("<td><input type 'text' name='date' placeholder='select date' class='form-control datepicker'/></td><td><input name='per' type='text' placeholder='eg. 123' class='form-control input-md'  /> </td><td><input name='con' type='text' placeholder='eg. 123' class='form-control input-md' /></td><td class='text-center'><button type='button' class='btn btn-success  btn-xs glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning  btn-xs glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger  btn-xs glyphicon glyphicon-trash' onclick='dels(" + j + ")'></button></td>");
        j++;
        functionOne();
    });
    $("#delete_rows").click(function () {
        if (j > 1) {

            $("#addrs" + (j - 1)).html('');
            j--;
        }
    });

});





function functionOne(j) {
    console.log(j);
    var $input = $('.datepicker').pickadate({
        format: 'dd/mm/yyyy',
        formatSubmit: 'dd/mm/yyyy',
        // min: [2015, 7, 14],
        container: '#datePopup',
        // editable: true,
        closeOnSelect: true,
        closeOnClear: false,
    })

    var picker = $input.pickadate('picker')
    // picker.set('select', '14 October, 2014')
    // picker.open()

    // $('button').on('click', function() {
    //     picker.set('disable', true);
    // });
}
