import { Component, OnInit } from '@angular/core';
import { User } from '../IUser';
import { allUsers } from '../allUsers';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  constructor() { }

  ngOnInit() {    
    this.users = allUsers;
  }
}
