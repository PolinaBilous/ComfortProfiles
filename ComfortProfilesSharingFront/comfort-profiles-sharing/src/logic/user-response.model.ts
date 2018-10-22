import { User } from "./User.model";

export class UserResponse {
    constructor(obj?: any) {
        Object.assign(this, obj);
    }

    public message: string;
    public appUser: User;
}