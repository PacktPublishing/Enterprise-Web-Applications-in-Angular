import { Component, OnInit } from '@angular/core';
import { User } from '../IUser';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  selectedUser:User;
  constructor() { }   

  ngOnInit() {   
   
  }

}
