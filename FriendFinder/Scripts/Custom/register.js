function firstShowNext() {
    //validate
    //validateNameEmailPassword();
  $("#firstDiv").hide();
  $("#secondDiv").show();
};

var validateNameEmailPassword = function () {
    var flag = true;
    var result = IsEmailExists();
    console.log(result);
    if(result==true)
    {
        alert('i am inside');
        flag = false;
        $("#Email").parent().addClass('has-error');
        //show validation message
    }
};
var IsEmailExists = function () {
    $.ajax({
        url: '/Login/IsEmailExists',
        type:'post',
        data: {'email':$("#Email").val()},
        success: function (result) {
            return result;
        },
        error:function(result)
        {
            console.log(result);
        }
    });
};



$(document).ready(function () {
    $("#DateOfBirth").addClass('form-control');
});

function secondShowNext() {
    $("#secondDiv").hide();
    $("#thirdDiv").show();
};

function thirdShowNext() {
    $("#thirdDiv").hide();
    $("#fourthDiv").show();
};

function secondShowPrevious() {
    $("#secondDiv").hide();
    $("#firstDiv").show();
};

function thirdShowPrevious() {
    $("#thirdDiv").hide();
    $("#secondDiv").show();
};

function fourthShowPrevious() {
    $("#fourthDiv").hide();
    $("#thirdDiv").show();
}