import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { ColorComponent } from './components/color/color.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { HomeComponent } from './components/home/home.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { LoginComponent } from './components/user/login/login.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  {path:'', redirectTo:'/login', pathMatch:'full'},
  {path:'login', component:LoginComponent},
  
  {
    path:'dashboard', component:MainLayoutComponent, canActivate:[AuthGuard],
    children:[
      {path:'', component:HomeComponent},
      {path: 'user', component:UserComponent},
      {path: 'color', component:ColorComponent},



      {path: 'forbidden', component:ForbiddenComponent},
      {path:'**', component:PageNotFoundComponent}

    ]},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
