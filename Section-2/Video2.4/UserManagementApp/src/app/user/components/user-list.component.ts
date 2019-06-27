import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  allUsers: User[];
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAllUSers().subscribe(
      (data) => {
        this.allUsers = data;
      }
    );
  }


}
