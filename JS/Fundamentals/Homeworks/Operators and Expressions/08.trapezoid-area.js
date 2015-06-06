function trapezoidArea (sideA,sideB,height) {
    var a = parseFloat(sideA),
        b = parseFloat(sideB),
        h = parseFloat(height);

    return ((a+b)*h)/2;
}

console.log(trapezoidArea( 5,7,12));
console.log(trapezoidArea( 2,1,33));
console.log(trapezoidArea( 8.5,4.3,2.7));
console.log(trapezoidArea( 100,200,300));
console.log(trapezoidArea( 0.222,0.333, 0.555));
