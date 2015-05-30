function Person(firstName, lastName, age) {
    var self = this;

    if (typeof firstName !== 'string' || typeof  lastName !== 'string' || typeof age !== 'number') {
        throw new Error('Wrong input');
    }

    if (!(this instanceof arguments.callee)) {
        return new Person(firstName, lastName, age);
    }

    self.firstName = firstName;
    self.lastName = lastName;
    self.age = age;
}

if (!Person.prototype.getFullName) {
    Person.prototype.getFullName = function () {
        return this.firstName + ' ' + this.lastName;
    }
}

Array.prototype.orderBy = function (selector, comparer) {
    comparer = comparer || DefaultSortComparer;
    var arr = this.slice(0);
    var fn = function (a, b) {
        return comparer(selector(a), selector(b));
    };

    arr.thenBy = function (selector, comparer) {
        comparer = comparer || DefaultSortComparer;
        return arr.orderBy(DefaultSelector, function (a, b) {
            var res = fn(a, b);
            return res === 0 ? comparer(selector(a), selector(b)) : res;
        });
    };

    arr.thenByDescending = function (selector, comparer) {
        comparer = comparer || DefaultSortComparer;
        return arr.orderBy(DefaultSelector, function (a, b) {
            var res = fn(a, b);
            return res === 0 ? -comparer(selector(a), selector(b)) : res;
        });
    };

    return arr.sort(fn);
};


function getYoungestStudent(people) {
    var ordered = people.orderBy(function (t) {
        return t.age
    }, function (a, b) {
        if ((a | 0) > (b | 0)) return 1;
        if ((a | 0) < (b | 0)) return -1;
        return 0;
    });

    return ordered[0].getFullName();
}

function groupByFirstName(people) {
    return people.orderBy(function (t) {
        return t.firstName
    }, function (a, b) {
        if (a.toUpperCase() > b.toUpperCase()) return 1;
        if (a.toUpperCase() < b.toUpperCase()) return -1;
        return 0;
    })
}

function groupByLatsName(people) {
    return people.orderBy(function (t) {
        return t.lastName
    }, function (a, b) {
        if (a.toUpperCase() > b.toUpperCase()) return 1;
        if (a.toUpperCase() < b.toUpperCase()) return -1;
        return 0;
    })
}

var people = [
    new Person('Asparuh', 'Borqnovski', 255),
    new Person('Vasil', 'Asparuhov', 135),
    new Person('Borqna', 'Vasileva', 179)
];

console.log(getYoungestStudent(people));
console.log(groupByFirstName(people));
console.log(groupByLatsName(people));