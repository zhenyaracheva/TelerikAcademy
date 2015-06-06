function thirdDigit(number) {
    var textNumber = number.toString();

    if(textNumber[textNumber.length-3] === '7'){
        return true;
    } else {
        return false;
    }
}

console.log(thirdDigit(5));
console.log(thirdDigit(701));
console.log(thirdDigit(1732));
console.log(thirdDigit(9703));
console.log(thirdDigit(877));
console.log(thirdDigit(777877));
console.log(thirdDigit(9999799));