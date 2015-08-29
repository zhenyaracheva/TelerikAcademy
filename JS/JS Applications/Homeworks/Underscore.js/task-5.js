/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has propeties `name`, `species` and `legsCount`
 *   **finds** and **prints** the total number of legs to the console in the format:
 *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
 *   **Use underscore.js for all operations**
 */

// function solve(){
//   return
function solve(animals) {
    if (!Array.isArray(animals)) {
        throw new Error('Invalid input');
    }

    var totalLegs = _.reduce(animals, function (memo, item) {
        return memo + item.legsCount;
    }, 0);

    return 'Total number of legs: ' + totalLegs;
}
// }
// module.exports = solve;
var animals = [];

console.log(solve(animals));