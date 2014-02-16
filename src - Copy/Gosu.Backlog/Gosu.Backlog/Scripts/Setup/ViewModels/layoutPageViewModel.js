var gb = gb || {};

gb.createLayoutPageViewModel = function (cardViewModels) {

    var cards = ko.observable(cardViewModels);
    
    return {
        cards: cards
    };
};