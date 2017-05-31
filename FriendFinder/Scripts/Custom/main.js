$(document).ready(function () {
    findNumberOfMessage();

});

var findNumberOfMessage = function () {
    $.ajax({
        url: '/Message/FindMessageNumber',
        type: 'post',
        
        success: function (result) {
            //$("#content").remove();
            $("#messageNo").text(result);
        },
        error: function (result) {
            console.log(result);
        }
    });
};