function solve(params) {
    var trucks,
        cars,
        trikes,
        solution,
        s = params | 0,
        count = 0;

    for (trucks = 0; trucks <= s / 10; trucks += 1) {
        for (cars = 0; cars <= s / 4; cars += 1) {
            for (trikes = 0; trikes <= s / 3; trikes += 1) {
                solution = trucks * 10 + cars * 4 + trikes * 3;
                if (solution === s) {
                    count += 1;
                } else if (solution > s) {
                    break;
                }
            }
        }
    }

    console.log(count);
}
solve(2);