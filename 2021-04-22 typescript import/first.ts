export default class Person {
    id: number;
    name: string;

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }

    hello(): void {
        console.log(`Hello ${this.name}, you are person ID ${this.id}`);
    }
}
