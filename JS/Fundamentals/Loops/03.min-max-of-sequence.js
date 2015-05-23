function minMax (input) {

    var numbers = input.split(' ').map(Number),
        min = Number.MAX_VALUE,
        max = Number.MIN_VALUE;

    for (var i = 0, len = numbers.length; i < len; i++) {

        if (min>numbers[i]){
            min = numbers[i];
        }

        if (max<numbers[i]){
            max = numbers[i];
        }
    }

    return min+' '+max;
}

console.log(minMax('6 5 4 55 4 7 6 2 4 8 7'));
console.log(minMax('1 5 6 8 7 4 2 1 101 -10 0 9 8 5687'));