function printNumbers(n) {
    var output='';
    n = parseInt(n);
    for (var i = 1; i <= n; i++) {
        output+= i+' '
    }

    return output;
}

console.log(printNumbers(15));
console.log(printNumbers(105));
console.log(printNumbers(37));
console.log(printNumbers(1));