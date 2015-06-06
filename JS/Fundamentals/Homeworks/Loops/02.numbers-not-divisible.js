function notDivisible3And7(endNumber) {
    endNumber = parseInt(endNumber);
    var i,
        output = '';

    for (i = 1; i <= endNumber; i+=1) {

        if (!(i % 3 === 0 && i % 7 === 0)) {
            output += i + ' ';
        }
    }

    return output;
}

console.log(notDivisible3And7(22));
console.log(notDivisible3And7(3));
console.log(notDivisible3And7(100));
console.log(notDivisible3And7(45));
