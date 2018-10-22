export class User{
    constructor(obj?: any) {
        Object.assign(this, obj);
    }

    public Id : string;
    public Email : string;
    public Name : string;
}