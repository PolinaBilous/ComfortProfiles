import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/logic/service.service';

@Component({
  selector: 'app-comfort-profile',
  templateUrl: './comfort-profile.component.html',
  styleUrls: ['./comfort-profile.component.css']
})
export class ComfortProfileComponent implements OnInit {

  appUserId;
  
  constructor(private activeRoute : ActivatedRoute, private router : Router, private service : Service) { 
    this.activeRoute.queryParams.subscribe(params => {
      this.appUserId = this.activeRoute.snapshot.params.id;
    });
    }

  ngOnInit() {
  }

  moveToComfortProfile(){
    this.router.navigate(['/comfort-profile', this.appUserId]);
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

  moveToInstructions() {
    this.router.navigate(['/instructions', this.appUserId]);
  }

  signOut(){
    this.router.navigate(['/home']);
  }
}
