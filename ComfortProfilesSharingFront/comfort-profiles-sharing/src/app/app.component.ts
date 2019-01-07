import { Component } from '@angular/core';
import { Service } from 'src/logic/service.service';
import { Observable } from 'rxjs/internal/Observable';
import { interval } from 'rxjs';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'comfort-profiles-sharing';

  constructor(private service : Service, public snackBar : MatSnackBar) {
    var isCoffeeNeeded = () => {
      var url = window.location.href;
      var arr = url.split('/');
      var id = arr[arr.length - 1];
    
      this.service.makeCupOfCoffeeIfNeeded(id).subscribe(result => {
        if ((result as any).message == 'ok'){

        }
        else {
          
        }
      });
    }
      setInterval(() => {
        isCoffeeNeeded()
      }, 60000);
    }
  }
