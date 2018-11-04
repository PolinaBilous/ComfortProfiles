import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiTestComponent } from './api-test/api-test.component';
import { Service } from 'src/logic/service.service';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { SignUpComponent } from './sign-up/sign-up.component';
import { StaticInfoComponent } from './static-info/static-info.component';
import {MatStepperModule} from '@angular/material/stepper';
import {MatSelectModule} from '@angular/material/select';
import {Router, ActivatedRoute} from "@angular/router";
import { AddRoomsComponent, LoadingDialog } from './add-rooms/add-rooms.component';
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material';
import {MatProgressSpinnerModule, MatProgressSpinner} from '@angular/material/progress-spinner';
import { RoomsComponent } from './rooms/rooms.component';
import { ChangeClimatComponent } from './change-climat/change-climat.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule, OWL_DATE_TIME_FORMATS } from 'ng-pick-datetime';
import { ChangeLightComponent } from './change-light/change-light.component';
import { InfoComponent } from './info/info.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { CoffeeAndTeaComponent } from './coffee-and-tea/coffee-and-tea.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatTooltipModule} from '@angular/material/tooltip';
import { MakeCoffeeComponent } from './make-coffee/make-coffee.component';
import { BoilWaterComponent } from './boil-water/boil-water.component'

export const MY_NATIVE_FORMATS = {
  parseInput: 'l LT',
  fullPickerInput: 'l LT',
  datePickerInput: 'l',
  timePickerInput: 'LT',
  monthYearLabel: 'MMM YYYY',
  dateA11yLabel: 'LL',
  monthYearA11yLabel: 'MMMM YYYY',
};

@NgModule({
  declarations: [
    AppComponent,
    ApiTestComponent,
    SignInComponent,
    HomeComponent,
    SignUpComponent,
    StaticInfoComponent,
    AddRoomsComponent, 
    LoadingDialog, 
    RoomsComponent, 
    ChangeClimatComponent, 
    ChangeLightComponent, 
    InfoComponent, CoffeeAndTeaComponent, MakeCoffeeComponent, BoilWaterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatStepperModule,
    MatSelectModule, 
    MatDialogModule,
    MatProgressSpinnerModule, 
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MatSnackBarModule, 
    MatProgressBarModule,
    MatTooltipModule
  ],
  exports: [
  ],
  providers: [
    Service
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    LoadingDialog, 
    ChangeClimatComponent, 
    ChangeLightComponent, 
    MakeCoffeeComponent, 
    BoilWaterComponent
  ]
})
export class AppModule { }
