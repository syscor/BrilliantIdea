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

SysCor.getModal = function (header, body, customBody, customfooter) {
    var modal = "<div id='sysCorModal' class='modal hide fade' tabindex='-1' role='dialog' aria-labelledby='sysCorModalLabel' aria-hidden='true'>";
    modal += '<div id="modalHeader" class="modal-header"><h3 id="sysCorModalLabel">'+ header + '</h3></div>';
    if (customBody.length>0) {
        modal += customBody; 
    } else {
        modal += '<div id="modalBody" class="modal-body"><p>'+ body +'</p></div>';          
    }
    if (customfooter.length>0) {
        modal += customfooter;
    } else {
        modal += '<div id="modalFooter" class="modal-footer"><a href="javascript:void(0);" class="btn" data-dismiss="modal">Cancelar</a><a id="modalYes" href="javascript:void(0);" class="btn btn-primary">Aceptar</a></div></div>';
    }
    return modal;
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