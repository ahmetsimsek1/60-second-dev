class Foo {
    constructor(id) { this._id = id || 0; }
    get ID() { return this._id; }
    set ID(value) { this._id = value * 100; } // Don't do this
}

const foo = new Foo(1);
console.log(foo.ID); 1
++foo.ID;
console.log(foo.ID); // 200
++foo.ID;
console.log(foo.ID); // 20100
++foo.ID;
console.log(foo.ID); // 2010100
++foo.ID;
console.log(foo.ID); // 201010100
