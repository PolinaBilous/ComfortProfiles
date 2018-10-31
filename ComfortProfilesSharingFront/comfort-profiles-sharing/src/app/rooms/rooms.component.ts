import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { ActivatedRoute } from '@angular/router';
import { RoomState } from 'src/logic/room-state.model';
import * as $ from 'jquery';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {
  appUserId = "";
  rooms : RoomState[] = [];
  roomIds = ["room1", "room2", "room3", "room4", "room5", "room7", "room8"];
  constructor(private service : Service, private activeRoute : ActivatedRoute) {     
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

}
