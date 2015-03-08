define(['./configService', 'mapping'], function(configService, mapping) {
    return {
        getPeople: function() {
            return $.ajax({
                url: configService.peopleUrl,
                type: 'get',
                dataType: 'json',
            });
        },
        savePerson: function (person) {
            return $.ajax({
                url: configService.peopleUrl,
                type: 'post',
                dataType: 'json',
                data: mapping.toJS(person)
            });
        },
        getColours: function () {
            return $.ajax({
                url: configService.colourUrl,
                type: 'get',
                dataType: 'json',
            });
        }
    };
})