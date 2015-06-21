function solve(params) {
    var i,
        j,
        z,
        k,
        line,
        sum = 0,
        jumps = 0,
        dimensions = params[0].split(' ').map(Number),
        rows = dimensions[0],
        cols = dimensions[1],
        row = rows - 1,
        col = cols - 1,
        nextRow,
        nextCol,
        next= [];
        directions = [],
        visited = [],
        matrix = [];

    for (i = 0, z = 1; i < rows; i += 1, z *= 2) {
        directions.push([]);
        matrix.push([]);
        visited.push([]);
        line = params[i + 1].split('');

        for (j = 0, k = z; j < cols; j += 1, k -= 1) {
            directions[i].push(line[j]);
            matrix[i].push(k);
            visited[i].push(0);
        }
    }

    while (1) {
        sum += matrix[row][col];


    }

    function changePosition(position) {

    }

    console.log(directions);
    console.log(matrix);
}

var args = [
    '3 5',
    '54561',
    '43328',
    '52388'
];

solve(args);