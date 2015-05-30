function reverseNumber(number) {
    var numAsString,
        reversed;

    if (typeof number === 'number') {

        numAsString = number.toString();
        reversed = numAsString.split('').reverse().join('');

        return Number(reversed);

    } else {
        return 'not a number';
    }
}

console.log(reverseNumber(256));
console.log(reverseNumber(123.45));
console.log(reverseNumber('stringValue'));
console.log(reverseNumber('1254.54'));