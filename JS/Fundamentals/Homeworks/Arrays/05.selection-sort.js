function selectionSort(array) {
    var i,
        j,
        len,
        secondLen,
        min,
        temp;

    for (i = 0, len = array.length - 1; i < len; i += 1) {
        min = i;


        for (j = i + 1, secondLen = array.length; j < secondLen; j += 1) {
            if (array[j] < array[min]) {
                min = j;
            }
        }

        temp = array[i];
        array[i] = array[min];
        array[min] = temp;
    }

    return array;
}

console.log(selectionSort([3, 2, 1, 8, 5, 6, 4, 7, 9]).join(' '));
console.log(selectionSort([1, 2, 1, 8, 5, 6, -4, 7, 9, 7, 9]).join(' '));
console.log(selectionSort([0]).join(' '));