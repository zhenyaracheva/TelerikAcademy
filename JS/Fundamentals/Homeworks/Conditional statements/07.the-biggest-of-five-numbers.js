function biggestOfFive (a,b,c,d,e) {
    var max = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);
    d = parseFloat(d);
    e = parseFloat(e);

    if (max<b){
        max = b;
    }

    if (max<c) {
        max = c;
    }

    if (max<d) {
        max = d;
    }

    if(max<e) {
        max = e;
    }

    return max;
}

console.log(biggestOfFive(5,2,2,4,1));
console.log(biggestOfFive(-2,-22,1,0,0));
console.log(biggestOfFive(-2,4,3,2,0));
console.log(biggestOfFive(0,-2.5,0,5,5));
console.log(biggestOfFive(-3,-0.5,-1.1,-2,-0.1));