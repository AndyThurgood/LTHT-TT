requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', ko);
define('mapping', ko.mapping);

define(['durandal/system', 'durandal/app', 'durandal/viewLocator'], function (system, app, viewLocator) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Tech Test Application';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    createBindingHandlers();

    app.start().then(function () {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });

    function createBindingHandlers() {
        ko.bindingHandlers.boolToLabel = {
            init: function (element, valueAccessor) {
                var value = ko.unwrap(valueAccessor());

                if (value) {
                    $(element).toggleClass('label-success', true);
                    $(element).toggleClass('label-danger', false);
                } else {
                    $(element).toggleClass('label-success', false);
                    $(element).toggleClass('label-danger', true);
                }
            },
            update: function (element, valueAccessor) {
                var value = ko.unwrap(valueAccessor());

                if (value) {
                    $(element).toggleClass('label-success', true);
                    $(element).toggleClass('label-danger', false);
                } else {
                    $(element).toggleClass('label-success', false);
                    $(element).toggleClass('label-danger', true);
                }
            }
        };

        ko.bindingHandlers.checkedInArray = {
            init: function (element, valueAccessor, all, vm, bindingContext) {
                ko.utils.registerEventHandler(element, "click", function () {
                    var array = ko.unwrap(valueAccessor()),
                        value = bindingContext.$data,
                        checked = element.checked;

                    if (checked) {
                        array.push(value);
                    } else {
                        var existingItem = ko.utils.arrayFirst(array, function(item) {
                            return item.colourId() == value.colourId();
                        });
                        ko.utils.arrayRemoveItem(array, existingItem);
                    }
                    valueAccessor().notifySubscribers();
                });
            },
            update: function (element, valueAccessor, all, vm, bindingContext) {
                var array = ko.utils.unwrapObservable(valueAccessor()),
                    value = bindingContext.$data;

                var matchingItems = ko.utils.arrayFilter(array, function(item) {
                    return item.colourId() == value.colourId();
                });

                element.checked = matchingItems.length > 0;
            }
        };
    }
});