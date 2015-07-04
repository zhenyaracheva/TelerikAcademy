var cosmeticShop = (function () {
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

    var product = (function () {
        var _productMinLength = 3,
            _productNameAndBrandMaxLength = 10,
            _productMinBrandNameLength = 2,
            product = {},
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

        Object.defineProperty(product, 'init', {
            value: function (name, brand, price, gender) {
                this.name = name;
                this.brand = brand;
                this.price = price;
                this.gender = genderType[gender.toUpperCase()];
                return this
            }
        });
        Object.defineProperty(product, 'print', {
            value: function () {
                var stringToReturn = '- ' + this.brand + ' - ' + this.name + '\n';
                stringToReturn += ' * Price: $' + this.price + '\n';
                stringToReturn += ' * For gender: ' + this.gender;
                return stringToReturn
            }
        });
        Object.defineProperty(product, 'name', {
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
        Object.defineProperty(product, 'brand', {
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
        Object.defineProperty(product, 'price', {
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
        Object.defineProperty(product, 'gender', {
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

        return product
    }());

    var shampoo = (function (parent) {
        var shampoo = Object.create(parent),
            usageType = {
                EVERYDAY: 'EVERYDAY',
                MEDICINE: 'MEDICINE'
            };

        function isValidUsage(usage) {
            if (usageType[usage] === undefined) {
                return false;
            }

            return true;
        }

        Object.defineProperty(shampoo, 'init', {
            value: function (name, brand, price, gender, milliliters, usage) {
                this.milliliters = milliliters;
                parent.init.call(this, name, brand, (price * milliliters), gender);
                this.usage = usageType[usage.toUpperCase()];
                return this
            }
        });
        Object.defineProperty(shampoo, 'print', {
            value: function () {
                var stringToReturn = parent.print.call(this) + '\n';
                stringToReturn += ' * Quantity: ' + this.milliliters + ' ml\n';
                stringToReturn += ' * Usage: ' + this.usage;
                return stringToReturn;
            }
        });
        Object.defineProperty(shampoo, 'usage', {
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
        Object.defineProperty(shampoo, 'milliliters', {
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

        return shampoo;
    }(product));

    var toothpaste = (function (parent) {
        var toothpaste = Object.create(parent),
            _minIngredientNameLength = 4,
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

        Object.defineProperty(toothpaste, 'init', {
            value: function (name, brand, price, gender, ingredients) {
                parent.init.call(this, name, brand, price, gender);
                this.ingredients = ingredients;
                return this
            }
        });
        Object.defineProperty(toothpaste, 'print', {
            value: function () {
                var stringToReturn = parent.print.call(this) + '\n';
                stringToReturn += ' * Ingredients: ' + this.ingredients;
                return stringToReturn;
            }
        });
        Object.defineProperty(toothpaste, 'ingredients', {
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

        return toothpaste;
    }(product));

    var category = (function () {
        var _cosmetics = [],
            _minCategoryNameLength = 2,
            _maxCategoryNameLength = 15,
            category = {},
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

        Object.defineProperty(category, 'init', {
            value: function (name) {
                this.name = name;
                return this
            }
        });
        Object.defineProperty(category, 'addCosmetics', {
            value: function (cosmetic) {
                _cosmetics.push(cosmetic);
                return _cosmetics.splice();
            }
        });
        Object.defineProperty(category, 'removeCosmetics', {
            value: function (cosmetic) {
                var index = _cosmetics.indexOf(cosmetic);
                if (index === -1) {
                    throw new Error('Product ' + cosmetic.name + ' does not exist in category ' + this.name + '!');
                }

                _cosmetics.splice(index, 1);
                return _cosmetics.splice();
            }
        });
        Object.defineProperty(category, 'print', {
            value: function () {
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
            }
        });
        Object.defineProperty(category, 'name', {
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

        return category;
    }());

    var shoppingCart = (function () {
        var _products = [],
            shoppingCart = {};

        Object.defineProperty(shoppingCart, 'init', {
            value: function () {
                return this
            }
        });
        Object.defineProperty(shoppingCart, 'addProduct', {
            value: function (product) {
                _products.push(product);
                return _products.slice();
            }
        });
        Object.defineProperty(shoppingCart, 'removeProduct', {
            value: function (product) {
                var index = _products.indexOf(product);
                if (index !== -1) {
                    _products.splice(index, 1);
                }

                return _products.splice();
            }
        });
        Object.defineProperty(shoppingCart, 'containsProduct', {
            value: function (product) {
                if (_products.indexOf(product) === -1) {
                    return false;
                }

                return true;
            }
        });
        Object.defineProperty(shoppingCart, 'totalPrice', {
            value: function () {
                var i,
                    len,
                    sum = 0;

                for (i = 0, len = _products.length; i < len; i += 1) {
                    sum += _products[i].price;
                }

                return sum;
            }
        });

        return shoppingCart;
    }());

    var cosmeticsFactory = (function () {
        var cosmeticsFactory = {};

        Object.defineProperty(cosmeticsFactory, 'createCategory', {
            value: function (name) {
                return Object.create(category).init(name);
            }
        });
        Object.defineProperty(cosmeticsFactory, 'createShampoo', {
            value: function (name, brand, price, gender, milliliters, usage) {
                return Object.create(shampoo).init(name, brand, price, gender, milliliters, usage);
            }
        });
        Object.defineProperty(cosmeticsFactory, 'createToothpaste', {
            value: function (name, brand, price, gender, ingredients) {
                return Object.create(toothpaste).init(name, brand, price, gender, ingredients);
            }
        });
        Object.defineProperty(cosmeticsFactory, 'createShoppingCart', {
            value: function () {
                return Object.create(shoppingCart).init();
            }
        });

        return cosmeticsFactory;
    }());

    return {
        cosmeticsFactory: cosmeticsFactory
    };
}());