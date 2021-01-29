const verifyOdd = require("./verify-odd");

async function go() {
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
}

// treat go() as a regular promise
go().then(() => {
    console.log("go is done");
});
