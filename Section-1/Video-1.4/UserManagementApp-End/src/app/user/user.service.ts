import { Injectable } from '@angular/core';
import { IUser } from './IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { 
    console.log('Service is running');
  }

  getAllUsers():IUser[]{
    return [{
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
}
