import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './components/user-list.component';

@NgModule({
  declarations: [UserListComponent],
  imports: [
    CommonModule
  ],
  exports: [UserListComponent]
})
export class UserModule { }
