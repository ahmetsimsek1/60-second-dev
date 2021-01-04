// const arr = ["a", "b", "c"];
// const newArr = arr.map(x => x.toUpperCase());
// console.log(newArr);

// const arr = ["a", "b", "c"];
// const newArr = arr.map((elem, idx, arr) => `${idx}: ${elem} (${arr.length} total)`);
// console.log(newArr);

function handleClick() {
    return `${this.id} clicked the button`;
}

const arr = ["a", "b", "c"];
const thisArg = { id: "something" };
const newArr = arr.map(handleClick, thisArg);
console.log(newArr);
