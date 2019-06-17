import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [UserListComponent, UserDetailComponent, UserRegistrationComponent],
  imports: [
    CommonModule, RouterModule
  ]
})
export class UserModule { }
