function occurrenceWordCaseSensitive(string, word) {
    var subStrings = string.split(word);
    return subStrings.length - 1;
}

function occurrenceWordCaseInsensitive(string, word) {
    return occurrenceWordCaseSensitive(string.toLowerCase(), word.toLowerCase())
}

var text ='Beer, Beer, Beer.I’m going for a beer.Beer, Beer, Beer.I’m gonna drink some beer.I like drinking beer.Lovely, lovely beer';
var word = 'beer';

console.log(occurrenceWordCaseSensitive(text,word));
console.log(occurrenceWordCaseInsensitive(text,word));