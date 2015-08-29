/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName` and `lastName` properties
 *   **Finds** all students whose `firstName` is before their `lastName` alphabetically
 *   Then **sorts** them in descending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   Then **prints** the fullname of founded students to the console
 *   **Use underscore.js for all operations**
 */

//function solve() {
//    return
function solve(students) {
    if (!Array.isArray(students)) {
        throw new Error("Student must nw array!");
    }
    var firstNameBeforelastName = _.filter(students, function (item) {
        return item.firstName < item.lastName;
    });

    var sorted = _.sortBy(firstNameBeforelastName, function (item) {
        return item.firstName + ' ' + item.lastName;
    }).reverse();

    var asString = _.map(sorted, function (item) {
        return item.firstName + ' ' + item.lastName;
    });

    return asString;
};
//}
//module.exports = solve;

var students = [];

var sorted = solve(students);
console.log(sorted);