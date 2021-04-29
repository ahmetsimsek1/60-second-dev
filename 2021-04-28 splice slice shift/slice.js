let arr = [ 1, 2, 3, 4 ];

// Shallow copy of entire array: no parameters
let newArr = arr.slice();

console.log(arr); // [ 1, 2, 3, 4 ]
console.log(newArr); // [ 1, 2, 3, 4 ]

// Pull items from the middle: arr.slice(startInclusive, endExclusive):
newArr = arr.slice(1, 2);
console.log(newArr); // [ 2 ]

// Pull the last N items:
newArr = arr.slice(-3);
console.log(newArr); // [ 2, 3, 4 ]

// Shallow copy:
arr = [{a: 1}];
newArr = arr.slice();
newArr[0].a = 2;
console.log(arr); [ { a: 2 }];
console.log(newArr); [ { a: 2 }];
