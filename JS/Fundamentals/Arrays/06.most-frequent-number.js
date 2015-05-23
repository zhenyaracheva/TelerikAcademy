function frequentNumber(array) {

    array.sort(function(a, b){return a - b});

    var maxNumber= array[0],
        maxCount= 0,
        current = array[0],
        currentCount = 1,
        solutions = [],
        output = '[';

    for (var i = 1, len = array.length; i < len; i++) {

        if(current === array[i]){
            currentCount++;

        } else {

            if(maxCount<currentCount){

                maxCount=currentCount;
                maxNumber = current;
                solutions = [maxNumber];

            } else if (maxCount=== currentCount) {

                maxNumber = current;
                solutions.push(maxNumber);
            }

            currentCount = 1;
            current = array[i];
        }
    }

    if(maxCount<currentCount){

        maxCount=currentCount;
        maxNumber = current;
        solutions = [maxNumber];

    } else if (maxCount=== currentCount) {

        maxNumber = current;
        solutions.push(maxNumber);
    }

    output += solutions.join(',');
    output +=']';

    if(maxCount===1){
        return output +'('+ maxCount+ ' time)';
    }else {
        return output +'('+ maxCount+ ' times)';
    }
}

console.log(frequentNumber([1,2,5,8,7,9,46,5,-4]));
console.log(frequentNumber([1,2,5,8,7,9,46,5,-4,7]));
console.log(frequentNumber([1,7,7,2,5,7,8,7,9,7,46,5,-4,7,7,7]));
console.log(frequentNumber([1,2,3]));
