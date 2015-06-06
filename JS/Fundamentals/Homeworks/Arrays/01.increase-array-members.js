function increaseArray() {
    var i,
        array = [20];
    for (i = 0; i < 20; i += 1) {
        array[i] = i * 5;
    }

    return array;
}

console.log(increaseArray());