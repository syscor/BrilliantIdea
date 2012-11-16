Monitor = {};

Monitor.initialize = function () {

    $(document).ready(function () {
        $("#cmbTemperature").wijcombobox({
            dropdownHeight: 160,
            dropdownWidth: 120,
            showingAnimation: { effect: "blind" },
            hidingAnimation: { effect: "blind" }
        });
    });

};

Monitor.getTemp = function (id) {
    var g = new JustGage({
        id: id,
        value: 45,
        min: 0,
        max: 100,
        title: "Region 1",
        label: "°C"
    });
    var g2 = new JustGage({
        id: "gaugeReg2",
        value: 21,
        min: 0,
        max: 100,
        title: "Region 2",
        label: "°C"
    });
    var g3 = new JustGage({
        id: "gaugeReg3",
        value: 80,
        min: 0,
        max: 100,
        title: "Region 3",
        label: "°C"
    });
    var g4 = new JustGage({
        id: "gaugeReg4",
        value: 45,
        min: 0,
        max: 100,
        title: "Region 4",
        label: "°C"
    });
    var g5 = new JustGage({
        id: "gaugeReg5",
        value: 65,
        min: 0,
        max: 100,
        title: "Region 5",
        label: "°C"
    });
    var g6 = new JustGage({
        id: "gaugeReg6",
        value: 10,
        min: 0,
        max: 100,
        title: "Region 6",
        label: "°C"
    });
}