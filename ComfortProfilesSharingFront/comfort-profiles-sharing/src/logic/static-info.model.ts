export class StaticInfo {
    constructor(obj?: any) {
        Object.assign(this, obj);
    }

    public UserId : string;

    public ShoeSize : number;
    public ClothingSize : number;
    public Allergens : string;
    public KindOfTea : string;
    public KindOfCoffee : string;
    public MusicalPreferences : string;
    public FruitPreferences : string; 

    public ChairTypeId : number;
    public TableTypeId : number;
    public MattressTypeId : number; 
    public WaterTypeId : number;
}