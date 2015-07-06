function processEstatesAgencyCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
    };

    function isString(value) {
        return typeof value === 'string';
    }

    function isNumber(value) {
        return typeof value === 'number';
    }

    function isBoolean(value) {
        return typeof value === 'boolean';
    }

    var Estate = (function () {
        var MinEstateArea = 1,
            MaxEstateArea = 10000;


        function Estate(name, area, location, isFurnitured) {
            this.name = name;
            this.area = area;
            this.location = location;
            this.isFurnitured = isFurnitured;
            this._type = 'Estate';
        }

        Estate.prototype.getName = function () {
            return this.name;
        };

        Estate.prototype.getLocation = function () {
            return this.location;
        };

        Estate.prototype.toString = function () {
            var furnitured = this.isFurnitured ? 'Yes' : 'No',
                result;

            result = this._type + ': Name = ';
            result += this.name + ', Area = ';
            result += this.area + ', Location = ';
            result += this.location + ', Furnitured = ';
            result += furnitured;

            return result;

        };

        Object.defineProperty(Estate.prototype, 'name', {
            get: function () {
                return this._name;
            },
            set: function (value) {
                if (!isString(value)) {
                    throw  new Error('Estate name must be string!');
                } else if (value.length < 1) {
                    throw new Error('Estate name cannot be empty!');
                }

                return this._name = value;
            }
        });
        Object.defineProperty(Estate.prototype, 'area', {
            get: function () {
                return this._area;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw new Error('Estate area must be number!');
                } else if (value < MinEstateArea || value > MaxEstateArea) {
                    throw new Error('Estate area must be between ' + MinEstateArea + ' and ' + MaxEstateArea);
                }

                this._area = value;
            }
        });
        Object.defineProperty(Estate.prototype, 'location', {
            get: function () {
                return this._location;
            },
            set: function (value) {
                if (!isString(value)) {
                    throw new Error('Estate location must be string!');
                } else if (value.length < 1) {
                    throw new Error('Estate location cannot be empty!');
                }

                this._location = value;
            }
        });
        Object.defineProperty(Estate.prototype, 'isFurnitured', {
            get: function () {
                return this._isFurnitured;
            },
            set: function (value) {
                if (!isBoolean(value)) {
                    throw new Error('IsFurnitured must be boolean!');
                }

                this._isFurnitured = value;
            }
        });

        return Estate;
    }());

    var BuildingEstate = (function (parent) {
        var MinRoomsCount = 0,
            MaxRoomsCount = 100;

        function BuildingEstate(name, area, location, isFurnitured, rooms, hasElevator) {
            parent.call(this, name, area, location, isFurnitured);
            this.rooms = rooms;
            this.hasElevator = hasElevator;
            this._type = 'BuildingEstate';
        }

        BuildingEstate.extends(parent);

        BuildingEstate.prototype.toString = function () {
            var result,
                hasElevator = this.hasElevator ? 'Yes' : 'No';

            result = parent.prototype.toString.call(this);
            result += ', Rooms: ' + this.rooms;
            result += ', Elevator: ' + hasElevator;
            return result;
        };

        Object.defineProperty(BuildingEstate.prototype, 'rooms', {
            get: function () {
                return this._rooms;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw  new Error('BuildingEstate rooms must be number!');
                } else if (value < MinRoomsCount || value > MaxRoomsCount) {
                    throw new Error('BuildingEstate rooms must be between ' + MinRoomsCount + ' and ' + MaxRoomsCount);
                }

                this._rooms = value;
            }
        });
        Object.defineProperty(BuildingEstate.prototype, 'hasElevator', {
            get: function () {
                return this._hasElevator;
            },
            set: function (value) {
                if (!isBoolean(value)) {
                    throw  new Error('HasElevator must be Boolean!');
                }

                this._hasElevator = value;
            }
        });

        return BuildingEstate
    }(Estate));

    var Apartment = (function (parent) {
        function Apartment(name, area, location, isFurnitured, rooms, hasElevator) {
            parent.call(this, name, area, location, isFurnitured, rooms, hasElevator);
            this._type = 'Apartment';
        }

        Apartment.extends(BuildingEstate);
        return Apartment
    }(BuildingEstate));

    var Office = (function (parent) {
        function Office(name, area, location, isFurnitured, rooms, hasElevator) {
            parent.call(this, name, area, location, isFurnitured, rooms, hasElevator);
            this._type = 'Office';
        }

        Office.extends(BuildingEstate);
        return Office
    }(BuildingEstate));

    var House = (function (parent) {
        var MinFloorsCount = 1,
            MaxFloorsCount = 10;

        function House(name, area, location, isFurnitured, floors) {
            parent.call(this, name, area, location, isFurnitured);
            this.floors = floors;
            this._type = 'House';
        }

        House.extends(parent);
        Object.defineProperty(House.prototype, 'floors', {
            get: function () {
                return this._floors;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw  new Error('House floors must be number!');
                } else if (value < MinFloorsCount || value > MaxFloorsCount) {
                    throw  new Error('House floors must be between ' + MinFloorsCount + ' and ' + MaxFloorsCount);
                }

                this._floors = value;
            }
        });

        House.prototype.toString = function () {
            var result = parent.prototype.toString.call(this);
            return result += ', Floors: ' + this.floors;
        };

        return House;
    }(Estate));

    var Garage = (function (parent) {
        var MinWidthAndHeightValue = 1,
            MaxWidthAndHeightValue = 500;

        function Garage(name, area, location, isFurnitured, width, height) {
            parent.call(this, name, area, location, isFurnitured);
            this.width = width;
            this.height = height;
            this._type = 'Garage';
        }

        Garage.extends(parent);
        Garage.prototype.toString = function () {
            var result = parent.prototype.toString.call(this);
            return result += ', Width: ' + this.width + ', Height: ' + this.height;
        };

        Object.defineProperty(Garage.prototype, 'width', {
            get: function () {
                return this._width;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw  new Error('Garage width must be number!');
                } else if (value < MinWidthAndHeightValue || value > MaxWidthAndHeightValue) {
                    throw new Error('Garage width must be between ' + MinWidthAndHeightValue + ' and ' + MaxWidthAndHeightValue);
                }
                this._width = value;
            }
        });
        Object.defineProperty(Garage.prototype, 'height', {
            get: function () {
                return this._height;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw  new Error('Garage height must be number!');
                } else if (value < MinWidthAndHeightValue || value > MaxWidthAndHeightValue) {
                    throw new Error('Garage height must be between ' + MinWidthAndHeightValue + ' and ' + MaxWidthAndHeightValue);
                }

                this._height = value;
            }
        });

        return Garage;
    }(Estate));

    var Offer = (function () {
        function Offer(estate, price) {
            this.estate = estate;
            this.price = price;
            this._type = 'Offer';
        }

        Offer.prototype.getEstate = function () {
            return this.estate;
        };
        Offer.prototype.getPrice = function () {
            return this.price;
        };
        Offer.prototype.toString = function () {
            return this._type + ': Estate = ' + this.estate.name + ', Location = ' + this.estate.location + ', Price = ' + this.price;
        };

        Object.defineProperty(Offer.prototype, 'estate', {
            get: function () {
                return this._estate;
            },
            set: function (value) {
                if (!(value instanceof Estate)) {
                    throw new Error('Invalid offer estate!');
                }

                this._estate = value;
            }
        });
        Object.defineProperty(Offer, 'price', {
            get: function () {
                return this._price;
            },
            set: function (value) {
                if (!isNumber(value)) {
                    throw new Error('Offer price must be number!');
                } else if (value < 1) {
                    throw new Error('Offer price must me bigger than 0!');
                }

                this._price = value;
            }
        });
        return Offer;
    }());

    var RentOffer = (function (parent) {
        function RentOffer(estate, price) {
            parent.call(this, estate, price);
            this._type = 'Rent';
        }

        RentOffer.extends(Offer);
        return RentOffer;
    }(Offer));

    var SaleOffer = (function (parent) {
        function SaleOffer(estate, price) {
            parent.call(this, estate, price);
            this._type = 'Sale';
        }

        SaleOffer.extends(Offer);
        return SaleOffer
    }(Offer));

    var EstatesEngine = (function () {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
                case 'create':
                    return executeCreateCommand(cmdArgs);
                case 'status':
                    return executeStatusCommand();
                case 'find-sales-by-location':
                    return executeFindSalesByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-location':
                    return executeFindRentsByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-price':
                    return executeFindRentsByPriceCommand(Number(cmdArgs[0]), Number(cmdArgs[1]));
                default:
                    throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
                case 'Apartment':
                    var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(apartment);
                    break;
                case 'Office':
                    var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(office);
                    break;
                case 'House':
                    var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                    addEstate(house);
                    break;
                case 'Garage':
                    var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                    addEstate(garage);
                    break;
                case 'RentOffer':
                    var estate = findEstateByName(cmdArgs[1]);
                    var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
                    addOffer(rentOffer);
                    break;
                case 'SaleOffer':
                    estate = findEstateByName(cmdArgs[1]);
                    var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
                    addOffer(saleOffer);
                    break;
                default:
                    throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].getName() == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.getName()]) {
                throw new Error('Duplicated estate name: ' + estate.getName());
            }
            _uniqueEstateNames[estate.getName()] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof SaleOffer;
            });
            selectedOffers.sort(function (a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof RentOffer;
            });
            selectedOffers.sort(function (a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByPriceCommand(minPrice, maxPrice) {

            if (!isNumber(minPrice) || !isNumber(maxPrice)) {
                throw new Error('Min price must be numbers!');
            } else if (isNaN(minPrice) || isNaN(maxPrice)) {
                throw new Error('Max price must be number');
            }

            var cmp = function (a, b) {
                if (a > b) return +1;
                if (a < b) return -1;
                return 0;
            };

            var selectedOffers = _offers.filter(function (offer) {
                return (offer.getPrice() >= minPrice) && (offer.getPrice() <= maxPrice) &&
                    (offer instanceof RentOffer);
            });

            selectedOffers.sort(function (a, b) {
                return cmp(a.getPrice(), b.getPrice()) || cmp(a.getEstate().getName(), b.getEstate().getName())
            });
            return formatQueryResults(selectedOffers);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.getEstate().getName() +
                        ', Location: ' + offer.getEstate().getLocation() +
                        ', Price: ' + offer.getPrice() + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());

    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}