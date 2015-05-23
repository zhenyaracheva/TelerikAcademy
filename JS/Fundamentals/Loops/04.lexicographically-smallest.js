function smallestAndLargestProperty (place) {
    var smallest = 'zzz',
        largerst = '';

    if (place=== document){

        for (var prop in document) {

            if (prop> largerst){
                largerst = prop;
            };

            if (prop < smallest){
                smallest = prop;
            }
        }
    } else if (place=== window) {

        for (var prop in window) {

            if (prop> largerst){
                largerst = prop;
            };

            if (prop < smallest){
                smallest = prop;
            }
        }

    } else if (place=== navigator){
        for (var prop in navigator) {

            if (prop> largerst){
                largerst = prop;
            };

            if (prop < smallest){
                smallest = prop;
            }
        }

    } else {
        return 'wrong input';
    }

    return 'Smallest property: '+smallest+' Largest property: '+ largerst;
}

console.log(smallestAndLargestProperty(window));
console.log(smallestAndLargestProperty(document));
console.log(smallestAndLargestProperty(navigator));