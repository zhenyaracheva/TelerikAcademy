function findPalindromes(text) {
    text = text || "";
    var i,
        len,
        word,
        palindromes = [],
        splitedText = text.match(/[A-Z0-9_-]+/gi);

    for (i = 0, len = splitedText.length; i < len; i += 1) {
        word = splitedText[i];
        if (word === word.split('').reverse().join('')) {
            palindromes.push(splitedText[i]);
        }
    }

    return palindromes;
}


var text = "neven, text exe notPalindrome asdsa.";

console.log(findPalindromes(text));