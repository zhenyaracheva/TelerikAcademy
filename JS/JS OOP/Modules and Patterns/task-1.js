/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID *
 * IDs must be unique integer numbers which are at least 1 *
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 *
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var getNextId = (function generateID() {
        var nextId = 1;
        return function(){
            return nextId+=1;
        };
    }());

    function validateTitle(title, msg) {
        if (typeof title !== 'string') {
            throw new Error('Invalid ' + msg + ' title');
        } else if (title.length < 1) {
            throw new Error('Title cannot be empty string')
        } else if (title[0] === ' ' || title[title.length - 1] === ' ') {
            throw new Error('Invalid ' + msg + ' title');
        } else if (title.indexOf('  ') > -1) {
            throw new Error(msg + 'title cannot have consecutive spaces')
        }
    }

    function validatePresentations(presentations) {
        if (presentations.length < 1) {
            throw new Error('Course cannot have less than 1 courses');
        }
        presentations.forEach(function (element) {
            validateTitle(element, 'Presentation');
        })
    }

    function validStudentName(name) {
        if (typeof  name !== 'string') {
            throw new Error('Name is not a string');
        }
        if (name[0] !== name[0].toUpperCase()) {
            throw new Error('Name must be uppercase')
        }
        if (name.length > 1) {
            if (name.substring(1) !== name.substring(1).toLowerCase()) {
                throw new Error('Invalid student name');
            }
        }
    }

    function parseInputName(name) {
        name = name.split(' ');
        if (name.length > 2) {
            throw new Error('Student have more names');
        }

        return name;
    }

    var student = {
        init: function (name) {
            name = parseInputName(name);
            this.firstname = name[0];
            this.lastname = name[1];
            this.id = getNextId();
            return this
        },

        get firstname() {
            return this._firstname;
        },
        set firstname(value) {
            validStudentName(value);
            this._firstname = value;
        },
        get lastname() {
            return this._lastname;
        },
        set lastname(value) {
            validStudentName(value);
            this._lastname = value;
        },
        get id() {
            return this._id;
        },
        set id(value) {
            while (value < 1) {
                value = getNextId();
            }
            this._id = value;
        }
    };

    var Course = {
        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];
            return this;
        },

        addStudent: function (name) {
            var current = Object.create(student);
            current.init(name);
            this.students.push(current);
            return current.id;
        },

        getAllStudents: function () {
            return this.students.slice();
        },

        submitHomework: function (studentID, homeworkID) {
            if (!this.students.some(function (st) {
                    return st.id === studentID
                })) {
                throw new Error('No student with this ID');
            }

            if (this.presentations.length < homeworkID || this.presentations.length < 0) {
                throw new Error('No homework with this ID');
            }

            this.presentations[homeworkID-1].homework = true;

        },

        pushExamResults: function (results) {
        },

        getTopStudents: function () {
        },
        
        get title() {
            return this._title;
        },
        set title(value) {
            validateTitle(value);
            this._title = value;
        },
        get presentations() {
            return this._presentations;
        },
        set presentations(value) {
            validatePresentations(value);
            this._presentations = value
        }
    };

    return Course;
}

module.exports = solve;
