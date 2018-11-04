import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Service } from 'src/logic/service.service';
import { CoffeeDeviceState } from 'src/logic/coffee-device-state.model';
import { TeapotState } from 'src/logic/teapot-state.model';
import { MatDialog, MatSnackBar } from '@angular/material';
import { MakeCoffeeComponent } from '../make-coffee/make-coffee.component';
import { CoffeeLog } from 'src/logic/coffee-log.model';
import { BoilWaterComponent } from '../boil-water/boil-water.component';

@Component({
  selector: 'app-coffee-and-tea',
  templateUrl: './coffee-and-tea.component.html',
  styleUrls: ['./coffee-and-tea.component.css']
})
export class CoffeeAndTeaComponent implements OnInit {
  appUserId;
  position = new FormControl("above"); 
  coffeeDeviceState:any;
  teapotState:any; 
  
  constructor(private activeRoute : ActivatedRoute, private service : Service, public dialog : MatDialog, public snackBar: MatSnackBar) { 
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
      this.service.getCoffeeDeviceState(this.appUserId).subscribe(result => {
        this.coffeeDeviceState = result;
        console.log(result);
      });

      this.service.getTeapotState(this.appUserId).subscribe(result => {
        this.teapotState = result;
      });
    });
    }

  ngOnInit() {
    $("#cdk-describedby-message-container").css("font-size", "40px");
  }

  boilWaterHandler(){
    const dialogRef = this.dialog.open(BoilWaterComponent, {
      width: '600px',
      height: '450px',
      data: this.appUserId
    });

    dialogRef.afterClosed().subscribe(result => {
          this.snackBar.open("You water is boiling!", "Ok", {
            duration: 3000,
          });
          setTimeout(() => 
          {
            this.snackBar.open("You water is boiled!", "Ok", {
              duration: 3000,
            });
            this.service.getTeapotState(this.appUserId).subscribe(result => {
              this.teapotState = result;
            });
          },
          7000);
    });
  }

  makeCoffeeHandler(){
    const dialogRef = this.dialog.open(MakeCoffeeComponent, {
      width: '600px',
      height: '450px',
      data: this.appUserId
    });

    dialogRef.afterClosed().subscribe(result => {
      this.service.getCoffeeDeviceState(this.appUserId).subscribe(result => {
        if (result.CurrentWaterAmount != 100){
          this.snackBar.open("You coffee is in process!", "Ok", {
            duration: 3000,
          });
          setTimeout(() => 
          {
            this.snackBar.open("You coffee is done!", "Ok", {
              duration: 3000,
            });
            this.coffeeDeviceState = result;
          },
          7000);
        }
        else {
          this.coffeeDeviceState = result;
        }
      });
    });
  }
}
