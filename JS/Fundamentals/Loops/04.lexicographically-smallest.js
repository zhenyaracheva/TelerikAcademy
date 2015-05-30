function smallestAndLargestProperty(place) {
    var prop,
        smallest = 'zzz',
        largest = '';

    if (place === document) {

        for (prop in document) {

            if (prop > largest) {
                largest = prop;
            }

            if (prop < smallest) {
                smallest = prop;
            }
        }
    } else if (place === window) {

        for (prop in window) {

            if (prop > largest) {
                largest = prop;
            }

            if (prop < smallest) {
                smallest = prop;
            }
        }

    } else if (place === navigator) {
        for (prop in navigator) {

            if (prop > largest) {
                largest = prop;
            }

            if (prop < smallest) {
                smallest = prop;
            }
        }

    } else {
        return 'wrong input';
    }

    return 'Smallest property: ' + smallest + ' Largest property: ' + largest;
}

console.log(smallestAndLargestProperty(window));
console.log(smallestAndLargestProperty(document));
console.log(smallestAndLargestProperty(navigator));