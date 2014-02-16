var gb = gb || {};

gb.createSetupPageViewModel = function (headerViewModels, backlogItemViewModels) {
    
    var backlogItems = ko.observableArray(backlogItemViewModels);
    var headers = ko.observableArray(headerViewModels);
    var upperRight = ko.observable();


    var setUpperRight = function (header) {
        upperRight(header.title);
    };
    
    return {        
        backlogItems: backlogItems,
        headers: headers,
        setUpperRight: setUpperRight,
        upperRight: upperRight
    };
};