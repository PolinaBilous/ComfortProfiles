import { Component, OnInit } from '@angular/core';
import { ChairType } from 'src/logic/chair-type.model';
import { Service } from 'src/logic/service.service';
import { TableType } from 'src/logic/table-type.model';
import { MattressType } from 'src/logic/mattress-type.model';
import { WaterType } from 'src/logic/water-type.model';
import * as $ from 'jquery';

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

  constructor(private service: Service) { 
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
      $(".mat-step-label").css("font-size", "15px");
      $(".mat-step-label").css("font-family", "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif");
      $(".mat-vertical-stepper-header.mat-step-header").css("height", "20px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding", "18px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding-left", "0px");
      $(".mat-vertical-content-container.mat-stepper-vertical-line").css("margin-left", "12px")
      $("#cdk-step-label-0-6").hide()
    });
  }

}
