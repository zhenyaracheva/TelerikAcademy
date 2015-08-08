function solve() {
    return function () {
        $.fn.listview = function (data) {
            var $this = this,
                holderTemplate = $this.attr('data-template'),
                template = $('#' + holderTemplate).html(),
                compiled = handlebars.compile(template);

            for (var i = 0; i < data.length; i++) {
                $this.append(compiled(data[i]));
            }

            return this;
        };
    };
}

module.exports = solve;