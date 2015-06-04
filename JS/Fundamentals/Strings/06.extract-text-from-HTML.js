function getContent() {
    var i,
        len,
        text = document.documentElement.innerHTML,
        splitText = text.split(/<.*?>/);

    for ( i = 0, len = splitText.length; i < len; i+=1) {
        splitText[i]= splitText[i].toString().trim();
    }

    return splitText.join('').replace(/(\r\n|\n|\r|)/gm, "");
}

console.log(getContent());