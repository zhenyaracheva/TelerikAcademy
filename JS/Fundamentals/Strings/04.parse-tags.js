function parseTags(text) {
    var i,
        len,
        result = '',
        tag,
        endIndex,
        rand,
        inTag = false,
        tags = [];

    for (i = 0, len = text.length; i < len; i += 1) {

        if (text[i] === '<') {

            if (text[i + 1] === '/') {
                inTag = false;
                tag = tags.pop();
                i += tag.length + 2;

            } else {
                inTag = true;
                endIndex = text.indexOf('>', i + 1);
                tag = text.substring(i + 1, endIndex);
                tags.push(tag);
                i += tag.length + 1;
            }

        } else {

            if (inTag) {
                tag = tags[tags.length - 1];

                switch (tag) {
                    case "upcase":
                        result += text[i].toUpperCase();
                        break;
                    case "lowcase":
                        result += text[i].toLowerCase();
                        break;
                    case "mixcase":
                        rand = Math.random() * 2 | 0;
                        if (rand) {
                            result += text[i].toLowerCase();
                        } else {
                            result += text[i].toUpperCase();
                        }
                        break;
                }
            } else {
                result += text[i];
            }
        }
    }

    return result;
}

var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

var textNested = "We are <mixcase>living</mixcase> in a <upcase>yellow <mixcase>submarine</mixcase></upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

console.log(parseTags(text));
console.log(parseTags(textNested));