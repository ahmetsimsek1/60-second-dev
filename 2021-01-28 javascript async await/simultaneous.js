var verifyOdd = require("./verify-odd");

verifyOdd(3)
    .then(msg => console.log(msg))
    .catch(msg => console.error(msg));

verifyOdd(4)
    .then(msg => console.log(msg))
    .catch(msg => console.error(msg));
