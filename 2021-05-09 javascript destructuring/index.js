// Object destructuring:
const phone = { brand: "Apple", phoneModel: "iPhone 14S" };

const { brand, phoneModel } = phone;
console.log(brand); // Apple
console.log(phoneModel); // iPhone 14S

// Array destructuring
const scores = [75, 80, 85];

const [a, b] = scores; // First two, third is ignored
console.log(a); // 75
console.log(b); // 80

// Rest
const car = { make: "Chevy", model: "Corvette", year: 2012, color: "Red" };
const { make, model, ...features } = car;
console.log(make); // Chevy
console.log(model); // Corvette
console.log(features); // { year: 2012, color: "Red" }

// Rest for array
const choices = ["beef", "tofu", "salad", "turkey"];
const [first, second, ...others] = choices;
console.log(first); // beef
console.log(second); // tofu
console.log(others); // ["salad", "turkey"]

// Different names
const teams = {
  football: "Cardinals",
  baseball: "Diamondbacks",
  hockey: "Coyotes",
  basketball: "Suns",
};

const {
  football: gridiron,
  baseball: diamond,
  hockey: icePunching,
  basketball: hoops,
} = teams;

console.log(gridiron); // Cardinals
console.log(diamond); // Diamondbacks
console.log(icePunching); // Coyotes
console.log(hoops); // Suns

// See docs for more uses: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Destructuring_assignment
