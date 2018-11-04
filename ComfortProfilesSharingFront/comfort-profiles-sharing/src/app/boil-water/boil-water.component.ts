import { Component, OnInit, Inject } from '@angular/core';
import { HowOften } from 'src/logic/how-often.model';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { Service } from 'src/logic/service.service';
import { TeapotLog } from 'src/logic/teapot-log.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-boil-water',
  templateUrl: './boil-water.component.html',
  styleUrls: ['./boil-water.component.css']
})
export class BoilWaterComponent implements OnInit {

  appUserId;
  howOftens:HowOften[];
  temperature;
  date;
  howOftenId;
  coffeeTypeId;

  constructor(
    public dialogRef: MatDialogRef<BoilWaterComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string, private service : Service, public snackBar : MatSnackBar) {
      this.appUserId = data;
      this.service.getHowOftens().subscribe(result => {
        this.howOftens = result;
      });
    }

  ngOnInit() {
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
  }

  submitHandler(){
    let teapotLog:TeapotLog = new TeapotLog();
    teapotLog.appUserId = this.appUserId;
    teapotLog.dateTime = this.date;
    teapotLog.howOftenId = this.howOftenId;
    teapotLog.temperature = this.temperature;

    this.service.boilWater(teapotLog).subscribe(result => {
        this.dialogRef.close();
    });
  }

}
