// Problem 1. Make person
var Person = (function () {

    function Person(firstName, lastName, age, gender) {
        var self = this;
        self.firstName = firstName;
        self.lastName = lastName;
        self.age = age;
        self.isFemale = gender
    }

    return Person;
}());

var people = [
    new Person('Pesho', 'Peshov', 55, false),
    new Person('Strafuna', 'Stamatova', 66, true),
    new Person('Gosho', 'Leshev', 155, false),
    new Person('Mima', 'Zafirova', 99, true),
    new Person('Stoqn', 'Stoqnov', 45, false),
    new Person('Sisi', 'Goshova', 6, true),
    new Person('Danail', 'Danailov', 15, false),
    new Person('Maria', 'Marinova', 65, true),
    new Person('Ivan', 'Ivanov', 59, false),
    new Person('Antonio', 'Jorov', 18, false),
];
console.log(people);

// Problem 2. People of age
var over18 = people.every(function (person) {
    return person.age >= 18;
});
console.log(over18);

// Problem 3. Underage people
var underagePeople = people.filter(function (person) {
    return person.age < 18
}).forEach(function (person) {
    console.log(person.firstName + ' ' + person.lastName + ' - ' + person.age);
});

// Problem 4. Average age of females
var averageFemaleSum = people.filter(function (person) {
    return person.isFemale
}).reduce(function (sum, female, index, arr) {
    var count = arr.length;
    return sum + ((female.age / count + 0.5) | 0);
}, 0);
console.log(averageFemaleSum);

// Problem 5. Youngest person
if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

var youngestMale = people.sort(function (first, second) {
    return first.age - second.age;
}).find(function (person) {
    return !person.isFemale
});
console.log(youngestMale);

// Problem 6. Group people
var grouped = people.reduce(function (groups, person) {

    if (groups[person.firstName[0]]) {
        groups[person.firstName[0]].push(person);
    } else {
        groups[person.firstName[0]] = [person]
    }

    return groups;
},{});
console.log(grouped);