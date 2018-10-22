import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { StaticInfo } from "./static-info.model";
import { environment } from "src/environments/environment";
import { HttpClient } from '@angular/common/http';
import { map, filter, switchMap } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';
import { UserResponse } from "./user-response.model";
import { ChairType } from "./chair-type.model";
import { TableType } from "./table-type.model";
import { WaterType } from "./water-type.model";
import { MattressType } from "./mattress-type.model";
import { CoffeeType } from "./coffee-type.model";
import { HowOften } from "./how-often.model";
import { CoffeeDeviceResponse } from "./coffee-device-response.model";
import { CoffeeDeviceState } from "./coffee-device-state.model";
import { CoffeeLog } from "./coffee-log.model";

@Injectable()
export class Service {
    constructor(private http: HttpClient) { }
    //public appUserId: string = "08a48980-e4a9-4830-92b2-3f691c86f4c1";
    public appUserId: string = "9ae8b797-0961-464b-b20b-ea239e7b14cf";
    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
        })
      };

    getStaticInfo() : Observable<StaticInfo>{
        return this.http.get<StaticInfo>(environment.apiUrl + "/api/StaticInfo/GetStaticInfoForCurrentUser?userId=" + this.appUserId).pipe(map(response => new StaticInfo(response)));
    }

    getTableTypes() : Observable<TableType[]> {
        return this.http.get<TableType[]>(environment.apiUrl + "/api/StaticInfo/GetTableTypes");
    }

    getWaterTypes() : Observable<WaterType[]> {
        return this.http.get<WaterType[]>(environment.apiUrl + "/api/StaticInfo/GetWaterTypes");
    }

    getMattressTypes() : Observable<MattressType[]> {
        return this.http.get<MattressType[]>(environment.apiUrl + "/api/StaticInfo/GetMattressTypes");
    }

    getChairTypes() : Observable<ChairType[]> {
        return this.http.get<ChairType[]>(environment.apiUrl + "/api/StaticInfo/GetChairTypes");
    }

    getCoffeeTypes() : Observable<CoffeeType[]> {
        return this.http.get<CoffeeType[]>(environment.apiUrl + "/api/Coffee/GetCoffeeTypes");
    }

    getHowOftens() : Observable<HowOften[]> {
        return this.http.get<HowOften[]>(environment.apiUrl + "/api/Coffee/GetHowOftens");
    }

    addStaticInfo(staticInfo : StaticInfo) : Observable<Object> {
        staticInfo.UserId = this.appUserId;
        return this.http.post(environment.apiUrl + "api/StaticInfo/AddStaticInfo", staticInfo, this.httpOptions).pipe(map(response => response));
    } 

    updateStaticInfo(staticInfo : StaticInfo) : Observable<Object> {
        staticInfo.UserId = this.appUserId;
        return this.http.post(environment.apiUrl + "api/StaticInfo/UpdateStaticInfo", staticInfo, this.httpOptions).pipe(map(response => response));
    } 

    registerUser(email : string, name : string, password : string) : Observable<UserResponse>{
        let request : string = environment.apiUrl + "/api/User/Register?email=" + email + "&password=" + password + "&name=" + name;
        return this.http.post(request, null, this.httpOptions).pipe(map(response => {
            let userResponse : UserResponse = new UserResponse();
            
            userResponse.message = JSON.parse(JSON.stringify(response)).message;
            userResponse.appUser = JSON.parse(JSON.stringify(response)).appUser;

            if (userResponse.appUser != null)
                this.appUserId = userResponse.appUser.Id;

            return userResponse;
        }));
    }

    loginUser(email : string, password : string) : Observable<UserResponse>{
        let request : string = environment.apiUrl + "/api/User/Login?email=" + email + "&password=" + password;
        return this.http.post(request, null, this.httpOptions).pipe(map(response => {
            let userResponse : UserResponse = new UserResponse();
            
            userResponse.message = JSON.parse(JSON.stringify(response)).message;
            userResponse.appUser = JSON.parse(JSON.stringify(response)).appUser;

            if (userResponse.appUser != null)
                this.appUserId = userResponse.appUser.Id;

            return userResponse;
        }));
    }

    addCoffeDevice() : Observable<CoffeeDeviceResponse>{
        let request : string = environment.apiUrl + "/api/Coffee/AddCoffeeDevice?appUserId=" + this.appUserId;
        return this.http.post(request, null, this.httpOptions).pipe(map(response => {
            let coffeDeviceResponse: CoffeeDeviceResponse = new CoffeeDeviceResponse();

            coffeDeviceResponse.message = JSON.parse(JSON.stringify(response)).message;
            coffeDeviceResponse.coffeDeviceState = JSON.parse(JSON.stringify(response)).coffeDeviceState;

            return coffeDeviceResponse;
        }));
    }

    makeCupOfCoffeeIfNeeded() : Observable<CoffeeDeviceResponse>{
        let request : string = environment.apiUrl + "/api/Coffee/MakeCupOfCoffeeIfNeeded?appUserId=" + this.appUserId;
        return this.http.post(request, null, this.httpOptions).pipe(map(response => {
            let coffeDeviceResponse: CoffeeDeviceResponse = new CoffeeDeviceResponse();

            coffeDeviceResponse.message = JSON.parse(JSON.stringify(response)).message;
            coffeDeviceResponse.coffeDeviceState = JSON.parse(JSON.stringify(response)).coffeDeviceState;

            return coffeDeviceResponse;
        }));
    }

    getCoffeeDeviceState() : Observable<CoffeeDeviceState>{
        return this.http.get<CoffeeDeviceState>(environment.apiUrl + "/api/Coffee/GetCoffeeDeviceState?appUserId=" + this.appUserId);
    }

    makeCupOfCoffee(coffeeLog : CoffeeLog) : Observable<CoffeeDeviceResponse> {
        coffeeLog.AppUserId = this.appUserId;
        return this.http.post(environment.apiUrl + "/api/Coffee/MakeCupOfCoffee", coffeeLog, this.httpOptions).pipe(map(response => {
            let coffeDeviceResponse: CoffeeDeviceResponse = new CoffeeDeviceResponse();

            coffeDeviceResponse.message = JSON.parse(JSON.stringify(response)).message;
            coffeDeviceResponse.coffeDeviceState = JSON.parse(JSON.stringify(response)).coffeDeviceState;

            return coffeDeviceResponse;
        }));
    }

}