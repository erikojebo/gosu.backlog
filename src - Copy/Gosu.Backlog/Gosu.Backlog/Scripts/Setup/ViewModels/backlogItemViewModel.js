var gb = gb || {};

gb.createBacklogItemViewModel = function (values) {

    var valueViewModels = [];

    for (var i = 0; i < values.length; i++) {
        var viewModel = gb.createCellViewModel(values[i], i);
        valueViewModels.push(viewModel);
    }

    var cells = ko.observableArray(valueViewModels);

    var getValueAt = function(index) {
        return cells()[index].value;
    };

    return {
        cells: cells,
        getValueAt: getValueAt
    };
};
