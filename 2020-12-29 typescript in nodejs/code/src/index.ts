import Car from "./car";
import isOdd from "is-odd";

(() => {
    const car = new Car("Mustang");
    car.drive();

    console.log(`Is 3 odd? ${isOdd(3)}`);
})();