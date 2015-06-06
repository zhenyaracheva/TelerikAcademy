function thirdBit (number) {

    var bits = parseInt(number).toString(2);

    if(bits[bits.length-4]=== '1'){
        return 1;
    } else {
        return 0;
    }
}

console.log(thirdBit(5));
console.log(thirdBit(8));
console.log(thirdBit(0));
console.log(thirdBit(15));
console.log(thirdBit(5343));
console.log(thirdBit(62241));