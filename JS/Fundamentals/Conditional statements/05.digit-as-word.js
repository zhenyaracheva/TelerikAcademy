function digitAsWord (digit) {
    digit= parseFloat(digit);

    switch (digit){
        case 0: return 'zero';
        case 1: return 'one';
        case 2: return 'two';
        case 3: return 'three';
        case 4: return 'four';
        case 5: return 'five';
        case 6: return 'six';
        case 7: return 'seven';
        case 8: return 'eight';
        case 9: return 'nine';
        default : return 'not a digit';
    }
}

console.log(digitAsWord(2));
console.log(digitAsWord(1));
console.log(digitAsWord(0));
console.log(digitAsWord(5));
console.log(digitAsWord(-0.1));
console.log(digitAsWord('hi'));
console.log(digitAsWord(9));
console.log(digitAsWord(10));