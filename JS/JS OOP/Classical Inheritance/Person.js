var Person = (function () {
    function Person(firstName, lastName, age) {
        var self = this;
        self.firstname = firstName;
        self.lastname = lastName;
        self.fullname = self.firstname + ' ' + self.lastname;
        self.age = age;
    }

    // validations:
    function validateName(name) {
        var i,
            len;
        if (name.length < 3 || name.length > 20) {
            return false;
        }

        for (i = 0, len = name.length; i < len; i += 1) {
            if (name[i] < 'A' || name[i] > 'z') {
                return false;
            }
        }

        return true
    }

    function validateAge(age) {

        if (isFinite(age)) {
            age = age | 0;
            if (age < 0 || age > 150) {
                return false;
            }
        } else {
            return false;
        }

        return true;
    }


    // Getters and setters:
    Object.defineProperty(Person.prototype, 'firstname', {
        get: function () {
            return this._firstName;
        },
        set: function (name) {
            if (!validateName(name)) {
                throw  new Error('Invalid first name')
            }

            this._firstName = name;
        }
    });

    Object.defineProperty(Person.prototype, 'lastname', {
        get: function () {
            return this._lastName;
        },
        set: function (name) {
            if (!validateName(name)) {
                throw  new Error('Invalid last name')
            }

            this._lastName = name;
        }
    });

    Object.defineProperty(Person.prototype, 'age', {
        get: function () {
            return this._age;
        },
        set: function (age) {
            if (!validateAge(age)) {
                throw  new Error('Invalid age')
            }

            this._age = age | 0;
        }
    });

    Object.defineProperty(Person.prototype, 'fullname', {
        get: function () {
            return this._fullname;
        },
        set: function (name) {
            var splittedName = name.split(' ');
            if (!validateName(splittedName[0]) || !validateName(splittedName[1])) {
                throw new Error('Invalid full name')
            }
            this._firstName = splittedName[0];
            this._lastName = splittedName[1];
            this._fullname = name;
        }
    });

    return Person;
}());


Person.prototype.introduce = function () {
    return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
};

var firstPerson = new Person('John', 'Doe', 15);
console.log(firstPerson.firstname);
console.log(firstPerson.lastname);
console.log(firstPerson.age);
console.log(firstPerson.introduce());