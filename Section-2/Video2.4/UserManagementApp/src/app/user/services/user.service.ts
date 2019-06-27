import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { allUSers } from '../models/allUsers';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getAllUSers():Observable<User[]>{
    return of(allUSers);
  }
}
