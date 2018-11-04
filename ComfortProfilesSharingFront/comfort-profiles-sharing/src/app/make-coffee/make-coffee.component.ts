import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { Service } from 'src/logic/service.service';
import { HowOften } from 'src/logic/how-often.model';
import { CoffeeType } from 'src/logic/coffee-type.model';
import * as $ from 'jquery';
import { CoffeeLog } from 'src/logic/coffee-log.model';

@Component({
  selector: 'app-make-coffee',
  templateUrl: './make-coffee.component.html',
  styleUrls: ['./make-coffee.component.css']
})
export class MakeCoffeeComponent implements OnInit {
  appUserId;
  howOftens:HowOften[];
  coffeeTypes:CoffeeType[];
  date;
  howOftenId;
  coffeeTypeId;

  constructor(
    public dialogRef: MatDialogRef<MakeCoffeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string, private service : Service, public snackBar : MatSnackBar) {
      this.appUserId = data;
      this.service.getHowOftens().subscribe(result => {
        this.howOftens = result;
      });

      this.service.getCoffeeTypes().subscribe(result => {
        console.log(result);
        this.coffeeTypes = result;
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
    let coffeeLog = new CoffeeLog();
    coffeeLog.AppUserId = this.appUserId;
    coffeeLog.CoffeeTypeId = this.coffeeTypeId;
    coffeeLog.DateTime = this.date;
    coffeeLog.HowOftenId = this.howOftenId;

    this.service.makeCupOfCoffee(coffeeLog).subscribe(result => {
      if (result.message == "ok"){
        this.dialogRef.close();
      }
      else {
        this.snackBar.open("Opps! You don't have enough milk, water or coffee.", "Ok", {
          duration: 2000,
        });
      }
    });
  }

}
