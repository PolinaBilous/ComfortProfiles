import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  email : string = "";
  password : string = "";

  constructor(private service: Service) { }

  ngOnInit() {
  }

  signInHandler(){
    this.service.loginUser(this.email, this.password).subscribe(result => {
      if (result.message == "ok"){
        alert("ok, id: " + result.appUser["id"] + ", name: " + result.appUser["name"]);
      }
      else {
        alert("error");
      }
    });
  }

}
