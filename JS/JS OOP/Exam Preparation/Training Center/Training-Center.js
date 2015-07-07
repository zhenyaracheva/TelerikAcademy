function processTrainingCenterCommands(commands) {

    'use strict';

    var trainingcenter = (function () {

        var TrainingCenterEngine = (function () {

            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;

            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }

            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }

            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName,
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description,
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }

            function findTrainerByUsername(username) {
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }

            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }

            function addTraining(training) {
                _trainings.push(training);
            }

            function executeListCommand() {
                var result = '', i;
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }

                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }

                return result.trim();
            }

            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        // TODO: implement "delete Trainer" command
                        throw new Error('Command "delete Trainer" not implemented.');
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };

            return trainingCenterEngine;
        }());

        function isString(value) {
            return typeof value === 'string';
        }

        function isNumber(value) {
            return typeof value === 'number';
        }

        function isNullOrUndefined(value) {
            if (value === undefined || value === null) {
                return true;
            }

            return false;
        }

        function formatDate(date) {
            var month = date.toString().split(' ')[1];
            return date.getDate() + '-' + month + '-' + date.getFullYear();
        }

        Function.prototype.extends = function (parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        };

        var Trainer = (function () {
            function Trainer(username, firstName, lastName, email) {
                this.username = username;
                this.firstName = firstName;
                this.lastName = lastName;
                this.email = email;
            }

            Object.defineProperty(Trainer, 'username', {
                get: function () {
                    return this._username;
                },
                set: function (value) {
                    if (!isString(value)) {
                        throw new Error('Trainer username must be string!');
                    } else if (!value) {
                        throw new Error('Trainer username cannot be empty string!');
                    }

                    this._username = value;
                }
            });
            Object.defineProperty(Trainer, 'firstName', {
                get: function () {
                    return this._firstName;
                },
                set: function (value) {

                    if (!isNullOrUndefined(value)) {
                        if (!isString(value)) {
                            throw new Error('Trainer firstName must be string!');
                        } else if (!value) {
                            throw new Error('Trainer firstName cannot be empty string!');
                        }
                    }

                    this._firstName = value;
                }
            });
            Object.defineProperty(Trainer, 'lastName', {
                get: function () {
                    return this._lastName;
                },
                set: function (value) {
                    if (!isString(value)) {
                        throw new Error('Trainer lastName must be string!');
                    } else if (!value) {
                        throw new Error('Trainer lastName cannot be empty string!');
                    }

                    this._lastName = value;
                }
            });
            Object.defineProperty(Trainer, 'email', {
                get: function () {
                    return this._email;
                },
                set: function (value) {

                    if (!isNullOrUndefined(value)) {
                        if (!isString(value)) {
                            throw new Error('Trainer email must be string!');
                        } else if (!value) {
                            throw new Error('Trainer email cannot be empty string!');
                        } else if (value.indexOf('@') === -1) {
                            throw new Error('Trainer email must contains "@"!')
                        }
                    }

                    this._email = value;
                }
            });

            Trainer.prototype.getUsername = function () {
                return this.username;
            };
            Trainer.prototype.toString = function () {
                var result;

                result = 'Trainer[username=' + this.username;
                if (!isNullOrUndefined(this.firstName)) {
                    result += ';first-name=' + this.firstName;
                }
                result += ';last-name=' + this.lastName;
                if (!isNullOrUndefined(this.email)) {
                    result += ';email=' + this.email + ']';
                } else {
                    result += ']';
                }

                return result;
            };

            return Trainer;
        }());

        var Training = (function () {
            var MinDurationValue = 1,
                MaxDurationValue = 99;

            function Training(name, description, trainer, startDate, duration) {
                this.name = name;
                this.description = description;
                this.trainer = trainer;
                this.startDate = startDate;
                this.duration = duration;
            }

            Object.defineProperty(Training, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    if (!isString(value)) {
                        throw new Error('Training name must be string!');
                    }

                    this._name = value;
                }
            });
            Object.defineProperty(Training, 'description', {
                get: function () {
                    return this._description;
                },
                set: function (value) {

                    if (!isNullOrUndefined(value)) {
                        if (!isString(value)) {
                            throw new Error('Training description must be string!');
                        } else if (!value) {
                            throw new Error('Training description cannot be empty string!');
                        }
                    }

                    this._description = value;
                }
            });
            Object.defineProperty(Training, 'trainer', {
                get: function () {
                    return this._trainer;
                },
                set: function (value) {
                    if (!isNullOrUndefined(value)) {
                        if (!(value instanceof  Trainer)) {
                            throw new Error('Training trainer must be instance of Trainer');
                        }
                    }

                    this._trainer = value;
                }
            });
            Object.defineProperty(Training, 'startDate', {
                get: function () {
                    return this._startDate;
                },
                set: function (value) {
                    if (!(value instanceof Date)) {
                        throw new Error('Training startDate must be instance of Date');
                    }

                    this._startDate = value;
                }
            });
            Object.defineProperty(Training, 'duration', {
                get: function () {
                    return this._duration;
                },
                set: function (value) {
                    if (!isNullOrUndefined(value)) {
                        if (!isNumber(value)) {
                            throw new Error('Training duration must be number!');
                        } else if (value < MinDurationValue || value > MaxDurationValue) {
                            throw new Error('Training duration must be between ' + MinDurationValue + ' and ' + MaxDurationValue);
                        }
                    }

                    this._duration = value;
                }
            });

            Training.prototype.toString = function () {

                var result = this.constructor.name + '[name=' + this.name;
                if (!isNullOrUndefined(this.description)) {
                    result += ';description=' + this.description;
                }
                if (!isNullOrUndefined(this.trainer)) {
                    result += ';trainer=' + this.trainer.toString();
                }

                result += ';start-date=' + formatDate(this.startDate);

                if (!isNullOrUndefined(this.duration)) {
                    result += ';duration=' + this.duration
                }

                return result + ']';
            };

            return Training;
        }());

        var Course = (function (parent) {
            function Course(name, description, trainer, startDate, duration) {
                parent.call(this, name, description, trainer, startDate, duration)
            }

            Course.extends(parent);
            return Course;
        }(Training));

        var Seminar = (function (parent) {
            var SeminarDuration = 1,
                UsedWordStartDate = 'start-date',
                UsedWordForDuration = ';duration=1',
                replacedWord = 'date';

            function Seminar(name, description, trainer, startDate) {
                parent.call(this, name, description, trainer, startDate, SeminarDuration);
            }

            Seminar.extends(parent);
            Seminar.prototype.toString = function () {
                var result = parent.prototype.toString.call(this),
                    patternStartDate = new RegExp(UsedWordStartDate, 'ig'),
                    patternDuration = new RegExp(UsedWordForDuration, 'ig');

                result = result.replace(patternDuration, '');
                return result.replace(patternStartDate, replacedWord);
            };
            return Seminar;
        }(Training));

        var RemoteCourse = (function (parent) {
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                parent.call(this, name, description, trainer, startDate, duration);
                this.location = location;
            }

            RemoteCourse.extends(Course);
            RemoteCourse.prototype.toString = function () {
                var result = parent.prototype.toString.call(this).split('');
                result = result.splice(0, result.length - 1);
                return result.join('') + ';location=' + this.location + ']'
            };

            Object.defineProperty(RemoteCourse, 'location', {
                get: function () {
                    return this._location;
                },
                set: function (value) {
                    if (!isString(value)) {
                        throw new Error('RemoteCourse location must be string!');
                    }

                    this._location = value;
                }
            });

            return RemoteCourse;
        }(Course));


        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };

        return trainingcenter;
    })
    ();


    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    };


    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    };


    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

// (function () {
//     var arr = [];
//     if (typeof (require) == 'function') {
//         // We are in node.js --> read the console input and process it
//         require('readline').createInterface({
//             input: process.stdin,
//             output: process.stdout
//         }).on('line', function (line) {
//             arr.push(line);
//         }).on('close', function () {
//             console.log(processTrainingCenterCommands(arr));
//         });
//     }
// })();
//