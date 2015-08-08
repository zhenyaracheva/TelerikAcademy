function solve() {
    return function Test(selector) {
        var $selected = $(selector)
            .hide();
        var options = $selected.find('option');

        var $divContainer = $('<div>')
            .addClass('dropdown-list')
            .append($selected);

        var $currentSelection = $('<div>')
            .addClass('current')
            .attr('data-value', '')
            .text('Select value');

        var $divOptionsContainer = $('<div>')
            .addClass('options-container')
            .css({
                'position': 'absolute',
                'display': 'none'
            });

        $currentSelection.on('click', (function () {
            $divOptionsContainer.toggle();
            $currentSelection.text('Select a value');
        }));

        $divOptionsContainer.on('click', function (ev) {
            var $clicked = $(ev.target);
            var $divToDisplay = $('.current');
            $divToDisplay.text($clicked.html());
            $selected.val($clicked.attr('data-value'));

            var $container = $(this)
                .css('display', 'none');
        });

        for (var i = 1; i <= options.length; i++) {
            var newOpt = $('<div>')
                .addClass('dropdown-item')
                .attr('data-value', $(options[i]).val())
                .attr('data-index', i - 1)
                .text($(options[i]).text());

            $divOptionsContainer.append(newOpt);
        }


        $currentSelection.appendTo($divContainer);
        $divOptionsContainer.appendTo($divContainer);
        $divContainer.appendTo('body');

    };
}
Test('select');
//module.exports = solve;
