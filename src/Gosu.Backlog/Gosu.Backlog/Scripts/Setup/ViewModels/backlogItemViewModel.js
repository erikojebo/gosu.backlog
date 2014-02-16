var gb = gb || {};

gb.createBacklogItemViewModel = function (values) {

    var valueViewModels = [];

    for (var i = 0; i < values.length; i++) {
        var viewModel = gb.createCellViewModel(values[i], i);
        valueViewModels.push(viewModel);
    }

    return {
        cells: ko.observableArray(valueViewModels)
    };
};