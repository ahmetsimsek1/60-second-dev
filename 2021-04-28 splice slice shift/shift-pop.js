let arr = [ 1, 2, 3, 4 ];

// Queue: FIFO (1, 2, 3, 4)
while (arr.length) {
    let item = arr.shift();
    console.log(`Working on item ${item}`);
}

arr = [ 1, 2, 3, 4 ];

// Stack: LIFO (4, 3, 2, 1)
while (arr.length) {
    let item = arr.pop();
    console.log(`Working on item ${item}`);
}
