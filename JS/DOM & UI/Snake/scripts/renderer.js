var renderer = (function () {

    var renderer = Object.create({});

    Object.defineProperty(renderer, 'drawSnake', {
        value: function (snake, canvasContext) {
            snake.tail.forEach(function (tailMember) {

                var x = tailMember.x,
                    y = tailMember.y;

                canvasContext.beginPath();
                canvasContext.arc(x, y, 10, 0, 2 * Math.PI, true);
                canvasContext.fillStyle = tailMember.color;
                canvasContext.strokeStyle = 'black';
                canvasContext.fill();
                canvasContext.stroke();
                canvasContext.closePath();
            });
        }
    });

    Object.defineProperty(renderer, 'drawGameField', {
        value: function (x, y, width, height, canvasContext) {
            canvasContext.lineWidth = '1';
            canvasContext.fillStyle = '#1DE1D3';
            canvasContext.fillRect(x, y, width - x - 1, height - y - 1);
            canvasContext.strokeRect(x, y, width - x - 1, height - y - 1);
        }
    });

    Object.defineProperty(renderer, 'drawFoodAndStone', {
        value: function (object, canvasContext) {
            canvasContext.drawImage(object.image, object.x, object.y);
        }
    });

    Object.defineProperty(renderer, 'clearCanvas', {
        value: function (w, h, canvasContext) {
            canvasContext.clearRect(0, 0, w, h);
        }
    });

    Object.defineProperty(renderer, 'drawGameOver', {
        value: function (w, h, canvasContext, snake) {
            var gameOverText = 'GAME OVER ';
            var scoreText = 'SCORE: ' + snake.foodEaten;
            canvasContext.font = '55px Arial';
            canvasContext.fillText(gameOverText, ( (w / 3) + gameOverText.length), h / 2);
            canvasContext.strokeText(gameOverText, ( (w / 3) + gameOverText.length), h / 2);
            canvasContext.fillText(scoreText, ( (w / 3) + scoreText.length * 7), (h / 2 + 70));
            canvasContext.strokeText(scoreText, ( (w / 3) + scoreText.length * 7), (h / 2 + 70));
        }
    });


    return renderer;
}());