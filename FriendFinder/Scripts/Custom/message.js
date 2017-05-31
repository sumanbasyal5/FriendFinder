$(document).ready(function () {
    $("#txtMessage").keypress(function (e) {
        if (e.which == 13) {
            sendMessage();
        }
    });

    setInterval("receiveMessage()", 5000);
});

var receiveMessage = function () {
    var senderId = $('.list-group').find('.active').find('span')[1].textContent;
    console.log(senderId);
    if (senderId != "")
    {
        $.ajax({
            url: '/Message/GetAllUnSeenMessagesFromSender',
            type: 'post',
            async:'false',
            data: {
                'senderId': senderId
            },
            success: function (result) {
                for (i = 0; i < result.length; i++) {
                    jQuery('<div/>', {

                        'class': 'received-message',
                        text: result[i]
                    }).appendTo('#chat-area');
                }

            },
            error: function (result) {
                console.log(result);
            }
        });
    }
    
};


var showMessage=function(e)
{
    $('.list-group-item').removeClass('active');
    $('.received-message').remove();
    $(e).addClass('active')
    var senderId = $(e).find('span')[1].textContent;
    $.ajax({
        url: '/Message/GetAllMessageFromSender',
        type: 'post',
        data: {
            'senderId': senderId
        },
        success: function (result) {
            console.log(result);
            for (i = 0; i < result.length; i++)
            {
                jQuery('<div/>', {
                    
                    'class':'received-message',
                    text: result[i].Messages
                }).appendTo('#chat-area');
            }
            
        },
        error: function (result) {
            console.log(result);
        }
    });
}

var sendMessage=function()
{
    var receiverId = $('.list-group').find('.active').find('span')[1].textContent;

    $.ajax({
        url: '/Home/SaveMessage',
        type: 'post',
        data: {
            'receiverId': receiverId,
           'message': $("#txtMessage").val()
        },
        success: function (result) {
            jQuery('<div/>', {

                'class': 'send-message',
                text: $("#txtMessage").val()
            }).appendTo('#chat-area');
        },
        error: function (result) {
            console.log(result);
        }
    });
}



$("#txtMessage").keypress(function (e) {
    if (e.which == 13) {
        alert('You pressed enter!');
        
    }
});



