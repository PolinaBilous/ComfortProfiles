import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/logic/service.service';

@Component({
  selector: 'app-instructions',
  templateUrl: './instructions.component.html',
  styleUrls: ['./instructions.component.css']
})
export class InstructionsComponent implements OnInit {

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
