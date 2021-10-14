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

    //$(".task-content").dblclick(function () {
    //    $('.column').sortable("cancel")
    //    $(".columns-area").sortable("cancel");
    //    enableEditing(content);
    //});

    $(".task").dblclick(function () {
        var project_id = $(this).closest(".project-wrapper").attr("project-id");
        var task_id = $(this).attr("task-id");
        var url = "/Project/EditTask/?projectid=" + project_id + "&taskid=" + task_id;
        $(location).attr('href', url);
    });

    $(".columns-area").dblclick(function () {

        


        console.log("project:");
        var project_id = $(this).closest(".project-wrapper").attr("project-id");
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
    element.setAttribute('contentEditable', true)
    //Focuses the element
    element.focus()
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
