function solve(params) {
    var lineNumber,
        len,
        name,
        currentValue,
        currentLine,
        index,
        valueAsString,
        allVariables = [];

    var Variable = (function () {

        function Variable(name, value) {
            var self = this;
            self.name = name;
            self.value = value;
        }

        return Variable;
    }());

    for (lineNumber = 0, len = params.length - 1; lineNumber < len; lineNumber += 1) {
        params[lineNumber] = params[lineNumber].trim();
        currentLine = params[lineNumber].substring(1, params[lineNumber].length - 1).replace('def', '').trim()
        index = currentLine.indexOf(' ');
        name = currentLine.substring(0, index).trim();
        valueAsString = currentLine.substring(name.length).trim();
        index = valueAsString.indexOf('(');
        if(index !== -1) {
            valueAsString = valueAsString.substring(1, valueAsString.length - 1).trim();
        }
        currentValue = parseValue(valueAsString);

        if (typeof currentValue !== "number") {
            return currentValue;
        }

        allVariables.push(new Variable(name, currentValue));
    }

    params[params.length - 1] = params[params.length - 1].trim();
    currentLine = params[params.length - 1].substring(1, params[params.length - 1].length - 1).trim();
    return parseValue(currentLine);


    function parseValue(values) {
        var i,
            len,
            j,
            innerLen,
            number = '',
            operator,
            arr = [];

        if (values[0] === '+' || values[0] === '-' || values[0] === '*' || values[0] === '/') {
            operator = values[0];
        } else {
            return parseInt(values);
        }


        for (i = 1, len = values.length; i < len; i += 1) {
            if (values[i] === ' ' && number.length !== 0) {
                if (isFinite(number)) {
                    arr.push(parseInt(number));
                } else {
                    for (j = 0, innerLen = allVariables.length; j < innerLen; j += 1) {
                        if (allVariables[j].name === number) {
                            arr.push(allVariables[j].value);
                        }
                    }
                }

                number = '';
            } else if (values[i] === ' ') {
                continue;
            } else {
                number += values[i];
            }
        }

        if (number.length !== 0) {
            if (isFinite(number)) {
                arr.push(parseInt(number));
            } else {
                for (j = 0, innerLen = allVariables.length; j < innerLen; j += 1) {
                    if (allVariables[j].name === number) {
                        arr.push(allVariables[j].value);
                    }
                }
            }
        }

        switch (operator) {
            case '+':
                return arr.reduce(function (a, b) {
                    return a + b;
                }, 0);
            case '-':
                return arr.reduce(function (a, b) {
                    return a - b;
                }, 0);
            case '*':
                return arr.reduce(function (a, b) {
                    return a * b;
                }, 1);
            case '/':
                if (checkForError(arr)) {
                    return 'Division by zero! At Line:' + (lineNumber + 1);
                }
                return parseInt(arr.reduce(function (a, b) {
                    return a / b;
                }));
        }

        function checkForError(arr) {
            var i,
                len;

            for (i = 0, len = arr.length; i < len; i += 1) {
                if (arr[i] === 0) {
                    return true
                }
            }

            return false;

        }
    }
}

var test1 = [
    '(/   5  5)'
];

var test2 = [
    '(def myFunc 5)',
    '(def myNewFunc (+  myFunc  myFunc 2))',
    '(def MyFunc (* 2  myNewFunc))',
    '(/   MyFunc  myFunc)'
];

var test3 = [
    '    (     def  func 10)',
    '( def          newFunc (+  func 2)           )',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '        (* sumFunc 2)          '
];

var test4 = [
    '(       def    func (+ 5    2))',
    '(def func2                      (/  func 5 2 1 0))     ',
    '    (def func3 (/ func 2))',
    '(/              func3     func)'
];

console.log(solve(test1));
console.log(solve(test2));
console.log(solve(test3));
console.log(solve(test4));

