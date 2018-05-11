// Write your JavaScript code.
$(document).ready(function() {
    $("#bankastraeti").hide();
    $("#kringlan").hide();
    $("#smaralind").hide();
    $("#mapB").hide();
    $("#mapK").hide(); 
    $("#mapS").hide();

    $(".icon-input-btn").each(function(){

        var btnFont = $(this).find(".btn").css("font-size");
    
        var btnColor = $(this).find(".btn").css("color");
    
        $(this).find(".glyphicon").css("font-size", btnFont);
    
        $(this).find(".glyphicon").css("color", btnColor);
    
        if($(this).find(".btn-xs").length){
    
            $(this).find(".glyphicon").css("top", "24%");
    
        }
    
    }); 
});

$( "#location1" ).click(function() {
    if($("#location2").hasClass("active") == true)
    {
        $("#location2").removeClass("active");
        $("#location1").addClass("active");
        $( "#mapB, #mapL" ).toggle();
        $( "#lagmuli, #bankastraeti" ).toggle();
    }
    else if($("#location3").hasClass("active") == true)
    {
        $("#location3").removeClass("active");
        $("#location1").addClass("active");
        $( "#mapK, #mapL" ).toggle();
        $( "#lagmuli, #kringlan" ).toggle();
    }
    else if($("#location4").hasClass("active") == true)
    {
        $("#location4").removeClass("active");
        $("#location1").addClass("active");
        $( "#mapS, #mapL" ).toggle();
        $( "#lagmuli, #smaralind" ).toggle();
    }
});

$( "#location2" ).click(function() {
    if($("#location1").hasClass("active") == true)
    {
        $("#location1").removeClass("active");
        $("#location2").addClass("active");
        $( "#mapB, #mapL" ).toggle();
        $( "#lagmuli, #bankastraeti" ).toggle();
    }
    else if($("#location3").hasClass("active") == true)
    {
        $("#location3").removeClass("active");
        $("#location2").addClass("active");
        $( "#mapK, #mapB" ).toggle();
        $( "#bankastraeti, #kringlan" ).toggle();
    }
    else if($("#location4").hasClass("active") == true)
    {
        $("#location4").removeClass("active");
        $("#location2").addClass("active");
        $( "#mapS, #mapB" ).toggle();
        $( "#bankastraeti, #smaralind" ).toggle();
    }
});

$( "#location3" ).click(function() {
    if($("#location2").hasClass("active") == true)
    {
        $("#location2").removeClass("active");
        $("#location3").addClass("active");
        $( "#mapB, #mapK" ).toggle();
        $( "#kringlan, #bankastraeti" ).toggle();
    }
    else if($("#location1").hasClass("active") == true)
    {
        $("#location1").removeClass("active");
        $("#location3").addClass("active");
        $( "#mapK, #mapL" ).toggle();
        $( "#kringlan, #lagmuli" ).toggle();        
    }
    else if($("#location4").hasClass("active") == true)
    {
        $("#location4").removeClass("active");
        $("#location3").addClass("active");
        $( "#mapS, #mapK" ).toggle();
        $( "#kringlan, #smaralind" ).toggle();
    }
});
$( "#location4" ).click(function() {
    if($("#location2").hasClass("active") == true)
    {
        $("#location2").removeClass("active");
        $("#location4").addClass("active");
        $( "#mapB, #mapS" ).toggle();
        $( "#smaralind, #bankastraeti" ).toggle();
    }
    else if($("#location3").hasClass("active") == true)
    {
        $("#location3").removeClass("active");
        $("#location4").addClass("active");
        $( "#mapK, #mapS" ).toggle();
        $( "#smaralind, #kringlan" ).toggle();
    }
    else if($("#location1").hasClass("active") == true)
    {
        $("#location1").removeClass("active");
        $("#location4").addClass("active");
        $( "#mapS, #mapL" ).toggle();
        $( "#smaralind, #lagmuli" ).toggle();
    }
});

$(".cart").click(function() {
    
    var bookId = parseInt(this.name);
    $.ajax({
        url: '/MyCave/AddToCart',
        type: 'POST',    
        dataType: 'json',
        data: { bookId },
        success: function (data) {
            alert("Item has been added to Cart");
        },
        error: function () {
            alert('error');
        }
    });
});
$(".trash").click(function() {
    
    var bookId = parseInt(this.name);
    $.ajax({
        url: '/MyCave/RemoveFromCart',
        type: 'POST',    
        dataType: 'json',
        data: { bookId },
        success: function (data) {
            alert("Item has been removed from Cart");
        },
        error: function () {
            alert('error');
        }
    });
});
$("#orderBy").change(function(e) {
    var input, filter;
    input = $('#orderBy').val();
    if(input == "orderName")
    {
        filter = 1;
    }
    else if(input == "orderAuthor")
    {
        filter = 2;
    }
    else{
        filter = 3;
    }

    $("#order").attr("href","/Book/Filter?filter="+filter);
});

$("#filter").change(function() {
    var input, filter;
    input = $('#genre').val();
    if(input == "adventure")
    {
        filter = 1;
    }
    else if(input == "children")
    {
        filter = 2;
    }
    else if(input == "crime")
    {
        filter = 3;
    }
    else if(input == "fantasy")
    {
        filter = 4;
    }
    else if(input == "fiction")
    {
        filter = 5;
    }
    else if(input == "fun")
    {
        filter = 6;
    }
    else if(input == "technicalBook")
    {
        filter = 7;
    }
    else if(input == "thriller")
    {
        filter = 8;
    }
    else if(input == "translated")
    {
        filter = 9;
    }
    else if(input == "youngAdult")
    {
        filter = 10;
    }
    else{
        filter = 0;
    }

    $("#filter").attr("href","/Book/FilterGenre?filter="+filter);
});