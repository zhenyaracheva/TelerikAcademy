function oddOrEven (number) {
    var num = parseInt(number);

    if(num%2 === 0){
        console.log( num +' is even');
    } else {
        console.log(num+ ' is odd');
    }
}

oddOrEven(3);
oddOrEven(2);
oddOrEven(-2);
oddOrEven(-1);
oddOrEven(0);
