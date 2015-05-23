function biggestOfThree (a,b,c) {
    var maxNumber = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    if(maxNumber < b){
        maxNumber = b;
    }

    if(maxNumber < c) {
        maxNumber = c;
    }

    return maxNumber;
}

console.log(biggestOfThree(5,2,2));
console.log(biggestOfThree(-2,-2,1));
console.log(biggestOfThree(-2,4,3));
console.log(biggestOfThree(0,-2.5,5));
console.log(biggestOfThree(-0.1,-0.5,-1.1));