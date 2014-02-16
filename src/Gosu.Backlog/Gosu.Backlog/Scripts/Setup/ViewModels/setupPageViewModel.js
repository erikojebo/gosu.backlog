var gb = gb || {};

gb.createSetupPageViewModel = function (headerViewModels, backlogItemViewModels) {
    
    var backlogItems = ko.observableArray(backlogItemViewModels);
    var headers = ko.observableArray(headerViewModels);
    var upperRight = ko.observable();
    var description = ko.observable();
    var title = ko.observable();
    var lowerRight = ko.observable();
    var lowerLeft = ko.observable();

    return {
        backlogItems: backlogItems,
        headers: headers,
        upperRight: upperRight,
        description: description,
        title: title,
        lowerLeft: lowerLeft,
        lowerRight: lowerRight
    };
};