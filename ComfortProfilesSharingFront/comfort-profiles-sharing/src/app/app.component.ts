import { Component } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { Observable } from 'rxjs/internal/Observable';
import { interval } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'comfort-profiles-sharing';

  constructor(private service : Service) {
    var isCoffeeNeeded = () => {
      var url = window.location.href;
      var arr = url.split('/');
      var id = arr[arr.length - 1];
    
      this.service.makeCupOfCoffeeIfNeeded(id).subscribe(result => {
        console.log(result);
      });
    }
      setInterval(() => {
        isCoffeeNeeded()
      }, 60000);
    }
  }
