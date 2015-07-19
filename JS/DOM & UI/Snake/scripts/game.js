var game = (function () {
    var canvas,
        canvasContext,
        food,
        foodSize,
        game,
        gameRun,
        h,
        level,
        render,
        snake,
        w,
        CONSTANTS = {
            HIT_WALL_MIN_VALUE: 5,
            HIT_WALL_MAX_VALUE: 10,
            LEFT_ARROW: 37,
            UP_ARROW: 38,
            RIGHT_ARROW: 39,
            DOWN_ARROW: 40,
            SPEED_UPDATE: 10,
            LEVEL_UPDATE: 5,

        };


    canvas = document.getElementById('canvas');
    canvasContext = canvas.getContext('2d');
    game = Object.create({});
    foodSize = Object.create(gameObjects.food).init().size;
    h = window.innerHeight - foodSize;
    w = window.innerWidth - foodSize;
    food = Object.create(gameObjects.food).init(getRandom(w - foodSize), getRandom(h - foodSize));
    level = 1;
    render = Object.create(renderer);
    snake = Object.create(gameObjects.snake).init();

    canvas.height = h;
    canvas.width = w;

    function isHitWall(x, y) {
        if (0 > x || x + CONSTANTS.HIT_WALL_MAX_VALUE > w ||
            0 > y - CONSTANTS.HIT_WALL_MAX_VALUE || y + CONSTANTS.HIT_WALL_MIN_VALUE > h) {
            return true;
        }

        return false;
    }

    function isHitSnakeMember(x, y, snake) {
        var i,
            len,
            currentMember;

        for (i = 1, len = snake.tail.length; i < len; i += 1) {

            currentMember = snake.tail[i];

            if (currentMember.x === x && currentMember.y === y) {

                return true;
            }
        }

        return false
    }

    function getRandom(endRange) {
        return (Math.random() * endRange) | 0;
    }

    function collisionWindowSides(snake) {
        var head = snake.tail[snake.head];

        if (isHitWall(head.x, head.y) || isHitSnakeMember(head.x, head.y, snake)) {
            snake.isAlive = false;
        }
    }

    function collisionFood(snake) {
        var appleIndented,
            head,
            foodX,
            foodY;

        head = snake.tail[snake.head];
        appleIndented = snake.tail[0].radius / 2;

        if ((head.x >= food.x - appleIndented) && (food.x + food.size + appleIndented) >= head.x &&
            (head.y >= food.y - appleIndented) && (food.y + food.size + appleIndented) >= head.y) {

            snake.foodEaten += 1;
            foodX = getRandom(w - foodSize);
            foodY = getRandom(h - foodSize);

            while (checkValidFoodPosition(foodX, foodY, snake, appleIndented, food.size)) {
                foodX = getRandom(w - foodSize);
                foodY = getRandom(h - foodSize);
            }

            food = Object.create(food).init(foodX, foodY);
        }
        else {
            snake.removeSnakeNode();
        }
    }

    function checkValidFoodPosition(x, y, snake, appleIndented, foodSize) {
        snake.tail.some(function (tailMember) {
            return (x >= tailMember.x - appleIndented * 2 - foodSize) && (tailMember.x + foodSize + appleIndented * 2) >= x &&
                (y >= tailMember.y - appleIndented * 2 - foodSize) && (tailMember.y + foodSize + appleIndented * 2) >= y
        });
    }

    function handleUserControl() {
        document.onkeydown = checkKey;
        function checkKey(e) {

            e = e || window.event;

            if (e.keyCode == CONSTANTS.UP_ARROW) {
                if (snake.direction !== 'down') {
                    snake.direction = 'up';
                }
            } else if (e.keyCode == CONSTANTS.DOWN_ARROW) {
                if (snake.direction !== 'up') {
                    snake.direction = 'down';
                }
            } else if (e.keyCode == CONSTANTS.LEFT_ARROW) {
                if (snake.direction !== 'right') {
                    snake.direction = 'left';
                }
            } else if (e.keyCode == CONSTANTS.RIGHT_ARROW) {
                if (snake.direction !== 'left') {
                    snake.direction = 'right';
                }
            }
        }
    }

    function levelController(snake) {
        if (snake.foodEaten === (CONSTANTS.LEVEL_UPDATE * level) && snake.speed > CONSTANTS.SPEED_UPDATE) {
            snake.speed -= CONSTANTS.SPEED_UPDATE;
            level += 1;
        }
    }

    function animation() {
        if (snake.isAlive) {
            snake.move();
            collisionWindowSides(snake, canvasContext, w, h);
            render.drawGameField(w, h, canvasContext);
            render.drawFoodAndStone(food, canvasContext);
            render.drawSnake(snake, canvasContext);
            handleUserControl(game);
            collisionFood(snake);
            levelController(snake);
        } else {
            stopGame();
        }
    }

    function stopGame() {
        clearInterval(gameRun);
        render.drawGameOver(w, h, canvasContext, snake);

    }

    Object.defineProperty(game, 'stop', {
        value: function () {
            stopGame();
        }
    });

    Object.defineProperty(game, 'start', {
        value: function () {
            gameRun = setInterval(animation, snake.speed);
        }
    });

    return game;
}());
