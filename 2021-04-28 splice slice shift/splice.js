let arr = [ 1, 2, 3, 4 ];

// To delete items from the array: arr.splice(position, numToDelete)
let deletedItems = arr.splice(2, 1); // removes one item, starting at position 2 (zero-based)
console.log(arr); // [ 1, 2, 4 ]
console.log(deletedItems); // [ 3 ]

arr = [ 1, 2, 3, 4 ];

// To insert items: arr.splice(position, numToDelete=0, itemToAdd, anotherItemToAdd...)
deletedItems = arr.splice(1, 0, 98, 99);
console.log(arr); // [1, 98, 99, 2, 3, 4 ]
console.log(deletedItems); // []

arr = [ 1, 2, 3, 4 ];

// To both insert and delete:
deletedItems = arr.splice(1, 1, 99);
console.log(arr); // [ 1, 99, 3, 4 ]
console.log(deletedItems); // [ 2 ]

arr = [ 1, 2, 3, 4 ];

// Act like a queue, clearing out the array one item at a time, FIFO:
// Works on records in order: 1, 2, 3, 4
while (arr.length) {
    deletedItems = arr.splice(0, 1);
    console.log(`Working on record ${deletedItems[0]}`);
}

arr = [ 1, 2, 3, 4 ];

// Act like a stack, clearing out the array one item at a time, LIFO:
// Works on records in order: 4, 3, 2, 1
while (arr.length) {
    deletedItems = arr.splice(arr.length - 1, 1);
    console.log(`Working on record ${deletedItems[0]}`);
}
