import { Component, OnInit } from '@angular/core';
import { IUser } from '../IUser';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  Users: IUser[];
  constructor() { 
    this.Users = [{
      FName: 'John',
      LName: 'Smith',
      Email: 'jh@gmail.com',
      Age: 25
      },{
      FName: 'Mark',
      LName: 'Peterson',
      Email: 'mp@gmail.com',
      Age: 45
    }];
  }

  ngOnInit() {
  }

}
