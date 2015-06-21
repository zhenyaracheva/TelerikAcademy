function solve(params) {
    var i,
        j,
        sum = 0,
        count= 0,
        matrix = [],
        steps = [],
        index = 1,
        splited = params[0].split(' '),
        n = parseInt(splited[0]),
        m = parseInt(splited[1]),
        position = params[1].split(' '),
        row = parseInt(position[0]),
        col = parseInt(position[1]);


    for (i = 0; i < n; i += 1) {
        matrix.push([]);
        steps.push([]);

        for (j = 0; j < m; j += 1) {
            matrix[i][j] = params[i + 2][j];
            steps[i][j] = index;
            index += 1;
        }
    }

    while (steps[row][col]!=0) {
        sum += steps[row][col];
        steps[row][col] = 0;
        count+=1;
        changeDirection(matrix[row][col]);
        if (isEscaped(row, col, n, m)) {
            return 'out ' + sum;
        }
    }

    return 'lost '+ count;

    function isEscaped(row, col, n, m) {
        return row >= n || row < 0 ||
            col >= m || col < 0;
    }


    function changeDirection(direction) {
        switch (direction) {
            case 'l':
                col -= 1;
                break;
            case 'r':
                col += 1;
                break;
            case 'u':
                row -= 1;
                break;
            case 'd':
                row += 1;
                break;
            default :
                throw  new Error('Invalid direction');
        }
    }
}