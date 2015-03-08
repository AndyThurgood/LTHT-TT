define(['durandal/app', 'knockout', 'mapping', 'services/dataService', 'viewmodels/detail'],
    function (app, ko, mapping, dataService, detail) {

        var people = ko.observableArray([]);
        var colours = ko.observableArray([]);
        var displayName = 'People';
        var cachedPerson;

        function activate() {
            return dataService.getPeople().then(function (data) {
                people(mapping.fromJS(data));
                return dataService.getColours().then(function (response) {
                    return colours(mapping.fromJS(response));
                });
            });
        }

        function canDeactivate() {
            return app.showMessage('Are you sure you want to leave this page?', 'Navigate', ['Yes', 'No']);
        }

        function select(person) {
            cachedPerson = mapping.toJS(person);

            app.showDialog(new detail(person, colours)).then(function (dialogResult) {
                if (dialogResult) {
                    dataService.savePerson(person);
                } else {
                    mapping.fromJS(cachedPerson, {}, person)
                    ;
                }
            });
        }

        return {
            people: people,
            displayName: displayName,
            activate: activate,
            canDeactivate: canDeactivate,
            select: select
        };

    });