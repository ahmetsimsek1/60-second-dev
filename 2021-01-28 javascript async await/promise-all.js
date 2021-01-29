const verifyOdd = require("./verify-odd");

const promises = [verifyOdd(3), verifyOdd(4)];
Promise.all(promises)
    .then(function () { console.log(`All promises complete: ${arguments}`); })
    .catch(function () { console.error(`Failure: ${JSON.stringify(arguments)}`); });
