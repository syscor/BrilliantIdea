SysCor = {};
SysCor.requestObject = {};

SysCor.initialize = function () {
    $('#fountainG').hide();
    $('#bodyContainer').ajaxStart(function () { $('#fountainG').show(); });
    $('#bodyContainer').ajaxComplete(function () { $('#fountainG').hide(); });
};

SysCor.performViewChange = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'html', 
        success: SysCor.doSubmitSuccess
    });
};

SysCor.doSubmitSuccess = function(result) {
    $('div#bodyContainer').html(result);
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
       alert("No se puede cargar el valor con el nombre: " + variableName);
    }
    return value;
};

var app = {
    PreviousNode: null,
    NodeSaved: function (data) { },
    NodeDeleted: function (data) { }
};

SysCor.trees = {};
