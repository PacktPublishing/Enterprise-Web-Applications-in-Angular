import { Component, OnInit } from '@angular/core';
import { IUser } from '../IUser';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  Users: IUser[];
  constructor(private userService: UserService) { 
    this.Users = this.userService.getAllUsers();
  }

  ngOnInit() {
  }

}
