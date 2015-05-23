function lastDigitAsWord(number) {

    if (typeof number=== 'number'){
        var last = number%10;
        return englishDigit(last);

    } else{
        return 'not a digit';
    }
}

function englishDigit(digit) {
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
        case 9 :return 'nine';
        default : return 'not a digit';
    }
}

console.log(lastDigitAsWord(512));
console.log(lastDigitAsWord(1024));
console.log(lastDigitAsWord(12309));
console.log(lastDigitAsWord('12309'));
console.log(lastDigitAsWord('stringValue'));