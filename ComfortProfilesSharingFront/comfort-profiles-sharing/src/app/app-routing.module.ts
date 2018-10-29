import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { StaticInfoComponent } from './static-info/static-info.component';

const routes: Routes = [
  {path: "sign-in", component: SignInComponent}, 
  {path: "sign-up", component: SignUpComponent}, 
  {path: "home", component: HomeComponent},
  {path: "info", component: StaticInfoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
