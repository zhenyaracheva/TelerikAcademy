function compareCharArrays(firstCharArray, secondCharArray) {
    var i,
        len;

    if (firstCharArray.length !== secondCharArray.length) {
        return false;

    } else {

        for (i = 0, len = firstCharArray.length; i < len; i += 1) {

            if (firstCharArray[i] !== secondCharArray[i]) {
                return false;
            }
        }

        return true;
    }
}

console.log(compareCharArrays(['a', 'b', 'c'], ['c', 'b', 'a']));
console.log(compareCharArrays(['a', 'b', 'c'], ['a', 'b', 'c']));
console.log(compareCharArrays(['a', 'b', 'c'], ['a', 'b']));
console.log(compareCharArrays(['b', 'c'], ['a', 'b', 'c']));