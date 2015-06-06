if (!String.prototype.bind) {
    String.prototype.bind = function (str, obj) {

        var name = '>' + obj.name + '<';
        str = str.replace(/></g, name);
        var link = 'href="' + obj.link + '" class="' + obj.name + '"';
        str = str.replace(/\b[A-z-=]+"link"\s[A-z-]+="[name]+"/, link);

        return str
    }
}


var str = '<div data-bind-content="name"></div>';
console.log(str.bind(str, {name: 'Steven'}));

var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>';
console.log(bindingString.bind(bindingString, {name: 'Elena', link: 'http://telerikacademy.com'}));