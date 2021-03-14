function Product(id, name, price) {
    this.id = id;
    this.name = name;
    this.price = price;
}

const product = new Product(1, "Oreos", 2.49);
console.log(product.id);
console.log(product.name);
console.log(product.price);
console.log("Applying changes...");
product.id = 2;
product.name = "Oreo Cookies";
product.price = 3.49;
console.log(product.id);
console.log(product.name);
console.log(product.price);
