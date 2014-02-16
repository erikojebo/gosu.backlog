gb.createCardViewModel = function () {

    var upperRight = ko.observable();
    var description = ko.observable();
    var title = ko.observable();
    var lowerRight = ko.observable();
    var lowerLeft = ko.observable();

    return {
        upperRight: upperRight,
        description: description,
        title: title,
        lowerLeft: lowerLeft,
        lowerRight: lowerRight
    };
};