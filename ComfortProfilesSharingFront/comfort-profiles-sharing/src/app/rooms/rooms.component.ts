import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomState } from 'src/logic/room-state.model';
import * as $ from 'jquery';
import { MatDialog } from '@angular/material';
import { ChangeClimatComponent } from '../change-climat/change-climat.component';
import { ChangeLightComponent } from '../change-light/change-light.component';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {
  appUserId = "";
  rooms : RoomState[] = [];
  roomIds = ["room1", "room2", "room3", "room4", "room5", "room7", "room8"];

  constructor(private service : Service, private activeRoute : ActivatedRoute, public dialog : MatDialog, private router: Router) {     
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
      this.service.getUserRooms(this.activeRoute.snapshot.params.id).subscribe(result => {
        this.rooms = result;
      });
    });
  }

  ngOnInit() {
    this.service.getUserRooms(this.activeRoute.snapshot.params.id).subscribe(result => {
      for (let i = 0; i < result.length; i++){
        $("." + result[i].id).attr("id", this.roomIds[Math.floor(Math.random() * 6)]);
      }
    });
  }

  OpenTemperatureDialog(roomId){
    const dialogRef = this.dialog.open(ChangeClimatComponent, {
      width: '600px',
      height: '520px',
      data: roomId
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(dialogRef.componentInstance.result);
      this.service.getUserRooms(this.appUserId).subscribe(result => {
        location.reload();
      });
    });
  }

  OpenlightningDialog(roomId){
    const dialogRef = this.dialog.open(ChangeLightComponent, {
      width: '600px',
      height: '520px',
      data: roomId
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(dialogRef.componentInstance.result);
      this.service.getUserRooms(this.appUserId).subscribe(result => {
        location.reload();
      });
    });
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

  moveToComfortProfile(){
    this.router.navigate(['/comfort-profile', this.appUserId]);
  }

  moveToInstructions() {
    this.router.navigate(['/instructions', this.appUserId]);
  }

  signOut(){
    this.router.navigate(['/home']);
  }
}
