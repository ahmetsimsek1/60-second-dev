const verifyOdd = require("./verify-odd");

(async function() {
    try {
        console.log(await verifyOdd(3));
    } catch (ex) {
        console.log(ex);
    }
    try {
        console.log(await verifyOdd(4));
    } catch (ex) {
        console.log(ex);
    }
})();
