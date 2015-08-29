/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

// function solve() {
//     return
function solve(students) {
    if (!Array.isArray(students)) {
        throw new Error('students must be Array!');
    }

    var studentsWithAverage = _.map(students, function (item) {
        var sum = _.reduce(item.marks, function (memo, num) {
            return memo + num;
        }, 0);

        return {
            firstName: item.firstName,
            lastName: item.lastName,
            age: item.age,
            average: sum / item.marks.length
        }
    });

    var sorted = _.sortBy(studentsWithAverage, function (item) {
        return item.average
    });

    var smartest = _.last(sorted);

    return smartest.firstName + ' ' + smartest.lastName + ' has an average score of ' + smartest.average;
};
// }
// module.exports = solve;
var students = [{
    firstName: 'Nikita',
    lastName: 'Anath',
    age: 14,
    marks: [6]
}];
console.log(solve(students));