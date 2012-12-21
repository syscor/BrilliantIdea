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

SysCor.doSubmitSuccess = function (result) {
    $('#alertsContainer').html("");
    $('div#bodyContainer').html(result);
};

SysCor.expandAndCollapse = function (node) {
    if (node.childList == null) {
        return;
    }

    for (var i = 0; i < node.childList.length; i++) {
        node.childList[i].toggleExpand();
        SysCor.expandAndCollapse(node.childList[i]);
        node.childList[i].toggleExpand();
    }
};

SysCor.loadStoredValue = function (variableName) {
    var value = $("#" + variableName).val();
    if (typeof value == "undefined") {
        alert("No se puede cargar el valor con el nombre: " + variableName);
        return false;
    }

    return value;
};

SysCor.showAlert = function (type, head, message) {
    $('#alertsContainer').html('<div class="' + type + '"><button type="button" class="close" data-dismiss="alert">&times;</button><h4>' + head + '</h4>' + message + '</div>');
};

SysCor.AlertEnum = {
    Alert: "alert",
    Error: "alert alert-error",
    Success: "alert alert-success",
    Information: "alert alert-info"
};

SysCor.AlertGenericMessages = {
    Success: "La operación se ha realizado con éxito",
    Error: "Se ha producido un problema, favor de intentarlo de nuevo o comunicarse con su administrador de sistemas"
};

SysCor.trees = {};