function solve(params) {
    var i,
        j,
        z,
        k,
        line,
        row = 0,
        col = 0,
        sum = 0,
        dimensions = params[0].split(' ').map(Number),
        rows = dimensions[0],
        cols = dimensions[1],
        directions = [],
        matrix = [];

    for (i = 0, z = 1; i < rows; i += 1, z *= 2) {
        directions.push([]);
        matrix.push([]);
        line = params[i + 1].split(' ');
        for (j = 0, k = z; j < cols; j += 1, k += 1) {
            directions[i].push(line[j]);
            matrix[i].push(k);
        }
    }

    while (1) {
        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            return 'successed with ' + sum;
        } else if (!matrix[row][col]) {
            return 'failed at (' + row + ', ' + col + ')';
        }

        sum += matrix[row][col];
        matrix[row][col] = 0;
        changeDirection(directions[row][col])
    }

    function changeDirection(direction) {
        switch (direction) {

            case 'dr':
                row += 1;
                col += 1;
                break;
            case 'dl':
                row += 1;
                col -= 1;
                break;
            case 'ur':
                row -= 1;
                col += 1;
                break;
            case 'ul':
                row -= 1;
                col -= 1;
                break;
        }
    }
}

var args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
];

console.log(solve(args));
