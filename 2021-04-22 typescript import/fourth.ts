export default class Account {
  id: number;
  balance: number;
  constructor(id: number, balance: number) {
    this.id = id;
    this.balance = balance;
  }
}

export class Customer {
    name: string;
    constructor(name: string) { this.name = name; }
}
