function increaseArray (){
    var array = [20];
    for (var i = 0 ; i < 20; i++) {
       array[i] = i*5;
    }

    return array;
}

console.log(increaseArray());