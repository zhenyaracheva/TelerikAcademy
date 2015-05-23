/*Problem 1. JavaScript literals*/
var stringVariable = 'sample',
    integerVariable=1,
    floatVariable= 1.1,
    boolVariable= true,
    arrayVariable= [1,2,3],
    matrixVariable= [[1,2,3], [4,5,6]],
    objectVariable = {
        name:'objectName',
        position: 1
    };

/*Problem 2. Quoted text*/
var quotedText="'How you doin'?', Joy said";
console.log(quotedText);

/*Problem 3. Typeof variables*/
console.log(typeof stringVariable);
console.log(typeof integerVariable);
console.log(typeof floatVariable);
console.log(typeof boolVariable);
console.log(typeof arrayVariable);
console.log(typeof matrixVariable);
console.log(typeof objectVariable);

/*Problem 4. Typeof null*/
var nullVariable= null,
    undefinedVariable = undefined;
console.log(typeof nullVariable);
console.log(typeof undefinedVariable);