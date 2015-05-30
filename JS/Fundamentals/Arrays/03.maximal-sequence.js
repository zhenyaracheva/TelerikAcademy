function maximalSequence(array) {

    if (array.length > 0) {
        var i,
            len,
            maxCount = 0,
            currentCount = 1,
            maxSymbol = array[0],
            lastSymbol = array[0];

        for (i = 0, len = array.length; i < len; i += 1) {
            if (lastSymbol === array[i]) {
                currentCount += 1;
            } else {
                if (maxCount < currentCount) {
                    maxCount = currentCount;
                    maxSymbol = lastSymbol;
                }

                currentCount = 1;
                lastSymbol = array[i];
            }
        }

        if (maxCount < currentCount) {
            maxCount = currentCount;
            maxSymbol = lastSymbol;
        }

        return Array(maxCount + 1).join(maxSymbol + ' ');

    } else {
        return 'Empty array'
    }
}

console.log(maximalSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(maximalSequence([2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 3, 2, 2, 2, 1]));