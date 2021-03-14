const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' });

class Product {
    constructor(id, name, price) {
        this.id = id;
        this.name = name;
        this.price = price;
        this._timesNameChanged = 0;
    }

    get id() { return this._id; }
    set id(value) { this._id = value * 100; }

    get name() { return this._name.toUpperCase(); }
    set name(value) { this._name = value; ++this._timesNameChanged; }
    
    get price() { return formatter.format(this._price); }
    set price(value) { this._price = value; }

    get timesNameChanged() { return this._timesNameChanged; }
}

const product = new Product(1, "Oreos", 2.49);
console.log(`ID: ${product.id}`);
console.log(product.name);
console.log(product.price);
console.log(`Name changed ${product.timesNameChanged} times`);
console.log("Applying changes...");
product.id = 2;
product.name = "Oreo Cookies";
product.price = 3.49;
console.log(`ID: ${product.id}`);
console.log(product.name);
console.log(product.price);
console.log(`Name changed ${product.timesNameChanged} times`);
