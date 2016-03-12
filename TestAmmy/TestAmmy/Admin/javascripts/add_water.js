//delete one by one in tab 1
function dels(j) {
    console.log("del it");
    $('#addrs' + j).remove();
}
//delete one by one in tab 2
function del(i) {
    console.log("del it");
    $('#addr' + i).remove();
}
//delete one by one in tab 3
function delss(k) {
    console.log("del it");
    $('#addrss' + k).remove();
}

//script1

$(document).ready(function () {
    var j = 1;
    functionOne();
    $("#add_rows").click(function () {
        $('#tab_logics').append('<tr id="addrs' + (j + 1) + '"></tr>');
        $('#addrs' + j).html("<td><input type='text' name='date0' placeholder='select date' class='form-control datepicker'/></td><td><input name='meter0' type='text' placeholder='eg. 1024' class='form-control input-md'  /> </td><td class='text-center'><button type='button' class='btn btn-success btn-xs glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning btn-xs glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger btn-xs glyphicon glyphicon-trash' onclick='dels(" + j + ")'></button></td>");
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
        $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
        $('#addr' + i).html("<td><input type='text' name='date1' placeholder='select date' class='form-control datepicker'/></td><td><input name='meter1' type='text' placeholder='eg. 1024' class='form-control input-md'  /> </td><td class='text-center'><button type='button' class='btn btn-success btn-xs glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning btn-xs glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger btn-xs glyphicon glyphicon-trash' onclick='dels(" + i + ")'></button></td>");
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

//script3
$(document).ready(function () {
    var k = 1;
    functionOne();
    $("#add_row3").click(function () {
        $('#tab_logic3').append('<tr id="addrss' + (k + 1) + '"></tr>');
        $('#addrss' + k).html("<td><input type='text' name='date2' placeholder='select date' class='form-control datepicker'/></td><td><input name='meter2' type='text' placeholder='eg. 1024' class='form-control input-md'  /> </td><td class='text-center'><button type='button' class='btn btn-success btn-xs glyphicon glyphicon-floppy-disk'></button> <button type='button' class='btn btn-warning btn-xs glyphicon glyphicon-pencil'></button> <button type='button' class='btn btn-danger btn-xs glyphicon glyphicon-trash' onclick='dels(" + k + ")'></button></td>");
        k++;
        functionOne();
    });
    $("#delete_row3").click(function () {
        if (k > 1) {
            $("#addrss" + (k - 1)).html('');
            k--;
        }
    });

});



function functionOne() {
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
