import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  email: string;
  name: string;
  password : string;
  constructor(private service : Service, private router : Router) { }

  ngOnInit() {
  }

  signUpHandler(){
    this.service.registerUser(this.email, this.name, this.password).subscribe(result => {
      if (result.message == "ok"){
        // alert("ok, id: " + result.appUser["id"] + ", name: " + result.appUser["name"]);
        this.router.navigate(['/info', result.appUser["id"]]);
      }
      else {
        alert("error");
      }
    });
  }
}
