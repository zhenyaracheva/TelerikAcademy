function correctBrackets(expression) {
    var i,
        len,
        brackets = 0;

    for (i = 0, len = expression.length; i < len; i += 1) {

        if (expression[i] === '(') {
            brackets += 1;
        } else if (expression[i] === ')') {
            if (brackets <= 0) {
                return false;
            }

            brackets -= 1;
        }
    }

    return brackets === 0;
}

console.log(correctBrackets('((a+b)/5-d)'));
console.log(correctBrackets(')(a+b)/5-d)'));
console.log(correctBrackets('()()(())()(((((())))))'));
console.log(correctBrackets('()()(())()(((((()))))))'));