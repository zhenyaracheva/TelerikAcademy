var models = models || {};

(function (scope) {

    function Item(title, description, price) {
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function addCustomerReview(customerReview) {
        this._customerReviews.push(customerReview);
        return this._customerReviews.slice();
    };

    Item.prototype.getCustomerReviews = function getCustomerReviews() {
        return this._customerReviews.slice();
    };

    scope._Item = Item;

    scope.getItem = function (title, description, price) {
        return new Item(title, description, price);
    };

}(models));