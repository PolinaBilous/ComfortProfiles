export class CoffeeDeviceState{
    constructor(obj?: any) {
        Object.assign(this, obj);
    }

    CurrentWaterAmount : number;
    CurrentMilkAmount : number;
    CurrentCoffeeAmount  : number;
}