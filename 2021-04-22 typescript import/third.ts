export class Tablet {
    operatingSystem: string;
    size: number;
    constructor(operatingSystem: string, size: number) {
        this.operatingSystem = operatingSystem;
        this.size = size;
    }
}

export function showTablet(tablet: Tablet) {
    console.log(`This is a ${tablet.size} inch tablet with ${tablet.operatingSystem}`);
}