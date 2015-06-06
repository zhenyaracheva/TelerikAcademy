function sortTwoNumbers(a, b) {
    a = parseFloat(a);
    b = parseFloat(b);

    if (a > b) {
        return b + ' ' + a;
    } else {
        return a + ' ' + b;
    }
}

console.log(sortTwoNumbers(5, 2));
console.log(sortTwoNumbers(3, 4));
console.log(sortTwoNumbers(5.5, 4.5));