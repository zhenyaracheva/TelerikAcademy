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

function solve() {
    return function (students) {
        var bestStudent = _.chain(students)
            .map(function (student) {
                var sumOfMarks = _.reduce(student.marks, function (memo, mark) {
                    return memo + mark;
                }, 0);

                var averageMark = sumOfMarks / student.marks.length;
                student.averageMark = averageMark;
                return student;
            })
            .max(function (student) {
                return student.averageMark;
            })
            .value();

        console.log(bestStudent.firstName + ' ' + bestStudent.lastName + ' has an average score of ' + bestStudent.averageMark);
    };
}

module.exports = solve;