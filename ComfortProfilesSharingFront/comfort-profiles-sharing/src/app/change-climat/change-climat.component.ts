import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material';
import { Service } from 'src/logic/service.service';
import * as $ from 'jquery';
import { HowOften } from 'src/logic/how-often.model';
import { ClimatLog } from 'src/logic/climat-log.model';
import * as moment from 'moment';

@Component({
  selector: 'app-change-climat',
  templateUrl: './change-climat.component.html',
  styleUrls: ['./change-climat.component.css']
})
export class ChangeClimatComponent implements OnInit {

  roomId = "";
  howOftens : HowOften[] = [];
  temperatureValues = [];
  airHumidityValues = [];
  temperature;
  airHumidity;
  date;
  howOftenId;
  result;
  constructor(
    public dialogRef: MatDialogRef<ChangeClimatComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string, private service : Service) {
      this.roomId = data;
      this.service.getHowOftens().subscribe(result => {
        this.howOftens = result;
      });

      for (let i = 15; i <= 35; i++){
        this.temperatureValues.push(i);
      }

      for (let i = 15; i < 60; i+=5){
        this.airHumidityValues.push(i);
      }
    }

  ngOnInit() {
    $(document).ready(function(){
      $(".mat-step-label").css("font-size", "15px");
      $(".mat-step-label").css("font-family", "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif");
      $(".mat-vertical-stepper-header.mat-step-header").css("height", "20px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding", "18px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding-left", "0px");
      $(".mat-vertical-content-container.mat-stepper-vertical-line").css("margin-left", "12px")
      $("#cdk-step-label-0-4").hide();
      $("#cdk-step-label-1-4").hide()
    });
  }

  submitHandler(){
    let climatLog : ClimatLog = new ClimatLog();
    climatLog.howOftenId = this.howOftenId;
    climatLog.airHumidity = (Number)(JSON.stringify(this.airHumidity).substring(0, 2));
    climatLog.temperature = (Number)(JSON.stringify(this.temperature).substring(0, 2));
    climatLog.roomId = this.roomId;
    climatLog.date = JSON.stringify(this.date).substring(1, 25);

    console.log(climatLog);
    this.service.changeClimat(climatLog).subscribe(result => {
      console.log(result);
      this.dialogRef.componentInstance.result = result; 
      this.dialogRef.close();
    });
  }

}