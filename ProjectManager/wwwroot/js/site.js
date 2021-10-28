(function () {

    $(".logout-btn")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
    $(".enter-btn")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
});


$(function () {
    $(".projects-area").sortable();
    $(".projects-area").disableSelection();

    $(".columns-area").sortable({
        /* cancel: ".newcolumn-button",*/
        handle: ".column-header",
        /* items: ".column",*/

        /*distance: 20,*/
        stop: function () {
            //  var delayInMilliseconds = 200;
            // setTimeout(makesequence(), delayInMilliseconds);
        },

        start: function (e, ui) {
            $(this).attr('data-previndex', ui.item.index());
        },
        update: function (e, ui) {

            var newIndex = ui.item.index();
            var oldIndex = $(this).attr('data-previndex');

            if (oldIndex != newIndex) {
                //var delayInMilliseconds = 200;
                //setTimeout(makesequence(), delayInMilliseconds);

                makesequence();
            }
            $(this).removeAttr('data-previndex');
        }
    });




    /* $(".columns-area").disableSelection();*/

    $(".project")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")
        .find(".project-header")
        .addClass("ui-widget-header ui-corner-all");

    $(".newproject-button")
        .addClass("ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-state-default")


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
        icon.closest(".project").remove();
    });

    $(".project").dblclick(function () {

        var project_id = $(this).attr("project-id");

        var url = "/Project/?projectid=" + project_id;
        $(location).attr('href', url);
    });

    $(".column")
        .find(".column-header")
        .addClass("ui-widget-header ui-corner-all");



    $(".column").sortable({
        connectWith: ".column",
        handle: ".task-header",
        cancel: ".task-toggle",
        items: ".task",
        distance: 20,
        placeholder: "task-placeholder ui-corner-all",

        stop: function (event, ui) {

            //var project_id = $(".project-wrapper").attr("project-id");
            //var column_id = $(ui.item).closest(".column").attr("column-id");
            //var task_id = $(ui.item).attr("task-id");

            //$.ajax({
            //    url: '/Project/ChangeColumn',
            //    method: 'get',
            //    dataType: 'html',
            //    data: {
            //        projectid: project_id,
            //        columnid: column_id,
            //        taskid: task_id
            //    },
            //});

            //var delayInMilliseconds = 200;
            //setTimeout(makesequence(), delayInMilliseconds);

        },
        start: function (e, ui) {
            $(this).attr('data-previndex', ui.item.index());
        },
        update: function (e, ui) {

            var newIndex = ui.item.index();
            var oldIndex = $(this).attr('data-previndex');
            var project_id = $(".project-wrapper").attr("project-id");
            var column_id = $(ui.item).closest(".column").attr("column-id");
            var task_id = $(ui.item).attr("task-id");


            if (oldIndex != newIndex) {
                $.ajax({
                    url: '/Project/ChangeColumn',
                    method: 'get',
                    dataType: 'html',
                    data: {
                        projectid: project_id,
                        columnid: column_id,
                        taskid: task_id
                    },
                });
                var delayInMilliseconds = 200;
                setTimeout(makesequence(), delayInMilliseconds);
            }

            $(this).removeAttr('data-previndex');

        }

    })
    //.selectable({
    //    filter: ".task",
    //    cancel: ".task-header",
    //    stop: function () {

    //    }
    //});


    $(".icon-column-close-wrapper").prepend("<span class='ui-icon ui-icon-closethick column-close'></span>");

    $(".column-close").on("click", function () {
        var icon = $(this);
        var column_id = icon.closest(".column").attr("column-id");
        var project_id = $(this).closest(".project-wrapper").attr("project-id");

        $.ajax({
            url: '/Project/DeleteColumn',
            method: 'get',
            dataType: 'html',
            data: {
                projectid: project_id,
                columnid: column_id,
            },
            success: function () {

            }

        });
        icon.closest(".column").remove();
        makesequence();

    });
    //$(".newcolumn-button").on("click", function () {

    //    var project_id = $(this).closest(".project-wrapper").attr("project-id");

    //    $.ajax({
    //        url: '/Project/CreateColumn',
    //        method: 'get',
    //        dataType: 'html',
    //        data: {
    //            projectid: project_id,
    //        },
    //        success: function () {
    //            makesequence();
    //        }

    //    });


    //});


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
        var project_id = $(this).closest(".project-wrapper").attr("project-id");

        $.ajax({
            url: '/Project/DeleteTask',
            method: 'get',
            dataType: 'html',
            data: {
                projectid: project_id,
                taskid: task_id
            },
            success: function () {
                icon.closest(".task").remove();
                //var delayInMilliseconds = 1500;
                //setTimeout(makesequence(), delayInMilliseconds);
                makesequence();
            }
        });

    });

    $(".task-content").dblclick(function () {
        var ce = $(this).attr("contentEditable");
        if (ce == 'false') { enableEditing($(this)); }
        else { disableEditing($(this)) }
    });

    //$(".task").dblclick(function () {

    //    var task_id = $(this).attr("task-id");
    //    $.ajax({
    //        url: '/Project/GetChat',
    //        method: 'get',
    //        data: {

    //            taskid: task_id
    //        },
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",

    //        success: function (data) {
    //            alert(data.Id);
    //            alert(data.Messagies)
    //        }
    //    });


    $(".task").dblclick(function () {
        var project_id = $(this).closest(".project-wrapper").attr("project-id");
        var task_id = $(this).attr("task-id");
        var url = "/Project/Index/?projectid=" + project_id + "&taskid=" + task_id;
        $(location).attr('href', url);
    });
});


//$(".column").dblclick(function () {
//    var project_id = $(this).closest(".project-wrapper").attr("project-id");
//    var column_id = $(this).attr("column-id");
//    var url = "/Project/EditColumn/?projectid=" + project_id + "&columnid=" + column_id;
//    $(location).attr('href', url);
//});

//$(".project-overall").dblclick(function () {
//    var project_id = $(".project-wrapper").attr("project-id");
//    var url = "/Project/EditProject/?projectid=" + project_id;
//    $(location).attr('href', url);
//});

$(function () {
    $(".startdatepicker").datetimepicker(
        {
            lang: 'en',
            format: 'd.m.Y H:i'
        });
});

$(function () {
    $(".enddatepicker").datetimepicker(
        {
            lang: 'en',
            format: 'd.m.Y H:i'
        });
});


document.on = function (event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        document.querySelector(".task-content").removeAttribute('contentEditable');
    }
}

function enableEditing(element) {
    //Adds the content editable property to passed element

    $(element).attr('contentEditable', true);
    //Focuses the element
    element.focus();
}

function disableEditing(element) {
    //Adds the content editable property to passed element

    $(element).attr('contentEditable', false);
    //Focuses the element
}

class Project {

    constructor(projectid) {
        this.projectid = projectid;
    }
    columns;
}

class Column {

    constructor(columnid) {
        this.columnid = columnid;
    }
    tasks;
}

class Task {

    constructor(taskid) {
        this.taskid = taskid;
    }
}

function makesequence() {
    console.log("project:");
    var project_id = $(".project-wrapper").attr("project-id");
    console.log(project_id);
    var project = new Project(project_id);

    var columns = document.getElementsByClassName('column');
    let columnsArray = [];
    Array.prototype.forEach.call(columns, function (col) {
        console.log("column:");
        var column_id = col.getAttribute("column-id");
        var column = new Column(column_id);
        columnsArray.push(column);
        console.log(column_id);
        console.log(column_id);
        let taskArray = [];
        var tasks = col.getElementsByClassName('task');
        Array.prototype.forEach.call(tasks, function (ts) {

            console.log("task:");
            var task_id = ts.getAttribute("task-id");
            var task = new Task(task_id);
            console.log(task_id);
            taskArray.push(task);
        });
        column.tasks = taskArray;
    });
    project.columns = columnsArray;
    console.log(project);
    console.log(JSON.stringify(project));

    $.ajax({
        type: "POST",
        url: "/Services/makeSequence",
        data: JSON.stringify(project),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}


//function sortableEnable() {
//    $("ul").sortable();
//    $("ul").sortable("option", "disabled", false);
//    $("li").attr("contentEditable", "false");
//    $("li").css("cursor", "move");
//    return false;
//}

//function sortableDisable() {
//    $("ul").sortable("disable");
//    $("li").attr("contentEditable", "true");
//    $("li").css("cursor", "default");
//    return false;
//}

//$(function () {
//    sortableEnable();
//});