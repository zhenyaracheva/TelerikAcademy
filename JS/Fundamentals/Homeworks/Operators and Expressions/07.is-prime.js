function isPrime(inputNumber) {
    var num = parseInt(inputNumber),
        counter = 0,
        checkTo;

    if (num < 0) {
        return false;
    } else if(num !== 0 && num !==1){

        checkTo= Math.sqrt(num);
        for (var i = 1; i <= checkTo; i++) {
            if(num%i === 0) {
                counter++;
            }

            if(counter>1) {
                break;
            }
        }
    }

    if(counter === 1) {
        return true
    } else {
        return false;
    }
}

console.log(isPrime(1));
console.log(isPrime(2));
console.log(isPrime(3));
console.log(isPrime(4));
console.log(isPrime(9));
console.log(isPrime(37));
console.log(isPrime(97));
console.log(isPrime(51));
console.log(isPrime(-3));
console.log(isPrime(0));