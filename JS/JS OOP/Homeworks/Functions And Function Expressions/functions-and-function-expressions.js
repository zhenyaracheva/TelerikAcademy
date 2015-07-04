var functionAndFunctionExpressions = (function () {
    /* Task 1
     Write a function that sums an array of numbers:
     Numbers must be always of type Number
     Returns null if the array is empty
     Throws Error if the parameter is not passed (undefined)
     Throws if any of the elements is not convertible to Number*/

    function sum(array) {
         if (array.length === 0) {
        return null;
    }

    return array.reduce(function (s, n) {

        if (!isFinite(n)) {
            throw new Error('Array must contains only numbers', 'task-1');
        }
        return s + +n;
    }, 0)
    }

    console.log(sum([1, 2, 3]));

    /* Task 2.
     Write a function that finds all the prime numbers in a range
     It should return the prime numbers in an array
     It must throw an Error if any of the range params is not convertible to Number
     It must throw an Error if any of the range params is missing */

    function primesInRange(start, end) {
          var number,
        divisor,
        isPrime,
        maxDivisor,
        primes = [];

    if(!isFinite(start) || !isFinite(end)){
        throw new Error('Parameters must be numbers', 'task-2');
    }
    start = start | 0;
    end = end | 0;

    for (number = start; number <= end; number += 1) {
        isPrime = true;
        maxDivisor = Math.sqrt(number);
        for (divisor = 2; divisor <= maxDivisor; divisor += 1) {

            if (number % divisor === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime && number > 1) {
            primes.push(number);
        }
    }

    return primes;
    }

    console.log(primesInRange(1, 5));
}());
