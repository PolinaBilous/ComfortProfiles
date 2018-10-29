import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  email: string;
  name: string;
  password : string;
  constructor(private service : Service) { }

  ngOnInit() {
  }

  signUpHandler(){
    this.service.registerUser(this.email, this.name, this.password).subscribe(result => {
      if (result.message == "ok"){
        alert("ok, id: " + result.appUser["id"] + ", name: " + result.appUser["name"]);
      }
      else {
        alert("error");
      }
    });
  }
}
