function divisible7and5(input) {
    var number= parseInt(input);

    if(number%5===0 && number%7===0) {
        return true;
    } else {
        return false;
    }
}

console.log(divisible7and5(3));
console.log(divisible7and5(0));
console.log(divisible7and5(5));
console.log(divisible7and5(7));
console.log(divisible7and5(35));
console.log(divisible7and5(140));