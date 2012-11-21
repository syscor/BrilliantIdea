SysCor = {};
SysCor.requestObject = {};

SysCor.initialize = function () {
    $('#monitorTabs').tabs();
    $("#menu").wijmenu();
    // SysCor.performViewChange("settings/homesettings");
};

ChangeView = function (url) {
    //Get the current View
    var currentDiv = $('#viewContainer').children().first();

    //Instead of this, ask for confirmation.
    if ($(currentDiv).attr('changed') == 'true') {
        $("#dialog:ui-dialog").dialog("destroy");
        $("#dialog-data").dialog({
            resizable: false,
            height: 150,
            modal: true,
            buttons: {
                "Accept": function () {
                    SysCor.performViewChange(url);
                    $(this).dialog("close");

                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#dialog-data").dialog("open");
        return true;
    }

    SysCor.performViewChange(url);
    //return a successful node click
    return true;
};

SysCor.performViewChange = function (url) {

    SysCor.requestObject.url = url;
    SysCor.requestObject.type = "GET";
    SysCor.requestObject.data = {};
    SysCor.requestObject.success = function (data) {
        SysCor.LastUrlLoaded = url;
        $('#viewContainer').html('');
        var currentView = '<div>' + data + '</div>';
        $('#viewContainer').html(currentView);
    };
    jQuery.ajax(SysCor.requestObject);
};

SysCor.loadTree = function(treeName, url, callback, async) {
    if (typeof async != "undefined") {
        SysCor.requestObject.async = async;
    }

    SysCor.requestObject.url = url;
    SysCor.requestObject.data = {};
    SysCor.requestObject.success = function(data) {
        $("#" + treeName).dynatree(
            {
                children: data,
                onClick: function(node, event) {
                    var targetType = node.getEventTargetType(event);
                    if (targetType != "title" && targetType != "prefix") {
                        return;
                    }
                    if (node.data.url != undefined) {
                        var result = ChangeView(node.data.url);
                        if (result) {
                            app.PreviousNode = node;
                            app.PreviousNode.activate();
                        } else {
                            app.PreviousNode.activateSilently();
                        }
                    }
                }
            });
        
        //add the right click

        var tree = $("#" + treeName).dynatree("getTree");
        var root = tree.getRoot();
        SysCor.trees[treeName] = root;
        //The tree needs to be expanded and collapset to allow omnisearch
        SysCor.expandAndCollapse(root);
        
    };
};

SysCor.expandAndCollapse = function(node) {
    if (node.childList==null) {
        return;
    }

    for (var i = 0; i < node.childList.length; i++) {
        node.childList[i].toggleExpand();
        SysCor.expandAndCollapse(node.childList[i]);
        node.childList[i].toggleExpand();
    }
};

SysCor.loadStoredValue = function(variableName) {
    var value = $("#" + variableName).val();
    if (typeof value == "undefined") {
        SysCor.alert("No se puede cargar el valor con el nombre: " + variableName);
    }
    return value;
};

//Global object, the functions are events that the current view "subscribes" to
var app = {
    PreviousNode: null,
    NodeSaved: function (data) { },
    NodeDeleted: function (data) { }
};

SysCor.trees = {};
SysCor.loadTree('processTree', SysCor.loadStoredValue("processTreUrl"), null);