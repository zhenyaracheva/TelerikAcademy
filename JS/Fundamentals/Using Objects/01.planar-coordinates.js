function Point(x, y) {

    var self = this;
    if (typeof x !== "number" || typeof y !== 'number') {
        throw new Error('X and Y must be numbers');
    }

    if (!(this instanceof arguments.callee)) {
        return new Point(x, y);
    }

    self.x = x;
    self.y = y;
}

function Line(start, end) {

    var self = this;
    if (!(start instanceof Point) || !(end instanceof Point)) {
        throw new Error('Start and end must be points');
    }

    if (!(this instanceof arguments.callee)) {
        return new Line(start, end);
    }

    self.startPoint = start;
    self.endPoint = end;
}


if (!Line.prototype.getDistance) {
    Line.prototype.getDistance = function () {
        var x = (this.startPoint.x - this.endPoint.x);
        var y = (this.startPoint.y - this.endPoint.y);

        return Math.sqrt(x * x + y * y);
    }
}

function isTriangle(lineA, lineB, lineC) {

    if (!(lineA instanceof Line) || !(lineB instanceof Line) || !(lineC instanceof Line)) {
        throw new Error('LineA, lineB and lineC must be lines');
    }


    return lineA.getDistance() < lineB.getDistance() + lineC.getDistance() &&
           lineB.getDistance() < lineA.getDistance() + lineC.getDistance() &&
           lineC.getDistance() < lineA.getDistance() + lineB.getDistance();
}

var firstPointA = new Point(1, 2),
    firstPointB = new Point(3, 4),
    firstPointC = new Point(5, 6),
    firstPineA = new Line(firstPointA, firstPointB),
    firstPineB = new Line(firstPointB, firstPointC),
    firstPineC = new Line(firstPointC, firstPointA),
    secondPointA = new Point(3, 2),
    secondPointB = new Point(3, 4),
    secondPointC = new Point(5, 6),
    secondLineA = new Line(secondPointA, secondPointB),
    secondLineB = new Line(secondPointB, secondPointC),
    secondLineC = new Line(secondPointC, secondPointA);


console.log('Is triangle: ' + isTriangle(firstPineA, firstPineB, firstPineC));
console.log('Is triangle: ' + isTriangle(secondLineA, secondLineB, secondLineC));