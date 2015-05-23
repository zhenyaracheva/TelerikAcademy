function quadraticEquation(a,b,c) {
    var result,
        firstRoot,
        secondRoot,
        d;
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    d = (b * b) - (4 * a * c);

    if (d > 0){

        firstRoot = ((-1) * b - Math.sqrt(d)) / (2 * a);
        secondRoot = ((-1) * b + Math.sqrt(d)) / (2 * a);

        return 'x1='+firstRoot+'; x2='+secondRoot;

    } else if (d === 0) {
        firstRoot = ((b*(-1))/(2*a))
        return 'x1=x2='+ firstRoot;
    }else {
        return 'no real roots'
    }
}

console.log(quadraticEquation(2,5,-3));
console.log(quadraticEquation(-1,3,0));
console.log(quadraticEquation(-0.5,4,-8));
console.log(quadraticEquation(5,2,8));