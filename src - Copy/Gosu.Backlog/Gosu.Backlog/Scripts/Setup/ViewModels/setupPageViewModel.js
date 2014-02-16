var gb = gb || {};

gb.createSetupPageViewModel = function (headerViewModels, backlogItemViewModels) {
    
    var backlogItems = ko.observableArray(backlogItemViewModels);
    var headers = ko.observableArray(headerViewModels);
    var upperRight = ko.observable();
    var description = ko.observable();
    var title = ko.observable();
    var lowerRight = ko.observable();
    var lowerLeft = ko.observable();

    function getValue(item, viewModel) {
        if (!viewModel) {
            return null;
        }

        return item.getValueAt(viewModel.index);
    }

    function createCardViewModel(item) {
        var card = gb.createCardViewModel();

        card.title(getValue(item, title()));
        card.description(getValue(item, description()));
        card.upperRight(getValue(item, upperRight()));
        card.lowerRight(getValue(item, lowerRight()));
        card.lowerLeft(getValue(item, lowerLeft()));

        return card;
    }

    function openLayoutTab(layoutPageViewModel) {
        var childWindow = window.open(gb.urls.layoutCards);
        
        childWindow.addEventListener('load', function() {
            childWindow.initializeLayout(ko, layoutPageViewModel);
        }, false);
    }

    var layoutCards = function () {

        var cardViewModels = backlogItems().map(function(item) {
            return createCardViewModel(item);
        });

        var layoutPageViewModel = gb.createLayoutPageViewModel(cardViewModels);

        openLayoutTab(layoutPageViewModel);
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
