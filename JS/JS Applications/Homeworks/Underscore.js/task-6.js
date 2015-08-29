/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has propeties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

// function solve() {
//     return
function solve(books) {

    var grouped = _.chain(books)
        .map(function (item) {
            item.author.fullName = item.author.firstName + ' ' + item.author.lastName;
            item.authorName = item.author.fullName;
            return item;
        })
        .sortBy('authorName')
        .groupBy('authorName')
        .value();

    var maxCount = _.chain(grouped)
        .map(function (item) {
            return item.length
        })
        .sort(function (item) {
            return +item;
        })
        .max(function (item) {
            return item
        })
        .value();

    var result = _.chain(grouped)
        .filter(function (item) {
            return item.length === maxCount;
        }).value()
        .map(function (item) {
            return item[0].authorName;
        });

    return result;
}
// }
// module.exports = solve;

var books = [{
    title: 'Book1',
    author: {
        firstName: 'ASanjay',
        lastName: 'Wilfrith'
    }
}, {
    title: 'Book27',
    author: {
        firstName: 'Sanjay',
        lastName: 'Wilfrith'
    }
}, {
    title: 'Book3',
    author: {
        firstName: 'ASanjay',
        lastName: 'Wilfrith'
    }
}, {
    title: 'Book3',
    author: {
        firstName: 'Sanjay',
        lastName: 'Wilfrith'
    }
}];
console.log(solve(books));
//solve(books);