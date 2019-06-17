import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { User } from '../IUser';
import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { allUsers } from '../allUsers';
@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  selectedUser:User;
  constructor(private route: ActivatedRoute) { }
  idVal: string;

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>         
         of(allUsers.find(p => p.EmpId == +params.get('id')))
    )).subscribe(userDetail => this.selectedUser = userDetail);
   
  }

}
