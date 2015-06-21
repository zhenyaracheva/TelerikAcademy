function solve(params) {
    var sum,
        i,
        j,
        z,
        s = params[0] | 0,
        c1 = params[1] | 0,
        c2 = params[2] | 0,
        c3 = params[3] | 0,
        answer = 0;

    for (i = 0; i <= s / c1; i += 1) {
        for (j = 0; j <= s / c2; j += 1) {
            for (z = 0; z <= s / c3; z += 1) {
                sum = i * c1 + j * c2 + z * c3;
                if (sum > s) {
                    break;
                }

                if (sum > answer) {
                    answer = sum;
                }
            }
        }
    }

    console.log(answer);
}