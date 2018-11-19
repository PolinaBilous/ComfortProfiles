import { ComfortProfileRoom } from "./comfort-profile-room";
import { CoffeeType } from "./coffee-type.model";
import { PreferableCoffeeTime } from "./pref-coffee-time.model";
import { PreferableTeaTimes } from "./pref-tea-time.model";

export class ComfortProfile{
    public userId : string;
    public shoeSize : number;
    public clothingSize : number;
    public chairTypeId : number;
    public tableTypeId : number;
    public mattressTypeId : number;
    public waterTypeId : number;
    public allergens : string;
    public kindOfTea : string;
    public kindOfCoffee : string;
    public musicalPreferences : string;
    public fruitPreferences : string;
    public comfortTeapotTemperature : number;
    public preferableRoomsIndicators : Array<ComfortProfileRoom>;
    public favoriteCoffeeTypes : Array<CoffeeType>;
    public preferableCoffeeTimes: Array<PreferableCoffeeTime>;
    public preferableTeaTimes: Array<PreferableTeaTimes>
}