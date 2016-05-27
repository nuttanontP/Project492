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
                var name = data[i]["first_name"];
                join = new Date(Date.parse(data[i]["timestamp"]));
                var monthNames = ["January", "February", "March", "April", "May", "June","July", "August", "September", "October", "November", "December"];
                var date = monthNames[join.getMonth()] +"-"+ join.getFullYear();
                console.log(date);
                $('#user_create').append('<li id=create'+(parseInt(i)+1)+'></li>');
                console.log(parseInt(i));
                console.log(name);
                $('#create' + i).html('<img src="../assets/img/nontpic/' + name + '.jpg" alt="User Image"/> <a class="users-list-name" href="#">' + name + '</a> <span class="users-list-date">' +'</span> ');
                i++;
            }
                    
        }
    });

    $.ajax({
        type: "POST",
        data: JSON.stringify(data_pro),
        url: "http://localhost:1291/Service1/getuserbycompany",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            for (i in data) {
                var name = data[i]["first_name"];
                join = new Date(Date.parse(data[i]["timestamp"]));
                var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
                var date = monthNames[join.getMonth()] + "-" + join.getFullYear();
                console.log(date);
                $('#user_create').append('<li id=create' + (parseInt(i) + 1) + '></li>');
                console.log(parseInt(i));
                console.log(name);
                $('#create' + i).html('<img src="../assets/img/nontpic/' + name + '.jpg" alt="User Image"/> <a class="users-list-name" href="#">' + name + '</a> <span class="users-list-date">' + date + '</span> ');
                i++;
            }

        }
    });
}