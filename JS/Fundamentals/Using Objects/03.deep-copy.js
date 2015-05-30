function deepClone(obj) {
    var copy,
        attr;

    if (obj == null || "object" != typeof obj){
        return obj;
    } 
    
    copy = obj.constructor();
    for (attr in obj) {
        if (obj.hasOwnProperty(attr)) {
            copy[attr] = obj[attr];
        }
    }
    return copy;
}

var obj = {
    name: 'John',
    age: '190',
    address: {
        country: 'Bulgaria',
        town: 'Sofia'
    }
};

var integer = 15;
var someString = 'justText';

console.log(deepClone(obj));
console.log(deepClone(integer));
console.log(deepClone(someString));