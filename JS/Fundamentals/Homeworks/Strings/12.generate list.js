function generateList(people, template) {
    var result = '<ul>',
        i,
        len;
    template = '<strong>-{name}-</strong><span>-{age}-</span>';

    for (i = 0, len = people.length; i < len; i++) {
        result += '<li>';
        result += template.replace('-{name}-', people[i]['name']).replace('-{age}-', people[i]['age']);
        result += '</li>';
    }
    return result + '</ul>';
}

var people = [{name: 'Peter', age: 14}, {name: 'Pesho', age: 105}];
var template = document.getElementById('list-item');
var peopleList = generateList(people, template);

console.log(peopleList);
