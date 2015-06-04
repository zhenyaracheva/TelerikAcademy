function parseEmail(input) {
    return input.match(/[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}/gi);
}

var text = "first@mail.bg, some text, some text email@abv.bg";

console.log(parseEmail(text));