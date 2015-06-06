function increasingSequence(array) {
    var i,
        len,
        max = '',
        current = '',
        lastNumber,
        maxNumber;

    if (array.length < 1) {
        return 'Empty array!';
    }
    else if (array.length === 1) {
        return array[0];
    } else {

        current = array[0];
        lastNumber = parseInt(array[0]);

        for (i = 1, len = array.length; i < len; i += 1) {
            var currentNumber = parseInt(array[i]);

            if (lastNumber + 1 === currentNumber) {
                current += ' ' + currentNumber;
            } else {

                if (max.length < current.length) {
                    max = current;
                }

                current = currentNumber;
            }

            lastNumber = currentNumber;
        }

        if (max.length < current.length) {
            max = current;
        }
    }

    return max;
}

console.log(increasingSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(increasingSequence([3, 2, 3, 4, 2, 2, 4, 5, 6, 7, 8, 9, 10]));
console.log(increasingSequence([]));
console.log(increasingSequence([1]));
