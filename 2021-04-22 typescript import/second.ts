export class Car {
    make: string;
    model: string;
    constructor(make: string, model: string) { this.make = make; this.model = model; }
    go(): void {
        console.log(`${this.make} ${this.model} goes vroom`);
    }
}

export class Shoe {
    size: number;
    style: string;
    constructor(size: number, style: string) { this.size = size; this.style = style; }
    run(): void {
        console.log(`My size ${this.size} ${this.style} shoe is running`);
    }
}

export function kickCar(shoe: Shoe, car: Car): void {
    console.log(`A size ${shoe.size} ${shoe.style} shoe just kicked the ${car.make} ${car.model}`);
}
