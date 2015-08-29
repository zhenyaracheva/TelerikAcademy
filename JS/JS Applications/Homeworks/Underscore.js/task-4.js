/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has propeties `name`, `species` and `legsCount`
 *   **groups** the animals by `species`
 *   the groups are sorted by `species` descending
 *   **sorts** them ascending by `legsCount`
 *	if two animals have the same number of legs sort them by name
 *   **prints** them to the console in the format:

 ```
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 GROUP_1_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in group 1
 NAME has LEGS_COUNT legs //for the second animal in group 1
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 GROUP_2_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in the group 2
 NAME has LEGS_COUNT legs //for the second animal in the group 2
 NAME has LEGS_COUNT legs //for the third animal in the group 2
 NAME has LEGS_COUNT legs //for the fourth animal in the group 2
 ```
 *   **Use underscore.js for all operations**
 */

// function solve(){
//   return
function solve(animals) {
    if (!Array.isArray(animals)) {
        throw new Error('Invalid input');
    }


    var sortedBySpecies = _.sortBy(animals, function (item) {
        return item.species;
    }).reverse();

    var groups = _.groupBy(sortedBySpecies, 'species');
    for (var group in groups) {

        groups[group].sort(function (a, b) {
            var x = a.legsCount;
            var y = b.legsCount;
            return x === y ? 0 : x < y ? -1 : 1;
        });
    }

    var res = [];
    for (var group in groups) {
        res.push('---------');
        res.push(group);
        res.push('---------');

        for (var i = 0; i < groups[group].length; i += 1) {
            res.push(groups[group][i].name + ' has ' + groups[group][i].legsCount+' legs');
        }
    }

    return res;
}
// }
// module.exports = solve;

var animals = [
    {
        name: 'Zlatev',
        species: 'Mosquito',
        legsCount: 2
    }, {
        name: 'Minkov',
        species: 'Mosquito',
        legsCount: 2
    }, {
        name: 'Doncho',
        species: 'Mosquito',
        legsCount: 2
    }, {
        name: 'Komara',
        species: 'Mosquito',
        legsCount: 4
    }];
console.log(solve(animals));