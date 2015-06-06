if (!Array.prototype.remove) {
    Array.prototype.remove = function (element) {
        var i,
            len;

        for (i = 0, len = this.length; i < len; i += 1) {
            if (this[i] === element) {
                this.splice(i, 1);
                i -= 1;
            }
        }

        return this;
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log(arr);
console.log(arr.remove(1));