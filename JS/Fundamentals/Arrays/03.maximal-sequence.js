function maximalSequence (array){

    if(array.length >0){
        var maxCount = 0,
            currerntCount = 1,
            maxSymbol = array[0],
            lastSymbol = array[0];

        for (var i = 0, len =array.length ; i < len; i++) {
            if (lastSymbol === array[i]) {
                currerntCount++;
            } else {
                if (maxCount < currerntCount) {
                    maxCount = currerntCount;
                    maxSymbol = lastSymbol;
                }

                currerntCount = 1;
                lastSymbol = array[i];
            }
        }

        if (maxCount < currerntCount) {
            maxCount = currerntCount;
            maxSymbol = lastSymbol;
        }

        return  Array(maxCount+1).join(maxSymbol+' ');

    } else {
        return 'Empty array'
    }
}

console.log(maximalSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(maximalSequence([2, 1, 1,1,1,1,1,1,1, 2, 3, 3, 2, 2, 2, 1]));