console.log("This should always log");
console.table([
    { id: 1, name: "Sharks" },
    { id: 2, name: "Jets" }
], ["id", "name"]);

console.logVerbose("This only logs if verbose is turned on");
