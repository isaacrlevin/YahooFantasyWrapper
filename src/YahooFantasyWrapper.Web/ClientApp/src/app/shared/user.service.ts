import { Injectable } from '@angular/core';
import { IUser } from '../models/User';
import { Router } from '@angular/router';
@Injectable()
export class UserService {
  private user: IUser;
  constructor(private router: Router) { }
  

  getUser(): IUser {
    if (this.user === undefined) {
      this.user = JSON.parse(localStorage.getItem('currentUser'));
    }
    return this.user;
  }

  setUser(user: IUser) {
    localStorage.removeItem('currentUser');
    this.user = user;
    localStorage.setItem('currentUser', JSON.stringify(user));
    this.router.navigate(['/']);
  }
}
