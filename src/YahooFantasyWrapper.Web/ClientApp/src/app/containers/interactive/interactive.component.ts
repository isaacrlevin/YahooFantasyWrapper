import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { OnInit, Component, Inject } from '@angular/core';
import { LoginService } from './../../shared/login.service';
import { InteractiveService } from './../../shared/index';
import { NgbTabChangeEvent } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-interactive',
  templateUrl: './interactive.component.html',
})
export class InteractiveComponent {
  games: any[];
  leagues: any[];
  selectedGame: string = null;
  selectedLeague: string = null;
  data: any;
  leagueLoaded: boolean = false;
  league: any;
  public loading = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute,
    private interactiveService: InteractiveService
  ) { }

  ngOnInit() {
    this.loading = true;
    this.interactiveService.getGames().subscribe(result => {
      this.games = result;
      this.loading = false;
    }, error => console.error(error));
  }

  changeTab($event: NgbTabChangeEvent) {
    switch ($event.nextId) {
      case "metadata":
        this.getLeagueMetadata();
        break;
      case "standings":
        this.getLeagueStandings();
        break;
      default:
        break;
    }
  };

  getLeagues() {
    this.selectedLeague = null;
    this.loading = true;
    this.interactiveService.getLeagues(this.selectedGame).subscribe(result => {
      this.leagues = result;
      this.loading = false;
    }, error => console.error(error));
  }

  getLeagueMetadata() {
    if (this.leagueLoaded) {
    }
    else {
      this.loading = true;
      this.interactiveService.getLeagueMetadata(this.selectedLeague).subscribe(result => {
        this.league = result;
        this.loading = false;
        this.leagueLoaded = true;
      }, error => console.error(error));
    }
  }

  getLeagueStandings() {
    this.loading = true;
    this.interactiveService.getLeagueStandings(this.selectedLeague).subscribe(result => {
      if (this.leagueLoaded) {
        this.league.standings = result.standings;
        this.league = Object.assign({}, this.league);
      }
      else {
        this.league = result;
      }
      this.loading = false;
      this.leagueLoaded = true;
    }, error => console.error(error));
  }

  getLeagueTeams() {
    this.loading = true;
    this.interactiveService.getLeagueTeams(this.selectedLeague).subscribe(result => {
      if (this.leagueLoaded) {
        this.league.teamList = result.teamList;
        this.league = Object.assign({}, this.league);
      }
      else {
        this.league = result;
      }
      this.loading = false;
      this.leagueLoaded = true;
    }, error => console.error(error));
  }
  getLeagueSettings() {
    this.loading = true;
    this.interactiveService.getLeagueSettings(this.selectedLeague).subscribe(result => {
      if (this.leagueLoaded) {
        this.league.settings = result.settings;
        this.league = Object.assign({}, this.league);
      }
      else {
        this.league = result;
      }
      this.loading = false;
      this.leagueLoaded = true;
    }, error => console.error(error));
  }
}
