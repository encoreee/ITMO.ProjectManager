(function () {
   
    $(".logout-btn")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
    $(".enter-btn")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
});




$(function () {
    $(".project-area").sortable();
    $(".project-area").disableSelection();

    $(".columns-area").sortable();
    $(".columns-area").disableSelection();

    $(".project")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
        .find(".project-header")
        .addClass("ui-widget-header ui-corner-all");

    $(".newproject-button")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")

    $(".sortable").sortable({
        cancel: ".newproject-button"
    });

    $(".icon-project-toggle-wrapper").prepend("<span class='ui-icon ui-icon-minusthick project-toggle'></span>");
    $(".icon-project-close-wrapper").prepend("<span class='ui-icon ui-icon-closethick project-close'></span>");

    $(".project-toggle").on("click", function () {
        var icon = $(this);
        icon.toggleClass("ui-icon-minusthick ui-icon-plusthick");
        icon.closest(".project").find(".project-content").toggle();
    });


    $(".project-close").on("click", function () {
        var icon = $(this);
        var project_id = icon.closest(".project").attr("project-id");

        $.ajax({
            url: '/Projects/DeleteProject',
            method: 'get',
            dataType: 'html',
            data: { id: project_id },

        });
        icon.closest(".project").hide();
    });

    $(".project").dblclick(function () {

        var project_id = $(this).attr("project-id");

        var url = "/Project/?id=" + project_id;
        $(location).attr('href', url);

    });

    $(".column")
        .find(".column-header")
        .addClass("ui-widget-header ui-corner-all");

    $(".column").sortable({
        connectWith: ".column",
        handle: ".task-header",
        cancel: ".task-toggle",
        placeholder: "task-placeholder ui-corner-all"
    });

    $(".icon-column-close-wrapper").prepend("<span class='ui-icon ui-icon-closethick column-close'></span>");
    
    $(".column-close").on("click", function () {
        var icon = $(this);
        var column_id = icon.closest(".column").attr("column-id");

        $.ajax({
            url: '/Project/DeleteColumn',
            method: 'get',
            dataType: 'html',
            data: { id: column_id },

        });
        icon.closest(".column").hide();
    });

    $(".task")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all")
        .find(".task-header")
        .addClass("ui-widget-header ui-corner-all");

    $(".icon-task-toggle-wrapper").prepend("<span class='ui-icon ui-icon-minusthick task-toggle'></span>");
    $(".icon-task-close-wrapper").prepend("<span class='ui-icon ui-icon-closethick task-close'></span>");

    $(".task-toggle").on("click", function () {
        var icon = $(this);
        icon.closest(".task").find(".task-content").toggle();
    });

    $(".task-close").on("click", function () {
        var icon = $(this);
        var task_id = icon.closest(".task").attr("task-id");

        $.ajax({
            url: '/Project/DeleteTask',
            method: 'get',
            dataType: 'html',
            data: { id: task_id },

        });
        icon.closest(".column").hide();
    });


});

