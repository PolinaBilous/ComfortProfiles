import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router, ActivatedRoute } from '@angular/router';
import { Service } from 'src/logic/service.service';
import { MatDialog, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-rooms',
  templateUrl: './add-rooms.component.html',
  styleUrls: ['./add-rooms.component.css']
})
export class AddRoomsComponent implements OnInit {
  appUserId = "";
  constructor(private router : Router, private service : Service, private activeRoute : ActivatedRoute, public dialog : MatDialog) { 
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
    });
  }

  firstRoom : string = "";
  secondRoom : string = "";
  thirdRoom : string = "";
  fourthRoom : string = "";
  fifthRoom : string = "";


  ngOnInit() {
    $(document).ready(function(){
      $(".mat-step-label").css("font-size", "15px");
      $(".mat-step-label").css("font-family", "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif");
      $(".mat-vertical-stepper-header.mat-step-header").css("height", "20px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding", "18px");
      $(".mat-vertical-stepper-header.mat-step-header").css("padding-left", "0px");
      $(".mat-vertical-content-container.mat-stepper-vertical-line").css("margin-left", "12px")
      $("#cdk-step-label-0-5").hide();
      $("#cdk-step-label-1-5").hide()
    });
  }

  onFinish() {
    if (this.firstRoom != "")
      this.service.addRoom(this.firstRoom, this.appUserId).subscribe(result => console.log(result));
    if (this.secondRoom != "")
      this.service.addRoom(this.secondRoom, this.appUserId).subscribe(result => console.log(result));
    if (this.thirdRoom != "")
      this.service.addRoom(this.thirdRoom, this.appUserId).subscribe(result => console.log(result));
    if (this.fourthRoom != "")
      this.service.addRoom(this.fourthRoom, this.appUserId).subscribe(result => console.log(result));
    if (this.fifthRoom != "")
    this.service.addRoom(this.fifthRoom, this.appUserId).subscribe(result => console.log(result));
    this.openDialog();
  }


  openDialog(): void {
    const dialogRef = this.dialog.open(LoadingDialog, {
      width: '550px',
    });

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    // });
    setTimeout(() => 
    {
        dialogRef.close();
        this.router.navigate(['/rooms', this.appUserId]);
    },
    7000);
  }

}

@Component({
  selector: 'loading-dialog',
  templateUrl: 'loading-dialog.html',
})
export class LoadingDialog {

  constructor(
    public dialogRef: MatDialogRef<LoadingDialog>) {}

}
