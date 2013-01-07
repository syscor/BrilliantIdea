SensorSettings = {};
SensorSettings.SensorLogic = {};

function SensorLogic() {
    var self = this;
    self.type = "SensorLogic";
}

SensorSettings.initialize = function () {
    $(document).ready(function () {
        $("#sensorTypes").wijtabs();
    });
    SensorSettings.SensorLogic.SensorSettings = new SensorLogic();
    
};

SensorSettings.getInitialValues = function(sensorLogic) {
    for (var i = 1; i <= 6; i++) {
        $.getJSON("/sensor/GetSensors/" + i, function (data) {

        });
    }
};