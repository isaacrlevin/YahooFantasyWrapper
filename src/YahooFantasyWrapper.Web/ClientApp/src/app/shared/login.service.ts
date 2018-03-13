import { Injectable, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Http, URLSearchParams } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';
import { UserService } from './user.service';
import { IUser } from '../models/User';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class LoginService {

  User: IUser;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  login(code: string) {
    return this.http.get<IUser>(`${this.baseUrl}api/Account/GetAuth?code=${code}`);
  }
}
