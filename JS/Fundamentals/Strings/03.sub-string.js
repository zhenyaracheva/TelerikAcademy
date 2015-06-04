function FindSubString(text, subString) {
    var index = text.indexOf(subString),
        count = 0;

    text = text.toLowerCase();
    while (index >= 0) {
        count += 1;
        index = text.indexOf(subString, index + 1);
    }

    return count;
}

var text = "The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

console.log(FindSubString(text, 'in'));