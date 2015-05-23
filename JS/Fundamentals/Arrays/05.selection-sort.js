function selectionSort(array) {

    for (var i = 0, len = array.length-1; i < len; i++) {
        var  min = i,
             temp;

        for (var j = i + 1, len = array.length; j < len; j++) {
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

console.log(selectionSort([3,2,1,8,5,6,4,7,9]).join(' '));
console.log(selectionSort([1,2,1,8,5,6,-4,7,9, 7,9]).join(' '));
console.log(selectionSort([0]).join(' '));