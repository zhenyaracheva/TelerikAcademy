function reverseNumber(number) {

    if (typeof number === 'number'){

        var numAsString = number.toString();
        var reversed = numAsString.split('').reverse().join('');

        return Number(reversed);

    } else {
        return 'not a number';
    }
}

console.log(reverseNumber(256));
console.log(reverseNumber(123.45));
console.log(reverseNumber('stringValue'));
console.log(reverseNumber('1254.54'));