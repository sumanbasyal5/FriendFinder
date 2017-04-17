var searchUser = function () {
    $.ajax({
        url: '/Login/SearchUser',
        type: 'post',
        data: {
            'cityName': $("#txtCity").val(),
            'currentCountryId': $("#CurrentCountryId").val(),
            'currentStateId': $("#CurrentStateId").val(),
            'permanentCountryId': $("#PermanentCountryId").val()
        },
        success: function (result) {
            //$("#content").remove();
            $("#searchResultContent").find("tr:gt(0)").remove();
            var trHTML = '';

            $.each(result, function (i, item) {
              
                trHTML += '<tr> <td><span id="rounded_span">' + item.FirstName[0] + '</span></td> <td>' + item.FirstName + '</td><td>' + item.LastName + '</td>  <td>' + item.CurrentAddress + '</td> <td>' + item.Email + '</td>  <td>  <span onclick="showDialog(this);" data-toggle="modal" data-target="#exampleModal"  class="glyphicon glyphicon-envelope" data-userid="' + item.UserId + '" data-name="' + item.FirstName + " " + item.LastName + '" ></span></td>  </tr>';

                //trHTML += '<tr> <td><span id="rounded_span">' + item.FirstName[0] + '</span></td> <td>' + item.FirstName + '</td><td>' + item.LastName + '</td>  <td>' + item.CurrentAddress + '</td> <td>' + item.Email + '</td>  <td>  <span onclick="sendMessage(this);"  class="glyphicon glyphicon-envelope" data-userid="' + item.UserId + '" data-name="' + item.FirstName + " " + item.LastName + '" ></span></td>  </tr>';
            });

            $('#searchResultContent').append(trHTML);


            //for(i=0;i<result.length;i++)
            //{  
            //    $("#content").append('<p> '+ result[i].FirstName  +"--->"+ result[i].Email+'  </p>');
            //}
        },
        error: function (result) {
            console.log(result);
        }
    });
};

$(document).ready(function () {


    //$('#exampleModal').on('show.bs.modal', function (e) {
    //    //var button = $(event.relatedTarget) // Button that triggered the modal
    //    //var recipient = button.data('whatever') // Extract info from data-* attributes
    //    //// If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    //    //// Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    //    //var modal = $(this)
        
    //    //debugger;
    //    //var receiverId = $("#txtReceiverId").val();
        
    //    //var fullName = $("#txtName").val();
    //    //$("#receiverId").val(receiverId);
    //    //$("#fullName").val(fullName);
    //    //modal.find('.modal-title').text('New message to ' + recipient)
    //    //modal.find('.modal-body input').val(recipient)
    //})

});


var showDialog=function(e)
{
    var receiverId = $(e).attr("data-userid");
    var fullName = $(e).attr("data-name");
    $("#receiverId").text(receiverId);
    $("#fullName").text(fullName);
    
}


var sendMessage = function () {
    $.ajax({
        url: '/Home/SaveMessage',
        type: 'post',
        data: {
            'receiverId': $("#receiverId").text(),
            'message': $("#messageText").val(),
            
        },
        success: function (result) {
           
        },
        error: function (result) {
            console.log(result);
        }
    });
};