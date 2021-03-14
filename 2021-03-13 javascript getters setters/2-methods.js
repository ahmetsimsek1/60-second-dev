const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' });

class Product {
    constructor(id, name, price) {
        this.setID(id);
        this.setName(name);
        this.setPrice(price);
    }

    getID() { return this._id; }
    setID(id) { this._id = id * 100; }
    getName() { return this._name.toUpperCase(); }
    setName(name) { this._name = name; }
    getPrice() { return formatter.format(this._price); }
    setPrice(price) { this._price = price; }
}

const product = new Product(1, "Oreos", 2.49);
console.log(product.getID());
console.log(product.getName());
console.log(product.getPrice());
console.log("Applying changes...");
product.setID(2);
product.setName("Oreo Cookies");
product.setPrice(3.49);
console.log(product.getID());
console.log(product.getName());
console.log(product.getPrice());
