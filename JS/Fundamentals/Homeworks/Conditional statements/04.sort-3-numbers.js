function sort3Numbers (a,b,c) {
    var result;
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);

    if(a >= b && a >= c){
        result= a + ' ';

        if(b > c) {
            result += b+ ' '+ c;

        } else {
            result  += c + ' '+ b;
        }
    }else if(b >= a && b >= c){

        result = b + ' ';

        if(a > c) {
            result += a+ ' '+ c;

        } else {
            result  += c + ' '+ a;
        }
    }else if(c >= b && c >= a){

        result = c + ' ';

        if(b > a) {
            result += b+ ' '+ a;

        } else {
            result  += a + ' '+ b;
        }
    }

    return result;
}

console.log(sort3Numbers(5,1,2));
console.log(sort3Numbers(-2,-2,1));
console.log(sort3Numbers(-2,4,3));
console.log(sort3Numbers(0,-2.5,5));
console.log(sort3Numbers(-1.1,-0.5,-0.1));
console.log(sort3Numbers(10,20,30));
console.log(sort3Numbers(1,1,1));