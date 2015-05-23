function pointInCircle(firstNumber, secondNumber){
    var x = parseFloat(firstNumber),
        y = parseFloat(secondNumber),
        radius = 5;

    return (x*x+y*y)<=radius*radius;
}

console.log(pointInCircle(0,1));
console.log(pointInCircle(-2,0));
console.log(pointInCircle(-1,2));
console.log(pointInCircle(1.5,-1));
console.log(pointInCircle(-1.5,-1.5));
console.log(pointInCircle(100,-30));
console.log(pointInCircle(0,0));
console.log(pointInCircle(0.2,-0.8));
console.log(pointInCircle(0.9, -1.93));
console.log(pointInCircle(1,1.655));