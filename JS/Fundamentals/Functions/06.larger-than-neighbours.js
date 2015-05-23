function largerThanNeighbours(array, position){

    if(position< array.length){
        if(position===0){
            return array[position]>array[position+1]? 'True': 'False';
        } else if (position===array.length-1){
            return array[position]> array[position-1]? 'True': 'False';
        } else{
            return array[position]> array[position-1]&& array[position]>array[position+1]? 'True': 'False';
        }
    } else {
        return 'wrong position';
    }
}

console.log(largerThanNeighbours([1,20,1053,49,75,69,78,50,10,0],5));
console.log(largerThanNeighbours([1,20,1053,49,75,69,78,50,10,0],50));
console.log(largerThanNeighbours([100,20,1053,49,75,69,78,50,10,0],0));
console.log(largerThanNeighbours([0,20,1053,49,75,69,78,50,10,0],0));
console.log(largerThanNeighbours([1,20,1053,49,75,69,78,50,10,777],9));
console.log(largerThanNeighbours([1,20,1053,49,75,69,78,50,10,7],9));
console.log(largerThanNeighbours([1,20,1053,49,75,69,78,50,10,0],2));