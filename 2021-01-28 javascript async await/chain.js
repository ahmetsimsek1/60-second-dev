const verifyOdd = require("./verify-odd");

verifyOdd(3)
    .then(msg => console.log(msg))
    .catch(msg => console.error(msg))
    .then(() => verifyOdd(4))
    .then(msg => console.log(msg))
    .catch(msg => console.error(msg));
