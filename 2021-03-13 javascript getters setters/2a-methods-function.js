const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' });

function Product(id, name, price) {
    this.getID = function() { return this._id; }
    this.setID = function(id) { this._id = id * 100; }
    this.getName = function() { return this._name.toUpperCase(); }
    this.setName = function(name) { this._name = name; }
    this.getPrice = function() { return formatter.format(this._price); }
    this.setPrice = function(price) { this._price = price; }

    this.setID(id);
    this.setName(name);
    this.setPrice(price);
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
