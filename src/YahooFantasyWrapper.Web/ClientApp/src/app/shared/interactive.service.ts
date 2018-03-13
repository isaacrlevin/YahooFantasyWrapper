import { Injectable, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Http, URLSearchParams } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';
import { UserService } from './user.service';
import { IUser } from '../models/User';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class InteractiveService {

  User: IUser;

  constructor(
    private http: HttpClient,
    private userService: UserService,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getGames() {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetGames`, null);
  }

  getLeagues(gameKey: string) {
    let user = this.userService.getUser();
    return this.http.get<any>(`${this.baseUrl}api/Interactive/GetLeagues?gameKey=${gameKey}`);
  }

  getLeagueMetadata(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.get<any>(`${this.baseUrl}api/Interactive/GetLeagueMetadata?leagueKey=${leagueKey}`);
  }

  getLeagueStandings(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.get<any>(`${this.baseUrl}api/Interactive/GetLeagueStandings?leagueKey=${leagueKey}`);
  }
  getLeagueSettings(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.get<any>(`${this.baseUrl}api/Interactive/GetLeagueSettings?leagueKey=${leagueKey}`);
  }
  getLeagueTeams(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.get<any>(`${this.baseUrl}api/Interactive/GetLeagueTeams?leagueKey=${leagueKey}`);
  }
}
