module.exports = function verifyOdd(num) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (num % 2) {
                resolve(`${num} is odd`);
            } else {
                reject(`ERROR: ${num} is even`);
            }
        }, 2000);
    });
};
