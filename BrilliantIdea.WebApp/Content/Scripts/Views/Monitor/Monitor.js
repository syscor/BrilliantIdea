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
    
   
}