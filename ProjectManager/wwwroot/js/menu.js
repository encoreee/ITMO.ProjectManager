var main = function () {
    $('.icon-menu').click(function () {
        $('.menu').animate({
            left: '0px'
        }, 200);

        $('body').animate({
            left: '400px'
        }, 200);
    });

    $('.menu-icon-close').click(function () {
        $('.menu').animate({
            left: '-400px'
        }, 200);

        $('body').animate({
            left: '0px'
        }, 200);
    });
};


var chatmenu = function () {
    $('.icon-chatmenu').click(function () {
        $('.chatmenu').animate({
            right: '0px'
        }, 200);

        $('body').animate({
            right: '400px'
        }, 200);
    });

    $('.chatmenu-icon-close').click(function () {
        $('.chatmenu').animate({
            right: '-400px'
        }, 200);

        $('body').animate({
            right: '0px'
        }, 200);
    });
};

$(document).ready(main);
$(document).ready(chatmenu);




const msgerForm = get(".msger-inputarea");
const msgerInput = get(".msger-input");
const msgerChat = get(".msger-chat");



function appendMessage(text) {
    var today = new Date();
    var time = today.getHours() + ":" + today.getMinutes();
    //var time = new Date().toLocaleTimeString('en-US', {
    //    hour12: false,
    //    hour: "numeric",
    //    minute: "numeric"
    //});
    

    var chat_id = $(".msger-chat").attr("chat-id");

    $.ajax({
        url: '/Project/addMessageToChat',
        method: 'get',
        dataType: 'html',
        data: {
            chatid: chat_id,
            text: text,
            date: time
        },
        success: function (data) {

            const msgHTML = '<div class="msgcontainer"><p>' + text + '</p><span class="time-right">' + time + '</span><span class="userright">' + data +'</span></div>';
            msgerChat.insertAdjacentHTML('beforeend', msgHTML);
            msgerChat.scrollTop += 500;
        }
    });

}

function get(selector, root = document) {
    return root.querySelector(selector);
}

msgerForm.addEventListener("submit", event => {
    event.preventDefault();

    const msgText = msgerInput.value;
    if (!msgText) return;

    appendMessage( msgText);
    msgerInput.value = "";

});