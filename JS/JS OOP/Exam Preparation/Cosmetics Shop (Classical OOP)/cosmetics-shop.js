var CosmeticShop = (function () {

    function isString(value) {
        if (typeof value === 'string') {
            return true;
        }

        return false;
    }

    function isNullOrUndefined(value) {
        if (value === null || value === undefined) {
            return true;
        }

        return false
    }

    var Product = (function () {

        var _productMinLength = 3,
            _productNameAndBrandMaxLength = 10,
            _productMinBrandNameLength = 2,
            genderType = {
                MEN: 'MEN',
                WOMEN: 'WOMEN',
                UNISEX: 'UNISEX'
            };

        function isValidProductName(name) {
            if (!isString(name)) {
                return false;
            } else if (name.length < _productMinLength || name.length > _productNameAndBrandMaxLength) {
                return false;
            }

            return true;
        }

        function isValidBrandName(name) {
            if (!isString(name)) {
                return false;
            } else if (name.length < _productMinBrandNameLength || name.length > _productNameAndBrandMaxLength) {
                return false;
            }

            return true;
        }

        function Product(name, brand, price, gender) {
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = genderType[gender.toUpperCase()];
        }

        Product.prototype.print = function () {
            var stringToReturn = '- ' + this.brand + ' - ' + this.name + '\n';
            stringToReturn += ' * Price: $' + this.price + '\n';
            stringToReturn += ' * For gender: ' + this.gender;
            return stringToReturn
        };

        Object.defineProperty(Product.prototype, 'name', {
            get: function () {
                return this._name;
            },
            set: function (value) {
                if (!isValidProductName(value)) {
                    throw new Error('Product name must be string between ' + _productMinLength + ' and ' + _productNameAndBrandMaxLength + ' symbols');
                }

                this._name = value;
            }
        });
        Object.defineProperty(Product.prototype, 'brand', {
            get: function () {
                return this._brand;
            },
            set: function (value) {
                if (!isValidBrandName(value)) {
                    throw new Error('Product brand must be string between ' + _productMinBrandNameLength + ' and ' + _productNameAndBrandMaxLength + ' symbols long!');
                }

                this._brand = value;
            }
        });
        Object.defineProperty(Product.prototype, 'price', {
            get: function () {
                return this._price;
            },
            set: function (value) {
                if (value <= 0) {
                    throw new Error('Price cannot be less than $1!')
                }

                this._price = value;
            }
        });
        Object.defineProperty(Product.prototype, 'gender', {
            get: function () {
                return this._gender;
            },
            set: function (value) {
                if (value === undefined) {
                    throw new Error('Gender type must be MAN, WOMEN or UNISEX!')
                }

                this._gender = value;
            }
        });

        return Product;
    }());

    var Shampoo = (function (parent) {
        var usageType = {
            EVERYDAY: 'EVERYDAY',
            MEDICINE: 'MEDICINE'
        };

        function isValidUsage(usage) {
            if (usageType[usage] === undefined) {
                return false;
            }

            return true;
        }

        function Shampoo(name, brand, price, gender, milliliters, usage) {
            this.milliliters = milliliters;
            parent.call(this, name, brand, price * milliliters, gender);
            this.usage = usageType[usage.toUpperCase()];
        }

        Shampoo.prototype.print = function () {
            var stringToReturn = parent.prototype.print.call(this) + '\n';
            stringToReturn += ' * Quantity: ' + this.milliliters + ' ml\n';
            stringToReturn += ' * Usage: ' + this.usage;
            return stringToReturn;
        };

        Object.defineProperty(Shampoo.prototype, 'milliliters', {
            get: function () {
                return this._milliliters;
            },
            set: function (value) {
                if (isNullOrUndefined(value)) {
                    throw new Error('Milliliters cannot be null or undefined')
                } else if (isString(value)) {
                    throw new Error('Milliliters cannot be string!')
                } else if (value <= 0) {
                    throw new Error('Milliliters cannot be less or equal to 0!');
                }

                this._milliliters = value;
            }
        });
        Object.defineProperty(Shampoo.prototype, 'usage', {
            get: function () {
                return this._usage;
            },
            set: function (value) {
                if (!isValidUsage(value)) {
                    throw new Error('Usage can be EVERYDAY or MEDICINE!');
                }

                this._usage = value;
            }
        });

        return Shampoo;
    }(Product));

    var Toothpaste = (function (parent) {
        var _minIngredientNameLength = 4,
            _maxIngredientNameLength = 12;

        function isValidIngredient(value) {
            var i,
                len;

            for (i = 0, len = value.length; i < len; i += 1) {
                if (!isString(value[i])) {
                    return false;
                }
                if (value[i].length < _minIngredientNameLength || value[i].length >= _maxIngredientNameLength) {
                    return false;
                }
            }

            return true
        }

        function Toothpaste(name, brand, price, gender, ingredients) {
            parent.call(this, name, brand, price, gender);
            this.ingredients = ingredients;
        }

        Toothpaste.prototype.print = function () {
            var stringToReturn = parent.prototype.print.call(this) + '\n';
            stringToReturn += ' * Ingredients: ' + this.ingredients;
            return stringToReturn;
        };

        Object.defineProperty(Toothpaste.prototype, 'ingredients', {
            get: function () {
                return this._ingredients;
            },
            set: function (value) {
                if (isNullOrUndefined(value)) {
                    throw new Error('Ingredients cannot be null or undefined!');
                } else if (isString(value)) {
                    throw new Error('Ingredients cannot be string!');
                } else if (value.length < 1) {
                    throw  new Error('Missing ingredients!')
                } else if (!isValidIngredient(value)) {
                    throw new Error('Each ingredient must be string between ' + _minIngredientNameLength + ' and ' + _maxIngredientNameLength + ' symbols long!');
                }

                this._ingredients = value.join(', ');
            }
        });

        return Toothpaste;
    }(Product));

    var Category = (function () {
        var _cosmetics = [],
            _minCategoryNameLength = 2,
            _maxCategoryNameLength = 15,
            compareAscending,
            compareDescending;

        function isValidCategoryName(name) {
            if (!isString(name)) {
                return false;
            } else if (name.length < _minCategoryNameLength || name.length > _maxCategoryNameLength) {
                return false;
            }

            return true
        }

        compareAscending = function (a, b) {
            if (a > b) return 1;
            if (a < b) return -1;
            return 0;
        };
        compareDescending = function (a, b) {
            if (a < b) return 1;
            if (a > b) return -1;
            return 0;
        };

        function Category(name) {
            this.name = name;
        }

        Category.prototype.addCosmetics = function (cosmetic) {
            _cosmetics.push(cosmetic);
            return _cosmetics.splice();
        };
        Category.prototype.removeCosmetics = function (cosmetic) {
            var index = _cosmetics.indexOf(cosmetic);
            if (index === -1) {
                throw new Error('Product ' + cosmetic.name + ' does not exist in category ' + this.name + '!');
            }

            _cosmetics.splice(index, 1);
            return _cosmetics.slice();
        };
        Category.prototype.print = function () {
            var i,
                len,
                result,
                productsToReturn;

            result = this.name + ' category - ' + _cosmetics.length + '\n';
            productsToReturn = _cosmetics.sort(function (a, b) {
                return compareAscending(a.brand, b.brand) || compareDescending(a.price, b.price)
            });

            for (i = 0, len = productsToReturn.length; i < len; i += 1) {
                result += productsToReturn[i].print() + '\n';
            }

            return result;
        };

        Object.defineProperty(Category.prototype, 'name', {
            get: function () {
                return this._name;
            },
            set: function (value) {
                if (!isValidCategoryName(value)) {
                    throw  new Error('Category name must be between ' + _minCategoryNameLength + ' and ' + _maxCategoryNameLength + ' symbols long!');
                }

                this._name = value;
            }
        });

        return Category;
    }());

    var ShoppingCart = (function () {
        var _products = [];

        function ShoppingCart() {
        }

        ShoppingCart.prototype.addProduct = function (product) {
            _products.push(product);
            return _products.slice();
        };

        ShoppingCart.prototype.removeProduct = function (product) {
            var index = _products.indexOf(product);
            if (index !== -1) {
                _products.splice(index, 1);
            }

            return _products.slice();
        };

        ShoppingCart.prototype.containsProduct = function (product) {
            if (_products.indexOf(product) === -1) {
                return false;
            }

            return true;
        };

        ShoppingCart.prototype.totalPrice = function () {
            var i,
                len,
                sum = 0;

            for (i = 0, len = _products.length; i < len; i += 1) {
                sum += _products[i].price;
            }

            return sum;
        };

        return ShoppingCart;
    }());

    var CosmeticsFactory = (function () {

        function CosmeticsFactory() {

        }

        CosmeticsFactory.prototype.createCategory = function (name) {
            return new Category(name);
        };
        CosmeticsFactory.prototype.createShampoo = function (name, brand, price, gender, milliliters, usage) {
            return new Shampoo(name, brand, price, gender, milliliters, usage);
        };
        CosmeticsFactory.prototype.createToothpaste = function (name, brand, price, gender, ingredients) {
            return new Toothpaste(name, brand, price, gender, ingredients);
        };
        CosmeticsFactory.prototype.createShoppingCart = function () {
            return new ShoppingCart();
        }

        return CosmeticsFactory;
    }());

    function CosmeticShop(){
        this.factory = new CosmeticsFactory();
    }

    return CosmeticShop

}());