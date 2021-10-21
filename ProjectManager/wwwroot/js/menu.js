var main = function() {
    $('.icon-menu').click(function() {
        $('.menu').animate({ 
            left: '0px'
        }, 200);
        
        $('body').animate({
            left: '400px'
        }, 200);
    });

    $('.menu-icon-close').click(function() {
        $('.menu').animate({
            left: '-400px' 
        }, 200);
        
    $('body').animate({
            left: '0px'
        }, 200);
    });
};

$(document).ready(main);
