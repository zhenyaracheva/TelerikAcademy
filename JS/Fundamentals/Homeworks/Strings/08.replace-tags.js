function replaceTags(text) {
    var original = /<a href="(.*?)">(.*?)<\/a>/,
        replace = '[URL=$1]$2[/URL]',
        index = text.indexOf('<a');

    while (index !== -1) {
        text = text.replace(original, replace);
        index = text.indexOf('<a', index + 1);
    }
    console.log(text);
}

var input = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

replaceTags(input);