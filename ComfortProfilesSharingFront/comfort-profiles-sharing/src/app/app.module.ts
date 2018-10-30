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

@NgModule({
  declarations: [
    AppComponent,
    ApiTestComponent,
    SignInComponent,
    HomeComponent,
    SignUpComponent,
    StaticInfoComponent,
    AddRoomsComponent, 
    LoadingDialog
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
    MatProgressSpinnerModule
  ],
  exports: [
  ],
  providers: [Service],
  bootstrap: [AppComponent],
  entryComponents: [LoadingDialog]
})
export class AppModule { }
