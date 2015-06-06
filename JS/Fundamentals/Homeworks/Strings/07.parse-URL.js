function parseURL(inputUrl) {
    inputUrl = inputUrl.replace(':','');
    var url = {
            protocol: '',
            server: '',
            resource: ''
        },
        parts = inputUrl.split('/');

    url.protocol= parts[0];
    url.server = parts[2];
    url.resource = parts.slice(3).join('/');

    return url;
}

var url= "http://telerikacademy.com/Courses/Courses/Details/239";

var parsed = parseURL(url);
console.log('protocol:'+ parsed.protocol);
console.log('server:'+ parsed.server);
console.log('resourse:'+ parsed.protocol);