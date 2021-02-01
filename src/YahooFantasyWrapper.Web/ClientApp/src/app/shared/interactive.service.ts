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
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetGames`, { accessToken: this.userService.getUser().accessToken, key: null });
  }

  getLeagues(gameKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagues`, { accessToken: this.userService.getUser().accessToken, key: gameKey });
  }

  getLeagueMetadata(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagueMetadata`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }

  getLeagueStandings(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagueStandings`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }
  getLeagueSettings(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagueSettings`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }
  getLeagueTeams(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagueTeams`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }
  getLeagueScoreboard(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetLeagueScoreboard`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }
  getLeagueDraftResults(leagueKey: string) {
    let user = this.userService.getUser();
    return this.http.post<any>(`${this.baseUrl}api/Interactive/GetDraftResults`, { accessToken: this.userService.getUser().accessToken, key: leagueKey });
  }
}
