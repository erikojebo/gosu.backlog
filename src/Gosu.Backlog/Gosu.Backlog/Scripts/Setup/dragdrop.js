var gb = gb || {};

ko.bindingHandlers.drop = {
    init: function (element, valueAccessor) {
        $(element).droppable({
            drop: function (event, ui) {
                var callback = ko.unwrap(valueAccessor());
                var droppedViewModel = ko.dataFor(ui.draggable[0]);
                callback(droppedViewModel);
            }
        });
    }
};

gb.initializeDragDrop = function() {
    
    $("th").draggable({
        helper: 'clone'
    });
}