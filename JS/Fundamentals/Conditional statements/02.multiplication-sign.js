function multiplicationSign(a,b,c) {
    var minus = 0;

    if(a===0 || b===0 || c===0){
        return 0;
    };

    minus+= isNegativeNumber(a);
    minus+= isNegativeNumber(b);
    minus+= isNegativeNumber(c);

    if(minus%2===0){
        return '+';
    } else {
        return '-';
    }
}

function isNegativeNumber(num) {
    if(num < 0){
        return 1;
    }else {
        return 0;
    }
}

console.log(multiplicationSign(5,2,2));
console.log(multiplicationSign(-2,-2,1));
console.log(multiplicationSign(-2,4,3));
console.log(multiplicationSign(0,-2.5,4));
console.log(multiplicationSign(-1,-0.5,-5.1));