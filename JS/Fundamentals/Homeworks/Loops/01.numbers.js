function printNumbers(n) {
    var i,
        output='';
    n = parseInt(n);
    for ( i = 1; i <= n; i+=1) {
        output+= i+' '
    }

    return output;
}

console.log(printNumbers(15));
console.log(printNumbers(105));
console.log(printNumbers(37));
console.log(printNumbers(1));