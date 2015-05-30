function hasProperty(obj, property) {
    return obj.hasOwnProperty(property);
}

var person = {
    name: 'John',
    age: 190
};

var dog = {
    name: 'doggy'
};

console.log(hasProperty(person, 'age'));
console.log(hasProperty(dog, 'age'));