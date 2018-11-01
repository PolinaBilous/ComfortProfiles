import { Component, OnInit } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  email : string = "";
  password : string = "";

  constructor(private service: Service, private router : Router) { }

  ngOnInit() {
  }

  signInHandler(){
    this.service.loginUser(this.email, this.password).subscribe(result => {
      if (result.message == "ok"){
        // alert("ok, id: " + result.appUser["id"] + ", name: " + result.appUser["name"]);
        this.router.navigate(['/rooms', result.appUser["id"]]);
      }
      else {
        alert("error");
      }
    });
  }

}
