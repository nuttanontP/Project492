function getuser(data_pro) {

    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getuserbycompany",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            for (i in data){
                var name = data[i]["first_name"] ;
                $('#user_create').append('<li id=create'+(parseInt(i)+1)+'></li>');
                console.log(parseInt(i));
                console.log(name);
                $('#create'+i).html('<img src="../assets/img/nontpic/'+name+'.jpg" alt="User Image"/> <a class="users-list-name" href="#">'+name+'</a> <span class="users-list-date">12 Jan</span> ');
                i++;
            }
                    
        }
    });
}