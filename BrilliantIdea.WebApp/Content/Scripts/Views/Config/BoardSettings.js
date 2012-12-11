BoardSettings = {};

BoardSettings.initialize = function() {
    $(document).ready(function() {
        $("#boardSteps").wijtabs();
    });
    $.getJSON("/config/getboards", function(data) {
        var x = data;
    });
};

