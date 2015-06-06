function pointInCircleOutRectangle (x,y) {
        r = 3,
        pointX = parseFloat(x),
        pointY= parseFloat(y),
        inCircle = ((pointX - 1) * (pointX - 1) + (pointY - 1) * (pointY - 1)) <= r*r,
        outRectangle = ((pointX < -1) || (pointX > 5) || (pointY > 1) || (pointY < -1));

        if(inCircle && outRectangle){
            return true;
        } else {
            return false;
        }
}

console.log(pointInCircleOutRectangle(1,2));
console.log(pointInCircleOutRectangle(2.5,2));
console.log(pointInCircleOutRectangle(0,1));
console.log(pointInCircleOutRectangle(2.5,1));
console.log(pointInCircleOutRectangle(2,0));
console.log(pointInCircleOutRectangle(4,0));
console.log(pointInCircleOutRectangle(2.5,1.5));
console.log(pointInCircleOutRectangle(2,1.5));
console.log(pointInCircleOutRectangle(1,2.5));
console.log(pointInCircleOutRectangle(-100,-100));