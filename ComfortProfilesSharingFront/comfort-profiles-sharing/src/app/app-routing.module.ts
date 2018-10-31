import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { StaticInfoComponent } from './static-info/static-info.component';
import { AddRoomsComponent } from './add-rooms/add-rooms.component';
import { RoomsComponent } from './rooms/rooms.component';

const routes: Routes = [
  {path: "sign-in", component: SignInComponent}, 
  {path: "sign-up", component: SignUpComponent}, 
  {path: "home", component: HomeComponent},
  {path: "info/:id", component: StaticInfoComponent},
  {path: "add-rooms/:id", component: AddRoomsComponent},
  {path: "rooms/:id", component: RoomsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
