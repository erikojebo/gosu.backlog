var gb = gb || {};

gb.createSetupPageViewModel = function (headerViewModels, backlogItemViewModels) {
    
    var backlogItems = ko.observableArray(backlogItemViewModels);
    var headers = ko.observableArray(headerViewModels);
    var upperRight = ko.observable();
    var description = ko.observable();
    var title = ko.observable();
    var lowerRight = ko.observable();
    var lowerLeft = ko.observable();

    var layoutCards = function () {

        var cardViewModels = backlogItems().map(function() {
            return gb.createCardViewModel();
        });

        var layoutPageViewModel = gb.createLayoutPageViewModel(cardViewModels);

        var childWindow = window.open(gb.urls.layoutCards);
        childWindow.addEventListener('load', function() {
            childWindow.initializeLayout(ko, layoutPageViewModel);
        }, false);
    };

    return {
        backlogItems: backlogItems,
        headers: headers,
        upperRight: upperRight,
        description: description,
        title: title,
        lowerLeft: lowerLeft,
        lowerRight: lowerRight,
        layoutCards: layoutCards
    };
};