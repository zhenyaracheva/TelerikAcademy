var models = models || {};

(function (models) {


    function Category(name) {
        this.name = name;
        this._categories = [];
        this._items = [];
    }

    Category.prototype.addCategory = function addCategory(category) {
        this._categories.push(category);
        return this._categories.slice();
    };

    Category.prototype.getCategories = function getCategories() {
        return this._categories.slice();
    };

    Category.prototype.addItem = function addItem(item) {
        this._items.push(item);
        return this._items.slice();
    };

    Category.prototype.getItems = function getItems() {
        return this._items.slice();
    };

    models.getCategory = function (name) {
        return new Category(name);
    }

}(models));