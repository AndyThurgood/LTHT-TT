define(['plugins/dialog'],
    function (dialog) {
        var ctor = function(selectedPerson, colours) {
            this.person = ko.observable(selectedPerson);
            this.availableColours = colours;
            this.cancel = function() {
                dialog.close(this, false);
            };
            this.save = function() {
                dialog.close(this, true);
            };
        };
        return ctor;
    });