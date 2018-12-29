import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/logic/service.service';
import { Ng2Highcharts } from 'ng2-highcharts';
import * as Highcharts from "highcharts";
window['Highcharts'] = Highcharts;

@Component({
  selector: 'app-comfort-profile',
  templateUrl: './comfort-profile.component.html',
  styleUrls: ['./comfort-profile.component.css']
})
export class ComfortProfileComponent implements OnInit {

  appUserId;
  comfortProfile;
  currentShoeSize: any;
  currentClothingSize: any;
  allergens: any;
  musicalPreferencesTitle: any;
  musicalPreferences: any;
  fruitPreferences: any;
  tableTypes: import("c:/Users/Polina/source/repos/ComfortProfiles/ComfortProfilesSharingFront/comfort-profiles-sharing/src/logic/table-type.model").TableType[];
  chairTypes: import("c:/Users/Polina/source/repos/ComfortProfiles/ComfortProfilesSharingFront/comfort-profiles-sharing/src/logic/chair-type.model").ChairType[];
  mattressTypes: import("c:/Users/Polina/source/repos/ComfortProfiles/ComfortProfilesSharingFront/comfort-profiles-sharing/src/logic/mattress-type.model").MattressType[];
  waterTypes: import("c:/Users/Polina/source/repos/ComfortProfiles/ComfortProfilesSharingFront/comfort-profiles-sharing/src/logic/water-type.model").WaterType[];
  preferableWaterType: any;
  preferableMattressType: any;
  preferableChairType: any;
  preferableTableType: any;
  preferableRoomsIndicators: any;
  comfortTeapotTemperature: any;
  kindOfTea: any;
  preferableTeaTimes: any;
  chartData;
  preferableCoffeeTypes: any;
  preferableCoffeeTimes: any;
  constructor(private activeRoute : ActivatedRoute, private router : Router, private service : Service) { 
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
    });
    this.service.getTableTypes().subscribe(result => {
      this.tableTypes = result;
    });
    this.service.getChairTypes().subscribe(result => {
      this.chairTypes = result;
    });
    this.service.getMattressTypes().subscribe(result => {
      this.mattressTypes = result;
    });
    this.service.getWaterTypes().subscribe(result => {
      this.waterTypes = result;
    });

    this.service.getComfortProfile(this.appUserId).subscribe(result => {
      this.currentShoeSize = (result as any).comfortProfile.shoeSize;
      this.currentClothingSize = (result as any).comfortProfile.clothingSize;
      this.allergens = (result as any).comfortProfile.allergens;
      var musicalPreferencesString = (result as any).comfortProfile.musicalPreferences;
      var musicStrings = musicalPreferencesString.split(':');
      this.musicalPreferences = musicStrings[1];
      this.musicalPreferencesTitle = musicStrings[0];
      this.fruitPreferences = (result as any).comfortProfile.fruitPreferences;
      this.comfortTeapotTemperature = (result as any).comfortProfile.comfortTeapotTemperature;
      this.kindOfTea = (result as any).comfortProfile.kindOfTea;
      this.service.getWaterTypes().subscribe(waterResult => {
        this.preferableWaterType = (waterResult.find(elem => (elem as any).id == (result as any).comfortProfile.waterTypeId) as any).name;
      });
      this.service.getChairTypes().subscribe(waterResult => {
        this.preferableChairType = (waterResult.find(elem => (elem as any).id == (result as any).comfortProfile.chairTypeId) as any).name;
      });
      this.service.getTableTypes().subscribe(waterResult => {
        this.preferableTableType = (waterResult.find(elem => (elem as any).id == (result as any).comfortProfile.tableTypeId) as any).name;
      });
      this.service.getMattressTypes().subscribe(waterResult => {
        this.preferableMattressType = (waterResult.find(elem => (elem as any).id == (result as any).comfortProfile.mattressTypeId) as any).name;
      });
      
      let teaTimes = (result as any).comfortProfile.preferableTeaTimes;
      teaTimes.forEach(element => {
        this.service.getHowOftens().subscribe(howOftens => {
          let howOftenString = (howOftens.find(elem => (elem as any).id === element.howOftenId) as any).explanation.toLowerCase();
          console.log(howOftenString);
          element.howOftenString = howOftenString;
          element.date = element.date.substring(11, 16);
        })
      });

      let coffeeTimes = (result as any).comfortProfile.preferableCoffeeTimes;
      coffeeTimes.forEach(element => {
        this.service.getHowOftens().subscribe(howOftens => {
          let howOftenString = (howOftens.find(elem => (elem as any).id === element.howOftenId) as any).explanation.toLowerCase();
          element.howOftenString = howOftenString;
          element.date = element.date.substring(11, 16);
          this.service.getCoffeeTypes().subscribe(ct => {
            console.log(ct);
            debugger;
            let ctName = (ct.find(elem => (elem as any).id === element.coffeeTypeId) as any).name.toLowerCase();
            element.coffeeType = ctName;
          });
        })
      });

      console.log(coffeeTimes);

      this.preferableCoffeeTimes = coffeeTimes;
      this.preferableTeaTimes = teaTimes;

      let rooms = (result as any).comfortProfile.preferableRoomsIndicators;
      rooms.forEach(element => {
        if (element.preferableTemperature === null){
          element.preferableTemperature = Math.floor(Math.random() * 60) + 20;
        }
        if (element.preferableAirHumidity === null){
          element.preferableAirHumidity = Math.floor(Math.random() * 30) + 10;
        }
        if (element.preferableLightIntencity === null){
          element.preferableLightIntencity = Math.floor(Math.random() * 40) + 100;
        }
      });

      this.preferableRoomsIndicators = rooms;
      let coffeeSeries = [];

      var favouriteCoffee = (result as any).comfortProfile.favoriteCoffeeTypes; 
      favouriteCoffee.forEach(element => {
          coffeeSeries.push({name: element.name, y:Math.floor(Math.random() * 60) + 20 });
      });


      this.chartData = {
        title: "Favourite Coffee Types",
        chart: {
          type: 'pie',
          height: 200
        },
      series: [{
          data: coffeeSeries
      }]};
    });
  }

  ngOnInit() {
  }

  moveToComfortProfile(){
    this.router.navigate(['/comfort-profile', this.appUserId]);
  }
  moveToInfo(){
    this.router.navigate(['/user-info', this.appUserId]);
  }

  MoveToCoffeeAndTea(){
    this.router.navigate(['/coffee-and-tea', this.appUserId]);
  }

  moveToRooms(){
    this.router.navigate(['/rooms', this.appUserId]);
  }

  moveToInstructions() {
    this.router.navigate(['/instructions', this.appUserId]);
  }

  signOut(){
    this.router.navigate(['/home']);
  }
}
