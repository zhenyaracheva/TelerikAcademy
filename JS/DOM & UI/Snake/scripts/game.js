var game = (function () {
    var canvas,
        canvasContext,
        food,
        foodSize,
        game,
        gameRun,
        gameFieldHeight,
        level,
        render,
        snake,
        gameFieldWidth,
        CONSTANTS = {
            HIT_WALL_MIN_VALUE: 5,
            HIT_WALL_MAX_VALUE: 10,
            LEFT_ARROW: 37,
            UP_ARROW: 38,
            RIGHT_ARROW: 39,
            DOWN_ARROW: 40,
            SPEED_UPDATE: 10,
            LEVEL_UPDATE: 5,
            WIDTH: (3 * window.innerWidth / 4) + 10,
            HEIGHT: window.innerHeight - 37,
            START_CANVAS_X: 6,
            START_CANVAS_Y: 7
        };


    canvas = document.getElementById('canvas');
    canvasContext = canvas.getContext('2d');
    game = Object.create({});
    foodSize = Object.create(gameObjects.food).init().size;
    gameFieldHeight = CONSTANTS.HEIGHT;
    gameFieldWidth = CONSTANTS.WIDTH;
    food = Object.create(gameObjects.food).init(getRandom(CONSTANTS.START_CANVAS_X, gameFieldWidth - foodSize), getRandom(CONSTANTS.START_CANVAS_Y, gameFieldHeight - foodSize));
    level = 1;
    render = Object.create(renderer);
    snake = Object.create(gameObjects.snake).init();

    canvas.height = CONSTANTS.HEIGHT;
    canvas.width = CONSTANTS.WIDTH;

    function isHitWall(x, y) {
        if (0 > x - CONSTANTS.START_CANVAS_X || x + CONSTANTS.HIT_WALL_MAX_VALUE > canvas.width ||
            0 > y - CONSTANTS.HIT_WALL_MAX_VALUE || y + CONSTANTS.HIT_WALL_MIN_VALUE > canvas.height) {
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

    function getRandom(startRange, endRange) {
        return (Math.random() * (endRange - startRange + 1) + startRange) | 0;
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
            foodY,
            foodSize;

        head = snake.tail[snake.head];
        appleIndented = snake.tail[0].radius;
        foodSize = food.size / 2;

        // first try
        //if ((head.x >= food.x - appleIndented) && (food.x + food.size + appleIndented) >= head.x &&
        //    (head.y >= food.y - appleIndented) && (food.y + food.size + appleIndented) >= head.y) {

        if ((head.x >= food.x ) && (food.x + food.size ) >= head.x &&
            (head.y >= food.y ) && (food.y + food.size ) >= head.y) {

            snake.foodEaten += 1;
            foodX = getRandom(CONSTANTS.START_CANVAS_X, gameFieldWidth - foodSize * 2);
            foodY = getRandom(CONSTANTS.START_CANVAS_Y, gameFieldHeight - foodSize * 2);

            while (checkValidFoodPosition(foodX, foodY, snake, appleIndented, food.size)) {
                foodX = getRandom(CONSTANTS.START_CANVAS_X, gameFieldWidth - foodSize);
                foodY = getRandom(CONSTANTS.START_CANVAS_Y, gameFieldHeight - foodSize);
            }

            food = Object.create(food).init(foodX, foodY);
        }
        else {
            snake.removeSnakeNode();
        }
    }

    function checkValidFoodPosition(foodX, foodY, snake, foodSize) {
        snake.tail.some(function (tailMember) {
            return (foodX > tailMember.x ) && foodX < (tailMember.x + foodSize) &&
                (foodY > tailMember.y ) && foodY < tailMember.y + foodSize;
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
            render.drawGameField(CONSTANTS.START_CANVAS_X, CONSTANTS.START_CANVAS_Y, canvas.width, canvas.height, canvasContext);
            snake.move();
            render.drawFoodAndStone(food, canvasContext);
            render.drawSnake(snake, canvasContext);
            collisionWindowSides(snake, canvasContext, gameFieldWidth, gameFieldHeight);
            handleUserControl(game);
            collisionFood(snake);
            levelController(snake);

        } else {
            stopGame();
        }
    }

    function stopGame() {
        clearInterval(gameRun);
        render.drawGameOver(canvas.width, canvas.height, canvasContext, snake);

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
