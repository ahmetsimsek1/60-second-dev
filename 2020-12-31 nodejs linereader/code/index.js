const lineReader = require("readline").createInterface({
    input: require("fs").createReadStream("data.txt")
});

const cities = new Set();
lineReader.on("line", line => {
    const fields = line.split("\t");
    const city = fields[4];
    cities.add(city);
});

lineReader.on("close", () => {
    const arr = [...cities];
    arr.sort();
    console.log(arr.join(", "));
});
