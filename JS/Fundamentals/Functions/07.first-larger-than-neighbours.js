function firstLargerThanNeighbours(array) {
    var i,
        len;

    if (array[0] > array[1]) {
        return 0;
    } else if (array[array.length - 1] > array[array.length - 2]) {
        return array.length - 1;
    } else {
        for (i = 1, len = array.length - 1; i < len; i += 1) {
            if (array[i] > array[i - 1] && array[i] > array[i + 1]) {
                return i;
            }
        }
    }
}

console.log(firstLargerThanNeighbours([1, 20, 10530000, 49, 75, 69, 78, 50, 10, 0]));
console.log(firstLargerThanNeighbours([10000, 20, 1053, 49, 75, 69, 78, 50, 10, 0]));
console.log(firstLargerThanNeighbours([1, 20, 1053, 49, 75, 69, 78, 50, 10, 10000000]));