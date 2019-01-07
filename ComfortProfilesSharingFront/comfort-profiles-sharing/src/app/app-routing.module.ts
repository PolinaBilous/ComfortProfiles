import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { StaticInfoComponent } from './static-info/static-info.component';
import { AddRoomsComponent } from './add-rooms/add-rooms.component';
import { RoomsComponent } from './rooms/rooms.component';
import { InfoComponent } from './info/info.component';
import { CoffeeAndTeaComponent } from './coffee-and-tea/coffee-and-tea.component';
import { ComfortProfileComponent } from './comfort-profile/comfort-profile.component';
import { InstructionsComponent } from './instructions/instructions.component';
import { ComfortProfileSharedComponent } from './comfort-profile-shared/comfort-profile-shared.component';

const routes: Routes = [
  {path: "sign-in", component: SignInComponent}, 
  {path: "sign-up", component: SignUpComponent}, 
  {path: "home", component: HomeComponent},
  {path: "info/:id", component: StaticInfoComponent},
  {path: "add-rooms/:id", component: AddRoomsComponent},
  {path: "rooms/:id", component: RoomsComponent},
  {path: "user-info/:id", component: InfoComponent},
  {path: "coffee-and-tea/:id", component: CoffeeAndTeaComponent},
  {path: "comfort-profile/:id", component: ComfortProfileComponent},
  {path: "instructions/:id", component: InstructionsComponent},
  {path: "comfort-profilec34f7a729bcff10296a899190aee21859ff757e2e0bbcb99/:id", component: ComfortProfileSharedComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
