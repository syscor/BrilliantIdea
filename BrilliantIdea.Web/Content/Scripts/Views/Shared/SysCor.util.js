SysCor = {};
SysCor.requestObject = {};

SysCor.initialize = function() {
    $('#monitorTabs').tabs();
    SysCor.performViewChange("settings/homesettings");
};

SysCor.performViewChange = function(url) {

    SysCor.requestObject.url = url;
    SysCor.requestObject.type = "GET";
    SysCor.requestObject.data = {};
    SysCor.requestObject.success = function(data) {
        SysCor.LastUrlLoaded = url;
        $('#viewContainer').html('');
        var currentView = '<div>' + data + '</div>';
        $('#viewContainer').html(currentView);
    };
    jQuery.ajax(SysCor.requestObject);
};