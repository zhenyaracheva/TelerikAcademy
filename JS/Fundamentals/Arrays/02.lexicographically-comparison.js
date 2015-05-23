function compareCharArrays (firstCharArray, secondCharArray) {

    if(firstCharArray.length!== secondCharArray.length){
        return 'not equl';

    }else {

    for (var i = 0, len = firstCharArray.length; i < len; i++) {

        if(firstCharArray[i] !== secondCharArray[i]){
            return false;
        }
    }

    return true;
    }
}

console.log(compareCharArrays(['a','b','c'],['c','b','a']));
console.log(compareCharArrays(['a','b','c'],['a','b','c']));
console.log(compareCharArrays(['a','b','c'],['a','b']));
console.log(compareCharArrays(['b','c'],['a','b','c']));