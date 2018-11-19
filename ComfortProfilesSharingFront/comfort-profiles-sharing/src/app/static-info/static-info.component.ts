import { Component, OnInit } from '@angular/core';
import { ChairType } from 'src/logic/chair-type.model';
import { Service } from 'src/logic/service.service';
import { TableType } from 'src/logic/table-type.model';
import { MattressType } from 'src/logic/mattress-type.model';
import { WaterType } from 'src/logic/water-type.model';
import * as $ from 'jquery';
import { ActivatedRoute, Router } from '@angular/router';
import { StaticInfo } from 'src/logic/static-info.model';

@Component({
  selector: 'app-static-info',
  templateUrl: './static-info.component.html',
  styleUrls: ['./static-info.component.css']
})
export class StaticInfoComponent implements OnInit {

  numbers : Number[] = [];
  chairTypes : ChairType[] = [];
  tableTypes : TableType[] = [];
  musicGenres : string[] = ["Alternative Music", "Blues", "Classical Music", "Country Music", "Dance Music", "Easy Listening", "Electronic Music",
                            "European Music (Folk / Pop)", "Hip Hop / Rap", "Indie Pop", "Asian Pop (J-Pop, K-pop)", "Jazz", "Latin Music", 
                            "New Age", "Opera", "Pop (Popular music)", "R&B / Soul", "Reggae", "Rock", "Singer / Songwriter (inc. Folk)", "World Music / Beats"];
  mattressTypes : MattressType[] = [];
  waterTypes : WaterType[] = [];
  appUserId = "";

  currentShoeSize : any;
  currentClothingSize : any;
  currentChairType : any;
  currentTableType : any;
  currentCoffee : any;
  currentTea : any;
  currentAllergens : any;
  currentFruits : any;
  currentMusic : any;
  currentMattress : any;
  currentWater : any;
  temperature : any;

  constructor(private service: Service, private activeRoute: ActivatedRoute, private router: Router) { 
    this.activeRoute.queryParams.subscribe(params => {
        this.appUserId = this.activeRoute.snapshot.params.id;
    });

    for (let i = 30; i <= 50; i++){
      this.numbers.push(i);
    }
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
  }

  ngOnInit() {
    $(document).ready(function(){
      alert(123);
      $(".mat-step-label").css("font-size", "15px");
      $(".mat-step-label").css("font-family", "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif");
      $(".mat-vertical-stepper-header.mat-step-header").css("height", "20px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding", "18px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding-left", "0px");
      $(".mat-vertical-content-container.mat-stepper-vertical-line").css("margin-left", "12px")
      $("mat-vertical-stepper").children().last().hide();
    });
  }

  onContinue(){
    let staticInfo: StaticInfo = new StaticInfo();
    if (this.currentShoeSize !== undefined)
      staticInfo.ShoeSize = this.currentShoeSize;
    if (this.currentClothingSize !== undefined)
      staticInfo.ClothingSize = this.currentClothingSize;
    if (this.currentChairType !== undefined)
      staticInfo.ChairTypeId = this.currentChairType;
    if (this.currentTableType !== undefined)
      staticInfo.TableTypeId = this.currentTableType;
    if (this.currentCoffee !== undefined)
      staticInfo.KindOfCoffee = this.currentCoffee;
    if (this.currentTea !== undefined)
      staticInfo.KindOfTea = this.currentTea;
    if (this.currentAllergens !== undefined)
      staticInfo.Allergens = this.currentAllergens;
    if (this.currentFruits !== undefined)
      staticInfo.FruitPreferences = this.currentFruits;
    if (this.currentMusic !== undefined)
      staticInfo.MusicalPreferences = "Favourite music genres:" + this.currentMusic.join(',');
    if (this.currentWater !== undefined)
      staticInfo.WaterTypeId = this.currentWater;
    if (this.currentMattress !== undefined)
      staticInfo.MattressTypeId = this.currentMattress;
    staticInfo.UserId = this.appUserId;

    console.log(staticInfo.WaterTypeId);

    this.service.addCoffeDevice(this.appUserId).subscribe(result => console.log(result));
    this.service.addTeapot(this.temperature, this.appUserId).subscribe(result => console.log(result));

    this.service.addStaticInfo(staticInfo).subscribe(result => {
      this.router.navigate(['/add-rooms', this.appUserId]);
    });
  }
}
