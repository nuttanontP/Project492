
//delete one by one in tab 1
function dels(j) {
    console.log("del it");
    $('#addrs' + j).remove();
}
function del(i) {
    console.log("del it");
    $('#addr' + i).remove();
}

//script1
$(document).ready(function () {
    var j = 1;
    functionOne();
    $("#add_rows").click(function () {
        $('#tab_logics').append('<tr id="addrs' + (j + 1) + '"></tr>');
        $('#addrs' + j).html("<td><input type 'text' name='date' placeholder='select date' class='form-control datepicker'/></td><td><input name='meter'  type='text' placeholder='eg.1024' class='form-control input-md'  /> </td><td class='text-center'><button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning glyphicon glyphicon-pencil'></button> <button type='button'  class='btn btn-danger glyphicon glyphicon-trash' onclick='dels(" + j + ")'></button></td>");
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
//script2
$(document).ready(function () {

    var i = 1;
    functionOne();
    $("#add_row").click(function () {


        $('#addr' + i).html("<td>  <input type='text' name='date' placeholder='select date' class='form-control datepicker' /></td><td><input name='name[] ' type='text' placeholder='eg.1250' class='form-control input-md'  /> </td><td><input  name='mail" + i + "' type='text' placeholder='eg. 1200'  class='form-control input-md'></td><td><input  name='mobile" + i + "' type='text' placeholder='eg. 1400'  class='form-control input-md'></td><td class='text-center'><button type='button' class='btn btn-success glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger glyphicon glyphicon-trash' onclick='del(" + i + ")'></button></td>");
        $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
        i++;
        functionOne();
    });
    $("#delete_row").click(function () {
        if (i > 1) {
            $("#addr" + (i - 1)).html('');
            i--;
        }
    });



});




function functionOne() {
    var $input = $('.datepicker').pickadate({
        format: "dd/mm/yyyy",
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
