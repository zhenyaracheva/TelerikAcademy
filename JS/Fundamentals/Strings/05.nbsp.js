function nbsp(text) {

    var index = text.indexOf(' ');

    while (index !== -1) {
        text = text.replace(' ', '&nbsp;');
        index = text.indexOf(' ', index + 1);
    }

    return text;
}

var text = 'text[ ]text[ ]another[ ]text[   ]';

console.log(nbsp(text));