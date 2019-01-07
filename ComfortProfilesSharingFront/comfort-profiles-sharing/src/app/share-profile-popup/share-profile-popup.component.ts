import { Component, OnInit, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-share-profile-popup',
  templateUrl: './share-profile-popup.component.html',
  styleUrls: ['./share-profile-popup.component.css']
})
export class ShareProfilePopupComponent implements OnInit {

  link : string;
  id;
  constructor(private router : Router, private bottomSheetRef: MatBottomSheetRef<ShareProfilePopupComponent>, @Inject(MAT_BOTTOM_SHEET_DATA) public data: any) {
    this.link = window.location.hostname + ':' + window.location.port + "/comfort-profilec34f7a729bcff10296a899190aee21859ff757e2e0bbcb99/" + data;
    this.id = data;
  }

  ngOnInit() {
  }
}
