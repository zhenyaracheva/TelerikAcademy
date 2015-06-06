function numberOfElements(element){
    var elements = document.getElementsByTagName(element);
    return elements.length;
}

console.log(numberOfElements('div'));
console.log(numberOfElements('h1'));
console.log(numberOfElements('wrongTag'));