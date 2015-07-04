/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * method removeAttribute(attribute)
 * throw Error if attribute does not exist in the domElement
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {

        function validTypeCharacters(type) {
            return /^\w+$/.test(type);
        }

        function validName(name) {
            return /^[A-Z\d\-]+$/i.test(name);
        }

        function isValidString(value) {
            if (typeof value !== 'string') {
                throw new Error('Type must be string');
            } else if (value.length <= 0) {
                throw new Error('Type cannot be empty');
            }
        }

        function validType(value) {
            isValidString(value);
            if (!validTypeCharacters(value)) {
                throw new Error('Type must contains only letters and digits');
            }
        }

        function validAttributeName(value) {
            isValidString(value);
            if (!validName(value)) {
                throw new Error('Type must contains only letters and digits');
            }
        }

        function getAttributesAsString(attributes) {
            var i,
                len,
                result = '';

            if (attributes.length > 0) {

                for (i = 0, len = attributes.length; i < len; i += 1) {
                    result += (' ' + attributes[i].name + '="' + attributes[i].value + '"');
                }
            }

            return result;
        }

        function parseHTML(domElement) {
            var i,
                len,
                child,
                result = '',
                attributes = domElement.attributes.sort(function (a, b) {
                    return a.name > b.name;
                });

            result += '<' + domElement.type;
            result += getAttributesAsString(attributes) + '>';


            for (i = 0, len = domElement.children.length; i < len; i += 1) {
                child = domElement.children[i];

                if (typeof child === 'string') {
                    result += child;
                } else {

                    result += child.innerHTML;
                }
            }

            result += domElement.content;
            result += '</' + domElement.type + '>';
            return result;
        }

        var domElement = {
            init: function (type) {
                this.type = type;
                this.content = '';
                this.parent;
                this.attributes = [];
                this.children = [];
                return this;
            },
            appendChild: function (child) {
                if (typeof child !== 'string') {
                    child.parent = this;
                }

                this.children.push(child);
                return this
            },
            addAttribute: function (name, value) {
                validAttributeName(name);
                var index = this.attributes.map(function (e) {
                    return e.name;
                }).indexOf(name);

                if (index !== -1) {
                    this.attributes[index] = {name: name, value: value};

                } else {
                    this.attributes.push({name: name, value: value});
                }

                return this
            },
            removeAttribute: function (attribute) {
                var index = this.attributes.map(function (x) {
                    return x.name;
                }).indexOf(attribute);

                if (index === -1) {
                    throw new Error('This attribute does not exist.');
                }

                this.attributes = this.attributes.filter(function (el) {
                    return el.name != attribute;
                });
                return this
            },

            get type() {
                return this._type;
            },
            set type(value) {
                validType(value);
                this._type = value;
            },
            get content() {
                if (this.children.length) {
                    return '';
                }
                return this._content;
            },
            set content(value) {
                this._content = value;
            },
            get parent() {
                return this._parent;
            },
            set parent(value) {
                this._parent = value;
            },
            get innerHTML() {
                return parseHTML(this);
            }
        };
        return domElement;
    }());
    return domElement;
}

module.exports = solve;