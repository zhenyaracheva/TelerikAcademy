/* globals $ */

/*
 Create a function that takes an id or DOM element and an array of contents
 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {
    return function DOM(element, contents) {
        var i,
            len;

        if (arguments.length < 2) {
            throw new Error('Function must contains 2 parameters!');
        }

        if (!element.nodeType && typeof element !== 'string') {
            throw  new Error('First parameter must DOM element or string ');
        }

        if (!(contents instanceof  Array)) {
            throw new Error('Second parameter must be an array!');
        }

        if (typeof element === 'string') {
            element = document.getElementById(element);

            if (element === null) {
                throw  new Error('Element cannot be null!');
            }
        }

        for (i = 0, len = contents.length; i < len; i += 1) {
            if (typeof contents[i] !== 'string' && typeof contents[i] !== 'number') {
                throw new Error('Invalid contents');
            }
        }

        element.innerHTML = '';
        for (i = 0, len = contents.length; i < len; i += 1) {

            element.innerHTML += '<div>' + contents[i] + '</div>';
        }

        return element
    };
};