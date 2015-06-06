function appearanceCount(array, element) {
   return array.reduce(function(total,x){return x===element ? total+1 : total}, 0);
}

console.log(appearanceCount([1,2,3,4,1,2,3,1,2,1],1));
console.log(appearanceCount([1,2,3,4,1,2,3,1,2,1],2));
console.log(appearanceCount([1,2,3,4,1,2,3,1,2,1],3));
console.log(appearanceCount([1,2,3,4,1,2,3,1,2,1],4));
console.log(appearanceCount([1,2,3,4,1,2,3,1,2,1],101));