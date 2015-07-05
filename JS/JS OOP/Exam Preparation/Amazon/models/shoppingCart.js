var models = models || {};

(function (scope) {

    function ShoppingCart() {
        this._items = [];
    }

    ShoppingCart.prototype.addItem = function (item) {
        this._items.push(item);
        return this._items.slice();
    };

    ShoppingCart.prototype.getTotalPrice = function () {
        var i,
            len,
            totalPrice = 0;

        for (i = 0, len = this._items.length; i < len; i += 1) {
            totalPrice+= this._items[i].price;
        }

        return totalPrice;
    };

    scope.getShoppingCart = function () {
        return new ShoppingCart();
    }

}(models));