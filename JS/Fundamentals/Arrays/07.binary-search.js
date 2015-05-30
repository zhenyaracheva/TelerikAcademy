function findIndexInSortedArray(element, sortedArray) {
    var max;
    if (isSortedArray(sortedArray)) {
        max = sortedArray.reduce(function (previous, current) {
            return previous > current ? previous : current
        });

        return binarySearch(sortedArray, 0, max, element);

    } else {
        return 'Array is not sorted!'
    }
}

function binarySearch(sortedArray, lowBound, highBound, value) {

    var mid;
    while (lowBound <= highBound) {
        mid = Math.floor((lowBound + highBound) / 2);

        if (mid < sortedArray.length) {

            if (sortedArray[mid] < value) {

                lowBound = mid + 1;
                continue;

            } else if (sortedArray[mid] > value) {

                highBound = mid - 1;
                continue;

            } else {
                return Math.floor(mid);
            }
        } else {
            return -1;
        }
    }
    return -1;
}

function isSortedArray(array) {

    var first = [].concat(array);
    var sorted = array.sort(function (a, b) {
        return a - b
    });

    for (var i = 0, len = array.length; i < len; i++) {
        if (first[i] !== sorted[i]) {
            return false;
        }
    }

    return true;
}

console.log(findIndexInSortedArray(5, [1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9]));
console.log(findIndexInSortedArray(1, [1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9]));
console.log(findIndexInSortedArray(500, [1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9]));
console.log(findIndexInSortedArray(-1, [-50, -1, 1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9]));
console.log(findIndexInSortedArray(0, [1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 0]));