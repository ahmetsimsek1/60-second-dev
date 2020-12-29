export default class Car {
    constructor(private model: string) {}
    drive() {console.log(`${this.model} goes vroom`);}
}