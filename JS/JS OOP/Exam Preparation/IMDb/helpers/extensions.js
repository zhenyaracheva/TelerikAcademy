if (!Function.prototype.expand) {
    Function.prototype.extend = function (parent) {
        this.prototype = Object.create(parent.prototype);
    };
}

if (!Array.prototype.getIndexByParameter) {
    Array.prototype.getIndexByParameter = function (parameterName, value) {
        var i,
            len;

        for (i = 0, len = this.length; i < len; i += 1) {
            if (this[i][parameterName] === value) {
                return i;
            }
        }
    }
}