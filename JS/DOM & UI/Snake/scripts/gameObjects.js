var gameObjects = (function () {
    var snake = (function () {
        var snake = Object.create({}),
            CONSTANTS = {
                X: ( (3 * window.innerWidth / 4)) / 2,
                Y: (window.innerHeight ) / 2,
                R: 10,
                START_ANGLE: 5,
                END_ANGLE: 2 * Math.PI,
                IS_CIRCLE: true,
                START_NODES_LENGTH: 5,
                SNAKE_SPEED: 70,
                SNAKE_START_DIRECTION: 'right',
                CHANGE_DIRECTION_VALUE: 15
            };

        function initializeFirstSnakeMembers() {
            var tail = [],
                i;

            for (i = 0; i < CONSTANTS.START_NODES_LENGTH; i += 1) {
                var currentMember = Object.create(snakeNode).init(CONSTANTS.X - (i * CONSTANTS.START_NODES_LENGTH * 3), CONSTANTS.Y, CONSTANTS.R, CONSTANTS.START_ANGLE, CONSTANTS.END_ANGLE, CONSTANTS.IS_CIRCLE);
                tail.push(currentMember);
            }

            return tail.slice();
        }

        Object.defineProperty(snake, 'init', {
            value: function () {
                this.direction = CONSTANTS.SNAKE_START_DIRECTION;
                this.tail = initializeFirstSnakeMembers();
                this.foodEaten = 0;
                this.head = 0;
                this.isAlive = true;
                this.speed = CONSTANTS.SNAKE_SPEED;
                return this
            }
        });

        Object.defineProperty(snake, 'addSnakeNode', {
            value: function (node) {
                if (this.head) {
                    this.tail.push(node);
                } else {
                    this.tail.unshift(node);
                }

                return this
            }
        });

        Object.defineProperty(snake, 'removeSnakeNode', {
            value: function () {
                if (this.head) {
                    this.tail.shift();
                } else {
                    this.tail.pop();
                }
            }
        });

        Object.defineProperty(snake, 'move', {

            value: function () {
                var headMember = this.tail[this.head],
                    x = headMember.x,
                    y = headMember.y,
                    node;

                switch (this.direction) {
                    case'right':
                        x += CONSTANTS.CHANGE_DIRECTION_VALUE;
                        break;
                    case 'left':
                        x -= CONSTANTS.CHANGE_DIRECTION_VALUE;
                        break;
                    case 'up':
                        y -= CONSTANTS.CHANGE_DIRECTION_VALUE;
                        break;
                    case 'down':
                        y += CONSTANTS.CHANGE_DIRECTION_VALUE;
                        break;
                }

                node = this.createSimilarSnakeNode(x, y, headMember);
                this.addSnakeNode(node);
            }
        });

        Object.defineProperty(snake, 'createSimilarSnakeNode', {
            value: function (x, y, node) {
                return Object.create(snakeNode).init(x, y, node.radius, node.start, node.end, node.isCircle);
            }
        });

        return snake;
    }());

    var snakeNode = (function () {
        var snakeNode = Object.create({}),
            CONSTANTS = {
                RANDOM_TO_STRING_NUMERICAL_SYSTEM: 16,
                COLOR_INDEX: -6
            };


        function getRandomColor() {
            var color = '#' + Math.random().toString(CONSTANTS.RANDOM_TO_STRING_NUMERICAL_SYSTEM).substr(CONSTANTS.COLOR_INDEX);
            return color;
        }

        Object.defineProperty(snakeNode, 'init', {
            value: function (x, y, radius, start, end, isCircle) {
                this.x = x;
                this.y = y;
                this.radius = radius;
                this.start = start;
                this.end = end;
                this.isCircle = isCircle;
                this.color = getRandomColor();
                return this
            }
        });

        return snakeNode;
    }());

    var food = (function () {
        var food = Object.create({}),
            CONSTANTS = {
                FOOD_SIZE: 30
            };

        Object.defineProperty(food, 'init', {
            value: function (x, y) {
                this.x = x;
                this.y = y;
                this.size = CONSTANTS.FOOD_SIZE;
                this.image = new Image();
                this.image.src = 'images/appleYellow.png';
                return this;
            }
        });

        return food;
    }());

    var stone = (function () {
        var stone = Object.create({});

        Object.defineProperty(stone, 'init', {
            value: function (x, y) {
                this.x = x;
                this.y = y;
                this.image = new Image();
                this.image.src = 'images/stone.png';
                return this
            }
        });

        return stone;
    }());

    return {
        snake: snake,
        food: food,
        snakeNode: snakeNode,
        stone: stone
    }

}());