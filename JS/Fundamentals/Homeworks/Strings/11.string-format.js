function stringFormat(format) {
    var args = [].slice.call(arguments, 1);
    return format.replace(/{(\d+)}/g, function(match, number) {
        return typeof args[number] != 'undefined'
            ? args[number]
            : match
;
});
}

var test1 = stringFormat('Hello {0}!', 'Peter');
var frmt = '{0}, {1}, {0} text {2}';
var test2 = stringFormat(frmt, 1, 'Pesho', 'Gosho');

console.log(test1);
console.log(test2);