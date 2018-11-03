import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material';
import { Service } from 'src/logic/service.service';
import { HowOften } from 'src/logic/how-often.model';
import * as $ from 'jquery';
import { IlluminationLog } from 'src/logic/illumination-log.model';

@Component({
  selector: 'app-change-light',
  templateUrl: './change-light.component.html',
  styleUrls: ['./change-light.component.css']
})
export class ChangeLightComponent implements OnInit {

  howOftens : HowOften[] = [];
  lightIntensities = [];
  roomId;
  isLight;
  lightIntensity;
  date;
  howOftenId;
  result;

  constructor(
    public dialogRef: MatDialogRef<ChangeLightComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string, private service : Service) {
      this.roomId = data;
      this.service.getHowOftens().subscribe(result => {
        this.howOftens = result;
      });

      for (let i = 5; i < 100; i+=5){
       this.lightIntensities.push(i);
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
      $("#cdk-step-label-2-4").hide();
      $("#cdk-step-label-3-4").hide()
      $("#cdk-step-label-4-4").hide();
      $("#cdk-step-label-5-4").hide()
    });
  }

  submitHandler(){
    let illuminationLog : IlluminationLog = new IlluminationLog();
    illuminationLog.howOftenId = this.howOftenId;
    if (this.isLight == 0)
      illuminationLog.isLight = false;
    if (this.isLight == 1)
      illuminationLog.isLight = true;
    if (this.lightIntensity !== undefined){
      illuminationLog.lightIntensity = (Number)(JSON.stringify(this.lightIntensity).substring(0, 2));
    }
    else {
      illuminationLog.lightIntensity = 0;
    }
    illuminationLog.roomId = this.roomId;
    illuminationLog.date = JSON.stringify(this.date).substring(1, 25);

    console.log(illuminationLog);
    this.service.changeIllumination(illuminationLog).subscribe(result => {
      console.log(result);
      this.dialogRef.componentInstance.result = result; 
      this.dialogRef.close();
    });
  }

  hideShowLightIntensity(e){
    if (this.isLight == 0){
      $("mat-vertical-stepper").children().first().next().hide();
      $("#cdk-overlay-0").css("height", "460px");
    }
    else {
      $("mat-vertical-stepper").children().first().next().show();
      $("#cdk-overlay-0").css("height", "520px");
    }
  }

}
