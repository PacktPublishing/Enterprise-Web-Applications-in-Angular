import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RouterModule, Routes } from "@angular/router";
import { UserListComponent } from './user/user-list/user-list.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserModule } from './user/user.module';
import { UserRegistrationComponent } from './user/user-registration/user-registration.component';

const appRoutes: Routes = [
  { path: '', redirectTo:'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'Users', component: UserListComponent },
  { path: 'Users/:id', component: UserDetailComponent },
  { path: 'UserRegistration', component: UserRegistrationComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule, RouterModule.forRoot(appRoutes), UserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
