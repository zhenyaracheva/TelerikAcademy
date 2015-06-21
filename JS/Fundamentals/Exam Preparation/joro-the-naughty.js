function Solve(params) {
    var i,
        j,
        sum = 0,
        count = 0,
        index = 1,
        arr = [],
        jumps = [],
        firstLine = params[0].split(' ').map(Number),
        rows = firstLine[0],
        columns = firstLine[1],
        jumpsCount = firstLine[2],
        secondLine = params[1].split(' ').map(Number),
        row = secondLine[0],
        col = secondLine[1];

    for (i = 2; i < jumpsCount + 2; i += 1) {
        jumps.push(params[i].split(' ').map(Number));
    }

    for (i = 0; i < rows; i += 1) {
        arr.push([]);
        for (j = 0; j < columns; j += 1) {
            arr[i].push(index);
            index += 1;
        }
    }

    for (i = 0; i < jumpsCount; i += 1) {

        if (row < 0 || row >= rows || col < 0 || col >= columns) {
            return 'escaped ' + sum;
        } else if (!arr[row][col]) {
            return 'caught ' + count;
        }

        sum += arr[row][col];
        count += 1;
        arr[row][col] = 0;
        row = row + jumps[i][0];
        col = col + jumps[i][1];

        if ((i + 1) % jumpsCount === 0) {
            i = -1;
        }
    }
}

console.log(Solve(['6 7 3', '0 0', '2 2', '-2 2', '3 -1']));