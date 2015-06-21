function Solve(params) {
    var i,
        N = parseInt(params[0]),
        answer = 1;

    for (i = 1; i <= N; i += 1) {
        if (parseInt(params[i]) > parseInt(params[i + 1])) {
            answer += 1;
        }
    }

    return answer;
}

var arr = [7, 1, 2, -3, 4, 4, 0, 1];
console.log(Solve(arr));
console.log(Solve([6, 1, 3, -5, 8, 7, -6]));
console.log(Solve([9, 1, 8, 8, 7, 6, 5, 7, 7, 6]));