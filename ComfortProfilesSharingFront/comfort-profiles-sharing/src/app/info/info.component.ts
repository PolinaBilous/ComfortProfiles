import { Component, OnInit } from '@angular/core';
import { StaticInfo } from 'src/logic/static-info.model';
import { ActivatedRoute } from '@angular/router';
import { Service } from 'src/logic/service.service';
import { UserResponse } from 'src/logic/user-response.model';
import * as $ from 'jquery';
import { WaterType } from 'src/logic/water-type.model';
import { MattressType } from 'src/logic/mattress-type.model';
import { TableType } from 'src/logic/table-type.model';
import { ChairType } from 'src/logic/chair-type.model';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  appUserId: string = "";
  staticInfo : StaticInfo;
  user : UserResponse;
  numbers : Number[] = [];
  chairTypes : ChairType[] = [];
  tableTypes : TableType[] = [];
  musicGenres : string[] = ["Alternative Music", "Blues", "Classical Music", "Country Music", "Dance Music", "Easy Listening", "Electronic Music",
                            "European Music (Folk / Pop)", "Hip Hop / Rap", "Indie Pop", "Asian Pop (J-Pop, K-pop)", "Jazz", "Latin Music", 
                            "New Age", "Opera", "Pop (Popular music)", "R&B / Soul", "Reggae", "Rock", "Singer / Songwriter (inc. Folk)", "World Music / Beats"];
  mattressTypes : MattressType[] = [];
  waterTypes : WaterType[] = [];
  currentShoeSize : any;
  currentClothingSize : any;
  currentChairType : any;
  currentTableType : any;
  currentCoffee : any;
  currentTea : any;
  currentAllergens : any;
  currentFruits : any;
  currentMusic : string[];
  currentMattress : any;
  currentWater : any;

  constructor(private activeRoute : ActivatedRoute, private service: Service, public snackBar: MatSnackBar) { 
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
      this.service.getUser(this.appUserId).subscribe(result => {
        this.user = result;
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
      this.service.getStaticInfo(this.appUserId).subscribe(result => {
        this.staticInfo = result;
        this.currentShoeSize = (result as any).shoeSize;
        this.currentClothingSize = (result as any).clothingSize;
        this.currentChairType = (result as any).chairTypeId;
        this.currentTableType = (result as any).tableTypeId;
        this.currentAllergens = (result as any).allergens;
        this.currentCoffee = (result as any).kindOfCoffee;
        this.currentTea = (result as any).kindOfTea;
        this.currentMattress = (result as any).mattressTypeId;
        this.currentWater = (result as any).waterTypeId;
        this.currentFruits = (result as any).fruitPreferences;
        this.currentMusic = [];
        (result as any).musicalPreferences.substring(23).split(',').forEach(element => {
          this.currentMusic.push(element);
        });

        $(document).ready(function(){
          $(".mat-step-label").css("font-size", "15px");
          $(".mat-step-label").css("font-family", "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif");
          $(".mat-vertical-stepper-header.mat-step-header").css("height", "20px");
          $(".mat-vertical-stepper-header.mat-step-header").css("padding", "18px");
          $(".mat-vertical-stepper-header.mat-step-header").css("padding-left", "0px");
          $(".mat-vertical-content-container.mat-stepper-vertical-line").css("margin-left", "12px");
          $("mat-vertical-stepper").children().last().hide();
          $(".mat-vertical-content").css("padding-bottom",  "10px");
        });
      });
    });
  }

  ngOnInit() {
  }

  onUpdate(){    let staticInfo: StaticInfo = new StaticInfo();
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

    this.service.updateStaticInfo(staticInfo).subscribe(result => {
      if (result == null){
        this.snackBar.open("Your information updated!", "Close", {
          duration: 2000,
        });
      }
    });
  }

}
