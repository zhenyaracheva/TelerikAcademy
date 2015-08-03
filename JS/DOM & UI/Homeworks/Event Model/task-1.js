/* globals $ */

/* 

 Create a function that takes an id or DOM element and:


 */

function solve() {
    return function Events(selector) {

    if (typeof selector === 'string') {
        selector = document.getElementById(selector);
    }

    var i,
        len,
        allChildren,
        currentElement,
        allButtonContentChildren = [];

    allChildren = selector.children;

    for (i = 0, len = allChildren.length; i < len; i += 1) {

        currentElement = allChildren[i];
        if (currentElement.className === 'button' || currentElement.className === 'content') {
            if (currentElement.className === 'button') {
                currentElement.innerHTML = 'hide';
                allChildren[i].addEventListener('click', clickedButton);
            }

            allButtonContentChildren.push(currentElement);
        }
    }

    function toggleElement(clicked, topmostContentElement) {
        if (topmostContentElement.style.display === 'none') {
            topmostContentElement.style.display = '';
            clicked.innerHTML = 'hide';
        } else {
            topmostContentElement.style.display = 'none';
            clicked.innerHTML = 'show';
        }
    }


    function clickedButton(ev) {
        var nextContent = this.nextElementSibling,
            nextButton = this.nextElementSibling;

        while (nextContent) {

            if (nextContent.className === 'content') {

                while (nextButton) {

                    if (nextButton.className === 'button') {
                        if (nextContent.style.display === 'none') {
                            nextContent.style.display = '';
                            nextButton.innerHTML = 'hide';
                            break;
                        } else {
                            nextContent.style.display = 'none';
                            nextButton.innerHTML = 'show';
                            break;
                        }
                    } else {
                        nextButton = nextButton.previousElementSibling;
                    }
                }
                break;
            } else {
                nextContent = nextContent.nextElementSibling;
            }
        }
    }

    //selector.addEventListener('click', clickedButton);
   }
};
//Events('root');

module.exports = solve;