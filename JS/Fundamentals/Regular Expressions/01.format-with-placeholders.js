if (!String.prototype.format) {
    String.prototype.format = function (option) {
        var i,
            len,
            result,
            matches = this.match(/#{[A-z]+}/g);

        result = [].concat(this).join('');
        for (i = 0, len = matches.length; i < len; i += 1) {
            var match = matches[i].substring(2, matches[i].length - 1);
            result = result.replace(matches[i], option[match]);
        }

        return result;
    }
}

var options = {name: 'John'};
var str = 'Hello, there! Are you #{name}?';
console.log(str.format(options));

var options2 = {name: 'John', age: 13};
var str2 = 'My name is #{name} and I am #{age}-years-old';
console.log(str2.format(options2));