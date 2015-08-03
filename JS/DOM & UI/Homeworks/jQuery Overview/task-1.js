function solve() {
    return function Test(selector, count) {
        var $ul,
            isNumber,
            li,
            i;


        if (!selector.nodeType && typeof selector !== 'string') {
            throw  new Error('First parameter must DOM element or string ');
        }

        if (typeof  selector === 'string') {
            // browser
            // selector = $('#'+selector);
            //tests:
            selector = $(selector);
        }

        isNumber = /^\d+$/.test(count);
        if (!isNumber) {
            throw new Error('Count must be number');
        }

        count = +count;

        if (count < 1) {
            throw new Error('Number cannot be less than 1');
        }

        $ul = $('<ul />')
            .addClass('items-list');


        for (i = 0; i < count; i += 1) {
            li = $('<li />')
                .addClass('list-item')
                .text('List item #' + i);
            $ul.append(li);
        }

        $ul.appendTo(selector);

    };
};