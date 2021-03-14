const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' });

function Product(id, name, price) {
    this.setID(id);
    this.setName(name);
    this.setPrice(price);
}

Product.prototype.getID = function() { return this._id; }
Product.prototype.setID = function(id) { this._id = id * 100; }
Product.prototype.getName = function() { return this._name.toUpperCase(); }
Product.prototype.setName = function(name) { this._name = name; }
Product.prototype.getPrice = function() { return formatter.format(this._price); }
Product.prototype.setPrice = function(price) { this._price = price; }

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
