function numberAsWord (number) {
    number = parseInt(number);
    var word= '';

    if(number=== parseFloat(0) ){
        return 'zero';
    }

    if(number<0){
        return word= 'minus ' + numberAsWord(Math.abs(number));
    }

    if ((number / 1000000) >=1) {
        word += numberAsWord(number / 1000000) + ' million ';
        number %= 1000000;
    }

     if ((number / 1000) >= 1){
        word += numberAsWord(number / 1000) + ' thousand ';
        number %= 1000;
    }

    if ((number / 100) >= 1) {
        word += numberAsWord(number / 100) + ' hundred ';
        number %= 100;
    }

     if (number >= 1) {
        if (word != '') {
            word += 'and ';
        }

        var unitsMap = [ 'zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
        var tensMap = ['zero', 'ten', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

        if (number < 20) {
            word += unitsMap[number];
        } else {
            word += tensMap[Math.floor(number / 10)];
            if ((number % 10) >= 1) {
                word += '-' + unitsMap[number % 10];
            }
        }
    }

    return word
}

console.log(numberAsWord(0));
console.log(numberAsWord(9));
console.log(numberAsWord(10));
console.log(numberAsWord(12));
console.log(numberAsWord(19));
console.log(numberAsWord(25));
console.log(numberAsWord(98));
console.log(numberAsWord(273));
console.log(numberAsWord(400));
console.log(numberAsWord(501));
console.log(numberAsWord(617));
console.log(numberAsWord(711));
console.log(numberAsWord(999));
console.log(numberAsWord(1000));