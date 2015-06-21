function Solve(params) {
    var i,
        j,
        len,
        N = parseInt(params[0]),
        currentSum,
        answer = -2000000,
        arr = [];


    for (i = 1; i <= N; i += 1) {
        arr.push(parseInt(params[i]))
    }

    for (i = 0, len = arr.length; i < len; i += 1) {
        currentSum = 0;
        for (j = i; j < len; j += 1) {
            currentSum += arr[j];
            if (currentSum > answer) {
                answer = currentSum;
            }
        }
    }

    return answer;
}
